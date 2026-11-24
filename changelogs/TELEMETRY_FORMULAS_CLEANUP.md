# Telemetry formulas cleanup — 2026-11-14

> **Historical changelog:** describes an earlier source revision. Some layouts, file names and implementation details have since changed. For current behavior, see the [project README](../README.md) and [current build changes](CURRENT_BUILD_2026-11-24.md).

This update continues from `PhysicsDataDebug_MemoryReader_Refactor_2026-11-12.zip`.

## Fixed
- Restored `using Memory.Utils;` to `LegacyMemoryUtilities.cs` for the legacy `ObjectType` helper.

## Moved from `LiveData.cs` to `TelemetryFormulas.cs`
- `RadToDeg`, `XZAngleRad`, `CalcAngles`, `GetPitchYawRollFromQuaternion`
- `WorldTransformToLocal`, `BigValueReducerFloat`, `LoopAngleRad`, `WorldPositionBody`

The method bodies were retained unchanged. The shared telemetry formula registry now calls them directly instead of through `LiveData`.

## Removed from `LiveData.cs`
- `GetFriction`, `GetTotalFriction`, `GetTotalFrictionAngle`
- `ConsoleTireData`, `GetCalculatedAeroData`, `GetCalculatedAccelData`, `GetCalculatedRotationData`
- `TransformMatrixBody`, `GetRawData<T>`, `GetCalcuatedTireData`, `GetCalculatedEngineData`
- `GetRawFourBytesArrayData`, `GetFloatDataValue`

The remaining raw-memory reads use `MemoryReader`, and calculated telemetry uses the on-demand formula registry. No compiled source calls the removed methods.

## Validation
- `python tools/validate_game_config.py` (updated for lazy formulas)
- `python tools/validate_lazy_telemetry.py`
- Static signature/reference and Visual Studio project source checks
- Archive integrity check

A Windows/.NET Framework 4.7.2 build and runtime test must still be performed in Visual Studio.
