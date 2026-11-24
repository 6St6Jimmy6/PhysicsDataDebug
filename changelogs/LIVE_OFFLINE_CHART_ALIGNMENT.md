# Four Wheels / Offline Chart alignment (2026-11-14)

> **Historical changelog:** describes an earlier source revision. Some layouts, file names and implementation details have since changed. For current behavior, see the [project README](../README.md) and [current build changes](CURRENT_BUILD_2026-11-24.md).

## Version selection
`FormLiveData` starts with the **Automatic (Wreckfest_x64.exe)** entry selected. A manual version explicitly saved in a user profile remains loadable and is restored on startup; the existing JSON-based manual version path is unchanged. Bundled versions include `V1_285308` and the corrected `V1_308438`.

## Live Four Wheels layout
`Form4Wheels.Designer.cs` now owns a `mainLayout` and `chartAndLegend` split area, arranged as:

1. Settings / Clear / Pause / Filter buttons (and Profiles)
2. Three current X/Y/Z filter rows
3. Ten extra filter rows
4. Chart + color-band legend, with an adjustable splitter
5. Bottom status caption

All thirteen existing `ChartLimiterRow` instances remain the same controls with their original names; saved filter profiles still bind to them. Single-tire modes and multi-tire modes are unchanged.

## Live settings layout
`Form4WheelsSettings` retains the four Designer-owned GroupBoxes (`settingsSidebarGroup`, `xAxisSettingsGroup`, `yAxisSettingsGroup`, `zAxisSettingsGroup`), now formatted in the same dark, compact row style as the offline form. Its original controls retain names for JSON compatibility. `Form4WheelsSettings.Appearance.cs` defines the new controls and the **explicit row ordering**, which is the single place to adjust where each item appears.

### Live-only controls retained
- Per-band history point count, marker color and type
- Clear/Apply and Apply-only actions
- Four-wheel arrangement: Separate, Front/Rear, All In One, and each wheel alone
- Tire contact filtering, pause/resume and per-axis and ten additional filters in the chart form

### Shared behavior and new live settings
- All palette schemes and configurable gradient bands (now under Z / Color)
- History series chart type (unsupported multi-Y / single-series-only types are rejected before rebuilding)
- History marker style and size, palette alpha and divider
- Cursor enable, X/Y zoom, color, alpha, quarter-step width and dash
- Major and minor grid dash/alpha, linked grid/tick-mark styling, quarter-step line width
- Responsive chart/legend splitter, similar to Offline Chart

`ChartAppearance.cs` is used by both chart forms to apply cursor and grid/tick colors, dash and widths. `ChartZoomBehavior.cs` is used by both chart forms to select X or Y zoom based on drag direction. The existing shared `GradientPalette` and `ChartLimiterRow` controls are retained.

## Configuration persistence
The live and offline settings remain independent JSON profiles. Existing live controls retain their names; new controls add new serialized entries with safe defaults. A new automatic version is the first-run default but manual version profiles remain supported. The `FormOfflineChartSettings` JSON files are not shared with the live form.

## Windows runtime testing checklist
- Startup with a new settings folder defaults to Automatic. A saved manual version can still be chosen.
- Press Get Process for 1.28/1.30 and verify the detected base shift.
- Open Four Wheels in all seven layout modes; check the chart and Z legend both resize.
- Run a live sample, pause, Apply without clearing, verify history is retained/recolored.
- Apply and Clear still clears only the chart history.
- Enable independent axis and extra filters; check selections persist after restarting.
- Resize settings and chart at 100%/150% Windows display scaling and adjust splitter.
- Try X and Y drag zoom and the full palette list.
- Verify Offline Chart imports and zoom still work unchanged.

The Linux workspace has no WinForms /.NET Framework 4.7.2 build toolchain, so these checks are not a substitute for a Windows Visual Studio build.
