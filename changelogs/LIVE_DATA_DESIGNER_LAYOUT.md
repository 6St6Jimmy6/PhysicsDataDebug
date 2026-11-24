# Live Data layout is now editable in the Visual Studio Designer

> **Historical changelog:** describes an earlier source revision. Some layouts, file names and implementation details have since changed. For current behavior, see the [project README](../README.md) and [current build changes](CURRENT_BUILD_2026-11-24.md).

This revision is based on the user-supplied `PhysicsDataDebug(1).zip` and retains
its hand-tuned `FormRowLayout` constants, telemetry control names, and settings.

Open **FormLiveData.cs [Design]**, then **View → Other Windows → Document Outline**.

```text
FormLiveData
└── liveDataMainLayout (TableLayoutPanel)
    ├── navigationPagesPanel (FlowLayoutPanel)
    │   ├── original page buttons
    │   ├── openOfflineChartButton
    │   └── toggleDebugWorkspaceButton
    └── telemetrySidebarSplitter (SplitContainer)
        ├── Panel1: telemetrySidebarPanel (FlowLayoutPanel)
        │   ├── gameVersionSection (Config / Profiles and build status)
        │   ├── sessionLoggingSection
        │   ├── speedTelemetrySection
        │   ├── accelerationTelemetrySection
        │   ├── gforceTelemetrySection
        │   ├── aeroTelemetrySection
        │   ├── liftTelemetrySection
        │   ├── engineTelemetrySection
        │   └── differentialTelemetrySection
        │       ├── differentialLeftSection
        │       └── differentialRightSection
        └── Panel2: debugWorkspaceSplitter (SplitContainer)
            ├── Panel1: wheelTelemetryColumn
            │   ├── checkBox1 (text updates)
            │   └── fourWheelScrollPanel
            │       └── fourWheelGrid (2 columns by default)
            │           ├── panel1TelemetryCard (Front Left)
            │           │   └── panel1 (16 Designer-owned measurement rows)
            │           ├── panel2TelemetryCard (Front Right)
            │           ├── panel3TelemetryCard (Rear Left)
            │           └── panel4TelemetryCard (Rear Right)
            └── Panel2: debugWorkspacePanel
                └── six labeled debug sections
```

Each wheel contains `panel1TelemetryRow0` ... `panel1TelemetryRow15` (and
similarly for panels 2, 3, and 4). Each row has its original caption, values,
separators, and units as child controls. You can select them from the Document
Outline and edit their properties directly.

Live resizing adjusts existing row panels through
`FormRowLayout.BindDesignerTelemetryRows()`; it **does not create or reparent**
measurement labels. If you want to change live responsive behavior, edit the
existing constants and `PlaceValueRow` method in `FormRowLayout.cs`.

To change broad widths, select the `SplitContainer` and edit `SplitterDistance`
or drag its divider in the Designer. For nav spacing, change
`navigationPagesPanel` `Padding`/button `Margin`. For fixed wheel row heights,
change `WheelRowHeight`/`WheelRowSpacing` in FormRowLayout.

The Profiles button itself is still a shared runtime button created by
JsonFormSettings, but its parent `SettingsProfilesHost` is now editable in the
Designer. Likewise, the game Config button and build status are Designer-owned.

The release build still hides debug content by default; the Designer keeps it
visible so you can edit the workspace.

## Validation needed on Windows

1. Build in Visual Studio, then open FormLiveData in the Designer.
2. Open Document Outline, confirm all four wheel groups and sixteen rows each.
3. Resize the Designer; check sidebar and wheel scroll behavior.
4. Run and test Get Process, chart pages, JSON Profiles, debug visibility,
   and live wheel updates at different window widths.

This Linux environment cannot run the Visual Studio WinForms Designer or
compile the .NET Framework solution, so its actual visual appearance has not
been runtime-verified here.
