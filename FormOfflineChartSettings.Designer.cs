using System;
using System.Drawing;
using System.Windows.Forms;

namespace Physics_Data_Debug
{
    partial class FormOfflineChartSettings
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox axisFiltersGroup;
        private System.Windows.Forms.FlowLayoutPanel axisFiltersFlow;
        private System.Windows.Forms.GroupBox extraFiltersGroup;
        private System.Windows.Forms.FlowLayoutPanel extraFiltersFlow;
        private Physics_Data_Debug.ChartLimiterRow axisXFilterRow;
        private Physics_Data_Debug.ChartLimiterRow axisYFilterRow;
        private Physics_Data_Debug.ChartLimiterRow axisZFilterRow;
        private Physics_Data_Debug.ChartLimiterRow extraFilterRow01;
        private Physics_Data_Debug.ChartLimiterRow extraFilterRow02;
        private Physics_Data_Debug.ChartLimiterRow extraFilterRow03;
        private Physics_Data_Debug.ChartLimiterRow extraFilterRow04;
        private Physics_Data_Debug.ChartLimiterRow extraFilterRow05;
        private Physics_Data_Debug.ChartLimiterRow extraFilterRow06;
        private Physics_Data_Debug.ChartLimiterRow extraFilterRow07;
        private Physics_Data_Debug.ChartLimiterRow extraFilterRow08;
        private Physics_Data_Debug.ChartLimiterRow extraFilterRow09;
        private Physics_Data_Debug.ChartLimiterRow extraFilterRow10;

        private TableLayoutPanel settingsColumns;
        private Panel actionsPanel, SettingsProfilesHost;
        private Panel filterSettingsPanel;
        private TableLayoutPanel filterSettingsRows;
        private Button applyButton;
        private Button applyFiltersButton;
        private GroupBox chartStyleGroup;
        private TableLayoutPanel styleFields;
        private ComboBox schemeComboBox;
        private Panel schemeComboBoxRow;
        private Label schemeComboBoxLabel;
        private ComboBox chartTypeComboBox;
        private Panel chartTypeComboBoxRow;
        private Label chartTypeComboBoxLabel;
        private ComboBox markerComboBox;
        private Panel markerComboBoxRow;
        private Label markerComboBoxLabel;
        private NumericUpDown bandsNumeric;
        private Panel bandsNumericRow;
        private Label bandsNumericLabel;
        private NumericUpDown markerSizeNumeric;
        private Panel markerSizeNumericRow;
        private Label markerSizeNumericLabel;
        private NumericUpDown paletteAlphaNumeric;
        private Panel paletteAlphaNumericRow;
        private Label paletteAlphaNumericLabel;
        private NumericUpDown paletteDividerNumeric;
        private Panel paletteDividerNumericRow;
        private Label paletteDividerNumericLabel;
        private ComboBox backgroundComboBox;
        private Panel backgroundComboBoxRow;
        private Label backgroundComboBoxLabel;
        private Panel layoutComboBoxRow;
        private Label layoutComboBoxLabel;
        private CheckBox tooltipEnableCheckBox;
        private Panel tooltipEnableCheckBoxRow;
        private NumericUpDown tooltipDelayNumeric;
        private Panel tooltipDelayNumericRow;
        private Label tooltipDelayNumericLabel;
        private CheckBox absoluteCheckBox;
        private Panel absoluteCheckBoxRow;
        private GroupBox xAxisGroup;
        private TableLayoutPanel xFields;
        private ComboBox xColumnComboBox;
        private Panel xColumnComboBoxRow;
        private Label xColumnComboBoxLabel;
        private CheckBox xAutoCheckBox;
        private Panel xAutoCheckBoxRow;
        private TextBox xMinimumBox;
        private Panel xMinimumBoxRow;
        private Label xMinimumBoxLabel;
        private TextBox xMaximumBox;
        private Panel xMaximumBoxRow;
        private Label xMaximumBoxLabel;
        private TextBox xGridIntervalBox;
        private Panel xGridIntervalBoxRow;
        private Label xGridIntervalBoxLabel;
        private NumericUpDown xDecimalsNumeric;
        private Panel xDecimalsNumericRow;
        private Label xDecimalsNumericLabel;
        private CheckBox xMinorCheckBox;
        private Panel xMinorCheckBoxRow;
        private ComboBox xGridColorComboBox;
        private Panel xGridColorComboBoxRow;
        private Label xGridColorComboBoxLabel;
        private NumericUpDown xGridWidthNumeric;
        private Panel xGridWidthNumericRow;
        private Label xGridWidthNumericLabel;
        private ComboBox xMinorColorComboBox;
        private Panel xMinorColorComboBoxRow;
        private Label xMinorColorComboBoxLabel;
        private NumericUpDown xMinorWidthNumeric;
        private Panel xMinorWidthNumericRow;
        private Label xMinorWidthNumericLabel;
        private ComboBox xFontComboBox;
        private Panel xFontComboBoxRow;
        private Label xFontComboBoxLabel;
        private NumericUpDown xFontSizeNumeric;
        private Panel xFontSizeNumericRow;
        private Label xFontSizeNumericLabel;
        private CheckBox xLogCheckBox;
        private Panel xLogCheckBoxRow;
        private TextBox xLogBaseBox;
        private Panel xLogBaseBoxRow;
        private Label xLogBaseBoxLabel;
        private Button xDefaultsButton;
        private Panel xDefaultsButtonRow;
        private GroupBox yAxisGroup;
        private TableLayoutPanel yFields;
        private ComboBox yColumnComboBox;
        private Panel yColumnComboBoxRow;
        private Label yColumnComboBoxLabel;
        private CheckBox yAutoCheckBox;
        private Panel yAutoCheckBoxRow;
        private TextBox yMinimumBox;
        private Panel yMinimumBoxRow;
        private Label yMinimumBoxLabel;
        private TextBox yMaximumBox;
        private Panel yMaximumBoxRow;
        private Label yMaximumBoxLabel;
        private TextBox yGridIntervalBox;
        private Panel yGridIntervalBoxRow;
        private Label yGridIntervalBoxLabel;
        private NumericUpDown yDecimalsNumeric;
        private Panel yDecimalsNumericRow;
        private Label yDecimalsNumericLabel;
        private CheckBox yMinorCheckBox;
        private Panel yMinorCheckBoxRow;
        private ComboBox yGridColorComboBox;
        private Panel yGridColorComboBoxRow;
        private Label yGridColorComboBoxLabel;
        private NumericUpDown yGridWidthNumeric;
        private Panel yGridWidthNumericRow;
        private Label yGridWidthNumericLabel;
        private ComboBox yMinorColorComboBox;
        private Panel yMinorColorComboBoxRow;
        private Label yMinorColorComboBoxLabel;
        private NumericUpDown yMinorWidthNumeric;
        private Panel yMinorWidthNumericRow;
        private Label yMinorWidthNumericLabel;
        private ComboBox yFontComboBox;
        private Panel yFontComboBoxRow;
        private Label yFontComboBoxLabel;
        private NumericUpDown yFontSizeNumeric;
        private Panel yFontSizeNumericRow;
        private Label yFontSizeNumericLabel;
        private ComboBox yFontColorComboBox;
        private Panel yFontColorComboBoxRow;
        private Label yFontColorComboBoxLabel;
        private CheckBox yLogCheckBox;
        private Panel yLogCheckBoxRow;
        private TextBox yLogBaseBox;
        private Panel yLogBaseBoxRow;
        private Label yLogBaseBoxLabel;
        private Button yDefaultsButton;
        private Panel yDefaultsButtonRow;
        private GroupBox zAxisGroup;
        private TableLayoutPanel zFields;
        private ComboBox zColumnComboBox;
        private Panel zColumnComboBoxRow;
        private Label zColumnComboBoxLabel;
        private CheckBox zAutoCheckBox;
        private Panel zAutoCheckBoxRow;
        private TextBox zMinimumBox;
        private Panel zMinimumBoxRow;
        private Label zMinimumBoxLabel;
        private TextBox zMaximumBox;
        private Panel zMaximumBoxRow;
        private Label zMaximumBoxLabel;
        private Button zDefaultsButton;
        private Panel zDefaultsButtonRow;

        private CheckBox cursorEnabledCheckBox;
        private Panel cursorEnabledCheckBoxRow;
        private CheckBox cursorZoomCheckBox;
        private Panel cursorZoomCheckBoxRow;
        private ComboBox cursorColorComboBox;
        private Panel cursorColorComboBoxRow;
        private Label cursorColorComboBoxLabel;
        private NumericUpDown cursorAlphaNumeric;
        private Panel cursorAlphaNumericRow;
        private Label cursorAlphaNumericLabel;
        private NumericUpDown cursorWidthNumeric;
        private Panel cursorWidthNumericRow;
        private Label cursorWidthNumericLabel;
        private ComboBox cursorDashComboBox;
        private Panel cursorDashComboBoxRow;
        private Label cursorDashComboBoxLabel;
        private ComboBox xGridDashComboBox;
        private Panel xGridDashComboBoxRow;
        private Label xGridDashComboBoxLabel;
        private NumericUpDown xGridAlphaNumeric;
        private Panel xGridAlphaNumericRow;
        private Label xGridAlphaNumericLabel;
        private ComboBox xMinorDashComboBox;
        private Panel xMinorDashComboBoxRow;
        private Label xMinorDashComboBoxLabel;
        private NumericUpDown xMinorAlphaNumeric;
        private Panel xMinorAlphaNumericRow;
        private Label xMinorAlphaNumericLabel;
        private ComboBox yGridDashComboBox;
        private Panel yGridDashComboBoxRow;
        private Label yGridDashComboBoxLabel;
        private NumericUpDown yGridAlphaNumeric;
        private Panel yGridAlphaNumericRow;
        private Label yGridAlphaNumericLabel;
        private ComboBox yMinorDashComboBox;
        private Panel yMinorDashComboBoxRow;
        private Label yMinorDashComboBoxLabel;
        private NumericUpDown yMinorAlphaNumeric;
        private Panel yMinorAlphaNumericRow;
        private Label yMinorAlphaNumericLabel;

        private TableLayoutPanel styleChartLayoutRow;
        private TableLayoutPanel styleMarkerRow;
        private TableLayoutPanel styleAppearanceRow;
        private TableLayoutPanel styleOptionsRow;
        private TableLayoutPanel styleTogglesRow;
        private TableLayoutPanel styleCursorTogglesRow;
        private TableLayoutPanel styleCursorColorsRow;
        private TableLayoutPanel styleCursorStrokeRow;
        private TableLayoutPanel xModeRow;
        private TableLayoutPanel xLimitsRow;
        private TableLayoutPanel xTicksRow;
        private TableLayoutPanel xMajorGridRow;
        private TableLayoutPanel xMajorStyleRow;
        private TableLayoutPanel xMinorGridRow;
        private TableLayoutPanel xMinorStrokeRow;
        private TableLayoutPanel xMinorOpacityRow;
        private TableLayoutPanel xFontRow;
        private TableLayoutPanel yModeRow;
        private TableLayoutPanel yLimitsRow;
        private TableLayoutPanel yTicksRow;
        private TableLayoutPanel yMajorGridRow;
        private TableLayoutPanel yMajorStyleRow;
        private TableLayoutPanel yMinorGridRow;
        private TableLayoutPanel yMinorStrokeRow;
        private TableLayoutPanel yMinorOpacityRow;
        private TableLayoutPanel yFontRow;
        private TableLayoutPanel zLimitsRow;
        private TableLayoutPanel zColorRow;

        protected override void Dispose(bool disposing)
        {
            if (disposing) components?.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.actionsPanel = new System.Windows.Forms.Panel();
            this.applyButton = new System.Windows.Forms.Button();
            this.applyFiltersButton = new System.Windows.Forms.Button();
            this.SettingsProfilesHost = new System.Windows.Forms.Panel();
            this.settingsColumns = new System.Windows.Forms.TableLayoutPanel();
            this.chartStyleGroup = new System.Windows.Forms.GroupBox();
            this.styleFields = new System.Windows.Forms.TableLayoutPanel();
            this.styleChartLayoutRow = new System.Windows.Forms.TableLayoutPanel();
            this.chartTypeComboBoxRow = new System.Windows.Forms.Panel();
            this.chartTypeComboBoxLabel = new System.Windows.Forms.Label();
            this.chartTypeComboBox = new System.Windows.Forms.ComboBox();
            this.layoutComboBoxRow = new System.Windows.Forms.Panel();
            this.layoutComboBoxLabel = new System.Windows.Forms.Label();
            this.layoutComboBox = new System.Windows.Forms.ComboBox();
            this.styleMarkerRow = new System.Windows.Forms.TableLayoutPanel();
            this.markerComboBoxRow = new System.Windows.Forms.Panel();
            this.markerComboBoxLabel = new System.Windows.Forms.Label();
            this.markerComboBox = new System.Windows.Forms.ComboBox();
            this.markerSizeNumericRow = new System.Windows.Forms.Panel();
            this.markerSizeNumericLabel = new System.Windows.Forms.Label();
            this.markerSizeNumeric = new System.Windows.Forms.NumericUpDown();
            this.styleAppearanceRow = new System.Windows.Forms.TableLayoutPanel();
            this.backgroundComboBoxRow = new System.Windows.Forms.Panel();
            this.backgroundComboBoxLabel = new System.Windows.Forms.Label();
            this.backgroundComboBox = new System.Windows.Forms.ComboBox();
            this.paletteAlphaNumericRow = new System.Windows.Forms.Panel();
            this.paletteAlphaNumericLabel = new System.Windows.Forms.Label();
            this.paletteAlphaNumeric = new System.Windows.Forms.NumericUpDown();
            this.styleOptionsRow = new System.Windows.Forms.TableLayoutPanel();
            this.paletteDividerNumericRow = new System.Windows.Forms.Panel();
            this.paletteDividerNumericLabel = new System.Windows.Forms.Label();
            this.paletteDividerNumeric = new System.Windows.Forms.NumericUpDown();
            this.tooltipDelayNumericRow = new System.Windows.Forms.Panel();
            this.tooltipDelayNumericLabel = new System.Windows.Forms.Label();
            this.tooltipDelayNumeric = new System.Windows.Forms.NumericUpDown();
            this.styleTogglesRow = new System.Windows.Forms.TableLayoutPanel();
            this.absoluteCheckBoxRow = new System.Windows.Forms.Panel();
            this.absoluteCheckBox = new System.Windows.Forms.CheckBox();
            this.tooltipEnableCheckBoxRow = new System.Windows.Forms.Panel();
            this.tooltipEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.styleCursorTogglesRow = new System.Windows.Forms.TableLayoutPanel();
            this.cursorEnabledCheckBoxRow = new System.Windows.Forms.Panel();
            this.cursorEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.cursorZoomCheckBoxRow = new System.Windows.Forms.Panel();
            this.cursorZoomCheckBox = new System.Windows.Forms.CheckBox();
            this.styleCursorColorsRow = new System.Windows.Forms.TableLayoutPanel();
            this.cursorColorComboBoxRow = new System.Windows.Forms.Panel();
            this.cursorColorComboBoxLabel = new System.Windows.Forms.Label();
            this.cursorColorComboBox = new System.Windows.Forms.ComboBox();
            this.cursorAlphaNumericRow = new System.Windows.Forms.Panel();
            this.cursorAlphaNumericLabel = new System.Windows.Forms.Label();
            this.cursorAlphaNumeric = new System.Windows.Forms.NumericUpDown();
            this.styleCursorStrokeRow = new System.Windows.Forms.TableLayoutPanel();
            this.cursorWidthNumericRow = new System.Windows.Forms.Panel();
            this.cursorWidthNumericLabel = new System.Windows.Forms.Label();
            this.cursorWidthNumeric = new System.Windows.Forms.NumericUpDown();
            this.cursorDashComboBoxRow = new System.Windows.Forms.Panel();
            this.cursorDashComboBoxLabel = new System.Windows.Forms.Label();
            this.cursorDashComboBox = new System.Windows.Forms.ComboBox();
            this.xAxisGroup = new System.Windows.Forms.GroupBox();
            this.xFields = new System.Windows.Forms.TableLayoutPanel();
            this.xFontPropertiesRow = new System.Windows.Forms.TableLayoutPanel();
            this.xFontSizeNumericRow = new System.Windows.Forms.Panel();
            this.xFontSizeNumericLabel = new System.Windows.Forms.Label();
            this.xFontSizeNumeric = new System.Windows.Forms.NumericUpDown();
            this.xFontColorComboBoxRow = new System.Windows.Forms.Panel();
            this.xFontColorComboBoxLabel = new System.Windows.Forms.Label();
            this.xFontColorComboBox = new System.Windows.Forms.ComboBox();
            this.xDefaultsButtonRow = new System.Windows.Forms.Panel();
            this.xDefaultsButton = new System.Windows.Forms.Button();
            this.xColumnComboBoxRow = new System.Windows.Forms.Panel();
            this.xColumnComboBoxLabel = new System.Windows.Forms.Label();
            this.xColumnComboBox = new System.Windows.Forms.ComboBox();
            this.xModeRow = new System.Windows.Forms.TableLayoutPanel();
            this.xAutoCheckBoxRow = new System.Windows.Forms.Panel();
            this.xAutoCheckBox = new System.Windows.Forms.CheckBox();
            this.xLogCheckBoxRow = new System.Windows.Forms.Panel();
            this.xLogCheckBox = new System.Windows.Forms.CheckBox();
            this.xLimitsRow = new System.Windows.Forms.TableLayoutPanel();
            this.xMinimumBoxRow = new System.Windows.Forms.Panel();
            this.xMinimumBoxLabel = new System.Windows.Forms.Label();
            this.xMinimumBox = new System.Windows.Forms.TextBox();
            this.xMaximumBoxRow = new System.Windows.Forms.Panel();
            this.xMaximumBoxLabel = new System.Windows.Forms.Label();
            this.xMaximumBox = new System.Windows.Forms.TextBox();
            this.xTicksRow = new System.Windows.Forms.TableLayoutPanel();
            this.xGridIntervalBoxRow = new System.Windows.Forms.Panel();
            this.xGridIntervalBoxLabel = new System.Windows.Forms.Label();
            this.xGridIntervalBox = new System.Windows.Forms.TextBox();
            this.xDecimalsNumericRow = new System.Windows.Forms.Panel();
            this.xDecimalsNumericLabel = new System.Windows.Forms.Label();
            this.xDecimalsNumeric = new System.Windows.Forms.NumericUpDown();
            this.xMajorGridRow = new System.Windows.Forms.TableLayoutPanel();
            this.xGridColorComboBoxRow = new System.Windows.Forms.Panel();
            this.xGridColorComboBoxLabel = new System.Windows.Forms.Label();
            this.xGridColorComboBox = new System.Windows.Forms.ComboBox();
            this.xGridWidthNumericRow = new System.Windows.Forms.Panel();
            this.xGridWidthNumericLabel = new System.Windows.Forms.Label();
            this.xGridWidthNumeric = new System.Windows.Forms.NumericUpDown();
            this.xMajorStyleRow = new System.Windows.Forms.TableLayoutPanel();
            this.xGridDashComboBoxRow = new System.Windows.Forms.Panel();
            this.xGridDashComboBoxLabel = new System.Windows.Forms.Label();
            this.xGridDashComboBox = new System.Windows.Forms.ComboBox();
            this.xGridAlphaNumericRow = new System.Windows.Forms.Panel();
            this.xGridAlphaNumericLabel = new System.Windows.Forms.Label();
            this.xGridAlphaNumeric = new System.Windows.Forms.NumericUpDown();
            this.xMinorGridRow = new System.Windows.Forms.TableLayoutPanel();
            this.xMinorCheckBoxRow = new System.Windows.Forms.Panel();
            this.xMinorCheckBox = new System.Windows.Forms.CheckBox();
            this.xMinorColorComboBoxRow = new System.Windows.Forms.Panel();
            this.xMinorColorComboBoxLabel = new System.Windows.Forms.Label();
            this.xMinorColorComboBox = new System.Windows.Forms.ComboBox();
            this.xMinorStrokeRow = new System.Windows.Forms.TableLayoutPanel();
            this.xMinorWidthNumericRow = new System.Windows.Forms.Panel();
            this.xMinorWidthNumericLabel = new System.Windows.Forms.Label();
            this.xMinorWidthNumeric = new System.Windows.Forms.NumericUpDown();
            this.xMinorDashComboBoxRow = new System.Windows.Forms.Panel();
            this.xMinorDashComboBoxLabel = new System.Windows.Forms.Label();
            this.xMinorDashComboBox = new System.Windows.Forms.ComboBox();
            this.xMinorOpacityRow = new System.Windows.Forms.TableLayoutPanel();
            this.xMinorAlphaNumericRow = new System.Windows.Forms.Panel();
            this.xMinorAlphaNumericLabel = new System.Windows.Forms.Label();
            this.xMinorAlphaNumeric = new System.Windows.Forms.NumericUpDown();
            this.xLogBaseBoxRow = new System.Windows.Forms.Panel();
            this.xLogBaseBoxLabel = new System.Windows.Forms.Label();
            this.xLogBaseBox = new System.Windows.Forms.TextBox();
            this.xFontRow = new System.Windows.Forms.TableLayoutPanel();
            this.xFontComboBoxRow = new System.Windows.Forms.Panel();
            this.xFontComboBoxLabel = new System.Windows.Forms.Label();
            this.xFontComboBox = new System.Windows.Forms.ComboBox();
            this.yAxisGroup = new System.Windows.Forms.GroupBox();
            this.yFields = new System.Windows.Forms.TableLayoutPanel();
            this.yFontColorRow = new System.Windows.Forms.TableLayoutPanel();
            this.yFontSizeNumericRow = new System.Windows.Forms.Panel();
            this.yFontSizeNumericLabel = new System.Windows.Forms.Label();
            this.yFontSizeNumeric = new System.Windows.Forms.NumericUpDown();
            this.yFontColorComboBoxRow = new System.Windows.Forms.Panel();
            this.yFontColorComboBoxLabel = new System.Windows.Forms.Label();
            this.yFontColorComboBox = new System.Windows.Forms.ComboBox();
            this.yDefaultsButtonRow = new System.Windows.Forms.Panel();
            this.yDefaultsButton = new System.Windows.Forms.Button();
            this.yColumnComboBoxRow = new System.Windows.Forms.Panel();
            this.yColumnComboBoxLabel = new System.Windows.Forms.Label();
            this.yColumnComboBox = new System.Windows.Forms.ComboBox();
            this.yModeRow = new System.Windows.Forms.TableLayoutPanel();
            this.yAutoCheckBoxRow = new System.Windows.Forms.Panel();
            this.yAutoCheckBox = new System.Windows.Forms.CheckBox();
            this.yLogCheckBoxRow = new System.Windows.Forms.Panel();
            this.yLogCheckBox = new System.Windows.Forms.CheckBox();
            this.yLimitsRow = new System.Windows.Forms.TableLayoutPanel();
            this.yMinimumBoxRow = new System.Windows.Forms.Panel();
            this.yMinimumBoxLabel = new System.Windows.Forms.Label();
            this.yMinimumBox = new System.Windows.Forms.TextBox();
            this.yMaximumBoxRow = new System.Windows.Forms.Panel();
            this.yMaximumBoxLabel = new System.Windows.Forms.Label();
            this.yMaximumBox = new System.Windows.Forms.TextBox();
            this.yTicksRow = new System.Windows.Forms.TableLayoutPanel();
            this.yGridIntervalBoxRow = new System.Windows.Forms.Panel();
            this.yGridIntervalBoxLabel = new System.Windows.Forms.Label();
            this.yGridIntervalBox = new System.Windows.Forms.TextBox();
            this.yDecimalsNumericRow = new System.Windows.Forms.Panel();
            this.yDecimalsNumericLabel = new System.Windows.Forms.Label();
            this.yDecimalsNumeric = new System.Windows.Forms.NumericUpDown();
            this.yMajorGridRow = new System.Windows.Forms.TableLayoutPanel();
            this.yGridColorComboBoxRow = new System.Windows.Forms.Panel();
            this.yGridColorComboBoxLabel = new System.Windows.Forms.Label();
            this.yGridColorComboBox = new System.Windows.Forms.ComboBox();
            this.yGridWidthNumericRow = new System.Windows.Forms.Panel();
            this.yGridWidthNumericLabel = new System.Windows.Forms.Label();
            this.yGridWidthNumeric = new System.Windows.Forms.NumericUpDown();
            this.yMajorStyleRow = new System.Windows.Forms.TableLayoutPanel();
            this.yGridDashComboBoxRow = new System.Windows.Forms.Panel();
            this.yGridDashComboBoxLabel = new System.Windows.Forms.Label();
            this.yGridDashComboBox = new System.Windows.Forms.ComboBox();
            this.yGridAlphaNumericRow = new System.Windows.Forms.Panel();
            this.yGridAlphaNumericLabel = new System.Windows.Forms.Label();
            this.yGridAlphaNumeric = new System.Windows.Forms.NumericUpDown();
            this.yMinorGridRow = new System.Windows.Forms.TableLayoutPanel();
            this.yMinorCheckBoxRow = new System.Windows.Forms.Panel();
            this.yMinorCheckBox = new System.Windows.Forms.CheckBox();
            this.yMinorColorComboBoxRow = new System.Windows.Forms.Panel();
            this.yMinorColorComboBoxLabel = new System.Windows.Forms.Label();
            this.yMinorColorComboBox = new System.Windows.Forms.ComboBox();
            this.yMinorStrokeRow = new System.Windows.Forms.TableLayoutPanel();
            this.yMinorWidthNumericRow = new System.Windows.Forms.Panel();
            this.yMinorWidthNumericLabel = new System.Windows.Forms.Label();
            this.yMinorWidthNumeric = new System.Windows.Forms.NumericUpDown();
            this.yMinorDashComboBoxRow = new System.Windows.Forms.Panel();
            this.yMinorDashComboBoxLabel = new System.Windows.Forms.Label();
            this.yMinorDashComboBox = new System.Windows.Forms.ComboBox();
            this.yMinorOpacityRow = new System.Windows.Forms.TableLayoutPanel();
            this.yMinorAlphaNumericRow = new System.Windows.Forms.Panel();
            this.yMinorAlphaNumericLabel = new System.Windows.Forms.Label();
            this.yMinorAlphaNumeric = new System.Windows.Forms.NumericUpDown();
            this.yLogBaseBoxRow = new System.Windows.Forms.Panel();
            this.yLogBaseBoxLabel = new System.Windows.Forms.Label();
            this.yLogBaseBox = new System.Windows.Forms.TextBox();
            this.yFontRow = new System.Windows.Forms.TableLayoutPanel();
            this.yFontComboBoxRow = new System.Windows.Forms.Panel();
            this.yFontComboBoxLabel = new System.Windows.Forms.Label();
            this.yFontComboBox = new System.Windows.Forms.ComboBox();
            this.zAxisGroup = new System.Windows.Forms.GroupBox();
            this.zFields = new System.Windows.Forms.TableLayoutPanel();
            this.zDefaultsButtonRow = new System.Windows.Forms.Panel();
            this.zDefaultsButton = new System.Windows.Forms.Button();
            this.zColumnComboBoxRow = new System.Windows.Forms.Panel();
            this.zColumnComboBoxLabel = new System.Windows.Forms.Label();
            this.zColumnComboBox = new System.Windows.Forms.ComboBox();
            this.zAutoCheckBoxRow = new System.Windows.Forms.Panel();
            this.zAutoCheckBox = new System.Windows.Forms.CheckBox();
            this.zLimitsRow = new System.Windows.Forms.TableLayoutPanel();
            this.zMinimumBoxRow = new System.Windows.Forms.Panel();
            this.zMinimumBoxLabel = new System.Windows.Forms.Label();
            this.zMinimumBox = new System.Windows.Forms.TextBox();
            this.zMaximumBoxRow = new System.Windows.Forms.Panel();
            this.zMaximumBoxLabel = new System.Windows.Forms.Label();
            this.zMaximumBox = new System.Windows.Forms.TextBox();
            this.zColorRow = new System.Windows.Forms.TableLayoutPanel();
            this.schemeComboBoxRow = new System.Windows.Forms.Panel();
            this.schemeComboBoxLabel = new System.Windows.Forms.Label();
            this.schemeComboBox = new System.Windows.Forms.ComboBox();
            this.bandsNumericRow = new System.Windows.Forms.Panel();
            this.bandsNumericLabel = new System.Windows.Forms.Label();
            this.bandsNumeric = new System.Windows.Forms.NumericUpDown();
            this.filterSettingsPanel = new System.Windows.Forms.Panel();
            this.filterSettingsRows = new System.Windows.Forms.TableLayoutPanel();
            this.axisFiltersGroup = new System.Windows.Forms.GroupBox();
            this.axisFiltersFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.axisXFilterRow = new Physics_Data_Debug.ChartLimiterRow();
            this.axisYFilterRow = new Physics_Data_Debug.ChartLimiterRow();
            this.axisZFilterRow = new Physics_Data_Debug.ChartLimiterRow();
            this.extraFiltersGroup = new System.Windows.Forms.GroupBox();
            this.extraFiltersFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.extraFilterRow01 = new Physics_Data_Debug.ChartLimiterRow();
            this.extraFilterRow02 = new Physics_Data_Debug.ChartLimiterRow();
            this.extraFilterRow03 = new Physics_Data_Debug.ChartLimiterRow();
            this.extraFilterRow04 = new Physics_Data_Debug.ChartLimiterRow();
            this.extraFilterRow05 = new Physics_Data_Debug.ChartLimiterRow();
            this.extraFilterRow06 = new Physics_Data_Debug.ChartLimiterRow();
            this.extraFilterRow07 = new Physics_Data_Debug.ChartLimiterRow();
            this.extraFilterRow08 = new Physics_Data_Debug.ChartLimiterRow();
            this.extraFilterRow09 = new Physics_Data_Debug.ChartLimiterRow();
            this.extraFilterRow10 = new Physics_Data_Debug.ChartLimiterRow();
            this.actionsPanel.SuspendLayout();
            this.settingsColumns.SuspendLayout();
            this.chartStyleGroup.SuspendLayout();
            this.styleFields.SuspendLayout();
            this.styleChartLayoutRow.SuspendLayout();
            this.chartTypeComboBoxRow.SuspendLayout();
            this.layoutComboBoxRow.SuspendLayout();
            this.styleMarkerRow.SuspendLayout();
            this.markerComboBoxRow.SuspendLayout();
            this.markerSizeNumericRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.markerSizeNumeric)).BeginInit();
            this.styleAppearanceRow.SuspendLayout();
            this.backgroundComboBoxRow.SuspendLayout();
            this.paletteAlphaNumericRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paletteAlphaNumeric)).BeginInit();
            this.styleOptionsRow.SuspendLayout();
            this.paletteDividerNumericRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paletteDividerNumeric)).BeginInit();
            this.tooltipDelayNumericRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tooltipDelayNumeric)).BeginInit();
            this.styleTogglesRow.SuspendLayout();
            this.absoluteCheckBoxRow.SuspendLayout();
            this.tooltipEnableCheckBoxRow.SuspendLayout();
            this.styleCursorTogglesRow.SuspendLayout();
            this.cursorEnabledCheckBoxRow.SuspendLayout();
            this.cursorZoomCheckBoxRow.SuspendLayout();
            this.styleCursorColorsRow.SuspendLayout();
            this.cursorColorComboBoxRow.SuspendLayout();
            this.cursorAlphaNumericRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cursorAlphaNumeric)).BeginInit();
            this.styleCursorStrokeRow.SuspendLayout();
            this.cursorWidthNumericRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cursorWidthNumeric)).BeginInit();
            this.cursorDashComboBoxRow.SuspendLayout();
            this.xAxisGroup.SuspendLayout();
            this.xFields.SuspendLayout();
            this.xFontPropertiesRow.SuspendLayout();
            this.xFontSizeNumericRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xFontSizeNumeric)).BeginInit();
            this.xFontColorComboBoxRow.SuspendLayout();
            this.xDefaultsButtonRow.SuspendLayout();
            this.xColumnComboBoxRow.SuspendLayout();
            this.xModeRow.SuspendLayout();
            this.xAutoCheckBoxRow.SuspendLayout();
            this.xLogCheckBoxRow.SuspendLayout();
            this.xLimitsRow.SuspendLayout();
            this.xMinimumBoxRow.SuspendLayout();
            this.xMaximumBoxRow.SuspendLayout();
            this.xTicksRow.SuspendLayout();
            this.xGridIntervalBoxRow.SuspendLayout();
            this.xDecimalsNumericRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xDecimalsNumeric)).BeginInit();
            this.xMajorGridRow.SuspendLayout();
            this.xGridColorComboBoxRow.SuspendLayout();
            this.xGridWidthNumericRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xGridWidthNumeric)).BeginInit();
            this.xMajorStyleRow.SuspendLayout();
            this.xGridDashComboBoxRow.SuspendLayout();
            this.xGridAlphaNumericRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xGridAlphaNumeric)).BeginInit();
            this.xMinorGridRow.SuspendLayout();
            this.xMinorCheckBoxRow.SuspendLayout();
            this.xMinorColorComboBoxRow.SuspendLayout();
            this.xMinorStrokeRow.SuspendLayout();
            this.xMinorWidthNumericRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xMinorWidthNumeric)).BeginInit();
            this.xMinorDashComboBoxRow.SuspendLayout();
            this.xMinorOpacityRow.SuspendLayout();
            this.xMinorAlphaNumericRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xMinorAlphaNumeric)).BeginInit();
            this.xLogBaseBoxRow.SuspendLayout();
            this.xFontRow.SuspendLayout();
            this.xFontComboBoxRow.SuspendLayout();
            this.yAxisGroup.SuspendLayout();
            this.yFields.SuspendLayout();
            this.yFontColorRow.SuspendLayout();
            this.yFontSizeNumericRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yFontSizeNumeric)).BeginInit();
            this.yFontColorComboBoxRow.SuspendLayout();
            this.yDefaultsButtonRow.SuspendLayout();
            this.yColumnComboBoxRow.SuspendLayout();
            this.yModeRow.SuspendLayout();
            this.yAutoCheckBoxRow.SuspendLayout();
            this.yLogCheckBoxRow.SuspendLayout();
            this.yLimitsRow.SuspendLayout();
            this.yMinimumBoxRow.SuspendLayout();
            this.yMaximumBoxRow.SuspendLayout();
            this.yTicksRow.SuspendLayout();
            this.yGridIntervalBoxRow.SuspendLayout();
            this.yDecimalsNumericRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yDecimalsNumeric)).BeginInit();
            this.yMajorGridRow.SuspendLayout();
            this.yGridColorComboBoxRow.SuspendLayout();
            this.yGridWidthNumericRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yGridWidthNumeric)).BeginInit();
            this.yMajorStyleRow.SuspendLayout();
            this.yGridDashComboBoxRow.SuspendLayout();
            this.yGridAlphaNumericRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yGridAlphaNumeric)).BeginInit();
            this.yMinorGridRow.SuspendLayout();
            this.yMinorCheckBoxRow.SuspendLayout();
            this.yMinorColorComboBoxRow.SuspendLayout();
            this.yMinorStrokeRow.SuspendLayout();
            this.yMinorWidthNumericRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yMinorWidthNumeric)).BeginInit();
            this.yMinorDashComboBoxRow.SuspendLayout();
            this.yMinorOpacityRow.SuspendLayout();
            this.yMinorAlphaNumericRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yMinorAlphaNumeric)).BeginInit();
            this.yLogBaseBoxRow.SuspendLayout();
            this.yFontRow.SuspendLayout();
            this.yFontComboBoxRow.SuspendLayout();
            this.zAxisGroup.SuspendLayout();
            this.zFields.SuspendLayout();
            this.zDefaultsButtonRow.SuspendLayout();
            this.zColumnComboBoxRow.SuspendLayout();
            this.zAutoCheckBoxRow.SuspendLayout();
            this.zLimitsRow.SuspendLayout();
            this.zMinimumBoxRow.SuspendLayout();
            this.zMaximumBoxRow.SuspendLayout();
            this.zColorRow.SuspendLayout();
            this.schemeComboBoxRow.SuspendLayout();
            this.bandsNumericRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bandsNumeric)).BeginInit();
            this.filterSettingsPanel.SuspendLayout();
            this.filterSettingsRows.SuspendLayout();
            this.axisFiltersGroup.SuspendLayout();
            this.axisFiltersFlow.SuspendLayout();
            this.extraFiltersGroup.SuspendLayout();
            this.extraFiltersFlow.SuspendLayout();
            this.SuspendLayout();
            // 
            // actionsPanel
            // 
            this.actionsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.actionsPanel.Controls.Add(this.applyButton);
            this.actionsPanel.Controls.Add(this.applyFiltersButton);
            this.actionsPanel.Controls.Add(this.SettingsProfilesHost);
            this.actionsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.actionsPanel.Location = new System.Drawing.Point(0, 0);
            this.actionsPanel.Name = "actionsPanel";
            this.actionsPanel.Size = new System.Drawing.Size(1385, 35);
            this.actionsPanel.TabIndex = 2;
            // 
            // applyButton
            // 
            this.applyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.applyButton.ForeColor = System.Drawing.Color.White;
            this.applyButton.Location = new System.Drawing.Point(10, 2);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(135, 30);
            this.applyButton.TabIndex = 0;
            this.applyButton.Text = "Apply Settings";
            this.applyButton.UseVisualStyleBackColor = false;
            // 
            // applyFiltersButton
            // 
            this.applyFiltersButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.applyFiltersButton.ForeColor = System.Drawing.Color.White;
            this.applyFiltersButton.Location = new System.Drawing.Point(151, 2);
            this.applyFiltersButton.Name = "applyFiltersButton";
            this.applyFiltersButton.Size = new System.Drawing.Size(133, 30);
            this.applyFiltersButton.TabIndex = 1;
            this.applyFiltersButton.Text = "Apply Filters";
            this.applyFiltersButton.UseVisualStyleBackColor = false;
            // 
            // SettingsProfilesHost
            // 
            this.SettingsProfilesHost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.SettingsProfilesHost.Location = new System.Drawing.Point(295, 0);
            this.SettingsProfilesHost.Name = "SettingsProfilesHost";
            this.SettingsProfilesHost.Size = new System.Drawing.Size(140, 32);
            this.SettingsProfilesHost.TabIndex = 2;
            // 
            // settingsColumns
            // 
            this.settingsColumns.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.settingsColumns.ColumnCount = 4;
            this.settingsColumns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26F));
            this.settingsColumns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.settingsColumns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.settingsColumns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.settingsColumns.Controls.Add(this.chartStyleGroup, 0, 0);
            this.settingsColumns.Controls.Add(this.xAxisGroup, 1, 0);
            this.settingsColumns.Controls.Add(this.yAxisGroup, 2, 0);
            this.settingsColumns.Controls.Add(this.zAxisGroup, 3, 0);
            this.settingsColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsColumns.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.settingsColumns.Location = new System.Drawing.Point(0, 390);
            this.settingsColumns.Name = "settingsColumns";
            this.settingsColumns.Padding = new System.Windows.Forms.Padding(8);
            this.settingsColumns.RowCount = 1;
            this.settingsColumns.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 330F));
            this.settingsColumns.Size = new System.Drawing.Size(1385, 471);
            this.settingsColumns.TabIndex = 0;
            // 
            // chartStyleGroup
            // 
            this.chartStyleGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.chartStyleGroup.Controls.Add(this.styleFields);
            this.chartStyleGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartStyleGroup.ForeColor = System.Drawing.Color.White;
            this.chartStyleGroup.Location = new System.Drawing.Point(13, 13);
            this.chartStyleGroup.Margin = new System.Windows.Forms.Padding(5);
            this.chartStyleGroup.Name = "chartStyleGroup";
            this.chartStyleGroup.Padding = new System.Windows.Forms.Padding(2);
            this.chartStyleGroup.Size = new System.Drawing.Size(345, 445);
            this.chartStyleGroup.TabIndex = 0;
            this.chartStyleGroup.TabStop = false;
            this.chartStyleGroup.Text = "Chart and data settings";
            // 
            // styleFields
            // 
            this.styleFields.AutoScroll = true;
            this.styleFields.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.styleFields.ColumnCount = 1;
            this.styleFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.styleFields.Controls.Add(this.styleChartLayoutRow, 0, 0);
            this.styleFields.Controls.Add(this.styleMarkerRow, 0, 1);
            this.styleFields.Controls.Add(this.styleAppearanceRow, 0, 2);
            this.styleFields.Controls.Add(this.styleOptionsRow, 0, 3);
            this.styleFields.Controls.Add(this.styleTogglesRow, 0, 4);
            this.styleFields.Controls.Add(this.styleCursorTogglesRow, 0, 5);
            this.styleFields.Controls.Add(this.styleCursorColorsRow, 0, 6);
            this.styleFields.Controls.Add(this.styleCursorStrokeRow, 0, 7);
            this.styleFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.styleFields.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.styleFields.Location = new System.Drawing.Point(2, 15);
            this.styleFields.Name = "styleFields";
            this.styleFields.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.styleFields.RowCount = 8;
            this.styleFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.styleFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.styleFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.styleFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.styleFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.styleFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.styleFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.styleFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.styleFields.Size = new System.Drawing.Size(341, 428);
            this.styleFields.TabIndex = 0;
            // 
            // styleChartLayoutRow
            // 
            this.styleChartLayoutRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.styleChartLayoutRow.ColumnCount = 2;
            this.styleChartLayoutRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.styleChartLayoutRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.styleChartLayoutRow.Controls.Add(this.chartTypeComboBoxRow, 0, 0);
            this.styleChartLayoutRow.Controls.Add(this.layoutComboBoxRow, 1, 0);
            this.styleChartLayoutRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.styleChartLayoutRow.Location = new System.Drawing.Point(3, 0);
            this.styleChartLayoutRow.Margin = new System.Windows.Forms.Padding(0);
            this.styleChartLayoutRow.Name = "styleChartLayoutRow";
            this.styleChartLayoutRow.RowCount = 1;
            this.styleChartLayoutRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.styleChartLayoutRow.Size = new System.Drawing.Size(335, 45);
            this.styleChartLayoutRow.TabIndex = 0;
            // 
            // chartTypeComboBoxRow
            // 
            this.chartTypeComboBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.chartTypeComboBoxRow.Controls.Add(this.chartTypeComboBoxLabel);
            this.chartTypeComboBoxRow.Controls.Add(this.chartTypeComboBox);
            this.chartTypeComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartTypeComboBoxRow.Location = new System.Drawing.Point(0, 0);
            this.chartTypeComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.chartTypeComboBoxRow.Name = "chartTypeComboBoxRow";
            this.chartTypeComboBoxRow.Size = new System.Drawing.Size(167, 45);
            this.chartTypeComboBoxRow.TabIndex = 0;
            // 
            // chartTypeComboBoxLabel
            // 
            this.chartTypeComboBoxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartTypeComboBoxLabel.ForeColor = System.Drawing.Color.White;
            this.chartTypeComboBoxLabel.Location = new System.Drawing.Point(2, 2);
            this.chartTypeComboBoxLabel.Name = "chartTypeComboBoxLabel";
            this.chartTypeComboBoxLabel.Size = new System.Drawing.Size(149, 15);
            this.chartTypeComboBoxLabel.TabIndex = 0;
            this.chartTypeComboBoxLabel.Text = "Chart type";
            // 
            // chartTypeComboBox
            // 
            this.chartTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartTypeComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.chartTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chartTypeComboBox.ForeColor = System.Drawing.Color.White;
            this.chartTypeComboBox.IntegralHeight = false;
            this.chartTypeComboBox.Location = new System.Drawing.Point(2, 20);
            this.chartTypeComboBox.Name = "chartTypeComboBox";
            this.chartTypeComboBox.Size = new System.Drawing.Size(162, 21);
            this.chartTypeComboBox.TabIndex = 1;
            // 
            // layoutComboBoxRow
            // 
            this.layoutComboBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.layoutComboBoxRow.Controls.Add(this.layoutComboBoxLabel);
            this.layoutComboBoxRow.Controls.Add(this.layoutComboBox);
            this.layoutComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutComboBoxRow.Location = new System.Drawing.Point(167, 0);
            this.layoutComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.layoutComboBoxRow.Name = "layoutComboBoxRow";
            this.layoutComboBoxRow.Size = new System.Drawing.Size(168, 45);
            this.layoutComboBoxRow.TabIndex = 1;
            // 
            // layoutComboBoxLabel
            // 
            this.layoutComboBoxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutComboBoxLabel.ForeColor = System.Drawing.Color.White;
            this.layoutComboBoxLabel.Location = new System.Drawing.Point(2, 2);
            this.layoutComboBoxLabel.Name = "layoutComboBoxLabel";
            this.layoutComboBoxLabel.Size = new System.Drawing.Size(149, 15);
            this.layoutComboBoxLabel.TabIndex = 0;
            this.layoutComboBoxLabel.Text = "Dataset layout";
            // 
            // layoutComboBox
            // 
            this.layoutComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.layoutComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.layoutComboBox.ForeColor = System.Drawing.Color.White;
            this.layoutComboBox.IntegralHeight = false;
            this.layoutComboBox.Location = new System.Drawing.Point(2, 20);
            this.layoutComboBox.Name = "layoutComboBox";
            this.layoutComboBox.Size = new System.Drawing.Size(163, 21);
            this.layoutComboBox.TabIndex = 1;
            // 
            // styleMarkerRow
            // 
            this.styleMarkerRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.styleMarkerRow.ColumnCount = 2;
            this.styleMarkerRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.styleMarkerRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.styleMarkerRow.Controls.Add(this.markerComboBoxRow, 0, 0);
            this.styleMarkerRow.Controls.Add(this.markerSizeNumericRow, 1, 0);
            this.styleMarkerRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.styleMarkerRow.Location = new System.Drawing.Point(3, 45);
            this.styleMarkerRow.Margin = new System.Windows.Forms.Padding(0);
            this.styleMarkerRow.Name = "styleMarkerRow";
            this.styleMarkerRow.RowCount = 1;
            this.styleMarkerRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.styleMarkerRow.Size = new System.Drawing.Size(335, 45);
            this.styleMarkerRow.TabIndex = 1;
            // 
            // markerComboBoxRow
            // 
            this.markerComboBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.markerComboBoxRow.Controls.Add(this.markerComboBoxLabel);
            this.markerComboBoxRow.Controls.Add(this.markerComboBox);
            this.markerComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.markerComboBoxRow.Location = new System.Drawing.Point(0, 0);
            this.markerComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.markerComboBoxRow.Name = "markerComboBoxRow";
            this.markerComboBoxRow.Size = new System.Drawing.Size(167, 45);
            this.markerComboBoxRow.TabIndex = 0;
            // 
            // markerComboBoxLabel
            // 
            this.markerComboBoxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.markerComboBoxLabel.ForeColor = System.Drawing.Color.White;
            this.markerComboBoxLabel.Location = new System.Drawing.Point(2, 2);
            this.markerComboBoxLabel.Name = "markerComboBoxLabel";
            this.markerComboBoxLabel.Size = new System.Drawing.Size(149, 15);
            this.markerComboBoxLabel.TabIndex = 0;
            this.markerComboBoxLabel.Text = "Marker style";
            // 
            // markerComboBox
            // 
            this.markerComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.markerComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.markerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.markerComboBox.ForeColor = System.Drawing.Color.White;
            this.markerComboBox.IntegralHeight = false;
            this.markerComboBox.Location = new System.Drawing.Point(2, 20);
            this.markerComboBox.Name = "markerComboBox";
            this.markerComboBox.Size = new System.Drawing.Size(162, 21);
            this.markerComboBox.TabIndex = 1;
            // 
            // markerSizeNumericRow
            // 
            this.markerSizeNumericRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.markerSizeNumericRow.Controls.Add(this.markerSizeNumericLabel);
            this.markerSizeNumericRow.Controls.Add(this.markerSizeNumeric);
            this.markerSizeNumericRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.markerSizeNumericRow.Location = new System.Drawing.Point(167, 0);
            this.markerSizeNumericRow.Margin = new System.Windows.Forms.Padding(0);
            this.markerSizeNumericRow.Name = "markerSizeNumericRow";
            this.markerSizeNumericRow.Size = new System.Drawing.Size(168, 45);
            this.markerSizeNumericRow.TabIndex = 1;
            // 
            // markerSizeNumericLabel
            // 
            this.markerSizeNumericLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.markerSizeNumericLabel.ForeColor = System.Drawing.Color.White;
            this.markerSizeNumericLabel.Location = new System.Drawing.Point(2, 2);
            this.markerSizeNumericLabel.Name = "markerSizeNumericLabel";
            this.markerSizeNumericLabel.Size = new System.Drawing.Size(149, 15);
            this.markerSizeNumericLabel.TabIndex = 0;
            this.markerSizeNumericLabel.Text = "Marker size";
            // 
            // markerSizeNumeric
            // 
            this.markerSizeNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.markerSizeNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.markerSizeNumeric.ForeColor = System.Drawing.Color.White;
            this.markerSizeNumeric.Location = new System.Drawing.Point(2, 20);
            this.markerSizeNumeric.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.markerSizeNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.markerSizeNumeric.Name = "markerSizeNumeric";
            this.markerSizeNumeric.Size = new System.Drawing.Size(163, 20);
            this.markerSizeNumeric.TabIndex = 1;
            this.markerSizeNumeric.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // styleAppearanceRow
            // 
            this.styleAppearanceRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.styleAppearanceRow.ColumnCount = 2;
            this.styleAppearanceRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.styleAppearanceRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.styleAppearanceRow.Controls.Add(this.backgroundComboBoxRow, 0, 0);
            this.styleAppearanceRow.Controls.Add(this.paletteAlphaNumericRow, 1, 0);
            this.styleAppearanceRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.styleAppearanceRow.Location = new System.Drawing.Point(3, 90);
            this.styleAppearanceRow.Margin = new System.Windows.Forms.Padding(0);
            this.styleAppearanceRow.Name = "styleAppearanceRow";
            this.styleAppearanceRow.RowCount = 1;
            this.styleAppearanceRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.styleAppearanceRow.Size = new System.Drawing.Size(335, 45);
            this.styleAppearanceRow.TabIndex = 2;
            // 
            // backgroundComboBoxRow
            // 
            this.backgroundComboBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.backgroundComboBoxRow.Controls.Add(this.backgroundComboBoxLabel);
            this.backgroundComboBoxRow.Controls.Add(this.backgroundComboBox);
            this.backgroundComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backgroundComboBoxRow.Location = new System.Drawing.Point(0, 0);
            this.backgroundComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.backgroundComboBoxRow.Name = "backgroundComboBoxRow";
            this.backgroundComboBoxRow.Size = new System.Drawing.Size(167, 45);
            this.backgroundComboBoxRow.TabIndex = 0;
            // 
            // backgroundComboBoxLabel
            // 
            this.backgroundComboBoxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.backgroundComboBoxLabel.ForeColor = System.Drawing.Color.White;
            this.backgroundComboBoxLabel.Location = new System.Drawing.Point(2, 2);
            this.backgroundComboBoxLabel.Name = "backgroundComboBoxLabel";
            this.backgroundComboBoxLabel.Size = new System.Drawing.Size(149, 15);
            this.backgroundComboBoxLabel.TabIndex = 0;
            this.backgroundComboBoxLabel.Text = "Chart background";
            // 
            // backgroundComboBox
            // 
            this.backgroundComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.backgroundComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.backgroundComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.backgroundComboBox.ForeColor = System.Drawing.Color.White;
            this.backgroundComboBox.IntegralHeight = false;
            this.backgroundComboBox.Location = new System.Drawing.Point(2, 20);
            this.backgroundComboBox.Name = "backgroundComboBox";
            this.backgroundComboBox.Size = new System.Drawing.Size(162, 21);
            this.backgroundComboBox.TabIndex = 1;
            // 
            // paletteAlphaNumericRow
            // 
            this.paletteAlphaNumericRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.paletteAlphaNumericRow.Controls.Add(this.paletteAlphaNumericLabel);
            this.paletteAlphaNumericRow.Controls.Add(this.paletteAlphaNumeric);
            this.paletteAlphaNumericRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paletteAlphaNumericRow.Location = new System.Drawing.Point(167, 0);
            this.paletteAlphaNumericRow.Margin = new System.Windows.Forms.Padding(0);
            this.paletteAlphaNumericRow.Name = "paletteAlphaNumericRow";
            this.paletteAlphaNumericRow.Size = new System.Drawing.Size(168, 45);
            this.paletteAlphaNumericRow.TabIndex = 1;
            // 
            // paletteAlphaNumericLabel
            // 
            this.paletteAlphaNumericLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paletteAlphaNumericLabel.ForeColor = System.Drawing.Color.White;
            this.paletteAlphaNumericLabel.Location = new System.Drawing.Point(2, 2);
            this.paletteAlphaNumericLabel.Name = "paletteAlphaNumericLabel";
            this.paletteAlphaNumericLabel.Size = new System.Drawing.Size(149, 15);
            this.paletteAlphaNumericLabel.TabIndex = 0;
            this.paletteAlphaNumericLabel.Text = "Color alpha";
            // 
            // paletteAlphaNumeric
            // 
            this.paletteAlphaNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paletteAlphaNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.paletteAlphaNumeric.ForeColor = System.Drawing.Color.White;
            this.paletteAlphaNumeric.Location = new System.Drawing.Point(2, 20);
            this.paletteAlphaNumeric.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.paletteAlphaNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.paletteAlphaNumeric.Name = "paletteAlphaNumeric";
            this.paletteAlphaNumeric.Size = new System.Drawing.Size(163, 20);
            this.paletteAlphaNumeric.TabIndex = 1;
            this.paletteAlphaNumeric.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // styleOptionsRow
            // 
            this.styleOptionsRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.styleOptionsRow.ColumnCount = 2;
            this.styleOptionsRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.styleOptionsRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.styleOptionsRow.Controls.Add(this.paletteDividerNumericRow, 0, 0);
            this.styleOptionsRow.Controls.Add(this.tooltipDelayNumericRow, 1, 0);
            this.styleOptionsRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.styleOptionsRow.Location = new System.Drawing.Point(3, 135);
            this.styleOptionsRow.Margin = new System.Windows.Forms.Padding(0);
            this.styleOptionsRow.Name = "styleOptionsRow";
            this.styleOptionsRow.RowCount = 1;
            this.styleOptionsRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.styleOptionsRow.Size = new System.Drawing.Size(335, 45);
            this.styleOptionsRow.TabIndex = 3;
            // 
            // paletteDividerNumericRow
            // 
            this.paletteDividerNumericRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.paletteDividerNumericRow.Controls.Add(this.paletteDividerNumericLabel);
            this.paletteDividerNumericRow.Controls.Add(this.paletteDividerNumeric);
            this.paletteDividerNumericRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paletteDividerNumericRow.Location = new System.Drawing.Point(0, 0);
            this.paletteDividerNumericRow.Margin = new System.Windows.Forms.Padding(0);
            this.paletteDividerNumericRow.Name = "paletteDividerNumericRow";
            this.paletteDividerNumericRow.Size = new System.Drawing.Size(167, 45);
            this.paletteDividerNumericRow.TabIndex = 0;
            // 
            // paletteDividerNumericLabel
            // 
            this.paletteDividerNumericLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paletteDividerNumericLabel.ForeColor = System.Drawing.Color.White;
            this.paletteDividerNumericLabel.Location = new System.Drawing.Point(2, 2);
            this.paletteDividerNumericLabel.Name = "paletteDividerNumericLabel";
            this.paletteDividerNumericLabel.Size = new System.Drawing.Size(149, 15);
            this.paletteDividerNumericLabel.TabIndex = 0;
            this.paletteDividerNumericLabel.Text = "Color intensity divider";
            // 
            // paletteDividerNumeric
            // 
            this.paletteDividerNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paletteDividerNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.paletteDividerNumeric.ForeColor = System.Drawing.Color.White;
            this.paletteDividerNumeric.Location = new System.Drawing.Point(2, 20);
            this.paletteDividerNumeric.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.paletteDividerNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.paletteDividerNumeric.Name = "paletteDividerNumeric";
            this.paletteDividerNumeric.Size = new System.Drawing.Size(162, 20);
            this.paletteDividerNumeric.TabIndex = 1;
            this.paletteDividerNumeric.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // tooltipDelayNumericRow
            // 
            this.tooltipDelayNumericRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.tooltipDelayNumericRow.Controls.Add(this.tooltipDelayNumericLabel);
            this.tooltipDelayNumericRow.Controls.Add(this.tooltipDelayNumeric);
            this.tooltipDelayNumericRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tooltipDelayNumericRow.Location = new System.Drawing.Point(167, 0);
            this.tooltipDelayNumericRow.Margin = new System.Windows.Forms.Padding(0);
            this.tooltipDelayNumericRow.Name = "tooltipDelayNumericRow";
            this.tooltipDelayNumericRow.Size = new System.Drawing.Size(168, 45);
            this.tooltipDelayNumericRow.TabIndex = 1;
            // 
            // tooltipDelayNumericLabel
            // 
            this.tooltipDelayNumericLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tooltipDelayNumericLabel.ForeColor = System.Drawing.Color.White;
            this.tooltipDelayNumericLabel.Location = new System.Drawing.Point(2, 2);
            this.tooltipDelayNumericLabel.Name = "tooltipDelayNumericLabel";
            this.tooltipDelayNumericLabel.Size = new System.Drawing.Size(149, 15);
            this.tooltipDelayNumericLabel.TabIndex = 0;
            this.tooltipDelayNumericLabel.Text = "Point hover delay (milliseconds)";
            // 
            // tooltipDelayNumeric
            // 
            this.tooltipDelayNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tooltipDelayNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.tooltipDelayNumeric.ForeColor = System.Drawing.Color.White;
            this.tooltipDelayNumeric.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.tooltipDelayNumeric.Location = new System.Drawing.Point(2, 20);
            this.tooltipDelayNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.tooltipDelayNumeric.Name = "tooltipDelayNumeric";
            this.tooltipDelayNumeric.Size = new System.Drawing.Size(163, 20);
            this.tooltipDelayNumeric.TabIndex = 1;
            this.tooltipDelayNumeric.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // styleTogglesRow
            // 
            this.styleTogglesRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.styleTogglesRow.ColumnCount = 2;
            this.styleTogglesRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.styleTogglesRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.styleTogglesRow.Controls.Add(this.absoluteCheckBoxRow, 0, 0);
            this.styleTogglesRow.Controls.Add(this.tooltipEnableCheckBoxRow, 1, 0);
            this.styleTogglesRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.styleTogglesRow.Location = new System.Drawing.Point(3, 180);
            this.styleTogglesRow.Margin = new System.Windows.Forms.Padding(0);
            this.styleTogglesRow.Name = "styleTogglesRow";
            this.styleTogglesRow.RowCount = 1;
            this.styleTogglesRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.styleTogglesRow.Size = new System.Drawing.Size(335, 25);
            this.styleTogglesRow.TabIndex = 4;
            // 
            // absoluteCheckBoxRow
            // 
            this.absoluteCheckBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.absoluteCheckBoxRow.Controls.Add(this.absoluteCheckBox);
            this.absoluteCheckBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.absoluteCheckBoxRow.Location = new System.Drawing.Point(0, 0);
            this.absoluteCheckBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.absoluteCheckBoxRow.Name = "absoluteCheckBoxRow";
            this.absoluteCheckBoxRow.Size = new System.Drawing.Size(167, 25);
            this.absoluteCheckBoxRow.TabIndex = 0;
            // 
            // absoluteCheckBox
            // 
            this.absoluteCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.absoluteCheckBox.Checked = true;
            this.absoluteCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.absoluteCheckBox.ForeColor = System.Drawing.Color.White;
            this.absoluteCheckBox.Location = new System.Drawing.Point(2, 2);
            this.absoluteCheckBox.Name = "absoluteCheckBox";
            this.absoluteCheckBox.Size = new System.Drawing.Size(131, 25);
            this.absoluteCheckBox.TabIndex = 0;
            this.absoluteCheckBox.Text = "Absolute values";
            this.absoluteCheckBox.UseVisualStyleBackColor = false;
            // 
            // tooltipEnableCheckBoxRow
            // 
            this.tooltipEnableCheckBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.tooltipEnableCheckBoxRow.Controls.Add(this.tooltipEnableCheckBox);
            this.tooltipEnableCheckBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tooltipEnableCheckBoxRow.Location = new System.Drawing.Point(167, 0);
            this.tooltipEnableCheckBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.tooltipEnableCheckBoxRow.Name = "tooltipEnableCheckBoxRow";
            this.tooltipEnableCheckBoxRow.Size = new System.Drawing.Size(168, 25);
            this.tooltipEnableCheckBoxRow.TabIndex = 1;
            // 
            // tooltipEnableCheckBox
            // 
            this.tooltipEnableCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.tooltipEnableCheckBox.Checked = true;
            this.tooltipEnableCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tooltipEnableCheckBox.ForeColor = System.Drawing.Color.White;
            this.tooltipEnableCheckBox.Location = new System.Drawing.Point(2, 2);
            this.tooltipEnableCheckBox.Name = "tooltipEnableCheckBox";
            this.tooltipEnableCheckBox.Size = new System.Drawing.Size(132, 25);
            this.tooltipEnableCheckBox.TabIndex = 0;
            this.tooltipEnableCheckBox.Text = "Show XYZ point tips";
            this.tooltipEnableCheckBox.UseVisualStyleBackColor = false;
            // 
            // styleCursorTogglesRow
            // 
            this.styleCursorTogglesRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.styleCursorTogglesRow.ColumnCount = 2;
            this.styleCursorTogglesRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.styleCursorTogglesRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.styleCursorTogglesRow.Controls.Add(this.cursorEnabledCheckBoxRow, 0, 0);
            this.styleCursorTogglesRow.Controls.Add(this.cursorZoomCheckBoxRow, 1, 0);
            this.styleCursorTogglesRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.styleCursorTogglesRow.Location = new System.Drawing.Point(3, 205);
            this.styleCursorTogglesRow.Margin = new System.Windows.Forms.Padding(0);
            this.styleCursorTogglesRow.Name = "styleCursorTogglesRow";
            this.styleCursorTogglesRow.RowCount = 1;
            this.styleCursorTogglesRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.styleCursorTogglesRow.Size = new System.Drawing.Size(335, 25);
            this.styleCursorTogglesRow.TabIndex = 5;
            // 
            // cursorEnabledCheckBoxRow
            // 
            this.cursorEnabledCheckBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.cursorEnabledCheckBoxRow.Controls.Add(this.cursorEnabledCheckBox);
            this.cursorEnabledCheckBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cursorEnabledCheckBoxRow.Location = new System.Drawing.Point(0, 0);
            this.cursorEnabledCheckBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.cursorEnabledCheckBoxRow.Name = "cursorEnabledCheckBoxRow";
            this.cursorEnabledCheckBoxRow.Size = new System.Drawing.Size(167, 25);
            this.cursorEnabledCheckBoxRow.TabIndex = 0;
            // 
            // cursorEnabledCheckBox
            // 
            this.cursorEnabledCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.cursorEnabledCheckBox.ForeColor = System.Drawing.Color.White;
            this.cursorEnabledCheckBox.Location = new System.Drawing.Point(2, 2);
            this.cursorEnabledCheckBox.Name = "cursorEnabledCheckBox";
            this.cursorEnabledCheckBox.Size = new System.Drawing.Size(140, 25);
            this.cursorEnabledCheckBox.TabIndex = 0;
            this.cursorEnabledCheckBox.Text = "Enable X / Y cursors";
            this.cursorEnabledCheckBox.UseVisualStyleBackColor = false;
            // 
            // cursorZoomCheckBoxRow
            // 
            this.cursorZoomCheckBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.cursorZoomCheckBoxRow.Controls.Add(this.cursorZoomCheckBox);
            this.cursorZoomCheckBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cursorZoomCheckBoxRow.Location = new System.Drawing.Point(167, 0);
            this.cursorZoomCheckBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.cursorZoomCheckBoxRow.Name = "cursorZoomCheckBoxRow";
            this.cursorZoomCheckBoxRow.Size = new System.Drawing.Size(168, 25);
            this.cursorZoomCheckBoxRow.TabIndex = 1;
            // 
            // cursorZoomCheckBox
            // 
            this.cursorZoomCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.cursorZoomCheckBox.ForeColor = System.Drawing.Color.White;
            this.cursorZoomCheckBox.Location = new System.Drawing.Point(2, 2);
            this.cursorZoomCheckBox.Name = "cursorZoomCheckBox";
            this.cursorZoomCheckBox.Size = new System.Drawing.Size(140, 25);
            this.cursorZoomCheckBox.TabIndex = 0;
            this.cursorZoomCheckBox.Text = "Enable X / Y drag zoom";
            this.cursorZoomCheckBox.UseVisualStyleBackColor = false;
            // 
            // styleCursorColorsRow
            // 
            this.styleCursorColorsRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.styleCursorColorsRow.ColumnCount = 2;
            this.styleCursorColorsRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.styleCursorColorsRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.styleCursorColorsRow.Controls.Add(this.cursorColorComboBoxRow, 0, 0);
            this.styleCursorColorsRow.Controls.Add(this.cursorAlphaNumericRow, 1, 0);
            this.styleCursorColorsRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.styleCursorColorsRow.Location = new System.Drawing.Point(3, 230);
            this.styleCursorColorsRow.Margin = new System.Windows.Forms.Padding(0);
            this.styleCursorColorsRow.Name = "styleCursorColorsRow";
            this.styleCursorColorsRow.RowCount = 1;
            this.styleCursorColorsRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.styleCursorColorsRow.Size = new System.Drawing.Size(335, 45);
            this.styleCursorColorsRow.TabIndex = 6;
            // 
            // cursorColorComboBoxRow
            // 
            this.cursorColorComboBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.cursorColorComboBoxRow.Controls.Add(this.cursorColorComboBoxLabel);
            this.cursorColorComboBoxRow.Controls.Add(this.cursorColorComboBox);
            this.cursorColorComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cursorColorComboBoxRow.Location = new System.Drawing.Point(0, 0);
            this.cursorColorComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.cursorColorComboBoxRow.Name = "cursorColorComboBoxRow";
            this.cursorColorComboBoxRow.Size = new System.Drawing.Size(167, 45);
            this.cursorColorComboBoxRow.TabIndex = 0;
            // 
            // cursorColorComboBoxLabel
            // 
            this.cursorColorComboBoxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cursorColorComboBoxLabel.ForeColor = System.Drawing.Color.White;
            this.cursorColorComboBoxLabel.Location = new System.Drawing.Point(2, 2);
            this.cursorColorComboBoxLabel.Name = "cursorColorComboBoxLabel";
            this.cursorColorComboBoxLabel.Size = new System.Drawing.Size(149, 15);
            this.cursorColorComboBoxLabel.TabIndex = 0;
            this.cursorColorComboBoxLabel.Text = "Cursor color";
            // 
            // cursorColorComboBox
            // 
            this.cursorColorComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cursorColorComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cursorColorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cursorColorComboBox.ForeColor = System.Drawing.Color.White;
            this.cursorColorComboBox.IntegralHeight = false;
            this.cursorColorComboBox.Location = new System.Drawing.Point(2, 20);
            this.cursorColorComboBox.Name = "cursorColorComboBox";
            this.cursorColorComboBox.Size = new System.Drawing.Size(162, 21);
            this.cursorColorComboBox.TabIndex = 1;
            // 
            // cursorAlphaNumericRow
            // 
            this.cursorAlphaNumericRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.cursorAlphaNumericRow.Controls.Add(this.cursorAlphaNumericLabel);
            this.cursorAlphaNumericRow.Controls.Add(this.cursorAlphaNumeric);
            this.cursorAlphaNumericRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cursorAlphaNumericRow.Location = new System.Drawing.Point(167, 0);
            this.cursorAlphaNumericRow.Margin = new System.Windows.Forms.Padding(0);
            this.cursorAlphaNumericRow.Name = "cursorAlphaNumericRow";
            this.cursorAlphaNumericRow.Size = new System.Drawing.Size(168, 45);
            this.cursorAlphaNumericRow.TabIndex = 1;
            // 
            // cursorAlphaNumericLabel
            // 
            this.cursorAlphaNumericLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cursorAlphaNumericLabel.ForeColor = System.Drawing.Color.White;
            this.cursorAlphaNumericLabel.Location = new System.Drawing.Point(2, 2);
            this.cursorAlphaNumericLabel.Name = "cursorAlphaNumericLabel";
            this.cursorAlphaNumericLabel.Size = new System.Drawing.Size(149, 15);
            this.cursorAlphaNumericLabel.TabIndex = 0;
            this.cursorAlphaNumericLabel.Text = "Cursor color alpha (0-255)";
            // 
            // cursorAlphaNumeric
            // 
            this.cursorAlphaNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cursorAlphaNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cursorAlphaNumeric.ForeColor = System.Drawing.Color.White;
            this.cursorAlphaNumeric.Location = new System.Drawing.Point(2, 20);
            this.cursorAlphaNumeric.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.cursorAlphaNumeric.Name = "cursorAlphaNumeric";
            this.cursorAlphaNumeric.Size = new System.Drawing.Size(163, 20);
            this.cursorAlphaNumeric.TabIndex = 1;
            this.cursorAlphaNumeric.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // styleCursorStrokeRow
            // 
            this.styleCursorStrokeRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.styleCursorStrokeRow.ColumnCount = 2;
            this.styleCursorStrokeRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.styleCursorStrokeRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.styleCursorStrokeRow.Controls.Add(this.cursorWidthNumericRow, 0, 0);
            this.styleCursorStrokeRow.Controls.Add(this.cursorDashComboBoxRow, 1, 0);
            this.styleCursorStrokeRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.styleCursorStrokeRow.Location = new System.Drawing.Point(3, 275);
            this.styleCursorStrokeRow.Margin = new System.Windows.Forms.Padding(0);
            this.styleCursorStrokeRow.Name = "styleCursorStrokeRow";
            this.styleCursorStrokeRow.RowCount = 1;
            this.styleCursorStrokeRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.styleCursorStrokeRow.Size = new System.Drawing.Size(335, 153);
            this.styleCursorStrokeRow.TabIndex = 7;
            // 
            // cursorWidthNumericRow
            // 
            this.cursorWidthNumericRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.cursorWidthNumericRow.Controls.Add(this.cursorWidthNumericLabel);
            this.cursorWidthNumericRow.Controls.Add(this.cursorWidthNumeric);
            this.cursorWidthNumericRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cursorWidthNumericRow.Location = new System.Drawing.Point(0, 0);
            this.cursorWidthNumericRow.Margin = new System.Windows.Forms.Padding(0);
            this.cursorWidthNumericRow.Name = "cursorWidthNumericRow";
            this.cursorWidthNumericRow.Size = new System.Drawing.Size(167, 153);
            this.cursorWidthNumericRow.TabIndex = 0;
            // 
            // cursorWidthNumericLabel
            // 
            this.cursorWidthNumericLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cursorWidthNumericLabel.ForeColor = System.Drawing.Color.White;
            this.cursorWidthNumericLabel.Location = new System.Drawing.Point(2, 2);
            this.cursorWidthNumericLabel.Name = "cursorWidthNumericLabel";
            this.cursorWidthNumericLabel.Size = new System.Drawing.Size(149, 15);
            this.cursorWidthNumericLabel.TabIndex = 0;
            this.cursorWidthNumericLabel.Text = "Cursor width";
            // 
            // cursorWidthNumeric
            // 
            this.cursorWidthNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cursorWidthNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cursorWidthNumeric.DecimalPlaces = 2;
            this.cursorWidthNumeric.ForeColor = System.Drawing.Color.White;
            this.cursorWidthNumeric.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.cursorWidthNumeric.Location = new System.Drawing.Point(2, 20);
            this.cursorWidthNumeric.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.cursorWidthNumeric.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.cursorWidthNumeric.Name = "cursorWidthNumeric";
            this.cursorWidthNumeric.Size = new System.Drawing.Size(162, 20);
            this.cursorWidthNumeric.TabIndex = 1;
            this.cursorWidthNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cursorDashComboBoxRow
            // 
            this.cursorDashComboBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.cursorDashComboBoxRow.Controls.Add(this.cursorDashComboBoxLabel);
            this.cursorDashComboBoxRow.Controls.Add(this.cursorDashComboBox);
            this.cursorDashComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cursorDashComboBoxRow.Location = new System.Drawing.Point(167, 0);
            this.cursorDashComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.cursorDashComboBoxRow.Name = "cursorDashComboBoxRow";
            this.cursorDashComboBoxRow.Size = new System.Drawing.Size(168, 153);
            this.cursorDashComboBoxRow.TabIndex = 1;
            // 
            // cursorDashComboBoxLabel
            // 
            this.cursorDashComboBoxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cursorDashComboBoxLabel.ForeColor = System.Drawing.Color.White;
            this.cursorDashComboBoxLabel.Location = new System.Drawing.Point(2, 2);
            this.cursorDashComboBoxLabel.Name = "cursorDashComboBoxLabel";
            this.cursorDashComboBoxLabel.Size = new System.Drawing.Size(149, 15);
            this.cursorDashComboBoxLabel.TabIndex = 0;
            this.cursorDashComboBoxLabel.Text = "Cursor dash style";
            // 
            // cursorDashComboBox
            // 
            this.cursorDashComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cursorDashComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cursorDashComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cursorDashComboBox.ForeColor = System.Drawing.Color.White;
            this.cursorDashComboBox.IntegralHeight = false;
            this.cursorDashComboBox.Location = new System.Drawing.Point(2, 20);
            this.cursorDashComboBox.Name = "cursorDashComboBox";
            this.cursorDashComboBox.Size = new System.Drawing.Size(163, 21);
            this.cursorDashComboBox.TabIndex = 1;
            // 
            // xAxisGroup
            // 
            this.xAxisGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.xAxisGroup.Controls.Add(this.xFields);
            this.xAxisGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xAxisGroup.ForeColor = System.Drawing.Color.White;
            this.xAxisGroup.Location = new System.Drawing.Point(368, 13);
            this.xAxisGroup.Margin = new System.Windows.Forms.Padding(5);
            this.xAxisGroup.Name = "xAxisGroup";
            this.xAxisGroup.Padding = new System.Windows.Forms.Padding(2);
            this.xAxisGroup.Size = new System.Drawing.Size(359, 445);
            this.xAxisGroup.TabIndex = 1;
            this.xAxisGroup.TabStop = false;
            this.xAxisGroup.Text = "X axis";
            // 
            // xFields
            // 
            this.xFields.AutoScroll = true;
            this.xFields.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.xFields.ColumnCount = 1;
            this.xFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.xFields.Controls.Add(this.xFontPropertiesRow, 0, 11);
            this.xFields.Controls.Add(this.xDefaultsButtonRow, 0, 0);
            this.xFields.Controls.Add(this.xColumnComboBoxRow, 0, 1);
            this.xFields.Controls.Add(this.xModeRow, 0, 2);
            this.xFields.Controls.Add(this.xLimitsRow, 0, 3);
            this.xFields.Controls.Add(this.xTicksRow, 0, 4);
            this.xFields.Controls.Add(this.xMajorGridRow, 0, 5);
            this.xFields.Controls.Add(this.xMajorStyleRow, 0, 6);
            this.xFields.Controls.Add(this.xMinorGridRow, 0, 7);
            this.xFields.Controls.Add(this.xMinorStrokeRow, 0, 8);
            this.xFields.Controls.Add(this.xMinorOpacityRow, 0, 9);
            this.xFields.Controls.Add(this.xFontRow, 0, 10);
            this.xFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xFields.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.xFields.Location = new System.Drawing.Point(2, 15);
            this.xFields.Name = "xFields";
            this.xFields.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.xFields.RowCount = 12;
            this.xFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.xFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.xFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.xFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.xFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.xFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.xFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.xFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.xFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.xFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.xFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.xFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.xFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.xFields.Size = new System.Drawing.Size(355, 428);
            this.xFields.TabIndex = 0;
            // 
            // xFontPropertiesRow
            // 
            this.xFontPropertiesRow.ColumnCount = 2;
            this.xFontPropertiesRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.xFontPropertiesRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.xFontPropertiesRow.Controls.Add(this.xFontSizeNumericRow, 1, 0);
            this.xFontPropertiesRow.Controls.Add(this.xFontColorComboBoxRow, 0, 0);
            this.xFontPropertiesRow.Dock = System.Windows.Forms.DockStyle.Top;
            this.xFontPropertiesRow.Location = new System.Drawing.Point(3, 470);
            this.xFontPropertiesRow.Margin = new System.Windows.Forms.Padding(0);
            this.xFontPropertiesRow.Name = "xFontPropertiesRow";
            this.xFontPropertiesRow.RowCount = 1;
            this.xFontPropertiesRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.xFontPropertiesRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.xFontPropertiesRow.Size = new System.Drawing.Size(332, 45);
            this.xFontPropertiesRow.TabIndex = 1;
            // 
            // xFontSizeNumericRow
            // 
            this.xFontSizeNumericRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.xFontSizeNumericRow.Controls.Add(this.xFontSizeNumericLabel);
            this.xFontSizeNumericRow.Controls.Add(this.xFontSizeNumeric);
            this.xFontSizeNumericRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xFontSizeNumericRow.Location = new System.Drawing.Point(166, 0);
            this.xFontSizeNumericRow.Margin = new System.Windows.Forms.Padding(0);
            this.xFontSizeNumericRow.Name = "xFontSizeNumericRow";
            this.xFontSizeNumericRow.Size = new System.Drawing.Size(166, 45);
            this.xFontSizeNumericRow.TabIndex = 1;
            // 
            // xFontSizeNumericLabel
            // 
            this.xFontSizeNumericLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xFontSizeNumericLabel.ForeColor = System.Drawing.Color.White;
            this.xFontSizeNumericLabel.Location = new System.Drawing.Point(2, 2);
            this.xFontSizeNumericLabel.Name = "xFontSizeNumericLabel";
            this.xFontSizeNumericLabel.Size = new System.Drawing.Size(147, 15);
            this.xFontSizeNumericLabel.TabIndex = 0;
            this.xFontSizeNumericLabel.Text = "Axis font size";
            // 
            // xFontSizeNumeric
            // 
            this.xFontSizeNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xFontSizeNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.xFontSizeNumeric.DecimalPlaces = 2;
            this.xFontSizeNumeric.ForeColor = System.Drawing.Color.White;
            this.xFontSizeNumeric.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.xFontSizeNumeric.Location = new System.Drawing.Point(5, 20);
            this.xFontSizeNumeric.Maximum = new decimal(new int[] {
            36,
            0,
            0,
            0});
            this.xFontSizeNumeric.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.xFontSizeNumeric.Name = "xFontSizeNumeric";
            this.xFontSizeNumeric.Size = new System.Drawing.Size(157, 20);
            this.xFontSizeNumeric.TabIndex = 1;
            this.xFontSizeNumeric.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // xFontColorComboBoxRow
            // 
            this.xFontColorComboBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.xFontColorComboBoxRow.Controls.Add(this.xFontColorComboBoxLabel);
            this.xFontColorComboBoxRow.Controls.Add(this.xFontColorComboBox);
            this.xFontColorComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xFontColorComboBoxRow.Location = new System.Drawing.Point(0, 0);
            this.xFontColorComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.xFontColorComboBoxRow.Name = "xFontColorComboBoxRow";
            this.xFontColorComboBoxRow.Size = new System.Drawing.Size(166, 45);
            this.xFontColorComboBoxRow.TabIndex = 11;
            // 
            // xFontColorComboBoxLabel
            // 
            this.xFontColorComboBoxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xFontColorComboBoxLabel.ForeColor = System.Drawing.Color.White;
            this.xFontColorComboBoxLabel.Location = new System.Drawing.Point(2, 2);
            this.xFontColorComboBoxLabel.Name = "xFontColorComboBoxLabel";
            this.xFontColorComboBoxLabel.Size = new System.Drawing.Size(148, 15);
            this.xFontColorComboBoxLabel.TabIndex = 0;
            this.xFontColorComboBoxLabel.Text = "Axis font color";
            // 
            // xFontColorComboBox
            // 
            this.xFontColorComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xFontColorComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.xFontColorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.xFontColorComboBox.ForeColor = System.Drawing.Color.White;
            this.xFontColorComboBox.IntegralHeight = false;
            this.xFontColorComboBox.Location = new System.Drawing.Point(5, 20);
            this.xFontColorComboBox.Name = "xFontColorComboBox";
            this.xFontColorComboBox.Size = new System.Drawing.Size(157, 21);
            this.xFontColorComboBox.TabIndex = 1;
            // 
            // xDefaultsButtonRow
            // 
            this.xDefaultsButtonRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.xDefaultsButtonRow.Controls.Add(this.xDefaultsButton);
            this.xDefaultsButtonRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xDefaultsButtonRow.Location = new System.Drawing.Point(3, 0);
            this.xDefaultsButtonRow.Margin = new System.Windows.Forms.Padding(0);
            this.xDefaultsButtonRow.Name = "xDefaultsButtonRow";
            this.xDefaultsButtonRow.Size = new System.Drawing.Size(332, 40);
            this.xDefaultsButtonRow.TabIndex = 0;
            // 
            // xDefaultsButton
            // 
            this.xDefaultsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xDefaultsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.xDefaultsButton.ForeColor = System.Drawing.Color.White;
            this.xDefaultsButton.Location = new System.Drawing.Point(6, 6);
            this.xDefaultsButton.Name = "xDefaultsButton";
            this.xDefaultsButton.Size = new System.Drawing.Size(315, 30);
            this.xDefaultsButton.TabIndex = 0;
            this.xDefaultsButton.Text = "Restore X defaults";
            this.xDefaultsButton.UseVisualStyleBackColor = false;
            // 
            // xColumnComboBoxRow
            // 
            this.xColumnComboBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.xColumnComboBoxRow.Controls.Add(this.xColumnComboBoxLabel);
            this.xColumnComboBoxRow.Controls.Add(this.xColumnComboBox);
            this.xColumnComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xColumnComboBoxRow.Location = new System.Drawing.Point(3, 40);
            this.xColumnComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.xColumnComboBoxRow.Name = "xColumnComboBoxRow";
            this.xColumnComboBoxRow.Size = new System.Drawing.Size(332, 45);
            this.xColumnComboBoxRow.TabIndex = 1;
            // 
            // xColumnComboBoxLabel
            // 
            this.xColumnComboBoxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xColumnComboBoxLabel.ForeColor = System.Drawing.Color.White;
            this.xColumnComboBoxLabel.Location = new System.Drawing.Point(2, 2);
            this.xColumnComboBoxLabel.Name = "xColumnComboBoxLabel";
            this.xColumnComboBoxLabel.Size = new System.Drawing.Size(314, 15);
            this.xColumnComboBoxLabel.TabIndex = 0;
            this.xColumnComboBoxLabel.Text = "X column";
            // 
            // xColumnComboBox
            // 
            this.xColumnComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xColumnComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.xColumnComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.xColumnComboBox.ForeColor = System.Drawing.Color.White;
            this.xColumnComboBox.IntegralHeight = false;
            this.xColumnComboBox.Location = new System.Drawing.Point(5, 20);
            this.xColumnComboBox.Name = "xColumnComboBox";
            this.xColumnComboBox.Size = new System.Drawing.Size(323, 21);
            this.xColumnComboBox.TabIndex = 1;
            // 
            // xModeRow
            // 
            this.xModeRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.xModeRow.ColumnCount = 2;
            this.xModeRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.xModeRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.xModeRow.Controls.Add(this.xAutoCheckBoxRow, 0, 0);
            this.xModeRow.Controls.Add(this.xLogCheckBoxRow, 1, 0);
            this.xModeRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xModeRow.Location = new System.Drawing.Point(3, 85);
            this.xModeRow.Margin = new System.Windows.Forms.Padding(0);
            this.xModeRow.Name = "xModeRow";
            this.xModeRow.RowCount = 1;
            this.xModeRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.xModeRow.Size = new System.Drawing.Size(332, 25);
            this.xModeRow.TabIndex = 2;
            // 
            // xAutoCheckBoxRow
            // 
            this.xAutoCheckBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.xAutoCheckBoxRow.Controls.Add(this.xAutoCheckBox);
            this.xAutoCheckBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xAutoCheckBoxRow.Location = new System.Drawing.Point(0, 0);
            this.xAutoCheckBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.xAutoCheckBoxRow.Name = "xAutoCheckBoxRow";
            this.xAutoCheckBoxRow.Size = new System.Drawing.Size(166, 25);
            this.xAutoCheckBoxRow.TabIndex = 0;
            // 
            // xAutoCheckBox
            // 
            this.xAutoCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xAutoCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.xAutoCheckBox.Checked = true;
            this.xAutoCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.xAutoCheckBox.ForeColor = System.Drawing.Color.White;
            this.xAutoCheckBox.Location = new System.Drawing.Point(2, 2);
            this.xAutoCheckBox.Name = "xAutoCheckBox";
            this.xAutoCheckBox.Size = new System.Drawing.Size(149, 28);
            this.xAutoCheckBox.TabIndex = 0;
            this.xAutoCheckBox.Text = "Auto-scale X";
            this.xAutoCheckBox.UseVisualStyleBackColor = false;
            // 
            // xLogCheckBoxRow
            // 
            this.xLogCheckBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.xLogCheckBoxRow.Controls.Add(this.xLogCheckBox);
            this.xLogCheckBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xLogCheckBoxRow.Location = new System.Drawing.Point(166, 0);
            this.xLogCheckBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.xLogCheckBoxRow.Name = "xLogCheckBoxRow";
            this.xLogCheckBoxRow.Size = new System.Drawing.Size(166, 25);
            this.xLogCheckBoxRow.TabIndex = 1;
            // 
            // xLogCheckBox
            // 
            this.xLogCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xLogCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.xLogCheckBox.ForeColor = System.Drawing.Color.White;
            this.xLogCheckBox.Location = new System.Drawing.Point(2, 2);
            this.xLogCheckBox.Name = "xLogCheckBox";
            this.xLogCheckBox.Size = new System.Drawing.Size(149, 28);
            this.xLogCheckBox.TabIndex = 0;
            this.xLogCheckBox.Text = "Logarithmic X axis";
            this.xLogCheckBox.UseVisualStyleBackColor = false;
            // 
            // xLimitsRow
            // 
            this.xLimitsRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.xLimitsRow.ColumnCount = 2;
            this.xLimitsRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.xLimitsRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.xLimitsRow.Controls.Add(this.xMinimumBoxRow, 0, 0);
            this.xLimitsRow.Controls.Add(this.xMaximumBoxRow, 1, 0);
            this.xLimitsRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xLimitsRow.Location = new System.Drawing.Point(3, 110);
            this.xLimitsRow.Margin = new System.Windows.Forms.Padding(0);
            this.xLimitsRow.Name = "xLimitsRow";
            this.xLimitsRow.RowCount = 1;
            this.xLimitsRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.xLimitsRow.Size = new System.Drawing.Size(332, 45);
            this.xLimitsRow.TabIndex = 3;
            // 
            // xMinimumBoxRow
            // 
            this.xMinimumBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.xMinimumBoxRow.Controls.Add(this.xMinimumBoxLabel);
            this.xMinimumBoxRow.Controls.Add(this.xMinimumBox);
            this.xMinimumBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xMinimumBoxRow.Location = new System.Drawing.Point(0, 0);
            this.xMinimumBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.xMinimumBoxRow.Name = "xMinimumBoxRow";
            this.xMinimumBoxRow.Size = new System.Drawing.Size(166, 45);
            this.xMinimumBoxRow.TabIndex = 0;
            // 
            // xMinimumBoxLabel
            // 
            this.xMinimumBoxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xMinimumBoxLabel.ForeColor = System.Drawing.Color.White;
            this.xMinimumBoxLabel.Location = new System.Drawing.Point(2, 2);
            this.xMinimumBoxLabel.Name = "xMinimumBoxLabel";
            this.xMinimumBoxLabel.Size = new System.Drawing.Size(148, 15);
            this.xMinimumBoxLabel.TabIndex = 0;
            this.xMinimumBoxLabel.Text = "X minimum";
            // 
            // xMinimumBox
            // 
            this.xMinimumBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xMinimumBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.xMinimumBox.ForeColor = System.Drawing.Color.White;
            this.xMinimumBox.Location = new System.Drawing.Point(5, 20);
            this.xMinimumBox.Name = "xMinimumBox";
            this.xMinimumBox.Size = new System.Drawing.Size(157, 20);
            this.xMinimumBox.TabIndex = 1;
            // 
            // xMaximumBoxRow
            // 
            this.xMaximumBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.xMaximumBoxRow.Controls.Add(this.xMaximumBoxLabel);
            this.xMaximumBoxRow.Controls.Add(this.xMaximumBox);
            this.xMaximumBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xMaximumBoxRow.Location = new System.Drawing.Point(166, 0);
            this.xMaximumBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.xMaximumBoxRow.Name = "xMaximumBoxRow";
            this.xMaximumBoxRow.Size = new System.Drawing.Size(166, 45);
            this.xMaximumBoxRow.TabIndex = 1;
            // 
            // xMaximumBoxLabel
            // 
            this.xMaximumBoxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xMaximumBoxLabel.ForeColor = System.Drawing.Color.White;
            this.xMaximumBoxLabel.Location = new System.Drawing.Point(2, 2);
            this.xMaximumBoxLabel.Name = "xMaximumBoxLabel";
            this.xMaximumBoxLabel.Size = new System.Drawing.Size(147, 15);
            this.xMaximumBoxLabel.TabIndex = 0;
            this.xMaximumBoxLabel.Text = "X maximum";
            // 
            // xMaximumBox
            // 
            this.xMaximumBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xMaximumBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.xMaximumBox.ForeColor = System.Drawing.Color.White;
            this.xMaximumBox.Location = new System.Drawing.Point(5, 20);
            this.xMaximumBox.Name = "xMaximumBox";
            this.xMaximumBox.Size = new System.Drawing.Size(157, 20);
            this.xMaximumBox.TabIndex = 1;
            // 
            // xTicksRow
            // 
            this.xTicksRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.xTicksRow.ColumnCount = 2;
            this.xTicksRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.xTicksRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.xTicksRow.Controls.Add(this.xGridIntervalBoxRow, 0, 0);
            this.xTicksRow.Controls.Add(this.xDecimalsNumericRow, 1, 0);
            this.xTicksRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xTicksRow.Location = new System.Drawing.Point(3, 155);
            this.xTicksRow.Margin = new System.Windows.Forms.Padding(0);
            this.xTicksRow.Name = "xTicksRow";
            this.xTicksRow.RowCount = 1;
            this.xTicksRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.xTicksRow.Size = new System.Drawing.Size(332, 45);
            this.xTicksRow.TabIndex = 4;
            // 
            // xGridIntervalBoxRow
            // 
            this.xGridIntervalBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.xGridIntervalBoxRow.Controls.Add(this.xGridIntervalBoxLabel);
            this.xGridIntervalBoxRow.Controls.Add(this.xGridIntervalBox);
            this.xGridIntervalBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xGridIntervalBoxRow.Location = new System.Drawing.Point(0, 0);
            this.xGridIntervalBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.xGridIntervalBoxRow.Name = "xGridIntervalBoxRow";
            this.xGridIntervalBoxRow.Size = new System.Drawing.Size(166, 45);
            this.xGridIntervalBoxRow.TabIndex = 0;
            // 
            // xGridIntervalBoxLabel
            // 
            this.xGridIntervalBoxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xGridIntervalBoxLabel.ForeColor = System.Drawing.Color.White;
            this.xGridIntervalBoxLabel.Location = new System.Drawing.Point(2, 2);
            this.xGridIntervalBoxLabel.Name = "xGridIntervalBoxLabel";
            this.xGridIntervalBoxLabel.Size = new System.Drawing.Size(162, 15);
            this.xGridIntervalBoxLabel.TabIndex = 0;
            this.xGridIntervalBoxLabel.Text = "Major grid interval (0 = auto)";
            // 
            // xGridIntervalBox
            // 
            this.xGridIntervalBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xGridIntervalBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.xGridIntervalBox.ForeColor = System.Drawing.Color.White;
            this.xGridIntervalBox.Location = new System.Drawing.Point(5, 20);
            this.xGridIntervalBox.Name = "xGridIntervalBox";
            this.xGridIntervalBox.Size = new System.Drawing.Size(157, 20);
            this.xGridIntervalBox.TabIndex = 1;
            // 
            // xDecimalsNumericRow
            // 
            this.xDecimalsNumericRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.xDecimalsNumericRow.Controls.Add(this.xDecimalsNumericLabel);
            this.xDecimalsNumericRow.Controls.Add(this.xDecimalsNumeric);
            this.xDecimalsNumericRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xDecimalsNumericRow.Location = new System.Drawing.Point(166, 0);
            this.xDecimalsNumericRow.Margin = new System.Windows.Forms.Padding(0);
            this.xDecimalsNumericRow.Name = "xDecimalsNumericRow";
            this.xDecimalsNumericRow.Size = new System.Drawing.Size(166, 45);
            this.xDecimalsNumericRow.TabIndex = 1;
            // 
            // xDecimalsNumericLabel
            // 
            this.xDecimalsNumericLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xDecimalsNumericLabel.ForeColor = System.Drawing.Color.White;
            this.xDecimalsNumericLabel.Location = new System.Drawing.Point(2, 2);
            this.xDecimalsNumericLabel.Name = "xDecimalsNumericLabel";
            this.xDecimalsNumericLabel.Size = new System.Drawing.Size(147, 15);
            this.xDecimalsNumericLabel.TabIndex = 0;
            this.xDecimalsNumericLabel.Text = "Label decimals";
            // 
            // xDecimalsNumeric
            // 
            this.xDecimalsNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xDecimalsNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.xDecimalsNumeric.ForeColor = System.Drawing.Color.White;
            this.xDecimalsNumeric.Location = new System.Drawing.Point(5, 20);
            this.xDecimalsNumeric.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.xDecimalsNumeric.Name = "xDecimalsNumeric";
            this.xDecimalsNumeric.Size = new System.Drawing.Size(157, 20);
            this.xDecimalsNumeric.TabIndex = 1;
            this.xDecimalsNumeric.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // xMajorGridRow
            // 
            this.xMajorGridRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.xMajorGridRow.ColumnCount = 2;
            this.xMajorGridRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.xMajorGridRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.xMajorGridRow.Controls.Add(this.xGridColorComboBoxRow, 0, 0);
            this.xMajorGridRow.Controls.Add(this.xGridWidthNumericRow, 1, 0);
            this.xMajorGridRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xMajorGridRow.Location = new System.Drawing.Point(3, 200);
            this.xMajorGridRow.Margin = new System.Windows.Forms.Padding(0);
            this.xMajorGridRow.Name = "xMajorGridRow";
            this.xMajorGridRow.RowCount = 1;
            this.xMajorGridRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.xMajorGridRow.Size = new System.Drawing.Size(332, 45);
            this.xMajorGridRow.TabIndex = 5;
            // 
            // xGridColorComboBoxRow
            // 
            this.xGridColorComboBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.xGridColorComboBoxRow.Controls.Add(this.xGridColorComboBoxLabel);
            this.xGridColorComboBoxRow.Controls.Add(this.xGridColorComboBox);
            this.xGridColorComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xGridColorComboBoxRow.Location = new System.Drawing.Point(0, 0);
            this.xGridColorComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.xGridColorComboBoxRow.Name = "xGridColorComboBoxRow";
            this.xGridColorComboBoxRow.Size = new System.Drawing.Size(166, 45);
            this.xGridColorComboBoxRow.TabIndex = 0;
            // 
            // xGridColorComboBoxLabel
            // 
            this.xGridColorComboBoxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xGridColorComboBoxLabel.ForeColor = System.Drawing.Color.White;
            this.xGridColorComboBoxLabel.Location = new System.Drawing.Point(2, 2);
            this.xGridColorComboBoxLabel.Name = "xGridColorComboBoxLabel";
            this.xGridColorComboBoxLabel.Size = new System.Drawing.Size(148, 15);
            this.xGridColorComboBoxLabel.TabIndex = 0;
            this.xGridColorComboBoxLabel.Text = "Major grid color";
            // 
            // xGridColorComboBox
            // 
            this.xGridColorComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xGridColorComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.xGridColorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.xGridColorComboBox.ForeColor = System.Drawing.Color.White;
            this.xGridColorComboBox.IntegralHeight = false;
            this.xGridColorComboBox.Location = new System.Drawing.Point(5, 20);
            this.xGridColorComboBox.Name = "xGridColorComboBox";
            this.xGridColorComboBox.Size = new System.Drawing.Size(157, 21);
            this.xGridColorComboBox.TabIndex = 1;
            // 
            // xGridWidthNumericRow
            // 
            this.xGridWidthNumericRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.xGridWidthNumericRow.Controls.Add(this.xGridWidthNumericLabel);
            this.xGridWidthNumericRow.Controls.Add(this.xGridWidthNumeric);
            this.xGridWidthNumericRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xGridWidthNumericRow.Location = new System.Drawing.Point(166, 0);
            this.xGridWidthNumericRow.Margin = new System.Windows.Forms.Padding(0);
            this.xGridWidthNumericRow.Name = "xGridWidthNumericRow";
            this.xGridWidthNumericRow.Size = new System.Drawing.Size(166, 45);
            this.xGridWidthNumericRow.TabIndex = 1;
            // 
            // xGridWidthNumericLabel
            // 
            this.xGridWidthNumericLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xGridWidthNumericLabel.ForeColor = System.Drawing.Color.White;
            this.xGridWidthNumericLabel.Location = new System.Drawing.Point(2, 2);
            this.xGridWidthNumericLabel.Name = "xGridWidthNumericLabel";
            this.xGridWidthNumericLabel.Size = new System.Drawing.Size(147, 15);
            this.xGridWidthNumericLabel.TabIndex = 0;
            this.xGridWidthNumericLabel.Text = "Major grid width";
            // 
            // xGridWidthNumeric
            // 
            this.xGridWidthNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xGridWidthNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.xGridWidthNumeric.DecimalPlaces = 2;
            this.xGridWidthNumeric.ForeColor = System.Drawing.Color.White;
            this.xGridWidthNumeric.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.xGridWidthNumeric.Location = new System.Drawing.Point(5, 20);
            this.xGridWidthNumeric.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.xGridWidthNumeric.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.xGridWidthNumeric.Name = "xGridWidthNumeric";
            this.xGridWidthNumeric.Size = new System.Drawing.Size(157, 20);
            this.xGridWidthNumeric.TabIndex = 1;
            this.xGridWidthNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // xMajorStyleRow
            // 
            this.xMajorStyleRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.xMajorStyleRow.ColumnCount = 2;
            this.xMajorStyleRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.xMajorStyleRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.xMajorStyleRow.Controls.Add(this.xGridDashComboBoxRow, 0, 0);
            this.xMajorStyleRow.Controls.Add(this.xGridAlphaNumericRow, 1, 0);
            this.xMajorStyleRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xMajorStyleRow.Location = new System.Drawing.Point(3, 245);
            this.xMajorStyleRow.Margin = new System.Windows.Forms.Padding(0);
            this.xMajorStyleRow.Name = "xMajorStyleRow";
            this.xMajorStyleRow.RowCount = 1;
            this.xMajorStyleRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.xMajorStyleRow.Size = new System.Drawing.Size(332, 45);
            this.xMajorStyleRow.TabIndex = 6;
            // 
            // xGridDashComboBoxRow
            // 
            this.xGridDashComboBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.xGridDashComboBoxRow.Controls.Add(this.xGridDashComboBoxLabel);
            this.xGridDashComboBoxRow.Controls.Add(this.xGridDashComboBox);
            this.xGridDashComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xGridDashComboBoxRow.Location = new System.Drawing.Point(0, 0);
            this.xGridDashComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.xGridDashComboBoxRow.Name = "xGridDashComboBoxRow";
            this.xGridDashComboBoxRow.Size = new System.Drawing.Size(166, 45);
            this.xGridDashComboBoxRow.TabIndex = 0;
            // 
            // xGridDashComboBoxLabel
            // 
            this.xGridDashComboBoxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xGridDashComboBoxLabel.ForeColor = System.Drawing.Color.White;
            this.xGridDashComboBoxLabel.Location = new System.Drawing.Point(2, 2);
            this.xGridDashComboBoxLabel.Name = "xGridDashComboBoxLabel";
            this.xGridDashComboBoxLabel.Size = new System.Drawing.Size(148, 15);
            this.xGridDashComboBoxLabel.TabIndex = 0;
            this.xGridDashComboBoxLabel.Text = "Major grid style";
            // 
            // xGridDashComboBox
            // 
            this.xGridDashComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xGridDashComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.xGridDashComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.xGridDashComboBox.ForeColor = System.Drawing.Color.White;
            this.xGridDashComboBox.IntegralHeight = false;
            this.xGridDashComboBox.Location = new System.Drawing.Point(5, 20);
            this.xGridDashComboBox.Name = "xGridDashComboBox";
            this.xGridDashComboBox.Size = new System.Drawing.Size(157, 21);
            this.xGridDashComboBox.TabIndex = 1;
            // 
            // xGridAlphaNumericRow
            // 
            this.xGridAlphaNumericRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.xGridAlphaNumericRow.Controls.Add(this.xGridAlphaNumericLabel);
            this.xGridAlphaNumericRow.Controls.Add(this.xGridAlphaNumeric);
            this.xGridAlphaNumericRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xGridAlphaNumericRow.Location = new System.Drawing.Point(166, 0);
            this.xGridAlphaNumericRow.Margin = new System.Windows.Forms.Padding(0);
            this.xGridAlphaNumericRow.Name = "xGridAlphaNumericRow";
            this.xGridAlphaNumericRow.Size = new System.Drawing.Size(166, 45);
            this.xGridAlphaNumericRow.TabIndex = 1;
            // 
            // xGridAlphaNumericLabel
            // 
            this.xGridAlphaNumericLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xGridAlphaNumericLabel.ForeColor = System.Drawing.Color.White;
            this.xGridAlphaNumericLabel.Location = new System.Drawing.Point(2, 2);
            this.xGridAlphaNumericLabel.Name = "xGridAlphaNumericLabel";
            this.xGridAlphaNumericLabel.Size = new System.Drawing.Size(147, 15);
            this.xGridAlphaNumericLabel.TabIndex = 0;
            this.xGridAlphaNumericLabel.Text = "Major grid alpha (0-255)";
            // 
            // xGridAlphaNumeric
            // 
            this.xGridAlphaNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xGridAlphaNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.xGridAlphaNumeric.ForeColor = System.Drawing.Color.White;
            this.xGridAlphaNumeric.Location = new System.Drawing.Point(5, 20);
            this.xGridAlphaNumeric.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.xGridAlphaNumeric.Name = "xGridAlphaNumeric";
            this.xGridAlphaNumeric.Size = new System.Drawing.Size(157, 20);
            this.xGridAlphaNumeric.TabIndex = 1;
            this.xGridAlphaNumeric.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // xMinorGridRow
            // 
            this.xMinorGridRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.xMinorGridRow.ColumnCount = 2;
            this.xMinorGridRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.xMinorGridRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.xMinorGridRow.Controls.Add(this.xMinorCheckBoxRow, 0, 0);
            this.xMinorGridRow.Controls.Add(this.xMinorColorComboBoxRow, 1, 0);
            this.xMinorGridRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xMinorGridRow.Location = new System.Drawing.Point(3, 290);
            this.xMinorGridRow.Margin = new System.Windows.Forms.Padding(0);
            this.xMinorGridRow.Name = "xMinorGridRow";
            this.xMinorGridRow.RowCount = 1;
            this.xMinorGridRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.xMinorGridRow.Size = new System.Drawing.Size(332, 45);
            this.xMinorGridRow.TabIndex = 7;
            // 
            // xMinorCheckBoxRow
            // 
            this.xMinorCheckBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.xMinorCheckBoxRow.Controls.Add(this.xMinorCheckBox);
            this.xMinorCheckBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xMinorCheckBoxRow.Location = new System.Drawing.Point(0, 0);
            this.xMinorCheckBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.xMinorCheckBoxRow.Name = "xMinorCheckBoxRow";
            this.xMinorCheckBoxRow.Size = new System.Drawing.Size(166, 45);
            this.xMinorCheckBoxRow.TabIndex = 0;
            // 
            // xMinorCheckBox
            // 
            this.xMinorCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xMinorCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.xMinorCheckBox.ForeColor = System.Drawing.Color.White;
            this.xMinorCheckBox.Location = new System.Drawing.Point(2, 10);
            this.xMinorCheckBox.Name = "xMinorCheckBox";
            this.xMinorCheckBox.Size = new System.Drawing.Size(149, 28);
            this.xMinorCheckBox.TabIndex = 0;
            this.xMinorCheckBox.Text = "Minor grid";
            this.xMinorCheckBox.UseVisualStyleBackColor = false;
            // 
            // xMinorColorComboBoxRow
            // 
            this.xMinorColorComboBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.xMinorColorComboBoxRow.Controls.Add(this.xMinorColorComboBoxLabel);
            this.xMinorColorComboBoxRow.Controls.Add(this.xMinorColorComboBox);
            this.xMinorColorComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xMinorColorComboBoxRow.Location = new System.Drawing.Point(166, 0);
            this.xMinorColorComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.xMinorColorComboBoxRow.Name = "xMinorColorComboBoxRow";
            this.xMinorColorComboBoxRow.Size = new System.Drawing.Size(166, 45);
            this.xMinorColorComboBoxRow.TabIndex = 1;
            // 
            // xMinorColorComboBoxLabel
            // 
            this.xMinorColorComboBoxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xMinorColorComboBoxLabel.ForeColor = System.Drawing.Color.White;
            this.xMinorColorComboBoxLabel.Location = new System.Drawing.Point(2, 2);
            this.xMinorColorComboBoxLabel.Name = "xMinorColorComboBoxLabel";
            this.xMinorColorComboBoxLabel.Size = new System.Drawing.Size(147, 15);
            this.xMinorColorComboBoxLabel.TabIndex = 0;
            this.xMinorColorComboBoxLabel.Text = "Minor grid color";
            // 
            // xMinorColorComboBox
            // 
            this.xMinorColorComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xMinorColorComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.xMinorColorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.xMinorColorComboBox.ForeColor = System.Drawing.Color.White;
            this.xMinorColorComboBox.IntegralHeight = false;
            this.xMinorColorComboBox.Location = new System.Drawing.Point(5, 20);
            this.xMinorColorComboBox.Name = "xMinorColorComboBox";
            this.xMinorColorComboBox.Size = new System.Drawing.Size(157, 21);
            this.xMinorColorComboBox.TabIndex = 1;
            // 
            // xMinorStrokeRow
            // 
            this.xMinorStrokeRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.xMinorStrokeRow.ColumnCount = 2;
            this.xMinorStrokeRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.xMinorStrokeRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.xMinorStrokeRow.Controls.Add(this.xMinorWidthNumericRow, 0, 0);
            this.xMinorStrokeRow.Controls.Add(this.xMinorDashComboBoxRow, 1, 0);
            this.xMinorStrokeRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xMinorStrokeRow.Location = new System.Drawing.Point(3, 335);
            this.xMinorStrokeRow.Margin = new System.Windows.Forms.Padding(0);
            this.xMinorStrokeRow.Name = "xMinorStrokeRow";
            this.xMinorStrokeRow.RowCount = 1;
            this.xMinorStrokeRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.xMinorStrokeRow.Size = new System.Drawing.Size(332, 45);
            this.xMinorStrokeRow.TabIndex = 8;
            // 
            // xMinorWidthNumericRow
            // 
            this.xMinorWidthNumericRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.xMinorWidthNumericRow.Controls.Add(this.xMinorWidthNumericLabel);
            this.xMinorWidthNumericRow.Controls.Add(this.xMinorWidthNumeric);
            this.xMinorWidthNumericRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xMinorWidthNumericRow.Location = new System.Drawing.Point(0, 0);
            this.xMinorWidthNumericRow.Margin = new System.Windows.Forms.Padding(0);
            this.xMinorWidthNumericRow.Name = "xMinorWidthNumericRow";
            this.xMinorWidthNumericRow.Size = new System.Drawing.Size(166, 45);
            this.xMinorWidthNumericRow.TabIndex = 0;
            // 
            // xMinorWidthNumericLabel
            // 
            this.xMinorWidthNumericLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xMinorWidthNumericLabel.ForeColor = System.Drawing.Color.White;
            this.xMinorWidthNumericLabel.Location = new System.Drawing.Point(2, 2);
            this.xMinorWidthNumericLabel.Name = "xMinorWidthNumericLabel";
            this.xMinorWidthNumericLabel.Size = new System.Drawing.Size(148, 15);
            this.xMinorWidthNumericLabel.TabIndex = 0;
            this.xMinorWidthNumericLabel.Text = "Minor grid width";
            // 
            // xMinorWidthNumeric
            // 
            this.xMinorWidthNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xMinorWidthNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.xMinorWidthNumeric.DecimalPlaces = 2;
            this.xMinorWidthNumeric.ForeColor = System.Drawing.Color.White;
            this.xMinorWidthNumeric.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.xMinorWidthNumeric.Location = new System.Drawing.Point(5, 20);
            this.xMinorWidthNumeric.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.xMinorWidthNumeric.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.xMinorWidthNumeric.Name = "xMinorWidthNumeric";
            this.xMinorWidthNumeric.Size = new System.Drawing.Size(157, 20);
            this.xMinorWidthNumeric.TabIndex = 1;
            this.xMinorWidthNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // xMinorDashComboBoxRow
            // 
            this.xMinorDashComboBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.xMinorDashComboBoxRow.Controls.Add(this.xMinorDashComboBoxLabel);
            this.xMinorDashComboBoxRow.Controls.Add(this.xMinorDashComboBox);
            this.xMinorDashComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xMinorDashComboBoxRow.Location = new System.Drawing.Point(166, 0);
            this.xMinorDashComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.xMinorDashComboBoxRow.Name = "xMinorDashComboBoxRow";
            this.xMinorDashComboBoxRow.Size = new System.Drawing.Size(166, 45);
            this.xMinorDashComboBoxRow.TabIndex = 1;
            // 
            // xMinorDashComboBoxLabel
            // 
            this.xMinorDashComboBoxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xMinorDashComboBoxLabel.ForeColor = System.Drawing.Color.White;
            this.xMinorDashComboBoxLabel.Location = new System.Drawing.Point(2, 2);
            this.xMinorDashComboBoxLabel.Name = "xMinorDashComboBoxLabel";
            this.xMinorDashComboBoxLabel.Size = new System.Drawing.Size(147, 15);
            this.xMinorDashComboBoxLabel.TabIndex = 0;
            this.xMinorDashComboBoxLabel.Text = "Minor grid style";
            // 
            // xMinorDashComboBox
            // 
            this.xMinorDashComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xMinorDashComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.xMinorDashComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.xMinorDashComboBox.ForeColor = System.Drawing.Color.White;
            this.xMinorDashComboBox.IntegralHeight = false;
            this.xMinorDashComboBox.Location = new System.Drawing.Point(5, 20);
            this.xMinorDashComboBox.Name = "xMinorDashComboBox";
            this.xMinorDashComboBox.Size = new System.Drawing.Size(157, 21);
            this.xMinorDashComboBox.TabIndex = 1;
            // 
            // xMinorOpacityRow
            // 
            this.xMinorOpacityRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.xMinorOpacityRow.ColumnCount = 2;
            this.xMinorOpacityRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.xMinorOpacityRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.xMinorOpacityRow.Controls.Add(this.xMinorAlphaNumericRow, 0, 0);
            this.xMinorOpacityRow.Controls.Add(this.xLogBaseBoxRow, 1, 0);
            this.xMinorOpacityRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xMinorOpacityRow.Location = new System.Drawing.Point(3, 380);
            this.xMinorOpacityRow.Margin = new System.Windows.Forms.Padding(0);
            this.xMinorOpacityRow.Name = "xMinorOpacityRow";
            this.xMinorOpacityRow.RowCount = 1;
            this.xMinorOpacityRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.xMinorOpacityRow.Size = new System.Drawing.Size(332, 45);
            this.xMinorOpacityRow.TabIndex = 9;
            // 
            // xMinorAlphaNumericRow
            // 
            this.xMinorAlphaNumericRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.xMinorAlphaNumericRow.Controls.Add(this.xMinorAlphaNumericLabel);
            this.xMinorAlphaNumericRow.Controls.Add(this.xMinorAlphaNumeric);
            this.xMinorAlphaNumericRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xMinorAlphaNumericRow.Location = new System.Drawing.Point(0, 0);
            this.xMinorAlphaNumericRow.Margin = new System.Windows.Forms.Padding(0);
            this.xMinorAlphaNumericRow.Name = "xMinorAlphaNumericRow";
            this.xMinorAlphaNumericRow.Size = new System.Drawing.Size(166, 45);
            this.xMinorAlphaNumericRow.TabIndex = 0;
            // 
            // xMinorAlphaNumericLabel
            // 
            this.xMinorAlphaNumericLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xMinorAlphaNumericLabel.ForeColor = System.Drawing.Color.White;
            this.xMinorAlphaNumericLabel.Location = new System.Drawing.Point(2, 2);
            this.xMinorAlphaNumericLabel.Name = "xMinorAlphaNumericLabel";
            this.xMinorAlphaNumericLabel.Size = new System.Drawing.Size(148, 15);
            this.xMinorAlphaNumericLabel.TabIndex = 0;
            this.xMinorAlphaNumericLabel.Text = "Minor grid alpha (0-255)";
            // 
            // xMinorAlphaNumeric
            // 
            this.xMinorAlphaNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xMinorAlphaNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.xMinorAlphaNumeric.ForeColor = System.Drawing.Color.White;
            this.xMinorAlphaNumeric.Location = new System.Drawing.Point(5, 20);
            this.xMinorAlphaNumeric.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.xMinorAlphaNumeric.Name = "xMinorAlphaNumeric";
            this.xMinorAlphaNumeric.Size = new System.Drawing.Size(157, 20);
            this.xMinorAlphaNumeric.TabIndex = 1;
            this.xMinorAlphaNumeric.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // xLogBaseBoxRow
            // 
            this.xLogBaseBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.xLogBaseBoxRow.Controls.Add(this.xLogBaseBoxLabel);
            this.xLogBaseBoxRow.Controls.Add(this.xLogBaseBox);
            this.xLogBaseBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xLogBaseBoxRow.Location = new System.Drawing.Point(166, 0);
            this.xLogBaseBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.xLogBaseBoxRow.Name = "xLogBaseBoxRow";
            this.xLogBaseBoxRow.Size = new System.Drawing.Size(166, 45);
            this.xLogBaseBoxRow.TabIndex = 1;
            // 
            // xLogBaseBoxLabel
            // 
            this.xLogBaseBoxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xLogBaseBoxLabel.ForeColor = System.Drawing.Color.White;
            this.xLogBaseBoxLabel.Location = new System.Drawing.Point(2, 2);
            this.xLogBaseBoxLabel.Name = "xLogBaseBoxLabel";
            this.xLogBaseBoxLabel.Size = new System.Drawing.Size(147, 15);
            this.xLogBaseBoxLabel.TabIndex = 0;
            this.xLogBaseBoxLabel.Text = "Logarithmic base";
            // 
            // xLogBaseBox
            // 
            this.xLogBaseBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xLogBaseBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.xLogBaseBox.ForeColor = System.Drawing.Color.White;
            this.xLogBaseBox.Location = new System.Drawing.Point(5, 20);
            this.xLogBaseBox.Name = "xLogBaseBox";
            this.xLogBaseBox.Size = new System.Drawing.Size(157, 20);
            this.xLogBaseBox.TabIndex = 1;
            // 
            // xFontRow
            // 
            this.xFontRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.xFontRow.ColumnCount = 1;
            this.xFontRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.xFontRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.xFontRow.Controls.Add(this.xFontComboBoxRow, 0, 0);
            this.xFontRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xFontRow.Location = new System.Drawing.Point(3, 425);
            this.xFontRow.Margin = new System.Windows.Forms.Padding(0);
            this.xFontRow.Name = "xFontRow";
            this.xFontRow.RowCount = 1;
            this.xFontRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.xFontRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.xFontRow.Size = new System.Drawing.Size(332, 45);
            this.xFontRow.TabIndex = 10;
            // 
            // xFontComboBoxRow
            // 
            this.xFontComboBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.xFontComboBoxRow.Controls.Add(this.xFontComboBoxLabel);
            this.xFontComboBoxRow.Controls.Add(this.xFontComboBox);
            this.xFontComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xFontComboBoxRow.Location = new System.Drawing.Point(0, 0);
            this.xFontComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.xFontComboBoxRow.Name = "xFontComboBoxRow";
            this.xFontComboBoxRow.Size = new System.Drawing.Size(332, 45);
            this.xFontComboBoxRow.TabIndex = 0;
            // 
            // xFontComboBoxLabel
            // 
            this.xFontComboBoxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xFontComboBoxLabel.ForeColor = System.Drawing.Color.White;
            this.xFontComboBoxLabel.Location = new System.Drawing.Point(2, 2);
            this.xFontComboBoxLabel.Name = "xFontComboBoxLabel";
            this.xFontComboBoxLabel.Size = new System.Drawing.Size(314, 15);
            this.xFontComboBoxLabel.TabIndex = 0;
            this.xFontComboBoxLabel.Text = "Axis font family";
            // 
            // xFontComboBox
            // 
            this.xFontComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xFontComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.xFontComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.xFontComboBox.ForeColor = System.Drawing.Color.White;
            this.xFontComboBox.IntegralHeight = false;
            this.xFontComboBox.Location = new System.Drawing.Point(5, 20);
            this.xFontComboBox.Name = "xFontComboBox";
            this.xFontComboBox.Size = new System.Drawing.Size(323, 21);
            this.xFontComboBox.TabIndex = 1;
            // 
            // yAxisGroup
            // 
            this.yAxisGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.yAxisGroup.Controls.Add(this.yFields);
            this.yAxisGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yAxisGroup.ForeColor = System.Drawing.Color.White;
            this.yAxisGroup.Location = new System.Drawing.Point(737, 13);
            this.yAxisGroup.Margin = new System.Windows.Forms.Padding(5);
            this.yAxisGroup.Name = "yAxisGroup";
            this.yAxisGroup.Padding = new System.Windows.Forms.Padding(2);
            this.yAxisGroup.Size = new System.Drawing.Size(359, 445);
            this.yAxisGroup.TabIndex = 2;
            this.yAxisGroup.TabStop = false;
            this.yAxisGroup.Text = "Y axis";
            // 
            // yFields
            // 
            this.yFields.AutoScroll = true;
            this.yFields.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.yFields.ColumnCount = 1;
            this.yFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.yFields.Controls.Add(this.yFontColorRow, 0, 11);
            this.yFields.Controls.Add(this.yDefaultsButtonRow, 0, 0);
            this.yFields.Controls.Add(this.yColumnComboBoxRow, 0, 1);
            this.yFields.Controls.Add(this.yModeRow, 0, 2);
            this.yFields.Controls.Add(this.yLimitsRow, 0, 3);
            this.yFields.Controls.Add(this.yTicksRow, 0, 4);
            this.yFields.Controls.Add(this.yMajorGridRow, 0, 5);
            this.yFields.Controls.Add(this.yMajorStyleRow, 0, 6);
            this.yFields.Controls.Add(this.yMinorGridRow, 0, 7);
            this.yFields.Controls.Add(this.yMinorStrokeRow, 0, 8);
            this.yFields.Controls.Add(this.yMinorOpacityRow, 0, 9);
            this.yFields.Controls.Add(this.yFontRow, 0, 10);
            this.yFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yFields.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.yFields.Location = new System.Drawing.Point(2, 15);
            this.yFields.Name = "yFields";
            this.yFields.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.yFields.RowCount = 12;
            this.yFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.yFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.yFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.yFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.yFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.yFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.yFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.yFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.yFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.yFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.yFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.yFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.yFields.Size = new System.Drawing.Size(355, 428);
            this.yFields.TabIndex = 0;
            // 
            // yFontColorRow
            // 
            this.yFontColorRow.ColumnCount = 2;
            this.yFontColorRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.yFontColorRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.yFontColorRow.Controls.Add(this.yFontSizeNumericRow, 1, 0);
            this.yFontColorRow.Controls.Add(this.yFontColorComboBoxRow, 0, 0);
            this.yFontColorRow.Dock = System.Windows.Forms.DockStyle.Top;
            this.yFontColorRow.Location = new System.Drawing.Point(3, 470);
            this.yFontColorRow.Margin = new System.Windows.Forms.Padding(0);
            this.yFontColorRow.Name = "yFontColorRow";
            this.yFontColorRow.RowCount = 1;
            this.yFontColorRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.yFontColorRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.yFontColorRow.Size = new System.Drawing.Size(332, 45);
            this.yFontColorRow.TabIndex = 1;
            // 
            // yFontSizeNumericRow
            // 
            this.yFontSizeNumericRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.yFontSizeNumericRow.Controls.Add(this.yFontSizeNumericLabel);
            this.yFontSizeNumericRow.Controls.Add(this.yFontSizeNumeric);
            this.yFontSizeNumericRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yFontSizeNumericRow.Location = new System.Drawing.Point(166, 0);
            this.yFontSizeNumericRow.Margin = new System.Windows.Forms.Padding(0);
            this.yFontSizeNumericRow.Name = "yFontSizeNumericRow";
            this.yFontSizeNumericRow.Size = new System.Drawing.Size(166, 45);
            this.yFontSizeNumericRow.TabIndex = 1;
            // 
            // yFontSizeNumericLabel
            // 
            this.yFontSizeNumericLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yFontSizeNumericLabel.ForeColor = System.Drawing.Color.White;
            this.yFontSizeNumericLabel.Location = new System.Drawing.Point(2, 2);
            this.yFontSizeNumericLabel.Name = "yFontSizeNumericLabel";
            this.yFontSizeNumericLabel.Size = new System.Drawing.Size(147, 15);
            this.yFontSizeNumericLabel.TabIndex = 0;
            this.yFontSizeNumericLabel.Text = "Axis font size";
            // 
            // yFontSizeNumeric
            // 
            this.yFontSizeNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yFontSizeNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.yFontSizeNumeric.DecimalPlaces = 2;
            this.yFontSizeNumeric.ForeColor = System.Drawing.Color.White;
            this.yFontSizeNumeric.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.yFontSizeNumeric.Location = new System.Drawing.Point(5, 20);
            this.yFontSizeNumeric.Maximum = new decimal(new int[] {
            36,
            0,
            0,
            0});
            this.yFontSizeNumeric.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.yFontSizeNumeric.Name = "yFontSizeNumeric";
            this.yFontSizeNumeric.Size = new System.Drawing.Size(157, 20);
            this.yFontSizeNumeric.TabIndex = 1;
            this.yFontSizeNumeric.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // yFontColorComboBoxRow
            // 
            this.yFontColorComboBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.yFontColorComboBoxRow.Controls.Add(this.yFontColorComboBoxLabel);
            this.yFontColorComboBoxRow.Controls.Add(this.yFontColorComboBox);
            this.yFontColorComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yFontColorComboBoxRow.Location = new System.Drawing.Point(0, 0);
            this.yFontColorComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.yFontColorComboBoxRow.Name = "yFontColorComboBoxRow";
            this.yFontColorComboBoxRow.Size = new System.Drawing.Size(166, 45);
            this.yFontColorComboBoxRow.TabIndex = 11;
            // 
            // yFontColorComboBoxLabel
            // 
            this.yFontColorComboBoxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yFontColorComboBoxLabel.ForeColor = System.Drawing.Color.White;
            this.yFontColorComboBoxLabel.Location = new System.Drawing.Point(2, 2);
            this.yFontColorComboBoxLabel.Name = "yFontColorComboBoxLabel";
            this.yFontColorComboBoxLabel.Size = new System.Drawing.Size(148, 15);
            this.yFontColorComboBoxLabel.TabIndex = 0;
            this.yFontColorComboBoxLabel.Text = "Axis font color";
            // 
            // yFontColorComboBox
            // 
            this.yFontColorComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yFontColorComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.yFontColorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yFontColorComboBox.ForeColor = System.Drawing.Color.White;
            this.yFontColorComboBox.IntegralHeight = false;
            this.yFontColorComboBox.Location = new System.Drawing.Point(5, 20);
            this.yFontColorComboBox.Name = "yFontColorComboBox";
            this.yFontColorComboBox.Size = new System.Drawing.Size(157, 21);
            this.yFontColorComboBox.TabIndex = 1;
            // 
            // yDefaultsButtonRow
            // 
            this.yDefaultsButtonRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.yDefaultsButtonRow.Controls.Add(this.yDefaultsButton);
            this.yDefaultsButtonRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yDefaultsButtonRow.Location = new System.Drawing.Point(3, 0);
            this.yDefaultsButtonRow.Margin = new System.Windows.Forms.Padding(0);
            this.yDefaultsButtonRow.Name = "yDefaultsButtonRow";
            this.yDefaultsButtonRow.Size = new System.Drawing.Size(332, 40);
            this.yDefaultsButtonRow.TabIndex = 0;
            // 
            // yDefaultsButton
            // 
            this.yDefaultsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yDefaultsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.yDefaultsButton.ForeColor = System.Drawing.Color.White;
            this.yDefaultsButton.Location = new System.Drawing.Point(6, 6);
            this.yDefaultsButton.Name = "yDefaultsButton";
            this.yDefaultsButton.Size = new System.Drawing.Size(315, 30);
            this.yDefaultsButton.TabIndex = 0;
            this.yDefaultsButton.Text = "Restore Y defaults";
            this.yDefaultsButton.UseVisualStyleBackColor = false;
            // 
            // yColumnComboBoxRow
            // 
            this.yColumnComboBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.yColumnComboBoxRow.Controls.Add(this.yColumnComboBoxLabel);
            this.yColumnComboBoxRow.Controls.Add(this.yColumnComboBox);
            this.yColumnComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yColumnComboBoxRow.Location = new System.Drawing.Point(3, 40);
            this.yColumnComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.yColumnComboBoxRow.Name = "yColumnComboBoxRow";
            this.yColumnComboBoxRow.Size = new System.Drawing.Size(332, 45);
            this.yColumnComboBoxRow.TabIndex = 1;
            // 
            // yColumnComboBoxLabel
            // 
            this.yColumnComboBoxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yColumnComboBoxLabel.ForeColor = System.Drawing.Color.White;
            this.yColumnComboBoxLabel.Location = new System.Drawing.Point(2, 2);
            this.yColumnComboBoxLabel.Name = "yColumnComboBoxLabel";
            this.yColumnComboBoxLabel.Size = new System.Drawing.Size(314, 15);
            this.yColumnComboBoxLabel.TabIndex = 0;
            this.yColumnComboBoxLabel.Text = "Y column";
            // 
            // yColumnComboBox
            // 
            this.yColumnComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yColumnComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.yColumnComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yColumnComboBox.ForeColor = System.Drawing.Color.White;
            this.yColumnComboBox.IntegralHeight = false;
            this.yColumnComboBox.Location = new System.Drawing.Point(5, 20);
            this.yColumnComboBox.Name = "yColumnComboBox";
            this.yColumnComboBox.Size = new System.Drawing.Size(323, 21);
            this.yColumnComboBox.TabIndex = 1;
            // 
            // yModeRow
            // 
            this.yModeRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.yModeRow.ColumnCount = 2;
            this.yModeRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.yModeRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.yModeRow.Controls.Add(this.yAutoCheckBoxRow, 0, 0);
            this.yModeRow.Controls.Add(this.yLogCheckBoxRow, 1, 0);
            this.yModeRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yModeRow.Location = new System.Drawing.Point(3, 85);
            this.yModeRow.Margin = new System.Windows.Forms.Padding(0);
            this.yModeRow.Name = "yModeRow";
            this.yModeRow.RowCount = 1;
            this.yModeRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.yModeRow.Size = new System.Drawing.Size(332, 25);
            this.yModeRow.TabIndex = 2;
            // 
            // yAutoCheckBoxRow
            // 
            this.yAutoCheckBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.yAutoCheckBoxRow.Controls.Add(this.yAutoCheckBox);
            this.yAutoCheckBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yAutoCheckBoxRow.Location = new System.Drawing.Point(0, 0);
            this.yAutoCheckBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.yAutoCheckBoxRow.Name = "yAutoCheckBoxRow";
            this.yAutoCheckBoxRow.Size = new System.Drawing.Size(166, 25);
            this.yAutoCheckBoxRow.TabIndex = 0;
            // 
            // yAutoCheckBox
            // 
            this.yAutoCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yAutoCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.yAutoCheckBox.Checked = true;
            this.yAutoCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.yAutoCheckBox.ForeColor = System.Drawing.Color.White;
            this.yAutoCheckBox.Location = new System.Drawing.Point(2, 2);
            this.yAutoCheckBox.Name = "yAutoCheckBox";
            this.yAutoCheckBox.Size = new System.Drawing.Size(149, 28);
            this.yAutoCheckBox.TabIndex = 0;
            this.yAutoCheckBox.Text = "Auto-scale Y";
            this.yAutoCheckBox.UseVisualStyleBackColor = false;
            // 
            // yLogCheckBoxRow
            // 
            this.yLogCheckBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.yLogCheckBoxRow.Controls.Add(this.yLogCheckBox);
            this.yLogCheckBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yLogCheckBoxRow.Location = new System.Drawing.Point(166, 0);
            this.yLogCheckBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.yLogCheckBoxRow.Name = "yLogCheckBoxRow";
            this.yLogCheckBoxRow.Size = new System.Drawing.Size(166, 25);
            this.yLogCheckBoxRow.TabIndex = 1;
            // 
            // yLogCheckBox
            // 
            this.yLogCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yLogCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.yLogCheckBox.ForeColor = System.Drawing.Color.White;
            this.yLogCheckBox.Location = new System.Drawing.Point(2, 2);
            this.yLogCheckBox.Name = "yLogCheckBox";
            this.yLogCheckBox.Size = new System.Drawing.Size(149, 28);
            this.yLogCheckBox.TabIndex = 0;
            this.yLogCheckBox.Text = "Logarithmic Y axis";
            this.yLogCheckBox.UseVisualStyleBackColor = false;
            // 
            // yLimitsRow
            // 
            this.yLimitsRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.yLimitsRow.ColumnCount = 2;
            this.yLimitsRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.yLimitsRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.yLimitsRow.Controls.Add(this.yMinimumBoxRow, 0, 0);
            this.yLimitsRow.Controls.Add(this.yMaximumBoxRow, 1, 0);
            this.yLimitsRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yLimitsRow.Location = new System.Drawing.Point(3, 110);
            this.yLimitsRow.Margin = new System.Windows.Forms.Padding(0);
            this.yLimitsRow.Name = "yLimitsRow";
            this.yLimitsRow.RowCount = 1;
            this.yLimitsRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.yLimitsRow.Size = new System.Drawing.Size(332, 45);
            this.yLimitsRow.TabIndex = 3;
            // 
            // yMinimumBoxRow
            // 
            this.yMinimumBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.yMinimumBoxRow.Controls.Add(this.yMinimumBoxLabel);
            this.yMinimumBoxRow.Controls.Add(this.yMinimumBox);
            this.yMinimumBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yMinimumBoxRow.Location = new System.Drawing.Point(0, 0);
            this.yMinimumBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.yMinimumBoxRow.Name = "yMinimumBoxRow";
            this.yMinimumBoxRow.Size = new System.Drawing.Size(166, 45);
            this.yMinimumBoxRow.TabIndex = 0;
            // 
            // yMinimumBoxLabel
            // 
            this.yMinimumBoxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yMinimumBoxLabel.ForeColor = System.Drawing.Color.White;
            this.yMinimumBoxLabel.Location = new System.Drawing.Point(2, 2);
            this.yMinimumBoxLabel.Name = "yMinimumBoxLabel";
            this.yMinimumBoxLabel.Size = new System.Drawing.Size(148, 15);
            this.yMinimumBoxLabel.TabIndex = 0;
            this.yMinimumBoxLabel.Text = "Y minimum";
            // 
            // yMinimumBox
            // 
            this.yMinimumBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yMinimumBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.yMinimumBox.ForeColor = System.Drawing.Color.White;
            this.yMinimumBox.Location = new System.Drawing.Point(5, 20);
            this.yMinimumBox.Name = "yMinimumBox";
            this.yMinimumBox.Size = new System.Drawing.Size(157, 20);
            this.yMinimumBox.TabIndex = 1;
            // 
            // yMaximumBoxRow
            // 
            this.yMaximumBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.yMaximumBoxRow.Controls.Add(this.yMaximumBoxLabel);
            this.yMaximumBoxRow.Controls.Add(this.yMaximumBox);
            this.yMaximumBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yMaximumBoxRow.Location = new System.Drawing.Point(166, 0);
            this.yMaximumBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.yMaximumBoxRow.Name = "yMaximumBoxRow";
            this.yMaximumBoxRow.Size = new System.Drawing.Size(166, 45);
            this.yMaximumBoxRow.TabIndex = 1;
            // 
            // yMaximumBoxLabel
            // 
            this.yMaximumBoxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yMaximumBoxLabel.ForeColor = System.Drawing.Color.White;
            this.yMaximumBoxLabel.Location = new System.Drawing.Point(2, 2);
            this.yMaximumBoxLabel.Name = "yMaximumBoxLabel";
            this.yMaximumBoxLabel.Size = new System.Drawing.Size(147, 15);
            this.yMaximumBoxLabel.TabIndex = 0;
            this.yMaximumBoxLabel.Text = "Y maximum";
            // 
            // yMaximumBox
            // 
            this.yMaximumBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yMaximumBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.yMaximumBox.ForeColor = System.Drawing.Color.White;
            this.yMaximumBox.Location = new System.Drawing.Point(5, 20);
            this.yMaximumBox.Name = "yMaximumBox";
            this.yMaximumBox.Size = new System.Drawing.Size(157, 20);
            this.yMaximumBox.TabIndex = 1;
            // 
            // yTicksRow
            // 
            this.yTicksRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.yTicksRow.ColumnCount = 2;
            this.yTicksRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.yTicksRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.yTicksRow.Controls.Add(this.yGridIntervalBoxRow, 0, 0);
            this.yTicksRow.Controls.Add(this.yDecimalsNumericRow, 1, 0);
            this.yTicksRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yTicksRow.Location = new System.Drawing.Point(3, 155);
            this.yTicksRow.Margin = new System.Windows.Forms.Padding(0);
            this.yTicksRow.Name = "yTicksRow";
            this.yTicksRow.RowCount = 1;
            this.yTicksRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.yTicksRow.Size = new System.Drawing.Size(332, 45);
            this.yTicksRow.TabIndex = 4;
            // 
            // yGridIntervalBoxRow
            // 
            this.yGridIntervalBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.yGridIntervalBoxRow.Controls.Add(this.yGridIntervalBoxLabel);
            this.yGridIntervalBoxRow.Controls.Add(this.yGridIntervalBox);
            this.yGridIntervalBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yGridIntervalBoxRow.Location = new System.Drawing.Point(0, 0);
            this.yGridIntervalBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.yGridIntervalBoxRow.Name = "yGridIntervalBoxRow";
            this.yGridIntervalBoxRow.Size = new System.Drawing.Size(166, 45);
            this.yGridIntervalBoxRow.TabIndex = 0;
            // 
            // yGridIntervalBoxLabel
            // 
            this.yGridIntervalBoxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yGridIntervalBoxLabel.ForeColor = System.Drawing.Color.White;
            this.yGridIntervalBoxLabel.Location = new System.Drawing.Point(2, 2);
            this.yGridIntervalBoxLabel.Name = "yGridIntervalBoxLabel";
            this.yGridIntervalBoxLabel.Size = new System.Drawing.Size(162, 15);
            this.yGridIntervalBoxLabel.TabIndex = 0;
            this.yGridIntervalBoxLabel.Text = "Major grid interval (0 = auto)";
            // 
            // yGridIntervalBox
            // 
            this.yGridIntervalBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yGridIntervalBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.yGridIntervalBox.ForeColor = System.Drawing.Color.White;
            this.yGridIntervalBox.Location = new System.Drawing.Point(5, 20);
            this.yGridIntervalBox.Name = "yGridIntervalBox";
            this.yGridIntervalBox.Size = new System.Drawing.Size(157, 20);
            this.yGridIntervalBox.TabIndex = 1;
            // 
            // yDecimalsNumericRow
            // 
            this.yDecimalsNumericRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.yDecimalsNumericRow.Controls.Add(this.yDecimalsNumericLabel);
            this.yDecimalsNumericRow.Controls.Add(this.yDecimalsNumeric);
            this.yDecimalsNumericRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yDecimalsNumericRow.Location = new System.Drawing.Point(166, 0);
            this.yDecimalsNumericRow.Margin = new System.Windows.Forms.Padding(0);
            this.yDecimalsNumericRow.Name = "yDecimalsNumericRow";
            this.yDecimalsNumericRow.Size = new System.Drawing.Size(166, 45);
            this.yDecimalsNumericRow.TabIndex = 1;
            // 
            // yDecimalsNumericLabel
            // 
            this.yDecimalsNumericLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yDecimalsNumericLabel.ForeColor = System.Drawing.Color.White;
            this.yDecimalsNumericLabel.Location = new System.Drawing.Point(2, 2);
            this.yDecimalsNumericLabel.Name = "yDecimalsNumericLabel";
            this.yDecimalsNumericLabel.Size = new System.Drawing.Size(147, 15);
            this.yDecimalsNumericLabel.TabIndex = 0;
            this.yDecimalsNumericLabel.Text = "Label decimals";
            // 
            // yDecimalsNumeric
            // 
            this.yDecimalsNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yDecimalsNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.yDecimalsNumeric.ForeColor = System.Drawing.Color.White;
            this.yDecimalsNumeric.Location = new System.Drawing.Point(5, 20);
            this.yDecimalsNumeric.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.yDecimalsNumeric.Name = "yDecimalsNumeric";
            this.yDecimalsNumeric.Size = new System.Drawing.Size(157, 20);
            this.yDecimalsNumeric.TabIndex = 1;
            this.yDecimalsNumeric.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // yMajorGridRow
            // 
            this.yMajorGridRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.yMajorGridRow.ColumnCount = 2;
            this.yMajorGridRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.yMajorGridRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.yMajorGridRow.Controls.Add(this.yGridColorComboBoxRow, 0, 0);
            this.yMajorGridRow.Controls.Add(this.yGridWidthNumericRow, 1, 0);
            this.yMajorGridRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yMajorGridRow.Location = new System.Drawing.Point(3, 200);
            this.yMajorGridRow.Margin = new System.Windows.Forms.Padding(0);
            this.yMajorGridRow.Name = "yMajorGridRow";
            this.yMajorGridRow.RowCount = 1;
            this.yMajorGridRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.yMajorGridRow.Size = new System.Drawing.Size(332, 45);
            this.yMajorGridRow.TabIndex = 5;
            // 
            // yGridColorComboBoxRow
            // 
            this.yGridColorComboBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.yGridColorComboBoxRow.Controls.Add(this.yGridColorComboBoxLabel);
            this.yGridColorComboBoxRow.Controls.Add(this.yGridColorComboBox);
            this.yGridColorComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yGridColorComboBoxRow.Location = new System.Drawing.Point(0, 0);
            this.yGridColorComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.yGridColorComboBoxRow.Name = "yGridColorComboBoxRow";
            this.yGridColorComboBoxRow.Size = new System.Drawing.Size(166, 45);
            this.yGridColorComboBoxRow.TabIndex = 0;
            // 
            // yGridColorComboBoxLabel
            // 
            this.yGridColorComboBoxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yGridColorComboBoxLabel.ForeColor = System.Drawing.Color.White;
            this.yGridColorComboBoxLabel.Location = new System.Drawing.Point(2, 2);
            this.yGridColorComboBoxLabel.Name = "yGridColorComboBoxLabel";
            this.yGridColorComboBoxLabel.Size = new System.Drawing.Size(148, 15);
            this.yGridColorComboBoxLabel.TabIndex = 0;
            this.yGridColorComboBoxLabel.Text = "Major grid color";
            // 
            // yGridColorComboBox
            // 
            this.yGridColorComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yGridColorComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.yGridColorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yGridColorComboBox.ForeColor = System.Drawing.Color.White;
            this.yGridColorComboBox.IntegralHeight = false;
            this.yGridColorComboBox.Location = new System.Drawing.Point(5, 20);
            this.yGridColorComboBox.Name = "yGridColorComboBox";
            this.yGridColorComboBox.Size = new System.Drawing.Size(157, 21);
            this.yGridColorComboBox.TabIndex = 1;
            // 
            // yGridWidthNumericRow
            // 
            this.yGridWidthNumericRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.yGridWidthNumericRow.Controls.Add(this.yGridWidthNumericLabel);
            this.yGridWidthNumericRow.Controls.Add(this.yGridWidthNumeric);
            this.yGridWidthNumericRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yGridWidthNumericRow.Location = new System.Drawing.Point(166, 0);
            this.yGridWidthNumericRow.Margin = new System.Windows.Forms.Padding(0);
            this.yGridWidthNumericRow.Name = "yGridWidthNumericRow";
            this.yGridWidthNumericRow.Size = new System.Drawing.Size(166, 45);
            this.yGridWidthNumericRow.TabIndex = 1;
            // 
            // yGridWidthNumericLabel
            // 
            this.yGridWidthNumericLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yGridWidthNumericLabel.ForeColor = System.Drawing.Color.White;
            this.yGridWidthNumericLabel.Location = new System.Drawing.Point(2, 2);
            this.yGridWidthNumericLabel.Name = "yGridWidthNumericLabel";
            this.yGridWidthNumericLabel.Size = new System.Drawing.Size(147, 15);
            this.yGridWidthNumericLabel.TabIndex = 0;
            this.yGridWidthNumericLabel.Text = "Major grid width";
            // 
            // yGridWidthNumeric
            // 
            this.yGridWidthNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yGridWidthNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.yGridWidthNumeric.DecimalPlaces = 2;
            this.yGridWidthNumeric.ForeColor = System.Drawing.Color.White;
            this.yGridWidthNumeric.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.yGridWidthNumeric.Location = new System.Drawing.Point(5, 20);
            this.yGridWidthNumeric.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.yGridWidthNumeric.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.yGridWidthNumeric.Name = "yGridWidthNumeric";
            this.yGridWidthNumeric.Size = new System.Drawing.Size(157, 20);
            this.yGridWidthNumeric.TabIndex = 1;
            this.yGridWidthNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // yMajorStyleRow
            // 
            this.yMajorStyleRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.yMajorStyleRow.ColumnCount = 2;
            this.yMajorStyleRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.yMajorStyleRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.yMajorStyleRow.Controls.Add(this.yGridDashComboBoxRow, 0, 0);
            this.yMajorStyleRow.Controls.Add(this.yGridAlphaNumericRow, 1, 0);
            this.yMajorStyleRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yMajorStyleRow.Location = new System.Drawing.Point(3, 245);
            this.yMajorStyleRow.Margin = new System.Windows.Forms.Padding(0);
            this.yMajorStyleRow.Name = "yMajorStyleRow";
            this.yMajorStyleRow.RowCount = 1;
            this.yMajorStyleRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.yMajorStyleRow.Size = new System.Drawing.Size(332, 45);
            this.yMajorStyleRow.TabIndex = 6;
            // 
            // yGridDashComboBoxRow
            // 
            this.yGridDashComboBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.yGridDashComboBoxRow.Controls.Add(this.yGridDashComboBoxLabel);
            this.yGridDashComboBoxRow.Controls.Add(this.yGridDashComboBox);
            this.yGridDashComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yGridDashComboBoxRow.Location = new System.Drawing.Point(0, 0);
            this.yGridDashComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.yGridDashComboBoxRow.Name = "yGridDashComboBoxRow";
            this.yGridDashComboBoxRow.Size = new System.Drawing.Size(166, 45);
            this.yGridDashComboBoxRow.TabIndex = 0;
            // 
            // yGridDashComboBoxLabel
            // 
            this.yGridDashComboBoxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yGridDashComboBoxLabel.ForeColor = System.Drawing.Color.White;
            this.yGridDashComboBoxLabel.Location = new System.Drawing.Point(2, 2);
            this.yGridDashComboBoxLabel.Name = "yGridDashComboBoxLabel";
            this.yGridDashComboBoxLabel.Size = new System.Drawing.Size(148, 15);
            this.yGridDashComboBoxLabel.TabIndex = 0;
            this.yGridDashComboBoxLabel.Text = "Major grid style";
            // 
            // yGridDashComboBox
            // 
            this.yGridDashComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yGridDashComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.yGridDashComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yGridDashComboBox.ForeColor = System.Drawing.Color.White;
            this.yGridDashComboBox.IntegralHeight = false;
            this.yGridDashComboBox.Location = new System.Drawing.Point(5, 20);
            this.yGridDashComboBox.Name = "yGridDashComboBox";
            this.yGridDashComboBox.Size = new System.Drawing.Size(157, 21);
            this.yGridDashComboBox.TabIndex = 1;
            // 
            // yGridAlphaNumericRow
            // 
            this.yGridAlphaNumericRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.yGridAlphaNumericRow.Controls.Add(this.yGridAlphaNumericLabel);
            this.yGridAlphaNumericRow.Controls.Add(this.yGridAlphaNumeric);
            this.yGridAlphaNumericRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yGridAlphaNumericRow.Location = new System.Drawing.Point(166, 0);
            this.yGridAlphaNumericRow.Margin = new System.Windows.Forms.Padding(0);
            this.yGridAlphaNumericRow.Name = "yGridAlphaNumericRow";
            this.yGridAlphaNumericRow.Size = new System.Drawing.Size(166, 45);
            this.yGridAlphaNumericRow.TabIndex = 1;
            // 
            // yGridAlphaNumericLabel
            // 
            this.yGridAlphaNumericLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yGridAlphaNumericLabel.ForeColor = System.Drawing.Color.White;
            this.yGridAlphaNumericLabel.Location = new System.Drawing.Point(2, 2);
            this.yGridAlphaNumericLabel.Name = "yGridAlphaNumericLabel";
            this.yGridAlphaNumericLabel.Size = new System.Drawing.Size(147, 15);
            this.yGridAlphaNumericLabel.TabIndex = 0;
            this.yGridAlphaNumericLabel.Text = "Major grid alpha (0-255)";
            // 
            // yGridAlphaNumeric
            // 
            this.yGridAlphaNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yGridAlphaNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.yGridAlphaNumeric.ForeColor = System.Drawing.Color.White;
            this.yGridAlphaNumeric.Location = new System.Drawing.Point(5, 20);
            this.yGridAlphaNumeric.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.yGridAlphaNumeric.Name = "yGridAlphaNumeric";
            this.yGridAlphaNumeric.Size = new System.Drawing.Size(157, 20);
            this.yGridAlphaNumeric.TabIndex = 1;
            this.yGridAlphaNumeric.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // yMinorGridRow
            // 
            this.yMinorGridRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.yMinorGridRow.ColumnCount = 2;
            this.yMinorGridRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.yMinorGridRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.yMinorGridRow.Controls.Add(this.yMinorCheckBoxRow, 0, 0);
            this.yMinorGridRow.Controls.Add(this.yMinorColorComboBoxRow, 1, 0);
            this.yMinorGridRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yMinorGridRow.Location = new System.Drawing.Point(3, 290);
            this.yMinorGridRow.Margin = new System.Windows.Forms.Padding(0);
            this.yMinorGridRow.Name = "yMinorGridRow";
            this.yMinorGridRow.RowCount = 1;
            this.yMinorGridRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.yMinorGridRow.Size = new System.Drawing.Size(332, 45);
            this.yMinorGridRow.TabIndex = 7;
            // 
            // yMinorCheckBoxRow
            // 
            this.yMinorCheckBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.yMinorCheckBoxRow.Controls.Add(this.yMinorCheckBox);
            this.yMinorCheckBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yMinorCheckBoxRow.Location = new System.Drawing.Point(0, 0);
            this.yMinorCheckBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.yMinorCheckBoxRow.Name = "yMinorCheckBoxRow";
            this.yMinorCheckBoxRow.Size = new System.Drawing.Size(166, 45);
            this.yMinorCheckBoxRow.TabIndex = 0;
            // 
            // yMinorCheckBox
            // 
            this.yMinorCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yMinorCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.yMinorCheckBox.ForeColor = System.Drawing.Color.White;
            this.yMinorCheckBox.Location = new System.Drawing.Point(2, 10);
            this.yMinorCheckBox.Name = "yMinorCheckBox";
            this.yMinorCheckBox.Size = new System.Drawing.Size(149, 28);
            this.yMinorCheckBox.TabIndex = 0;
            this.yMinorCheckBox.Text = "Minor grid";
            this.yMinorCheckBox.UseVisualStyleBackColor = false;
            // 
            // yMinorColorComboBoxRow
            // 
            this.yMinorColorComboBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.yMinorColorComboBoxRow.Controls.Add(this.yMinorColorComboBoxLabel);
            this.yMinorColorComboBoxRow.Controls.Add(this.yMinorColorComboBox);
            this.yMinorColorComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yMinorColorComboBoxRow.Location = new System.Drawing.Point(166, 0);
            this.yMinorColorComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.yMinorColorComboBoxRow.Name = "yMinorColorComboBoxRow";
            this.yMinorColorComboBoxRow.Size = new System.Drawing.Size(166, 45);
            this.yMinorColorComboBoxRow.TabIndex = 1;
            // 
            // yMinorColorComboBoxLabel
            // 
            this.yMinorColorComboBoxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yMinorColorComboBoxLabel.ForeColor = System.Drawing.Color.White;
            this.yMinorColorComboBoxLabel.Location = new System.Drawing.Point(2, 2);
            this.yMinorColorComboBoxLabel.Name = "yMinorColorComboBoxLabel";
            this.yMinorColorComboBoxLabel.Size = new System.Drawing.Size(147, 15);
            this.yMinorColorComboBoxLabel.TabIndex = 0;
            this.yMinorColorComboBoxLabel.Text = "Minor grid color";
            // 
            // yMinorColorComboBox
            // 
            this.yMinorColorComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yMinorColorComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.yMinorColorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yMinorColorComboBox.ForeColor = System.Drawing.Color.White;
            this.yMinorColorComboBox.IntegralHeight = false;
            this.yMinorColorComboBox.Location = new System.Drawing.Point(5, 20);
            this.yMinorColorComboBox.Name = "yMinorColorComboBox";
            this.yMinorColorComboBox.Size = new System.Drawing.Size(157, 21);
            this.yMinorColorComboBox.TabIndex = 1;
            // 
            // yMinorStrokeRow
            // 
            this.yMinorStrokeRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.yMinorStrokeRow.ColumnCount = 2;
            this.yMinorStrokeRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.yMinorStrokeRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.yMinorStrokeRow.Controls.Add(this.yMinorWidthNumericRow, 0, 0);
            this.yMinorStrokeRow.Controls.Add(this.yMinorDashComboBoxRow, 1, 0);
            this.yMinorStrokeRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yMinorStrokeRow.Location = new System.Drawing.Point(3, 335);
            this.yMinorStrokeRow.Margin = new System.Windows.Forms.Padding(0);
            this.yMinorStrokeRow.Name = "yMinorStrokeRow";
            this.yMinorStrokeRow.RowCount = 1;
            this.yMinorStrokeRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.yMinorStrokeRow.Size = new System.Drawing.Size(332, 45);
            this.yMinorStrokeRow.TabIndex = 8;
            // 
            // yMinorWidthNumericRow
            // 
            this.yMinorWidthNumericRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.yMinorWidthNumericRow.Controls.Add(this.yMinorWidthNumericLabel);
            this.yMinorWidthNumericRow.Controls.Add(this.yMinorWidthNumeric);
            this.yMinorWidthNumericRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yMinorWidthNumericRow.Location = new System.Drawing.Point(0, 0);
            this.yMinorWidthNumericRow.Margin = new System.Windows.Forms.Padding(0);
            this.yMinorWidthNumericRow.Name = "yMinorWidthNumericRow";
            this.yMinorWidthNumericRow.Size = new System.Drawing.Size(166, 45);
            this.yMinorWidthNumericRow.TabIndex = 0;
            // 
            // yMinorWidthNumericLabel
            // 
            this.yMinorWidthNumericLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yMinorWidthNumericLabel.ForeColor = System.Drawing.Color.White;
            this.yMinorWidthNumericLabel.Location = new System.Drawing.Point(2, 2);
            this.yMinorWidthNumericLabel.Name = "yMinorWidthNumericLabel";
            this.yMinorWidthNumericLabel.Size = new System.Drawing.Size(148, 15);
            this.yMinorWidthNumericLabel.TabIndex = 0;
            this.yMinorWidthNumericLabel.Text = "Minor grid width";
            // 
            // yMinorWidthNumeric
            // 
            this.yMinorWidthNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yMinorWidthNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.yMinorWidthNumeric.DecimalPlaces = 2;
            this.yMinorWidthNumeric.ForeColor = System.Drawing.Color.White;
            this.yMinorWidthNumeric.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.yMinorWidthNumeric.Location = new System.Drawing.Point(5, 20);
            this.yMinorWidthNumeric.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.yMinorWidthNumeric.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.yMinorWidthNumeric.Name = "yMinorWidthNumeric";
            this.yMinorWidthNumeric.Size = new System.Drawing.Size(157, 20);
            this.yMinorWidthNumeric.TabIndex = 1;
            this.yMinorWidthNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // yMinorDashComboBoxRow
            // 
            this.yMinorDashComboBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.yMinorDashComboBoxRow.Controls.Add(this.yMinorDashComboBoxLabel);
            this.yMinorDashComboBoxRow.Controls.Add(this.yMinorDashComboBox);
            this.yMinorDashComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yMinorDashComboBoxRow.Location = new System.Drawing.Point(166, 0);
            this.yMinorDashComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.yMinorDashComboBoxRow.Name = "yMinorDashComboBoxRow";
            this.yMinorDashComboBoxRow.Size = new System.Drawing.Size(166, 45);
            this.yMinorDashComboBoxRow.TabIndex = 1;
            // 
            // yMinorDashComboBoxLabel
            // 
            this.yMinorDashComboBoxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yMinorDashComboBoxLabel.ForeColor = System.Drawing.Color.White;
            this.yMinorDashComboBoxLabel.Location = new System.Drawing.Point(2, 2);
            this.yMinorDashComboBoxLabel.Name = "yMinorDashComboBoxLabel";
            this.yMinorDashComboBoxLabel.Size = new System.Drawing.Size(147, 15);
            this.yMinorDashComboBoxLabel.TabIndex = 0;
            this.yMinorDashComboBoxLabel.Text = "Minor grid style";
            // 
            // yMinorDashComboBox
            // 
            this.yMinorDashComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yMinorDashComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.yMinorDashComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yMinorDashComboBox.ForeColor = System.Drawing.Color.White;
            this.yMinorDashComboBox.IntegralHeight = false;
            this.yMinorDashComboBox.Location = new System.Drawing.Point(5, 20);
            this.yMinorDashComboBox.Name = "yMinorDashComboBox";
            this.yMinorDashComboBox.Size = new System.Drawing.Size(157, 21);
            this.yMinorDashComboBox.TabIndex = 1;
            // 
            // yMinorOpacityRow
            // 
            this.yMinorOpacityRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.yMinorOpacityRow.ColumnCount = 2;
            this.yMinorOpacityRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.yMinorOpacityRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.yMinorOpacityRow.Controls.Add(this.yMinorAlphaNumericRow, 0, 0);
            this.yMinorOpacityRow.Controls.Add(this.yLogBaseBoxRow, 1, 0);
            this.yMinorOpacityRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yMinorOpacityRow.Location = new System.Drawing.Point(3, 380);
            this.yMinorOpacityRow.Margin = new System.Windows.Forms.Padding(0);
            this.yMinorOpacityRow.Name = "yMinorOpacityRow";
            this.yMinorOpacityRow.RowCount = 1;
            this.yMinorOpacityRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.yMinorOpacityRow.Size = new System.Drawing.Size(332, 45);
            this.yMinorOpacityRow.TabIndex = 9;
            // 
            // yMinorAlphaNumericRow
            // 
            this.yMinorAlphaNumericRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.yMinorAlphaNumericRow.Controls.Add(this.yMinorAlphaNumericLabel);
            this.yMinorAlphaNumericRow.Controls.Add(this.yMinorAlphaNumeric);
            this.yMinorAlphaNumericRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yMinorAlphaNumericRow.Location = new System.Drawing.Point(0, 0);
            this.yMinorAlphaNumericRow.Margin = new System.Windows.Forms.Padding(0);
            this.yMinorAlphaNumericRow.Name = "yMinorAlphaNumericRow";
            this.yMinorAlphaNumericRow.Size = new System.Drawing.Size(166, 45);
            this.yMinorAlphaNumericRow.TabIndex = 0;
            // 
            // yMinorAlphaNumericLabel
            // 
            this.yMinorAlphaNumericLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yMinorAlphaNumericLabel.ForeColor = System.Drawing.Color.White;
            this.yMinorAlphaNumericLabel.Location = new System.Drawing.Point(5, 2);
            this.yMinorAlphaNumericLabel.Name = "yMinorAlphaNumericLabel";
            this.yMinorAlphaNumericLabel.Size = new System.Drawing.Size(148, 15);
            this.yMinorAlphaNumericLabel.TabIndex = 0;
            this.yMinorAlphaNumericLabel.Text = "Minor grid alpha (0-255)";
            // 
            // yMinorAlphaNumeric
            // 
            this.yMinorAlphaNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yMinorAlphaNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.yMinorAlphaNumeric.ForeColor = System.Drawing.Color.White;
            this.yMinorAlphaNumeric.Location = new System.Drawing.Point(5, 20);
            this.yMinorAlphaNumeric.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.yMinorAlphaNumeric.Name = "yMinorAlphaNumeric";
            this.yMinorAlphaNumeric.Size = new System.Drawing.Size(157, 20);
            this.yMinorAlphaNumeric.TabIndex = 1;
            this.yMinorAlphaNumeric.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // yLogBaseBoxRow
            // 
            this.yLogBaseBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.yLogBaseBoxRow.Controls.Add(this.yLogBaseBoxLabel);
            this.yLogBaseBoxRow.Controls.Add(this.yLogBaseBox);
            this.yLogBaseBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yLogBaseBoxRow.Location = new System.Drawing.Point(166, 0);
            this.yLogBaseBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.yLogBaseBoxRow.Name = "yLogBaseBoxRow";
            this.yLogBaseBoxRow.Size = new System.Drawing.Size(166, 45);
            this.yLogBaseBoxRow.TabIndex = 1;
            // 
            // yLogBaseBoxLabel
            // 
            this.yLogBaseBoxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yLogBaseBoxLabel.ForeColor = System.Drawing.Color.White;
            this.yLogBaseBoxLabel.Location = new System.Drawing.Point(2, 2);
            this.yLogBaseBoxLabel.Name = "yLogBaseBoxLabel";
            this.yLogBaseBoxLabel.Size = new System.Drawing.Size(147, 15);
            this.yLogBaseBoxLabel.TabIndex = 0;
            this.yLogBaseBoxLabel.Text = "Logarithmic base";
            // 
            // yLogBaseBox
            // 
            this.yLogBaseBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yLogBaseBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.yLogBaseBox.ForeColor = System.Drawing.Color.White;
            this.yLogBaseBox.Location = new System.Drawing.Point(5, 20);
            this.yLogBaseBox.Name = "yLogBaseBox";
            this.yLogBaseBox.Size = new System.Drawing.Size(157, 20);
            this.yLogBaseBox.TabIndex = 1;
            // 
            // yFontRow
            // 
            this.yFontRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.yFontRow.ColumnCount = 1;
            this.yFontRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.yFontRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.yFontRow.Controls.Add(this.yFontComboBoxRow, 0, 0);
            this.yFontRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yFontRow.Location = new System.Drawing.Point(3, 425);
            this.yFontRow.Margin = new System.Windows.Forms.Padding(0);
            this.yFontRow.Name = "yFontRow";
            this.yFontRow.RowCount = 1;
            this.yFontRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.yFontRow.Size = new System.Drawing.Size(332, 45);
            this.yFontRow.TabIndex = 10;
            // 
            // yFontComboBoxRow
            // 
            this.yFontComboBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.yFontComboBoxRow.Controls.Add(this.yFontComboBoxLabel);
            this.yFontComboBoxRow.Controls.Add(this.yFontComboBox);
            this.yFontComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yFontComboBoxRow.Location = new System.Drawing.Point(0, 0);
            this.yFontComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.yFontComboBoxRow.Name = "yFontComboBoxRow";
            this.yFontComboBoxRow.Size = new System.Drawing.Size(332, 45);
            this.yFontComboBoxRow.TabIndex = 0;
            // 
            // yFontComboBoxLabel
            // 
            this.yFontComboBoxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yFontComboBoxLabel.ForeColor = System.Drawing.Color.White;
            this.yFontComboBoxLabel.Location = new System.Drawing.Point(2, 2);
            this.yFontComboBoxLabel.Name = "yFontComboBoxLabel";
            this.yFontComboBoxLabel.Size = new System.Drawing.Size(314, 15);
            this.yFontComboBoxLabel.TabIndex = 0;
            this.yFontComboBoxLabel.Text = "Axis font family";
            // 
            // yFontComboBox
            // 
            this.yFontComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yFontComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.yFontComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yFontComboBox.ForeColor = System.Drawing.Color.White;
            this.yFontComboBox.IntegralHeight = false;
            this.yFontComboBox.Location = new System.Drawing.Point(5, 20);
            this.yFontComboBox.Name = "yFontComboBox";
            this.yFontComboBox.Size = new System.Drawing.Size(323, 21);
            this.yFontComboBox.TabIndex = 1;
            // 
            // zAxisGroup
            // 
            this.zAxisGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.zAxisGroup.Controls.Add(this.zFields);
            this.zAxisGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zAxisGroup.ForeColor = System.Drawing.Color.White;
            this.zAxisGroup.Location = new System.Drawing.Point(1106, 13);
            this.zAxisGroup.Margin = new System.Windows.Forms.Padding(5);
            this.zAxisGroup.Name = "zAxisGroup";
            this.zAxisGroup.Padding = new System.Windows.Forms.Padding(2);
            this.zAxisGroup.Size = new System.Drawing.Size(266, 445);
            this.zAxisGroup.TabIndex = 3;
            this.zAxisGroup.TabStop = false;
            this.zAxisGroup.Text = "Z / color axis";
            // 
            // zFields
            // 
            this.zFields.AutoScroll = true;
            this.zFields.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.zFields.ColumnCount = 1;
            this.zFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.zFields.Controls.Add(this.zDefaultsButtonRow, 0, 0);
            this.zFields.Controls.Add(this.zColumnComboBoxRow, 0, 1);
            this.zFields.Controls.Add(this.zAutoCheckBoxRow, 0, 2);
            this.zFields.Controls.Add(this.zLimitsRow, 0, 3);
            this.zFields.Controls.Add(this.zColorRow, 0, 4);
            this.zFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zFields.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.zFields.Location = new System.Drawing.Point(2, 15);
            this.zFields.Name = "zFields";
            this.zFields.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.zFields.RowCount = 5;
            this.zFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.zFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.zFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.zFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.zFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.zFields.Size = new System.Drawing.Size(262, 428);
            this.zFields.TabIndex = 0;
            // 
            // zDefaultsButtonRow
            // 
            this.zDefaultsButtonRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.zDefaultsButtonRow.Controls.Add(this.zDefaultsButton);
            this.zDefaultsButtonRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zDefaultsButtonRow.Location = new System.Drawing.Point(3, 0);
            this.zDefaultsButtonRow.Margin = new System.Windows.Forms.Padding(0);
            this.zDefaultsButtonRow.Name = "zDefaultsButtonRow";
            this.zDefaultsButtonRow.Size = new System.Drawing.Size(256, 40);
            this.zDefaultsButtonRow.TabIndex = 0;
            // 
            // zDefaultsButton
            // 
            this.zDefaultsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zDefaultsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.zDefaultsButton.ForeColor = System.Drawing.Color.White;
            this.zDefaultsButton.Location = new System.Drawing.Point(6, 6);
            this.zDefaultsButton.Name = "zDefaultsButton";
            this.zDefaultsButton.Size = new System.Drawing.Size(239, 30);
            this.zDefaultsButton.TabIndex = 0;
            this.zDefaultsButton.Text = "Restore Z defaults";
            this.zDefaultsButton.UseVisualStyleBackColor = false;
            // 
            // zColumnComboBoxRow
            // 
            this.zColumnComboBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.zColumnComboBoxRow.Controls.Add(this.zColumnComboBoxLabel);
            this.zColumnComboBoxRow.Controls.Add(this.zColumnComboBox);
            this.zColumnComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zColumnComboBoxRow.Location = new System.Drawing.Point(3, 40);
            this.zColumnComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.zColumnComboBoxRow.Name = "zColumnComboBoxRow";
            this.zColumnComboBoxRow.Size = new System.Drawing.Size(256, 45);
            this.zColumnComboBoxRow.TabIndex = 1;
            // 
            // zColumnComboBoxLabel
            // 
            this.zColumnComboBoxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zColumnComboBoxLabel.ForeColor = System.Drawing.Color.White;
            this.zColumnComboBoxLabel.Location = new System.Drawing.Point(2, 2);
            this.zColumnComboBoxLabel.Name = "zColumnComboBoxLabel";
            this.zColumnComboBoxLabel.Size = new System.Drawing.Size(238, 15);
            this.zColumnComboBoxLabel.TabIndex = 0;
            this.zColumnComboBoxLabel.Text = "Z column (colors)";
            // 
            // zColumnComboBox
            // 
            this.zColumnComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zColumnComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.zColumnComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.zColumnComboBox.ForeColor = System.Drawing.Color.White;
            this.zColumnComboBox.IntegralHeight = false;
            this.zColumnComboBox.Location = new System.Drawing.Point(5, 20);
            this.zColumnComboBox.Name = "zColumnComboBox";
            this.zColumnComboBox.Size = new System.Drawing.Size(247, 21);
            this.zColumnComboBox.TabIndex = 1;
            // 
            // zAutoCheckBoxRow
            // 
            this.zAutoCheckBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.zAutoCheckBoxRow.Controls.Add(this.zAutoCheckBox);
            this.zAutoCheckBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zAutoCheckBoxRow.Location = new System.Drawing.Point(3, 85);
            this.zAutoCheckBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.zAutoCheckBoxRow.Name = "zAutoCheckBoxRow";
            this.zAutoCheckBoxRow.Size = new System.Drawing.Size(256, 25);
            this.zAutoCheckBoxRow.TabIndex = 2;
            // 
            // zAutoCheckBox
            // 
            this.zAutoCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zAutoCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.zAutoCheckBox.Checked = true;
            this.zAutoCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.zAutoCheckBox.ForeColor = System.Drawing.Color.White;
            this.zAutoCheckBox.Location = new System.Drawing.Point(2, 2);
            this.zAutoCheckBox.Name = "zAutoCheckBox";
            this.zAutoCheckBox.Size = new System.Drawing.Size(239, 28);
            this.zAutoCheckBox.TabIndex = 0;
            this.zAutoCheckBox.Text = "Auto-scale Z";
            this.zAutoCheckBox.UseVisualStyleBackColor = false;
            // 
            // zLimitsRow
            // 
            this.zLimitsRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.zLimitsRow.ColumnCount = 2;
            this.zLimitsRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.zLimitsRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.zLimitsRow.Controls.Add(this.zMinimumBoxRow, 0, 0);
            this.zLimitsRow.Controls.Add(this.zMaximumBoxRow, 1, 0);
            this.zLimitsRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zLimitsRow.Location = new System.Drawing.Point(3, 110);
            this.zLimitsRow.Margin = new System.Windows.Forms.Padding(0);
            this.zLimitsRow.Name = "zLimitsRow";
            this.zLimitsRow.RowCount = 1;
            this.zLimitsRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.zLimitsRow.Size = new System.Drawing.Size(256, 45);
            this.zLimitsRow.TabIndex = 3;
            // 
            // zMinimumBoxRow
            // 
            this.zMinimumBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.zMinimumBoxRow.Controls.Add(this.zMinimumBoxLabel);
            this.zMinimumBoxRow.Controls.Add(this.zMinimumBox);
            this.zMinimumBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zMinimumBoxRow.Location = new System.Drawing.Point(0, 0);
            this.zMinimumBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.zMinimumBoxRow.Name = "zMinimumBoxRow";
            this.zMinimumBoxRow.Size = new System.Drawing.Size(128, 45);
            this.zMinimumBoxRow.TabIndex = 0;
            // 
            // zMinimumBoxLabel
            // 
            this.zMinimumBoxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zMinimumBoxLabel.ForeColor = System.Drawing.Color.White;
            this.zMinimumBoxLabel.Location = new System.Drawing.Point(2, 2);
            this.zMinimumBoxLabel.Name = "zMinimumBoxLabel";
            this.zMinimumBoxLabel.Size = new System.Drawing.Size(110, 15);
            this.zMinimumBoxLabel.TabIndex = 0;
            this.zMinimumBoxLabel.Text = "Color minimum";
            // 
            // zMinimumBox
            // 
            this.zMinimumBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zMinimumBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.zMinimumBox.ForeColor = System.Drawing.Color.White;
            this.zMinimumBox.Location = new System.Drawing.Point(5, 20);
            this.zMinimumBox.Name = "zMinimumBox";
            this.zMinimumBox.Size = new System.Drawing.Size(119, 20);
            this.zMinimumBox.TabIndex = 1;
            // 
            // zMaximumBoxRow
            // 
            this.zMaximumBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.zMaximumBoxRow.Controls.Add(this.zMaximumBoxLabel);
            this.zMaximumBoxRow.Controls.Add(this.zMaximumBox);
            this.zMaximumBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zMaximumBoxRow.Location = new System.Drawing.Point(128, 0);
            this.zMaximumBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.zMaximumBoxRow.Name = "zMaximumBoxRow";
            this.zMaximumBoxRow.Size = new System.Drawing.Size(128, 45);
            this.zMaximumBoxRow.TabIndex = 1;
            // 
            // zMaximumBoxLabel
            // 
            this.zMaximumBoxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zMaximumBoxLabel.ForeColor = System.Drawing.Color.White;
            this.zMaximumBoxLabel.Location = new System.Drawing.Point(2, 2);
            this.zMaximumBoxLabel.Name = "zMaximumBoxLabel";
            this.zMaximumBoxLabel.Size = new System.Drawing.Size(110, 15);
            this.zMaximumBoxLabel.TabIndex = 0;
            this.zMaximumBoxLabel.Text = "Color maximum";
            // 
            // zMaximumBox
            // 
            this.zMaximumBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zMaximumBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.zMaximumBox.ForeColor = System.Drawing.Color.White;
            this.zMaximumBox.Location = new System.Drawing.Point(5, 20);
            this.zMaximumBox.Name = "zMaximumBox";
            this.zMaximumBox.Size = new System.Drawing.Size(118, 20);
            this.zMaximumBox.TabIndex = 1;
            // 
            // zColorRow
            // 
            this.zColorRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.zColorRow.ColumnCount = 2;
            this.zColorRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.zColorRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.zColorRow.Controls.Add(this.schemeComboBoxRow, 0, 0);
            this.zColorRow.Controls.Add(this.bandsNumericRow, 1, 0);
            this.zColorRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zColorRow.Location = new System.Drawing.Point(3, 155);
            this.zColorRow.Margin = new System.Windows.Forms.Padding(0);
            this.zColorRow.Name = "zColorRow";
            this.zColorRow.RowCount = 1;
            this.zColorRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.zColorRow.Size = new System.Drawing.Size(256, 273);
            this.zColorRow.TabIndex = 4;
            // 
            // schemeComboBoxRow
            // 
            this.schemeComboBoxRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.schemeComboBoxRow.Controls.Add(this.schemeComboBoxLabel);
            this.schemeComboBoxRow.Controls.Add(this.schemeComboBox);
            this.schemeComboBoxRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schemeComboBoxRow.Location = new System.Drawing.Point(0, 0);
            this.schemeComboBoxRow.Margin = new System.Windows.Forms.Padding(0);
            this.schemeComboBoxRow.Name = "schemeComboBoxRow";
            this.schemeComboBoxRow.Size = new System.Drawing.Size(128, 273);
            this.schemeComboBoxRow.TabIndex = 0;
            // 
            // schemeComboBoxLabel
            // 
            this.schemeComboBoxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.schemeComboBoxLabel.ForeColor = System.Drawing.Color.White;
            this.schemeComboBoxLabel.Location = new System.Drawing.Point(2, 2);
            this.schemeComboBoxLabel.Name = "schemeComboBoxLabel";
            this.schemeComboBoxLabel.Size = new System.Drawing.Size(110, 15);
            this.schemeComboBoxLabel.TabIndex = 0;
            this.schemeComboBoxLabel.Text = "Color scheme";
            // 
            // schemeComboBox
            // 
            this.schemeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.schemeComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.schemeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.schemeComboBox.ForeColor = System.Drawing.Color.White;
            this.schemeComboBox.IntegralHeight = false;
            this.schemeComboBox.Location = new System.Drawing.Point(5, 20);
            this.schemeComboBox.Name = "schemeComboBox";
            this.schemeComboBox.Size = new System.Drawing.Size(119, 21);
            this.schemeComboBox.TabIndex = 1;
            // 
            // bandsNumericRow
            // 
            this.bandsNumericRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.bandsNumericRow.Controls.Add(this.bandsNumericLabel);
            this.bandsNumericRow.Controls.Add(this.bandsNumeric);
            this.bandsNumericRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bandsNumericRow.Location = new System.Drawing.Point(128, 0);
            this.bandsNumericRow.Margin = new System.Windows.Forms.Padding(0);
            this.bandsNumericRow.Name = "bandsNumericRow";
            this.bandsNumericRow.Size = new System.Drawing.Size(128, 273);
            this.bandsNumericRow.TabIndex = 1;
            // 
            // bandsNumericLabel
            // 
            this.bandsNumericLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bandsNumericLabel.ForeColor = System.Drawing.Color.White;
            this.bandsNumericLabel.Location = new System.Drawing.Point(2, 2);
            this.bandsNumericLabel.Name = "bandsNumericLabel";
            this.bandsNumericLabel.Size = new System.Drawing.Size(110, 15);
            this.bandsNumericLabel.TabIndex = 0;
            this.bandsNumericLabel.Text = "Gradient bands";
            // 
            // bandsNumeric
            // 
            this.bandsNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bandsNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.bandsNumeric.ForeColor = System.Drawing.Color.White;
            this.bandsNumeric.Location = new System.Drawing.Point(5, 20);
            this.bandsNumeric.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.bandsNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.bandsNumeric.Name = "bandsNumeric";
            this.bandsNumeric.Size = new System.Drawing.Size(118, 20);
            this.bandsNumeric.TabIndex = 1;
            this.bandsNumeric.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // filterSettingsPanel
            // 
            this.filterSettingsPanel.AutoScroll = true;
            this.filterSettingsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.filterSettingsPanel.Controls.Add(this.filterSettingsRows);
            this.filterSettingsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.filterSettingsPanel.Location = new System.Drawing.Point(0, 35);
            this.filterSettingsPanel.Name = "filterSettingsPanel";
            this.filterSettingsPanel.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.filterSettingsPanel.Size = new System.Drawing.Size(1385, 355);
            this.filterSettingsPanel.TabIndex = 1;
            // 
            // filterSettingsRows
            // 
            this.filterSettingsRows.ColumnCount = 1;
            this.filterSettingsRows.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.filterSettingsRows.Controls.Add(this.axisFiltersGroup, 0, 0);
            this.filterSettingsRows.Controls.Add(this.extraFiltersGroup, 0, 1);
            this.filterSettingsRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterSettingsRows.Location = new System.Drawing.Point(6, 3);
            this.filterSettingsRows.Name = "filterSettingsRows";
            this.filterSettingsRows.RowCount = 2;
            this.filterSettingsRows.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 166F));
            this.filterSettingsRows.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.filterSettingsRows.Size = new System.Drawing.Size(1373, 349);
            this.filterSettingsRows.TabIndex = 0;
            // 
            // axisFiltersGroup
            // 
            this.axisFiltersGroup.BackColor = System.Drawing.Color.Black;
            this.axisFiltersGroup.Controls.Add(this.axisFiltersFlow);
            this.axisFiltersGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axisFiltersGroup.ForeColor = System.Drawing.Color.White;
            this.axisFiltersGroup.Location = new System.Drawing.Point(3, 3);
            this.axisFiltersGroup.Name = "axisFiltersGroup";
            this.axisFiltersGroup.Padding = new System.Windows.Forms.Padding(8);
            this.axisFiltersGroup.Size = new System.Drawing.Size(1367, 160);
            this.axisFiltersGroup.TabIndex = 1;
            this.axisFiltersGroup.TabStop = false;
            this.axisFiltersGroup.Text = "Current X / Y / Z axis filters";
            // 
            // axisFiltersFlow
            // 
            this.axisFiltersFlow.AutoScroll = true;
            this.axisFiltersFlow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.axisFiltersFlow.Controls.Add(this.axisXFilterRow);
            this.axisFiltersFlow.Controls.Add(this.axisYFilterRow);
            this.axisFiltersFlow.Controls.Add(this.axisZFilterRow);
            this.axisFiltersFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axisFiltersFlow.Location = new System.Drawing.Point(8, 21);
            this.axisFiltersFlow.Name = "axisFiltersFlow";
            this.axisFiltersFlow.Size = new System.Drawing.Size(1351, 131);
            this.axisFiltersFlow.TabIndex = 0;
            // 
            // axisXFilterRow
            // 
            this.axisXFilterRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.axisXFilterRow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.axisXFilterRow.Location = new System.Drawing.Point(5, 5);
            this.axisXFilterRow.Margin = new System.Windows.Forms.Padding(5);
            this.axisXFilterRow.Name = "axisXFilterRow";
            this.axisXFilterRow.Size = new System.Drawing.Size(355, 63);
            this.axisXFilterRow.TabIndex = 0;
            this.axisXFilterRow.Title = "X axis (follows chart)";
            // 
            // axisYFilterRow
            // 
            this.axisYFilterRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.axisYFilterRow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.axisYFilterRow.Location = new System.Drawing.Point(370, 5);
            this.axisYFilterRow.Margin = new System.Windows.Forms.Padding(5);
            this.axisYFilterRow.Name = "axisYFilterRow";
            this.axisYFilterRow.Size = new System.Drawing.Size(355, 63);
            this.axisYFilterRow.TabIndex = 1;
            this.axisYFilterRow.Title = "Y axis (follows chart)";
            // 
            // axisZFilterRow
            // 
            this.axisZFilterRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.axisZFilterRow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.axisZFilterRow.Location = new System.Drawing.Point(735, 5);
            this.axisZFilterRow.Margin = new System.Windows.Forms.Padding(5);
            this.axisZFilterRow.Name = "axisZFilterRow";
            this.axisZFilterRow.Size = new System.Drawing.Size(355, 63);
            this.axisZFilterRow.TabIndex = 2;
            this.axisZFilterRow.Title = "Z axis (follows chart)";
            // 
            // extraFiltersGroup
            // 
            this.extraFiltersGroup.BackColor = System.Drawing.Color.Black;
            this.extraFiltersGroup.Controls.Add(this.extraFiltersFlow);
            this.extraFiltersGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.extraFiltersGroup.ForeColor = System.Drawing.Color.White;
            this.extraFiltersGroup.Location = new System.Drawing.Point(3, 169);
            this.extraFiltersGroup.Name = "extraFiltersGroup";
            this.extraFiltersGroup.Padding = new System.Windows.Forms.Padding(8);
            this.extraFiltersGroup.Size = new System.Drawing.Size(1367, 177);
            this.extraFiltersGroup.TabIndex = 2;
            this.extraFiltersGroup.TabStop = false;
            this.extraFiltersGroup.Text = "Additional selectable filters (10)";
            // 
            // extraFiltersFlow
            // 
            this.extraFiltersFlow.AutoScroll = true;
            this.extraFiltersFlow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.extraFiltersFlow.Controls.Add(this.extraFilterRow01);
            this.extraFiltersFlow.Controls.Add(this.extraFilterRow02);
            this.extraFiltersFlow.Controls.Add(this.extraFilterRow03);
            this.extraFiltersFlow.Controls.Add(this.extraFilterRow04);
            this.extraFiltersFlow.Controls.Add(this.extraFilterRow05);
            this.extraFiltersFlow.Controls.Add(this.extraFilterRow06);
            this.extraFiltersFlow.Controls.Add(this.extraFilterRow07);
            this.extraFiltersFlow.Controls.Add(this.extraFilterRow08);
            this.extraFiltersFlow.Controls.Add(this.extraFilterRow09);
            this.extraFiltersFlow.Controls.Add(this.extraFilterRow10);
            this.extraFiltersFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.extraFiltersFlow.Location = new System.Drawing.Point(8, 21);
            this.extraFiltersFlow.Name = "extraFiltersFlow";
            this.extraFiltersFlow.Size = new System.Drawing.Size(1351, 148);
            this.extraFiltersFlow.TabIndex = 0;
            // 
            // extraFilterRow01
            // 
            this.extraFilterRow01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.extraFilterRow01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.extraFilterRow01.Location = new System.Drawing.Point(5, 5);
            this.extraFilterRow01.Margin = new System.Windows.Forms.Padding(5);
            this.extraFilterRow01.Name = "extraFilterRow01";
            this.extraFilterRow01.Size = new System.Drawing.Size(355, 63);
            this.extraFilterRow01.TabIndex = 0;
            this.extraFilterRow01.Title = "Extra 1";
            // 
            // extraFilterRow02
            // 
            this.extraFilterRow02.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.extraFilterRow02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.extraFilterRow02.Location = new System.Drawing.Point(370, 5);
            this.extraFilterRow02.Margin = new System.Windows.Forms.Padding(5);
            this.extraFilterRow02.Name = "extraFilterRow02";
            this.extraFilterRow02.Size = new System.Drawing.Size(355, 63);
            this.extraFilterRow02.TabIndex = 1;
            this.extraFilterRow02.Title = "Extra 2";
            // 
            // extraFilterRow03
            // 
            this.extraFilterRow03.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.extraFilterRow03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.extraFilterRow03.Location = new System.Drawing.Point(735, 5);
            this.extraFilterRow03.Margin = new System.Windows.Forms.Padding(5);
            this.extraFilterRow03.Name = "extraFilterRow03";
            this.extraFilterRow03.Size = new System.Drawing.Size(355, 63);
            this.extraFilterRow03.TabIndex = 2;
            this.extraFilterRow03.Title = "Extra 3";
            // 
            // extraFilterRow04
            // 
            this.extraFilterRow04.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.extraFilterRow04.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.extraFilterRow04.Location = new System.Drawing.Point(5, 78);
            this.extraFilterRow04.Margin = new System.Windows.Forms.Padding(5);
            this.extraFilterRow04.Name = "extraFilterRow04";
            this.extraFilterRow04.Size = new System.Drawing.Size(355, 63);
            this.extraFilterRow04.TabIndex = 3;
            this.extraFilterRow04.Title = "Extra 4";
            // 
            // extraFilterRow05
            // 
            this.extraFilterRow05.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.extraFilterRow05.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.extraFilterRow05.Location = new System.Drawing.Point(370, 78);
            this.extraFilterRow05.Margin = new System.Windows.Forms.Padding(5);
            this.extraFilterRow05.Name = "extraFilterRow05";
            this.extraFilterRow05.Size = new System.Drawing.Size(355, 63);
            this.extraFilterRow05.TabIndex = 4;
            this.extraFilterRow05.Title = "Extra 5";
            // 
            // extraFilterRow06
            // 
            this.extraFilterRow06.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.extraFilterRow06.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.extraFilterRow06.Location = new System.Drawing.Point(735, 78);
            this.extraFilterRow06.Margin = new System.Windows.Forms.Padding(5);
            this.extraFilterRow06.Name = "extraFilterRow06";
            this.extraFilterRow06.Size = new System.Drawing.Size(355, 63);
            this.extraFilterRow06.TabIndex = 5;
            this.extraFilterRow06.Title = "Extra 6";
            // 
            // extraFilterRow07
            // 
            this.extraFilterRow07.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.extraFilterRow07.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.extraFilterRow07.Location = new System.Drawing.Point(5, 151);
            this.extraFilterRow07.Margin = new System.Windows.Forms.Padding(5);
            this.extraFilterRow07.Name = "extraFilterRow07";
            this.extraFilterRow07.Size = new System.Drawing.Size(355, 63);
            this.extraFilterRow07.TabIndex = 6;
            this.extraFilterRow07.Title = "Extra 7";
            // 
            // extraFilterRow08
            // 
            this.extraFilterRow08.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.extraFilterRow08.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.extraFilterRow08.Location = new System.Drawing.Point(370, 151);
            this.extraFilterRow08.Margin = new System.Windows.Forms.Padding(5);
            this.extraFilterRow08.Name = "extraFilterRow08";
            this.extraFilterRow08.Size = new System.Drawing.Size(355, 63);
            this.extraFilterRow08.TabIndex = 7;
            this.extraFilterRow08.Title = "Extra 8";
            // 
            // extraFilterRow09
            // 
            this.extraFilterRow09.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.extraFilterRow09.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.extraFilterRow09.Location = new System.Drawing.Point(735, 151);
            this.extraFilterRow09.Margin = new System.Windows.Forms.Padding(5);
            this.extraFilterRow09.Name = "extraFilterRow09";
            this.extraFilterRow09.Size = new System.Drawing.Size(355, 63);
            this.extraFilterRow09.TabIndex = 8;
            this.extraFilterRow09.Title = "Extra 9";
            // 
            // extraFilterRow10
            // 
            this.extraFilterRow10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.extraFilterRow10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.extraFilterRow10.Location = new System.Drawing.Point(5, 224);
            this.extraFilterRow10.Margin = new System.Windows.Forms.Padding(5);
            this.extraFilterRow10.Name = "extraFilterRow10";
            this.extraFilterRow10.Size = new System.Drawing.Size(355, 63);
            this.extraFilterRow10.TabIndex = 9;
            this.extraFilterRow10.Title = "Extra 10";
            // 
            // FormOfflineChartSettings
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(1385, 861);
            this.Controls.Add(this.settingsColumns);
            this.Controls.Add(this.filterSettingsPanel);
            this.Controls.Add(this.actionsPanel);
            this.ForeColor = System.Drawing.Color.White;
            this.MinimumSize = new System.Drawing.Size(870, 530);
            this.Name = "FormOfflineChartSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Offline chart settings";
            this.actionsPanel.ResumeLayout(false);
            this.settingsColumns.ResumeLayout(false);
            this.chartStyleGroup.ResumeLayout(false);
            this.styleFields.ResumeLayout(false);
            this.styleChartLayoutRow.ResumeLayout(false);
            this.chartTypeComboBoxRow.ResumeLayout(false);
            this.layoutComboBoxRow.ResumeLayout(false);
            this.styleMarkerRow.ResumeLayout(false);
            this.markerComboBoxRow.ResumeLayout(false);
            this.markerSizeNumericRow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.markerSizeNumeric)).EndInit();
            this.styleAppearanceRow.ResumeLayout(false);
            this.backgroundComboBoxRow.ResumeLayout(false);
            this.paletteAlphaNumericRow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paletteAlphaNumeric)).EndInit();
            this.styleOptionsRow.ResumeLayout(false);
            this.paletteDividerNumericRow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paletteDividerNumeric)).EndInit();
            this.tooltipDelayNumericRow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tooltipDelayNumeric)).EndInit();
            this.styleTogglesRow.ResumeLayout(false);
            this.absoluteCheckBoxRow.ResumeLayout(false);
            this.tooltipEnableCheckBoxRow.ResumeLayout(false);
            this.styleCursorTogglesRow.ResumeLayout(false);
            this.cursorEnabledCheckBoxRow.ResumeLayout(false);
            this.cursorZoomCheckBoxRow.ResumeLayout(false);
            this.styleCursorColorsRow.ResumeLayout(false);
            this.cursorColorComboBoxRow.ResumeLayout(false);
            this.cursorAlphaNumericRow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cursorAlphaNumeric)).EndInit();
            this.styleCursorStrokeRow.ResumeLayout(false);
            this.cursorWidthNumericRow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cursorWidthNumeric)).EndInit();
            this.cursorDashComboBoxRow.ResumeLayout(false);
            this.xAxisGroup.ResumeLayout(false);
            this.xFields.ResumeLayout(false);
            this.xFontPropertiesRow.ResumeLayout(false);
            this.xFontSizeNumericRow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xFontSizeNumeric)).EndInit();
            this.xFontColorComboBoxRow.ResumeLayout(false);
            this.xDefaultsButtonRow.ResumeLayout(false);
            this.xColumnComboBoxRow.ResumeLayout(false);
            this.xModeRow.ResumeLayout(false);
            this.xAutoCheckBoxRow.ResumeLayout(false);
            this.xLogCheckBoxRow.ResumeLayout(false);
            this.xLimitsRow.ResumeLayout(false);
            this.xMinimumBoxRow.ResumeLayout(false);
            this.xMinimumBoxRow.PerformLayout();
            this.xMaximumBoxRow.ResumeLayout(false);
            this.xMaximumBoxRow.PerformLayout();
            this.xTicksRow.ResumeLayout(false);
            this.xGridIntervalBoxRow.ResumeLayout(false);
            this.xGridIntervalBoxRow.PerformLayout();
            this.xDecimalsNumericRow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xDecimalsNumeric)).EndInit();
            this.xMajorGridRow.ResumeLayout(false);
            this.xGridColorComboBoxRow.ResumeLayout(false);
            this.xGridWidthNumericRow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xGridWidthNumeric)).EndInit();
            this.xMajorStyleRow.ResumeLayout(false);
            this.xGridDashComboBoxRow.ResumeLayout(false);
            this.xGridAlphaNumericRow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xGridAlphaNumeric)).EndInit();
            this.xMinorGridRow.ResumeLayout(false);
            this.xMinorCheckBoxRow.ResumeLayout(false);
            this.xMinorColorComboBoxRow.ResumeLayout(false);
            this.xMinorStrokeRow.ResumeLayout(false);
            this.xMinorWidthNumericRow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xMinorWidthNumeric)).EndInit();
            this.xMinorDashComboBoxRow.ResumeLayout(false);
            this.xMinorOpacityRow.ResumeLayout(false);
            this.xMinorAlphaNumericRow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xMinorAlphaNumeric)).EndInit();
            this.xLogBaseBoxRow.ResumeLayout(false);
            this.xLogBaseBoxRow.PerformLayout();
            this.xFontRow.ResumeLayout(false);
            this.xFontComboBoxRow.ResumeLayout(false);
            this.yAxisGroup.ResumeLayout(false);
            this.yFields.ResumeLayout(false);
            this.yFontColorRow.ResumeLayout(false);
            this.yFontSizeNumericRow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.yFontSizeNumeric)).EndInit();
            this.yFontColorComboBoxRow.ResumeLayout(false);
            this.yDefaultsButtonRow.ResumeLayout(false);
            this.yColumnComboBoxRow.ResumeLayout(false);
            this.yModeRow.ResumeLayout(false);
            this.yAutoCheckBoxRow.ResumeLayout(false);
            this.yLogCheckBoxRow.ResumeLayout(false);
            this.yLimitsRow.ResumeLayout(false);
            this.yMinimumBoxRow.ResumeLayout(false);
            this.yMinimumBoxRow.PerformLayout();
            this.yMaximumBoxRow.ResumeLayout(false);
            this.yMaximumBoxRow.PerformLayout();
            this.yTicksRow.ResumeLayout(false);
            this.yGridIntervalBoxRow.ResumeLayout(false);
            this.yGridIntervalBoxRow.PerformLayout();
            this.yDecimalsNumericRow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.yDecimalsNumeric)).EndInit();
            this.yMajorGridRow.ResumeLayout(false);
            this.yGridColorComboBoxRow.ResumeLayout(false);
            this.yGridWidthNumericRow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.yGridWidthNumeric)).EndInit();
            this.yMajorStyleRow.ResumeLayout(false);
            this.yGridDashComboBoxRow.ResumeLayout(false);
            this.yGridAlphaNumericRow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.yGridAlphaNumeric)).EndInit();
            this.yMinorGridRow.ResumeLayout(false);
            this.yMinorCheckBoxRow.ResumeLayout(false);
            this.yMinorColorComboBoxRow.ResumeLayout(false);
            this.yMinorStrokeRow.ResumeLayout(false);
            this.yMinorWidthNumericRow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.yMinorWidthNumeric)).EndInit();
            this.yMinorDashComboBoxRow.ResumeLayout(false);
            this.yMinorOpacityRow.ResumeLayout(false);
            this.yMinorAlphaNumericRow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.yMinorAlphaNumeric)).EndInit();
            this.yLogBaseBoxRow.ResumeLayout(false);
            this.yLogBaseBoxRow.PerformLayout();
            this.yFontRow.ResumeLayout(false);
            this.yFontComboBoxRow.ResumeLayout(false);
            this.zAxisGroup.ResumeLayout(false);
            this.zFields.ResumeLayout(false);
            this.zDefaultsButtonRow.ResumeLayout(false);
            this.zColumnComboBoxRow.ResumeLayout(false);
            this.zAutoCheckBoxRow.ResumeLayout(false);
            this.zLimitsRow.ResumeLayout(false);
            this.zMinimumBoxRow.ResumeLayout(false);
            this.zMinimumBoxRow.PerformLayout();
            this.zMaximumBoxRow.ResumeLayout(false);
            this.zMaximumBoxRow.PerformLayout();
            this.zColorRow.ResumeLayout(false);
            this.schemeComboBoxRow.ResumeLayout(false);
            this.bandsNumericRow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bandsNumeric)).EndInit();
            this.filterSettingsPanel.ResumeLayout(false);
            this.filterSettingsRows.ResumeLayout(false);
            this.axisFiltersGroup.ResumeLayout(false);
            this.axisFiltersFlow.ResumeLayout(false);
            this.extraFiltersGroup.ResumeLayout(false);
            this.extraFiltersFlow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private ComboBox layoutComboBox;
        private TableLayoutPanel xFontPropertiesRow;
        private Panel xFontColorComboBoxRow;
        private Label xFontColorComboBoxLabel;
        private ComboBox xFontColorComboBox;
        private TableLayoutPanel yFontColorRow;
    }
}
