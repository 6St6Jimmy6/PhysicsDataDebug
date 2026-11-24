# Four Wheels Settings — Visual Studio Designer control declaration fix

> **Historical changelog:** describes an earlier source revision. Some layouts, file names and implementation details have since changed. For current behavior, see the [project README](../README.md) and [current build changes](CURRENT_BUILD_2026-11-24.md).

The previous version initialized 21 live chart appearance controls in `Form4WheelsSettings.Designer.cs` but declared their private fields in `Form4WheelsSettings.Appearance.cs`. It also declared `gradientStepsNumericUpDown` in `Form4WheelsSettings.cs`. Although C# partial classes compile in this arrangement, the WinForms Designer could not resolve the fields while loading the form.

## Fix

- All 22 affected Designer-owned control field declarations are now in `Form4WheelsSettings.Designer.cs`, with their existing construction, control names, parent rows, and event wiring untouched.
- Removed the duplicate/external declarations from `Form4WheelsSettings.Appearance.cs` and `Form4WheelsSettings.cs`.
- Added `tools/validate_designer_control_fields.py` to prevent the same mistake.
- Preserved Designer layout, live chart options, JSON names, Z legend width (80 px default), and Offline Chart button handlers.

## Verification performed

- All 13 `*.Designer.cs` files passed the new control-field validator.
- All 22 affected controls have one declaration, initialization, `Name`, and parent `Controls.Add`.
- All 16 settings Designer event hookup targets exist.
- All 58 C# sources listed by the project are present.
- `validate_game_config.py`, `validate_lazy_telemetry.py`, `validate_live_legend.py`, and `validate_offline_chart_ui.py` pass.
- A full Visual Studio Windows Forms Designer and .NET Framework build test is still necessary, since Windows tools are unavailable in this environment.

In Visual Studio: close the Form4WheelsSettings Designer, build the solution, and reopen the form. If Visual Studio caches old Designer information, close/reopen Visual Studio before retrying.
