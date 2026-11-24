# Four-wheel plotting refactor

> **Historical changelog:** describes an earlier source revision. Some layouts, file names and implementation details have since changed. For current behavior, see the [project README](../README.md) and [current build changes](CURRENT_BUILD_2026-11-24.md).

The initial update refactored the **4 Wheels** plotting and color-gradient
subsystem. Later work also covers the game-memory reader and G-force charts.

## LiveData and logging refactor

- `LiveData.GetFullListDataValue` caches `DataItem` references by name, so
  labels, G-force plots and the logger no longer scan each entire data list
  for every measurement. The cache refreshes if a list's identity, length or
  first item changes.
- `LiveData.InitializeDataLists` and `RefreshTelemetry` centralize the
  six-prefix initialization and read/update order. `FormLiveData` invokes
  these methods rather than repeating the long list of chunk arguments.
- `LiveData` now appends calculated bytes with `AddRange`, reuses empty offset
  arrays, makes one rotation-angle calculation per tick, and simplifies
  executable byte reading and pattern matching.
- `FormLiveData` binds its four wheels' 120 tire labels once from one ordered
  list of 30 label definitions. The per-tick update loops through the cached
  bindings. It also simplifies window button visibility, corrects the right
  differential readouts and honors display prefixes/suffixes.
- `LogData.cs` defines the ordered log columns in one place, and
  `LogSettings.cs` stores 29 field-selection flags instead of 29 separate
  booleans and more than a hundred temporary Header/Parameter strings.
- `DataLogger.cs` exports only checked fields, writes a header **and** the
  first data row immediately, applies the configured filters, and uses the
  correct wheel for suspension length/velocity. The four checkbox labels for
  G-forces now actually export XG, ZG, YG, and total XYZG respectively.
- Existing default column ordering (including the second brake-torque column),
  delimiter, and wheel file names are preserved. If selected fields or the
  delimiter change while a filename already exists, the logger chooses a
  numbered sibling file rather than append incompatible rows.
- The logging Form now restores its saved checkbox settings at startup,
  including the case where **Select All** is unchecked. The main app applies
  saved logging choices before allowing logging to start; W1/W2 center values
  and the tolerances are parsed and persisted with the Form.

### Suggested Windows logging tests

1. Start logging with all columns checked and filters off. Verify that each
   wheel's file contains the header plus its first data row (30 columns).
2. Uncheck one item, e.g. `Angular Velocity`, and select Apply. Verify the
   exported header and rows omit that field for all four wheels. The brake
   torque item intentionally controls two columns.
3. Change the selected fields while logging, or change the delimiter. Verify
   the old file is preserved and a numbered file with its own matching header
   receives subsequent rows.
4. Enable filters and choose speed exclusion and slip/load limits. Verify
   samples failing the criteria are not written, and those passing are.
5. Close and reopen the app with some items unchecked, then press Start Logging
   without opening Log Settings. Verify the saved field choices and filter
   values still apply.
6. While connected, enable the live-data display and verify all four wheels'
   tire labels and the right differential values change independently.

## JSON configuration and G-force update (latest)

### Consolidated Form organization

The former `4Wheels.cs` and `GForce.cs` plotting code lives directly in
`Form4Wheels.cs` and `FormGForce.cs` respectively. The state previously in
`4WheelsSettings.cs` and `GForceSettings.cs` is now in
`Form4WheelsSettings.cs` and `FormGForceSettings.cs`. The separate source
files have been removed from the Visual Studio project. External callers use
`Form4Wheels.*`, `FormGForce.*`, `Form4WheelsSettings.*`, and
`FormGForceSettings.*`; methods within their own Forms access the static
members without an unnecessary class qualifier. Designer files and UI
registry paths remain unchanged.

Follow-up correction: `FormLiveData.cs` and `FormLiveData.Designer.cs` now
consistently use the original `CurrentGForce` label field. A broad rename
accidentally changed some references to nonexistent `CurrentFormGForce`.

- `WreckfestGameMemoryConfig.json` contains the original 39 enum groups / 631 values,
  two game-version profiles, the wheel-axis defaults dictionary, and the
  absolute-value field list. Addresses, chunk sizes and side offsets used by
  `LiveData` are resolved from the selected version's JSON lookup.
- `FormLiveData` lists versions from JSON rather than the compiled
  `BaseAddressUpdate` enum and preserves the selected version ID in settings.
- JSON can introduce new *raw* field names inside the existing telemetry
  memory chunks. These are appended to the corresponding data lists; extra
  tire fields also appear as selectable wheel chart axes.
- Calculated telemetry values retain their stable computed order even if a
  game's raw chunk size changes. Likewise, internal compiled enum IDs remain
  stable and do not change when physical offsets are overridden.
- `FormGForce.cs` uses the shared `GradientPalette` and directly appends/removes
  chart points. It replaces unbounded creation of `Series2`, `Series3`, ...
  with one `SeriesHistory` and optionally caps old points through JSON.
- Applying G-force styling recolors existing history instead of discarding it.
- See `GAME_CONFIG_GUIDE.md` for examples and limitations.

## What's changed

- `Form4Wheels.cs`: no longer has 4 × 10 hard-coded X/Y/Z gradient list groups
  or 20+ parameter `ListSeries` calls.
- `WheelPlotHistory.cs`: stores X/Y/Z history as bounded FIFO queues, one
  per gradient band, per wheel. Each new sample appends directly to the
  relevant chart series using `Points.AddXY` and updates the current-value
  series. Rebuilding a chart also uses `AddXY` rather than deferred LINQ
  enumeration through `DataBindXY`, which previously threw a
  `NotImplementedException` when connecting to Wreckfest.
- `GradientPalette.cs`: centralizes the original color palettes, suffixes,
  and Z-band selection; interpolates the ten reference colors when using a
  different band count.
- `Form4Wheels.cs`: creates history series in a loop and uses the same
  palette for the vertical legend.
- `Form4WheelsSettings.cs`: adds a **Gradient color bands** numeric setting,
  from 1 to 64, underneath the wheel layout selection. Existing registry
  settings saving and loading handles this control.
- `Form4WheelsSettings.cs`: the default band count is set in one place:
  `DefaultGradientSteps = 10`, and the permitted range is configured by
  `MinimumGradientSteps` and `MaximumGradientSteps`.

## Further four-wheel optimizations

- `Form4WheelsSettings.cs` now shares one Apply pathway between the normal
  and Clear buttons. It pauses the chart timer during configuration changes
  and restores the timer's previous enabled state. The X, Y, Z, and general
  settings each have a single parsing routine.
- Repetitive ComboBox DrawItem handlers now delegate to shared owner-drawing
  helpers. Temporary fonts and brushes are disposed, and the dropdowns handle
  unselected items without indexing errors.
- `Form4Wheels.cs` gets axis defaults and palette colors once per rebuild;
  shared ChartAreas are created/configured just once. It no longer performs
  repeated limiter UI updates or unnecessary layout-label assignments on
  each 50 ms timer tick.
- `Form4Wheels.cs` samples all four wheels through a common wheel method and
  caches the prefix enum order to avoid repeated array allocations.
- The string-based axis defaults API delegates to the enum-based defaults
  lookup, keeping one mapping to maintain.

## Shared four-wheel and G-force settings cleanup

- `ChartSettingsUi.cs` now owns the common font/color/scheme item drawing,
  numeric and enum dropdown population, and setup for owner-drawn controls.
  Each Form still keeps its existing Designer event-handler names, but the
  rendering behavior is implemented only once.
- Removed duplicate `DrawItem` event subscriptions from both settings Form
  constructors; the Designer already connected those handlers. Each dropdown
  now draws once per draw event.
- `ComboBoxFontStore` tracks fonts allocated by either settings Form. Replacing
  a font disposes the previous owned font, and closing the Form disposes the
  remaining fonts. G-force font changes previously allocated untracked fonts.
- G-force gradient colors are cached between chart updates, and regenerated
  only when their scheme, step count, alpha or divider changes.
- The G-force Clear action restores the timers' existing enabled states
  instead of unconditionally enabling both timers. Its chart layout calculation
  now uses the client width without duplicate position assignments.
- Chart Apply actions tolerate their corresponding chart Form being closed;
  four-wheel settings still update the model even when no chart is open.
- Removed the old commented-out list of hard-coded wheel axis names; selectable
  measurements continue to come from the built-in list and JSON configuration.

## Dropdown and persistence update

- `ComboBoxBehaviors.cs` enables editable search/suggestions for the four
  windows containing ComboBoxes. The displayed names of `Color` and
  `FontFamily` items are formatted without replacing their typed objects.
  An unknown typed value reverts to the most recent valid item on validation.
- A WinForms `IMessageFilter` suppresses mouse-wheel selection changes on
  closed ComboBoxes while allowing list scrolling when the dropdown is open.
- `Registry Tools.cs` now stores each form in a separate registry subsection,
  matches saved ComboBox values against real items instead of setting `Text`
  only, and saves both checked and unchecked checklist states. It can import
  the older shared settings when it finds that form's unique legacy key.
- Startup restores the saved four-wheel and G-force model parameters before
  opening their charts. Four-wheel limiter selections are restored when the
  four-wheel window opens. The main form saves only its game-version ComboBox,
  avoiding unnecessary persistence of live telemetry textboxes.
- The G-force Apply action pauses both chart timers and restores their original
  states. Opening G-force settings itself does not clear chart history.

### Additional Windows checks

1. Choose nondefault X/Y/Z measurements, axis ranges, scheme, and band count.
   Apply, close the app, and reopen it. Open **4 Wheels** directly and verify
   the chart and gradient legend already use those choices.
2. Set custom wheel limiter selections, click Apply Limiters, close/reopen
   4 Wheels, and verify the same selections and limits are shown.
3. Save different values in G-force and 4 Wheels settings; close them in either
   order, restart, and check neither overwrites the other.
4. Type into every kind of dropdown (axis, font, color, numeric, scheme,
   game version); select a suggestion, and verify its typed value is used.
   Test an unmatched value and leaving the field.
5. Hover over a closed dropdown and scroll the mouse wheel: its selection
   must not change. Open the dropdown and confirm the wheel scrolls its list.
6. For saved values from a previous build, verify whichever form was last
   saved in the old registry layout is recovered. Data already overwritten
   by the old shared `ClearSettings` behavior cannot be reconstructed.

## Compatibility

At 10 bands, the existing `SeriesFLColor1` through `SeriesRRColor10`
naming and reference RGB values are preserved. Color1 and Color10 are
distinguished using exact **suffix** matching, not substring matching.

Changing the chart layout rebinds existing history to the recreated series.
The history now retains each point's original Z value and insertion order.
Changing the color scheme, Z-range, or band count rebuckets and recolors the
stored points immediately when **Apply Chart Settings** is clicked, without
waiting for fresh incoming telemetry.

## Manual Windows validation

The project targets **.NET Framework 4.7.2 WinForms (x64)**. Open
`Wreckfest Physics Debugger.sln` in Visual Studio with that targeting pack
installed, then test:

1. Build Debug|AnyCPU (the project sets PlatformTarget=x64).
2. **Open 4 Wheels before pressing Get Process**, then connect and verify
   that no `NotImplementedException` occurs. Repeat with the 4 Wheels page
   opened after connecting.
3. Check all three layouts (Separate, Front/Rear, All In One).
4. Check each of the three palettes at 10 bands against the original output.
5. In **4 Wheels Settings**, select 5, 10, and 16 gradient bands and click
   **Apply Chart Settings**. Confirm every wheel receives the chosen number
   of `ColorN` series and the gradient legend tracks the same count.
6. With a Wreckfest session active, verify current points move and historical
   points stay bounded by **History Points per Z-gradient**.
7. Switch chart layouts or change band count; previous history should reappear
   in the correct color buckets (subject to the per-band history cap).
8. Pause updates, change the color scheme and press **Apply Chart Settings**.
   Confirm all already-drawn dots change colors, including the most recent
   dot for each wheel. Repeat with a changed Z-axis range.
9. Close and reopen the settings form; verify the band count is restored.
10. Check the absolute-values setting and the X/Y/Z limiter filters.
11. Compare **Apply Chart Settings** (keeps old dots) with **Apply and Clear**
    (removes them); pause updates before applying to verify pause is retained.
12. Check font/color dropdown drawing and selection, the four-wheel labels,
    and opening/closing the settings form after changing layouts.

The Linux editing environment does not contain Visual Studio or a .NET
Framework/WinForms build toolchain, so no executable build/runtime test was
performed here. The project source and Visual Studio solution are included.
