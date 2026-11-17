using System;
using System.Drawing;
using System.Windows.Forms;

namespace Physics_Data_Debug
{
    /// <summary>
    /// Keep ordinary WinForms Panels in a parent form's .Designer.cs file.
    /// ChartLimiterRow controls are mounted only when that form actually runs,
    /// avoiding a build-order dependency when opening the parent form designer.
    /// The filter's internal layout remains editable in ChartLimiterRow [Design].
    /// </summary>
    internal static class ChartLimiterRowHost
    {
        internal static ChartLimiterRow Mount(Panel host)
        {
            if (host == null) throw new ArgumentNullException(nameof(host));

            var row = new ChartLimiterRow
            {
                Name = host.Name.Replace("Host", "Row"),
                Dock = DockStyle.Fill,
                Margin = Padding.Empty
            };
            host.Controls.Clear();
            host.Controls.Add(row);
            return row;
        }
    }
}
