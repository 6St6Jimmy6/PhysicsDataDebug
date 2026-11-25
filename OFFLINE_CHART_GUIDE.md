# Offline Four Wheels / CSV chart

## Opening and importing

1. Open Live Data and click **Offline Chart** in the navigation bar.
2. Click **Load CSV / TXT...** and select one or more exported telemetry files.
3. Check/uncheck file names to overlay or hide them; select one and use **Remove selected** to unload it.
4. Click **Chart settings**, choose X, Y, Z measurements (wheel measurements have no `FL_`/`FR_`/`RL_`/`RR_` prefix), choose a dataset layout, and click **Apply Settings**. The thirteen filters and their **Apply Filters** action are in this settings window.
5. The plot rebuilds from the *original imported rows* whenever an axis, color, chart type, limiter or file visibility is changed.

The importer automatically detects `;`, comma, tab, and `|` separators, handles
quoted cells, UTF-8 BOM and a trailing delimiter, and accepts both `1,23` and
`1.23` numeric decimal notation. It supports `.csv`, `.txt`, `.tsv`, `.log` and
other delimited files through the **All files** filter. The first nonempty
record must contain column headers; headers need *not* match any game-memory
JSON names. Original files are not modified; legacy wheel headers are normalized in memory, and repeated headers are
uniquely suffixed with `(2)`, `(3)`, etc. Non-numeric cells are considered
missing data. A file whose selected X/Y/Z or enabled filter header is absent
is not plotted, but remains loaded.

## Layout and filters

- `FormOfflineChart.Designer.cs` owns the file list, chart and legend. Its
  filter controls have been removed from that Designer.
- `FormOfflineChartSettings.Designer.cs` directly owns the three axis rows and
  ten additional rows in its filter section, below the action bar. Each row is
  a reusable `ChartLimiterRow`, whose internal layout is editable in
  `ChartLimiterRow.Designer.cs`. The Settings instance is retained for the
  lifetime of the chart; no runtime reparenting or parking is needed.
- The three fixed filters always follow the chosen axes. Each of the 13 filters
  has its own enabled checkbox, Min, Max and Defaults action.
- **Apply Filters**, in the Settings window, redraws without dropping rows
  from the imported datasets.
  Empty bounds mean unlimited; invalid enabled bounds are highlighted.
- Defaults uses the actual imported range, falling back to the JSON axis
  defaults where appropriate. Filter fields marked as absolute in the current
  game configuration are filtered by their absolute value, like Four Wheels.
- **Dataset layout** determines which wheel channels appear, not the X/Y/Z
  measurement selectors. **All In One** overlays all four, **Separate** creates
  one chart area per wheel, **Front/Rear** and **Left/Right** group wheels,
  and axle-only, side-only, or individual-wheel layouts hide unwanted wheels.
  Multiple imported files for the same wheel can overlay in one chart area.
  The legend identifies the file and wheel; global-only data is plotted once.
- For line charts, a filtered-out sample and a color-band transition introduce
  breaks rather than connecting unrelated portions of the data.

## Chart settings

`FormOfflineChartSettings.Designer.cs` has four named Designer sections:
**Chart and data**, **X axis**, **Y axis**, **Z / color axis**. These include
configurable chart type, marker style/size, background, palette, gradient bands,
absolute values, axis selection, scaling, label font/colors, major/minor grid
styles, and logarithmic axes. The Settings window has **Apply Settings** for
chart options and **Apply Filters** to redraw using the current filter values.
There is no live-history limit or separate Clear/Apply control.

`GradientPalette.cs` provides the same 24 named gradient schemes as live Four
Wheels (including reversed variants). The Z legend represents the selected Z column; axes and filters are
mapped from headers, not from compiled Wreckfest enums.

## Saving settings

The existing `JsonFormSettings` utility saves these two Forms separately:

- `%APPDATA%\PhysicsDataDebug\Settings\FormOfflineChart.json`
- `%APPDATA%\PhysicsDataDebug\Settings\FormOfflineChartSettings.json`

The main chart snapshot captures the Settings-owned filter controls using their existing control-name keys. The Settings snapshot also captures its own controls. During normal restoration of chart appearance, filter values are restored separately from the main chart snapshot once imported headers are available. The **Profiles** menu on either form can save, load or restore factory settings.
Chart settings are reapplied after the first file import on a later launch, so
you do not need to open the settings dialog merely to restore the previous
column choices. The data files themselves are *not* serialized into JSON; use
Load CSV/TXT to import them in a new session.

## Validation checklist

- Load an older `FrontLeftWreckfestDebugLog.txt` with `;` separators and decimal commas;
  select `SlipAngleDeg`, `LateralFriction`, and `CamberAngleDeg` after import.
- Load a second file, verify All In One vs Separate, and uncheck each file.
- Change each of X, Y, and Z, chart type and palette, then Apply Settings.
- Enable an extra `VerticalLoad` filter and tighten Min/Max; verify the visible
  count drops, then disable the filter and verify the points return.
- Set a custom X/Y range, test Z color limits, and save/reload a JSON profile.
- Reopen the app, load a log, verify last saved axes, palette and filters apply.
- Inspect both axes with contrasting grid colors and minor grids enabled: exterior tick marks should be absent and the axis lines should match their parallel major grids.

This is a WinForms/.NET Framework 4.7.2 application. Build and interactive
visual testing must be completed in Visual Studio on Windows.

## Inspecting XYZ points

Open **Chart Settings → Chart and data settings** to control point inspection:

- **Show XYZ point tooltips** enables point inspection (on by default).
- **Point hover delay (milliseconds)** defaults to `1000` in `OfflineChartOptions.cs`. Values from 0 through 10,000 ms are allowed; 0 is effectively immediate. Previously saved profiles can override the default.

For chart types where Windows Forms Chart can hit-test a rendered data point, keep the mouse over that point until the hover delay expires. A transient tooltip shows the imported file name and **X, Y, Z** values after all display transformations (such as Absolute). **Left-click a point** to pin a tooltip on the chart, then click **×** to dismiss it. Clicking another point replaces the pinned point. Pinning does not affect the underlying file data or filters.

When a dataset, filter, selected column, axis or chart type is changed and the chart is redrawn, the pinned popup closes automatically because the old series/data-point objects were replaced. Data points with missing/invalid measurements are not inspectable. Lines without visible markers, or very dense FastLine/FastPoint rendering, may not be individually hit-testable; for the most reliable inspection choose **Point** with visible markers. Point inspection is implemented in reusable `ChartPointInspector.cs`.

## Chart types, grid styling and cursor options

- All 35 `SeriesChartType` enum choices appear in the chart type dropdown. Most
  single-Y chart types can render from X/Y/Z data. Bubble size uses `abs(Z)`.
  Stock, Candlestick, Range, financial charts, and BoxPlot/ErrorBar require
  multiple Y fields and currently give a validation message instead of crashing.
- Color scheme and gradient bands live under **Z / color axis**. The old
  `Default` scheme is shown as **Blue Red**; old saved profiles still work.
  All additional gradient schemes include a reversed option.
- X and Y major/minor grid settings now each have independent dash style and
  alpha. Exterior major/minor tick marks are disabled. The horizontal X axis
  inherits the Y major grid style and the vertical Y axis inherits the X major
  grid style (color including alpha, width and dash). The defaults are Solid
  major and Dash minor. The same shared styling is used in live Four Wheels.
- Shared cursor controls under **Chart and data settings** adjust enabled,
  zoomable, line color, alpha, width, and dash. Drag mostly left/right to zoom X,
  mostly up/down to zoom Y. Applying settings redraws and resets the current zoom.
- Each axis section starts with Restore Defaults. Blank minimum/maximum boxes
  are filled with a range computed from imported data (or the game's default
  range where available). Auto-scale stays enabled if the checkbox is checked.
- Numeric input mouse wheel changes are blocked throughout the application.
  Keyboard up/down arrows and direct typing still work.
- X/Y grid widths, minor widths, cursor width, and axis font sizes accept 0.25
  increments with a 0.25 minimum. WinForms Chart itself renders line widths in
  **integer pixels**, so quarter-pixel widths are preserved in JSON but rounded
  to at least 1 px for drawing. Font sizes use true fractional point sizes.
- The available font families come from Windows installed fonts. Each font name
  is drawn using that installed font in the open dropdown.
- If you already have an older `FormOfflineChartSettings.json`, the old saved
  values take precedence until you restore factory defaults or change them.
  `Factory Defaults.json` snapshots are only generated once by the app; delete
  the corresponding existing factory snapshot to regenerate with the new defaults.

## Combined telemetry files (current logger)

The live logger creates one synchronized `Telemetry_yyyyMMdd_HHmmss.txt` file.
Import it normally using **Load CSV / TXT**. Wheel measurements become available
in X/Y/Z and filter selectors once as `SlipAngleDeg`, `LateralFriction`,
`VerticalLoad`, etc. Global fields such as `TIME_RaceTime` retain their prefix.

To choose FL, FR, RL, or RR, change **Dataset layout**; do not choose a separate
prefixed field. The combined file still contains four physically distinct
prefixed sets of columns. Older files with unprefixed headers are accepted
and normalized in memory during import; the original files remain unchanged.

See [TELEMETRY_NAMING_GUIDE.md](TELEMETRY_NAMING_GUIDE.md).

## Optional 3D scatter view (XYZ)

Under **Z / color axis**, enable **3D point chart (XYZ)**, then Apply Settings. The selected X, Y and Z columns are actual numerical coordinates in the 3D projection. The 2D chart type selector is disabled in this mode; the regular WinForms series-depth visualization is not used. The color gradient is still based on Z unless **Use fourth field for color** is enabled. Select any available fourth column in the additional dropdown. The existing Z/color range, scheme, bands and alpha apply to the chosen color field. Z remains a geometric coordinate and uses the filtered data's range; use the Z limiter to restrict geometric depth. Both modes retain the original CSV rows.

The 3D view honors the existing wheel layouts, filters, X/Y ranges, absolute values and logarithmic X/Y scaling. Left-drag orbits, right/middle-drag pans, mouse wheel zooms and double-click resets the view. Hover uses the configured tooltip delay and reports the file, XYZ and optional fourth color value. Pinning tooltips and WinForms cursor rectangle zoom are 2D-only. The 3D view uses a simple normalized axis grid and supports circle, square, diamond, triangle and cross markers; other marker shapes use square points. Very large datasets can still render slowly; no GPU acceleration is required or used.

Fresh chart settings use **FastPoint** in 2D and **Arial** for X/Y fonts. Enabled minor grids use five subdivisions of each major interval, including automatically calculated major intervals. The Apply Settings and Apply Filters Designer click handlers are connected again.
