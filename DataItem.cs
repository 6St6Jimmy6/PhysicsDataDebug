using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Physics_Data_Debug
{
    public class DataItem
    {
        public int Id { get; set; }
        public int Prefix { get; set; }
        public ulong BaseAddress { get; set; }
        public int[] Offsets { get; set; }
        public ulong FullAddress { get; set; }
        public string Name { get; set; }
        // Exact JSON group for unambiguous fields shared by multiple wheel chunks.
        internal string SourceGroup { get; set; }
        // Raw values are assigned on each telemetry refresh. Derived values use a
        // per-sample lazy getter, so unrequested formulas cost nothing.
        private dynamic storedValue;
        private int cachedSample = -1;
        private bool evaluating;
        internal Func<double> Calculator { get; set; }
        public dynamic Value
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
        public int Unit { get; set; }
        public TextBox textBox { get; set; }
    }
}
