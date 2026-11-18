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
- **Tire Temperatures** — temperature-history charts for all four tires.
- **Offline Four Wheels / CSV Chart** — imported-file plotting without a live game connection.
- **Log Settings** — choose recorded fields, filters, output directory, and logging limits.

The available memory measurements include tire, suspension, body, engine, differential, acceleration, aerodynamics, timing, and other categories defined in the active game-memory JSON. Some additional selections are **calculated telemetry**, derived from raw readings.

### Four Wheels

The live Four Wheels page supports:

- Configurable **X**, **Y**, and **Z/color** measurements.
- **Separate**, **Front/Rear**, **All In One**, and individual-wheel layouts.
- A configurable Z-axis gradient palette, number of color bands, and legend.
- Per-band history limits and current-value markers.
- **13 chart filters:** three that follow the selected X/Y/Z fields, plus ten optional extra telemetry filters.
- Independent filter limits and reset/default controls.
- Separate **Apply Chart Settings** and **Clear Charts and Apply** actions in the settings window. Applying appearance changes does not necessarily discard recorded history.
- Searchable selectors and JSON settings profiles.

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

Open **Log Settings** from Live Data, choose the fields to record, and apply your settings before selecting **Start Logging**.

### Selectable fields

The logging checklist is populated from the **active game-memory JSON** and calculated-telemetry registry, rather than a fixed list of older measurements. It includes fields from tire, suspension, geometry, body, acceleration, engine, differential, aerodynamics, timing, and related groups.

- Field selection is saved **by field name**, not checklist position.
- The initial field selection is a smaller, familiar set; you can enable any additional available fields.
- When names would collide in the output, the logger uses qualified column names to keep them distinct.

### Ten logging filters

Configure up to **10 independent** filters. Each has a telemetry selection, enable checkbox, minimum/maximum bounds, optional absolute-value comparison, and one of two modes:

- **Inside range:** record only values between the inclusive minimum and maximum.
- **Outside range:** record only values below the minimum or above the maximum.

**All enabled filters must pass** for a wheel's row to be written. Wheel-specific fields are evaluated separately for each tire; shared vehicle measurements use the same value for all four. Non-numeric or non-finite filter values do not pass.

### Log files and location

The default destination is:

```text
%APPDATA%\PhysicsDataDebug\Logs\
```

You can choose a different folder in **Log Settings**. Each logging session creates **four new files**, with a shared start timestamp:

```text
FrontLeft_20261117_151725.txt
FrontRight_20261117_151725.txt
RearLeft_20261117_151725.txt
RearRight_20261117_151725.txt
```

The filename format is `<Wheel>_yyyyMMdd_HHmmss.txt`. Existing files are **not** appended to or overwritten; a suffix is added if the chosen timestamp already exists. The default field delimiter is a **semicolon (`;`)**, which can be changed in Log Settings. Data is written as UTF-8 text with a header row.

### Automatic stop conditions

Two optional limits can stop an active logging session:

| Limit | Behavior |
| --- | --- |
| **Time** | Maximum elapsed session time, in seconds. |
| **Total size** | Maximum combined size of all four files, in MiB. |

A value of **0** disables that limit. When both limits are enabled, **the first one reached stops logging** and closes the files. The size limit includes the file headers. Logging settings are captured when the session starts; changes made afterward take effect on the **next** session.

The main Live Data sampling interval is configurable; its default is **50 ms**. This is a requested timer interval, not a guarantee of exact memory-read timing. Actual update timing depends on system and application workload.

The exported files can be opened in compatible spreadsheet and plotting programs. A separate log-file plotting project is available at [Log File Reader and Plotter](https://github.com/6St6Jimmy6/Log-File-Reader-and-Plotter).

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

`WreckfestGameMemoryConfig.json` defines available game versions, memory addresses, offsets, raw telemetry fields, and selected defaults. The built-in configuration is installed into the user Settings folder on first launch. You can maintain additional named JSON configurations and select them using **Config ▼** on Live Data.

Available actions include loading a configuration, saving a copy, reloading the active configuration, selecting the default Wreckfest configuration, and opening the folder.

To edit a configuration, **stop sampling and logging** and close other chart/settings windows before switching it. Be careful when editing memory offsets: an incorrect offset can produce invalid values or make attachment/read operations fail.

See [GAME_CONFIG_GUIDE.md](GAME_CONFIG_GUIDE.md) and [WRECKFEST_AUTO_DETECTION.md](WRECKFEST_AUTO_DETECTION.md) for version profiles and automatic detection details.

## Interface and Designer organization

Most chart settings use a consistent dark theme, searchable ComboBoxes, and grouped layout panels. Font/color selections have shared drawing helpers; color choices are displayed with contrast-aware text so both bright and dark colors remain readable.

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
- [OPTIMIZATION_REVIEW.md](OPTIMIZATION_REVIEW.md) — performance notes and further refactoring opportunities.

## Acknowledgments

- **Cartoons** — help with discovering and confirming the first in-game memory values.
- **N4T4NM** and **iGutobreks** — earlier memory-helper code and usage.
- **Rod Stephens** — the original registry-persistence example used in older versions.
