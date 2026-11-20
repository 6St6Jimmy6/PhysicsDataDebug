using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;

namespace Physics_Data_Debug
{
    /// <summary>
    /// Small, safe numeric expression compiler. No C# evaluation, reflection or script execution.
    /// Compile once on configuration load; the returned delegate only reads named telemetry values.
    /// </summary>
    internal sealed class TelemetryExpression
    {
        public Func<Func<string, double>, double> Evaluate { get; private set; }
        public string[] Dependencies { get; private set; }
        private readonly string text;
        private int position;
        private readonly HashSet<string> dependencies = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        private Func<Func<string, double>, double> compiled;

        private TelemetryExpression(string expression)
        {
            text = expression;
            if (string.IsNullOrWhiteSpace(text) || text.Length > 4096)
                throw new FormatException("Formula expression must have 1-4096 characters.");
            compiled = ParseOr();
            SkipSpace();
            if (position != text.Length) Fail("Unexpected token");
            Evaluate = read => {
                try
                {
                    double value = compiled(read);
                    return double.IsInfinity(value) ? double.NaN : value;
                }
                catch (ArithmeticException) { return double.NaN; }
            };
            Dependencies = dependencies.ToArray();
        }

        public static TelemetryExpression Compile(string expression) => new TelemetryExpression(expression);

        private void Fail(string message) { throw new FormatException(message + " at character " + position + " in expression '" + text + "'."); }
        private void SkipSpace() { while (position < text.Length && char.IsWhiteSpace(text[position])) position++; }
        private bool Take(string token)
        {
            SkipSpace();
            if (position + token.Length <= text.Length && string.CompareOrdinal(text, position, token, 0, token.Length) == 0)
            { position += token.Length; return true; }
            return false;
        }
        private Func<Func<string, double>, double> ParseOr()
        {
            var left = ParseAnd();
            while (Take("||")) { var a = left; var b = ParseAnd(); left = v => a(v) != 0 || b(v) != 0 ? 1 : 0; }
            return left;
        }
        private Func<Func<string, double>, double> ParseAnd()
        {
            var left = ParseEquality();
            while (Take("&&")) { var a = left; var b = ParseEquality(); left = v => a(v) != 0 && b(v) != 0 ? 1 : 0; }
            return left;
        }
        private Func<Func<string, double>, double> ParseEquality()
        {
            var left = ParseComparison();
            while (true)
            {
                if (Take("==")) { var a = left; var b = ParseComparison(); left = v => a(v) == b(v) ? 1 : 0; }
                else if (Take("!=")) { var a = left; var b = ParseComparison(); left = v => a(v) != b(v) ? 1 : 0; }
                else return left;
            }
        }
        private Func<Func<string, double>, double> ParseComparison()
        {
            var left = ParseSum();
            while (true)
            {
                if (Take("<=")) { var a = left; var b = ParseSum(); left = v => a(v) <= b(v) ? 1 : 0; }
                else if (Take(">=")) { var a = left; var b = ParseSum(); left = v => a(v) >= b(v) ? 1 : 0; }
                else if (Take("<")) { var a = left; var b = ParseSum(); left = v => a(v) < b(v) ? 1 : 0; }
                else if (Take(">")) { var a = left; var b = ParseSum(); left = v => a(v) > b(v) ? 1 : 0; }
                else return left;
            }
        }
        private Func<Func<string, double>, double> ParseSum()
        {
            var left = ParseProduct();
            while (true)
            {
                if (Take("+")) { var a = left; var b = ParseProduct(); left = v => a(v) + b(v); }
                else if (Take("-")) { var a = left; var b = ParseProduct(); left = v => a(v) - b(v); }
                else return left;
            }
        }
        private Func<Func<string, double>, double> ParseProduct()
        {
            var left = ParseUnary();
            while (true)
            {
                if (Take("*")) { var a = left; var b = ParseUnary(); left = v => a(v) * b(v); }
                else if (Take("/")) { var a = left; var b = ParseUnary(); left = v => b(v) == 0 ? double.NaN : a(v) / b(v); }
                else if (Take("%")) { var a = left; var b = ParseUnary(); left = v => a(v) % b(v); }
                else return left;
            }
        }
        private Func<Func<string, double>, double> ParseUnary()
        {
            if (Take("+")) return ParseUnary();
            if (Take("-")) { var a = ParseUnary(); return v => -a(v); }
            if (Take("!")) { var a = ParseUnary(); return v => a(v) == 0 ? 1 : 0; }
            return ParsePower();
        }
        private Func<Func<string, double>, double> ParsePower()
        {
            var left = ParseAtom();
            if (Take("^")) { var right = ParseUnary(); return v => Math.Pow(left(v), right(v)); }
            return left;
        }
        private Func<Func<string, double>, double> ParseAtom()
        {
            if (Take("("))
            {
                var inside = ParseOr();
                if (!Take(")")) Fail("Missing closing parenthesis");
                return inside;
            }
            SkipSpace();
            int begin = position;
            if (position < text.Length && (char.IsDigit(text[position]) || text[position] == '.'))
            {
                while (position < text.Length && (char.IsDigit(text[position]) || text[position] == '.')) position++;
                if (position < text.Length && (text[position] == 'e' || text[position] == 'E'))
                {
                    position++;
                    if (position < text.Length && (text[position] == '+' || text[position] == '-')) position++;
                    while (position < text.Length && char.IsDigit(text[position])) position++;
                }
                if (!double.TryParse(text.Substring(begin, position - begin), NumberStyles.Float,
                    CultureInfo.InvariantCulture, out double number) || double.IsInfinity(number))
                    Fail("Invalid numeric literal");
                return v => number;
            }
            if (position < text.Length && (char.IsLetter(text[position]) || text[position] == '_'))
            {
                position++;
                while (position < text.Length && (char.IsLetterOrDigit(text[position]) || text[position] == '_')) position++;
                string name = text.Substring(begin, position - begin);
                if (Take("("))
                {
                    var args = new List<Func<Func<string, double>, double>>();
                    if (!Take(")"))
                    {
                        do { args.Add(ParseOr()); } while (Take(","));
                        if (!Take(")")) Fail("Missing closing function parenthesis");
                    }
                    return Function(name, args);
                }
                if (string.Equals(name, "pi", StringComparison.OrdinalIgnoreCase)) return v => Math.PI;
                if (string.Equals(name, "e", StringComparison.OrdinalIgnoreCase)) return v => Math.E;
                dependencies.Add(name);
                return v => v(name);
            }
            Fail("Expected a number, field name or function");
            return null;
        }

        private Func<Func<string, double>, double> Function(string name,
            List<Func<Func<string, double>, double>> args)
        {
            string f = name.ToLowerInvariant();
            int count = args.Count;
            int required;
            switch (f)
            {
                case "normalizexzangle": case "sqrt": case "abs": case "sin": case "cos": case "tan":
                case "asin": case "acos": case "atan": case "log": case "log10":
                case "exp": case "floor": case "ceil": case "round": case "sign":
                    required = 1; break;
                case "atan2": case "pow": case "div0": case "hypot":
                case "xzanglerad": case "frictionangledeg":
                case "adhesiongrip": case "microgrip": case "macrogrip": required = 2; break;
                case "clamp": case "if": case "loadsensgrip": required = 3; break;
                case "casterangle": case "camberangle": case "steerangle":
                case "pitchangle": case "yawangle": case "rollangle": required = 16; break;
                case "localx": case "localy": case "localz": required = 19; break;
                case "min": case "max": required = -1; break;
                default: throw new FormatException("Unsupported formula function '" + name + "'.");
            }
            if (required >= 0 && count != required || required == -1 && count < 2)
                throw new FormatException("Function '" + name + "' received " + count + " arguments.");
            var a = args.ToArray();
            return v =>
            {
                // Conditional evaluation is lazy, avoiding errors in the unused branch.
                if (f == "if") return a[0](v) != 0 ? a[1](v) : a[2](v);
                if (f == "div0") { double denominator = a[1](v); return denominator == 0 ? 0 : a[0](v) / denominator; }
                if (count == 16 || count == 19)
                {
                    // Matrix functions take M11...M44 in row-major order.
                    // Local-component functions append three world XYZ values.
                    float[] p = a.Select(arg => (float)arg(v)).ToArray();
                    Matrix4x4 m = new Matrix4x4(
                        p[0],p[1],p[2],p[3], p[4],p[5],p[6],p[7],
                        p[8],p[9],p[10],p[11], p[12],p[13],p[14],p[15]);
                    if (count == 19)
                    {
                        Vector3 world = new Vector3(p[16],p[17],p[18]);
                        Vector3 local = TelemetryFormulas.WorldTransformToLocal(world,
                            TelemetryFormulas.WorldPositionBody(m), m);
                        return f == "localx" ? local.X : f == "localy" ? local.Y : local.Z;
                    }
                    Vector3 angles = TelemetryFormulas.CalcAngles(m);
                    if (f == "camberangle" || f == "rollangle")
                        return TelemetryFormulas.LoopAngleRad(-angles.Z, Math.PI * 0.5);
                    return f == "casterangle" || f == "pitchangle" ? -angles.X : -angles.Y;
                }
                double x = a[0](v);
                switch (f)
                {
                    case "sqrt": return Math.Sqrt(x);
                    case "abs": return Math.Abs(x);
                    case "sin": return Math.Sin(x);
                    case "cos": return Math.Cos(x);
                    case "tan": return Math.Tan(x);
                    case "asin": return Math.Asin(x);
                    case "acos": return Math.Acos(x);
                    case "atan": return Math.Atan(x);
                    case "log": return Math.Log(x);
                    case "log10": return Math.Log10(x);
                    case "exp": return Math.Exp(x);
                    case "floor": return Math.Floor(x);
                    case "ceil": return Math.Ceiling(x);
                    case "round": return Math.Round(x);
                    case "sign": return double.IsNaN(x) ? double.NaN : Math.Sign(x);
                    case "min": return a.Skip(1).Aggregate(x, (n, arg) => Math.Min(n, arg(v)));
                    case "max": return a.Skip(1).Aggregate(x, (n, arg) => Math.Max(n, arg(v)));
                    case "atan2": return Math.Atan2(x, a[1](v));
                    case "xzanglerad": return TelemetryFormulas.XZAngleRad(x, a[1](v));
                    case "normalizexzangle": return TelemetryFormulas.NormalizeXZAngle(x);
                    case "frictionangledeg": return TelemetryFormulas.FrictionAngleDeg(x, a[1](v));
                    case "adhesiongrip": return TelemetryFormulas.GripForExpression(x, a[1](v), "Adhesion");
                    case "microgrip": return TelemetryFormulas.GripForExpression(x, a[1](v), "Micro");
                    case "macrogrip": return TelemetryFormulas.GripForExpression(x, a[1](v), "Macro");
                    case "loadsensgrip": return TireGripMath.LoadSensGrip(x, a[1](v), a[2](v));
                    case "pow": return Math.Pow(x, a[1](v));
                    case "hypot": { double y = a[1](v); return Math.Sqrt(x * x + y * y); }
                    case "clamp": { double lo = a[1](v), hi = a[2](v); return Math.Min(Math.Max(x, lo), hi); }
                }
                return double.NaN;
            };
        }
    }
}
