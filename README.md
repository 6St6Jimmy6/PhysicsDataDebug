# Wreckfest Physics Debugger

A Windows desktop application for inspecting, charting, and logging physics telemetry from **Wreckfest**. It reads game memory, provides live wheel and vehicle measurements, supports configurable charts and filters, and exports telemetry into text files for later analysis.

The application also includes an **Offline Four Wheels / CSV Chart**, which can plot imported files without connecting to the game.

## Example pictures

These screenshots are from earlier builds; the current layout may differ.
![LiveData page](https://github.com/user-attachments/assets/ac6a893e-7061-4b0f-8282-2e17cbecb5c4)
![4wheels_gradient](https://github.com/user-attachments/assets/b9b06097-d5fb-41b0-ab7a-59061e778523)

## Requirements

- Windows and a Wreckfest installation for **live** telemetry.
- A compatible `Wreckfest_x64.exe` build and matching memory configuration. Unsupported or changed game builds may require updated offsets.
- For building from source: Visual Studio with Windows Forms/.NET Framework desktop development support, targeting **.NET Framework 4.7.2** (C# 8.0 language setting).
- The offline chart does **not** require Wreckfest to be running.

## Getting started

1. Launch the Physics Debugger application.
2. In **Live Data**, select a Wreckfest version or **Automatic (Wreckfest_x64.exe)**.
3. Start Wreckfest, then select **Get Process** to attach to the game.
4. Open the live charts or telemetry windows you want to inspect.
5. Use each window's **Settings** or **Profiles** controls to customize its display. Saved preferences are restored on later launches.
6. For recorded data, configure **Log Settings** and select **Start Logging** in Live Data.

**Automatic version detection** attempts to identify the executable build and calculate an address shift. If detection fails, use the corresponding manually configured version. Memory addresses and field definitions are stored in `WreckfestGameMemoryConfig.json`, not hardcoded in the form layouts.

## Available windows

### Live Data

**Live Data** is the main navigation and telemetry-monitoring window. It provides game-version and memory-configuration selection, **Get Process**, logging controls, and access to:

- **Four Wheels** — live X/Y plots for individual tires, axle/side pairs, or combined wheel layouts.
- **G-Force** — polar acceleration plot with a vertical acceleration chart.
- **Tire Static Values** — tire dimensions, spring/damper, thermal, and mass/inertia data.
- **Suspension Static Values** — spring, travel-limit, damping/rebound, and bump-stop data.
- **Suspension Geometry** — front and rear suspension geometry visualization.
- **Live Time Chart** (`FormLiveTimeChart`) — up to five stacked telemetry plots sharing RaceTime.
- **Offline Four Wheels / CSV Chart** — imported-file plotting without a live game connection.
- **Log Settings** — choose recorded channels, filters, output directory, and logging limits.

#### Configurable telemetry monitor

The Live Data monitor is populated from the active game-memory JSON, rather than a fixed list of labels. Expand categories such as **Aerodynamics** to select individual drag or lift measurements, or check a category to display everything it contains. Each selected measurement appears in its own row:

- Tire and suspension measurements use **FL / FR / RL / RR** value columns in the same row.
- Shared vehicle measurements appear **once**, rather than once per wheel.
- Labels and units come from each field's JSON `displayName`, `unit`, and `unitName` properties. Hover over a unit abbreviation, such as `N` or `m/s`, to see its full description (for example, *newtons* or *meters per second*).

Your visible measurement selections are stored separately from the game-memory configuration, so changing what you monitor does not change memory offsets or log field names.

Available measurements include tire, suspension, body, engine, differential, acceleration, aerodynamics, timing, and any other groups supplied by the active JSON. Calculated telemetry can also be defined by JSON expressions; specialized calculations remain available as named built-ins.

### Four Wheels

The live **Four Wheels** chart supports:

- Configurable **X**, **Y**, and **Z/color** measurements.
- **Separate**, **Front/Rear**, **Left/Right**, **All In One**, axle-only, side-only, and individual-wheel dataset layouts.
- A configurable Z-axis gradient palette, color bands, and legend.
- Per-band history limits and current-value markers.
- **13 filters**: three based on the selected X/Y/Z measurements, plus ten optional telemetry filters.
- Searchable selectors and named JSON settings profiles.

**Measurement choice is independent of dataset layout.** Select a wheel measurement once—for example, `SlipRatio`, `SlipAngleDeg`, or `LateralFriction`—and the dataset layout determines which of **FL / FR / RL / RR** is drawn and where. Single-wheel layouts use the same unprefixed wheel choices. Shared measurements remain prefixed, such as `ENG_RPM`, `BODY_YawDeg`, and `TIME_RaceTime`.

`Form4WheelsSettings` uses dark, Designer-editable setting groups. Its **Chart Settings** tab holds the appearance and axis controls. Its **Filters** tab holds all 13 filters and the live-only **No tire contact limiter**; use **Apply Filters** in the Settings action bar. The filter rows are owned by the Settings Designer, not the main chart window. Chart settings have separate **Apply Chart Settings** and **Clear Charts and Apply** actions, allowing changes without necessarily discarding history. Live and offline Cartesian axis lines inherit the parallel major grid's color, alpha, width and dash style; exterior tick marks are disabled.

### G-Force
![GForce page](https://github.com/user-attachments/assets/1e894ee1-7850-4251-962f-2d70a3c24269)

The G-Force page shows a polar acceleration chart alongside a narrower vertical acceleration visualization. **G-Force Settings** provides background and marker colors, axis fonts, angle units (degrees/radians), grid styling, history limits, and color schemes.

- **Apply Chart Settings** updates formatting while keeping existing history.
- **Clear Charts and Apply** updates formatting and resets chart history.
- The chart window also provides **Clear Charts**.
- Changing between degrees and radians through Apply converts existing polar-history coordinates.

Saved G-Force settings are restored before the chart is opened. The default X/Y font is **Arial** unless a custom font has been saved.

### Tire and Suspension Static Values

Both static-value windows use a **2 × 2 wheel layout**:

| Front Left | Front Right |
| --- | --- |
| Rear Left | Rear Right |

Each wheel has its own scrolling region and labeled parameter groups. The groups are defined in the WinForms Designer rather than being reconstructed from control coordinates at runtime.

### Suspension Geometry
![3DSuspensionGeometry page](https://github.com/user-attachments/assets/414de6d6-55d8-4251-beb4-f502733dc62e)
`FormSuspensionGeometry` shows two **live 3D wireframe views** for the front (FL/FR) and rear (RL/RR) suspension. It uses X, Y, and Z positions for body-side suspension pickups, spindle-side joints, steering and push rods, wheel pivots and tire outlines. You can inspect the geometry from any angle.
- **Left-drag** either view to rotate both front and rear cameras, **right/middle-drag** to pan a view, and use the **mouse wheel** to zoom. Hover over a joint to see its name and X/Y/Z coordinates in metres.
- Toolbar controls adjust **Azimuth**, **Elevation**, **Zoom (%)**, and **Update (ms)**; preset **Front**, **Side**, **Top**, **Isometric**, and **Reset view** buttons restore useful viewpoints.
- Toggle **Perspective**, the ground **Grid**, **Point names**, **Legend**, and **Rotate spindle offsets** (uses the game's tire orientation matrix to turn local spindle offsets into the wheel's orientation).
- Green/blue tire outlines distinguish left/right wheels. Upper arms, lower arms, steering rods, and pushrods have different colors. The in-view legend identifies the arm colors, pickup points, wheel pivots, projected centers and vehicle center-of-mass height. The previous 2D instant-center/roll-center calculations remain available as explicitly labeled **XY projections**, not as genuine 3D roll-axis solutions.

The update interval defaults to **100** ms and can be set from **10** to **10,000** ms. Camera settings and display choices are saved in `FormSuspensionGeometry.json`. The view continues to refresh available suspension data even when RaceTime is paused. Missing or invalid points are skipped instead of drawing them at zero.
The 3D wireframe uses the existing vehicle-relative data conventions from the previous 2D chart. The tire-matrix rotation can be disabled for comparison with the original untranslated spindle offsets. See [SUSPENSION_3D_GUIDE.md](SUSPENSION_3D_GUIDE.md) for usage and geometry assumptions.

### Live Time Chart (previously Tire Temperatures)

`FormLiveTimeChart` (formerly `FormTireTemperatures`) provides a **MoTeC-style live time history** rather than four fixed temperature plots. Up to **five** independently enabled plot lanes share one time axis. Every plot selects one measurement (for example `SlipRatio`, `TreadTemperature`, `ACC_XG`, or `ENG_RPM`) and displays any combination of **FL, FR, RL, RR** in that lane. Per-lane wheel checkboxes control visibility without changing the selected measurement. Shared vehicle telemetry is drawn once rather than duplicated across wheel channels.

**X always uses `TIME_RaceTime`.** Wreckfest supplies it in **milliseconds**; the chart converts this to seconds internally and can label the X axis in seconds or minutes. The visible backwards-looking history window is adjustable in seconds or minutes. A new **Live Time Chart Settings** dialog controls the window, refresh rate, series type, line thickness and markers, grid and text appearance, independent wheel/vehicle colors (including custom hex colors), and automatic or fixed Y ranges for each plot.

The chart provides **Resume**, **Pause**, and **Clear History** actions. RaceTime pauses do not create duplicate points, and a RaceTime reset clears the previous session. Track choices and settings persist through the existing per-form JSON settings system.

See [LIVE_TIME_CHART_GUIDE.md](LIVE_TIME_CHART_GUIDE.md).

## Offline Four Wheels / CSV Chart
![OfflineChart page](https://github.com/user-attachments/assets/1c743ce6-ec69-4f5e-9c06-403cac49efe3)

Use **Offline Chart** to visualize recorded or imported delimited telemetry without Wreckfest running.

- Import multiple **CSV, TXT, TSV, or LOG** files and choose which datasets are visible.
- Select **X**, **Y**, and **Z/color** measurements, chart type, palette, gradient bands, axis ranges, fonts, and grid styles.
- Choose a **dataset layout** to route FL/FR/RL/RR channels into separate, grouped, or combined chart areas. Single-wheel layouts display only that wheel's series.
- Configure cursor appearance and X/Y zoom, and inspect data points using hover tooltips or pinned information popups.
- Save and restore chart settings through named JSON profiles.

The selectors follow the same rule as live Four Wheels: a wheel measurement such as `SlipAngleDeg` appears **once**, without a wheel prefix. The dataset layout resolves `FL_SlipAngleDeg`, `FR_SlipAngleDeg`, `RL_SlipAngleDeg`, and `RR_SlipAngleDeg` from the imported file as needed. Shared measurements such as `TIME_RaceTime` keep their prefixes. Combined logs and older individual-wheel files are supported; imported file headers are not rewritten.

**All 13 chart filter rows are owned by `FormOfflineChartSettings.Designer.cs`**, in the filter section below its action bar. **Apply Filters** is in that action bar; no filter panels are parked on the main Offline Chart window. Applying filters changes the displayed points without altering the source file.

Some WinForms chart types require multiple Y values and cannot be rendered from a single X/Y/Z row; these combinations are reported instead of being treated as ordinary single-Y plots.

For details, see [OFFLINE_CHART_GUIDE.md](OFFLINE_CHART_GUIDE.md) and [TELEMETRY_NAMING_GUIDE.md](TELEMETRY_NAMING_GUIDE.md).

## Logging telemetry
![LogSettings](https://github.com/user-attachments/assets/82fc5c65-bc6a-4a49-a592-8d8709c0ecf0)

Open **Log Settings** from Live Data, choose the channels to record, and select **Start Logging**.
The logger records **one synchronized file per session**, rather than four separate wheel files.

### Selectable fields and names

The logging tree is populated from the active game-memory JSON and the lazy calculated-telemetry registry. Expand a category and tick a wheel measurement (for example, `MomentOfInertia`) to select **FL**, **FR**, **RL**, and **RR** together. Expand that measurement to untick any individual wheel without affecting the others; a partial parent displays its selection count (for example, `3/4`). Shared engine, body, acceleration, aerodynamic, differential, vehicle, and timing measurements appear only once. Examples:

```text
TIME_RaceTime;FL_SlipRatio;FR_SlipRatio;RL_SlipRatio;RR_SlipRatio;ENG_RPM;VEH_TravelSpeed
15000;0.01;0.02;0.01;0.03;4500;28.4
```

The row above is an **illustrative example**, not a recorded game sample. `TIME_RaceTime` is measured in **milliseconds**. Public column names use these prefixes: `FL_`, `FR_`, `RL_`, `RR_`, `ENG_`, `GBX_`, `DIFF_`, `BODY_`, `ACC_`, `AERO_`, `VEH_`, `ENV_`, and `TIME_`. `GBX_` and `ENV_` are reserved until memory fields for those categories become available. Duplicate suspension member names receive `Suspension1` or `Suspension2` qualifiers.

Field selection is saved using stable field and wheel identities, rather than checklist positions. Older flat-list logging selections are migrated where possible.

### Ten logging filters

You can configure up to **10 independent filters**, each with a telemetry column, an enabled checkbox, minimum and maximum bounds, optional absolute value, and an **Inside range** or **Outside range** mode. Every active filter must pass before the **whole synchronized row** is written. For example, filtering `FL_SlipRatio` controls whether the sample containing all four wheels is recorded.

### Log filenames and location

The default output directory is:

```text
%APPDATA%\PhysicsDataDebug\Logs\
```

A logging session creates a single file named, for example, `Telemetry_20261119_151725.txt`. Its header and rows use the chosen delimiter (semicolon by default) and UTF-8 encoding. You may choose a different output folder. Existing files are never overwritten; filename collisions receive a numeric suffix.

### Automatic stop conditions

Two optional limits can stop the active logging session:

| Limit | Behavior |
|---|---|
| **Time** | Maximum elapsed recording time, in seconds. |
| **File size** | Maximum size of the single log file, in MiB (including the header). |

A value of **0** disables that limit. If both are enabled, the first reached stops logging. Settings changed during a session apply to the next recording. The Live Data sampling interval is configurable (50 ms by default), but actual sampling cadence depends on game and PC workload.

## Saved settings and profiles

Current UI settings are saved in editable JSON files under:

```text
%APPDATA%\PhysicsDataDebug\Settings\
```

The program maintains separate settings for its forms, such as `FormLiveData.json`, `Form4WheelsSettings.json`, `FormGForceSettings.json`, `FormOfflineChartSettings.json`, and `FormLogSettings.json`. Named profiles are kept under `Settings\Profiles\<FormName>\`.

Where available, the **Profiles** menu allows you to:

1. Save the current settings as a named profile.
2. Load a previously saved profile.
3. Restore factory defaults or recover the previous autosave (`.bak`).
4. Reset one form or all form settings/profiles (with archival and restart), or open the settings folder.

Factory-default snapshots are created only if missing, so upgrading the program does not silently replace an existing baseline. On first use, legacy registry preferences may be imported into JSON; ongoing settings are stored in JSON rather than written back to the registry.

**Game-memory configuration is separate from UI preferences.** Do not use a per-form settings profile as a substitute for the executable version and address configuration.

For more information, see [SETTINGS_PROFILES_GUIDE.md](SETTINGS_PROFILES_GUIDE.md).

## Game-memory JSON configuration

`WreckfestGameMemoryConfig.json` defines game versions, shared base addresses, categorized raw telemetry, calculated fields, and per-field display defaults. The reader dynamically batches nearby memory offsets instead of depending on manually specified fixed chunk sizes.

In **schema 2**, a field belongs to a category and can inherit its base address and wheel offsets. Adding an ordinary raw field can be as simple as specifying its final offset; optional field settings include:

| Property | Purpose |
|---|---|
| `offset` | Raw memory offset relative to the field's configured base/pointer structure. |
| `type` | Data interpretation, such as `float32`. |
| `axisDefaults` | Suggested axes, intervals, and decimal precision for charts. |
| `absolute` | Mark a field for absolute-value behavior where applicable. |
| `displayName` | Human-readable monitoring label, e.g. `Front Lift`. |
| `unit` | Short unit symbol, e.g. `N`. |
| `unitName` | Full unit label for tooltips, e.g. `newtons`. |
| `expression` | Formula for a calculated field, under the category's `calculated` section. |

For example, an existing `FrontLift` field can have presentation properties like these alongside its **actual configured offset**:

```json
"displayName": "Front Lift",
"unit": "N",
"unitName": "newtons"
```

The field's raw identity and public telemetry prefix do not change when its presentation label changes. Likewise, a calculated tire value can be added under `tire.calculated` with an expression such as `LateralLoad / VerticalLoad`; the calculation system resolves wheel-specific dependencies and makes the result available to compatible charts and logging. More complex operations can use named built-in functions. Public telemetry selections are generated from the configuration, so duplicate hand-maintained selector lists are unnecessary. Legacy schema 1 configurations remain supported.

The bundled game configuration is installed into the user's Settings folder on first use. You can maintain additional named JSON configurations and choose them with **Config ▼** in Live Data. Options include loading, saving a copy, reloading, selecting the default Wreckfest configuration, and opening its folder.

**Before switching or editing memory configurations**, stop sampling and logging and close other chart/settings windows. Back up customized files: updates do not automatically overwrite your saved configuration, and incorrect memory offsets can cause invalid reads or attachment failures.

See [GAME_CONFIG_GUIDE.md](GAME_CONFIG_GUIDE.md), [LAZY_TELEMETRY_GUIDE.md](LAZY_TELEMETRY_GUIDE.md), and [WRECKFEST_AUTO_DETECTION.md](WRECKFEST_AUTO_DETECTION.md) for the schema and memory-reader details.

## Interface and Designer organization

Most chart settings use a consistent dark theme, searchable ComboBoxes, and grouped layout panels. Font/color selections have shared drawing helpers; color choices are displayed with contrast-aware text so both bright and dark colors remain readable. All color selectors also accept a custom hex value: type `#RRGGBB` (for example, `#FFFFFF`) and press **Enter** or move focus away to commit it. `#AARRGGBB` is also accepted for alpha values. Custom colors are retained by JSON settings and profiles.

The grouped settings, tire/suspension static-value pages, and geometry toolbar are primarily **Designer-owned WinForms controls**. They can be inspected and rearranged through **Visual Studio → View → Other Windows → Document Outline**. Some dynamic measurement and filter choices are intentionally populated at runtime from the JSON configuration or imported file headers.

The current source package has no `tools` directory. No Python validation scripts are required to build or run the application. The filter rows in both chart Settings designers share `ChartLimiterRow.Designer.cs`; `ChartLimiterRowHost.cs` is obsolete and absent from this build.

## Building and troubleshooting

1. Open `Wreckfest Physics Debugger.sln` in Visual Studio on Windows.
2. Install the **.NET Framework 4.7.2** targeting/developer pack if Visual Studio requests it.
3. Restore any missing project references, then **Rebuild Solution**.
4. Run the application and confirm that the selected Wreckfest version matches your executable before attaching.

If a WinForms Designer window fails to load, first resolve **Build** errors and rebuild the project, then close and reopen the Designer tab. Live memory reads and runtime-only file/configuration loading should not run inside the Designer.

If attaching or drawing geometry causes an exception, inspect the **exception type, message, and call stack**. An exception shown at `Application.Run(...)` is not necessarily caused by that statement; the failing call may be inside a form update, memory read, or chart renderer.

## Further documentation

- [GAME_CONFIG_GUIDE.md](GAME_CONFIG_GUIDE.md) — memory configuration, schema 2, calculated expressions, versions, and fields.
- [WRECKFEST_AUTO_DETECTION.md](WRECKFEST_AUTO_DETECTION.md) — executable-version detection.
- [SETTINGS_PROFILES_GUIDE.md](SETTINGS_PROFILES_GUIDE.md) — saved preferences and named profiles.
- [OFFLINE_CHART_GUIDE.md](OFFLINE_CHART_GUIDE.md) — importing files, dataset layouts, and chart controls.
- [LIVE_TIME_CHART_GUIDE.md](LIVE_TIME_CHART_GUIDE.md) — synchronized live time-history charts.
- [TELEMETRY_NAMING_GUIDE.md](TELEMETRY_NAMING_GUIDE.md) — prefixes, combined logs, and measurement selectors.
- [LAZY_TELEMETRY_GUIDE.md](LAZY_TELEMETRY_GUIDE.md) — telemetry-reading architecture and performance.
- [SUSPENSION_3D_GUIDE.md](SUSPENSION_3D_GUIDE.md) — 3D camera, geometry, legend and coordinate assumptions.
- [REFACTOR_NOTES.md](REFACTOR_NOTES.md) — current refactoring and validation limitations.
- [Current build changes](changelogs/CURRENT_BUILD_2026-11-24.md) — filter ownership, chart axes, 3D suspension and documentation.
- [Historical changelogs](changelogs/README.md) — earlier implementation records, not current instructions.

## Acknowledgments

- **Cartoons** — help with discovering and confirming the first in-game memory values.
- **N4T4NM** and **iGutobreks** — earlier memory-helper code and usage.
- **Rod Stephens** — the original registry-persistence example used in older versions.

## Latest chart updates

- Live Four Wheels uses FastPoint by default. Other history chart types are timed during initial rebuild/paint and subsequent telemetry updates; a rebuild taking over 5 s or a subsequent render exceeding the timer interval by over 1 s switches back to FastPoint and preserves history. The current marker remains a normal Point. The WinForms UI thread cannot interrupt a renderer that never returns.
- Offline Chart restores the Settings and Filters Apply actions, uses Arial and FastPoint as fresh defaults, and subdivides enabled minor grids. Optional true XYZ scatter plotting supports a fourth color field using the existing Z/color palette controls. See [Offline Chart guide](OFFLINE_CHART_GUIDE.md).
- G-force settings have independent current/history marker sizes and sampling interval. Fresh telemetry/chart update defaults are 50 ms; the G-force infinite-history snapshot timer and connection/status housekeeping remain intentionally separate.
- Suspension Geometry can translate and tilt its grid across each axle to touch both rendered tire outlines, without changing their original XYZ coordinates. See [Suspension guide](SUSPENSION_3D_GUIDE.md).
- Profiles buttons are Designer-owned on all eight forms that use the shared profile menu. Existing user-selected settings are not forcibly reset.
