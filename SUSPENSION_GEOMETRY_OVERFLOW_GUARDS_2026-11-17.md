# Suspension Geometry - Overflow guards (2026-11-17)

## Symptom

After opening Suspension Geometry and selecting **Get Process** on Live Data, an unhandled `System.OverflowException` appeared at `Application.Run(main)`. That is the top-level WinForms message loop, not the definitive throw site. Without the VS exception call stack, the exact failing method cannot be proven.

## Changes

- The `XYLineIntersectionVector()` method now uses a double-precision determinant, not a pair of slopes. A vertical arm no longer causes `dy/dx` to become infinite; parallel, coincident, degenerate, nonfinite, or extremely remote intersections are flagged as unavailable.
- Every suspension-geometry chart X/Y value is updated through `SetGeometryPoint()`, which marks invalid points as empty rather than writing infinities to the chart or fabricating a (0,0) location.
- Adaptive major tick intervals avoid very large numbers of axis labels/gridlines if the user configures a wide X/Y range.
- If a numeric overflow still happens inside the suspension-geometry update timer, the timer is stopped and a dialog provides the full exception string and stack trace.
- If an overflow occurs during `LiveData.RefreshTelemetry()`, memory capture is stopped and the full exception is shown, with a reminder to check the game-version configuration.

## Validation

The Python source regression scripts pass. A Windows/.NET Framework build and in-game test are still required. If the exception recurs, please copy the new error dialog's stack trace; it will identify the actual throw site.
