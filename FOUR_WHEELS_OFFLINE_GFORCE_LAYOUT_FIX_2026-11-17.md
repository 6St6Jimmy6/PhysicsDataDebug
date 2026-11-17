# Live/Offline/G-Force layout corrections (2026-11-17)

- Form4Wheels: action buttons now auto-size to text with explicit minimum widths and padding. Existing no-wrap scrolling toolbar and right-hand Profiles host remain.
- FormOfflineChart: designer-owned `toolbarLayout` (2 columns x 2 rows) with `toolbarButtonsFlow` and a dedicated right-hand `SettingsProfilesHost`; file list spans the entire second row. No obsolete manual toolbar resize handler. Profiles remain visible while the left action row scrolls if necessary.
- FormOfflineChart: GroupBox backgrounds explicitly black.
- ChartLimiterRow (shared by Form4Wheels and FormOfflineChart): ComboBox and numeric filter textboxes now use dark input backgrounds and white text at design and run time.
- FormOfflineChart: validation resets numeric filter fields to dark, not SystemColors.Window; invalid values highlight dark red with white text.
- FormGForce: fixed right-side G-force chart set to 72 px wide, 40% narrower than the 120 px default Form4Wheels legend; main polar chart expands with the window.

Changes are in the designer-owned files wherever possible so they show in Visual Studio Designer. Full Windows/WinForms runtime and Designer rendering could not be performed in this environment.
