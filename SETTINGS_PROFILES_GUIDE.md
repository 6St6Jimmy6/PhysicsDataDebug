# Per-form JSON settings and profiles

The application saves its current UI preferences as readable JSON files in your
Windows user profile. Settings automatically load again the next time you open
the app. **You do not need to press Apply first after restarting**: the
four-wheel, G-force, and logging models restore their settings at startup.

## Automatic settings files

Press **Win + R**, paste the following, and press Enter:

```
%APPDATA%\PhysicsDataDebug\Settings
```

You will see individual files after the corresponding form has saved settings:

| File | Saved preferences |
| --- | --- |
| `FormLiveData.json` | Selected game version, logging interval, window bounds |
| `Form4Wheels.json` | Wheel chart axis-limit selections and controls |
| `Form4WheelsSettings.json` | Wheel chart styling, axis choices, palettes, history, gradient bands |
| `FormGForceSettings.json` | G-force chart styling, colors, history and axis options |
| `FormLogSettings.json` | Log fields, delimiter, filters and numeric inputs |

Current settings are automatically saved by the forms' existing Apply and
Close actions. The main window also saves when you exit the program. Each
form saves to its **own file**, so changes to another form cannot overwrite it.

The `WreckfestGameMemoryConfig.json` file is also placed in this Settings
folder on first launch. It defines game versions, offsets, memory fields,
and defaults. It is a **game-memory config**, not a per-form UI profile.
Switch between game configs from **Config ▼** on the Live Data page.

## Saving and loading named profiles

Every relevant form has a **Profiles ▼** button, with these commands:

1. **Save profile as...** — saves a snapshot of that form's current controls
   to a `.json` file with a name of your choice, e.g. `Drifting.json`.
2. **Load profile...** — restores the controls from an existing JSON profile,
   updates the chart or logging model, and makes those values the current
   automatic settings. Future startups use the loaded values.
3. **Restore factory defaults** — loads that form's original settings captured
   before your saved preferences were applied. This also updates the active
   autosave, so the defaults remain selected after restarting.
4. **Open settings folder** — opens the location of your automatic JSON files.

You can also press **Ctrl + Shift + P** in any of these forms to open the same
profile menu (handy on large charts where the button may be off-screen).

The default named-profile folders are:

```
%APPDATA%\PhysicsDataDebug\Settings\Profiles\Form4Wheels
%APPDATA%\PhysicsDataDebug\Settings\Profiles\Form4WheelsSettings
%APPDATA%\PhysicsDataDebug\Settings\Profiles\FormGForceSettings
%APPDATA%\PhysicsDataDebug\Settings\Profiles\FormLogSettings
%APPDATA%\PhysicsDataDebug\Settings\Profiles\FormLiveData
```

You can back up, copy, rename, and edit profile files with a text editor. The
profile chooser also lets you navigate to a file elsewhere on your computer.
Profiles are **per form** to prevent unrelated wheel/chart/logging preferences
from being mixed together.

On the first startup, the app also creates a **`Factory Defaults.json`** file
in each of the five folders above. Unlike a partial template, it captures all
the initialized controls, including the current defaults configured in
the selected game-memory JSON file. These baseline files are generated **before** saved
user preferences are restored. The app never overwrites existing baseline
files, so your original defaults remain available. To generate a fresh
baseline after intentionally changing the program's defaults, close the app,
delete just the corresponding `Factory Defaults.json`, and launch it again.

## Editing JSON yourself

Settings are plain UTF-8 JSON with indented values. A shortened example:

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
    "checkBoxFiltersOn": "false",
    "checkedListBoxLogging.Items.SlipRatio": "true"
  }
}
```

The `Controls` keys are the WinForms control names. Checkbox values are the
strings `"true"` or `"false"`; numeric values are strings using a dot as the
decimal separator. For logging field checkboxes, the key contains the field
**name**, so reordering configured fields won't change which ones are enabled.
The exact field names in your own JSON may differ from this example.

You can edit a JSON file while the application is closed and its changes will
load on the next start. For changes while the app is open, edit a **named
profile** and use **Load profile...**; the active autosave can be overwritten
when the form is next applied or closed.

If a saved control name or dropdown item no longer exists, the application
keeps its current valid/default value. If JSON is malformed or belongs to a
different form, a warning is shown instead of applying the file.

## Old registry migration

When an automatic JSON file does not yet exist, the app tries to read that
form's settings from its old Windows registry location and writes an initial
JSON file. This is a **read-only, one-time import**. New preferences are saved
only to JSON; the previous registry settings are not deleted.

To restore a named profile later, use **Profiles ▼ → Load profile...** rather
than deleting the current autosave.
