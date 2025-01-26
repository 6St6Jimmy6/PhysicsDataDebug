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
    public partial class FormGForceSettings : Form
    {
        public FormGForceSettings()
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
            LoadOtherDefaults();
        }
        private void AddInComboBoxes()
        {
            // Add Font sizes in comboboxes
            for (int i = GForceSettings.FontSizeMin * GForceSettings.FontSizeDivided; i < GForceSettings.FontSizeMax * GForceSettings.FontSizeDivided + 1f / GForceSettings.FontSizeDivided; i++) // +1f/fontSizeDivided adds the last one missing.
            {
                X1FontSizeComboBox.Items.Add(i * 1f / GForceSettings.FontSizeDivided);
                Y1FontSizeComboBox.Items.Add(i * 1f / GForceSettings.FontSizeDivided);

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
            // Add Major Fractions in the comboboxes
            for (int i = 1; i <= 10; i++)
            {
                // X1
                X1MajorIntervalFractionComboBox.Items.Add(i);
                // Y1
                Y1MajorIntervalDividerComboBox.Items.Add(i);
            }
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
                //X1MajorDecimalsComboBox.Items.Add(i);
                // Y1
                Y1MajorDecimalsComboBox.Items.Add(i);
            }
            // Add Color Scheme Options in the combobox
            SchemeComboBox.Items.Add("Colorblind");
            SchemeComboBox.Items.Add("Green Red");
            SchemeComboBox.Items.Add("Blue Red");
            // Add Degree/Radian in the combobox
            X1AngleTypeComboBox.Items.Add("Degrees");
            X1AngleTypeComboBox.Items.Add("Radians");
        }
        private void LoadOtherDefaults()
        {
            //Default background color
            if (DefaultsCheckBox.Checked == true)
            {
                BackgroundColorComboBox.SelectedItem = GForceSettings.DefaultBackgroundColor;
                MarkerColorComboBox.SelectedItem = GForceSettings.DefaultMarkerColor;
                HistoryAmountPointsMaskedTextBox.Text = GForceSettings.DefaultHistoryAmountPoints.ToString();
                InfiniteHistoryCheckBox.Checked = GForceSettings.DefaultInfiniteHistoryEnabled;
                SchemeComboBox.SelectedItem = GForceSettings.DefaultScheme;
            }
            else
            {
                BackgroundColorComboBox.SelectedItem = GForceSettings.BackgroundColor;
                MarkerColorComboBox.SelectedItem = GForceSettings.MarkerColor;
                HistoryAmountPointsMaskedTextBox.Text = GForceSettings.HistoryAmountPoints.ToString();
                InfiniteHistoryCheckBox.Checked = GForceSettings.InfiniteHistoryEnabled;
                SchemeComboBox.SelectedItem = GForceSettings.Scheme;
            }
        }

        private void LoadX1Defaults()
        {
            // Default X1 selections
            if (X1DefaultsCheckBox.Checked == true)
            {
                X1AngleTypeComboBox.SelectedItem = GForceSettings.X1DefaultAngleType;

                X1ComboBoxFonts.SelectedItem = GForceSettings.X1DefaultFontFamily;//X1ComboBoxFonts.Items[GForceSettings.X1DefaultFontIndex];//Sets default SelectedItem to Microsoft Sans Serif

                //GForceSettings.X1DefaultFontString = X1ComboBoxFonts.SelectedItem.ToString();//Gets default SelectedItem's string "Microsoft Sans Serif"

                X1FontSizeComboBox.SelectedItem = GForceSettings.X1DefaultFontSize;

                X1FontStyleComboBox.SelectedItem = GForceSettings.X1DefaultFontStyle;

                X1FontColorComboBox.SelectedItem = GForceSettings.X1DefaultFontColor;

                X1MajorColorComboBox.SelectedItem = GForceSettings.X1DefaultMajorColor;
                //X1MajorDecimalsComboBox.SelectedItem = GForceSettings.X1DefaultMajorDecimals;
                X1MajorIntervalFractionComboBox.SelectedItem = GForceSettings.X1DefaultMajorIntervalFraction;
                X1MajorLineWidthComboBox.SelectedItem = GForceSettings.X1DefaultMajorLineWidth;
                X1MinorColorComboBox.SelectedItem = GForceSettings.X1DefaultMinorColor;
                X1MinorDashStyleComboBox.SelectedItem = GForceSettings.X1DefaultMinorDashStyle;
                X1MinorEnabledCheckBox.Checked = GForceSettings.X1DefaultMinorEnabled;
                X1MinorIntervalComboBox.SelectedItem = GForceSettings.X1DefaultMinorIntervalFraction;
                X1MinorLineWidthComboBox.SelectedItem = GForceSettings.X1DefaultMinorLineWidth;
            }
            else
            {
                X1AngleTypeComboBox.SelectedItem = GForceSettings.X1AngleType;

                X1ComboBoxFonts.SelectedItem = GForceSettings.X1FontFamily;//X1ComboBoxFonts.Items[GForceSettings.X1FontIndex];//Sets default SelectedItem to Microsoft Sans Serif

                //GForceSettings.X1FontFamily = X1ComboBoxFonts.SelectedItem.ToString();//Gets default SelectedItem's string "Microsoft Sans Serif"

                X1FontSizeComboBox.SelectedItem = GForceSettings.X1FontSize;

                X1FontStyleComboBox.SelectedItem = GForceSettings.X1FontStyle;

                X1FontColorComboBox.SelectedItem = GForceSettings.X1FontColor;

                X1MajorColorComboBox.SelectedItem = GForceSettings.X1MajorColor;
                //X1MajorDecimalsComboBox.SelectedItem = GForceSettings.X1MajorDecimals;
                X1MajorIntervalFractionComboBox.SelectedItem = GForceSettings.X1MajorIntervalFraction;
                X1MajorLineWidthComboBox.SelectedItem = GForceSettings.X1MajorLineWidth;
                X1MinorColorComboBox.SelectedItem = GForceSettings.X1MinorColor;
                X1MinorDashStyleComboBox.SelectedItem = GForceSettings.X1MinorDashStyle;
                X1MinorEnabledCheckBox.Checked = GForceSettings.X1MinorEnabled;
                X1MinorIntervalComboBox.SelectedItem = GForceSettings.X1MinorIntervalFraction;
                X1MinorLineWidthComboBox.SelectedItem = GForceSettings.X1MinorLineWidth;
            }
        }
        private void LoadY1Defaults()
        {
            // Default Y1 selections
            if (Y1DefaultsCheckBox.Checked == true)
            {
                Y1MaxMaskedTextBox.Text = GForceSettings.Y1DefaultMax.ToString();
                Y1MinMaskedTextBox.Text = GForceSettings.Y1DefaultMin.ToString();

                Y1ComboBoxFonts.SelectedItem = GForceSettings.Y1DefaultFontFamily;//Y1ComboBoxFonts.Items[GForceSettings.Y1DefaultFontIndex];//Sets default SelectedItem to Microsoft Sans Serif

                //GForceSettings.Y1DefaultFontString = Y1ComboBoxFonts.SelectedItem.ToString();//Gets default SelectedItem's string "Microsoft Sans Serif"

                Y1FontSizeComboBox.SelectedItem = GForceSettings.Y1DefaultFontSize;

                Y1FontStyleComboBox.SelectedItem = GForceSettings.Y1DefaultFontStyle;

                Y1FontColorComboBox.SelectedItem = GForceSettings.Y1DefaultFontColor;

                Y1MajorColorComboBox.SelectedItem = GForceSettings.Y1DefaultMajorColor;
                Y1MajorDecimalsComboBox.SelectedItem = GForceSettings.Y1DefaultMajorDecimals;
                Y1MajorIntervalDividerComboBox.SelectedItem = GForceSettings.Y1DefaultIntervalDivider;
                Y1MajorLineWidthComboBox.SelectedItem = GForceSettings.Y1DefaultMajorLineWidth;
                Y1MinorColorComboBox.SelectedItem = GForceSettings.Y1DefaultMinorColor;
                Y1MinorDashStyleComboBox.SelectedItem = GForceSettings.Y1DefaultMinorDashStyle;
                Y1MinorEnabledCheckBox.Checked = GForceSettings.Y1DefaultMinorEnabled;
                Y1MinorIntervalComboBox.SelectedItem = GForceSettings.Y1DefaultMinorIntervalFraction;
                Y1MinorLineWidthComboBox.SelectedItem = GForceSettings.Y1DefaultMinorLineWidth;
            }
            else
            {
                Y1MaxMaskedTextBox.Text = GForceSettings.Y1Max.ToString();
                Y1MinMaskedTextBox.Text = GForceSettings.Y1Min.ToString();

                Y1ComboBoxFonts.SelectedItem = GForceSettings.Y1FontFamily;//Y1ComboBoxFonts.Items[GForceSettings.Y1FontIndex];//Sets default SelectedItem to Microsoft Sans Serif

                //GForceSettings.Y1FontString = Y1ComboBoxFonts.SelectedItem.ToString();//Gets default SelectedItem's string "Microsoft Sans Serif"

                Y1FontSizeComboBox.SelectedItem = GForceSettings.Y1FontSize;

                Y1FontStyleComboBox.SelectedItem = GForceSettings.Y1FontStyle;

                Y1FontColorComboBox.SelectedItem = GForceSettings.Y1FontColor;

                Y1MajorColorComboBox.SelectedItem = GForceSettings.Y1MajorColor;
                Y1MajorDecimalsComboBox.SelectedItem = GForceSettings.Y1MajorDecimals;
                Y1MajorIntervalDividerComboBox.SelectedItem = GForceSettings.Y1IntervalDivider;
                Y1MajorLineWidthComboBox.SelectedItem = GForceSettings.Y1MajorLineWidth;
                Y1MinorColorComboBox.SelectedItem = GForceSettings.Y1MinorColor;
                Y1MinorDashStyleComboBox.SelectedItem = GForceSettings.Y1MinorDashStyle;
                Y1MinorEnabledCheckBox.Checked = GForceSettings.Y1MinorEnabled;
                Y1MinorIntervalComboBox.SelectedItem = GForceSettings.Y1MinorIntervalFraction;
                Y1MinorLineWidthComboBox.SelectedItem = GForceSettings.Y1MinorLineWidth;
            }
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            /*
            if ()
            {

            }
            else
            {

            }
            */
            // Other stuff
            if (DefaultsCheckBox.Checked == true)
            {
                GForceSettings.BackgroundColor = GForceSettings.DefaultBackgroundColor;
                GForceSettings.MarkerColor = GForceSettings.DefaultMarkerColor;
                GForceSettings.HistoryAmountPoints = GForceSettings.DefaultHistoryAmountPoints;
                GForceSettings.InfiniteHistoryEnabled = GForceSettings.DefaultInfiniteHistoryEnabled;
                GForceSettings.Scheme = GForceSettings.DefaultScheme;
            }
            else
            {
                GForceSettings.BackgroundColor = (Color)BackgroundColorComboBox.SelectedItem;
                GForceSettings.MarkerColor = (Color)MarkerColorComboBox.SelectedItem;
                GForceSettings.HistoryAmountPoints = Parsers.HistoryAmountPointsMaskedTextBoxParserInt(HistoryAmountPointsMaskedTextBox, GForceSettings.HistoryAmountPoints, GForceSettings.DefaultHistoryAmountPoints, true);
                GForceSettings.InfiniteHistoryEnabled = InfiniteHistoryCheckBox.Checked;
                GForceSettings.Scheme = SchemeComboBox.Text;
            }

            // X-Axis
            if (X1DefaultsCheckBox.Checked == true)
            {
                GForceSettings.X1AngleType = GForceSettings.X1DefaultAngleType;

                GForceSettings.X1FontFamily = GForceSettings.X1DefaultFontFamily;
                GForceSettings.X1FontSize = GForceSettings.X1DefaultFontSize;
                GForceSettings.X1FontStyle = GForceSettings.X1DefaultFontStyle;
                GForceSettings.X1FontColor = GForceSettings.X1DefaultFontColor;

                GForceSettings.X1MajorLineWidth = GForceSettings.X1DefaultMajorLineWidth;
                GForceSettings.X1MajorIntervalFraction = GForceSettings.X1DefaultMajorIntervalFraction;
                GForceSettings.X1MajorColor = GForceSettings.X1DefaultMajorColor;

                GForceSettings.X1MinorEnabled = GForceSettings.X1DefaultMinorEnabled;
                GForceSettings.X1MinorIntervalFraction = GForceSettings.X1DefaultMinorIntervalFraction;
                GForceSettings.X1MinorLineWidth = GForceSettings.X1DefaultMinorLineWidth;
                GForceSettings.X1MinorColor = GForceSettings.X1DefaultMinorColor;
                GForceSettings.X1MinorDashStyle = GForceSettings.X1DefaultMinorDashStyle;
            }
            else
            {
                GForceSettings.X1AngleType = X1AngleTypeComboBox.Text;
                GForceSettings.X1FontIndex = X1ComboBoxFonts.SelectedIndex;
                GForceSettings.X1FontFamily = (FontFamily)X1ComboBoxFonts.SelectedItem;
                GForceSettings.X1FontColor = (Color)X1FontColorComboBox.SelectedItem;
                GForceSettings.X1FontSize = (float)X1FontSizeComboBox.SelectedItem;
                GForceSettings.X1FontStyle = (FontStyle)X1FontStyleComboBox.SelectedItem;

                GForceSettings.X1MajorLineWidth = (int)X1MajorLineWidthComboBox.SelectedItem;
                GForceSettings.X1MajorIntervalFraction = (int)X1MajorIntervalFractionComboBox.SelectedItem;//Parsers.TextBoxParserInt(X1MajorIntervalFractionTextBox, GForceSettings.X1MajorIntervalFraction, GForceSettings.X1DefaultMajorIntervalFraction, true);
                GForceSettings.X1MajorColor = (Color)X1MajorColorComboBox.SelectedItem;

                GForceSettings.X1MinorEnabled = X1MinorEnabledCheckBox.Checked;
                GForceSettings.X1MinorIntervalFraction = (int)X1MinorIntervalComboBox.SelectedItem;
                GForceSettings.X1MinorLineWidth = (int)X1MinorLineWidthComboBox.SelectedItem;
                GForceSettings.X1MinorColor = (Color)X1MinorColorComboBox.SelectedItem;
                GForceSettings.X1MinorDashStyle = (ChartDashStyle)X1MinorDashStyleComboBox.SelectedItem;
            }

            // Y-Axis
            if (Y1DefaultsCheckBox.Checked == true)
            {
                GForceSettings.Y1Min = GForceSettings.Y1DefaultMin;
                GForceSettings.Y1Max = GForceSettings.Y1DefaultMax;

                GForceSettings.Y1FontFamily = GForceSettings.Y1DefaultFontFamily;
                GForceSettings.Y1FontSize = GForceSettings.Y1DefaultFontSize;
                GForceSettings.Y1FontStyle = GForceSettings.Y1DefaultFontStyle;
                GForceSettings.Y1FontColor = GForceSettings.Y1DefaultFontColor;


                GForceSettings.Y1MajorLineWidth = GForceSettings.Y1DefaultMajorLineWidth;
                GForceSettings.Y1MajorDecimals = GForceSettings.Y1DefaultMajorDecimals;
                GForceSettings.Y1IntervalDivider = GForceSettings.Y1DefaultIntervalDivider;
                GForceSettings.Y1MajorColor = GForceSettings.Y1DefaultMajorColor;

                GForceSettings.Y1MinorEnabled = GForceSettings.Y1DefaultMinorEnabled;
                GForceSettings.Y1MinorIntervalFraction = GForceSettings.Y1DefaultMinorIntervalFraction;
                GForceSettings.Y1MinorLineWidth = GForceSettings.Y1DefaultMinorLineWidth;
                GForceSettings.Y1MinorColor = GForceSettings.Y1DefaultMinorColor;
                GForceSettings.Y1MinorDashStyle = GForceSettings.Y1DefaultMinorDashStyle;
            }
            else
            {
                GForceSettings.Y1FontIndex = Y1ComboBoxFonts.SelectedIndex;
                //GForceSettings.Y1FontString = Y1ComboBoxFonts.Text;
                GForceSettings.Y1FontFamily = (FontFamily)Y1ComboBoxFonts.SelectedItem;
                GForceSettings.Y1FontColor = (Color)Y1FontColorComboBox.SelectedItem;
                GForceSettings.Y1FontSize = (float)Y1FontSizeComboBox.SelectedItem;
                GForceSettings.Y1FontStyle = (FontStyle)Y1FontStyleComboBox.SelectedItem;

                GForceSettings.Y1Min = Parsers.MaskedTextBoxParserDouble(Y1MinMaskedTextBox, GForceSettings.Y1Min, GForceSettings.Y1DefaultMin, true);
                GForceSettings.Y1Max = Parsers.MaskedTextBoxParserDouble(Y1MaxMaskedTextBox, GForceSettings.Y1Max, GForceSettings.Y1DefaultMax, true);

                GForceSettings.Y1MajorLineWidth = (int)Y1MajorLineWidthComboBox.SelectedItem;
                GForceSettings.Y1MajorDecimals = (int)Y1MajorDecimalsComboBox.SelectedItem;
                GForceSettings.Y1IntervalDivider = (int)Y1MajorIntervalDividerComboBox.SelectedItem;//Parsers.TextBoxParserInt(Y1IntervalDividerTextBox, GForceSettings.Y1IntervalDivider, GForceSettings.Y1DefaultIntervalDivider, true);
                GForceSettings.Y1MajorColor = (Color)Y1MajorColorComboBox.SelectedItem;

                GForceSettings.Y1MinorEnabled = Y1MinorEnabledCheckBox.Checked;
                GForceSettings.Y1MinorIntervalFraction = (int)Y1MinorIntervalComboBox.SelectedItem;
                GForceSettings.Y1MinorLineWidth = (int)Y1MinorLineWidthComboBox.SelectedItem;
                GForceSettings.Y1MinorColor = (Color)Y1MinorColorComboBox.SelectedItem;
                GForceSettings.Y1MinorDashStyle = (ChartDashStyle)Y1MinorDashStyleComboBox.SelectedItem;
            }
            // Updating and clearing the charts from old data
            FormGForce form = (FormGForce)Application.OpenForms["FormGForce"];
            var chart1 = form.chart1;
            var chart2 = form.chart2;
            var timer1 = form.timer1;
            var timer2 = form.timer1;

            timer1.Enabled = false;
            timer2.Enabled = false;
            GForce.ClearSeriesHistory(chart1);
            GForce.SetArrays();
            GForce.SetPolarChart(chart1);
            GForce.SetUpDownChart(chart2);
            timer1.Enabled = true;
            timer2.Enabled = true;
        }

        private void LoadCurrentValuesButton_Click(object sender, EventArgs e)
        {
            LoadX1Defaults();
            LoadY1Defaults();
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
                GForceSettings.OtherDefaults = true;
            }
            else
            {
                GForceSettings.OtherDefaults = false;
            }
        }
        private void MarkerColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //GForceSettings GForceSettings = new GForceSettings();
            var comboBox = (ComboBox)sender;
            var color = (Color)comboBox.Items[e.Index];
            SolidBrush brush = new SolidBrush(color);
            var font = new Font(GForceSettings.Y1DefaultFontFamily, GForceSettings.Y1DefaultFontSize, GForceSettings.Y1DefaultFontStyle);
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
            MarkerColorComboBox.Font = new Font(GForceSettings.Y1DefaultFontFamily, GForceSettings.Y1DefaultFontSize, GForceSettings.Y1DefaultFontStyle);
            CheckFontColorAndSetBackGroundColor(MarkerColorComboBox, (Color)color);
        }

        private void BackgroundColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //GForceSettings GForceSettings = new GForceSettings();
            var comboBox = (ComboBox)sender;
            var color = (Color)comboBox.Items[e.Index];
            SolidBrush brush = new SolidBrush(color);
            var font = new Font(GForceSettings.Y1DefaultFontFamily, GForceSettings.Y1DefaultFontSize, GForceSettings.Y1DefaultFontStyle);
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
            BackgroundColorComboBox.Font = new Font(GForceSettings.Y1DefaultFontFamily, GForceSettings.Y1DefaultFontSize, GForceSettings.Y1DefaultFontStyle);
            CheckFontColorAndSetBackGroundColor(BackgroundColorComboBox, (Color)color);
        }

        private void GreenRedSchemeComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //GForceSettings GForceSettings = new GForceSettings();
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
            else
            {
                color = Color.Black;
            }
            SolidBrush brush = new SolidBrush((Color)color);
            var font = new Font(GForceSettings.Y1DefaultFontFamily, GForceSettings.Y1DefaultFontSize, FontStyle.Bold);
            string colorRemovePart1 = color.ToString().Replace("Color [", "");
            string colorRemovePart2 = colorRemovePart1.Replace("]", "");
            string colorName = colorRemovePart2 + " Red";
            e.DrawBackground();
            e.Graphics.DrawString(colorName, font, brush, e.Bounds.X, e.Bounds.Y);
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
                GForceSettings.X1Defaults = true;
            }
            else
            {
                GForceSettings.X1Defaults = false;
            }
        }
        private void X1ComboBoxFonts_DrawItem(object sender, DrawItemEventArgs e)
        {
            //GForceSettings GForceSettings = new GForceSettings();
            var comboBox = (ComboBox)sender;
            var fontFamily = (FontFamily)comboBox.Items[e.Index];
            var font = new Font(fontFamily, GForceSettings.X1DefaultFontSize, GForceSettings.X1DefaultFontStyle);
            e.DrawBackground();
            e.Graphics.DrawString(font.Name, font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
        }

        private void X1ComboBoxFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GForceSettings GForceSettings = new GForceSettings();
            var comboBox = (ComboBox)sender;
            var fontFamily = (FontFamily)comboBox.SelectedItem;
            X1ComboBoxFonts.Font = new Font(fontFamily, GForceSettings.X1DefaultFontSize, GForceSettings.X1DefaultFontStyle);
        }

        private void X1FontStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GForceSettings GForceSettings = new GForceSettings();
            //GForceSettings.X1FontStyle = (FontStyle)X1FontStyleComboBox.SelectedItem;
            var comboBox = (ComboBox)sender;
            var fontStyle = (FontStyle)comboBox.SelectedItem;
            X1FontStyleComboBox.Font = new Font(GForceSettings.X1DefaultFontFamily, GForceSettings.X1DefaultFontSize, fontStyle);
        }

        private void X1FontStyleComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //GForceSettings GForceSettings = new GForceSettings();
            var comboBox = (ComboBox)sender;
            var fontStyle = (FontStyle)comboBox.Items[e.Index];
            var font = new Font(GForceSettings.X1DefaultFontFamily, GForceSettings.X1DefaultFontSize, fontStyle);
            e.DrawBackground();
            e.Graphics.DrawString(fontStyle.ToString(), font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
        }

        private void X1FontColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GForceSettings GForceSettings = new GForceSettings();
            //GForceSettings.X1FontColor = (Color)X1FontColorComboBox.SelectedItem;
            var comboBox = (ComboBox)sender;
            var color = comboBox.SelectedItem;
            X1FontColorComboBox.Font = new Font(GForceSettings.X1DefaultFontFamily, GForceSettings.X1DefaultFontSize, GForceSettings.X1DefaultFontStyle);
            X1FontColorComboBox.ForeColor = (Color)color;
            CheckFontColorAndSetBackGroundColor(X1FontColorComboBox, (Color)color);
        }

        private void X1FontColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //GForceSettings GForceSettings = new GForceSettings();
            var comboBox = (ComboBox)sender;
            var color = (Color)comboBox.Items[e.Index];
            SolidBrush brush = new SolidBrush(color);
            var font = new Font(GForceSettings.X1DefaultFontFamily, GForceSettings.X1DefaultFontSize, GForceSettings.X1DefaultFontStyle);
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
            //GForceSettings GForceSettings = new GForceSettings();
            //GForceSettings.X1FontSize = (float)X1FontSizeComboBox.SelectedItem;
            X1FontSizeComboBox.Font = new Font(GForceSettings.X1DefaultFontFamily, (float)fontSize, GForceSettings.X1DefaultFontStyle);
            //textBox8.Text = GForceSettings.X1FontSize.ToString();
            //comboBox7.Text = p.GetX1FontSize().ToString();
        }

        private void X1FontSizeComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //GForceSettings GForceSettings = new GForceSettings();
            var comboBox = (ComboBox)sender;
            var fontSize = comboBox.Items[e.Index];
            var font = new Font(GForceSettings.X1DefaultFontFamily, GForceSettings.X1DefaultFontSize, GForceSettings.X1DefaultFontStyle);
            e.DrawBackground();
            e.Graphics.DrawString(fontSize.ToString(), font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
        }
        private void X1MajorColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GForceSettings GForceSettings = new GForceSettings();
            //GForceSettings.X1MajorColor = (Color)X1MajorColorComboBox.SelectedItem;
            var comboBox = (ComboBox)sender;
            var color = comboBox.SelectedItem;
            X1MajorColorComboBox.Font = new Font(GForceSettings.X1DefaultFontFamily, GForceSettings.X1DefaultFontSize, GForceSettings.X1DefaultFontStyle);
            X1MajorColorComboBox.ForeColor = (Color)color;
            CheckFontColorAndSetBackGroundColor(X1MajorColorComboBox, (Color)color);
        }
        private void X1MajorColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //GForceSettings GForceSettings = new GForceSettings();
            var comboBox = (ComboBox)sender;
            var color = (Color)comboBox.Items[e.Index];
            SolidBrush brush = new SolidBrush(color);
            var font = new Font(GForceSettings.X1DefaultFontFamily, GForceSettings.X1DefaultFontSize, GForceSettings.X1FontStyle);
            string colorRemovePart1 = color.ToString().Replace("Color [", "");
            string colorRemovePart2 = colorRemovePart1.Replace("]", "");
            string colorName = colorRemovePart2;
            e.DrawBackground();
            e.Graphics.DrawString(colorName, font, brush, e.Bounds.X, e.Bounds.Y);
            CheckFontColorAndSetBackGroundColor(X1MajorColorComboBox, (Color)color);
        }


        //////////////////////////////////////////////////////////////////////////////////////////77
        ///Y1 STUFF
        ///
        private void Y1DefaultsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Y1DefaultsCheckBox.Checked == true)
            {
                GForceSettings.Y1Defaults = true;
            }
            else
            {
                GForceSettings.Y1Defaults = false;
            }
        }
        private void Y1ComboBoxFonts_DrawItem(object sender, DrawItemEventArgs e)
        {
            //GForceSettings GForceSettings = new GForceSettings();
            var comboBox = (ComboBox)sender;
            var fontFamily = (FontFamily)comboBox.Items[e.Index];
            var font = new Font(fontFamily, GForceSettings.Y1DefaultFontSize, GForceSettings.Y1DefaultFontStyle);
            e.DrawBackground();
            e.Graphics.DrawString(font.Name, font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
        }

        private void Y1ComboBoxFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = (ComboBox)sender;
            var fontFamily = (FontFamily)comboBox.SelectedItem;
            Y1ComboBoxFonts.Font = new Font(fontFamily, GForceSettings.Y1DefaultFontSize, GForceSettings.Y1DefaultFontStyle);
        }

        private void Y1FontStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GForceSettings GForceSettings = new GForceSettings();
            //GForceSettings.Y1FontStyle = (FontStyle)Y1FontStyleComboBox.SelectedItem;
            var comboBox = (ComboBox)sender;
            var fontStyle = (FontStyle)comboBox.SelectedItem;
            Y1FontStyleComboBox.Font = new Font(GForceSettings.Y1DefaultFontFamily, GForceSettings.Y1DefaultFontSize, fontStyle);
        }

        private void Y1FontStyleComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //GForceSettings GForceSettings = new GForceSettings();
            var comboBox = (ComboBox)sender;
            var fontStyle = (FontStyle)comboBox.Items[e.Index];
            var font = new Font(GForceSettings.Y1DefaultFontFamily, GForceSettings.Y1DefaultFontSize, fontStyle);
            e.DrawBackground();
            e.Graphics.DrawString(fontStyle.ToString(), font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
        }

        private void Y1FontColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GForceSettings GForceSettings = new GForceSettings();
            //GForceSettings.Y1FontColor = (Color)Y1FontColorComboBox.SelectedItem;
            var comboBox = (ComboBox)sender;
            var color = comboBox.SelectedItem;
            Y1FontColorComboBox.Font = new Font(GForceSettings.Y1DefaultFontFamily, GForceSettings.Y1DefaultFontSize, GForceSettings.Y1DefaultFontStyle);
            Y1FontColorComboBox.ForeColor = (Color)color;
            CheckFontColorAndSetBackGroundColor(Y1FontColorComboBox, (Color)color);
        }

        private void Y1FontColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //GForceSettings GForceSettings = new GForceSettings();
            var comboBox = (ComboBox)sender;
            var color = (Color)comboBox.Items[e.Index];
            SolidBrush brush = new SolidBrush(color);
            var font = new Font(GForceSettings.Y1DefaultFontFamily, GForceSettings.Y1DefaultFontSize, GForceSettings.Y1DefaultFontStyle);
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
            Y1FontSizeComboBox.Font = new Font(GForceSettings.Y1DefaultFontFamily, (float)fontSize, GForceSettings.Y1DefaultFontStyle);
        }

        private void Y1FontSizeComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //GForceSettings GForceSettings = new GForceSettings();
            var comboBox = (ComboBox)sender;
            var fontSize = comboBox.Items[e.Index];
            var font = new Font(GForceSettings.Y1DefaultFontFamily, GForceSettings.Y1DefaultFontSize, GForceSettings.Y1DefaultFontStyle);
            e.DrawBackground();
            e.Graphics.DrawString(fontSize.ToString(), font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
        }
        private void Y1MajorColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GForceSettings GForceSettings = new GForceSettings();
            //GForceSettings.Y1MajorColor = (Color)Y1MajorColorComboBox.SelectedItem;
            var comboBox = (ComboBox)sender;
            var color = comboBox.SelectedItem;
            Y1MajorColorComboBox.Font = new Font(GForceSettings.Y1DefaultFontFamily, GForceSettings.Y1DefaultFontSize, GForceSettings.Y1DefaultFontStyle);
            Y1MajorColorComboBox.ForeColor = (Color)color;
            CheckFontColorAndSetBackGroundColor(Y1MajorColorComboBox, (Color)color);
        }
        private void Y1MajorColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //GForceSettings GForceSettings = new GForceSettings();
            var comboBox = (ComboBox)sender;
            var color = (Color)comboBox.Items[e.Index];
            SolidBrush brush = new SolidBrush(color);
            var font = new Font(GForceSettings.Y1DefaultFontFamily, GForceSettings.Y1DefaultFontSize, GForceSettings.Y1DefaultFontStyle);
            string colorRemovePart1 = color.ToString().Replace("Color [", "");
            string colorRemovePart2 = colorRemovePart1.Replace("]", "");
            string colorName = colorRemovePart2;
            e.DrawBackground();
            e.Graphics.DrawString(colorName, font, brush, e.Bounds.X, e.Bounds.Y);
            CheckFontColorAndSetBackGroundColor(Y1MajorColorComboBox, (Color)color);
        }
        private void X1MajorLineWidthComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private void X1MajorDecimalsComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private void AngleTypeComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private void X1MinorIntervalComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private void X1MinorLineWidthComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private void X1MinorColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GForceSettings GForceSettings = new GForceSettings();
            //GForceSettings.X1MinorColor = (Color)X1MinorColorComboBox.SelectedItem;
            var comboBox = (ComboBox)sender;
            var color = comboBox.SelectedItem;
            X1MinorColorComboBox.Font = new Font(GForceSettings.X1DefaultFontFamily, GForceSettings.X1DefaultFontSize, GForceSettings.X1DefaultFontStyle);
            X1MinorColorComboBox.ForeColor = (Color)color;
            CheckFontColorAndSetBackGroundColor(X1MinorColorComboBox, (Color)color);
        }
        private void X1MinorColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //GForceSettings GForceSettings = new GForceSettings();
            var comboBox = (ComboBox)sender;
            var color = (Color)comboBox.Items[e.Index];
            SolidBrush brush = new SolidBrush(color);
            var font = new Font(GForceSettings.X1DefaultFontFamily, GForceSettings.X1DefaultFontSize, GForceSettings.X1DefaultFontStyle);
            string colorRemovePart1 = color.ToString().Replace("Color [", "");
            string colorRemovePart2 = colorRemovePart1.Replace("]", "");
            string colorName = colorRemovePart2;
            e.DrawBackground();
            e.Graphics.DrawString(colorName, font, brush, e.Bounds.X, e.Bounds.Y);
            CheckFontColorAndSetBackGroundColor(X1MinorColorComboBox, (Color)color);
        }

        private void X1MinorDashStyleComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private void Y1MajorLineWidthComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private void Y1MajorDecimalsComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private void Y1MinorIntervalComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private void Y1MinorLineWidthComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private void Y1MinorColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GForceSettings GForceSettings = new GForceSettings();
            //GForceSettings.Y1MinorColor = (Color)Y1MinorColorComboBox.SelectedItem;
            var comboBox = (ComboBox)sender;
            var color = comboBox.SelectedItem;
            Y1MinorColorComboBox.Font = new Font(GForceSettings.Y1DefaultFontFamily, GForceSettings.Y1DefaultFontSize, GForceSettings.Y1DefaultFontStyle);
            Y1MinorColorComboBox.ForeColor = (Color)color;
            CheckFontColorAndSetBackGroundColor(Y1MinorColorComboBox, (Color)color);
        }
        private void Y1MinorColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //GForceSettings GForceSettings = new GForceSettings();
            var comboBox = (ComboBox)sender;
            var color = (Color)comboBox.Items[e.Index];
            SolidBrush brush = new SolidBrush(color);
            var font = new Font(GForceSettings.Y1DefaultFontFamily, GForceSettings.Y1DefaultFontSize, GForceSettings.Y1DefaultFontStyle);
            string colorRemovePart1 = color.ToString().Replace("Color [", "");
            string colorRemovePart2 = colorRemovePart1.Replace("]", "");
            string colorName = colorRemovePart2;
            e.DrawBackground();
            e.Graphics.DrawString(colorName, font, brush, e.Bounds.X, e.Bounds.Y);
            CheckFontColorAndSetBackGroundColor(Y1MinorColorComboBox, (Color)color);
        }

        private void Y1MinorDashStyleComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private void Y1IntervalDividerComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private void FormGForceSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            GForceSettings.SettingsOpen = false;
            RegistryTools.SaveAllSettings(Application.ProductName, this);
        }

        private void FormGForceSettings_Load(object sender, EventArgs e)
        {
            GForceSettings.SettingsOpen = true;
            RegistryTools.LoadAllSettings(Application.ProductName, this);
        }

        private void Y1MajorIntervalDividerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SchemeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void InfiniteHistoryCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void HistoryAmountPointsMaskedTextBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Y1IntervalDividerTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Y1MinorLineWidthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Y1MaxMaskedTextBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Y1MajorLineWidthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Y1MinorEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Y1MinorDashStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Y1MinorIntervalComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Y1MajorDecimalsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Y1MinMaskedTextBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void X1AngleTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void X1MajorIntervalFractionTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void X1MinorLineWidthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void X1MajorLineWidthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void X1MinorEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void X1MinorDashStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void X1MinorIntervalComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MarkerColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void BackgroundColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void X1MajorIntervalFractionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
