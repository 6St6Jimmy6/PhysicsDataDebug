# Configuring Wreckfest game versions, offsets and chart defaults

Game-memory configurations now live in the same user-editable directory as
the form preferences:

```
%APPDATA%\PhysicsDataDebug\Settings\
```

On the **first launch**, the application creates
`WreckfestGameMemoryConfig.json` there using the defaults embedded in the
executable. The original source file is named `WreckfestGameMemoryConfig.json`
in the Visual Studio project and compiled as an **Embedded Resource**. You no
longer need a JSON file beside the executable. If you have an old, edited
`GameMemoryConfig.json` beside the executable from a previous release, that
file is copied to `WreckfestImportedGameMemoryConfig.json` and selected on the
first launch. The pristine `WreckfestGameMemoryConfig.json` remains available
separately. Existing AppData files are never overwritten by startup.

To edit the running game configuration, change its JSON in the AppData folder
and use **Config ▼ → Reload current configuration** on the Live Data page
while memory capture is stopped. Alternatively restart the app.

## Multiple game configuration profiles

Store any number of named game-memory JSON files in the Settings folder, for
example `WreckfestGameMemoryConfig.json` and
`WreckfestBetaGameMemoryConfig.json`. On the Live Data form, next to **Select
Game Version**, use **Config ▼**:

- **Load game configuration...** — select any JSON. If it is outside the
  Settings folder, a uniquely named copy is imported there first.
- **Save current configuration as...** — copy the current JSON to a new file
  for experimentation, without overwriting the original.
- **Reload current configuration** — apply manual edits to the active file.
- **Select Wreckfest configuration** — switch to the stored
  `WreckfestGameMemoryConfig.json`.
- **Open configuration folder** — open the AppData Settings folder.

Stop memory sampling and logging and close any other chart/settings forms
before switching. The available game versions and telemetry lists rebuild
from the newly loaded configuration. The selected filename is recorded in
`ActiveGameMemoryConfig.json` and restored automatically on later launches.
The regular `FormLiveData.json` independently remembers which **version** you
selected within that configuration. The original offsets and version options
are unchanged.

`ActiveGameMemoryConfig.json` is also editable. For example:

```json
{"fileName":"WreckfestGameMemoryConfig.json"}
```

It contains only a filename, not a full path. All selectable configurations
belong in `%APPDATA%\PhysicsDataDebug\Settings`. The current memory reader
still expects Wreckfest-style data layouts and the `Wreckfest_x64` process;
supporting a completely different game will also require adapting that reader.

## Game version selection

Under `versions`, each object defines a distinct game build:

```json
{
  "id": "V1_NewBuild",
  "displayName": "My new Wreckfest build",
  "baseAddressShift": "0xA000",
  "enumOverrides": {
    "BaseAddress": {
      "Tire": "0x18324C8",
      "Engine": "0x18327C8"
    },
    "WF_TireDataOffset": {
      "VerticalLoad": "0x490",
      "SlipRatio": "0xBF4"
    },
    "WF_TireDataChunks": {
      "ChunkSize": "0xC4C"
    }
  }
}
```

Insert this object into the existing `versions` array (with a comma between
objects). You can add as many versions as you want. `id` must be unique;
`displayName` is what the selector shows. `defaultVersion` is the version
selected on a fresh install. After that, **Select Version Number** remembers
the last chosen `id` through the existing saved UI settings.

The two shipped versions reproduce the previous hardcoded offsets:

| Version | Base-address shift |
| --- | --- |
| `V1_285308` | `0x0` |
| `V1_308408` | `0x9E00` |

`enumValues` provides shared defaults for the 32 groups of physical memory
addresses, wheel-side offsets, chunk starts/sizes, and memory-read fields.
Per-version `enumOverrides` replace individual entries, while omitted entries
keep their shared values. The original enum-only IDs and computed offsets have
been removed: they did not point to game memory.
Write offsets as quoted hexadecimal strings (`"0x4AC"`), including negative
offsets if applicable (`"-0x10"`). Ordinary decimal numbers/strings are
also accepted. Keep the existing group and field names used by the program;
the application resolves these symbolic names at runtime without compiled
`WreckfestEnums.cs` enumerators.

There is no longer a requirement that all `BaseAddress` aliases have the same
value: e.g. `BaseAddress.Tire` and `BaseAddress.Suspension1` are addressed by
their exact names, even though their original C# enum constants are aliases.

## Adding data fields

To add a new raw tire float in a known memory chunk, add a new name under
`enumValues.WF_TireDataOffset`, for example:

```json
"CustomTireFloat": "0x4E0"
```

The name appears in the four-wheel X/Y/Z and limiter choices, and is read
from the four tire memory chunks. Newly named fields in the Engine,
Differential, Body Rotation, Body Acceleration, Aero, Suspension1,
Suspension Geometry, Suspension2 and Mass offset groups also enter the
respective telemetry data list. **Declare new field names in shared
`enumValues`**, then override their numeric positions in individual
versions if needed, so the available data-field list is consistent across
versions. Newly added fields are currently interpreted as 32-bit floats.

For every new physical field, ensure the relevant `DataStart`, `ChunkSize`,
and memory block offsets encompass that field, with aligned four-byte
positions. For example, the tire chunk covers the range starting at
`WF_TireDataChunks.DataStart` for `WF_TireDataChunks.ChunkSize` bytes.
The built-in **calculated** fields (tire friction, converted angles, etc.)
are generated by code and appended after the raw chunk; they are not direct
game-memory reads. **They have no entries in `enumValues`**: their names and
order are in `CalculatedTelemetry.cs`, and the calculations in `LiveData.cs`.
You can use them by their symbolic names in charts and logs exactly like raw
values. Add or reorder calculations in both C# locations together. Adding a completely new
memory block or a new chart axis type requires corresponding code wiring.

## Chart customization

The `wheelAxisDefaults` dictionary controls the defaults when selecting an
axis on the Four Wheels page:

```json
"VerticalLoad": {
  "max": 10000,
  "min": 0,
  "majorInterval": 1000,
  "decimals": 0,
  "minorEnabled": true,
  "minorIntervalFraction": 2
}
```

You can add an entry for a custom tire field as well. Existing axis settings
saved through the UI still take priority until you reset/apply defaults.
`absoluteValueFields` is also editable: it lists the field names for which
the axis/limiter defaults should use absolute-value behavior.

`telemetrySelections` records the canonical prefixed telemetry names
in the supplied JSON. The live Four Wheels X/Y/Z selectors are built from
the available configured fields, showing each wheel measurement once without
FL_/FR_/RL_/RR_ in multi-wheel layouts, and showing only the chosen wheel's
prefix in single-wheel layouts. Global fields keep their category prefixes.
The logger and Offline Chart retain the full prefixed channel names.
These are **names, not hexadecimal offsets**. Any new raw tire field added under
`enumValues.WF_TireDataOffset` is offered automatically.

The `gForce` block has two options:

```json
"gForce": {
  "gradientSteps": 10,
  "maxInfiniteHistoryPoints": 0
}
```

`gradientSteps` supports 1–64 interpolated color bands (original default:
10). `maxInfiniteHistoryPoints` sets a cap on old G-force snapshot points;
`0` preserves unlimited history. Normal live history length, color scheme,
marker color, and other G-force settings remain configurable in the UI and
persist between sessions.

## Invalid values

If the JSON is missing or fails to parse, the application shows an error and
stops rather than reading arbitrary memory; it no longer has compiled backup
offsets. A syntactically valid but
incorrect address can still make memory reads fail or produce wrong values;
validate each new version in-game. Keep a backup of a working JSON file.
