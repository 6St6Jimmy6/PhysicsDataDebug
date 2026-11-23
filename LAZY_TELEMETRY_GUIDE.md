# On-demand calculated telemetry

Calculated telemetry is shared by the live memory reader, synchronized logger,
chart filters, Live Data monitor, Live Time Chart, and Offline Chart. Calculated
fields have **no physical memory offset**.

## Current implementation

- `WreckfestGameMemoryConfig.json` schema 2 holds raw fields under
  `categories.<category>.fields` and derived fields under
  `categories.<category>.calculated`.
- A derived field normally has an `expression`. During configuration loading,
  `GameMemoryConfig.cs` parses the entries, `TelemetryExpression.cs` compiles the
  expressions, and `TelemetryFormulas.cs` validates their dependencies.
- `CalculatedTelemetry.cs` maintains compatibility with older calculated-field
  indexes and names. It is **not** the place where a new schema 2 arithmetic
  formula must be registered.
- The supplied configuration contains **56** calculated fields: **55 JSON
  expressions**, and the specialized `Log10aT` WLF calculation marked
  `"builtin": true`. Named C# physics functions are available to JSON formulas
  for matrix, angle, local-acceleration, and grip calculations.
- Calculated values are resolved on demand, and repeated requests for the same
  sample reuse cached results. A new live sample invalidates the cache.

## Live telemetry and memory reads

The schema 2 memory reader plans small process-memory read ranges from the raw
offsets in each category. The `readOptimization.maxGapBytes` and
`readOptimization.maxReadBytes` options control how close fields are grouped.
A virtual four-byte indexed layout is retained for older `LiveData` consumers;
this does **not** mean the reader still fetches one fixed chunk for every
category. Calculations are evaluated when a chart, log column, filter, or
monitor requests them, rather than eagerly materializing all calculated fields.

Adding a new field to an existing configured category generally requires only
an aligned offset in JSON. Only currently supported raw value types and memory
structures can be used without changing C#.

## Offline CSV/TSV/TXT/LOG

- The importer keeps physical file columns. Older unprefixed per-wheel headers
  are normalized in memory without editing the source file.
- A **recorded column takes precedence** over a virtual calculated column with
  the same canonical identity. There is no duplicate selector entry.
- Derived columns are offered when their dependency fields can be resolved.
  For example, a file containing `FL_LateralLoad` and `FL_VerticalLoad` can
  supply `FL_LateralFriction` if it was not recorded.
- Derived formulas can depend on other calculated values: a file containing
  lateral and longitudinal friction can supply a combined-friction value.
- Expressions are evaluated only when a selected X/Y/Z field or active filter
  requests the result. Invalid or absent inputs are not silently replaced by
  ordinary zero readings. The `div0(a,b)` function is an intentional exception:
  it returns zero for a zero denominator.
- The selector shows wheel-relative names such as `LateralFriction`; the dataset
  layout routes matching `FL_`, `FR_`, `RL_`, and `RR_` columns to the proper
  chart area. Shared names retain their category prefixes.

## Add a calculated value

In an existing schema 2 category, add an entry to `calculated`:

```json
"MyCombinedGrip": {
  "expression": "hypot(LateralFriction, LongitudinalFriction)",
  "displayName": "My Combined Grip",
  "axisDefaults": {
    "min": 0, "max": 2, "majorInterval": 0.5, "decimals": 3
  }
}
```

For a wheel category, this automatically creates `FL_MyCombinedGrip`,
`FR_MyCombinedGrip`, `RL_MyCombinedGrip`, and `RR_MyCombinedGrip` as public
channels. You do **not** need to edit `CalculatedTelemetry.cs`, manually
register a formula in `TelemetryFormulas.cs`, or add `telemetrySelections`.

A same-category identifier resolves within that category. To reference other
categories, use full public names, for example `ENG_RPM`. The configuration
loader rejects malformed expressions, unknown dependencies, and circular
references. Built-in C# functions are needed only for operations not available
in the expression language; adding a *new* built-in function still requires
source changes.

See [GAME_CONFIG_GUIDE.md](GAME_CONFIG_GUIDE.md) for expression operators,
functions, field metadata, versioning and memory-read optimization.

## Verification on Windows

1. Add a simple expression to a **copy** of the schema 2 configuration and
   reload it while sampling/logging is stopped.
2. Verify that the field appears in the logging hierarchy and the appropriate
   live chart choices without changing C#.
3. Test a combined file with all required source columns but no recorded result;
   select the derived measurement in Offline Chart.
4. Test a file that already records the result to confirm physical-column
   priority; test missing inputs and a zero denominator separately.
5. Compare a few derived values with hand calculations or known game samples.

Source structure and JSON checks are not substitutes for running and validating
the application on Windows with real game data.
