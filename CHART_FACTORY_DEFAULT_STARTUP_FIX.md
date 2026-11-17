# Fix: zero-width WinForms chart during factory-default startup

## Symptom

`JsonFormSettings.EnsureFactoryDefaults<T>()` threw `TargetInvocationException`,
with `ArgumentException: Width must be greater than 0px` from
`System.Windows.Forms.DataVisualization.Charting.ChartPicture.InspectChartDimensions`.

## Cause

`Program.Main` constructed temporary, invisible `Form4Wheels` and
`FormOfflineChart` windows solely to capture default settings. Those forms
also initialize/rebuild chart controls, which can receive zero-size layout
measurements before the windows have been displayed.

## Changes

- `Program.cs` no longer creates either chart form during factory-default
  initialization. Other settings-only forms retain their startup default
  profiles as before.
- `JsonFormSettings.EnsureFactoryDefaults<T>()` now refuses to instantiate
  these two chart forms even if mistakenly called again.
- `Form4Wheels` generates `Factory Defaults.json` from its real instance
  before loading its active saved settings.
- `FormOfflineChart` continues to capture its baseline before CSV data
  is imported, with no temporary Chart window being created.
- Initial chart rendering/reconfiguration is deferred to `Shown` for both
  chart forms, when their layout dimensions are established.
- `tools/validate_factory_default_chart_startup.py` checks this invariant.

## Existing settings and profiles

No AppData JSON files or profiles are deleted or overwritten. An existing
`Factory Defaults.json` is preserved. If one is absent for a chart form,
it will be created the first time the corresponding chart is opened.

## Windows tests recommended

1. Launch with empty `%APPDATA%\\PhysicsDataDebug\\Settings\\Profiles\\Form4Wheels`
   and `FormOfflineChart` profile folders, or back them up before testing.
2. Confirm startup succeeds without opening temporary chart windows.
3. Open Four Wheels and Offline Chart, then close/reopen both.
4. Check that each form's `Factory Defaults.json` was created and that
   saved settings and manual Profiles actions still work.
5. Resize chart forms and repeat with existing CSV imports.

Static validators pass, but the WinForms UI has not been executed here.
