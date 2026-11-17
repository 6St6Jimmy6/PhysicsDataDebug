# Four Wheels settings rows and toolbar appearance — 2026-11-16

## Cause of overwide settings controls

The 65 Designer-owned measurement/settings rows were `Panel`s whose initial width was the WinForms default 200 px. Each row contained controls placed at x=12 with a width of 240 or 250 px and left/right anchoring. WinForms computed incorrect (negative) right-side anchor distances, so later resizing could make controls wider than their parent panels. This hid ComboBox dropdown arrows and could trigger horizontal scrolling.

## Change

`Form4WheelsSettings.Designer.cs`: each row is initialized with `Width = 264` **before** the row's child controls are attached, allowing 12 px initial margins for the 240 px inputs. The generated caption labels are also 240 px wide. Rows remain Designer-owned, `Dock.Top`, and responsive to the X/Y/Z/Chart & Data panel widths. Controls and JSON setting names are unchanged.

`Form4Wheels.Designer.cs`: the Settings, Clear/Refresh All, Pause, and Apply Limiters buttons all have `UseVisualStyleBackColor = false`, a dark-gray `(60,60,60)` background, and white text, matching Offline Chart. Click handlers are unchanged. The shared Profiles button already uses dark styling.

`tools/validate_live_settings_rows_and_buttons.py`: regression check that all 65 rows have an appropriate initial width before anchoring and that four toolbar buttons retain click handlers and consistent styling.

## Visual Studio checks

1. Open `Form4WheelsSettings` in Designer, resize the window narrower/wider, and confirm the X/Y/Z dropdown arrows remain inside the panels.
2. Check vertical scrolling shows all fields and no additional horizontal scrollbars appear when there is enough space for the selected column width.
3. Open `Form4Wheels`: verify the four buttons are dark with white text and retain their actions.

The project was not compiled or run under Windows in this environment.
