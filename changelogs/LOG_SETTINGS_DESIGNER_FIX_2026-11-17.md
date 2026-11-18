# FormLogSettings WinForms Designer fix

## Root cause
Visual Studio could not load the project-specific `Physics_Data_Debug.LogFilterRow` for the ten filter rows.
When that type could not resolve from the design-time assembly, the form Designer also marked all ten dependent fields as unassigned.

## Changes
- Removed the custom `LogFilterRow` UserControl from `FormLogSettings.Designer.cs` and the project.
- Replaced all ten rows with ordinary, Designer-owned `TableLayoutPanel`, `Label`, `CheckBox`, `ComboBox`, and `TextBox` controls.
- Kept each named, grouped row (`logFilter01` ... `logFilter10`) and every inner control editable in Visual Studio's Document Outline.
- Moved only data initialization, JSON field search, parsing, inside/outside logic, and validation to `LogFilterBinding.cs`; **no custom control has to load in the WinForms Designer**.
- Preserved the previous JSON autosave keys (`LogFilter01Enabled`, `LogFilter01Field`, etc.) and selected field names.

## Visual Studio
Close the broken Designer tab, reopen the solution, select **Build > Rebuild Solution** and then open `FormLogSettings.cs` > **View Designer**. If Visual Studio still displays the old cached missing-type diagnostics, close Visual Studio and clear its `.vs` cache before reopening.

No filter behavior or telemetry log format was intentionally changed. This project was checked with source-level tests, not compiled or launched in Windows.
