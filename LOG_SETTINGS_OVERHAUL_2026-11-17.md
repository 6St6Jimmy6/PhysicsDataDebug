# Logging settings overhaul

## New selection model
- The `checkedListBoxLogging` choices come from the active `WreckfestGameMemoryConfig.json` through `GameMemoryConfig.Members(...)`, rather than the 29 old hardcoded designer entries.
- Covers timing, body rotation, body acceleration, aero, body mass, engine, differential, tire, suspension 1, suspension geometry, and suspension 2, including calculated fields registered by `CalculatedTelemetry`.
- Each choice is presented as `Category / ExactFieldName`. Rows are stored in the settings JSON using their displayed names, so adding/reordering fields in the game JSON will not silently reassign a checkbox.
- Column headers prefer the existing JSON telemetry name (e.g. `RaceTime`, `SlipRatio`, `Body_XG`); duplicate names are qualified by category to prevent CSV collisions.
- Logging 100% of available fields may produce very large files, especially suspension geometry; the initial selection is a conservative subset based on the former 29-item logger.

## Filter semantics
- Ten independent designer-owned `LogFilterRow` UserControls, each with Enabled, Field (searchable), Mode (Inside/Outside), Absolute, Minimum and Maximum.
- Every enabled filter must pass before a row for that wheel is written (logical AND).
- Inside: minimum <= value <= maximum. Outside: value < minimum OR value > maximum. Non-numeric/nonfinite values fail the filter.
- Shared Body/Powertrain/Timing values are evaluated identically for each wheel; wheel fields use that wheel's value.
- Apply changes the next session. Logging already in progress retains its snapshot, including filters, fields and limits, so the four output file schemas remain consistent.

## Output and auto-stop
- Default folder: `%APPDATA%\PhysicsDataDebug\Logs`, adjacent to `%APPDATA%\PhysicsDataDebug\Settings`.
- Four files per Start Logging click: `FrontLeft_yyyyMMdd_HHmmss.txt`, `FrontRight_...`, `RearLeft_...`, and `RearRight_...` with a shared timestamp. Existing names never overwrite; a coordinated numeric suffix is added for a rare same-second collision.
- Time limit: seconds since Start, 0 unlimited. Total size limit: MiB combined over all four files, 0 unlimited. Whichever is reached first stops logging and closes all writers. The row that would exceed the byte limit is not written.
- Log history is not appended to a previous session.

## Designer editing
- Open `FormLogSettings.cs` in Visual Studio > View Designer. In Document Outline: `contentLayout` contains `selectedFieldsGroup` and `filterAndOutputLayout`; `filterRowsLayout` contains `logFilter01` ... `logFilter10`.
- To change the arrangement of a single filter, open `LogFilterRow.cs` in View Designer; that template is shared by all ten rows. To move a filter row, change its `Row` under `filterRowsLayout` in the Designer.
- Dark colors and fixed layout groups are defined in the `.Designer.cs` files, not created as runtime overlays. The active JSON list is deliberately populated at runtime so newly added telemetry fields are available without rebuilding the Designer.

## Notes
- `LogData` reads the full telemetry registry, not the original fixed offset table. `LiveData.GetFullListDataValue` now matches exact JSON group + field where possible, fixing previously ambiguous duplicate field names.
- The application still needs a Windows/Visual Studio compile and UI check; no WinForms compiler is available in this environment.
