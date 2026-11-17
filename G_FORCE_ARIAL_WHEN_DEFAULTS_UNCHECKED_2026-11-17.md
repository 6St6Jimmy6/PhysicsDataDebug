# G-Force startup font selection with Defaults unchecked

- Both G-Force font ComboBoxes now explicitly select Arial immediately after binding the installed-font list; the list's first item is never used as an implicit default.
- The initial custom (Defaults unchecked) model font is still Arial, independently of each Defaults checkbox.
- Older autosaves and older factory profiles might contain `Agency FB` because it was selected automatically from the bound font list. On load, unversioned legacy snapshots containing that value for either G-Force axis are corrected to Arial, including when Defaults is unchecked. Other saved font values remain unchanged.
- Future G-Force autosaves and profiles store an internal font-selection version marker. This allows users to deliberately select and save Agency FB after the fix, without the migration changing their choice.
- Existing control names and Designer arrangement were not changed. The two charts still read their font settings from the FormGForceSettings model.

## Validation

Run `python tools/validate_gforce_font_initialization.py`. Other source-level validation scripts are unchanged. Visual Studio/WinForms runtime compilation and UI behavior must be checked on Windows.
