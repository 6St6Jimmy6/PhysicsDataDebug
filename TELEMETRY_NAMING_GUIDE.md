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

In JSON schema 2, category `prefix` and optional per-field `alias` control public names.
The loader generates compatible internal memory symbols (e.g. `WF_EngineDataOffset.EngineRPM`),
because renamed offsets would break the reader and calculated formulas.
The public name for that field is `ENG_RPM`. The UI and the output file share these
public names. A legacy chart can still read its former unprefixed field names.

Both **Four Wheels** and **Offline Chart** select wheel measurements without
wheel prefixes: `SlipRatio`, `SlipAngleDeg`, `Suspension1SpringRate`, etc. The
**dataset layout** selects FL, FR, RL or RR, and chooses how their chart areas
are grouped. Single-wheel layouts keep the very same measurement choices.
Shared values such as `ENG_RPM` remain prefixed. X/Y/Z and chart filter
selectors follow this rule, including older saved selections migrated from
`FR_SlipRatio` to `SlipRatio`.

**Logging and CSV/TXT headers always retain exact source prefixes** (`FL_`,
`FR_`, `RL_`, `RR_`, etc.). Memory-offset keys are not renamed.

Logging range filters now target **specific** columns such as `FL_SlipRatio`;
all ten enabled filters are ANDed to decide whether the single synchronized row
is written. Old generic wheel filter labels resolve to the Front Left wheel as a
migration fallback; review any previously saved filter profile.

Offline Chart opens both new combined files and older per-wheel CSV/TXT files.
Choose `SlipRatio` once and use **Dataset layout** to plot all wheels together,
separately, front/rear, left/right, axle-only, side-only, or a single wheel.
Shared columns such as `TIME_RaceTime` can be plotted against wheel measurements.
Old prefixed axis preferences are mapped to their relative measurement names.
Legacy imported headers are normalized in memory without editing source files.
Native values take precedence over dynamically calculated columns, whose
names use the same prefixes when their dependencies are available.

For custom memory configurations, `telemetryPrefixes` maps JSON field groups to
output categories and `telemetryAliases` maps `Group.Member` to public member names.
The original JSON offset keys must remain unchanged.
