# Game Version selector layout fix (2026-11-15)

> **Historical changelog:** describes an earlier source revision. Some layouts, file names and implementation details have since changed. For current behavior, see the [project README](../README.md) and [current build changes](CURRENT_BUILD_2026-11-24.md).

- FormLiveData Designer now owns a `gameVersionFieldsLayout` TableLayoutPanel
  inside `gameVersionSection`. Columns: remaining width + fixed 94-pixel
  Config column. Rows: version/config, Profiles, detection status.
- Initial sidebar width increased from 250px to 370px.
- Sidebar minimum increased to 310px, game section height to 214px.
- Removed the runtime `GameVersionComboBox.Width -= 80` adjustment, which
  made the selector too narrow to show the selected version.
- The redundant old Select Game Version label is not inserted into the group.

## Designer customization
Open `FormLiveData` in Windows Forms Designer, then Document Outline:
`telemetrySidebarSplitter` (set SplitterDistance), and
`gameVersionSection` > `gameVersionFieldsLayout` (Edit Rows and Columns).
Increase the GroupBox height if you enlarge the row sizes. The section is
shown live in the Designer without running the application.

## Validation
Static source checks and ZIP integrity passed. A Windows Forms build and
visual resize check still need to be run in Visual Studio.
