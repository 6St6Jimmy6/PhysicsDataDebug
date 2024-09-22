using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using Microsoft.Win32;

namespace Physics_Data_Debug
{
    // Source code http://www.csharphelper.com/howtos/howto_save_checkedlistbox_values.html
    // Example code by Rod Stephens licensed under CC-BY 4.0.
    class RegistryTools
    {
        // Remove all settings for this app.
        public static void ClearSettings(string app_name)
        {
            RegistryKey reg_key =
                Registry.CurrentUser.OpenSubKey("Software", true);
            reg_key.DeleteSubKeyTree(app_name);
        }

        // Save a value.
        public static void SaveSetting(string app_name,
            string name, object value)
        {
            RegistryKey reg_key =
                Registry.CurrentUser.OpenSubKey("Software", true);
            RegistryKey sub_key = reg_key.CreateSubKey(app_name);
            sub_key.SetValue(name, value);
        }

        // Get a value.
        public static object GetSetting(string app_name, string name, object default_value)
        {
            RegistryKey reg_key = Registry.CurrentUser.OpenSubKey("Software", true);
            RegistryKey sub_key = reg_key.CreateSubKey(app_name);
            return sub_key.GetValue(name, default_value);
        }

        // Load all of the saved settings.
        public static void LoadAllSettings(string app_name, Form frm)
        {
            // Load form settings.
            frm.SetBounds(
                (int)GetSetting(app_name, "FormLeft", frm.Left),
                (int)GetSetting(app_name, "FormTop", frm.Top),
                (int)GetSetting(app_name, "FormWidth", frm.Width),
                (int)GetSetting(app_name, "FormHeight", frm.Height));
            frm.WindowState = (FormWindowState)GetSetting(app_name,
                "FormWindowState", frm.WindowState);

            // Load the controls' values.
            LoadChildSettings(app_name, frm);
        }

        // Load all child control settings.
        public static void LoadChildSettings(string app_name, Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                // Restore the child's value.
                switch (child.GetType().Name)
                {
                    case "TextBox":
                    case "ListBox":
                    case "ComboBox":
                        child.Text = GetSetting(app_name, child.Name, child.Text).ToString();
                        break;
                    case "CheckBox":
                        CheckBox chk = child as CheckBox;
                        chk.Checked = bool.Parse(GetSetting(app_name,
                            child.Name, chk.Checked.ToString()).ToString());
                        break;
                    case "RadioButton":
                        RadioButton rad = child as RadioButton;
                        rad.Checked = bool.Parse(GetSetting(app_name,
                            child.Name, rad.Checked.ToString()).ToString());
                        break;
                    case "VScrollBar":
                        VScrollBar vscr = child as VScrollBar;
                        vscr.Value = (int)GetSetting(app_name, child.Name, vscr.Value);
                        break;
                    case "HScrollBar":
                        HScrollBar hscr = child as HScrollBar;
                        hscr.Value = (int)GetSetting(app_name, child.Name, hscr.Value);
                        break;
                    case "NumericUpDown":
                        NumericUpDown nud = child as NumericUpDown;
                        nud.Value = decimal.Parse(GetSetting(app_name, child.Name, nud.Value).ToString());
                        break;
                    case "CheckedListBox":
                        CheckedListBox lst = child as CheckedListBox;
                        for (int i = 0; i < lst.Items.Count; i++)
                        {
                            // Default is false.
                            string item_name = child.Name + "(" + i.ToString() + ")";
                            bool is_checked = bool.Parse(GetSetting(app_name, item_name, "False").ToString());
                            lst.SetItemChecked(i, is_checked);
                        }
                        break;

                        // Add other control types here.
                }

                // Recursively restore the child's children.
                LoadChildSettings(app_name, child);
            }
        }

        // Save all of the form's settings.
        public static void SaveAllSettings(string app_name, Form frm)
        {
            ClearSettings(app_name);

            // Save form settings.
            SaveSetting(app_name, "FormWindowState", (int)frm.WindowState);
            if (frm.WindowState == FormWindowState.Normal)
            {
                // Save current bounds.
                SaveSetting(app_name, "FormLeft", frm.Left);
                SaveSetting(app_name, "FormTop", frm.Top);
                SaveSetting(app_name, "FormWidth", frm.Width);
                SaveSetting(app_name, "FormHeight", frm.Height);
            }
            else
            {
                // Save bounds when we're restored.
                SaveSetting(app_name, "FormLeft", frm.RestoreBounds.Left);
                SaveSetting(app_name, "FormTop", frm.RestoreBounds.Top);
                SaveSetting(app_name, "FormWidth",
                    frm.RestoreBounds.Width);
                SaveSetting(app_name, "FormHeight",
                    frm.RestoreBounds.Height);
            }

            // Save the controls' values.
            SaveChildSettings(app_name, frm);
        }

        // Save all child control settings.
        public static void SaveChildSettings(string app_name,
            Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                // Save the child's value.
                switch (child.GetType().Name)
                {
                    case "TextBox":
                    case "ListBox":
                    case "ComboBox":
                        SaveSetting(app_name, child.Name, child.Text);
                        break;
                    case "CheckBox":
                        CheckBox chk = child as CheckBox;
                        SaveSetting(app_name, child.Name,
                            chk.Checked.ToString());
                        break;
                    case "RadioButton":
                        RadioButton rad = child as RadioButton;
                        SaveSetting(app_name, child.Name,
                            rad.Checked.ToString());
                        break;
                    case "VScrollBar":
                        VScrollBar vscr = child as VScrollBar;
                        SaveSetting(app_name, child.Name, vscr.Value);
                        break;
                    case "HScrollBar":
                        HScrollBar hscr = child as HScrollBar;
                        SaveSetting(app_name, child.Name, hscr.Value);
                        break;
                    case "NumericUpDown":
                        NumericUpDown nud = child as NumericUpDown;
                        SaveSetting(app_name, child.Name, nud.Value);
                        break;
                    case "CheckedListBox":
                        CheckedListBox lst = child as CheckedListBox;
                        for (int i = 0; i < lst.Items.Count; i++)
                        {
                            // Default is false.
                            if (lst.GetItemChecked(i))
                            {
                                string item_name = child.Name + "(" + i.ToString() + ")";
                                SaveSetting(app_name, item_name, "True");
                            }
                        }
                        break;
                        // Add other control types here.
                }

                // Recursively save the child's children.
                SaveChildSettings(app_name, child);
            }
        }
    }
}
