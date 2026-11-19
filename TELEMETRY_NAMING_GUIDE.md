# Combined telemetry file and public field naming

Every recording writes **one** `Telemetry_yyyyMMdd_HHmmss.txt` file into the configured Logs directory.
The file is a semicolon-delimited table by default, with **one row per sampled tick**.
The same row contains all four wheels and one copy of each global value.

## Public column prefixes

| Prefix | Meaning | Example available in the current source |
|---|---|---|
| `FL_`, `FR_`, `RL_`, `RR_` | Wheel, tire, suspension, and geometry | `FL_SlipRatio`, `RR_RideHeight` |
| `ENG_` | Engine | `ENG_RPM`, `ENG_TorqueNm` |
| `GBX_` | Gearbox | Reserved: no gearbox offsets currently configured |
| `DIFF_` | Differential | `DIFF_TorquePrimaryLeft` |
| `BODY_` | Body rotation and orientation | `BODY_YawDeg`, `BODY_M11` |
| `ACC_` | Acceleration and G-force | `ACC_XG`, `ACC_XYZG` |
| `AERO_` | Aerodynamic forces | `AERO_FrontLift`, `AERO_XDragWorld` |
| `VEH_` | General vehicle data | `VEH_TravelSpeed`, `VEH_SprungMass` |
| `ENV_` | Environment | Reserved: no standalone ambient-environment fields currently configured |
| `TIME_` | Timing | `TIME_RaceTime` (milliseconds) |

Wheel members with a collision across source structures gain a qualifier:
`FL_Suspension1SpringRate` and `FL_Suspension2SpringRate`, for example.
The qualifier is used only for collisions. All generated columns are checked for uniqueness.

## JSON and compatibility

`WreckfestGameMemoryConfig.json` contains `telemetryPrefixes` and `telemetryAliases` for naming.
`enumValues` retains original memory symbols (e.g. `WF_EngineDataOffset.EngineRPM`),
because renamed offsets would break the reader and calculated formulas.
The public name for that field is `ENG_RPM`. The UI and the output file share these
public names. A legacy chart can still read its former unprefixed field names.

The live **Four Wheels** chart selects a *measurement shared across its visible
wheels*, so multi-wheel layouts offer `SlipRatio`, `SlipAngleDeg`, or
`Suspension1SpringRate` once, without a wheel prefix. A single-wheel layout
displays only its selected wheel's prefixed fields (for example,
`FR_SlipRatio` in Front Right mode). Global selections such as `ENG_RPM`
remain prefixed in both modes. The X/Y/Z settings and live extra filters follow
this rule. When changing the layout, the saved measurement is preserved and
translated to the new display name.

Logging and Offline Chart selectors instead refer to exact prefixed channels,
such as `FL_SlipRatio` and `FR_SlipRatio`. Older preferences are migrated on
load; the raw game-memory offset keys and combined log headers do not change.

Logging range filters now target **specific** columns such as `FL_SlipRatio`;
all ten enabled filters are ANDed to decide whether the single synchronized row
is written. Old generic wheel filter labels resolve to the Front Left wheel as a
migration fallback; review any previously saved filter profile.

Offline Chart opens both new combined files and older per-wheel CSV/TXT files.
The Offline Chart selector always shows the full channel name. Choose
`FL_SlipRatio` to see Front Left, `FR_SlipRatio` to see Front Right, etc.;
there are no separate unprefixed wheel-relative entries. Shared columns such as
`TIME_RaceTime` may be plotted against a wheel channel. Legacy imported headers
are converted in memory; the underlying CSV/TXT files are not modified.
Native values take precedence over dynamically calculated columns, whose
names use the same prefixes when their dependencies are available.

For custom memory configurations, `telemetryPrefixes` maps JSON field groups to
output categories and `telemetryAliases` maps `Group.Member` to public member names.
The original JSON offset keys must remain unchanged.
