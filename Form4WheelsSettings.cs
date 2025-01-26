using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Physics_Data_Debug
{
    public partial class Form4WheelsSettings : Form
    {
        public Form4WheelsSettings()
        {
            InitializeComponent();
            X1ComboBoxFonts.DropDownStyle = ComboBoxStyle.DropDownList;// Shows font name right this way and you can't write on it
            Y1ComboBoxFonts.DropDownStyle = ComboBoxStyle.DropDownList;// Shows font name right this way and you can't write on it

            // Font slection and draw stuff
            MarkerColorComboBox.DrawItem += MarkerColorComboBox_DrawItem;
            MarkerColorComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            MarkerColorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            BackgroundColorComboBox.DrawItem += BackgroundColorComboBox_DrawItem;
            BackgroundColorComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            BackgroundColorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            SchemeComboBox.DrawItem += GreenRedSchemeComboBox_DrawItem;
            SchemeComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            SchemeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            //SchemeComboBox.BackColor = Color.Maroon;

            X1ComboBoxFonts.DrawItem += X1ComboBoxFonts_DrawItem;
            X1ComboBoxFonts.DataSource = System.Drawing.FontFamily.Families.ToList();
            X1ComboBoxFonts.DrawMode = DrawMode.OwnerDrawFixed;
            Y1ComboBoxFonts.DrawItem += Y1ComboBoxFonts_DrawItem;
            Y1ComboBoxFonts.DataSource = System.Drawing.FontFamily.Families.ToList();
            Y1ComboBoxFonts.DrawMode = DrawMode.OwnerDrawFixed;

            X1FontSizeComboBox.DrawItem += X1FontSizeComboBox_DrawItem;
            X1FontSizeComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            Y1FontSizeComboBox.DrawItem += Y1FontSizeComboBox_DrawItem;
            Y1FontSizeComboBox.DrawMode = DrawMode.OwnerDrawFixed;

            X1FontStyleComboBox.DrawItem += X1FontStyleComboBox_DrawItem;
            X1FontStyleComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            X1FontStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            Y1FontStyleComboBox.DrawItem += Y1FontStyleComboBox_DrawItem;
            Y1FontStyleComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            Y1FontStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            X1FontColorComboBox.DrawItem += X1FontColorComboBox_DrawItem;
            X1FontColorComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            X1FontColorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            Y1FontColorComboBox.DrawItem += Y1FontColorComboBox_DrawItem;
            Y1FontColorComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            Y1FontColorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            X1MajorColorComboBox.DrawItem += X1MajorColorComboBox_DrawItem;
            X1MajorColorComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            X1MajorColorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            Y1MajorColorComboBox.DrawItem += Y1MajorColorComboBox_DrawItem;
            Y1MajorColorComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            Y1MajorColorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            X1MinorColorComboBox.DrawItem += X1MinorColorComboBox_DrawItem;
            X1MinorColorComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            X1MinorColorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            Y1MinorColorComboBox.DrawItem += Y1MinorColorComboBox_DrawItem;
            Y1MinorColorComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            Y1MinorColorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            AddInComboBoxes();
            LoadX1Defaults();
            LoadY1Defaults();
            LoadZ1Defaults();
            LoadOtherDefaults();
        }


        private void AddInComboBoxes()
        {
            // Add Font sizes in comboboxes
            for (int i = _4WheelsSettings.FontSizeMin * _4WheelsSettings.FontSizeDivided; i < _4WheelsSettings.FontSizeMax * _4WheelsSettings.FontSizeDivided + 1f / _4WheelsSettings.FontSizeDivided; i++) // +1f/fontSizeDivided adds the last one missing.
            {
                X1FontSizeComboBox.Items.Add(i * 1f / _4WheelsSettings.FontSizeDivided);
                Y1FontSizeComboBox.Items.Add(i * 1f / _4WheelsSettings.FontSizeDivided);

            }
            // Add FontStyles in the comboboxes
            foreach (FontStyle style in Enum.GetValues(typeof(FontStyle)))
            {
                X1FontStyleComboBox.Items.Add(style);
                Y1FontStyleComboBox.Items.Add(style);
            }
            // Add Colors in the comboboxes
            KnownColor[] colors = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            foreach (KnownColor knowColor in colors)
            {
                Color color = Color.FromKnownColor(knowColor);
                BackgroundColorComboBox.Items.Add(color);
                MarkerColorComboBox.Items.Add(color);
                // X1
                X1FontColorComboBox.Items.Add(color);
                X1MajorColorComboBox.Items.Add(color);
                X1MinorColorComboBox.Items.Add(color);
                // Y1
                Y1FontColorComboBox.Items.Add(color);
                Y1MajorColorComboBox.Items.Add(color);
                Y1MinorColorComboBox.Items.Add(color);

            }
            // Add DashStyles in the comboboxes
            foreach (ChartDashStyle style in Enum.GetValues(typeof(ChartDashStyle)))
            {
                X1MinorDashStyleComboBox.Items.Add(style);
                Y1MinorDashStyleComboBox.Items.Add(style);
            }
            // Add Line Widths in the comboboxes
            for (int i = 1; i <= 10; i++)
            {
                // X1
                X1MajorLineWidthComboBox.Items.Add(i);
                X1MinorLineWidthComboBox.Items.Add(i);
                // Y1
                Y1MajorLineWidthComboBox.Items.Add(i);
                Y1MinorLineWidthComboBox.Items.Add(i);
            }
            /*
            // Add Major Fractions in the comboboxes
            for (int i = 1; i <= 10; i++)
            {
                // X1
                X1MajorIntervalFractionComboBox.Items.Add(i);
                // Y1
                Y1MajorIntervalDividerComboBox.Items.Add(i);
            }
            */
            // Add Minor Fractions in comboboxes
            for (int i = 2; i <= 10; i++)
            {
                // X1
                X1MinorIntervalComboBox.Items.Add(i);
                // Y1
                Y1MinorIntervalComboBox.Items.Add(i);
            }
            // Add Decimals in the comboboxes
            for (int i = 0; i <= 10; i++)
            {
                // X1
                X1MajorDecimalsComboBox.Items.Add(i);
                // Y1
                Y1MajorDecimalsComboBox.Items.Add(i);
            }
            // Add Color Scheme Options in the combobox
            SchemeComboBox.Items.Add("Colorblind");
            SchemeComboBox.Items.Add("Green Red");
            SchemeComboBox.Items.Add("Blue Red");
            // Add X axis selections in the combobox
            X1SelectionComboBox.Items.Add(LiveData.sTireTravelSpeed);
            X1SelectionComboBox.Items.Add(LiveData.sAngularVelocity);
            X1SelectionComboBox.Items.Add(LiveData.sVerticalLoad);
            X1SelectionComboBox.Items.Add(LiveData.sVerticalDeflection);
            X1SelectionComboBox.Items.Add(LiveData.sLoadedRadius);
            X1SelectionComboBox.Items.Add(LiveData.sEffectiveRadius);
            X1SelectionComboBox.Items.Add(LiveData.sContactLength);
            X1SelectionComboBox.Items.Add(LiveData.sBrakeTorque);
            X1SelectionComboBox.Items.Add(LiveData.sMaxBrakeTorque);
            X1SelectionComboBox.Items.Add(LiveData.sSteerAngle);
            X1SelectionComboBox.Items.Add(LiveData.sCamberAngle);
            X1SelectionComboBox.Items.Add(LiveData.sLateralLoad);
            X1SelectionComboBox.Items.Add(LiveData.sSlipAngle);
            X1SelectionComboBox.Items.Add(LiveData.sLateralFriction);
            X1SelectionComboBox.Items.Add(LiveData.sLateralSlipSpeed);
            X1SelectionComboBox.Items.Add(LiveData.sLongitudinalLoad);
            X1SelectionComboBox.Items.Add(LiveData.sSlipRatio);
            X1SelectionComboBox.Items.Add(LiveData.sLongitudinalFriction);
            X1SelectionComboBox.Items.Add(LiveData.sLongitudinalSlipSpeed);
            X1SelectionComboBox.Items.Add(LiveData.sTreadTemperature);
            X1SelectionComboBox.Items.Add(LiveData.sInnerTemperature);
            X1SelectionComboBox.Items.Add(LiveData.sRaceTime);
            X1SelectionComboBox.Items.Add(LiveData.sTotalFriction);
            X1SelectionComboBox.Items.Add(LiveData.sTotalFrictionAngle);
            X1SelectionComboBox.Items.Add(LiveData.sSuspensionLength);
            X1SelectionComboBox.Items.Add(LiveData.sSuspensionVelocity);
            // Add Y axis selections in the combobox
            Y1SelectionComboBox.Items.Add(LiveData.sTireTravelSpeed);
            Y1SelectionComboBox.Items.Add(LiveData.sAngularVelocity);
            Y1SelectionComboBox.Items.Add(LiveData.sVerticalLoad);
            Y1SelectionComboBox.Items.Add(LiveData.sVerticalDeflection);
            Y1SelectionComboBox.Items.Add(LiveData.sLoadedRadius);
            Y1SelectionComboBox.Items.Add(LiveData.sEffectiveRadius);
            Y1SelectionComboBox.Items.Add(LiveData.sContactLength);
            Y1SelectionComboBox.Items.Add(LiveData.sBrakeTorque);
            Y1SelectionComboBox.Items.Add(LiveData.sMaxBrakeTorque);
            Y1SelectionComboBox.Items.Add(LiveData.sSteerAngle);
            Y1SelectionComboBox.Items.Add(LiveData.sCamberAngle);
            Y1SelectionComboBox.Items.Add(LiveData.sLateralLoad);
            Y1SelectionComboBox.Items.Add(LiveData.sSlipAngle);
            Y1SelectionComboBox.Items.Add(LiveData.sLateralFriction);
            Y1SelectionComboBox.Items.Add(LiveData.sLateralSlipSpeed);
            Y1SelectionComboBox.Items.Add(LiveData.sLongitudinalLoad);
            Y1SelectionComboBox.Items.Add(LiveData.sSlipRatio);
            Y1SelectionComboBox.Items.Add(LiveData.sLongitudinalFriction);
            Y1SelectionComboBox.Items.Add(LiveData.sLongitudinalSlipSpeed);
            Y1SelectionComboBox.Items.Add(LiveData.sTreadTemperature);
            Y1SelectionComboBox.Items.Add(LiveData.sInnerTemperature);
            Y1SelectionComboBox.Items.Add(LiveData.sRaceTime);
            Y1SelectionComboBox.Items.Add(LiveData.sTotalFriction);
            Y1SelectionComboBox.Items.Add(LiveData.sTotalFrictionAngle);
            Y1SelectionComboBox.Items.Add(LiveData.sSuspensionLength);
            Y1SelectionComboBox.Items.Add(LiveData.sSuspensionVelocity);
            // Add Z axis selections in the combobox
            Z1SelectionComboBox.Items.Add(LiveData.sTireTravelSpeed);
            Z1SelectionComboBox.Items.Add(LiveData.sAngularVelocity);
            Z1SelectionComboBox.Items.Add(LiveData.sVerticalLoad);
            Z1SelectionComboBox.Items.Add(LiveData.sVerticalDeflection);
            Z1SelectionComboBox.Items.Add(LiveData.sLoadedRadius);
            Z1SelectionComboBox.Items.Add(LiveData.sEffectiveRadius);
            Z1SelectionComboBox.Items.Add(LiveData.sContactLength);
            Z1SelectionComboBox.Items.Add(LiveData.sBrakeTorque);
            Z1SelectionComboBox.Items.Add(LiveData.sMaxBrakeTorque);
            Z1SelectionComboBox.Items.Add(LiveData.sSteerAngle);
            Z1SelectionComboBox.Items.Add(LiveData.sCamberAngle);
            Z1SelectionComboBox.Items.Add(LiveData.sLateralLoad);
            Z1SelectionComboBox.Items.Add(LiveData.sSlipAngle);
            Z1SelectionComboBox.Items.Add(LiveData.sLateralFriction);
            Z1SelectionComboBox.Items.Add(LiveData.sLateralSlipSpeed);
            Z1SelectionComboBox.Items.Add(LiveData.sLongitudinalLoad);
            Z1SelectionComboBox.Items.Add(LiveData.sSlipRatio);
            Z1SelectionComboBox.Items.Add(LiveData.sLongitudinalFriction);
            Z1SelectionComboBox.Items.Add(LiveData.sLongitudinalSlipSpeed);
            Z1SelectionComboBox.Items.Add(LiveData.sTreadTemperature);
            Z1SelectionComboBox.Items.Add(LiveData.sInnerTemperature);
            Z1SelectionComboBox.Items.Add(LiveData.sRaceTime);
            Z1SelectionComboBox.Items.Add(LiveData.sTotalFriction);
            Z1SelectionComboBox.Items.Add(LiveData.sTotalFrictionAngle);
            Z1SelectionComboBox.Items.Add(LiveData.sSuspensionLength);
            Z1SelectionComboBox.Items.Add(LiveData.sSuspensionVelocity);
        }
        private void LoadOtherDefaults()
        {
            //Default background color
            if (DefaultsCheckBox.Checked == true)
            {
                BackgroundColorComboBox.SelectedItem = _4WheelsSettings.DefaultBackgroundColor;
                MarkerColorComboBox.SelectedItem = _4WheelsSettings.DefaultMarkerColor;
                HistoryAmountPointsMaskedTextBox.Text = _4WheelsSettings.DefaultFL_HistoryAmountPoints.ToString();
                InfiniteHistoryCheckBox.Checked = _4WheelsSettings.DefaultInfiniteHistoryEnabled;
                SchemeComboBox.SelectedItem = _4WheelsSettings.DefaultScheme;
            }
            else
            {
                BackgroundColorComboBox.SelectedItem = _4WheelsSettings.BackgroundColor;
                MarkerColorComboBox.SelectedItem = _4WheelsSettings.MarkerColor;
                HistoryAmountPointsMaskedTextBox.Text = _4WheelsSettings.FL_HistoryAmountPoints.ToString();
                InfiniteHistoryCheckBox.Checked = _4WheelsSettings.InfiniteHistoryEnabled;
                SchemeComboBox.SelectedItem = _4WheelsSettings.Scheme;
            }
        }

        private void LoadX1Defaults()
        {
            X1SelectionComboBox.SelectedItem = _4WheelsSettings.X1Selection;

            // Default X1 selections
            if (X1DefaultsCheckBox.Checked == true)
            {
                X1MaxMaskedTextBox.Text = _4WheelsSettings.X1DefaultMax.ToString();
                X1MinMaskedTextBox.Text = _4WheelsSettings.X1DefaultMin.ToString();

                X1ComboBoxFonts.SelectedItem = _4WheelsSettings.X1DefaultFontFamily;//X1ComboBoxFonts.Items[_4WheelsSettings.X1DefaultFontIndex];//Sets default SelectedItem to Microsoft Sans Serif

                //_4WheelsSettings.X1DefaultFontString = X1ComboBoxFonts.SelectedItem.ToString();//Gets default SelectedItem's string "Microsoft Sans Serif"

                X1FontSizeComboBox.SelectedItem = _4WheelsSettings.X1DefaultFontSize;

                X1FontStyleComboBox.SelectedItem = _4WheelsSettings.X1DefaultFontStyle;

                X1FontColorComboBox.SelectedItem = _4WheelsSettings.X1DefaultFontColor;

                X1MajorColorComboBox.SelectedItem = _4WheelsSettings.X1DefaultMajorColor;
                X1MajorDecimalsComboBox.SelectedItem = _4WheelsSettings.X1DefaultMajorDecimals;
                X1MajorIntervalFractionTextBox.Text = _4WheelsSettings.X1DefaultMajorInterval.ToString();
                X1MajorLineWidthComboBox.SelectedItem = _4WheelsSettings.X1DefaultMajorLineWidth;
                X1MinorColorComboBox.SelectedItem = _4WheelsSettings.X1DefaultMinorColor;
                X1MinorDashStyleComboBox.SelectedItem = _4WheelsSettings.X1DefaultMinorDashStyle;
                X1MinorEnabledCheckBox.Checked = _4WheelsSettings.X1DefaultMinorEnabled;
                X1MinorIntervalComboBox.SelectedItem = _4WheelsSettings.X1DefaultMinorIntervalFraction;
                X1MinorLineWidthComboBox.SelectedItem = _4WheelsSettings.X1DefaultMinorLineWidth;
            }
            else
            {
                X1MaxMaskedTextBox.Text = _4WheelsSettings.X1Max.ToString();
                X1MinMaskedTextBox.Text = _4WheelsSettings.X1Min.ToString();

                X1ComboBoxFonts.SelectedItem = _4WheelsSettings.X1FontFamily;//X1ComboBoxFonts.Items[_4WheelsSettings.X1FontIndex];//Sets default SelectedItem to Microsoft Sans Serif

                //_4WheelsSettings.X1FontFamily = X1ComboBoxFonts.SelectedItem.ToString();//Gets default SelectedItem's string "Microsoft Sans Serif"

                X1FontSizeComboBox.SelectedItem = _4WheelsSettings.X1FontSize;

                X1FontStyleComboBox.SelectedItem = _4WheelsSettings.X1FontStyle;

                X1FontColorComboBox.SelectedItem = _4WheelsSettings.X1FontColor;

                X1MajorColorComboBox.SelectedItem = _4WheelsSettings.X1MajorColor;
                X1MajorDecimalsComboBox.SelectedItem = _4WheelsSettings.X1MajorDecimals;
                X1MajorIntervalFractionTextBox.Text = _4WheelsSettings.X1MajorInterval.ToString();
                X1MajorLineWidthComboBox.SelectedItem = _4WheelsSettings.X1MajorLineWidth;
                X1MinorColorComboBox.SelectedItem = _4WheelsSettings.X1MinorColor;
                X1MinorDashStyleComboBox.SelectedItem = _4WheelsSettings.X1MinorDashStyle;
                X1MinorEnabledCheckBox.Checked = _4WheelsSettings.X1MinorEnabled;
                X1MinorIntervalComboBox.SelectedItem = _4WheelsSettings.X1MinorIntervalFraction;
                X1MinorLineWidthComboBox.SelectedItem = _4WheelsSettings.X1MinorLineWidth;
            }
        }
        private void LoadY1Defaults()
        {
            Y1SelectionComboBox.SelectedItem = _4WheelsSettings.Y1Selection;

            // Default Y1 selections
            if (Y1DefaultsCheckBox.Checked == true)
            {
                Y1MaxMaskedTextBox.Text = _4WheelsSettings.Y1DefaultMax.ToString();
                Y1MinMaskedTextBox.Text = _4WheelsSettings.Y1DefaultMin.ToString();

                Y1ComboBoxFonts.SelectedItem = _4WheelsSettings.Y1DefaultFontFamily;//Y1ComboBoxFonts.Items[_4WheelsSettings.Y1DefaultFontIndex];//Sets default SelectedItem to Microsoft Sans Serif

                //_4WheelsSettings.Y1DefaultFontString = Y1ComboBoxFonts.SelectedItem.ToString();//Gets default SelectedItem's string "Microsoft Sans Serif"

                Y1FontSizeComboBox.SelectedItem = _4WheelsSettings.Y1DefaultFontSize;

                Y1FontStyleComboBox.SelectedItem = _4WheelsSettings.Y1DefaultFontStyle;

                Y1FontColorComboBox.SelectedItem = _4WheelsSettings.Y1DefaultFontColor;

                Y1MajorColorComboBox.SelectedItem = _4WheelsSettings.Y1DefaultMajorColor;
                Y1MajorDecimalsComboBox.SelectedItem = _4WheelsSettings.Y1DefaultMajorDecimals;
                Y1IntervalDividerTextBox.Text = _4WheelsSettings.Y1DefaultMajorInterval.ToString();
                Y1MajorLineWidthComboBox.SelectedItem = _4WheelsSettings.Y1DefaultMajorLineWidth;
                Y1MinorColorComboBox.SelectedItem = _4WheelsSettings.Y1DefaultMinorColor;
                Y1MinorDashStyleComboBox.SelectedItem = _4WheelsSettings.Y1DefaultMinorDashStyle;
                Y1MinorEnabledCheckBox.Checked = _4WheelsSettings.Y1DefaultMinorEnabled;
                Y1MinorIntervalComboBox.SelectedItem = _4WheelsSettings.Y1DefaultMinorIntervalFraction;
                Y1MinorLineWidthComboBox.SelectedItem = _4WheelsSettings.Y1DefaultMinorLineWidth;
            }
            else
            {
                Y1MaxMaskedTextBox.Text = _4WheelsSettings.Y1Max.ToString();
                Y1MinMaskedTextBox.Text = _4WheelsSettings.Y1Min.ToString();

                Y1ComboBoxFonts.SelectedItem = _4WheelsSettings.Y1FontFamily;//Y1ComboBoxFonts.Items[_4WheelsSettings.Y1FontIndex];//Sets default SelectedItem to Microsoft Sans Serif

                //_4WheelsSettings.Y1FontString = Y1ComboBoxFonts.SelectedItem.ToString();//Gets default SelectedItem's string "Microsoft Sans Serif"

                Y1FontSizeComboBox.SelectedItem = _4WheelsSettings.Y1FontSize;

                Y1FontStyleComboBox.SelectedItem = _4WheelsSettings.Y1FontStyle;

                Y1FontColorComboBox.SelectedItem = _4WheelsSettings.Y1FontColor;

                Y1MajorColorComboBox.SelectedItem = _4WheelsSettings.Y1MajorColor;
                Y1MajorDecimalsComboBox.SelectedItem = _4WheelsSettings.Y1MajorDecimals;
                Y1IntervalDividerTextBox.Text = _4WheelsSettings.Y1MajorInterval.ToString();
                Y1MajorLineWidthComboBox.SelectedItem = _4WheelsSettings.Y1MajorLineWidth;
                Y1MinorColorComboBox.SelectedItem = _4WheelsSettings.Y1MinorColor;
                Y1MinorDashStyleComboBox.SelectedItem = _4WheelsSettings.Y1MinorDashStyle;
                Y1MinorEnabledCheckBox.Checked = _4WheelsSettings.Y1MinorEnabled;
                Y1MinorIntervalComboBox.SelectedItem = _4WheelsSettings.Y1MinorIntervalFraction;
                Y1MinorLineWidthComboBox.SelectedItem = _4WheelsSettings.Y1MinorLineWidth;
            }
        }
        private void LoadZ1Defaults()
        {
            Z1SelectionComboBox.SelectedItem = _4WheelsSettings.Z1Selection;

            // Default Z1 selections
            if (Z1DefaultsCheckBox.Checked == true)
            {
                Z1MaxMaskedTextBox.Text = _4WheelsSettings.Z1DefaultMax.ToString();
                Z1MinMaskedTextBox.Text = _4WheelsSettings.Z1DefaultMin.ToString();

                //Z1ComboBoxFonts.SelectedItem = _4WheelsSettings.Z1DefaultFontFamily;//Z1ComboBoxFonts.Items[_4WheelsSettings.Z1DefaultFontIndex];//Sets default SelectedItem to Microsoft Sans Serif

                //_4WheelsSettings.Z1DefaultFontString = Z1ComboBoxFonts.SelectedItem.ToString();//Gets default SelectedItem's string "Microsoft Sans Serif"

                //Z1FontSizeComboBox.SelectedItem = _4WheelsSettings.Z1DefaultFontSize;

                //Z1FontStyleComboBox.SelectedItem = _4WheelsSettings.Z1DefaultFontStyle;

                //Z1FontColorComboBox.SelectedItem = _4WheelsSettings.Z1DefaultFontColor;

                //Z1MajorColorComboBox.SelectedItem = _4WheelsSettings.Z1DefaultMajorColor;
                //Z1MajorDecimalsComboBox.SelectedItem = _4WheelsSettings.Z1DefaultMajorDecimals;
                //Z1IntervalDividerTextBox.Text = _4WheelsSettings.Z1DefaultMajorInterval.ToString();
                //Z1MajorLineWidthComboBox.SelectedItem = _4WheelsSettings.Z1DefaultMajorLineWidth;
                //Z1MinorColorComboBox.SelectedItem = _4WheelsSettings.Z1DefaultMinorColor;
                //Z1MinorDashStyleComboBox.SelectedItem = _4WheelsSettings.Z1DefaultMinorDashStyle;
                //Z1MinorEnabledCheckBox.Checked = _4WheelsSettings.Z1DefaultMinorEnabled;
                //Z1MinorIntervalComboBox.SelectedItem = _4WheelsSettings.Z1DefaultMinorIntervalFraction;
                //Z1MinorLineWidthComboBox.SelectedItem = _4WheelsSettings.Z1DefaultMinorLineWidth;
            }
            else
            {
                Z1MaxMaskedTextBox.Text = _4WheelsSettings.Z1Max.ToString();
                Z1MinMaskedTextBox.Text = _4WheelsSettings.Z1Min.ToString();

                //Z1ComboBoxFonts.SelectedItem = _4WheelsSettings.Z1FontFamily;//Z1ComboBoxFonts.Items[_4WheelsSettings.Z1FontIndex];//Sets default SelectedItem to Microsoft Sans Serif

                //_4WheelsSettings.Z1FontString = Z1ComboBoxFonts.SelectedItem.ToString();//Gets default SelectedItem's string "Microsoft Sans Serif"

                //Z1FontSizeComboBox.SelectedItem = _4WheelsSettings.Z1FontSize;

                //Z1FontStyleComboBox.SelectedItem = _4WheelsSettings.Z1FontStyle;

                //Z1FontColorComboBox.SelectedItem = _4WheelsSettings.Z1FontColor;

                //Z1MajorColorComboBox.SelectedItem = _4WheelsSettings.Z1MajorColor;
                //Z1MajorDecimalsComboBox.SelectedItem = _4WheelsSettings.Z1MajorDecimals;
                //Z1IntervalDividerTextBox.Text = _4WheelsSettings.Z1MajorInterval.ToString();
                //Z1MajorLineWidthComboBox.SelectedItem = _4WheelsSettings.Z1MajorLineWidth;
                //Z1MinorColorComboBox.SelectedItem = _4WheelsSettings.Z1MinorColor;
                //Z1MinorDashStyleComboBox.SelectedItem = _4WheelsSettings.Z1MinorDashStyle;
                //Z1MinorEnabledCheckBox.Checked = _4WheelsSettings.Z1MinorEnabled;
                //Z1MinorIntervalComboBox.SelectedItem = _4WheelsSettings.Z1MinorIntervalFraction;
                //Z1MinorLineWidthComboBox.SelectedItem = _4WheelsSettings.Z1MinorLineWidth;
            }
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void applyButton_Click(object sender, EventArgs e)
        {
            // Other stuff
            if (DefaultsCheckBox.Checked == true)
            {
                _4WheelsSettings.BackgroundColor = _4WheelsSettings.DefaultBackgroundColor;
                _4WheelsSettings.MarkerColor = _4WheelsSettings.DefaultMarkerColor;
                _4WheelsSettings.FL_HistoryAmountPoints = _4WheelsSettings.DefaultFL_HistoryAmountPoints;
                _4WheelsSettings.FR_HistoryAmountPoints = _4WheelsSettings.DefaultFR_HistoryAmountPoints;
                _4WheelsSettings.RL_HistoryAmountPoints = _4WheelsSettings.DefaultRL_HistoryAmountPoints;
                _4WheelsSettings.RR_HistoryAmountPoints = _4WheelsSettings.DefaultRR_HistoryAmountPoints;
                _4WheelsSettings.InfiniteHistoryEnabled = _4WheelsSettings.DefaultInfiniteHistoryEnabled;
                _4WheelsSettings.Scheme = _4WheelsSettings.DefaultScheme;
            }
            else
            {
                _4WheelsSettings.BackgroundColor = (Color)BackgroundColorComboBox.SelectedItem;
                _4WheelsSettings.MarkerColor = (Color)MarkerColorComboBox.SelectedItem;
                _4WheelsSettings.FL_HistoryAmountPoints = Parsers.HistoryAmountPointsMaskedTextBoxParserInt(HistoryAmountPointsMaskedTextBox, _4WheelsSettings.FL_HistoryAmountPoints, _4WheelsSettings.DefaultFL_HistoryAmountPoints, true);
                _4WheelsSettings.FR_HistoryAmountPoints = Parsers.HistoryAmountPointsMaskedTextBoxParserInt(HistoryAmountPointsMaskedTextBox, _4WheelsSettings.FR_HistoryAmountPoints, _4WheelsSettings.DefaultFR_HistoryAmountPoints, true);
                _4WheelsSettings.RL_HistoryAmountPoints = Parsers.HistoryAmountPointsMaskedTextBoxParserInt(HistoryAmountPointsMaskedTextBox, _4WheelsSettings.RL_HistoryAmountPoints, _4WheelsSettings.DefaultRL_HistoryAmountPoints, true);
                _4WheelsSettings.RR_HistoryAmountPoints = Parsers.HistoryAmountPointsMaskedTextBoxParserInt(HistoryAmountPointsMaskedTextBox, _4WheelsSettings.RR_HistoryAmountPoints, _4WheelsSettings.DefaultRR_HistoryAmountPoints, true);
                _4WheelsSettings.InfiniteHistoryEnabled = InfiniteHistoryCheckBox.Checked;
                _4WheelsSettings.Scheme = SchemeComboBox.Text;
            }

            // X-Axis
            _4WheelsSettings.X1Selection = X1SelectionComboBox.Text;
            if (X1DefaultsCheckBox.Checked == true)
            {
                _4WheelsSettings.X1Min = _4WheelsSettings.X1DefaultMin;
                _4WheelsSettings.X1Max = _4WheelsSettings.X1DefaultMax;

                _4WheelsSettings.X1FontFamily = _4WheelsSettings.X1DefaultFontFamily;
                _4WheelsSettings.X1FontSize = _4WheelsSettings.X1DefaultFontSize;
                _4WheelsSettings.X1FontStyle = _4WheelsSettings.X1DefaultFontStyle;
                _4WheelsSettings.X1FontColor = _4WheelsSettings.X1DefaultFontColor;

                _4WheelsSettings.X1MajorLineWidth = _4WheelsSettings.X1DefaultMajorLineWidth;
                _4WheelsSettings.X1MajorDecimals = _4WheelsSettings.X1DefaultMajorDecimals;
                _4WheelsSettings.X1MajorInterval = _4WheelsSettings.X1DefaultMajorInterval;
                _4WheelsSettings.X1MajorColor = _4WheelsSettings.X1DefaultMajorColor;

                _4WheelsSettings.X1MinorEnabled = _4WheelsSettings.X1DefaultMinorEnabled;
                _4WheelsSettings.X1MinorIntervalFraction = _4WheelsSettings.X1DefaultMinorIntervalFraction;
                _4WheelsSettings.X1MinorLineWidth = _4WheelsSettings.X1DefaultMinorLineWidth;
                _4WheelsSettings.X1MinorColor = _4WheelsSettings.X1DefaultMinorColor;
                _4WheelsSettings.X1MinorDashStyle = _4WheelsSettings.X1DefaultMinorDashStyle;
            }
            else
            {
                _4WheelsSettings.X1FontIndex = X1ComboBoxFonts.SelectedIndex;
                _4WheelsSettings.X1FontFamily = (FontFamily)X1ComboBoxFonts.SelectedItem;
                _4WheelsSettings.X1FontColor = (Color)X1FontColorComboBox.SelectedItem;
                _4WheelsSettings.X1FontSize = (float)X1FontSizeComboBox.SelectedItem;
                _4WheelsSettings.X1FontStyle = (FontStyle)X1FontStyleComboBox.SelectedItem;

                _4WheelsSettings.X1Min = Parsers.MaskedTextBoxParserDouble(X1MinMaskedTextBox, _4WheelsSettings.X1Min, _4WheelsSettings.X1DefaultMin, false);
                _4WheelsSettings.X1Max = Parsers.MaskedTextBoxParserDouble(X1MaxMaskedTextBox, _4WheelsSettings.X1Max, _4WheelsSettings.X1DefaultMax, false);

                _4WheelsSettings.X1MajorLineWidth = (int)X1MajorLineWidthComboBox.SelectedItem;
                _4WheelsSettings.X1MajorDecimals = (int)X1MajorDecimalsComboBox.SelectedItem;
                _4WheelsSettings.X1MajorInterval = Parsers.TextBoxParserDouble(X1MajorIntervalFractionTextBox, _4WheelsSettings.X1MajorInterval, _4WheelsSettings.X1DefaultMajorInterval, false);
                _4WheelsSettings.X1MajorColor = (Color)X1MajorColorComboBox.SelectedItem;

                _4WheelsSettings.X1MinorEnabled = X1MinorEnabledCheckBox.Checked;
                _4WheelsSettings.X1MinorIntervalFraction = (int)X1MinorIntervalComboBox.SelectedItem;
                _4WheelsSettings.X1MinorLineWidth = (int)X1MinorLineWidthComboBox.SelectedItem;
                _4WheelsSettings.X1MinorColor = (Color)X1MinorColorComboBox.SelectedItem;
                _4WheelsSettings.X1MinorDashStyle = (ChartDashStyle)X1MinorDashStyleComboBox.SelectedItem;
            }

            // Y-Axis
            _4WheelsSettings.Y1Selection = Y1SelectionComboBox.Text;
            if (Y1DefaultsCheckBox.Checked == true)
            {
                _4WheelsSettings.Y1Min = _4WheelsSettings.Y1DefaultMin;
                _4WheelsSettings.Y1Max = _4WheelsSettings.Y1DefaultMax;

                _4WheelsSettings.Y1FontFamily = _4WheelsSettings.Y1DefaultFontFamily;
                _4WheelsSettings.Y1FontSize = _4WheelsSettings.Y1DefaultFontSize;
                _4WheelsSettings.Y1FontStyle = _4WheelsSettings.Y1DefaultFontStyle;
                _4WheelsSettings.Y1FontColor = _4WheelsSettings.Y1DefaultFontColor;


                _4WheelsSettings.Y1MajorLineWidth = _4WheelsSettings.Y1DefaultMajorLineWidth;
                _4WheelsSettings.Y1MajorDecimals = _4WheelsSettings.Y1DefaultMajorDecimals;
                _4WheelsSettings.Y1MajorInterval = _4WheelsSettings.Y1DefaultMajorInterval;
                _4WheelsSettings.Y1MajorColor = _4WheelsSettings.Y1DefaultMajorColor;

                _4WheelsSettings.Y1MinorEnabled = _4WheelsSettings.Y1DefaultMinorEnabled;
                _4WheelsSettings.Y1MinorIntervalFraction = _4WheelsSettings.Y1DefaultMinorIntervalFraction;
                _4WheelsSettings.Y1MinorLineWidth = _4WheelsSettings.Y1DefaultMinorLineWidth;
                _4WheelsSettings.Y1MinorColor = _4WheelsSettings.Y1DefaultMinorColor;
                _4WheelsSettings.Y1MinorDashStyle = _4WheelsSettings.Y1DefaultMinorDashStyle;
            }
            else
            {
                _4WheelsSettings.Y1FontIndex = Y1ComboBoxFonts.SelectedIndex;
                //_4WheelsSettings.Y1FontString = Y1ComboBoxFonts.Text;
                _4WheelsSettings.Y1FontFamily = (FontFamily)Y1ComboBoxFonts.SelectedItem;
                _4WheelsSettings.Y1FontColor = (Color)Y1FontColorComboBox.SelectedItem;
                _4WheelsSettings.Y1FontSize = (float)Y1FontSizeComboBox.SelectedItem;
                _4WheelsSettings.Y1FontStyle = (FontStyle)Y1FontStyleComboBox.SelectedItem;

                _4WheelsSettings.Y1Min = Parsers.MaskedTextBoxParserDouble(Y1MinMaskedTextBox, _4WheelsSettings.Y1Min, _4WheelsSettings.Y1DefaultMin, false);
                _4WheelsSettings.Y1Max = Parsers.MaskedTextBoxParserDouble(Y1MaxMaskedTextBox, _4WheelsSettings.Y1Max, _4WheelsSettings.Y1DefaultMax, false);

                _4WheelsSettings.Y1MajorLineWidth = (int)Y1MajorLineWidthComboBox.SelectedItem;
                _4WheelsSettings.Y1MajorDecimals = (int)Y1MajorDecimalsComboBox.SelectedItem;
                _4WheelsSettings.Y1MajorInterval = Parsers.TextBoxParserDouble(Y1IntervalDividerTextBox, _4WheelsSettings.Y1MajorInterval, _4WheelsSettings.Y1DefaultMajorInterval, true);
                _4WheelsSettings.Y1MajorColor = (Color)Y1MajorColorComboBox.SelectedItem;

                _4WheelsSettings.Y1MinorEnabled = Y1MinorEnabledCheckBox.Checked;
                _4WheelsSettings.Y1MinorIntervalFraction = (int)Y1MinorIntervalComboBox.SelectedItem;
                _4WheelsSettings.Y1MinorLineWidth = (int)Y1MinorLineWidthComboBox.SelectedItem;
                _4WheelsSettings.Y1MinorColor = (Color)Y1MinorColorComboBox.SelectedItem;
                _4WheelsSettings.Y1MinorDashStyle = (ChartDashStyle)Y1MinorDashStyleComboBox.SelectedItem;
            }
            // Z-Axis
            _4WheelsSettings.Z1Selection = Z1SelectionComboBox.Text;
            if (Z1DefaultsCheckBox.Checked == true)
            {
                _4WheelsSettings.Z1Min = _4WheelsSettings.Z1DefaultMin;
                _4WheelsSettings.Z1Max = _4WheelsSettings.Z1DefaultMax;

                //_4WheelsSettings.Z1FontFamily = _4WheelsSettings.Z1DefaultFontFamily;
                //_4WheelsSettings.Z1FontSize = _4WheelsSettings.Z1DefaultFontSize;
                //_4WheelsSettings.Z1FontStyle = _4WheelsSettings.Z1DefaultFontStyle;
                //_4WheelsSettings.Z1FontColor = _4WheelsSettings.Z1DefaultFontColor;


                //_4WheelsSettings.Z1MajorLineWidth = _4WheelsSettings.Z1DefaultMajorLineWidth;
                //_4WheelsSettings.Z1MajorDecimals = _4WheelsSettings.Z1DefaultMajorDecimals;
                //_4WheelsSettings.Z1MajorInterval = _4WheelsSettings.Z1DefaultMajorInterval;
                //_4WheelsSettings.Z1MajorColor = _4WheelsSettings.Z1DefaultMajorColor;

                //_4WheelsSettings.Z1MinorEnabled = _4WheelsSettings.Z1DefaultMinorEnabled;
                //_4WheelsSettings.Z1MinorIntervalFraction = _4WheelsSettings.Z1DefaultMinorIntervalFraction;
                //_4WheelsSettings.Z1MinorLineWidth = _4WheelsSettings.Z1DefaultMinorLineWidth;
                //_4WheelsSettings.Z1MinorColor = _4WheelsSettings.Z1DefaultMinorColor;
                //_4WheelsSettings.Z1MinorDashStyle = _4WheelsSettings.Z1DefaultMinorDashStyle;
            }
            else
            {
                //_4WheelsSettings.Z1FontIndex = Z1ComboBoxFonts.SelectedIndex;
                //_4WheelsSettings.Z1FontString = Z1ComboBoxFonts.Text;
                //_4WheelsSettings.Z1FontFamily = (FontFamily)Z1ComboBoxFonts.SelectedItem;
                //_4WheelsSettings.Z1FontColor = (Color)Z1FontColorComboBox.SelectedItem;
                //_4WheelsSettings.Z1FontSize = (float)Z1FontSizeComboBox.SelectedItem;
                //_4WheelsSettings.Z1FontStyle = (FontStyle)Z1FontStyleComboBox.SelectedItem;

                _4WheelsSettings.Z1Min = Parsers.MaskedTextBoxParserDouble(Z1MinMaskedTextBox, _4WheelsSettings.Z1Min, _4WheelsSettings.Z1DefaultMin, true);
                _4WheelsSettings.Z1Max = Parsers.MaskedTextBoxParserDouble(Z1MaxMaskedTextBox, _4WheelsSettings.Z1Max, _4WheelsSettings.Z1DefaultMax, true);

                //_4WheelsSettings.Z1MajorLineWidth = (int)Z1MajorLineWidthComboBox.SelectedItem;
                //_4WheelsSettings.Z1MajorDecimals = (int)Z1MajorDecimalsComboBox.SelectedItem;
                //_4WheelsSettings.Z1MajorInterval = Parsers.TextBoxParserDouble(Z1IntervalDividerTextBox, _4WheelsSettings.Z1MajorInterval, _4WheelsSettings.Z1DefaultMajorInterval, true);
                //_4WheelsSettings.Z1MajorColor = (Color)Z1MajorColorComboBox.SelectedItem;

                //_4WheelsSettings.Z1MinorEnabled = Z1MinorEnabledCheckBox.Checked;
                //_4WheelsSettings.Z1MinorIntervalFraction = (int)Z1MinorIntervalComboBox.SelectedItem;
                //_4WheelsSettings.Z1MinorLineWidth = (int)Z1MinorLineWidthComboBox.SelectedItem;
                //_4WheelsSettings.Z1MinorColor = (Color)Z1MinorColorComboBox.SelectedItem;
                //_4WheelsSettings.Z1MinorDashStyle = (ChartDashStyle)Z1MinorDashStyleComboBox.SelectedItem;
            }
            // Updating and clearing the charts from old data
            Form4Wheels form = (Form4Wheels)Application.OpenForms["Form4Wheels"];
            var chart1 = form.chart1;
            var chart2 = form.chart2;
            var chart3 = form.chart3;
            var chart4 = form.chart4;
            var gradientChart = form.GradientChart;
            //var chart2 = form.chart2;
            var timer1 = form.timer1;
            var timer2 = form.timer1;

            timer1.Enabled = false;
            timer2.Enabled = false;
            _4Wheels.ClearSeriesHistory(chart1);
            _4Wheels.ClearSeriesHistory(chart2);
            _4Wheels.ClearSeriesHistory(chart3);
            _4Wheels.ClearSeriesHistory(chart4);
            _4Wheels.SetArrays();
            _4Wheels.SetChart(chart1);
            _4Wheels.SetChart(chart2);
            _4Wheels.SetChart(chart3);
            _4Wheels.SetChart(chart4);
            _4Wheels.SetUpDownChart(gradientChart);
            timer1.Enabled = true;
            timer2.Enabled = true;
        }

        private void LoadCurrentValuesButton_Click(object sender, EventArgs e)
        {
            LoadX1Defaults();
            LoadY1Defaults();
            LoadZ1Defaults();
            LoadOtherDefaults();
        }

        private void CheckFontColorAndSetBackGroundColor(ComboBox cb, Color fontColor)
        {
            if (fontColor == Color.White || fontColor == Color.WhiteSmoke || fontColor == Color.AntiqueWhite || fontColor == Color.FloralWhite || fontColor == Color.NavajoWhite)
            {
                cb.BackColor = Color.Black;
            }
            else
            {
                cb.BackColor = SystemColors.Window;
            }
            cb.ForeColor = fontColor;
        }
        //////////////////////////////////////////////////////////////////////////////////////////
        ///OTHER STUFF
        ///
        private void DefaultsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DefaultsCheckBox.Checked == true)
            {
                _4WheelsSettings.OtherDefaults = true;
            }
            else
            {
                _4WheelsSettings.OtherDefaults = false;
            }
        }

        private void BackgroundColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //_4WheelsSettings _4WheelsSettings = new _4WheelsSettings();
            var comboBox = (ComboBox)sender;
            var color = (Color)comboBox.Items[e.Index];
            SolidBrush brush = new SolidBrush(color);
            var font = new Font(_4WheelsSettings.Y1DefaultFontFamily, _4WheelsSettings.Y1DefaultFontSize, _4WheelsSettings.Y1DefaultFontStyle);
            string colorRemovePart1 = color.ToString().Replace("Color [", "");
            string colorRemovePart2 = colorRemovePart1.Replace("]", "");
            string colorName = colorRemovePart2;
            e.DrawBackground();
            e.Graphics.DrawString(colorName, font, brush, e.Bounds.X, e.Bounds.Y);
            CheckFontColorAndSetBackGroundColor(BackgroundColorComboBox, color);
        }

        private void BackgroundColorComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var comboBox = (ComboBox)sender;
            var color = comboBox.SelectedItem;
            BackgroundColorComboBox.ForeColor = (Color)color;
            BackgroundColorComboBox.Font = new Font(_4WheelsSettings.Y1DefaultFontFamily, _4WheelsSettings.Y1DefaultFontSize, _4WheelsSettings.Y1DefaultFontStyle);
            CheckFontColorAndSetBackGroundColor(BackgroundColorComboBox, (Color)color);
        }

        private void MarkerColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //_4WheelsSettings _4WheelsSettings = new _4WheelsSettings();
            var comboBox = (ComboBox)sender;
            var color = (Color)comboBox.Items[e.Index];
            SolidBrush brush = new SolidBrush(color);
            var font = new Font(_4WheelsSettings.Y1DefaultFontFamily, _4WheelsSettings.Y1DefaultFontSize, _4WheelsSettings.Y1DefaultFontStyle);
            string colorRemovePart1 = color.ToString().Replace("Color [", "");
            string colorRemovePart2 = colorRemovePart1.Replace("]", "");
            string colorName = colorRemovePart2;
            e.DrawBackground();
            e.Graphics.DrawString(colorName, font, brush, e.Bounds.X, e.Bounds.Y);
            CheckFontColorAndSetBackGroundColor(MarkerColorComboBox, color);
        }
        private void MarkerColorComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var comboBox = (ComboBox)sender;
            var color = comboBox.SelectedItem;
            MarkerColorComboBox.ForeColor = (Color)color;
            MarkerColorComboBox.Font = new Font(_4WheelsSettings.Y1DefaultFontFamily, _4WheelsSettings.Y1DefaultFontSize, _4WheelsSettings.Y1DefaultFontStyle);
            CheckFontColorAndSetBackGroundColor(MarkerColorComboBox, (Color)color);
        }
        private void GreenRedSchemeComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //_4WheelsSettings _4WheelsSettings = new _4WheelsSettings();
            var comboBox = (ComboBox)sender;
            var color = comboBox.Items[e.Index];
            if ((string)color == "Green Red")
            {
                color = Color.Green;
            }
            else if ((string)color == "Blue Red")
            {
                color = Color.Blue;
            }
            else if ((string)color == "Colorblind")
            {
                color = Color.Black;
            }
            SolidBrush brush = new SolidBrush((Color)color);
            var font = new Font(_4WheelsSettings.Y1DefaultFontFamily, _4WheelsSettings.Y1DefaultFontSize, FontStyle.Bold);
            string colorRemovePart1 = color.ToString().Replace("Color [", "");
            string colorRemovePart2 = colorRemovePart1.Replace("]", "");
            string colorName = colorRemovePart2 + " Red";
            e.DrawBackground();
            if(colorRemovePart2 == "Black")
            {
                e.Graphics.DrawString("Colorblind", font, brush, e.Bounds.X, e.Bounds.Y);
            }
            else
            {
                e.Graphics.DrawString(colorName, font, brush, e.Bounds.X, e.Bounds.Y);
            }
        }
        private void SchemeComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }
        //////////////////////////////////////////////////////////////////////////////////////////
        ///X1 STUFF
        ///
        private void X1DefaultsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (X1DefaultsCheckBox.Checked == true)
            {
                _4WheelsSettings.X1Defaults = true;
            }
            else
            {
                _4WheelsSettings.X1Defaults = false;
            }
        }
        private void X1ComboBoxFonts_DrawItem(object sender, DrawItemEventArgs e)
        {
            //_4WheelsSettings _4WheelsSettings = new _4WheelsSettings();
            var comboBox = (ComboBox)sender;
            var fontFamily = (FontFamily)comboBox.Items[e.Index];
            var font = new Font(fontFamily, _4WheelsSettings.X1DefaultFontSize, _4WheelsSettings.X1DefaultFontStyle);
            e.DrawBackground();
            e.Graphics.DrawString(font.Name, font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
        }

        private void X1ComboBoxFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //_4WheelsSettings _4WheelsSettings = new _4WheelsSettings();
            var comboBox = (ComboBox)sender;
            var fontFamily = (FontFamily)comboBox.SelectedItem;
            X1ComboBoxFonts.Font = new Font(fontFamily, _4WheelsSettings.X1DefaultFontSize, _4WheelsSettings.X1DefaultFontStyle);
        }

        private void X1FontStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //_4WheelsSettings _4WheelsSettings = new _4WheelsSettings();
            //_4WheelsSettings.X1FontStyle = (FontStyle)X1FontStyleComboBox.SelectedItem;
            var comboBox = (ComboBox)sender;
            var fontStyle = (FontStyle)comboBox.SelectedItem;
            X1FontStyleComboBox.Font = new Font(_4WheelsSettings.X1DefaultFontFamily, _4WheelsSettings.X1DefaultFontSize, fontStyle);
        }

        private void X1FontStyleComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //_4WheelsSettings _4WheelsSettings = new _4WheelsSettings();
            var comboBox = (ComboBox)sender;
            var fontStyle = (FontStyle)comboBox.Items[e.Index];
            var font = new Font(_4WheelsSettings.X1DefaultFontFamily, _4WheelsSettings.X1DefaultFontSize, fontStyle);
            e.DrawBackground();
            e.Graphics.DrawString(fontStyle.ToString(), font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
        }

        private void X1FontColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //_4WheelsSettings _4WheelsSettings = new _4WheelsSettings();
            //_4WheelsSettings.X1FontColor = (Color)X1FontColorComboBox.SelectedItem;
            var comboBox = (ComboBox)sender;
            var color = comboBox.SelectedItem;
            X1FontColorComboBox.Font = new Font(_4WheelsSettings.X1DefaultFontFamily, _4WheelsSettings.X1DefaultFontSize, _4WheelsSettings.X1DefaultFontStyle);
            X1FontColorComboBox.ForeColor = (Color)color;
            CheckFontColorAndSetBackGroundColor(X1FontColorComboBox, (Color)color);
        }

        private void X1FontColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //_4WheelsSettings _4WheelsSettings = new _4WheelsSettings();
            var comboBox = (ComboBox)sender;
            var color = (Color)comboBox.Items[e.Index];
            SolidBrush brush = new SolidBrush(color);
            var font = new Font(_4WheelsSettings.X1DefaultFontFamily, _4WheelsSettings.X1DefaultFontSize, _4WheelsSettings.X1DefaultFontStyle);
            string colorRemovePart1 = color.ToString().Replace("Color [", "");
            string colorRemovePart2 = colorRemovePart1.Replace("]", "");
            string colorName = colorRemovePart2;
            e.DrawBackground();
            e.Graphics.DrawString(colorName, font, brush, e.Bounds.X, e.Bounds.Y);
            CheckFontColorAndSetBackGroundColor(X1FontColorComboBox, (Color)color);
        }

        private void X1FontSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = (ComboBox)sender;
            var fontSize = comboBox.SelectedItem;
            //_4WheelsSettings _4WheelsSettings = new _4WheelsSettings();
            //_4WheelsSettings.X1FontSize = (float)X1FontSizeComboBox.SelectedItem;
            X1FontSizeComboBox.Font = new Font(_4WheelsSettings.X1DefaultFontFamily, (float)fontSize, _4WheelsSettings.X1DefaultFontStyle);
            //textBox8.Text = _4WheelsSettings.X1FontSize.ToString();
            //comboBox7.Text = p.GetX1FontSize().ToString();
        }

        private void X1FontSizeComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //_4WheelsSettings _4WheelsSettings = new _4WheelsSettings();
            var comboBox = (ComboBox)sender;
            var fontSize = comboBox.Items[e.Index];
            var font = new Font(_4WheelsSettings.X1DefaultFontFamily, _4WheelsSettings.X1DefaultFontSize, _4WheelsSettings.X1DefaultFontStyle);
            e.DrawBackground();
            e.Graphics.DrawString(fontSize.ToString(), font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
        }
        private void X1MajorColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //_4WheelsSettings _4WheelsSettings = new _4WheelsSettings();
            //_4WheelsSettings.X1MajorColor = (Color)X1MajorColorComboBox.SelectedItem;
            var comboBox = (ComboBox)sender;
            var color = comboBox.SelectedItem;
            X1MajorColorComboBox.Font = new Font(_4WheelsSettings.X1DefaultFontFamily, _4WheelsSettings.X1DefaultFontSize, _4WheelsSettings.X1DefaultFontStyle);
            X1MajorColorComboBox.ForeColor = (Color)color;
            CheckFontColorAndSetBackGroundColor(X1MajorColorComboBox, (Color)color);
        }
        private void X1MajorColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //_4WheelsSettings _4WheelsSettings = new _4WheelsSettings();
            var comboBox = (ComboBox)sender;
            var color = (Color)comboBox.Items[e.Index];
            SolidBrush brush = new SolidBrush(color);
            var font = new Font(_4WheelsSettings.X1DefaultFontFamily, _4WheelsSettings.X1DefaultFontSize, _4WheelsSettings.X1FontStyle);
            string colorRemovePart1 = color.ToString().Replace("Color [", "");
            string colorRemovePart2 = colorRemovePart1.Replace("]", "");
            string colorName = colorRemovePart2;
            e.DrawBackground();
            e.Graphics.DrawString(colorName, font, brush, e.Bounds.X, e.Bounds.Y);
            CheckFontColorAndSetBackGroundColor(X1MajorColorComboBox, (Color)color);
        }

        private void X1MinorColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //_4WheelsSettings _4WheelsSettings = new _4WheelsSettings();
            //_4WheelsSettings.X1MinorColor = (Color)X1MinorColorComboBox.SelectedItem;
            var comboBox = (ComboBox)sender;
            var color = comboBox.SelectedItem;
            X1MinorColorComboBox.Font = new Font(_4WheelsSettings.X1DefaultFontFamily, _4WheelsSettings.X1DefaultFontSize, _4WheelsSettings.X1DefaultFontStyle);
            X1MinorColorComboBox.ForeColor = (Color)color;
            CheckFontColorAndSetBackGroundColor(X1MinorColorComboBox, (Color)color);
        }
        private void X1MinorColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //_4WheelsSettings _4WheelsSettings = new _4WheelsSettings();
            var comboBox = (ComboBox)sender;
            var color = (Color)comboBox.Items[e.Index];
            SolidBrush brush = new SolidBrush(color);
            var font = new Font(_4WheelsSettings.X1DefaultFontFamily, _4WheelsSettings.X1DefaultFontSize, _4WheelsSettings.X1DefaultFontStyle);
            string colorRemovePart1 = color.ToString().Replace("Color [", "");
            string colorRemovePart2 = colorRemovePart1.Replace("]", "");
            string colorName = colorRemovePart2;
            e.DrawBackground();
            e.Graphics.DrawString(colorName, font, brush, e.Bounds.X, e.Bounds.Y);
            CheckFontColorAndSetBackGroundColor(X1MinorColorComboBox, (Color)color);
        }


        //////////////////////////////////////////////////////////////////////////////////////////77
        ///Y1 STUFF
        ///
        private void Y1DefaultsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Y1DefaultsCheckBox.Checked == true)
            {
                _4WheelsSettings.Y1Defaults = true;
            }
            else
            {
                _4WheelsSettings.Y1Defaults = false;
            }
        }
        private void Y1ComboBoxFonts_DrawItem(object sender, DrawItemEventArgs e)
        {
            //_4WheelsSettings _4WheelsSettings = new _4WheelsSettings();
            var comboBox = (ComboBox)sender;
            var fontFamily = (FontFamily)comboBox.Items[e.Index];
            var font = new Font(fontFamily, _4WheelsSettings.Y1DefaultFontSize, _4WheelsSettings.Y1DefaultFontStyle);
            e.DrawBackground();
            e.Graphics.DrawString(font.Name, font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
        }

        private void Y1ComboBoxFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = (ComboBox)sender;
            var fontFamily = (FontFamily)comboBox.SelectedItem;
            Y1ComboBoxFonts.Font = new Font(fontFamily, _4WheelsSettings.Y1DefaultFontSize, _4WheelsSettings.Y1DefaultFontStyle);
        }

        private void Y1FontStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //_4WheelsSettings _4WheelsSettings = new _4WheelsSettings();
            //_4WheelsSettings.Y1FontStyle = (FontStyle)Y1FontStyleComboBox.SelectedItem;
            var comboBox = (ComboBox)sender;
            var fontStyle = (FontStyle)comboBox.SelectedItem;
            Y1FontStyleComboBox.Font = new Font(_4WheelsSettings.Y1DefaultFontFamily, _4WheelsSettings.Y1DefaultFontSize, fontStyle);
        }

        private void Y1FontStyleComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //_4WheelsSettings _4WheelsSettings = new _4WheelsSettings();
            var comboBox = (ComboBox)sender;
            var fontStyle = (FontStyle)comboBox.Items[e.Index];
            var font = new Font(_4WheelsSettings.Y1DefaultFontFamily, _4WheelsSettings.Y1DefaultFontSize, fontStyle);
            e.DrawBackground();
            e.Graphics.DrawString(fontStyle.ToString(), font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
        }

        private void Y1FontColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //_4WheelsSettings _4WheelsSettings = new _4WheelsSettings();
            //_4WheelsSettings.Y1FontColor = (Color)Y1FontColorComboBox.SelectedItem;
            var comboBox = (ComboBox)sender;
            var color = comboBox.SelectedItem;
            Y1FontColorComboBox.Font = new Font(_4WheelsSettings.Y1DefaultFontFamily, _4WheelsSettings.Y1DefaultFontSize, _4WheelsSettings.Y1DefaultFontStyle);
            Y1FontColorComboBox.ForeColor = (Color)color;
            CheckFontColorAndSetBackGroundColor(Y1FontColorComboBox, (Color)color);
        }

        private void Y1FontColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //_4WheelsSettings _4WheelsSettings = new _4WheelsSettings();
            var comboBox = (ComboBox)sender;
            var color = (Color)comboBox.Items[e.Index];
            SolidBrush brush = new SolidBrush(color);
            var font = new Font(_4WheelsSettings.Y1DefaultFontFamily, _4WheelsSettings.Y1DefaultFontSize, _4WheelsSettings.Y1DefaultFontStyle);
            string colorRemovePart1 = color.ToString().Replace("Color [", "");
            string colorRemovePart2 = colorRemovePart1.Replace("]", "");
            string colorName = colorRemovePart2;
            e.DrawBackground();
            e.Graphics.DrawString(colorName, font, brush, e.Bounds.X, e.Bounds.Y);
            CheckFontColorAndSetBackGroundColor(Y1FontColorComboBox, (Color)color);
        }

        private void Y1FontSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = (ComboBox)sender;
            var fontSize = comboBox.SelectedItem;
            Y1FontSizeComboBox.Font = new Font(_4WheelsSettings.Y1DefaultFontFamily, (float)fontSize, _4WheelsSettings.Y1DefaultFontStyle);
        }

        private void Y1FontSizeComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //_4WheelsSettings _4WheelsSettings = new _4WheelsSettings();
            var comboBox = (ComboBox)sender;
            var fontSize = comboBox.Items[e.Index];
            var font = new Font(_4WheelsSettings.Y1DefaultFontFamily, _4WheelsSettings.Y1DefaultFontSize, _4WheelsSettings.Y1DefaultFontStyle);
            e.DrawBackground();
            e.Graphics.DrawString(fontSize.ToString(), font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
        }
        private void Y1MajorColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //_4WheelsSettings _4WheelsSettings = new _4WheelsSettings();
            //_4WheelsSettings.Y1MajorColor = (Color)Y1MajorColorComboBox.SelectedItem;
            var comboBox = (ComboBox)sender;
            var color = comboBox.SelectedItem;
            Y1MajorColorComboBox.Font = new Font(_4WheelsSettings.Y1DefaultFontFamily, _4WheelsSettings.Y1DefaultFontSize, _4WheelsSettings.Y1DefaultFontStyle);
            Y1MajorColorComboBox.ForeColor = (Color)color;
            CheckFontColorAndSetBackGroundColor(Y1MajorColorComboBox, (Color)color);
        }
        private void Y1MajorColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //_4WheelsSettings _4WheelsSettings = new _4WheelsSettings();
            var comboBox = (ComboBox)sender;
            var color = (Color)comboBox.Items[e.Index];
            SolidBrush brush = new SolidBrush(color);
            var font = new Font(_4WheelsSettings.Y1DefaultFontFamily, _4WheelsSettings.Y1DefaultFontSize, _4WheelsSettings.Y1DefaultFontStyle);
            string colorRemovePart1 = color.ToString().Replace("Color [", "");
            string colorRemovePart2 = colorRemovePart1.Replace("]", "");
            string colorName = colorRemovePart2;
            e.DrawBackground();
            e.Graphics.DrawString(colorName, font, brush, e.Bounds.X, e.Bounds.Y);
            CheckFontColorAndSetBackGroundColor(Y1MajorColorComboBox, (Color)color);
        }

        private void Y1MinorColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //_4WheelsSettings _4WheelsSettings = new _4WheelsSettings();
            //_4WheelsSettings.Y1MinorColor = (Color)Y1MinorColorComboBox.SelectedItem;
            var comboBox = (ComboBox)sender;
            var color = comboBox.SelectedItem;
            Y1MinorColorComboBox.Font = new Font(_4WheelsSettings.Y1DefaultFontFamily, _4WheelsSettings.Y1DefaultFontSize, _4WheelsSettings.Y1DefaultFontStyle);
            Y1MinorColorComboBox.ForeColor = (Color)color;
            CheckFontColorAndSetBackGroundColor(Y1MinorColorComboBox, (Color)color);
        }
        private void Y1MinorColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //_4WheelsSettings _4WheelsSettings = new _4WheelsSettings();
            var comboBox = (ComboBox)sender;
            var color = (Color)comboBox.Items[e.Index];
            SolidBrush brush = new SolidBrush(color);
            var font = new Font(_4WheelsSettings.Y1DefaultFontFamily, _4WheelsSettings.Y1DefaultFontSize, _4WheelsSettings.Y1DefaultFontStyle);
            string colorRemovePart1 = color.ToString().Replace("Color [", "");
            string colorRemovePart2 = colorRemovePart1.Replace("]", "");
            string colorName = colorRemovePart2;
            e.DrawBackground();
            e.Graphics.DrawString(colorName, font, brush, e.Bounds.X, e.Bounds.Y);
            CheckFontColorAndSetBackGroundColor(Y1MinorColorComboBox, (Color)color);
        }
        //////////////////////////////////////////////////////////////////////////////////////////
        ///Z1 STUFF
        ///
        private void Z1DefaultsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Z1DefaultsCheckBox.Checked == true)
            {
                _4WheelsSettings.Z1Defaults = true;
            }
            else
            {
                _4WheelsSettings.Z1Defaults = false;
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////
        private void Form_4WheelsSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            _4WheelsSettings.SettingsOpen = false;
            RegistryTools.SaveAllSettings(Application.ProductName, this);
        }

        private void Form_4WheelsSettings_Load(object sender, EventArgs e)
        {
            _4WheelsSettings.SettingsOpen = true;
            RegistryTools.LoadAllSettings(Application.ProductName, this);
        }

        private void AbsoluteValuesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (AbsoluteValuesCheckBox.Checked == true)
            {
                _4WheelsSettings.AbsoluteValues = true;
            }
            else
            {
                _4WheelsSettings.AbsoluteValues = false;
            }
        }
    }
}
