# On-demand calculated telemetry

`TelemetryFormulas.cs` is the common source of derived-field calculations for
both the live Wreckfest memory reader and the offline CSV plotter.

## Live telemetry

- LiveData reads the configured raw chunks exactly as before.
- It no longer eagerly appends the 56 calculated values to each tire, engine,
  acceleration, rotation, and drag memory buffer.
- Each calculated `DataItem` has a lazy getter. Its formula is evaluated only
  when a label, log column, filter, or plot asks for that value. Dependencies are
  resolved recursively and each calculated result is cached for the current
  memory sample.
- A new sample invalidates cached results. Names, telemetry list ordering, and
  normal callers such as `GetFullListDataValue` stay compatible.

## Offline CSV/TSV/TXT/LOG

- The importer preserves all original numbers and columns. It offers additional
  **virtual** column names only when all of a formula's prerequisites exist.
- If a CSV already has a `LateralFriction` column, **that physical column wins**.
  There is never a second `LateralFriction` option or a hidden recalculation.
- For a file with `LateralLoad` and `VerticalLoad`, but no `LateralFriction`, the
  importer offers `LateralFriction`, calculated as `LateralLoad / VerticalLoad`.
  As in the old debugger, zero vertical load produces zero friction.
- Additional formulas, including `TotalFriction`, work transitively. A file with
  `LateralFriction` and `LongitudinalFriction` can offer `TotalFriction` even if
  the loads are not present.
- A virtual column is calculated **only when a row's X, Y, Z, or active filter
  actually needs it**. Results are cached within that row to avoid duplicate
  evaluations for multiple selections. Changing plot options filters the view
  but never removes the raw data.
- Matrix-based camber, steer, caster, body rotation/acceleration/drag formulas
  need all the requisite raw matrix fields; they're not offered for partial logs.
- Formula names have the same spelling as their live telemetry equivalents.
  CSV names are case-insensitive.
- An absent or nonnumeric input produces an unavailable sample, which is
  skipped by the chart. Missing physical columns must **not** silently be
  replaced by zeros.

## Add a calculated value

1. Add its name to the appropriate group in `CalculatedTelemetry.cs` (live
   list ordering, not a physical memory offset).
2. Register the dependency names and calculation in `TelemetryFormulas.cs`.
3. Do *not* put a fake memory offset for it in WreckfestGameMemoryConfig.json.

The shared registry currently covers the original 56 calculated fields in the
five existing calculated telemetry groups, including the original Wreckfest
friction, shift-factor, grip and angle routines. There are no per-CSV formulas.

## Verification still required

The archive has been statically checked, but the Windows Forms/.NET Framework
4.7.2 project could not be built or executed in this environment. Test Get
Process and live logging, then load a CSV containing `LateralLoad` and
`VerticalLoad` (without `LateralFriction`) and select `LateralFriction` as Y.
Also test a CSV that includes `LateralFriction` directly to verify raw-column
priority.
