# Settings designer layout update — 2026-11-17

> **Historical changelog:** describes an earlier source revision. Some layouts, file names and implementation details have since changed. For current behavior, see the [project README](../README.md) and [current build changes](CURRENT_BUILD_2026-11-24.md).

## Forms changed

- `FormOfflineChartSettings.Designer.cs`: 4 equally sized chart/data, X, Y and Z/color columns; 37 rows, including 28 named horizontal 2-setting groups. Original 65 setting panel wrappers have been kept and moved into designer-owned TableLayoutPanels. The old one-setting-per-row FlowLayoutPanels were replaced by designer-owned, scrollable TableLayoutPanels.
- `FormGForceSettings.Designer.cs`: three equal-width chart/data, X and Y sections; 22 rows, including 14 named 2-setting groups. Its original input fields and event handlers were retained, with each visible field now wrapped in a new designer-owned `...Row` Panel. Apply / Reload / Profiles are in a separate top action bar.
- `JsonFormSettings.cs`: the dynamically inserted GForce Profiles button matches the dark theme and docks to its designer-owned host (as on the other settings forms).
- `FormOfflineChartSettings.cs`: removed obsolete fixed-row resize logic. TableLayoutPanel columns now size their own children.

## Editing in Visual Studio

1. Right-click `FormOfflineChartSettings.cs` or `FormGForceSettings.cs` → **View Designer**.
2. Open **View → Other Windows → Document Outline**.
3. Expand `settingsSectionsLayout`, then the relevant GroupBox and its content panel (`styleFields`, `xFields`, `yFields`, `zFields`, or GForce's `settingsSidebarPanel`, `xAxisSettingsPanel`, `yAxisSettingsPanel`).
4. Expand a named `...Row` TableLayoutPanel. Move a `...Row` **Panel** (not just the ComboBox/TextBox) between group cells to keep its label and input together.
5. Use the TableLayoutPanel's smart-tag **Edit Rows and Columns** to add/remove cells. For a new horizontal pair, add a TableLayoutPanel and set its `ColumnCount` to 2 and each ColumnStyle to 50%. Adjust the parent table's `RowCount` and its corresponding absolute RowStyle as well.
6. Existing axes, chart settings, JSON keys and control names are unchanged. Do not rename the input fields unless you intentionally want a new JSON settings key.

## Colors

The background RGB is `(24,24,24)`, the top actions bar `(35,35,35)`, input fields `(43,43,43)` with white text, and buttons `(60,60,60)` with white text. These values are set on the controls in `.Designer.cs`, not by a runtime-only recursive recoloring pass, so they appear in the Designer as well.

## Limits of validation

Source checks verify all prior input fields remain declared, attached or intentionally hidden, and that the group definitions exist in Designer code. This Linux environment does not provide Visual Studio or a Windows Forms build/runtime; please open both forms in Visual Studio Designer and run on Windows to verify display/DPI scaling.
