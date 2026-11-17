# Form4Wheels chart filters

`Form4Wheels` has **13 independent Min/Max filters**. All enabled filters must
pass for a wheel sample to appear in a chart. If none are enabled, no Min/Max
filter is applied. **No tire contact limiter** remains an independent option.

## Editing the panels in Visual Studio

Open `Form4Wheels.cs` in the WinForms Designer and use **View → Other Windows →
Document Outline** to see the exact container hierarchy:

- `filterActionsPanel`: Settings, Clear/Refresh, Pause, Apply Limiters, no-contact
  checkbox, and the settings-profile button host.
- `axisFiltersGroup` → `axisFiltersFlow`: **X, Y, Z** filters. These always follow
  the current chart axis selections, and their field selectors cannot be changed
  here. Their Min/Max, Enabled and Defaults controls are independent.
- `extraFiltersGroup` → `extraFiltersFlow`: **Extra 1 … Extra 10**, each with its
  own telemetry selector, Min/Max inputs, Enabled box and Defaults button.
- `chartScrollPanel`: the chart, gradient, and wheel labels. Filters occupy their
  own space above this panel and cannot overlay the charts.

To modify the spacing and appearance of **every filter row at once**, open
`ChartLimiterRow.cs` in the WinForms Designer. The complete row is a reusable
`UserControl`. Row ordering and the common grouping are defined in
`Form4Wheels.Designer.cs`; selection and value logic live in
`Form4Wheels.Filters.cs`. The filter area scrolls on smaller windows.

## Values and persistence

- Clicking **Defaults** populates Min/Max for that row's *currently selected*
  field using the same configured axis defaults as the chart settings. Blank
  default bounds mean no limit on that side.
- Signed fields use their normal min and max. Fields explicitly listed in
  `absoluteValueFields` in `WreckfestGameMemoryConfig.json` compare `abs(value)`
  and use a default minimum of zero.
- Each filter's enabled state, selection, Min and Max are saved with the existing
  Form4Wheels JSON settings and profiles. The three followed selections update
  when chart axes change; changing an axis loads that field's default Min/Max.
- Invalid input is highlighted pink, and that filter is temporarily skipped.
  Min must not exceed Max.

The **Apply Limiters** button also saves the current form settings. Valid edits
take effect without needing to clear the charts; only newly sampled points are
filtered. Existing chart history remains until cleared.

## Choosing which tires to chart

In **Form4WheelsSettings**, use **Separate, Front/Rear or All In One** to
record all four tires in four, two or one chart area respectively. Choose
**Front Left, Front Right, Rear Left or Rear Right** to record and display
only that tire, using the full single chart area.

Apply Chart Settings to rebuild the chart with the chosen layout. Existing
history for other tires is preserved but hidden while a single-tire mode is
active; no new points are collected for those tires until an all-tire layout
is selected again. Use **Clear Charts and Apply Axis Selections** to discard
the old history if desired.
