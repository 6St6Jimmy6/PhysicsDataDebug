# Current source build — 2026-11-24

Documentation baseline: `PhysicsDataDebug_SuspensionLegend_Full.zip`. This is a source revision, not a claim that the Windows executable was rebuilt or tested.

## Current implementation

- **Four Wheels / Offline Chart:** each Settings Designer directly owns 13 `ChartLimiterRow` controls; the live Settings form also owns the No tire contact limiter. The original filter keys remain compatible with chart snapshots. No hidden parking panels or `ChartLimiterRowHost.cs` remain.
- **Chart appearance:** live and offline Cartesian axes inherit the parallel major grid line style (including alpha, width and dash), with exterior tick marks disabled. This change is not a claim that the polar G-Force axes use the same logic.
- **Telemetry:** calculated fields have no raw memory index; raw decoding plans and timing spans are cached by configuration revision. Calculations remain lazy, and logger buffers are reused. See [refactoring notes](../REFACTOR_NOTES.md) and [lazy telemetry](../LAZY_TELEMETRY_GUIDE.md).
- **Live Time Chart:** `FormLiveTimeChart` and `FormLiveTimeChartSettings` are the current source names. Five selectable lanes share `TIME_RaceTime` (milliseconds from the game, seconds internally).
- **Suspension Geometry:** two live 3D wireframes replace the previous 2D chart. The toolbar provides camera angles, zoom, refresh interval, view presets, perspective, grid, point names, spindle rotation and a Legend checkbox. Point hovering shows XYZ; the instant and roll centers remain XY projections. Legend entries can be omitted in short viewports. See [3D geometry guide](../SUSPENSION_3D_GUIDE.md).
- **Configuration:** the bundled schema 2 JSON contains 11 categories, 271 raw fields and 56 calculated fields (55 expressions and one built-in); versions `V1_285308` and `V1_308438` remain supplied.

## Documentation update

Current guides and README were compared with the packaged C# source, Designer declarations, project configuration and bundled JSON. Older changelogs are labeled historical rather than rewritten as present-day instructions. The documentation-only patch changes no C#, JSON, resource, project or solution files. No settings reset is required.

## Verification limits

This is a source/documentation review. Windows .NET Framework 4.7.2 compilation, Visual Studio Designer rendering, live telemetry, and measured performance remain unverified here. See the smoke tests in the individual guides.
