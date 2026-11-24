# PhysicsDataDebug — source refactoring

Baseline: `PhysicsDataDebug(5).zip`. Target framework and language remain .NET Framework 4.7.2 / C# 8. No new package dependencies.

## Changes

- The live and offline chart settings designers now each own their complete filter layout: three axis filters and ten extra filters. The live no-contact checkbox is also owned by its settings form. The shared `ChartLimiterRow` user control retains its own Designer-editable child layout. Edit a row instance's placement in the relevant settings designer; edit the common row layout in `ChartLimiterRow.Designer.cs`.
- Removed the chart forms' hidden parking panels and filter reparenting helper. Settings instances live for the lifetime of the chart and retain filter state between openings. The search overlay is cleaned up when a form is hidden/disposed, including repeated openings.
- Retained the existing filter control-name keys and chart-profile persistence. The settings form's filter subtree can be captured by the chart's profile without physically moving controls. Existing chart settings and telemetry naming are retained.
- Consolidated filter bound parsing and validation; removed unused live limiter state and methods. Live chart sampling applies active filters before reading plotting axes, and avoids temporary per-wheel axis collections.
- Removed obsolete calculated-telemetry memory-index machinery. Calculated names remain ordered and lazy calculation caching remains per sample. Configuration rollback restores the calculated-name snapshot.
- Consolidated live chart field lookup caches with the existing telemetry lookup infrastructure. Retained group-qualified names and canonical wheel aliases. Cached raw-memory offset/type read plans and the timing span, invalidated when the active memory configuration/version changes. Preserved integer versus float decoding and unavailable-value handling.
- Reused fixed wheel-selection lists and logging buffers; removed unused data-item metadata and a redundant log formatting method; reduced live time-chart sample allocations by storing four values in a value type.
- Removed the unused G-force `SetArrays` compatibility stub. Disposed the offline settings font collection. Delayed the live scatter chart's timer until its first chart layout is ready.

## Applying the changed-files archive

Extract over the original source directory, replacing existing files. Delete `ChartLimiterRowHost.cs` manually; its Compile entry is already removed from the updated project. The full-source archive already omits it. Back up the original source before applying. The full-source archive excludes `.git`, `.vs`, `bin`, and `obj`; it is not a compiled binary release.

## Validation and limitations

Source-level checks: every project Compile/EmbeddedResource/None/Content entry exists; every C# source file is included in the project; all changed C# files passed a lexical delimiter-balance check; each settings designer owns exactly 13 filter rows and neither main chart designer owns any; the only removed source file is `ChartLimiterRowHost.cs`. No Windows compiler, .NET Framework 4.7.2 reference assemblies, or Visual Studio WinForms designer are available in the execution environment. A successful build, runtime behavior, designer rendering and measured performance have therefore not been verified.

On Windows, use a Visual Studio Developer Command Prompt with the .NET Framework 4.7.2 targeting pack:

```cmd
msbuild "Wreckfest Physics Debugger.sln" /t:Rebuild /p:Configuration=Debug /p:Platform="Any CPU"
```

Recommended smoke tests: open both Settings designers; open and close each settings window repeatedly; apply/reset all 13 filters; save/load existing chart and settings profiles; change chart axes/layout/absolute mode; import old and new CSV logs; connect to the game and check all four wheels, calculated telemetry, race time, logging and the time chart; test configuration/version selection and unavailable-memory behavior. Compare live sampling cost before and after using the same configuration and workload before assigning a numerical speedup.
