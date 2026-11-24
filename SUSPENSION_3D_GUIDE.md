# 3D suspension geometry viewer

`FormSuspensionGeometry` replaces the old front/rear XY chart with two **interactive 3D wireframe views**. This is a geometric 3D projection drawn with built-in WinForms/GDI+; it does not require a new graphics engine, OpenGL, or third-party NuGet packages. It is not a solid mesh renderer.

## Controls

| Input | Action |
| --- | --- |
| Left mouse drag | Orbit both views (azimuth/elevation) |
| Right or middle drag | Pan only the view being dragged |
| Mouse wheel | Zoom both views |
| Hover over a point | Show point name and X/Y/Z in metres |
| Front / Side / Top / Isometric | Set a standard viewing angle |
| Reset view | Restore the isometric camera, 100% zoom, clear pan, and reframe the current axle geometry |
| Azimuth / Elevation | Precise camera-angle inputs (degrees) |
| Zoom (%) | Scale from 20% to 800% |
| Update (ms) | Live refresh interval, 10–10,000 ms; default 100 |
| Perspective | Enable/disable perspective (orthographic when off) |
| Grid | Toggle the horizontal XZ ground grid and XYZ axes |
| Point names | Draw labels by points (hover labels work regardless) |
| Rotate spindle offsets | Rotate wheel-local spindle offsets using `TireM11..TireM33` |

Each viewport initially fits its own axle geometry, then locks its camera framing once both wheel pivots are available. The camera center stays on **X = 0** (vehicle centerline); subsequent suspension movement and steering do not cause automatic recentering or rescaling. Press **Reset view** to frame a new vehicle or session. The physical *relative* scale of front vs rear drawings may differ. The camera angles and zoom are shared; pan is independent. The toolbar and two viewports are owned by `FormSuspensionGeometry.Designer.cs` and visible in Visual Studio's Designer. The custom `Suspension3DView` displays a static example in the Designer; runtime uses live telemetry instead.

## Geometry

- **X**: lateral; **Y**: vertical; **Z**: longitudinal.
- Body pickup points come from `BodyUpperFrontArm*`, `BodyUpperRearArm*`, `BodyLowerFrontArm*`, `BodyLowerRearArm*`, `BodySteeringRod*`, and `BodyPushRod*`.
- Spindle endpoints use the corresponding `Spindle*` offsets relative to the dynamic tire pivot (`TireM41`/`42`/`43`). When enabled, the optional matrix transform rotates spindle offsets by `TireM11..TireM33`, to account for wheel orientation.
- The body pickups and wheel pivot use the same `RideHeight + CenterOfMassHeight` vertical shift as the former XY plot. Tire outlines use `TireRadius`, `TireWidth`, and the tire rotation matrix if available.
- The upright and wishbone joining lines connect captured arm endpoints. These are visual construction lines, not additional game-memory measurements.
- The previous **XY instant center** and **XY roll center** are shown as *projected XY calculations* at the wheel/axle Z plane. These are not independently calculated 3D roll axes.

**Coordinate-frame caveat:** The underlying `Spindle*` offsets and wheel orientation-matrix conventions were inferred from the earlier 2D view, not proven against a known 3D model. Compare with `Rotate spindle offsets` disabled if arm directions appear wrong, and verify geometry against Wreckfest debug values. The renderer does not use the game's separate `XYZ*` diagnostic fields at present.

## Behavior while Wreckfest is in the menu

The memory reader remains attached and samples whatever telemetry is readable, even when `TIME_RaceTime` is not advancing. Geometry redraw does not require advancing RaceTime. Unavailable pointers and non-finite coordinates are skipped. If no geometry is available, the viewer shows an informative empty state rather than plotting bogus zero points.

## Saving and startup

The normal per-form `JsonFormSettings` system saves all toolbar numeric inputs and checkboxes in `%APPDATA%\PhysicsDataDebug\Settings\FormSuspensionGeometry.json`. Right-drag pan is temporary; Reset view clears it. The update timer and telemetry sampling are separate: a faster view timer cannot make the underlying memory-reader sample faster.

## Testing notes

After rebuilding the .NET Framework 4.7.2 solution in Visual Studio, verify the Designer, try all view presets, orbit/zoom and tooltip display in game, and watch the geometry move under steering and suspension load. In particular, compare `Rotate spindle offsets` on/off: axis conventions may need tuning with real telemetry. Windows runtime and live Wreckfest correctness have not been tested by this documentation change.
