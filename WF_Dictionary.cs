using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics_Data_Debug
{
    public class WF_Dictionary
    {
        public static Dictionary<WF_Prefix, DataItem> DefaultWF1Dictionary { get; set; } = new Dictionary<WF_Prefix, DataItem>
            {
                {
                    WF_Prefix.FL,
                    new DataItem
                    {
                        Id = 0,
                        FullAddress = 0,
                        BaseAddress = 0,
                        Offsets = new int[] { 0 },
                        Name = "Shit",
                        Value = 0f,
                        Unit = 0
                    }
                },
                {
                    WF_Prefix.Body,
                    new DataItem
                    {
                        Id = 0,
                        FullAddress = 0,
                        BaseAddress = 0,
                        Offsets = new int[] { 0 },
                        Name = "Shit",
                        Value = 0f,
                        Unit = 0
                    }
                },
            };
    }
}
