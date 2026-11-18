# Live chart-area headers

The fixed pixel-positioned wheel labels above `Form4Wheels.chart1` have been removed.
`Form4Wheels.SetChartsForForm()` now attaches a `Title` to each created `ChartArea`
using `DockedToChartArea` and `IsDockedInsideChartArea = false`. Titles
therefore track their plot when the window is resized or when wheel layouts
change.

- Separate: Front Left, Rear Left, Front Right, Rear Right (one per area)
- Front/Rear: Front Tires, Rear Tires
- All In One: All Wheels
- Single wheel: the selected wheel name

The Z-column name now appears as the `GradientChart` title, not in the
main chart heading strip. The existing series and data histories are untouched.

When changing the title style, edit `AddChartAreaHeading()` in `Form4Wheels.cs`.

This revision has not been run in Visual Studio; please verify Title docking
for all layouts and when resizing the window.
