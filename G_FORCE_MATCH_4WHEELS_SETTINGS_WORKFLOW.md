# G-Force settings workflow aligned to Form4Wheels

- Program.Main restores `FormGForceSettings.RestoreSavedModel()` before chart creation.
- `FormGForce` no longer applies chart properties inside its constructor. Like `Form4Wheels`, it configures the charts in `Shown` after real layout is ready. Both timers start only after this initialization.
- `FormGForceSettings` now uses one `ApplySettings(bool clearHistory)` path, shared by:
  - **Apply Chart Settings**: update appearance and sample interval, preserve current and infinite history.
  - **Clear Charts and Apply**: apply settings, then clear existing current and infinite history on both chart controls.
- Opening the G-Force Settings form or loading a profile updates chart appearance without clearing data.
- `FormGForce.ApplyChartSettings()` centralizes the polar chart, vertical bar and snapshot timer refresh.
- `FormGForce.ClearAllSeriesHistory()` handles both Chart controls; the G-Force chart's toolbar Clear Charts button uses the same method.
- G-Force Settings action buttons are designer-owned and styled like Form4WheelsSettings.
- The existing custom font persistence, legend/scheme, and grouped designer controls are preserved.

Validation: source checks only. Build in Visual Studio and test at runtime in Windows, particularly layout and event ordering.

- Removed legacy hardcoded white polar chart strip lines and seeded dummy vertical G-force points from the designer.
- Apply-only converts existing polar history between degrees and radians when the angle display setting changes.
