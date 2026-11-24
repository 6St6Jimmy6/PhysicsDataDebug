using System;

namespace Physics_Data_Debug
{
    public class DataItem
    {
        public string Name { get; set; }
        // Exact JSON group for unambiguous fields shared by multiple wheel chunks.
        internal string SourceGroup { get; set; }
        // Raw values are assigned on each telemetry refresh. Derived values use a
        // per-sample lazy getter, so unrequested formulas cost nothing.
        // A newly initialized field is unavailable until its first sample.
        // Preserve a consistent float32 type rather than exposing null to
        // chart calculations during menu -> race transitions.
        private object storedValue = float.NaN;
        private int cachedSample = -1;
        private bool evaluating;
        internal Func<double> Calculator { get; set; }
        public object Value
        {
            get
            {
                if (Calculator == null) return storedValue;
                if (cachedSample != LiveData.TelemetryGeneration)
                {
                    if (evaluating) throw new InvalidOperationException("Cyclic calculated telemetry dependency: " + Name);
                    evaluating = true;
                    try
                    {
                        storedValue = (float)Calculator();
                        cachedSample = LiveData.TelemetryGeneration;
                    }
                    finally { evaluating = false; }
                }
                return storedValue;
            }
            set { storedValue = value; cachedSample = LiveData.TelemetryGeneration; }
        }
    }
}
