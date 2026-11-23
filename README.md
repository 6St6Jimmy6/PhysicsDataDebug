# Wreckfest Physics Debugger

A Windows desktop application for inspecting, charting, and logging physics telemetry from **Wreckfest**. It reads game memory, provides live wheel and vehicle measurements, supports configurable charts and filters, and exports telemetry into text files for later analysis.

The application also includes an **Offline Four Wheels / CSV Chart**, which can plot imported files without connecting to the game.

# Example pictures (outdated)

![LiveData page](https://github.com/user-attachments/assets/c68f05b9-0a75-47ca-88be-779a9ff533a7)
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

The main window displays live measurements and provides navigation to the other tools, including:

- **Four Wheels** — live X/Y plots for individual tires, front/rear pairs, or combined wheel layouts.
- **G-Force** — polar acceleration plot with a vertical acceleration chart.
- **Tire Static Values** — tire dimensions, spring/damper, thermal, and mass/inertia data.
- **Suspension Static Values** — spring, travel-limit, damping/rebound, and bump-stop data.
- **Suspension Geometry** — front and rear geometry visualization.
- **Live Time Chart** (`FormTireTemperatures`) — up to five vertically stacked synchronized telemetry plots, including tire temperatures, with a configurable RaceTime window.
- **Offline Four Wheels / CSV Chart** — imported-file plotting without a live game connection.
- **Log Settings** — choose recorded fields, filters, output directory, and logging limits.

The available memory measurements include tire, suspension, body, engine, differential, acceleration, aerodynamics, timing, and other categories defined in the active game-memory JSON. Some additional selections are **calculated telemetry**, derived from raw readings. Schema 2 allows you to define most new calculated fields directly in JSON using mathematical expressions; more complex quaternion and tire-grip calculations remain available as named built-ins.

### Four Wheels

The live Four Wheels page supports:

- Configurable **X**, **Y**, and **Z/color** measurements.
- **Separate**, **Front/Rear**, **Left/Right**, **All In One**, axle-only, side-only, and individual-wheel layouts.
- A configurable Z-axis gradient palette, number of color bands, and legend.
- Per-band history limits and current-value markers.
- **13 chart filters:** three that follow the selected X/Y/Z fields, plus ten optional extra telemetry filters.
- Independent filter limits and reset/default controls.
- Separate **Apply Chart Settings** and **Clear Charts and Apply** actions in the settings window. Applying appearance changes does not necessarily discard recorded history.
- Searchable selectors and JSON settings profiles.

**Four Wheels field selection is independent of dataset layout.** All layouts,
including single-wheel layouts, offer each wheel measurement only once as
`SlipRatio`, `SlipAngleDeg`, `LateralFriction`, etc. The chart resolves the
measurement for the FL/FR/RL/RR datasets selected by the layout. Shared fields
retain category prefixes (`ENG_RPM`, `BODY_YawDeg`, `TIME_RaceTime`). The 13 live
chart filters use the same choices. Log file headers remain fully prefixed.

The four-wheel settings window uses dark, **Designer-editable groups**. Related fields share horizontal rows, and the four main settings sections have equal-width columns.

### G-Force

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

Displays front and rear suspension geometry. A compact toolbar lets you adjust:

| Setting | Default |
| --- | ---: |
| X minimum | -1.5 |
| X maximum | 1.5 |
| Y minimum | -0.5 |
| Y maximum | 1.5 |
| Update interval | 100 ms |

The X/Y limits apply to both charts. The update interval controls the geometry timer and can be set from **10 to 10,000 ms**. Values are saved in the per-form settings JSON. Invalid or undefined geometric intersections are omitted from the plot rather than being passed to the chart renderer.

### Live Time Chart (previously Tire Temperatures)

`FormTireTemperatures` now provides a **MoTeC-style live time history** rather than four fixed temperature plots. Up to **five** independently enabled plot lanes share one time axis. Every plot selects one measurement (for example `SlipRatio`, `TreadTemperature`, `ACC_XG`, or `ENG_RPM`) and displays any combination of **FL, FR, RL, RR** in that lane. Per-lane wheel checkboxes control visibility without changing the selected measurement. Shared vehicle telemetry is drawn once rather than duplicated across wheel channels.

**X always uses `TIME_RaceTime`.** Wreckfest supplies it in **milliseconds**; the chart converts this to seconds internally and can label the X axis in seconds or minutes. The visible backwards-looking history window is adjustable in seconds or minutes. A new **Live Time Chart Settings** dialog controls the window, refresh rate, series type, line thickness and markers, grid and text appearance, independent wheel/vehicle colors (including custom hex colors), and automatic or fixed Y ranges for each plot.

The chart provides **Start / Resume**, **Pause**, and **Clear History** actions. RaceTime pauses do not create duplicate points, and a RaceTime reset clears the previous session. Track choices and settings persist through the existing per-form JSON settings system.

See [LIVE_TIME_CHART_GUIDE.md](LIVE_TIME_CHART_GUIDE.md).

## Offline Four Wheels / CSV Chart

Use this window to visualize recorded or imported delimited telemetry independently of Wreckfest.

- Import multiple **CSV, TXT, TSV, or LOG** files and choose which files are visible.
- Map imported column headers to **X**, **Y**, and **Z/color** selections.
- Use the same general arrangement of **13 filters** as the live Four Wheels page (three axis-following filters and ten additional filters).
- Change chart types, palettes, gradient bands, axis ranges, fonts, and grid styling.
- Configure cursor appearance and X/Y zoom behavior.
- Inspect supported data points using hover tooltips or click to pin a point-information popup.
- Save and restore settings using JSON profiles.

**Apply Filters** redraws the view without changing the original imported rows. Some WinForms chart types require multiple Y values and cannot be rendered from a single X/Y/Z row; the application reports those combinations rather than treating them as ordinary single-Y plots.

For details, see [OFFLINE_CHART_GUIDE.md](OFFLINE_CHART_GUIDE.md).

## Logging telemetry

Open **Log Settings** from Live Data, choose the channels to record, and select **Start Logging**.
The logger records **one synchronized file per session**, rather than four separate wheel files.

### Selectable fields and names

The logging tree is populated from the active game-memory JSON and the lazy calculated-telemetry registry. Expand a category and tick a wheel measurement (for example, `MomentOfInertia`) to select **FL**, **FR**, **RL**, and **RR** together. Expand that measurement to untick any individual wheel without affecting the others; a partial parent displays its selection count (for example, `3/4`). Shared engine, body, acceleration, aerodynamic, differential, vehicle, and timing measurements appear only once. Examples:

```text
TIME_RaceTime;FL_SlipRatio;FR_SlipRatio;RL_SlipRatio;RR_SlipRatio;ENG_RPM;VEH_TravelSpeed
15000;0.01;0.02;0.01;0.03;4500;28.4
```

The row above is an **illustrative example**, not a recorded game sample. `TIME_RaceTime` is measured in **milliseconds**. Public column names use these prefixes: `FL_`, `FR_`, `RL_`, `RR_`, `ENG_`, `GBX_`, `DIFF_`, `BODY_`, `ACC_`, `AERO_`, `VEH_`, `ENV_`, and `TIME_`. `GBX_` and `ENV_` are reserved until memory fields for those categories become available. Duplicate suspension member names receive `Suspension1` or `Suspension2` qualifiers.

Field selection is saved by the stable field and wheel identity, not checklist index. Older flat-list settings are migrated. The grouped JSON **schema 2** stores raw field offsets, types, axis defaults and absolute-value behavior in one category-owned definition; public prefixes/aliases are derived from that definition. The application also supports legacy schema 1 game configurations.

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

The **Offline Chart** imports combined TXT files and older CSV/TXT logs. Axis and filter dropdowns display wheel measurements without prefixes (for example `SlipAngleDeg`, `LateralFriction` and `VerticalLoad`) and shared fields with category prefixes (`TIME_RaceTime`). Its dataset layout chooses the wheel channels and chart areas. Import preserves fully prefixed file headers internally and accepts legacy names.

For field naming and compatibility details see [TELEMETRY_NAMING_GUIDE.md](TELEMETRY_NAMING_GUIDE.md).

## Saved settings and profiles

Current UI settings are saved in editable JSON files under:

```text
%APPDATA%\PhysicsDataDebug\Settings\
```

The program maintains separate settings for its forms, such as `FormLiveData.json`, `Form4WheelsSettings.json`, `FormGForceSettings.json`, `FormOfflineChartSettings.json`, and `FormLogSettings.json`. Named profiles are kept under `Settings\Profiles\<FormName>\`.

Where available, the **Profiles** menu allows you to:

1. Save the current settings as a named profile.
2. Load a previously saved profile.
3. Restore factory defaults.
4. Open the settings folder.

Factory-default snapshots are created only if missing, so upgrading the program does not silently replace an existing baseline. On first use, legacy registry preferences may be imported into JSON; ongoing settings are stored in JSON rather than written back to the registry.

**Game-memory configuration is separate from UI preferences.** Do not use a per-form settings profile as a substitute for the executable version and address configuration.

For more information, see [SETTINGS_PROFILES_GUIDE.md](SETTINGS_PROFILES_GUIDE.md).

## Game-memory JSON configuration

`WreckfestGameMemoryConfig.json` defines available game versions, shared base addresses, categorized raw telemetry fields, and per-field defaults. The memory reader dynamically batches nearby configured offsets instead of relying on manually fixed chunk sizes. The built-in configuration is installed into the user Settings folder on first launch. You can maintain additional named JSON configurations and select them using **Config ▼** on Live Data.

Available actions include loading a configuration, saving a copy, reloading the active configuration, selecting the default Wreckfest configuration, and opening the folder.

To edit a configuration, **stop sampling and logging** and close other chart/settings windows before switching it. Be careful when editing memory offsets: an incorrect offset can produce invalid values or make attachment/read operations fail.

See [GAME_CONFIG_GUIDE.md](GAME_CONFIG_GUIDE.md) and [WRECKFEST_AUTO_DETECTION.md](WRECKFEST_AUTO_DETECTION.md) for version profiles and automatic detection details.

## Interface and Designer organization

Most chart settings use a consistent dark theme, searchable ComboBoxes, and grouped layout panels. Font/color selections have shared drawing helpers; color choices are displayed with contrast-aware text so both bright and dark colors remain readable. All color selectors also accept a custom hex value: type `#RRGGBB` (for example, `#FFFFFF`) and press **Enter** or move focus away to commit it. `#AARRGGBB` is also accepted for alpha values. Custom colors are retained by JSON settings and profiles.

The grouped settings, tire/suspension static-value pages, and geometry toolbar are primarily **Designer-owned WinForms controls**. They can be inspected and rearranged through **Visual Studio → View → Other Windows → Document Outline**. Some dynamic measurement and filter choices are intentionally populated at runtime from the JSON configuration or imported file headers.

The `tools` directory, if present in a source package, contains optional Python source-validation scripts. It is **not required** to build or run the application.

## Building and troubleshooting

1. Open `Wreckfest Physics Debugger.sln` in Visual Studio on Windows.
2. Install the **.NET Framework 4.7.2** targeting/developer pack if Visual Studio requests it.
3. Restore any missing project references, then **Rebuild Solution**.
4. Run the application and confirm that the selected Wreckfest version matches your executable before attaching.

If a WinForms Designer window fails to load, first resolve **Build** errors and rebuild the project, then close and reopen the Designer tab. Live memory reads and runtime-only file/configuration loading should not run inside the Designer.

If attaching or drawing geometry causes an exception, inspect the **exception type, message, and call stack**. An exception shown at `Application.Run(...)` is not necessarily caused by that statement; the failing call may be inside a form update, memory read, or chart renderer.

## Further documentation

- [GAME_CONFIG_GUIDE.md](GAME_CONFIG_GUIDE.md) — memory configuration, versions, and fields.
- [WRECKFEST_AUTO_DETECTION.md](WRECKFEST_AUTO_DETECTION.md) — automatic executable-version detection.
- [SETTINGS_PROFILES_GUIDE.md](SETTINGS_PROFILES_GUIDE.md) — autosaved preferences and named profiles.
- [OFFLINE_CHART_GUIDE.md](OFFLINE_CHART_GUIDE.md) — importing files and chart controls.
- [LAZY_TELEMETRY_GUIDE.md](LAZY_TELEMETRY_GUIDE.md) — telemetry-reading architecture and performance.
- [OPTIMIZATION_REVIEW.md](changelogs/OPTIMIZATION_REVIEW.md) — performance notes and further refactoring opportunities.

## Acknowledgments

- **Cartoons** — help with discovering and confirming the first in-game memory values.
- **N4T4NM** and **iGutobreks** — earlier memory-helper code and usage.
- **Rod Stephens** — the original registry-persistence example used in older versions.

See [TELEMETRY_NAMING_GUIDE.md](TELEMETRY_NAMING_GUIDE.md) for the combined log format and field prefixes.

### Telemetry field names in selectors

Logging and stored file headers always use fully prefixed telemetry names.
Wheel values use `FL_`, `FR_`, `RL_` and `RR_`; shared signals use `ENG_`,
`GBX_`, `DIFF_`, `BODY_`, `ACC_`, `AERO_`, `VEH_`, `ENV_` and `TIME_`.

Live Four Wheels and Offline Chart selectors instead choose a wheel measurement
once (for example `SlipRatio`), and their **dataset layout** determines which
wheels to display and where. Shared signals such as `ENG_RPM` and `TIME_RaceTime`
retain their category prefixes. Older files and saved profiles are mapped to
these selection names without modifying the stored telemetry headers.

## Configurable Live Data monitoring

The Live Data window includes a selectable telemetry monitor driven by the
active game-memory configuration. Expand a category such as Aerodynamics to
choose individual drag and lift measurements, or check the category to show
all its values. Every selected measurement gets one live row. Tire and
suspension measurements share a row with FL/FR/RL/RR columns; global values
are shown once. The visible label, unit abbreviation, and full unit tooltip
come from each JSON field's `displayName`, `unit`, and optional `unitName`.
These presentation labels do not alter prefixed telemetry/logging identities.

Offline Chart's thirteen range filters are available in Chart Settings,
between the Settings action buttons and the other chart options.
