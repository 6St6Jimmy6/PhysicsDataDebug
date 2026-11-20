# Live Time Chart

`FormTireTemperatures` is now the live, five-lane telemetry time-history chart.
Open it from **Live Data > Live Time Chart** after connecting to Wreckfest with **Get Process**.

## What a plot represents

- All plot lanes use the same X coordinate: **RaceTime** from the game, measured in milliseconds. The chart stores the X coordinate in seconds and can label it in **seconds or minutes**.
- Check a plot number (1–5) to enable its chart area, then choose a **Y measurement** from the dropdown. Up to five enabled plots stack vertically, aligned to the same X axis. Only the bottom plot shows time labels.
- For a wheel measurement such as `SlipAngleDeg`, that plot contains four individual series: `FL_`, `FR_`, `RL_`, `RR_`. The four checkboxes beside the selected field hide or show **that plot's** wheel series independently.
- Shared vehicle measurements such as `ENG_RPM`, `ACC_XG`, and `TIME_RaceTime` appear only once in their plot. The wheel checkboxes are disabled for shared measurements.
- The fields come from the active game-memory configuration and calculated-telemetry registry. The names shown for wheel measurements remain unprefixed: you choose the measurement, not a particular wheel.

By default, plot 1 shows `TreadTemperature` and plot 2 shows `InnerTemperature`. Plot slots 3–5 are initially disabled. Changing a measurement clears **only that plot's** history. Switching wheel visibility preserves the retained samples.

## Settings

Open **Chart Settings** to change:

| Setting | Initial value | Meaning |
| --- | --- | --- |
| Visible history | 60 seconds | How far back from the latest RaceTime to display |
| History unit | Seconds | Change to Minutes to enter longer windows conveniently |
| X axis display | Seconds | Labels shown in seconds or minutes, independent of history-window unit |
| Refresh interval | 100 ms | Timer rate for sampling the latest live telemetry snapshot |
| Max points per trace | 10,000 | Memory/performance cap per plotted series |
| Series type | FastLine | Alternatives: Line, Spline |
| Line thickness | 2 px | Width of each wheel/channel series |
| Marker diameter | 0 (off) | Optional point markers (most visible with Line or Spline) |
| Colors | Dark background, FL green, FR blue, RL gold, RR purple | Colors can be selected by name or by `#RRGGBB` / `#AARRGGBB` |
| Axis/grid text | Arial, white | Font family, axis and title font sizes, major/minor grid colors and visibility |
| Plot Y minimum / maximum | Auto | Each lane can use automatic scaling or its own fixed bounds |

Click **Apply Settings** to keep existing time samples while rebuilding the display. Your choices save to `%APPDATA%\PhysicsDataDebug\Settings\FormTireTemperaturesSettings.json` and track selections save separately to `FormTireTemperatures.json`.

## Live behavior

- Start/Resume begins updating the chart; Pause stops chart sampling without clearing the screen. Clear History removes all retained samples.
- The chart shows only the last `Visible history` amount. Older samples are discarded, and the maximum-points setting caps memory usage during very high sampling rates.
- An unchanged RaceTime (paused game) does not create duplicate samples. A backwards jump in RaceTime (new race/session) clears the old data.
- The game-memory sample refresh runs in the Live Data form. Changing the chart timer rate does **not** make Wreckfest memory refresh faster; it only changes how often the chart samples the latest available values.
- The chart does not write files. Use **Log Settings** for synchronized telemetry recording.

## Designer and source

The form and its separate settings dialog use standard WinForms controls (`Chart`, `TableLayoutPanel`, `ComboBox`, `CheckBox`, and `NumericUpDown`) owned by their `.Designer.cs` files. The individual five selector rows and grouped settings can be edited in Visual Studio Designer.

The plotted values are resolved through `LogData.AllColumns` and `LiveData`; complex calculated fields continue to use the active JSON schema and shared formula evaluator. No separate tire-temperature-only memory reader is required.
