using System;

namespace Physics_Data_Debug
{
    /// <summary>
    /// Stateless tire grip/thermal mathematical helpers.
    /// These formulas do not read memory or depend on WinForms controls.
    /// Runtime tuning inputs remain supplied by callers, preserving existing behavior.
    /// </summary>
    internal static class TireGripMath
    {
        public static double[] GetShiftFactor_Log10aT(double tempKelvins, double glassTransition, double x, double y, double z)
        {
            return new double[] { Math.Log10(Math.Pow(2.71828, y * ((tempKelvins - glassTransition - x) / (z + tempKelvins - glassTransition)))), y * ((tempKelvins - glassTransition - x) / (z + tempKelvins - glassTransition)) };//Log10(Ln(aT)) or Log10(aT). WF1 uses Log10(Ln(aT)), so array [0]
        }

        public static double CosineFunctionGrip(double log10_aT, double slideSpeed, double log10v_aT_PX, double log10v_aT_PY, double log10v_aT_PZ, double gripX, double gripY, double gripZ)
        {
            double log10v = Math.Log10(Math.Abs(slideSpeed));
            double log10vPX = log10v_aT_PX - log10_aT;
            double log10vPY = log10v_aT_PY - log10_aT;
            double log10vPZ = log10v_aT_PZ - log10_aT;
        

            if (log10v < log10vPY)
            {
                if (log10v < log10vPX)
                {
                    return gripX;
                }
                else
                {
                    return (0.75 - (0.25 * Math.Cos((log10v - log10vPX) * Math.PI / (log10vPY - log10vPX))) - 0.5) / 0.5 * (gripY - gripX) + gripX;
                }
            }
            else
            {
                if (log10v < log10vPZ)
                {
                    return (0.75 + (0.25 * Math.Cos((log10v - log10vPY) * Math.PI / (log10vPZ - log10vPY))) - 0.5) / 0.5 * (gripY - gripZ) + gripZ;
                }
                else
                {
                    return gripZ;
                }
            }
        }

        public static double LoadSensGrip(double verticalLoad, double power, double offset)
        {
            return Math.Pow(verticalLoad + offset, power) / Math.Pow(offset, power);
        }

    }
}
