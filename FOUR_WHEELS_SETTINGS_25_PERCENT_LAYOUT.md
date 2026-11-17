# Four Wheels settings: equal columns and responsive rows

The Visual Studio WinForms Designer owns the layout. In `Form4WheelsSettings.Designer.cs`:

- `settingsSectionsLayout` has **four Percent columns of 25% each**. Select the table in the Designer and choose **Edit Rows and Columns…** to change them. There is no second assignment later in `InitializeComponent`.
- The 65 setting rows are regular Designer `Panel` controls docked `Top` within their own scrolling sections.
- Their captions dock **Top** and inputs dock **Bottom** (checkbox-only rows use **Fill**), inside 12 px horizontal padding. This keeps ComboBox arrows and NumericUpDown spinner buttons inside the available width, including when a vertical scrollbar appears. None uses a fixed width or a right-side anchor.
- The multiline **Absolute values** checkbox has a taller row so its full text can be displayed.
- `settingsActionsPanel` is a Designer-owned `FlowLayoutPanel` docked at the top, 88 px tall. Buttons have larger minimum widths and `AutoSize`, so labels fit. It scrolls horizontally if the window is too narrow. The existing Profiles button fills its Designer host.

### Test in Visual Studio

1. Open `Form4WheelsSettings.cs [Design]`, select `settingsSectionsLayout`, verify 25% in each column.
2. Resize the form to normal width and minimum width, then check X/Y/Z dropdown arrows and NumericUpDown spinner buttons remain accessible.
3. Scroll each section downward and check no horizontal scrollbar is needed merely to show a dropdown arrow.
4. Verify Apply Chart Settings, Clear Charts and Apply, Reload Values, and Profiles show their full text and respond to clicks.
5. Save and load a settings JSON profile to confirm existing control names were retained.

These changes have source validations only: a Windows WinForms run and live Designer check have not been performed in this environment.
