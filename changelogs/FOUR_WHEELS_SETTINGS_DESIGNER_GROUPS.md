# Form4WheelsSettings — Designer-editable grouped controls

> **Historical changelog:** describes an earlier source revision. Some layouts, file names and implementation details have since changed. For current behavior, see the [project README](../README.md) and [current build changes](CURRENT_BUILD_2026-11-24.md).

This layout uses normal **WinForms Designer controls**, not a runtime-generated settings screen. The four outer groups remain **25% each** in `settingsSectionsLayout` and retain independent vertical scrolling.

## Open and edit in Visual Studio

1. Open `Form4WheelsSettings.cs` with **View Designer**.
2. Open **View > Other Windows > Document Outline** (`Ctrl+Alt+T` in many Visual Studio keyboard configurations).
3. Expand `settingsSectionsLayout`, then the relevant section:
   `settingsSidebarGroup`, `xAxisSettingsGroup`, `yAxisSettingsGroup`, or `zAxisSettingsGroup`.
4. Expand its scrolling panel, e.g. `xAxisSettingsPanel`. Each horizontal setting group is a named `TableLayoutPanel`, e.g. `xAxisLimitsRow` or `xAxisFontFaceRow`.
5. Inside each group, each setting (caption + editor) is a **single Panel**, e.g. `X1MinMaskedTextBoxRow`. Move the whole setting panel in Document Outline, not the ComboBox/TextBox alone. The field name and event handlers are preserved.

## Add, reorder, or move settings

- To swap two settings in one horizontal group, change the `Column` cell assignment in the TableLayoutPanel's visual designer, or drag the setting panels between cells in Document Outline.
- To move a setting between groups, move its complete `...Row` panel to the target TableLayoutPanel cell (cut/paste or drag in Document Outline). When a target cell is occupied, move that existing setting first.
- For an additional setting in a group, add a `Panel` inside its TableLayoutPanel; put a `Label` at **Dock=Top** and an input at **Dock=Bottom**; set the cell Panel to **Dock=Fill**, and use left/right Padding 4, top/bottom Padding 0. Set the TableLayoutPanel's `ColumnCount` and `ColumnStyles` in its Properties / Edit Rows and Columns dialog.
- To create an additional horizontal row, copy the layout of an existing named `...Row` TableLayoutPanel and place it within the relevant scrolling Panel. Set the new group to **Dock=Top**, **Height=76**, and **Padding=0**. (Visual Studio's Document Outline helps with Dock.Top stacking order.)
- Use two settings per row unless the form is wide enough for more; the UI preserves 25% outer columns, so too many narrow cells will truncate long labels.
- To show a setting on its own full-width row, its `...Row` Panel may be placed directly into its section's scrolling Panel with **Dock=Top** and **Height=76**. This remains editable through the Designer.

## Layout constraints

- The original 65 setting panels remain present and maintain their names; bindings, event handlers and values are unchanged.
- There are 26 two-column named layout groups; all others remain full-width rows.
- Vertical padding remains 0 on setting panels; labels are docked top and editors bottom, avoiding vertical collisions.
- Editors adapt to their containing cell width; the configured `Size` on a docked editor is a design-time size and its on-screen width is determined by the row/table layout.
- The legend width editor has a **minimum and default of 120 px**, with Designer `Size` set to `279 x 31` (runtime width follows its docked cell). The application-wide default legend width is also 120 px.
- `Form4Wheels`: `axisFiltersGroup` and `extraFiltersGroup` have **Padding (8, 8, 8, 15)**.

Run `python tools/validate_grouped_four_wheels_settings.py` to verify source-level row ownership and sizing. The final designer interaction and DPI layout must be checked in Windows/Visual Studio.
