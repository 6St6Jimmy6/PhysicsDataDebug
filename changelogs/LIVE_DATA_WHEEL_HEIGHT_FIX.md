# Live Data wheel cards and Game Version buttons

> **Historical changelog:** describes an earlier source revision. Some layouts, file names and implementation details have since changed. For current behavior, see the [project README](../README.md) and [current build changes](CURRENT_BUILD_2026-11-24.md).

- In **FormLiveData.Designer.cs**, the two rows of `fourWheelGrid` use **448 px** rather than 858 px. The Designer preview and runtime use the same row height.
- In **FormLiveData.Layout.cs**, `InitializeDesignerLayoutBehavior()` reads the first row height from `fourWheelGrid.RowStyles[0]` and preserves it when switching between two and one wheel-card columns. To change the height visually, open **FormLiveData** in the WinForms Designer, select `fourWheelGrid` in **Document Outline**, choose **Edit Rows and Columns**, and adjust the first row height. Keep both initial row heights consistent.
- `GameConfigurationProfilesButton` (Config) and the runtime Profiles button are styled dark gray with white text to match the Live Data sidebar.
- No telemetry labels, wheel rows, UI text, chart functions, or saved settings were changed.

A Windows/Visual Studio build and runtime resizing test are still required.
