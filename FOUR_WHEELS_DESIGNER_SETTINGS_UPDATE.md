# Four Wheels settings designer conversion

- `Form4WheelsSettings.Designer.cs` owns every row, label, input, top action bar and Profiles host.
- No controls are repositioned or created by `ArrangeLiveSettings()` at runtime. That method and the former dynamic layout class have been removed.
- Edit `settingsSectionsLayout` columns in the WinForms Designer, or open `settingsSidebarPanel`, `xAxisSettingsPanel`, `yAxisSettingsPanel`, and `zAxisSettingsPanel` in Document Outline to select each row.
- Each row has `Dock=Top`; change `Height` to alter spacing. The parent panel scrolls if necessary.
- Legend default width is 80 px, range 60–600 px; the chart split container's minimum legend width is 60.
- The live-only controls (history, wheel layouts, markers, cursors) remain in Chart and Data Settings.
- The four Offline Chart toolbar buttons retain their Designer-defined dark colors and connections.
- The shared Profiles button is themed dark for chart forms and their settings.

Build and inspect in Visual Studio; full .NET Framework GUI execution was not available in this environment.
