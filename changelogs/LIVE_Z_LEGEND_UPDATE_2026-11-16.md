# Live Four Wheels — compact Z legend and label precision

> **Historical changelog:** describes an earlier source revision. Some layouts, file names and implementation details have since changed. For current behavior, see the [project README](../README.md) and [current build changes](CURRENT_BUILD_2026-11-24.md).

The live Four Wheels Z gradient legend now defaults to a compact **170 px** panel. The previous `Shown` handler increased the legend width by adding 175 px to the panel minimum, overriding the narrower Designer sizing. That handler has been replaced with a width application based on the user-selected setting.

Open **Form4WheelsSettings → Z / Color Axis** for two new inputs:

- **Legend width (px)**: 115–600, default 170. This changes the space assigned to the Z gradient legend without changing chart data. The splitter remains resizable manually, but applying settings restores the selected width.
- **Legend label decimals**: 0–10, default 2. This uses the Chart Y-axis `LabelStyle.Format` setting (`F0`, `F1`, `F2`, etc.), rather than rounding Z values. Stored samples, thresholds, and color bands retain their original precision.

The new controls are declared in `Form4WheelsSettings.Designer.cs`, have stable control names, and are persisted by the existing `JsonFormSettings` capture/restore code. Old settings files lacking these keys will use the new defaults.

## Suggested Windows checks

1. Open Four Wheels with the Z range set to 0–1. The legend should show short values such as `0.20` rather than raw `0.200000...`.
2. Open Four Wheels Settings, set Legend width to 140 and label decimals to 3, then Apply Chart Settings. Confirm the change is immediate and the recorded points remain.
3. Close and reopen the app; confirm that the settings restore from the same JSON profile.
4. Switch between Separate, Front/Rear, All In One, and single-tire layouts; make sure the legend is still readable.
5. Check the Offline Chart Import, Settings, Remove, and Apply Filters buttons to guard against unrelated Designer event regression.

Static source tests: `python tools/validate_live_legend.py`, plus the regular game-config, lazy-telemetry, and offline-chart-ui validators. A complete .NET Framework WinForms build and runtime test require Visual Studio on Windows.
