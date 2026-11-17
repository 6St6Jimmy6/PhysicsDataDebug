# WinForms UI layout changes — 2026-11-15

Changes are in the Designer-visible controls and their backing code.

## Form4Wheels
- `mainLayout`: Row 1 = 75 px, Row 2 = 155 px, Row 3 = 155 px (Visual Studio row numbering, starting at 1); plot row remains percentage-sized.
- `actionColumns`: Column 2 = 300 px (the Profiles host column).
- `SettingsProfilesHost` initial size adjusted to 300 × 75, while still docking to its TableLayoutPanel cell.

## FormOfflineChart
- `mainLayout`: Row 2 = 130 px, Row 3 = 130 px.
- `SettingsProfilesHost.Location = new Point(1103, 8)`.

## JsonFormSettings
- For named Profiles hosts and settings sidebars, the button is placed at `(1, 4)` inside its parent.
- Profile button hosting no longer depends on a `Close` button being present.

## Removed Close buttons
- `Form4WheelsSettings`, `FormGForceSettings`, `FormOfflineChartSettings` and `FormTireTemperatures` no longer create standalone Close buttons. Use each window's title-bar **X** instead.
- Form close events and their cleanup logic are preserved.
- The **×** button on pinned data-point popups remains because the popup has no native window title bar.

## Designer customization
- Select `mainLayout` or `actionColumns` in Document Outline and use **Edit Rows and Columns...** for a live Designer preview.
- The application still needs a Windows Visual Studio build and UI check.
