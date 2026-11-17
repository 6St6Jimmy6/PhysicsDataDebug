# Tire / Suspension Static Values – Designer layout update

Both static-value pages are now laid out **entirely in their `.Designer.cs` files**. The old
`FormPanelLayout.OrganizeWheelValues` calls were removed from their constructors.
Their former fixed screen positions are no longer consulted at runtime.

## Hierarchy in Visual Studio's Document Outline

- `wheelValuesLayout` – 2×2 `TableLayoutPanel` (front left/right, then rear left/right)
  - `frontLeftGroup`, `frontRightGroup`, `rearLeftGroup`, `rearRightGroup` – dark `GroupBox` wheel cards
    - `frontLeftScroll` etc. – independently scrollable `Panel`
      - `frontLeftSections` etc. – vertically stacked `TableLayoutPanel`
        - `frontLeftSection1Group` etc. – editable section `GroupBox`
          - `frontLeftSection1Rows` etc. – 1-column `TableLayoutPanel`
            - `frontLeftRadiusRow` etc. – **a complete movable setting row**
              - `frontLeftRadiusCaption` and `label_FL_Radius` (the latter updated by telemetry)

To move a measurement, select its `...Row` table in **View → Other Windows → Document Outline**, then move it to the destination section's `...Rows` table and change its `Row` property. If adding rows, increase the destination section table's `RowCount`, add a `RowStyle`, and increase its parent section row height. Wheel cards use scrolling, so taller content will not overlap other cards. Edit category titles using the `Text` property of their `...Group` controls.

## Grouping

**Tire Static Values:** Dimensions, Spring & Damper, Thermal, Mass & Inertia.

**Suspension Static Values:** Springs, Travel & Limits, Damping & Rebound, Bump Stops.
Paired values appear side-by-side in X/Y order, with a corresponding caption.

All 36 tire and 72 suspension numeric readout labels retain their original names,
which are used by the existing telemetry update methods. No memory offsets, timers,
or other forms were changed.

## Testing

Source-level checks: `python tools/validate_static_values_panels.py` and
`python tools/validate_designer_control_fields.py`.

The Windows Forms Designer and runtime are not available in this environment;
please review actual render at your normal Windows DPI scaling.

## Compact layout refinement

Both forms now use 31-pixel measurement rows (previously 38), with smaller
category margins and more compact wheel-card padding. Each section row reserves
29 pixels in addition to its measurement rows for the GroupBox heading and spacing.
Numeric readouts use 38% width for single-value rows; X/Y pairs use 21% each,
leaving sufficient room for captions. Outer form margins are reduced and the
default window widths are smaller. All values and groups remain editable from
Visual Studio's WinForms Designer. No runtime layout or resizing logic was added.

At elevated Windows text scaling, the independent wheel scrollbars remain enabled
so the form can adapt without overlapping controls.
