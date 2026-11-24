# Per-form JSON settings and profiles

Physics Debugger saves UI preferences as editable JSON under your Windows user
profile. Each form has its own autosave and, where the **Profiles** menu is
available, its own folder of named profiles. This is separate from the
Wreckfest memory-offset configuration.

## Automatic settings files

Press **Win + R**, enter the following path and press Enter:

```text
%APPDATA%\PhysicsDataDebug\Settings\
```

Files are created or updated as their corresponding windows are used. Current
examples include:

| File | Contents |
| --- | --- |
| `FormLiveData.json` | Game-version selection, refresh interval, window settings |
| `LiveMonitorSelections.json` | Selected measurements in the JSON-driven Live Data monitor (separate from per-form snapshots) |
| `Form4Wheels.json` | Live chart window settings and captured Settings-owned limiter states |
| `Form4WheelsSettings.json` | X/Y/Z measurements, chart appearance, dataset layout and Settings-owned filters |
| `FormGForceSettings.json` | G-Force axis and appearance options |
| `FormOfflineChart.json` | Offline chart window and captured Settings-owned filter states |
| `FormOfflineChartSettings.json` | Offline axis, dataset layout, appearance, cursor settings and Settings-owned filters |
| `FormLogSettings.json` | Logging-tree field selection, output folder, delimiter, ten filters and time/size limits |
| `FormLiveTimeChart.json` | Up to five plotted measurements, enabled lanes and individual wheel visibility |
| `FormLiveTimeChartSettings.json` | Time window, time units, update interval, colors, grid and per-lane Y ranges |
| `FormSuspensionGeometry.json` | 3D camera azimuth/elevation/zoom, refresh interval, perspective, grid, point names, legend and spindle rotation |

This table lists the relevant current implementations, not a guarantee that
every file exists before its form has been used.

The live and offline filter rows now belong directly to their respective Settings designers. `JsonFormSettings` also captures/restores those rows through the main chart snapshot to preserve existing filter keys and profiles. Normal chart-appearance restoration skips filter controls until the chart restores its filters. No manual relocation of old filter keys is required. Older settings without the new `legendCheckBox` key retain the Suspension Geometry Designer default (checked).

**Game memory:** `WreckfestGameMemoryConfig.json` supplies versions, addresses,
raw/calculated fields and defaults. The active configuration filename is
tracked in `ActiveGameMemoryConfig.json`. Those are not form-profile snapshots.
Use **Config ▼** in Live Data to switch or reload game configurations.

## Saving and loading named profiles

Where a form has a **Profiles ▼** button, the shared `JsonFormSettings.cs` menu
supports:

1. **Save profile as...** — save the current controls as a named JSON file.
2. **Load profile...** — restore a previously saved profile; the restored values
   also become the current autosave.
3. **Restore factory defaults** — load the captured initial settings for that
   form, if its factory snapshot exists.
4. **Restore previous autosave (.bak)** — recover a backup when available.
5. **Reset this form's settings and profiles...** — archive and reset one form's
   settings, then restart.
6. **Reset ALL form settings and profiles...** — archive and reset the per-form
   settings/profiles, preserving game-memory configurations; restart afterwards.
7. **Open settings folder** — open the AppData directory.

**Ctrl + Shift + P** also opens the profile menu on forms where it is attached.
Menus and autosave behavior differ slightly by form; settings dialogs may
apply changes immediately or when you click their Apply button.

Named profiles are stored in folders such as:

```text
%APPDATA%\PhysicsDataDebug\Settings\Profiles\Form4WheelsSettings\
%APPDATA%\PhysicsDataDebug\Settings\Profiles\FormGForceSettings\
%APPDATA%\PhysicsDataDebug\Settings\Profiles\FormLogSettings\
%APPDATA%\PhysicsDataDebug\Settings\Profiles\FormOfflineChartSettings\
%APPDATA%\PhysicsDataDebug\Settings\Profiles\FormLiveTimeChartSettings\
```

The shared code uses a `Profiles\<FormName>` directory for whichever form
opens the menu. **`Factory Defaults.json` is created if missing** for the forms
that initialize factory profiles. Existing baseline files are not replaced
silently when the application is updated; an older factory snapshot can retain
older defaults. To deliberately regenerate one, close the application, back up
that file, and delete only the relevant `Factory Defaults.json` before opening
the form again.

## Editing a settings JSON yourself

Per-form snapshots use a schema independent of game-memory schema 2. A shortened,
illustrative example of the **settings** format is:

```json
{
  "SchemaVersion": 1,
  "FormName": "FormLogSettings",
  "Left": 250,
  "Top": 120,
  "Width": 1200,
  "Height": 720,
  "WindowState": "Normal",
  "Controls": {
    "DelimiterTextBox": ";",
    "logFieldsTreeView.Fields.WF_TireDataOffset.SlipRatio.FL": "true"
  }
}
```

A `Controls` key normally corresponds to a WinForms control name. Boolean
values are stored as the strings `"true"` / `"false"`; number entries normally
use an invariant decimal point. The logging selection tree saves **leaf keys**
by stable source group/member/wheel, not by visible tree position. For example,
`WF_TireDataOffset.SlipRatio.FL` represents the FL Slip Ratio column. Parent
categories and measurement checkboxes are reconstructed from their children.
Older flat `CheckedListBox` selections can still be migrated, but the old
`checkedListBoxLogging` is no longer part of the UI.

For manual edits, close the application first. While it is open, its next Apply
or Close action may overwrite changes to an active autosave. To load a modified
file during a session, use a **named profile** and **Load profile...**. A bad or
obsolete control key will not create a new WinForms control; missing choices
fall back to valid current values where possible.

The logging tree, combined log headers and the Four Wheels/Offline relative
wheel selection names represent different purposes: saved logging leaf keys
identify a specific wheel, while X/Y/Z selector choices such as `SlipRatio`
identify a measurement whose wheel is chosen by the dataset layout.

## Older registry migration

When an autosave does not exist, the code may import settings from older
registry-based versions once. After migration, new preferences are saved in
JSON; the old registry keys are not actively updated. A reset can disable
subsequent legacy registry import without deleting the old registry entries.

For configuration offsets, expressions and `displayName` / `unit` metadata, see
[GAME_CONFIG_GUIDE.md](GAME_CONFIG_GUIDE.md). For file-header prefixes, see
[TELEMETRY_NAMING_GUIDE.md](TELEMETRY_NAMING_GUIDE.md).
