﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Physics_Data_Debug
{
    public class Parsers
    {
        public static double TextBoxParserDouble(TextBox textBox, double variable, double defaultVariable, bool isNegativeCheck)
        {
            if (double.TryParse(textBox.Text, out double parse))
            {
                if (isNegativeCheck == true)
                {
                    // Here you already can use a valid double 'doubleValue'
                    if (parse >= 0) // It's a positive number.
                    {
                        variable = parse;
                    }
                    else // Negative returns to default
                    {
                        textBox.Text = "Invalid negative value!";
                        variable = defaultVariable;
                    }
                }
                else
                {
                    variable = parse;
                }
            }
            else
            {
                // Here you can display an error message like 'Invalid value'
                textBox.Text = "Invalid value!";
                variable = defaultVariable;
            }
            return variable;
        }
        public static int TextBoxParserInt(TextBox textBox, int variable, int defaultVariable, bool isNegativeCheck)
        {
            if (int.TryParse(textBox.Text, out int parse))
            {
                if (isNegativeCheck == true)
                {
                    // Here you already can use a valid double 'doubleValue'
                    if (parse >= 0) // It's a positive number.
                    {
                        variable = parse;
                    }
                    else // Negative returns to default
                    {
                        textBox.Text = "Invalid negative value!";
                        variable = defaultVariable;
                    }
                }
                else
                {
                    variable = parse;
                }
            }
            else
            {
                // Here you can display an error message like 'Invalid value'
                textBox.Text = "Invalid value!";
                variable = defaultVariable;
            }
            return variable;
        }
        public static double MaskedTextBoxParserDouble(MaskedTextBox maskedTextBox, double variable, double defaultVariable, bool isNegativeCheck)
        {
            if (double.TryParse(maskedTextBox.Text, out double parse))
            {
                if (isNegativeCheck == true)
                {
                    // Here you already can use a valid double 'doubleValue'
                    if (parse >= 0) // It's a positive number.
                    {
                        variable = parse;
                    }
                    else // Negative returns to default
                    {
                        maskedTextBox.Text = "Invalid negative value!";
                        variable = defaultVariable;
                    }
                }
                else
                {
                    variable = parse;
                }
            }
            else
            {
                // Here you can display an error message like 'Invalid value'
                maskedTextBox.Text = "Invalid value!";
                variable = defaultVariable;
            }
            return variable;
        }
        public static int MaskedTextBoxParserInt(MaskedTextBox maskedTextBox, int variable, int defaultVariable, bool isNegativeCheck)
        {
            if (int.TryParse(maskedTextBox.Text, out int parse))
            {
                if (isNegativeCheck == true)
                {
                    // Here you already can use a valid double 'doubleValue'
                    if (parse >= 0) // It's a positive number.
                    {
                        variable = parse;
                    }
                    else // Negative returns to default
                    {
                        maskedTextBox.Text = "Invalid negative value!";
                        variable = defaultVariable;
                    }
                }
                else
                {
                    variable = parse;
                }
            }
            else
            {
                // Here you can display an error message like 'Invalid value'
                maskedTextBox.Text = "Invalid value!";
                variable = defaultVariable;
            }
            return variable;
        }
        public static int HistoryAmountPointsMaskedTextBoxParserInt(MaskedTextBox maskedTextBox, int variable, int defaultVariable, bool isOverTwoCheck)
        {
            if (int.TryParse(maskedTextBox.Text, out int parse))
            {
                if (isOverTwoCheck == true)
                {
                    // Here you already can use a valid double 'doubleValue'
                    if (parse >= 2) // It's a positive number over 2.
                    {
                        variable = parse;
                    }
                    else // Negative returns to default
                    {
                        maskedTextBox.Text = "Invalid value!";
                        variable = defaultVariable;
                    }
                }
                else
                {
                    variable = parse;
                }
            }
            else
            {
                // Here you can display an error message like 'Invalid value'
                maskedTextBox.Text = "Invalid value!";
                variable = defaultVariable;
            }
            return variable;
        }
    }
}
