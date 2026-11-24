# G-Force X/Y Arial default selection fix (17 Nov 2026)

> **Historical changelog:** describes an earlier source revision. Some layouts, file names and implementation details have since changed. For current behavior, see the [project README](../README.md) and [current build changes](CURRENT_BUILD_2026-11-24.md).

## Root cause

The X and Y default values were already declared as `new FontFamily("Arial")`, but the fonts are data-bound `FontFamily` instances. Setting `ComboBox.SelectedItem` to a separately instantiated FontFamily object was not reliable; the list could keep its first installed font (such as Agency FB). The original `CheckedChanged` handlers also changed only static flags, not the visible font selection. Old autosave/factory profile values could then restore an unintended font while the Defaults checkbox remained checked.

## Changes

- `ChartSettingsUi.ConfigureFontFamilies` displays the `FontFamily.Name` property.
- `ChartSettingsUi.SelectFontFamily` chooses the installed list entry by name, not by object instance.
- Both X/Y font lists in `FormGForceSettings` use the new selector for default and saved model values.
- `ApplyControlsToModel` and the Form Load path normalize the displayed X/Y fonts to Arial **only when the corresponding Defaults checkbox is enabled**. This also handles previously saved Agency FB values in profiles marked Defaults=true.
- Checking/unchecking any of the G-Force Defaults checkboxes immediately reloads the corresponding displayed settings, rather than changing a flag only.
- Initialization excludes runtime bindings and profile setup in Visual Studio Designer mode, preserving the designer-owned grouped layout.
- `FormGForce.Designer.cs` now starts with Arial font definitions for chart labels and titles; runtime `SetPolarChart` continues to read the model values.
- Shared owner-drawn font, style and size entries now use foreground colors rather than hardcoded black text on dark backgrounds.
- The identical object-selection weakness in `Form4WheelsSettings` font initialization is fixed using the shared name-based selector.

## Preserving user choices

If the X/Y Defaults checkbox is **unchecked**, any explicitly saved font is preserved. A persisted Agency FB font with Defaults unchecked remains a custom setting; check Defaults and Apply to return to Arial. Existing JSON/settings files are not deleted or overwritten automatically during migration.

## Verification

Static source validators passed, including `tools/validate_gforce_arial_defaults.py` and existing four-wheel designer checks. The auto-detection validator needs local Wreckfest executables and could not run fully here. A native Windows Forms compile and on-screen designer test are unavailable in the Linux container.
