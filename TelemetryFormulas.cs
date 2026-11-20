using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Physics_Data_Debug
{
    /// <summary>
    /// Shared, demand-driven telemetry formulas. Dependencies are symbolic field names,
    /// not memory offsets. Both live telemetry and imported CSV columns use the same
    /// definitions. Original values always take precedence over derived ones.
    ///
    /// Add new derived telemetry here; no CSV data needs to be rewritten or stored.
    /// </summary>
    internal static class TelemetryFormulas
    {

        // Reusable geometric and numeric helpers, formerly in LiveData.
        public static double RadToDeg(double toConvert)
        {
            return toConvert * (float)(180 / Math.PI);
        }

        public static double XZAngleRad(double x, double z)
        {
            if (x > 0)
            {
                if (z > 0)
                {
                    return (Math.PI + (Math.Atan(x / z)));
                }
                else if (z < 0)
                {
                    return (2 * Math.PI + (Math.Atan(x / z)));
                }
                else
                {
                    return 1.5 * Math.PI;
                }
            }
            else if (x < 0)
            {
                if (z > 0)
                {
                    return (Math.PI + (Math.Atan(x / z)));
                }
                else if (z < 0)
                {
                    return (0d + (Math.Atan(x / z)));
                }
                else
                {
                    return 0.5 * Math.PI;
                }
            }
            else
            {
                if (z > 0f)
                {
                    return Math.PI;
                }
                else if (z < 0f)
                {
                    return 2 * Math.PI;
                }
                else
                {
                    return 0d;
                }
            }
        }

        public static Vector3 CalcAngles(Matrix4x4 transformMatrix)
        {
            Quaternion quat = Quaternion.CreateFromRotationMatrix(transformMatrix);

            Vector3 pitchyawroll = GetPitchYawRollFromQuaternion(quat);
            // Pitch Yaw and Roll or Caster Toe and Camber
            //pitch = -pitchyawroll.X;// caster angle
            //yaw = -pitchyawroll.Y;// toe angle
            //roll = LoopAngleRad(-pitchyawroll.Z, (float)Math.PI * 0.5f);// camber angle
            return pitchyawroll;
        }

        public static Vector3 GetPitchYawRollFromQuaternion(Quaternion rotation)
        {
            float yaw = (float)Math.Atan2(2.0f * (rotation.Y * rotation.W + rotation.X * rotation.Z), 1.0f - 2.0f * (rotation.X * rotation.X + rotation.Y * rotation.Y));
            float pitch = (float)Math.Asin(2.0f * (rotation.X * rotation.W - rotation.Y * rotation.Z));
            float roll = (float)Math.Atan2(2.0f * (rotation.X * rotation.Y + rotation.Z * rotation.W), 1.0f - 2.0f * (rotation.X * rotation.X + rotation.Z * rotation.Z));

            return new Vector3(pitch, yaw, roll);
        }

        public static Vector3 WorldTransformToLocal(Vector3 worldXYZ, Vector3 worldPositionBody, Matrix4x4 transformMatrixBody)
        {
            worldXYZ.X = BigValueReducerFloat(worldXYZ.X);
            worldXYZ.Y = BigValueReducerFloat(worldXYZ.Y);
            worldXYZ.Z = BigValueReducerFloat(worldXYZ.Z);

            Matrix4x4 rotationInvertedBody = Matrix4x4.Identity;
            transformMatrixBody.Translation = worldPositionBody;
            Matrix4x4 rotation = new Matrix4x4();
            rotation = transformMatrixBody;
            rotation.M41 = 0.0f;
            rotation.M42 = 0.0f;
            rotation.M43 = 0.0f;
            rotation.M44 = 1.0f;

            rotationInvertedBody = new Matrix4x4();
            Matrix4x4.Invert(rotation, out rotationInvertedBody);

            //transform world acceleration to local space
            Vector3 local = Vector3.Transform(worldXYZ, rotationInvertedBody);
            //Vector3 localAcceleration = worldAcceleration;
            return local;
        }

        public static float BigValueReducerFloat(float value)
        {
            if (value > 10000 || value < -10000)
            {
                return 10000;
            }
            else
            {
                return value;
            }
        }

        public static double LoopAngleRad(double angle, double minMag)
        {
            double absAngle = Math.Abs(angle);

            if (absAngle <= minMag)
            {
                return angle;
            }

            double direction = angle / absAngle;

            //(180.0f * 1) - 135 = 45
            //(180.0f *-1) - -135 = -45
            double loopedAngle = (Math.PI * direction) - angle;

            return loopedAngle;
        }

        public static Vector3 WorldPositionBody(Matrix4x4 transformMatrixBody)
        {
            return new Vector3(transformMatrixBody.M41, transformMatrixBody.M42, transformMatrixBody.M43);
        }

        private sealed class Definition
        {
            internal string[] Dependencies;
            internal Func<Func<string, double>, double> Calculate;
        }

        private static readonly Dictionary<string, Definition> Definitions =
            new Dictionary<string, Definition>(StringComparer.OrdinalIgnoreCase);
        private static readonly List<string> PublicNames = new List<string>();

        private static void Add(string name, string[] dependencies, Func<Func<string, double>, double> expression,
            bool selectable = true)
        {
            Definitions.Add(name, new Definition { Dependencies = dependencies, Calculate = expression });
            if (selectable) PublicNames.Add(name);
        }

        private static string[] Fields(string stem)
        {
            var names = new List<string>();
            for (int r = 1; r <= 4; r++)
                for (int c = 1; c <= 4; c++) names.Add(stem + r + c);
            return names.ToArray();
        }

        private static Matrix4x4 Matrix(Func<string, double> v, string stem)
        {
            return new Matrix4x4(
                (float)v(stem + "11"), (float)v(stem + "12"), (float)v(stem + "13"), (float)v(stem + "14"),
                (float)v(stem + "21"), (float)v(stem + "22"), (float)v(stem + "23"), (float)v(stem + "24"),
                (float)v(stem + "31"), (float)v(stem + "32"), (float)v(stem + "33"), (float)v(stem + "34"),
                (float)v(stem + "41"), (float)v(stem + "42"), (float)v(stem + "43"), (float)v(stem + "44"));
        }

        // Preserve the existing game's zero-load convention rather than producing NaN.
        private static double DivideOrZero(double numerator, double denominator) =>
            denominator == 0 ? 0 : numerator / denominator;

        internal static double FrictionAngleDeg(double lateral, double longitudinal)
        {
            // Keep the original Wreckfest debugger quadrant/sign convention.
            if (lateral > 0)
                return longitudinal == 0 ? 90 : 90 - Math.Atan(longitudinal / lateral) * LiveData.RadDeg;
            if (lateral < 0)
            {
                if (longitudinal > 0) return 270 + Math.Atan(longitudinal / Math.Abs(lateral)) * LiveData.RadDeg;
                if (longitudinal < 0) return 270 - Math.Atan(longitudinal / lateral) * LiveData.RadDeg;
                return 270;
            }
            if (longitudinal > 0) return 360;
            if (longitudinal < 0) return 180;
            return 0;
        }

        internal static double GripForExpression(double log10aT, double slideSpeed, string kind)
        {
            if (kind == "Adhesion")
                return TireGripMath.CosineFunctionGrip(log10aT, slideSpeed,
                    FormLiveData.SlidingAdhesionPointLog10aTv_X, FormLiveData.SlidingAdhesionPointLog10aTv_Y,
                    FormLiveData.SlidingAdhesionPointLog10aTv_Z, FormLiveData.SlidingAdhesionGripX,
                    FormLiveData.SlidingAdhesionGripY, FormLiveData.SlidingAdhesionGripZ);
            if (kind == "Micro")
                return TireGripMath.CosineFunctionGrip(log10aT, slideSpeed,
                    FormLiveData.SlidingMicroPointLog10aTv_X, FormLiveData.SlidingMicroPointLog10aTv_Y,
                    FormLiveData.SlidingMicroPointLog10aTv_Z, FormLiveData.SlidingMicroGripX,
                    FormLiveData.SlidingMicroGripY, FormLiveData.SlidingMicroGripZ);
            return TireGripMath.CosineFunctionGrip(log10aT, slideSpeed,
                FormLiveData.SlidingMacroPointLog10aTv_X, FormLiveData.SlidingMacroPointLog10aTv_Y,
                FormLiveData.SlidingMacroPointLog10aTv_Z, FormLiveData.SlidingMacroGripX,
                FormLiveData.SlidingMacroGripY, FormLiveData.SlidingMacroGripZ);
        }

        private static double LocalComponent(Func<string, double> v, string worldStem, int component)
        {
            Matrix4x4 matrix = Matrix(v, "BodyM");
            Vector3 world = new Vector3((float)v("X" + worldStem + "World"),
                (float)v("Y" + worldStem + "World"), (float)v("Z" + worldStem + "World"));
            Vector3 local = WorldTransformToLocal(world, WorldPositionBody(matrix), matrix);
            return component == 0 ? local.X : component == 1 ? local.Y : local.Z;
        }

        internal static double NormalizeXZAngle(double angle)
        {
            if (angle >= 3 * Math.PI || angle <= -3 * Math.PI) return 0;
            if (angle < 0)
                return angle > 2 * Math.PI ? angle - 2 * Math.PI : 2 * Math.PI + angle;
            return angle > 2 * Math.PI ? angle - 2 * Math.PI : angle;
        }

        static TelemetryFormulas()
        {
            string[] tireMatrix = Fields("TireM");
            string[] bodyMatrix = Fields("BodyM");
            // Tire orientation (existing quaternion/angle convention).
            Add("CasterAngleRad", tireMatrix, v => -CalcAngles(Matrix(v, "TireM")).X);
            Add("CasterAngleDeg", new[] { "CasterAngleRad" }, v => RadToDeg(v("CasterAngleRad")));
            Add("CamberAngleRad", tireMatrix, v => LoopAngleRad(-CalcAngles(Matrix(v, "TireM")).Z, Math.PI * 0.5));
            Add("CamberAngleDeg", new[] { "CamberAngleRad" }, v => RadToDeg(v("CamberAngleRad")));
            Add("SteerAngleRad", tireMatrix, v => -CalcAngles(Matrix(v, "TireM")).Y);
            Add("SteerAngleDeg", new[] { "SteerAngleRad" }, v => RadToDeg(v("SteerAngleRad")));

            Add("LateralFriction", new[] { "LateralLoad", "VerticalLoad" },
                v => DivideOrZero(v("LateralLoad"), v("VerticalLoad")));
            Add("LongitudinalFriction", new[] { "LongitudinalLoad", "VerticalLoad" },
                v => DivideOrZero(v("LongitudinalLoad"), v("VerticalLoad")));
            Add("TotalFriction", new[] { "LateralFriction", "LongitudinalFriction" },
                v => Math.Sqrt(Math.Pow(v("LateralFriction"), 2) + Math.Pow(v("LongitudinalFriction"), 2)));
            Add("TotalFrictionAngleDeg", new[] { "LateralFriction", "LongitudinalFriction" },
                v => FrictionAngleDeg(v("LateralFriction"), v("LongitudinalFriction")));
            Add("SlipAngleDeg", new[] { "SlipAngleRad" }, v => RadToDeg(v("SlipAngleRad")));
            Add("RollingResistance", new[] { "Mx", "VerticalLoad" },
                v => DivideOrZero(v("Mx"), v("VerticalLoad")));
            Add("PneumaticTrail", new[] { "Mz", "LateralLoad" },
                v => DivideOrZero(v("Mz"), v("LateralLoad")));
            Add("TreadTemperatureKelvins", new[] { "TreadTemperature" },
                v => (float)v("TreadTemperature") + 273.15f);
            Add("Log10aT", new[] { "TreadTemperatureKelvins" },
                v => TireGripMath.GetShiftFactor_Log10aT(v("TreadTemperatureKelvins"),
                    FormLiveData.Tg, FormLiveData.TgX, FormLiveData.TgY, FormLiveData.TgZ)[0]);

            foreach (string direction in new[] { "Lateral", "Longitudinal" })
            {
                string prefix = direction;
                foreach (string gripType in new[] { "Adhesion", "Micro", "Macro" })
                {
                    string kind = gripType;
                    Add(prefix + kind + "Grip", new[] { "Log10aT", prefix + "SlipSpeed" },
                        v => GripForExpression(v("Log10aT"), v(prefix + "SlipSpeed"), kind));
                }
                Add("WLF_" + prefix + "SlidingFrictionGripMultiplier",
                    new[] { prefix + "AdhesionGrip", prefix + "MicroGrip", prefix + "MacroGrip" },
                    v => v(prefix + "AdhesionGrip") + v(prefix + "MicroGrip") + v(prefix + "MacroGrip"));
            }
            Add("LateralLoadSensGripMultiplier", new[] { "VerticalLoad" },
                v => TireGripMath.LoadSensGrip(v("VerticalLoad"), -0.05, 10300));
            Add("LongitudinalLoadSensGripMultiplier", new[] { "LateralLoadSensGripMultiplier" },
                v => v("LateralLoadSensGripMultiplier"));
            Add("LateralFrictionNoMultis", new[] { "LateralFriction", "WLF_LateralSlidingFrictionGripMultiplier", "LateralLoadSensGripMultiplier" },
                v => v("LateralFriction") / (v("WLF_LateralSlidingFrictionGripMultiplier") * v("LateralLoadSensGripMultiplier")));
            Add("LongitudinalFrictionNoMultis", new[] { "LongitudinalFriction", "WLF_LongitudinalSlidingFrictionGripMultiplier", "LongitudinalLoadSensGripMultiplier" },
                v => v("LongitudinalFriction") / (v("WLF_LongitudinalSlidingFrictionGripMultiplier") * v("LongitudinalLoadSensGripMultiplier")));
            Add("TotalFrictionNoMultis", new[] { "LateralFrictionNoMultis", "LongitudinalFrictionNoMultis" },
                v => Math.Sqrt(Math.Pow(v("LateralFrictionNoMultis"), 2) + Math.Pow(v("LongitudinalFrictionNoMultis"), 2)));

            // Engine power and torque unit conversions.
            Add("EngineTorqueLbFt", new[] { "EngineTorqueNm" }, v => (float)v("EngineTorqueNm") * 0.7375621493f);
            Add("EnginePowerKW", new[] { "EngineTorqueNm", "EngineRPM" },
                v => (float)v("EngineTorqueNm") * (float)v("EngineRPM") / 9548.8f);
            Add("EnginePowerHP", new[] { "EngineTorqueLbFt", "EngineRPM" },
                v => (float)v("EngineTorqueLbFt") * (float)v("EngineRPM") / 5252.1f);
            Add("EnginePowerPS", new[] { "EnginePowerHP" }, v => (float)v("EnginePowerHP") * 0.986f);
            Add("EnginePowerBHP", new[] { "EnginePowerKW" }, v => (float)v("EnginePowerKW") * 1.34102f);

            // Body orientation from the same quaternion used for tire orientation.
            Add("PitchRad", bodyMatrix, v => -CalcAngles(Matrix(v, "BodyM")).X);
            Add("PitchDeg", new[] { "PitchRad" }, v => RadToDeg(v("PitchRad")));
            Add("YawRad", bodyMatrix, v => -CalcAngles(Matrix(v, "BodyM")).Y);
            Add("YawDeg", new[] { "YawRad" }, v => RadToDeg(v("YawRad")));
            Add("RollRad", bodyMatrix, v => LoopAngleRad(-CalcAngles(Matrix(v, "BodyM")).Z, Math.PI * 0.5));
            Add("RollDeg", new[] { "RollRad" }, v => RadToDeg(v("RollRad")));

            // Local acceleration and drag require body orientation plus world XYZ.
            string[] accelDependencies = bodyMatrix.Concat(new[] { "XAccelerationWorld", "YAccelerationWorld", "ZAccelerationWorld" }).ToArray();
            Add("XAccelerationLocal", accelDependencies, v => LocalComponent(v, "Acceleration", 0));
            Add("YAccelerationLocal", accelDependencies, v => LocalComponent(v, "Acceleration", 1));
            Add("Body_ZAccelerationLocal", accelDependencies, v => LocalComponent(v, "Acceleration", 2));
            Add("XZAccelerationAngleRad", new[] { "XAccelerationLocal", "Body_ZAccelerationLocal" },
                v => XZAngleRad(v("XAccelerationLocal"), v("Body_ZAccelerationLocal")));
            Add("XZAccelerationAngleDeg", new[] { "XZAccelerationAngleRad" },
                v => RadToDeg(v("XZAccelerationAngleRad")));
            Add("XZAcceleration", new[] { "XAccelerationLocal", "Body_ZAccelerationLocal" },
                v => Math.Sqrt(Math.Pow(v("XAccelerationLocal"), 2) + Math.Pow(v("Body_ZAccelerationLocal"), 2)));
            Add("XYZAcceleration", new[] { "XZAcceleration", "YAccelerationLocal" },
                v => Math.Sqrt(Math.Pow(v("XZAcceleration"), 2) + Math.Pow(v("YAccelerationLocal"), 2)));
            Add("XG", new[] { "XAccelerationLocal" }, v => v("XAccelerationLocal") / LiveData.g);
            Add("YG", new[] { "YAccelerationLocal" }, v => v("YAccelerationLocal") / LiveData.g);
            Add("ZG", new[] { "Body_ZAccelerationLocal" }, v => v("Body_ZAccelerationLocal") / LiveData.g);
            Add("XZG", new[] { "XG", "ZG" }, v => Math.Sqrt(Math.Pow(v("XG"), 2) + Math.Pow(v("ZG"), 2)));
            Add("XYZG", new[] { "YG", "XZG" }, v => Math.Sqrt(Math.Pow(v("YG"), 2) + Math.Pow(v("XZG"), 2)));
            Add("XZGAngleRad", new[] { "XZAccelerationAngleRad" }, v => NormalizeXZAngle(v("XZAccelerationAngleRad")));
            Add("Body_XZGAngleDeg", new[] { "XZGAngleRad" }, v => RadToDeg(v("XZGAngleRad")));
            string[] dragDependencies = bodyMatrix.Concat(new[] { "XDragWorld", "YDragWorld", "ZDragWorld" }).ToArray();
            Add("XDragLocal", dragDependencies, v => LocalComponent(v, "Drag", 0));
            Add("YDragLocal", dragDependencies, v => LocalComponent(v, "Drag", 1));
            Add("ZDragLocal", dragDependencies, v => LocalComponent(v, "Drag", 2));
        }

        private static Dictionary<string, TelemetryExpression> configured =
            new Dictionary<string, TelemetryExpression>(StringComparer.Ordinal);

        public static bool HasBuiltIn(string field) => Definitions.ContainsKey(field ?? "");

        /// <summary>Compile JSON formulas once. Built-in formulas remain as fallbacks for
        /// quaternion transforms, WLF functions and legacy configurations.</summary>
        public static void Configure(IDictionary<string, string> expressions)
        {
            var next = new Dictionary<string, TelemetryExpression>(StringComparer.Ordinal);
            foreach (var entry in expressions)
                next.Add(entry.Key, TelemetryExpression.Compile(entry.Value));
            configured = next;
        }

        public static IReadOnlyList<string> Names => PublicNames.Concat(
            configured.Keys.Select(key => key.Substring(key.IndexOf('.') + 1)))
            .Distinct(StringComparer.OrdinalIgnoreCase).ToArray();
        public static bool IsCalculated(string field) => Definitions.ContainsKey(field ?? "") ||
            configured.Keys.Any(key => key.EndsWith("." + field, StringComparison.Ordinal));
        public static bool IsCalculated(string group, string field) =>
            configured.ContainsKey(group + "." + field) ||
                (CalculatedTelemetry.IsCalculated(group, field) && Definitions.ContainsKey(field ?? ""));

        public static IReadOnlyList<string> Dependencies(string group, string field)
        {
            if (configured.TryGetValue(group + "." + field, out TelemetryExpression expression))
                return expression.Dependencies;
            if (CalculatedTelemetry.IsCalculated(group, field) &&
                Definitions.TryGetValue(field ?? "", out Definition definition))
                return definition.Dependencies;
            return Array.Empty<string>();
        }

        public static double Calculate(string group, string field, Func<string, double> read)
        {
            if (configured.TryGetValue(group + "." + field, out TelemetryExpression expression))
                return expression.Evaluate(read);
            return Calculate(field, read);
        }

        /// <summary>Check configured names, source dependencies and cycles after the
        /// canonical LogData columns have been built.</summary>
        public static void ValidateConfiguration()
        {
            var byHeader = LogData.AllColumns.ToDictionary(c => c.Header,
                StringComparer.OrdinalIgnoreCase);
            var byKey = LogData.AllColumns.ToDictionary(c => c.Group + "." + c.Member + "." +
                (c.Wheel ?? ""), StringComparer.Ordinal);
            var visiting = new HashSet<string>(StringComparer.Ordinal);
            var complete = new HashSet<string>(StringComparer.Ordinal);
            foreach (LogData.Column column in LogData.AllColumns)
                if (IsCalculated(column.Group, column.Member)) Visit(column);

            void Visit(LogData.Column column)
            {
                string key = column.Key;
                if (complete.Contains(key)) return;
                if (!visiting.Add(key)) throw new FormatException("Circular calculated telemetry dependency: " + key);
                foreach (string dependency in Dependencies(column.Group, column.Member))
                {
                    LogData.Column target = Resolve(column, dependency);
                    if (target == null)
                        throw new FormatException("Unknown dependency '" + dependency + "' in calculated field " + key);
                    if (IsCalculated(target.Group, target.Member)) Visit(target);
                }
                visiting.Remove(key);
                complete.Add(key);
            }
            LogData.Column Resolve(LogData.Column origin, string name)
            {
                if (byHeader.TryGetValue(name, out LogData.Column direct)) return direct;
                // A bare field name first resolves within its own memory category.
                string key = origin.Group + "." + name + "." + (origin.Wheel ?? "");
                if (byKey.TryGetValue(key, out LogData.Column same)) return same;
                // Older built-ins refer to a field in a sibling category (such
                // as the body matrix used to calculate aerodynamic drag).
                var candidates = LogData.AllColumns.Where(c => c.Member == name && c.Wheel == origin.Wheel).ToArray();
                if (candidates.Length == 1) return candidates[0];
                if (candidates.Length > 1)
                    throw new FormatException("Ambiguous formula dependency '" + name + "' in " + origin.Key +
                        ". Use its category-prefixed public name.");
                return null;
            }
        }

        // Availability is structural: only show a formula if *all* inputs exist.
        // Physical CSV columns are checked first and always win (no duplicates).
        public static bool CanResolve(string field, Func<string, bool> hasRaw)
        {
            return CanResolve(field, hasRaw, new HashSet<string>(StringComparer.OrdinalIgnoreCase));
        }

        private static bool CanResolve(string field, Func<string, bool> hasRaw, HashSet<string> pending)
        {
            if (hasRaw(field)) return true;
            if (!Definitions.TryGetValue(field, out Definition definition) || !pending.Add(field)) return false;
            try { return definition.Dependencies.All(name => CanResolve(name, hasRaw, pending)); }
            finally { pending.Remove(field); }
        }

        public static double Calculate(string field, Func<string, double> read)
        {
            if (!Definitions.TryGetValue(field, out Definition definition))
                throw new KeyNotFoundException("No calculated telemetry formula for " + field);
            return definition.Calculate(read);
        }
    }
}
