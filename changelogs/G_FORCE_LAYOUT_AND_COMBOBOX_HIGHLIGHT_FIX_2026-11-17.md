# G-Force layout, settings alignment, and ComboBox highlight fix

> **Historical changelog:** describes an earlier source revision. Some layouts, file names and implementation details have since changed. For current behavior, see the [project README](../README.md) and [current build changes](CURRENT_BUILD_2026-11-24.md).

## FormGForceSettings
- The form and X/Y chart settings default to Arial (instead of GenericSansSerif).
- Labeled input controls use top/left/right anchoring instead of `DockStyle.Bottom`, so the last ComboBox stays immediately under its label if the form is enlarged.
- A final percentage-height spacer row absorbs free space in each scrollable settings column; labeled rows remain fixed-height.
- The top button bar is a designer-owned, dark FlowLayoutPanel with wider Apply and Load Current buttons. The toolbar scrolls horizontally if a very narrow window cannot show all actions.

## FormGForce
- The previous form-width `SizeChanged` handler is removed entirely.
- A designer-owned `mainLayout` TableLayoutPanel now contains a dark button bar, an adjustable `chartAndBar` SplitContainer, and a status label.
- Polar and vertical G charts are docked inside the split panels. Adjust the splitter in Visual Studio or at runtime, without custom resize code. No limiter UI is added.
- Chart minimum sizes are set before docking to avoid transient zero-size Chart errors.

## ComboBoxBehaviors
- Searchable controls now use `AutoCompleteMode.Suggest` rather than `SuggestAppend` to avoid automatically selecting displayed text in blue.
- A shared selection-clearing event handler removes retained editable-text highlighting on opening/committing a selection and when a form first appears, while retaining searchable typing and the currently selected item.
- This behavior is used by Form4WheelsSettings, FormOfflineChartSettings, and FormGForceSettings (plus the other forms that call `EnableSearch`). It does not change the native highlight of one currently selected *option inside the open list*.

## Verification
- Structural source validators passed. The application/Visual Studio Designer cannot be executed in this Linux environment. Test the WinForms Designer and DPI scaling on Windows.
- Saved settings profiles can override the new default Arial font until restored to defaults.
