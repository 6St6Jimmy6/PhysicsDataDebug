using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;

namespace Physics_Data_Debug
{
    /// <summary>
    /// Shared palette and band calculations for the four-wheel plot and its legend.
    /// The original ten-color palettes are retained; other band counts interpolate them.
    /// Palette of 15 colorblind-friendly colors pal <- c("#000000","#004949","#009292","#ff6db6","#ffb6db", "#490092","#006ddb","#b66dff","#6db6ff","#b6dbff", "#920000","#924900","#db6d00","#24ff24","#ffff6d")
    /// https://i.pinimg.com/564x/c0/e2/0e/c0e20ea42efb8a6af48d72099286079b.jpg
    /// https://i.sstatic.net/4iwS1l.png
    /// </summary>
    internal static class GradientPalette
    {
        private static readonly Color[] DefaultColors =
        {
            Color.FromArgb(0, 0, 192), Color.FromArgb(64, 0, 192),
            Color.FromArgb(128, 0, 192), Color.FromArgb(192, 0, 192),
            Color.FromArgb(255, 0, 192), Color.FromArgb(255, 0, 128),
            Color.FromArgb(255, 0, 64), Color.FromArgb(255, 0, 0),
            Color.FromArgb(192, 0, 0), Color.FromArgb(128, 0, 0)
        };

        private static readonly Color[] GreenRedColors =
        {
            Color.FromArgb(0, 192, 0), Color.FromArgb(64, 192, 0),
            Color.FromArgb(128, 192, 0), Color.FromArgb(192, 192, 0),
            Color.FromArgb(255, 192, 0), Color.FromArgb(255, 128, 0),
            Color.FromArgb(255, 64, 0), Color.FromArgb(255, 0, 0),
            Color.FromArgb(192, 0, 0), Color.FromArgb(128, 0, 0)
        };

        private static readonly Color[] ColorblindColors =
        {
            Color.FromArgb(0, 73, 73), Color.FromArgb(0, 146, 146),
            Color.FromArgb(255, 109, 182), Color.FromArgb(73, 0, 146),
            Color.FromArgb(0, 109, 219), Color.FromArgb(182, 109, 255),
            Color.FromArgb(109, 182, 255), Color.FromArgb(255, 255, 109),
            Color.FromArgb(36, 255, 36), Color.FromArgb(219, 109, 0)
        };

        // Canonical names are also used by settings dropdowns. "Default" remains
        // supported as a legacy alias for saved profiles.
        public static readonly string[] AvailableSchemes =
        {
            "Colorblind", "Colorblind Reversed", "Blue Red", "Red Blue",
            "Green Red", "Red Green", "Red Green Blue", "Blue Green Red",
            "Red Yellow Green", "Green Yellow Red", "Blue Green Yellow",
            "Yellow Green Blue", "Purple Blue Green", "Green Blue Purple",
            "Blue White Red", "Red White Blue", "Black White", "White Black",
            "Viridis", "Viridis Reversed", "Plasma", "Plasma Reversed",
            "Inferno", "Inferno Reversed"
        };

        private static Color[] GradientStops(string name)
        {
            switch (name)
            {
                case "Red Green Blue": return new[] { Color.Red, Color.Lime, Color.Blue };
                case "Blue Green Red": return new[] { Color.Blue, Color.Lime, Color.Red };
                case "Red Yellow Green": return new[] { Color.Red, Color.Yellow, Color.Lime };
                case "Green Yellow Red": return new[] { Color.Lime, Color.Yellow, Color.Red };
                case "Blue Green Yellow": return new[] { Color.Blue, Color.Lime, Color.Yellow };
                case "Yellow Green Blue": return new[] { Color.Yellow, Color.Lime, Color.Blue };
                case "Purple Blue Green": return new[] { Color.Purple, Color.Blue, Color.Lime };
                case "Green Blue Purple": return new[] { Color.Lime, Color.Blue, Color.Purple };
                case "Blue White Red": return new[] { Color.Blue, Color.White, Color.Red };
                case "Red White Blue": return new[] { Color.Red, Color.White, Color.Blue };
                case "Black White": return new[] { Color.Black, Color.White };
                case "White Black": return new[] { Color.White, Color.Black };
                case "Viridis": return HexColors("#440154", "#3B528B", "#21918C", "#5EC962", "#FDE725");
                case "Viridis Reversed": return HexColors("#FDE725", "#5EC962", "#21918C", "#3B528B", "#440154");
                case "Plasma": return HexColors("#0D0887", "#7E03A8", "#CC4778", "#F89540", "#F0F921");
                case "Plasma Reversed": return HexColors("#F0F921", "#F89540", "#CC4778", "#7E03A8", "#0D0887");
                case "Inferno": return HexColors("#000004", "#57106E", "#BC3754", "#F98E09", "#FCFFA4");
                case "Inferno Reversed": return HexColors("#FCFFA4", "#F98E09", "#BC3754", "#57106E", "#000004");
                default: return null;
            }
        }

        private static Color[] HexColors(params string[] hex) =>
            Array.ConvertAll(hex, ColorTranslator.FromHtml);

        public static List<Color> Create(string scheme, int steps, int alpha, int divider)
        {
            if (steps < 1) throw new ArgumentOutOfRangeException(nameof(steps));
            if (divider < 1) throw new ArgumentOutOfRangeException(nameof(divider));

            Color[] source = GradientStops(scheme);
            if (source == null)
            {
                bool reversed = scheme == "Colorblind Reversed" ||
                    scheme == "Red Green" || scheme == "Red Blue";
                source = scheme == "Colorblind" || scheme == "Colorblind Reversed" ? ColorblindColors
                    : scheme == "Green Red" || scheme == "Red Green" ? GreenRedColors : DefaultColors;
                if (reversed)
                {
                    source = (Color[])source.Clone();
                    Array.Reverse(source);
                }
            }

            // Index 0 is intentionally unused; series names and bands start at 1.
            var result = new List<Color>(steps + 1) { Color.Transparent };
            for (int index = 1; index <= steps; index++)
            {
                double position = steps == 1 ? 0 : (index - 1.0) * (source.Length - 1) / (steps - 1);
                int left = (int)Math.Floor(position);
                int right = Math.Min(left + 1, source.Length - 1);
                double fraction = position - left;

                // Integer truncation is deliberate: at 10 steps this matches the original colors.
                int red = (int)(source[left].R + (source[right].R - source[left].R) * fraction) / divider;
                int green = (int)(source[left].G + (source[right].G - source[left].G) * fraction) / divider;
                int blue = (int)(source[left].B + (source[right].B - source[left].B) * fraction) / divider;
                result.Add(Color.FromArgb(Math.Max(0, Math.Min(255, alpha)), red, green, blue));
            }
            return result;
        }

        public static string SeriesSuffix(int band)
        {
            return "Color" + band.ToString(CultureInfo.InvariantCulture);
        }

        public static int GetBand(float z, float minimum, float maximum, int steps)
        {
            if (steps < 1) throw new ArgumentOutOfRangeException(nameof(steps));
            if (maximum <= minimum || float.IsNaN(z)) return 1;

            // Matches the original 10-band cutoff behavior, including both extremes.
            double position = (Math.Abs((double)z) - minimum) / (maximum - minimum);
            if (position <= 0) return 1;
            if (position >= 1) return steps;
            return Math.Min(steps, (int)Math.Floor(position * steps) + 1);
        }

        public static bool TryGetBandFromSeriesName(string name, int steps, out int band)
        {
            // Suffix matching avoids accidentally matching Color1 inside Color10.
            for (int i = 1; i <= steps; i++)
            {
                if (name.EndsWith(SeriesSuffix(i), StringComparison.Ordinal))
                {
                    band = i;
                    return true;
                }
            }
            band = 0;
            return false;
        }
    }
}
