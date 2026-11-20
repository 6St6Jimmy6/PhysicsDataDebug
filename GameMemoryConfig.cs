using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace Physics_Data_Debug
{
    /// <summary>A symbolic JSON-backed offset or calculated telemetry field.</summary>
    internal readonly struct GameMemoryField
    {
        public string Group { get; }
        public string Name { get; }
        public GameMemoryField(string group, string name)
        {
            Group = group;
            Name = name;
        }
        public override string ToString() => Name;
    }

    /// <summary>Logical telemetry list names; these are not memory offsets.</summary>
    internal static class TelemetryPrefix
    {
        public const string Body = "Body";
        public const string FL = "FL";
        public const string FR = "FR";
        public const string RL = "RL";
        public const string RR = "RR";
        public const string Powertrain = "Powertrain";
        public const string Timing = "Timing";
        // Append new categories to preserve the indexes of existing telemetry lists.
        public static readonly string[] Order = { Body, FL, FR, RL, RR, Powertrain, Timing };
    }

    /// <summary>A selectable game build with its own base-address shift and offset overrides.</summary>
    internal sealed class GameVersionProfile
    {
        public string Id { get; }
        public string DisplayName { get; }
        public long BaseAddressShift { get; }
        internal Dictionary<string, long> Overrides { get; }

        internal GameVersionProfile(string id, string displayName, long shift,
                                    Dictionary<string, long> overrides)
        {
            Id = id;
            DisplayName = displayName;
            BaseAddressShift = shift;
            Overrides = overrides;
        }

        // The stable ID is used for compatibility with old saved selections.
        public override string ToString() => Id;
    }

    internal sealed class WheelAxisProfile
    {
        public float Max { get; set; }
        public float Min { get; set; }
        public double MajorInterval { get; set; }
        public int Decimals { get; set; }
        public bool MinorEnabled { get; set; }
        public int MinorIntervalFraction { get; set; }
    }

    /// <summary>
    /// Resolves symbolic field names, memory offsets and ordered telemetry layouts
    /// from the selected JSON file in the per-user Settings folder.
    /// No compiled Wreckfest enums are needed.
    /// </summary>
    /// <summary>One contiguous process-memory read needed for the configured fields.</summary>
    internal sealed class MemoryReadRange
    {
        public int Start { get; }
        public int Length { get; }
        public MemoryReadRange(int start, int length) { Start = start; Length = length; }
    }

    internal static class GameMemoryConfig
    {
        public const string DefaultFileName = "WreckfestGameMemoryConfig.json";
        private const string ActiveSelectionFileName = "ActiveGameMemoryConfig.json";
        private const string EmbeddedDefaultResource = "Physics_Data_Debug.WreckfestGameMemoryConfig.json";
        private static Dictionary<string, long> activeValues =
            new Dictionary<string, long>(StringComparer.Ordinal);
        private static List<GameVersionProfile> versions = BuildBuiltInVersions();
        private static Dictionary<string, WheelAxisProfile> wheelAxisDefaults =
            new Dictionary<string, WheelAxisProfile>(StringComparer.Ordinal);

        public static IReadOnlyList<GameVersionProfile> Versions => versions;
        public static GameVersionProfile ActiveVersion { get; private set; } =
            versions.FirstOrDefault(version => version.Id == "V1_308438") ?? versions[0];
        public static string LoadWarning { get; private set; }
        public static string SettingsDirectory => JsonFormSettings.DirectoryPath;
        public static string ActiveFileName { get; private set; } = DefaultFileName;
        public static string FilePath => Path.Combine(SettingsDirectory, ActiveFileName);
        public static IReadOnlyList<string> AbsoluteValueFields { get; private set; } = new string[0];
        public static IReadOnlyList<string> TelemetrySelections { get; private set; } = new string[0];
        public static IReadOnlyDictionary<string, string> TelemetryPrefixes { get; private set; } =
            new Dictionary<string, string>(StringComparer.Ordinal);
        public static IReadOnlyDictionary<string, string> TelemetryAliases { get; private set; } =
            new Dictionary<string, string>(StringComparer.Ordinal);
        private static bool categorizedSchema;
        private static int maxReadGapBytes = 32;
        private static Dictionary<string, string> configuredExpressions =
            new Dictionary<string, string>(StringComparer.Ordinal);
        private static int maxReadBytes = 4096;
        private static Dictionary<string, string> configuredFieldTypes =
            new Dictionary<string, string>(StringComparer.Ordinal);
        private static Dictionary<string, int[]> configuredPointerChains =
            new Dictionary<string, int[]>(StringComparer.Ordinal);
        private static Dictionary<string, int[]> activePointerChains =
            new Dictionary<string, int[]>(StringComparer.Ordinal);
        private static Dictionary<string, MemoryReadRange[]> configuredReadRanges =
            new Dictionary<string, MemoryReadRange[]>(StringComparer.Ordinal);

        // A stable bridge from the readable category names in schema 2 to the
        // internal data layouts used by existing charts, formulas and labels.
        // Adding a field inside an existing category needs no C# changes.
        private sealed class CategoryBinding
        {
            public string BaseName, FieldGroup, ChunkGroup, SideGroup;
            public CategoryBinding(string baseName, string group, string chunk, string side)
            { BaseName = baseName; FieldGroup = group; ChunkGroup = chunk; SideGroup = side; }
        }
        private static readonly Dictionary<string, CategoryBinding> CategoryBindings =
            new Dictionary<string, CategoryBinding>(StringComparer.Ordinal)
            {
                { "tire", new CategoryBinding("Tire", "WF_TireDataOffset", "WF_TireDataChunks", "WF_TireSide") },
                { "suspension1", new CategoryBinding("Suspension1", "WF_Suspension1DataOffset", "WF_Suspension1DataChunks", "WF_Suspension1DataSideOffset") },
                { "suspension2", new CategoryBinding("Suspension2", "WF_Suspension2DataOffset", "WF_Suspension2DataChunks", "WF_Suspension2DataSideOffset") },
                { "suspensionGeometry", new CategoryBinding("SuspensionGeometry", "WF_SuspensionGeometryDataOffset", "WF_SuspensionGeometryDataChunks", "WF_SuspensionGeometrySideOffsets") },
                { "bodyMass", new CategoryBinding("Suspension2", "WF_MassDataOffset", "WF_MassDataChunks", "WF_BodyMassSide") },
                { "bodyRotation", new CategoryBinding("BodyLocationHeading", "WF_BodyRotationDataOffset", "WF_BodyRotationChunks", "WF_BodyRotationSide") },
                { "bodyAcceleration", new CategoryBinding("Acceleration", "WF_BodyAccelDataOffset", "WF_BodyAccelDataChunks", "WF_BodyAccelSide") },
                { "aerodynamics", new CategoryBinding("Aero", "WF_AeroDataOffset", "WF_AeroDataChunks", "WF_AeroSide") },
                { "engine", new CategoryBinding("Engine", "WF_EngineDataOffset", "WF_EngineDataChunks", "WF_EngineSide") },
                { "differential", new CategoryBinding("Differential", "WF_DifferentialDataOffset", "WF_DifferentialDataChunks", "WF_DifferentialSide") },
                { "timing", new CategoryBinding("RaceTime", "WF_TimeDataOffset", null, null) }
            };
        private static readonly Dictionary<string, string[]> BaseAliases =
            new Dictionary<string, string[]>(StringComparer.Ordinal)
            {
                { "vehicle", new[] { "Tire", "Suspension1", "Suspension2", "Aero", "Differential", "BodyLocationHeading" } },
                { "engine", new[] { "Engine", "Speed" } },
                { "timing", new[] { "RaceTime" } },
                { "acceleration", new[] { "Acceleration" } },
                { "geometry", new[] { "SuspensionGeometry" } }
            };
        internal static string ChunkForFieldGroup(string group)
        {
            foreach (var binding in CategoryBindings.Values)
                if (binding.FieldGroup == group) return binding.ChunkGroup;
            return null;
        }
        public static IReadOnlyList<MemoryReadRange> ReadRanges(string chunkGroup) =>
            configuredReadRanges.TryGetValue(chunkGroup, out MemoryReadRange[] ranges)
                ? ranges : Array.Empty<MemoryReadRange>();
        public static IReadOnlyList<int> PointerChain(string chunkGroup) =>
            activePointerChains.TryGetValue(chunkGroup, out int[] offsets)
                ? offsets : Array.Empty<int>();
        public static bool IsInt32Field(string group, string name) =>
            configuredFieldTypes.TryGetValue(group + "." + name, out string type)
                ? type == "int32"
                : group == "WF_TimeDataOffset" ||
                    (group == "WF_DifferentialDataOffset" && name.StartsWith("DifferentialOpen", StringComparison.Ordinal));

        private static Dictionary<string, string[]> orderedMembers =
            new Dictionary<string, string[]>(StringComparer.Ordinal);

        /// <summary>
        /// Read the previously selected configuration at startup. Passing a
        /// filename switches profiles and remembers it for the next launch.
        /// Filenames are confined to the user's Settings directory.
        /// </summary>
        public static void Load(string configurationFileName = null)
        {
            try
            {
                EnsureDefaultConfiguration();
                string fileName = configurationFileName ?? ReadActiveConfigurationName();
                ValidateFileName(fileName);
                LoadConfiguration(Path.Combine(SettingsDirectory, fileName));
                ActiveFileName = fileName;
                if (configurationFileName != null)
                    SaveActiveConfigurationName(fileName);
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException ||
                                       ex is System.Security.SecurityException)
            {
                throw new FormatException("Unable to access game configurations in " +
                    SettingsDirectory + ": " + ex.Message, ex);
            }
        }

        private static void ValidateFileName(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName) ||
                !string.Equals(Path.GetFileName(fileName), fileName, StringComparison.Ordinal) ||
                !fileName.EndsWith(".json", StringComparison.OrdinalIgnoreCase) ||
                fileName == "." || fileName == "..")
                throw new FormatException("Invalid game configuration filename: " + fileName);
        }

        private static string ReadActiveConfigurationName()
        {
            string path = Path.Combine(SettingsDirectory, ActiveSelectionFileName);
            if (!File.Exists(path)) return DefaultFileName;
            try
            {
                var serializer = new JavaScriptSerializer();
                var settings = AsObject(serializer.DeserializeObject(File.ReadAllText(path)), "active game configuration");
                string selected = RequiredString(settings, "fileName");
                ValidateFileName(selected);
                return selected;
            }
            catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException ||
                                       ex is IOException || ex is UnauthorizedAccessException)
            {
                throw new FormatException("Could not read " + path + ": " + ex.Message, ex);
            }
        }

        private static void SaveActiveConfigurationName(string name)
        {
            string path = Path.Combine(SettingsDirectory, ActiveSelectionFileName);
            string temp = path + "." + Guid.NewGuid().ToString("N") + ".tmp";
            try
            {
                var serializer = new JavaScriptSerializer();
                File.WriteAllText(temp, serializer.Serialize(new { fileName = name }), new UTF8Encoding(false));
                if (File.Exists(path)) File.Replace(temp, path, null);
                else File.Move(temp, path);
            }
            finally { if (File.Exists(temp)) File.Delete(temp); }
        }

        /// <summary>
        /// The shipped Wreckfest defaults are embedded in the executable.
        /// Extract the original into AppData once; if an older executable had
        /// customized JSON next to it, import that as a separate profile.
        /// Never overwrite edits or the original factory file.
        /// </summary>
        private static void EnsureDefaultConfiguration()
        {
            Directory.CreateDirectory(SettingsDirectory);
            string destination = Path.Combine(SettingsDirectory, DefaultFileName);
            if (!File.Exists(destination))
            {
                string temp = destination + "." + Guid.NewGuid().ToString("N") + ".tmp";
                try
                {
                    using (Stream source = typeof(GameMemoryConfig).Assembly.GetManifestResourceStream(EmbeddedDefaultResource))
                    {
                        if (source == null)
                            throw new FormatException("The embedded " + DefaultFileName + " default is missing from the application.");
                        using (var output = new FileStream(temp, FileMode.CreateNew, FileAccess.Write))
                            source.CopyTo(output);
                    }
                    File.Move(temp, destination);
                }
                finally { if (File.Exists(temp)) File.Delete(temp); }
            }

            // Older builds kept an editable GameMemoryConfig.json alongside the
            // executable. If it differs from the shipped defaults, preserve it
            // under a distinct filename and select that profile on upgrade.
            string selection = Path.Combine(SettingsDirectory, ActiveSelectionFileName);
            string legacy = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GameMemoryConfig.json");
            string imported = "WreckfestImportedGameMemoryConfig.json";
            string importedPath = Path.Combine(SettingsDirectory, imported);
            if (!File.Exists(selection) && File.Exists(legacy) &&
                !File.Exists(importedPath) &&
                !File.ReadAllBytes(legacy).SequenceEqual(File.ReadAllBytes(destination)))
            {
                File.Copy(legacy, importedPath);
                SaveActiveConfigurationName(imported);
            }
        }

        private static void LoadConfiguration(string configPath)
        {
            LoadWarning = null;
            Dictionary<string, long> globals =
                new Dictionary<string, long>(StringComparer.Ordinal);
            List<GameVersionProfile> configuredVersions = BuildBuiltInVersions();
            string preferredVersion = "V1_308438";
            int gradientSteps = 10;
            int maxInfiniteHistoryPoints = 0;
            bool parsedSchema2 = false;
            int configuredMaxReadGap = 32;
            int configuredMaxReadBytes = 4096;
            var axisDefaults = new Dictionary<string, WheelAxisProfile>(StringComparer.Ordinal);
            List<string> absoluteFields = null;
            List<string> selectableFields = null;
            var parsedFieldTypes = new Dictionary<string, string>(StringComparer.Ordinal);
            var parsedExpressions = new Dictionary<string, string>(StringComparer.Ordinal);
            var parsedCalculatedNames = new Dictionary<string, List<string>>(StringComparer.Ordinal);
            var parsedPointerChains = new Dictionary<string, int[]>(StringComparer.Ordinal);

            var configuredTelemetryPrefixes = new Dictionary<string, string>(StringComparer.Ordinal);
            var configuredTelemetryAliases = new Dictionary<string, string>(StringComparer.Ordinal);

            try
            {
                if (File.Exists(configPath))
                {
                    var serializer = new JavaScriptSerializer { MaxJsonLength = int.MaxValue };
                    var document = AsObject(serializer.DeserializeObject(File.ReadAllText(configPath)), "root");
                    if (!document.TryGetValue("schemaVersion", out object schema))
                        throw new FormatException("Missing schemaVersion.");
                    int schemaVersion = Convert.ToInt32(schema, CultureInfo.InvariantCulture);
                    if (schemaVersion == 1)
                    {
                        if (document.TryGetValue("enumValues", out object values))
                            MergeValues(globals, AsObject(values, "enumValues"));
                        if (globals.Count == 0)
                            throw new FormatException("enumValues must provide the default offsets.");
                    }
                    else if (schemaVersion == 2)
                    {
                        parsedSchema2 = true;
                        ParseCategorizedFields(document, globals, axisDefaults,
                            ref absoluteFields, configuredTelemetryPrefixes,
                            configuredTelemetryAliases, parsedFieldTypes, parsedPointerChains,
                            parsedExpressions, parsedCalculatedNames);
                    }
                    else throw new FormatException("Unsupported schemaVersion: " + schemaVersion + ". Expected 1 or 2.");


                    if (document.TryGetValue("readOptimization", out object optimizationRaw))
                    {
                        var optimization = AsObject(optimizationRaw, "readOptimization");
                        if (optimization.TryGetValue("maxGapBytes", out object gap))
                            configuredMaxReadGap = checked((int)ParseNumber(gap, "maxGapBytes"));
                        if (optimization.TryGetValue("maxReadBytes", out object maxRead))
                            configuredMaxReadBytes = checked((int)ParseNumber(maxRead, "maxReadBytes"));
                        if (configuredMaxReadGap < 0 || configuredMaxReadGap > 1024 ||
                            configuredMaxReadBytes < 4 || configuredMaxReadBytes > 1024 * 1024 ||
                            (configuredMaxReadBytes & 3) != 0 || (configuredMaxReadGap & 3) != 0)
                            throw new FormatException("readOptimization settings must be four-byte aligned; gap 0-1024, read 4-1048576.");
                    }

                    if (document.TryGetValue("defaultVersion", out object defaultId))
                        preferredVersion = NormalizeLegacyVersionId(
                            Convert.ToString(defaultId, CultureInfo.InvariantCulture));

                    if (document.TryGetValue("gForce", out object gForceSettings))
                    {
                        var settings = AsObject(gForceSettings, "gForce");
                        if (settings.TryGetValue("gradientSteps", out object steps))
                            gradientSteps = checked((int)ParseNumber(steps, "gForce.gradientSteps"));
                        if (settings.TryGetValue("maxInfiniteHistoryPoints", out object points))
                            maxInfiniteHistoryPoints = checked((int)ParseNumber(points, "gForce.maxInfiniteHistoryPoints"));
                        if (gradientSteps < 1 || gradientSteps > 64 || maxInfiniteHistoryPoints < 0)
                            throw new FormatException("gForce.gradientSteps must be 1-64 and maxInfiniteHistoryPoints must be nonnegative.");
                    }

                    if (document.TryGetValue("wheelAxisDefaults", out object axisData))
                    {
                        foreach (var entry in AsObject(axisData, "wheelAxisDefaults"))
                        {
                            var fields = AsObject(entry.Value, "wheelAxisDefaults." + entry.Key);
                            var profile = new WheelAxisProfile
                            {
                                Max = Convert.ToSingle(fields["max"], CultureInfo.InvariantCulture),
                                Min = Convert.ToSingle(fields["min"], CultureInfo.InvariantCulture),
                                MajorInterval = Convert.ToDouble(fields["majorInterval"], CultureInfo.InvariantCulture),
                                Decimals = Convert.ToInt32(fields["decimals"], CultureInfo.InvariantCulture),
                                MinorEnabled = Convert.ToBoolean(fields["minorEnabled"], CultureInfo.InvariantCulture),
                                MinorIntervalFraction = Convert.ToInt32(fields["minorIntervalFraction"], CultureInfo.InvariantCulture)
                            };
                            if (profile.MinorIntervalFraction < 1 || profile.Decimals < 0 ||
                                double.IsNaN(profile.MajorInterval))
                                throw new FormatException("Invalid wheel axis defaults for " + entry.Key);
                            axisDefaults.Add(entry.Key, profile);
                        }
                    }
                    if (document.TryGetValue("absoluteValueFields", out object absoluteData))
                    {
                        absoluteFields = new List<string>();
                        foreach (object name in AsArray(absoluteData, "absoluteValueFields"))
                        {
                            string text = Convert.ToString(name, CultureInfo.InvariantCulture);
                            if (string.IsNullOrWhiteSpace(text))
                                throw new FormatException("absoluteValueFields cannot contain blank entries.");
                            absoluteFields.Add(text);
                        }
                    }
                    if (document.TryGetValue("telemetryPrefixes", out object prefixMappings))
                    {
                        foreach (var entry in AsObject(prefixMappings, "telemetryPrefixes"))
                        {
                            string value = Convert.ToString(entry.Value, CultureInfo.InvariantCulture);
                            if (string.IsNullOrWhiteSpace(value) ||
                                !System.Text.RegularExpressions.Regex.IsMatch(value, "^[A-Z][A-Z0-9]*$"))
                                throw new FormatException("Invalid telemetry prefix: " + entry.Key);
                            configuredTelemetryPrefixes.Add(entry.Key, value);
                        }
                    }
                    if (document.TryGetValue("telemetryAliases", out object aliasMappings))
                    {
                        foreach (var entry in AsObject(aliasMappings, "telemetryAliases"))
                        {
                            string value = Convert.ToString(entry.Value, CultureInfo.InvariantCulture);
                            if (string.IsNullOrWhiteSpace(value) ||
                                !System.Text.RegularExpressions.Regex.IsMatch(value, "^[A-Za-z][A-Za-z0-9]*$"))
                                throw new FormatException("Invalid telemetry alias: " + entry.Key);
                            configuredTelemetryAliases.Add(entry.Key, value);
                        }
                    }
                    if (document.TryGetValue("telemetrySelections", out object selections))
                    {
                        selectableFields = new List<string>();
                        foreach (object field in AsArray(selections, "telemetrySelections"))
                        {
                            string name = Convert.ToString(field, CultureInfo.InvariantCulture);
                            if (string.IsNullOrWhiteSpace(name) || selectableFields.Contains(name))
                                throw new FormatException("Invalid or duplicate telemetry selection: " + name);
                            selectableFields.Add(name);
                        }
                    }

                    if (document.TryGetValue("versions", out object versionEntries))
                    {
                        var loadedVersions = new List<GameVersionProfile>();
                        var ids = new HashSet<string>(StringComparer.Ordinal);
                        foreach (object entry in AsArray(versionEntries, "versions"))
                        {
                            var version = AsObject(entry, "versions[]");
                            string originalId = RequiredString(version, "id");
                            string id = NormalizeLegacyVersionId(originalId);
                            if (!ids.Add(id))
                                throw new FormatException("Duplicate version ID: " + id);
                            string displayName = version.TryGetValue("displayName", out object text)
                                ? Convert.ToString(text, CultureInfo.InvariantCulture) : id;
                            if (string.Equals(displayName, "V1_308408", StringComparison.Ordinal))
                                displayName = "V1_308438";
                            long shift = ParseNumber(version["baseAddressShift"], "baseAddressShift");
                            var overrides = new Dictionary<string, long>(StringComparer.Ordinal);
                            if (version.TryGetValue("enumOverrides", out object perVersion))
                                MergeValues(overrides, AsObject(perVersion, "enumOverrides"));
                            loadedVersions.Add(new GameVersionProfile(id, displayName, shift, overrides));
                        }
                        if (loadedVersions.Count == 0)
                            throw new FormatException("At least one version is required.");
                        configuredVersions = loadedVersions;
                    }
                }
                else
                {
                    throw new FormatException(configPath + " was not found. The JSON configuration is required.");
                }
            }
            catch (Exception ex) when (ex is FormatException || ex is KeyNotFoundException ||
                                       ex is OverflowException || ex is ArgumentException ||
                                       ex is InvalidCastException || ex is InvalidOperationException ||
                                       ex is IOException || ex is UnauthorizedAccessException)
            {
                // Without compiled offsets, guessing defaults would read arbitrary game memory.
                throw new FormatException("Unable to load " + configPath + ": " + ex.Message, ex);
            }

            foreach (GameVersionProfile version in configuredVersions)
            {
                foreach (string key in version.Overrides.Keys)
                    if (!globals.ContainsKey(key))
                        throw new FormatException("Version " + version.Id +
                            " overrides unknown field " + key +
                            ". Add it to enumValues first.");
            }

            // Commit as a transaction: invalid dependencies and alias collisions
            // must not leave a previously working game configuration half-applied.
            var oldVersions = versions;
            var oldBaseValues = baseValues;
            var oldAxisDefaults = wheelAxisDefaults;
            var oldAbsoluteFields = AbsoluteValueFields;
            var oldPrefixes = TelemetryPrefixes;
            var oldAliases = TelemetryAliases;
            var oldMembers = orderedMembers;
            var oldSchema = categorizedSchema;
            int oldGap = maxReadGapBytes, oldMaxRead = maxReadBytes;
            var oldTypes = configuredFieldTypes;
            var oldPointers = configuredPointerChains;
            var oldExpressions = configuredExpressions;
            var oldActive = activeValues;
            var oldActivePointers = activePointerChains;
            var oldReadRanges = configuredReadRanges;
            var oldVersion = ActiveVersion;
            var oldSelections = TelemetrySelections;
            int oldGradientSteps = FormGForceSettings.GradientSteps;
            int oldMaxPoints = FormGForceSettings.MaxInfiniteHistoryPoints;
            var oldCalculations = CalculatedTelemetry.Groups.ToDictionary(
                group => group, group => CalculatedTelemetry.Names(group).ToList(),
                StringComparer.Ordinal);
            try
            {
                versions = configuredVersions;
                baseValues = globals;
                wheelAxisDefaults = axisDefaults;
                AbsoluteValueFields = absoluteFields != null
                    ? (IReadOnlyList<string>)absoluteFields
                    : Array.Empty<string>();
                TelemetryPrefixes = configuredTelemetryPrefixes;
                TelemetryAliases = configuredTelemetryAliases;
                CalculatedTelemetry.Configure(parsedCalculatedNames);
                orderedMembers = BuildOrderedMembers(globals);
                // Older JSON files stored the names in AllValueNames; preserve
                // compatibility when users upgrade the executable first.
                categorizedSchema = parsedSchema2;
                maxReadGapBytes = configuredMaxReadGap;
                maxReadBytes = configuredMaxReadBytes;
                configuredFieldTypes = parsedFieldTypes;
                configuredPointerChains = parsedPointerChains;
                configuredExpressions = parsedExpressions;
                // Compile JSON expressions once during config loading. The existing
                // built-ins are used for fields with no expression.
                TelemetryFormulas.Configure(configuredExpressions);
                // Lists are derived from the configured fields (including formulas),
                // never duplicated manually in telemetrySelections.
                TelemetrySelections = Array.Empty<string>();
                FormGForceSettings.GradientSteps = gradientSteps;
                FormGForceSettings.MaxInfiniteHistoryPoints = maxInfiniteHistoryPoints;
                SelectVersion(versions.FirstOrDefault(v => v.Id == preferredVersion) ?? versions[0]);
                LogData.RebuildColumns();
                TelemetryFormulas.ValidateConfiguration();
                TelemetrySelections = (new[] { "None" }).Concat(
                    LogData.AllColumns.Select(column => column.Header)).ToArray();

            }
            catch
            {
                versions = oldVersions;
                baseValues = oldBaseValues;
                wheelAxisDefaults = oldAxisDefaults;
                AbsoluteValueFields = oldAbsoluteFields;
                TelemetryPrefixes = oldPrefixes;
                TelemetryAliases = oldAliases;
                orderedMembers = oldMembers;
                categorizedSchema = oldSchema;
                maxReadGapBytes = oldGap;
                maxReadBytes = oldMaxRead;
                configuredFieldTypes = oldTypes;
                configuredPointerChains = oldPointers;
                configuredExpressions = oldExpressions;
                activeValues = oldActive;
                activePointerChains = oldActivePointers;
                configuredReadRanges = oldReadRanges;
                ActiveVersion = oldVersion;
                TelemetrySelections = oldSelections;
                FormGForceSettings.GradientSteps = oldGradientSteps;
                FormGForceSettings.MaxInfiniteHistoryPoints = oldMaxPoints;
                CalculatedTelemetry.Configure(oldCalculations);
                TelemetryFormulas.Configure(oldExpressions);
                if (oldMembers.Count > 0) LogData.RebuildColumns();
                throw;
            }
        }

        public static void SelectVersion(GameVersionProfile version)
        {
            if (version == null || !versions.Contains(version))
                throw new ArgumentException("Select a configured version.", nameof(version));
            // A version switch updates one immutable lookup snapshot; no JSON
            // parsing or reflection occurs during the 50 ms telemetry loop.
            var selected = new Dictionary<string, long>(baseValues, StringComparer.Ordinal);
            foreach (var entry in version.Overrides)
                selected[entry.Key] = entry.Value;
            if (categorizedSchema)
                RecomputeCategorySpans(selected);
            activeValues = selected;
            var selectedPointers = new Dictionary<string, int[]>(StringComparer.Ordinal);
            foreach (var entry in configuredPointerChains)
            {
                var chain = (int[])entry.Value.Clone();
                if (chain.Length > 0 && selected.TryGetValue(entry.Key + ".Offset1", out long first))
                    chain[0] = checked((int)first);
                selectedPointers.Add(entry.Key, chain);
            }
            activePointerChains = selectedPointers;
            // Build the optimized read plan once per selected game version.
            configuredReadRanges = BuildReadRanges(selected);
            ActiveVersion = version;
        }

        // Compatibility with JSON profiles created before the build-number typo was found.
        // Normalize only this known identifier; user-defined versions remain untouched.
        private static string NormalizeLegacyVersionId(string id) =>
            string.Equals(id, "V1_308408", StringComparison.Ordinal)
                ? "V1_308438" : id;

        /// <summary>
        /// Automatic mode uses the detected Tire RVA to determine a shift, while
        /// still honoring a matching JSON version's individual field overrides.
        /// For unknown builds, use the reference 1.285308 (shift 0) offsets.
        /// Nothing is written to the user's JSON; manual profiles still work.
        /// </summary>
        public static long SelectDetectedVersion(WreckfestDetectedVersion detected,
            out GameVersionProfile matchingProfile)
        {
            if (detected == null) throw new ArgumentNullException(nameof(detected));
            matchingProfile = versions.FirstOrDefault(v =>
                string.Equals(v.Id, detected.VersionId, StringComparison.Ordinal));
            GameVersionProfile reference = matchingProfile ??
                versions.FirstOrDefault(v => string.Equals(v.Id, "V1_285308", StringComparison.Ordinal)) ??
                versions.FirstOrDefault(v => v.BaseAddressShift == 0);
            if (reference == null)
                throw new InvalidOperationException(
                    "Automatic detection requires a matching version or a baseline JSON version with baseAddressShift 0. " +
                    "Select a manually configured version instead.");
            SelectVersion(reference);
            long tireRvaInConfig = checked((long)Address("Tire"));
            // Offsets in a matching version profile are already reflected in Address("Tire").
            // The returned extra shift is applied once by MemoryReader.ReadSample().
            return checked(detected.TireBaseRva - tireRvaInConfig);
        }

        private static Dictionary<string, long> baseValues =
            new Dictionary<string, long>(StringComparer.Ordinal);

        public static long Value(string enumType, string member)
        {
            string key = enumType + "." + member;
            if (!activeValues.TryGetValue(key, out long value))
                throw new KeyNotFoundException("Unknown offset " + key + " in " + ActiveFileName);
            return value;
        }

        public static int Int(string enumType, string member) => checked((int)Value(enumType, member));
        public static int Int(GameMemoryField field) => Int(field.Group, field.Name);
        public static GameMemoryField Field(string group, string name) => new GameMemoryField(group, name);
        public static ulong Address(string member) => checked((ulong)Value("BaseAddress", member));
        public static bool TryGetWheelAxisDefaults(string name, out WheelAxisProfile profile) =>
            wheelAxisDefaults.TryGetValue(LegacySelectionName(name), out profile);

        // Public prefixed aliases and historical unprefixed profile selections
        // remain interchangeable for chart-axis defaults and saved preferences.
        public static string LegacySelectionName(string name)
        {
            if (string.IsNullOrEmpty(name)) return name;
            name = TelemetryNames.RelativeWheelName(name);
            foreach (string group in new[] { "WF_TimeDataOffset", "WF_BodyRotationDataOffset",
                "WF_BodyAccelDataOffset", "WF_AeroDataOffset", "WF_MassDataOffset",
                "WF_EngineDataOffset", "WF_DifferentialDataOffset" })
                foreach (string member in Members(group))
                    if (string.Equals(name, TelemetryNames.Name(group, member), StringComparison.Ordinal))
                        return member;
            return name;
        }

        public static bool IsAbsoluteValueField(string name) =>
            AbsoluteValueFields.Contains(name) || AbsoluteValueFields.Contains(LegacySelectionName(name));

        /// <summary>
        /// Names are ordered by their baseline JSON offsets, independently of
        /// per-game-version overrides. New JSON fields become visible automatically.
        /// </summary>
        public static IReadOnlyList<string> Members(string group)
        {
            return orderedMembers.TryGetValue(group, out string[] names) ? names : Array.Empty<string>();
        }

        private static Dictionary<string, string[]> BuildOrderedMembers(Dictionary<string, long> values)
        {
            var result = values.GroupBy(entry => entry.Key.Substring(0, entry.Key.IndexOf('.')),
                                      StringComparer.Ordinal)
                .ToDictionary(group => group.Key,
                    group => group.Where(entry => !CalculatedTelemetry.IsCalculated(
                            group.Key, entry.Key.Substring(group.Key.Length + 1)))
                        .OrderBy(entry => entry.Value)
                        .Select(entry => entry.Key.Substring(group.Key.Length + 1)).ToArray(),
                    StringComparer.Ordinal);
            foreach (string group in CalculatedTelemetry.Groups)
            {
                string[] raw = result.TryGetValue(group, out string[] names) ? names : Array.Empty<string>();
                result[group] = raw.Concat(CalculatedTelemetry.Names(group)).ToArray();
            }
            return result;
        }

        private static WheelAxisProfile ParseAxisProfile(object raw, string location)
        {
            var fields = AsObject(raw, location);
            var profile = new WheelAxisProfile
            {
                Max = Convert.ToSingle(fields["max"], CultureInfo.InvariantCulture),
                Min = Convert.ToSingle(fields["min"], CultureInfo.InvariantCulture),
                MajorInterval = Convert.ToDouble(fields["majorInterval"], CultureInfo.InvariantCulture),
                Decimals = Convert.ToInt32(fields["decimals"], CultureInfo.InvariantCulture),
                MinorEnabled = Convert.ToBoolean(fields["minorEnabled"], CultureInfo.InvariantCulture),
                MinorIntervalFraction = Convert.ToInt32(fields["minorIntervalFraction"], CultureInfo.InvariantCulture)
            };
            if (profile.MinorIntervalFraction < 1 || profile.Decimals < 0 ||
                profile.Min >= profile.Max || double.IsNaN(profile.MajorInterval) ||
                double.IsInfinity(profile.MajorInterval) || profile.MajorInterval <= 0)
                throw new FormatException("Invalid axisDefaults at " + location);
            return profile;
        }

        /// <summary>Schema 2: categories inherit bases and wheel strides;
        /// every field owns its offset, display metadata, and value type.</summary>
        private static void ParseCategorizedFields(IDictionary<string, object> document,
            Dictionary<string, long> values, Dictionary<string, WheelAxisProfile> axes,
            ref List<string> absolute, Dictionary<string, string> prefixes,
            Dictionary<string, string> aliases, Dictionary<string, string> types,
            Dictionary<string, int[]> pointerChains,
            Dictionary<string, string> expressions,
            Dictionary<string, List<string>> calculatedNames)
        {
            absolute = new List<string>();
            var configuredBases = AsObject(document["baseAddresses"], "baseAddresses");
            var resolvedBases = new Dictionary<string, long>(StringComparer.Ordinal);
            foreach (var entry in configuredBases)
            {
                if (!BaseAliases.TryGetValue(entry.Key, out string[] baseNames))
                    throw new FormatException("Unknown baseAddresses category: " + entry.Key);
                long address = ParseNumber(entry.Value, "baseAddresses." + entry.Key);
                resolvedBases[entry.Key] = address;
                foreach (string name in baseNames) values.Add("BaseAddress." + name, address);
            }
            foreach (var entry in AsObject(document["categories"], "categories"))
            {
                if (!CategoryBindings.TryGetValue(entry.Key, out CategoryBinding binding))
                    throw new FormatException("Unknown memory category: " + entry.Key +
                        ". Add a category binding in GameMemoryConfig before introducing a new memory structure.");
                var category = AsObject(entry.Value, "categories." + entry.Key);
                string baseAlias = RequiredString(category, "base");
                if (!resolvedBases.TryGetValue(baseAlias, out long address) ||
                    !values.TryGetValue("BaseAddress." + binding.BaseName, out long expectedAddress) ||
                    address != expectedAddress)
                    throw new FormatException("Incorrect memory base for categories." + entry.Key);
                if (category.TryGetValue("prefix", out object prefix))
                    prefixes[binding.FieldGroup] = Convert.ToString(prefix, CultureInfo.InvariantCulture);
                if (binding.SideGroup != null)
                {
                    if (category.TryGetValue("wheelOffsets", out object wheelOffsets))
                    {
                        foreach (var wheel in AsObject(wheelOffsets, "wheelOffsets"))
                            values.Add(binding.SideGroup + "." + wheel.Key,
                                ParseNumber(wheel.Value, entry.Key + ".wheelOffsets." + wheel.Key));
                    }
                    else
                    {
                        string name = binding.SideGroup == "WF_DifferentialSide" ? "Left" : "AllSides";
                        values.Add(binding.SideGroup + "." + name, 0);
                    }
                }
                if (category.TryGetValue("pointerOffsets", out object chain))
                {
                    var offsets = new List<int>();
                    foreach (var value in AsArray(chain, entry.Key + ".pointerOffsets"))
                        offsets.Add(checked((int)ParseNumber(value, entry.Key + ".pointerOffsets")));
                    if (binding.ChunkGroup == null && offsets.Count != 0)
                        throw new FormatException("Timing memory does not support pointerOffsets.");
                    if (binding.ChunkGroup != null) pointerChains.Add(binding.ChunkGroup, offsets.ToArray());
                    if (binding.ChunkGroup != null && offsets.Count > 0)
                        values.Add(binding.ChunkGroup + ".Offset1", offsets[0]);
                }
                var fields = AsObject(category["fields"], entry.Key + ".fields");
                if (fields.Count == 0)
                    throw new FormatException("Category has no fields: " + entry.Key);
                int low = int.MaxValue, high = int.MinValue;
                foreach (var field in fields)
                {
                    string location = entry.Key + ".fields." + field.Key;
                    if (CalculatedTelemetry.IsBuiltIn(binding.FieldGroup, field.Key))
                        throw new FormatException("Raw field conflicts with a calculated built-in: " + location);
                    IDictionary<string, object> metadata = field.Value as IDictionary<string, object>;
                    object rawOffset = metadata != null ? metadata["offset"] : field.Value;
                    int offset = checked((int)ParseNumber(rawOffset, location));
                    if (offset < 0 || (offset & 3) != 0)
                        throw new FormatException("Offsets must be nonnegative and four-byte aligned: " + location);
                    values.Add(binding.FieldGroup + "." + field.Key, offset);
                    low = Math.Min(low, offset);
                    high = Math.Max(high, offset);
                    if (metadata != null) ExtractFieldMetadata(binding.FieldGroup, field.Key,
                        metadata, axes, absolute, aliases, types, location);
                }
                if (binding.ChunkGroup != null)
                {
                    int size = checked(high - low + sizeof(float));
                    // Consumer indexing still uses a virtual sparse chunk. Only
                    // the actual reads will be split into small contiguous ranges.
                    if (size > 4 * 1024 * 1024)
                        throw new FormatException("Category span exceeds 4 MiB: " + entry.Key);
                    values.Add(binding.ChunkGroup + ".DataStart", low);
                    values.Add(binding.ChunkGroup + ".ChunkSize", size);
                }
                if (category.TryGetValue("calculated", out object computedRaw))
                {
                    foreach (var computed in AsObject(computedRaw, entry.Key + ".calculated"))
                    {
                        string location = entry.Key + ".calculated." + computed.Key;
                        if (fields.ContainsKey(computed.Key))
                            throw new FormatException("Calculated field conflicts with raw field: " + location);
                        if (!System.Text.RegularExpressions.Regex.IsMatch(computed.Key, "^[A-Za-z][A-Za-z0-9_]*$"))
                            throw new FormatException("Invalid calculated name: " + location);
                        var metadata = AsObject(computed.Value, location);
                        if (!calculatedNames.TryGetValue(binding.FieldGroup, out List<string> names))
                            calculatedNames[binding.FieldGroup] = names = new List<string>();
                        names.Add(computed.Key);
                        bool hasExpression = metadata.TryGetValue("expression", out object expressionRaw);
                        bool hasBuiltin = metadata.TryGetValue("builtin", out object builtinRaw) &&
                            Convert.ToBoolean(builtinRaw, CultureInfo.InvariantCulture);
                        if (hasExpression && hasBuiltin)
                            throw new FormatException("Use either expression or builtin, not both: " + location);
                        if (hasBuiltin && !TelemetryFormulas.HasBuiltIn(computed.Key))
                            throw new FormatException("Unknown builtin formula: " + location);
                        if (hasExpression)
                        {
                            string expression = Convert.ToString(expressionRaw, CultureInfo.InvariantCulture);
                            // Validate syntax immediately, before installing a new configuration.
                            TelemetryExpression.Compile(expression);
                            expressions.Add(binding.FieldGroup + "." + computed.Key, expression);
                        }
                        else if (!TelemetryFormulas.HasBuiltIn(computed.Key))
                            throw new FormatException("New calculated field needs an expression: " + location);
                        ExtractFieldMetadata(binding.FieldGroup, computed.Key,
                            metadata, axes, absolute, aliases, types, location);
                    }
                }
            }
            foreach (string id in CategoryBindings.Keys)
                if (!AsObject(document["categories"], "categories").ContainsKey(id))
                    throw new FormatException("Missing required memory category: " + id);
        }

        private static void ExtractFieldMetadata(string group, string member,
            IDictionary<string, object> fields, Dictionary<string, WheelAxisProfile> axes,
            List<string> absolute, Dictionary<string, string> aliases,
            Dictionary<string, string> types, string location)
        {
            if (fields.TryGetValue("axisDefaults", out object axis))
            {
                WheelAxisProfile profile = ParseAxisProfile(axis, location + ".axisDefaults");
                if (!axes.ContainsKey(member)) axes.Add(member, profile);
            }
            if (fields.TryGetValue("absolute", out object absoluteRaw) &&
                Convert.ToBoolean(absoluteRaw, CultureInfo.InvariantCulture) &&
                !absolute.Contains(member)) absolute.Add(member);
            if (fields.TryGetValue("alias", out object alias))
            {
                string name = Convert.ToString(alias, CultureInfo.InvariantCulture);
                if (string.IsNullOrWhiteSpace(name))
                    throw new FormatException("Empty alias: " + location);
                aliases.Add(group + "." + member, name);
            }
            if (fields.TryGetValue("type", out object type))
            {
                string value = Convert.ToString(type, CultureInfo.InvariantCulture);
                if (value != "int32" && value != "float32")
                    throw new FormatException("Only float32 and int32 types are supported: " + location);
                types.Add(group + "." + member, value);
            }
        }

        private static void RecomputeCategorySpans(Dictionary<string, long> values)
        {
            foreach (CategoryBinding binding in CategoryBindings.Values)
            {
                if (binding.ChunkGroup == null) continue;
                string groupPrefix = binding.FieldGroup + ".";
                long[] offsets = values.Where(e => e.Key.StartsWith(groupPrefix, StringComparison.Ordinal))
                    .Select(e => e.Value).ToArray();
                if (offsets.Length == 0) throw new FormatException("Empty memory category: " + binding.FieldGroup);
                long first = offsets.Min(), last = offsets.Max();
                if (first < 0 || first % 4 != 0 || last % 4 != 0 ||
                    last - first + 4 > 4 * 1024 * 1024)
                    throw new FormatException("Invalid field offset range in " + binding.FieldGroup);
                values[binding.ChunkGroup + ".DataStart"] = first;
                values[binding.ChunkGroup + ".ChunkSize"] = checked(last - first + 4);
            }
        }

        private static Dictionary<string, MemoryReadRange[]> BuildReadRanges(
            Dictionary<string, long> values)
        {
            var result = new Dictionary<string, MemoryReadRange[]>(StringComparer.Ordinal);
            foreach (var binding in CategoryBindings.Values)
            {
                string group = binding.FieldGroup;
                var offsets = values.Where(kv => kv.Key.StartsWith(group + ".", StringComparison.Ordinal))
                    .Select(kv => checked((int)kv.Value)).Distinct().OrderBy(x => x).ToArray();
                if (offsets.Length == 0) throw new FormatException("No raw fields for " + group);
                string planKey = binding.ChunkGroup ?? binding.FieldGroup;
                int start = binding.ChunkGroup != null
                    ? checked((int)values[binding.ChunkGroup + ".DataStart"]) : offsets[0];
                int size = binding.ChunkGroup != null
                    ? checked((int)values[binding.ChunkGroup + ".ChunkSize"])
                    : checked(offsets[offsets.Length - 1] - offsets[0] + sizeof(float));
                if (size <= 0 || size > 4 * 1024 * 1024 || (size & 3) != 0)
                    throw new FormatException("Invalid generated memory span for " + group);
                var ranges = new List<MemoryReadRange>();
                int lower = offsets[0], upper = checked(lower + sizeof(float));
                foreach (int offset in offsets.Skip(1))
                {
                    if (offset - upper <= maxReadGapBytes && offset - lower + sizeof(float) <= maxReadBytes)
                        upper = checked(offset + sizeof(float));
                    else
                    {
                        ranges.Add(new MemoryReadRange(lower, upper - lower));
                        lower = offset;
                        upper = checked(offset + sizeof(float));
                    }
                }
                ranges.Add(new MemoryReadRange(lower, upper - lower));
                if (ranges[0].Start < start ||
                    ranges[ranges.Count - 1].Start + ranges[ranges.Count - 1].Length > start + size)
                    throw new FormatException("Version offsets exceed configured span for " + group);
                result.Add(planKey, ranges.ToArray());
            }
            return result;
        }

        private static List<GameVersionProfile> BuildBuiltInVersions()
        {
            return new List<GameVersionProfile>
            {
                new GameVersionProfile("V1_285308", "V1_285308", 0L,
                    new Dictionary<string, long>(StringComparer.Ordinal)),
                new GameVersionProfile("V1_308438", "V1_308438", 0x9E00L,
                    new Dictionary<string, long>(StringComparer.Ordinal))
            };
        }

        private static IDictionary<string, object> AsObject(object value, string field)
        {
            if (value is IDictionary<string, object> map) return map;
            throw new FormatException(field + " must be a JSON object.");
        }

        private static IEnumerable AsArray(object value, string field)
        {
            if (value is object[] list) return list;
            if (value is ArrayList array) return array;
            throw new FormatException(field + " must be an array.");
        }

        private static string RequiredString(IDictionary<string, object> map, string key)
        {
            if (!map.TryGetValue(key, out object value))
                throw new FormatException("Missing required property: " + key);
            string result = Convert.ToString(value, CultureInfo.InvariantCulture);
            if (string.IsNullOrWhiteSpace(result))
                throw new FormatException(key + " cannot be blank.");
            return result;
        }

        private static void MergeValues(Dictionary<string, long> target,
                                        IDictionary<string, object> groups)
        {
            foreach (var group in groups)
            {
                foreach (var entry in AsObject(group.Value, group.Key))
                    target[group.Key + "." + entry.Key] = ParseNumber(entry.Value, group.Key + "." + entry.Key);
            }
        }

        private static long ParseNumber(object raw, string field)
        {
            string value = Convert.ToString(raw, CultureInfo.InvariantCulture)?.Trim();
            if (string.IsNullOrEmpty(value))
                throw new FormatException("Empty numeric value at " + field);
            bool negative = value.StartsWith("-", StringComparison.Ordinal);
            string magnitude = negative ? value.Substring(1) : value;
            if (magnitude.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
            {
                ulong parsed = ulong.Parse(magnitude.Substring(2), NumberStyles.HexNumber,
                                          CultureInfo.InvariantCulture);
                if (parsed > long.MaxValue)
                    throw new OverflowException(field + " exceeds the signed 64-bit range.");
                return negative ? -(long)parsed : (long)parsed;
            }
            return long.Parse(value, NumberStyles.Integer, CultureInfo.InvariantCulture);
        }
    }
}
