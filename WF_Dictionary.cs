using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Physics_Data_Debug
{
    public class WF_Dictionary
    {
        public static Dictionary<WF_PrefixMain, Dictionary<WF_PrefixSecondary, DataItem>> DefaultWF1Dictionary { get; set; } = new Dictionary<WF_PrefixMain, Dictionary<WF_PrefixSecondary, DataItem>>
        {
            #region Body
            {
                WF_PrefixMain.Body,
                new Dictionary<WF_PrefixSecondary, DataItem>
                {
                    #region None
                    {
                        WF_PrefixSecondary.None,
                        new DataItem
                        {
                            BaseAddress = 0,
                            Offsets = new int[] { 0 },
                            FullAddress = 0,
                            Name = "Acceleration", 
                            Value = 0f,
                            Unit = 0
                        }
                    },
                    #endregion
                    #region Aero
                    {
                        WF_PrefixSecondary.Aero,
                        new DataItem
                        {
                            BaseAddress = 0,
                            Offsets = new int[] { 0 },
                            FullAddress = 0,
                            Name = "DragX", 
                            Value = 0f,
                            Unit = 0
                        }
                    },
                    #endregion
                }
            },
            #endregion
            #region FL
            {
                WF_PrefixMain.FL, 
                new Dictionary<WF_PrefixSecondary, DataItem> 
                {
                    #region Tires
                    {
                        WF_PrefixSecondary.Tires, 
                        new DataItem 
                        { 
                            BaseAddress = 0, 
                            Offsets = new int[] { 0 },
                            FullAddress = 0,
                            Name = "SpringRate", 
                            Value = 0f, 
                            Unit = 0 
                        } 
                    },
                    #endregion
                    #region Suspension
                    {
                        WF_PrefixSecondary.Suspension,
                        new DataItem
                        {
                            BaseAddress = 0,
                            Offsets = new int[] { 0 },
                            FullAddress = 0,
                            Name = "SpringRate", 
                            Value = 0f,
                            Unit = 0
                        }
                    },
                    #endregion
                }
            },
            #endregion
            #region FR
            {
                WF_PrefixMain.FR,
                new Dictionary<WF_PrefixSecondary, DataItem>
                {
                    #region Tires
                    {
                        WF_PrefixSecondary.Tires,
                        new DataItem
                        {
                            BaseAddress = 0,
                            Offsets = new int[] { 0 },
                            FullAddress = 0,
                            Name = "SpringRate", 
                            Value = 0f,
                            Unit = 0
                        }
                    },
                    #endregion
                    #region Suspension
                    {
                        WF_PrefixSecondary.Suspension,
                        new DataItem
                        {
                            FullAddress = 0,
                            BaseAddress = 0,
                            Offsets = new int[] { 0 },
                            Name = "SpringRate", 
                            Value = 0f,
                            Unit = 0
                        }
                    },
                    #endregion
                }
            },
            #endregion
            #region RL
            {
                WF_PrefixMain.RL,
                new Dictionary<WF_PrefixSecondary, DataItem>
                {
                    #region Tires
                    {
                        WF_PrefixSecondary.Tires,
                        new DataItem
                        {
                            BaseAddress = 0,
                            Offsets = new int[] { 0 },
                            FullAddress = 0,
                            Name = "SpringRate", 
                            Value = 0f,
                            Unit = 0
                        }
                    },
                    #endregion
                    #region Suspension
                    {
                        WF_PrefixSecondary.Suspension,
                        new DataItem
                        {
                            BaseAddress = 0,
                            Offsets = new int[] { 0 },
                            FullAddress = 0,
                            Name = "SpringRate", 
                            Value = 0f,
                            Unit = 0
                        }
                    },
                    #endregion
                }
            },
            #endregion
            #region RR
            {
                WF_PrefixMain.RR,
                new Dictionary<WF_PrefixSecondary, DataItem>
                {
                    #region Tires
                    {
                        WF_PrefixSecondary.Tires,
                        new DataItem
                        {
                            BaseAddress = 0,
                            Offsets = new int[] { 0 },
                            FullAddress = 0,
                            Name = "SpringRate", 
                            Value = 0f,
                            Unit = 0
                        }
                    },
                    #endregion
                    #region Suspension
                    {
                        WF_PrefixSecondary.Suspension,
                        new DataItem
                        {
                            BaseAddress = 0,
                            Offsets = new int[] { 0 },
                            FullAddress = 0,
                            Name = "SpringRate", 
                            Value = 0f,
                            Unit = 0
                        }
                    },
                    #endregion
                }
            },
            #endregion
            #region Powertrain
            {
                WF_PrefixMain.Powertrain,
                new Dictionary<WF_PrefixSecondary, DataItem>
                {
                    #region Engine
                    {
                        WF_PrefixSecondary.Engine,
                        new DataItem
                        {
                            BaseAddress = 0,
                            Offsets = new int[] { 0 },
                            FullAddress = 0,
                            Name = "RPM", 
                            Value = 0f,
                            Unit = 0
                        }
                    },
                    #endregion
                    #region Differential
                    {
                        WF_PrefixSecondary.Differential,
                        new DataItem
                        {
                            BaseAddress = 0,
                            Offsets = new int[] { 0 },
                            FullAddress = 0,
                            Name = "DifferentialVelocity", 
                            Value = 0f,
                            Unit = 0
                        }
                    },
                    #endregion
                    #region Transmission
                    {
                        WF_PrefixSecondary.Transmission,
                        new DataItem
                        {
                            BaseAddress = 0,
                            Offsets = new int[] { 0 },
                            FullAddress = 0,
                            Name = "GearSomething", 
                            Value = 0f,
                            Unit = 0
                        }
                    },
                    #endregion
                }
            },
            #endregion
        };
    }
}
