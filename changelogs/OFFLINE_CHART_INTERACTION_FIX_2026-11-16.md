# Offline Chart interaction fix — 2026-11-16

> **Historical changelog:** describes an earlier source revision. Some layouts, file names and implementation details have since changed. For current behavior, see the [project README](../README.md) and [current build changes](CURRENT_BUILD_2026-11-24.md).

This patch was made from the user-supplied `PhysicsDataDebug(2).zip`.

## Root cause confirmed in source

`FormOfflineChart.cs` already contained `ImportFilesButton_Click`,
`RemoveFilesButton_Click`, `SettingsButton_Click`, and
`ApplyFiltersButton_Click`, but `FormOfflineChart.Designer.cs` did not
subscribe **any** of the four toolbar buttons to those methods.
Clicking them therefore did nothing. This is independent of any
saved JSON profiles and survives restarting the program.

## Changes

- Reconnected all four Click handlers in the Designer, so they are also
  inspectable under the Events (lightning bolt) tab in Visual Studio.
- Restored dark, high-contrast button styling using `UseVisualStyleBackColor = false`.
- Corrected the imported-files panel's initial Designer width from 2248 px
  to 1128 px (matching the 1148 px toolbar width and 10 px left/right space).
- Enabled the existing toolbar resizing and chart/legend resizing handlers.
- Added `tools/validate_offline_chart_ui.py` to catch accidental removal
  of toolbar event subscriptions in future Designer refactors.

The live Four Wheels and Live Data layout settings were not changed.
No AppData settings reset is required for these fixes.

## Runtime verification on Windows

1. Open Offline CSV Chart before opening any other chart.
2. Check **Load CSV / TXT...** opens the file picker, select a log file.
3. Check **Chart settings** opens the settings form and Apply works.
4. Check **Apply filters** redraws, and **Remove selected** removes a file.
5. Open and close Four Wheels, then repeat steps 2–4 in Offline Chart.
6. Close/restart the app and repeat the test with previously saved profiles.

C# project structure and source checks passed; a full WinForms runtime
build/test could not be performed in this environment.
