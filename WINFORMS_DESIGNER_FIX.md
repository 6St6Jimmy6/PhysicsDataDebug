# Form4Wheels and FormOfflineChart designer-loading fix

The parent Form designers no longer instantiate `ChartLimiterRow` directly.
Each of the 13 filter slots is a normal WinForms `Panel` with the same size,
margin and ordering. These panels are visible in Document Outline and can be
moved and resized in the parent form designer. When the application runs,
`ChartLimiterRowHost.Mount()` places a `ChartLimiterRow` in each panel. The
individual filter layout remains editable in `ChartLimiterRow.cs [Design]`.

Form constructors bypass chart setup, timers, file settings and runtime row
mounting in Visual Studio's design mode. This prevents unwanted app-data writes
and run-time chart manipulation while editing the forms.

The thirteen rows retain the existing filter names (`ChartFilter01...13` and
`OfflineFilter01...13`) and persisted child-control names, so prior settings
continue to load.

Windows verification:
1. Rebuild solution (Debug/x64) in Visual Studio.
2. Open Form4Wheels and FormOfflineChart designers and check their panel slots.
3. Open ChartLimiterRow designer to adjust the row's fields.
4. Run both forms and confirm all 13 filters are present and save/load normally.
5. Test changing one axis filter and an additional filter in each chart.
