# Chart and Designer update (2026-11-25)

Baseline: `PhysicsDataDebug(6).zip`.

- All profile-menu buttons are regular Designer controls. Removed the generic runtime button construction and parking host panels.
- Reconnected Offline Chart settings/filter Apply events, fixed font defaults and explicit minor-grid intervals, and added a software-projected interactive XYZ scatter view with optional independent color field.
- Four Wheels history defaults to FastPoint; a chart rebuild/paint taking more than 5000 ms, or a subsequent telemetry plot/paint exceeding the configured tick by more than 1000 ms, triggers a FastPoint rebuild and autosave. Current marker is a separate Point. This is a post-render safeguard, not a cancellation mechanism for a hung UI thread.
- G-force current/history marker sizes and update time are independently editable and persisted. Telemetry/chart refresh defaults are 50 ms; the G-force history snapshot timer remains derived from the history length.
- Added ground-following grid to suspension geometry, fitting a laterally tilted common supporting plane to both rendered tires per axle.
- Restoring factory defaults uses current values for the changed settings while retaining existing named profiles and autosaves.

## Windows verification checklist

1. Build the .NET Framework 4.7.2 solution in Visual Studio; open each modified Designer, especially G-force, Offline and Suspension Geometry.
2. Verify Profiles sizing and menu/keyboard behavior, then save/load a named profile.
3. Load a CSV with multiple wheels and at least four numeric fields; Apply Settings and Apply Filters, verify axis/marker changes, minor grid subdivisions, and restored profiles. Switch to 3D, orbit/pan/zoom, check XYZ tooltips, enable the fourth color field, and switch back to 2D.
4. On live Four Wheels, test FastPoint and another compatible history type, and verify fallback at the specified thresholds with a large history. Check that existing history remains.
5. Change G-force current/history sizes and interval; verify old history is restyled and settings persist.
6. Toggle suspension ground following under suspension movement. Check that the grid tilts to touch both tires, and the coordinates remain unchanged.

No Windows compiler or running Wreckfest is available in the preparation environment; static source and archive checks do not replace those runtime tests.
