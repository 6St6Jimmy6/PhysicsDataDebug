# Form-settings recovery and Offline Chart isolation

> **Historical changelog:** describes an earlier source revision. Some layouts, file names and implementation details have since changed. For current behavior, see the [project README](../README.md) and [current build changes](CURRENT_BUILD_2026-11-24.md).

## What changed

- `FormOfflineChartSettings.ApplySavedSettings()` is now read-only. During CSV import it can use persisted chart settings, but it **must not** write `FormOfflineChartSettings.json` with fallback axis selections from a different CSV.
- If an imported CSV and a saved chart profile have incompatible values, silent startup restoration logs the issue to Visual Studio Debug Output instead of creating a modal `MessageBox` owned by a hidden settings window. Such a hidden dialog could make the visible chart appear frozen, including its buttons.
- Closing `FormOfflineChart` without importing a file no longer overwrites filter autosaves with empty/default column choices.
- Autosaving JSON now writes a `.bak` copy of the previous autosave, where supported by `File.Replace`.
- The shared **Profiles** menu now contains:
  - **Restore previous autosave (.bak)**
  - **Reset this form's settings and profiles...**
  - **Reset ALL form settings and profiles...**

## Recommended reset for an affected installation

1. Close your extra chart windows, but leave the main Live Data window open.
2. In Live Data, click **Profiles** and choose **Reset ALL form settings and profiles...**.
3. Accept the confirmation, **close the entire application**, then launch it again.
4. The form factory defaults will be regenerated at startup/opening. You can then create new named profiles.

If a window is blocked by a hidden modal dialogue and you cannot reach the menu, end the program, navigate to `%APPDATA%\PhysicsDataDebug\Settings\`, and **back up** the affected `Form*.json` files and the `Profiles` directory before moving them out of the Settings directory. On the next launch, the application will create new profiles. Use the in-app reset when possible; it also leaves a marker preventing old registry settings from being imported again.

Reset archives are stored under:

`%APPDATA%\PhysicsDataDebug\Settings\ResetBackups\<UTC timestamp>\`

The reset deliberately **does not affect game memory configurations** such as `WreckfestGameMemoryConfig.json`, or `ActiveGameMemoryConfig.json`.

## Important distinction

A ZIP download of the source project is **not a settings reset**. The saved JSON settings live in AppData and survive replacing the executable or source folder. The recovery feature is intended to remove the need for extracting a fresh ZIP each time a saved profile is damaged.

## Testing

- Start the application, import a CSV, select unusual X/Y/Z fields, colors and chart types, apply and close.
- Import a different CSV with different headers; ensure its chart works and the original `FormOfflineChartSettings.json` is **not silently changed by import**.
- Open and close Form4Wheels, then return to the Offline Chart; buttons should still respond and the saved offline palette should be independent.
- Try a broken/incompatible saved chart setting: the importing window should **not** be blocked by a MessageBox owned by an invisible form.
- Use the Profiles menu to reset a single form, close the app and reopen; old autosaves should not reappear.
- Use the Profiles menu to reset all forms, close and reopen; `WreckfestGameMemoryConfig.json` should remain untouched, and new factory profiles should be created.
- After changing a chart setting twice, check the `.json.bak` file and try Restore previous autosave.

**Not runtime-tested on Windows.** Source validation and project checks are not a substitute for a WinForms run.
