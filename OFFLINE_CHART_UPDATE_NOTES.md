# Offline chart settings update — 2026-11-12

The work is based on PhysicsDataDebug_OfflineSettings_NumericDefaultsFix_2026-11-12.zip.

## Offline chart options
- Chart type dropdown lists the complete .NET Framework SeriesChartType enum (35 types). The importer has one selectable Y column and one Z/color column. Types needing several independent Y fields (e.g. Stock, Candlestick, BoxPlot, Range and specialized financial charts) now show a specific validation message instead of an unhandled exception. Bubble size uses |Z|, and circular charts color individual points by Z.
- All palette names are from GradientPalette.AvailableSchemes. The old "Default" name is now "Blue Red" in the UI; "Default" remains supported for older profiles. Additional ordered schemes are provided in both directions.
- Color scheme and band count are in the Z group, not in Chart/Data.
- Empty X/Y/Z manual minimum and maximum fields fill from the imported data range, or configured game defaults. Auto checkbox remains authoritative for whether manual bounds are used.
- Axis restore-defaults buttons are the first control in each axis panel.
- Major and minor grids have independent dash styles and opacity (0–255). Matching tick marks follow the same grid styling. Minor dash defaults to Dash; major to Solid.
- The Chart/Data group now exposes shared cursor enable, drag zoom, color, alpha, width, and dash style controls. A predominantly horizontal drag zooms X; vertical drag zooms Y.
- NumericUpDown mouse-wheel changes are blocked globally; keyboard/direct entry works.
- Axis font families come from installed Windows fonts. Dropdown items are owner-drawn in their own typefaces.
- Marker/opacity/color, chart background, tooltip, and file-loading behavior otherwise remain unchanged.
- New default point-hover delay = 1000 ms.
- Numeric widths/font sizes allow 0.25 increments and minima. Font sizes render fractionally; the WinForms chart APIs take only integer pixel widths, so widths are rounded up to at least 1px when drawing. Input precision and saved JSON precision are retained.

## Backward compatibility
Existing `%APPDATA%/PhysicsDataDebug/Settings/FormOfflineChartSettings.json` and previously generated Factory Defaults profiles continue to take priority over code defaults. If old numeric values (e.g. 9) persist from the earlier settings bug, restore valid settings or back up and delete that file; delete `Factory Defaults.json` to regenerate the new baseline.

## Validation limitations
The Linux workspace lacks the .NET Framework 4.7.2 Windows Forms build/runtime. Project references, Designer declarations, symbolic field config, and ZIP integrity were checked. Please compile and visually test the settings form and cursor zoom in Visual Studio on Windows.
