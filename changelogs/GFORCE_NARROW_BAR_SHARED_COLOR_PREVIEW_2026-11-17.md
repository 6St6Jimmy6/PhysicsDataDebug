# FormGForce right chart + shared color dropdown update

> **Historical changelog:** describes an earlier source revision. Some layouts, file names and implementation details have since changed. For current behavior, see the [project README](../README.md) and [current build changes](CURRENT_BUILD_2026-11-24.md).

## G-Force chart sizing

`FormGForce.Designer.cs` now owns a `TableLayoutPanel` named `chartAndBar`, with
one flexible left chart column and one **absolute-width 72-pixel right column**.
The old `SplitContainer` and `SplitterDistance` are removed. The fixed width is
independent of the window aspect ratio and is editable in the Visual Studio
Designer (Document Outline > `chartAndBar` > ColumnStyles).

`FormGForce.cs` also explicitly sizes the inner chart area to make room for
vertical-axis tick labels at the narrow width.

## Shared color dropdown drawing

`ChartSettingsUi.cs` contains the shared drawing and automatic contrast logic.
Every option is drawn with its own background color; labels use the higher
contrast of black or white, selected entries have a contrasting outline rather
than blue paint, and Transparent has a light checkerboard sample.

- `Form4WheelsSettings`: background, marker, X/Y font and grid colors.
- `FormGForceSettings`: background, marker, X/Y font and grid colors.
- `FormOfflineChartSettings`: background, X/Y font and grid, cursor colors.
- `Form4WheelsSettings.Appearance`: live cursor color.

`Color` and named string items are both supported; no JSON profile setting
names, item values, or existing chart colors are changed.

`ComboBoxBehaviors` still permits typing/search; unlike a DropDownList, an
editable ComboBox's closed text field is rendered by Windows. Its selected
background is set to the preview color and its text to a contrasting color.
The opened list uses the per-item drawing logic.

## Validation

Run `python tools/validate_shared_color_dropdowns.py` and the other
`tools/validate_*.py` checks. WinForms rendering and Visual Studio Designer
behavior must additionally be tested on Windows, especially under high DPI.
