# Optimization pass (2026-11-11)

> **Historical changelog:** describes an earlier source revision. Some layouts, file names and implementation details have since changed. For current behavior, see the [project README](../README.md) and [current build changes](CURRENT_BUILD_2026-11-24.md).

This pass focuses on work repeated by the telemetry timer and preserves
existing game-memory field names, chart series, log columns, JSON profile
formats, and public methods. It intentionally **does not remove unused
methods**, so they can be reviewed separately.

## Implemented

- **MemoryReader.cs (formerly MemoryHelper.cs):** Four-byte values are copied directly from the memory
  buffer rather than converted to floats and serialized back to bytes.
  This preserves integer timings and special float bit patterns, avoids a
  temporary float array, and preallocates the result list. The existing
  array-reader signature remains available. Removed catch-and-rethrow blocks
  that discarded the original stack trace, and removed per-write console
  logging of generic type names.
- **LiveData.cs:** Calculated telemetry uses a private, typed float reader,
  avoiding dynamic dispatch for each primitive memory value. Tire angles
  are calculated once instead of three times per wheel; raw tire chunk
  start, tire slip speeds and lateral load are reused. The two identical
  load-sensitivity calculations are evaluated once and reused for the
  longitudinal result. Engine, acceleration and aero calculations reuse
  their chunk starts. The four wheel update calls also share configured
  chunk starts per tick.
- **LiveData.cs:** Updating a label or text box with an unchanged formatted
  value is skipped, reducing redundant WinForms notifications and repaints.
  The number-formatting culture is reused.
- **GameMemoryConfig.cs:** Missing field/member groups reuse the empty
  string array rather than allocating a new one.
- **WheelPlotHistory.cs:** Clearing histories uses a direct indexed loop.
- **FormTireTemperatures.cs:** The WinForms timer is now the sole running
  state, rather than mirroring it in a second boolean. Removed unnecessary
  conversions and imports.

## Worth considering next (not changed)

1. **Memory representation:** Each tick still builds many four-byte arrays.
   A contiguous byte buffer with typed read-at-offset access would avoid
   most of these allocations, but would require changing every calculated
   telemetry consumer and carefully preserving int-versus-float semantics.
2. **Configured offset lookups:** Raw and derived value indexes are
   resolved repeatedly during sampling. Per-configuration/per-version
   compiled field indexes could help, provided switching JSON configurations
   fully invalidates them.
3. **Chart and suspension-geometry setup:** Several sections repeat chart
   and series property assignment. Reusable setup helpers could shorten the
   code, but would need side-by-side visual tests to avoid changing display
   choices.
4. **Logging:** Selected columns and headers are prepared for each logging
   tick. Caching a schema until selection/delimiter changes could reduce
   allocations, provided file rotation still works for changed columns.

## Verification

The game-memory configuration validator and project-file checks can run in
this workspace. No Windows/.NET Framework build tools are installed here;
compile the solution in Visual Studio and compare a brief telemetry capture,
  including integer RaceTime, chart history and CSV logs, against your
previous build.
