# Memory reader / static-state refactor (2026-11-12)

> **Historical changelog:** describes an earlier source revision. Some layouts, file names and implementation details have since changed. For current behavior, see the [project README](../README.md) and [current build changes](CURRENT_BUILD_2026-11-24.md).

## Structure

- `MemoryReader.cs` replaces `MemoryHelper.cs` in the project. `Physics_Data_Debug.MemoryReader` is an **instance** attached to one Wreckfest process; it owns the process connection and its cached handle and module base.
- Configured pointer traversal, contiguous chunk reads, timing span calculation, wheel-block reading, and x64 process discovery are now here rather than in `LiveData.cs` or the Live Data form.
- `TelemetryMemorySnapshot` and `WheelMemoryBlock` are internal data containers carrying the raw byte chunks of one sample. Their fields contain no eager tire calculations.
- `LiveData.GetData` now obtains a snapshot and exposes the established `List<byte[]>` properties for existing charts/logs. The existing `DataItem` on-demand calculation behavior remains unchanged.
- `LegacyMemoryUtilities.cs` retains the older 32-bit reader, pointer-calculator overloads, and `ObjectType` helpers for inspection/compatibility; they are not on the live x64 sampling path.
- `DataLogger` is now an instance held by `FormLiveData`. Its output-path cache is no longer a static global dictionary.
- `TireGripMath.cs` now holds the three stateless shift-factor, cosine-grip and load-sensitivity formulas formerly declared in `FormLiveData`. Existing call sites were updated to use it.
- `FormLiveData` delegates process attachment/detachment to `LiveData` / `MemoryReader` and centralizes capture cleanup. It stops polling and warns on a native memory-read failure.

## Memory semantics and performance

- One process reader is constructed on **Get Process**, instead of every telemetry refresh.
- `Process.MainModule.BaseAddress` and the process handle are read once per attachment.
- The fast configured pointer-chain path avoids allocating an offsets array for each raw chunk.
- `ReadProcessMemory` checks returned byte counts, preventing failed/partial reads being silently interpreted as zero telemetry.
- We preserve the original pointer-chain *order*, the original unsigned 32-bit offset arithmetic, chunk layout, version shifts, wheel side offsets, and the JSON-configured field names.
- A reader owns the `Process` object. Closing it disposes that object rather than directly calling `CloseHandle(process.Handle)` on a handle owned by `System.Diagnostics.Process`.
- Configured offsets are resolved for each sample so selecting another game-version configuration does not leave an out-of-date offset cache.

## Static design decisions

The code intentionally retains static **pure** helpers (e.g. palette and formulas) and static **application-wide** interfaces (`GameMemoryConfig`, existing `LiveData` field access) because many existing forms and the lazy calculation registry consume them. Converting every global field to per-form state without a staged migration would be a breaking behavior change. The process reader, log output-path cache, and their resource lifetimes have been moved to instances in this pass. Three cross-form mathematical functions moved out of the Form into a dedicated stateless utility. Other unused functions were left in place, per request.

## Testing on Windows

1. Build in Visual Studio (.NET Framework 4.7.2, x64).
2. Run Wreckfest and click Get Process, verify all four wheel readouts, RaceTime and live charts update.
3. Click Refresh Process repeatedly and switch game versions with capture stopped; verify pointer reads and values still work.
4. Stop/exit Wreckfest while polling; verify capture stops without a recurring exception.
5. Start/stop logging, change selected columns, and check file headers and all four wheel logs.
6. Open Four Wheels, GForce, suspension geometry/static values, and the offline CSV plot to check unchanged references.
7. Compare a few known numeric telemetry fields (including integer RaceTime) with the previous build.

**Validation limitation:** Container checks cover reference searches, project XML, JSON offsets and source consistency only. A native WinForms build and live ReadProcessMemory execution cannot be performed in this Linux workspace.
