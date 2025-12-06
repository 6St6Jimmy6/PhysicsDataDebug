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
        public dynamic Value { get; set; }
        public int Unit { get; set; }
        public TextBox textBox { get; set; }
    }
}
