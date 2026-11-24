# WinForms Chart zero-width initialization fix

> **Historical changelog:** describes an earlier source revision. Some layouts, file names and implementation details have since changed. For current behavior, see the [project README](../README.md) and [current build changes](CURRENT_BUILD_2026-11-24.md).

## Symptom
`System.ArgumentException: Width must be greater than 0px.` from
`System.Windows.Forms.DataVisualization.Charting.ChartPicture.InspectChartDimensions`,
occurring while `chartAndLegend.EndInit()` executes in `Form4Wheels.Designer.cs`.

## Cause
The two WinForms Chart controls are docked to the SplitContainer panels.
During initial SplitContainer layout (and sometimes resize/minimization), a panel
can temporarily report zero width before its final size is established. The
WinForms Chart control raises an exception when asked to resize to zero pixels.
Delaying `SetChartsForForm()` until `Shown` does not protect the control itself
against this earlier size change.

## Fix
Both `Form4Wheels.Designer.cs` and `FormOfflineChart.Designer.cs` assign
`MinimumSize = new Size(10, 10)` to `chart1` and `GradientChart` **before**
applying `DockStyle.Fill`. They remain docked and Designer-editable, and the
minimum prevents transient zero-pixel sizes. Legend width settings are unchanged.

## Verification
`python tools/validate_chart_minimum_size.py` verifies both form Designers.
Source validators do not replace a Windows build/Designer and runtime test.

## Runtime tests
1. Open Form4Wheels from Live Data and check no exception at `EndInit()`.
2. Open FormOfflineChart and check loading/rendering still works.
3. Resize and minimize/restore both forms; check legend width and charts.
4. Open both Designers in Visual Studio.
