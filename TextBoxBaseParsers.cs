using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Physics_Data_Debug
{
    public class TextBoxBaseParsers
    {
        public static double Parser(TextBoxBase textBox, double defaultVariable, bool isNegativeCheck)
        {
            double variable;
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
                        textBox.Text = defaultVariable.ToString();
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
                textBox.Text = defaultVariable.ToString();
                variable = defaultVariable;
            }
            return variable;
        }
        public static double HistoryAmountPointsParser(TextBoxBase textBox, double defaultVariable, bool isOverTwoCheck)
        {
            double variable;
            if (double.TryParse(textBox.Text, out double parse))
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
                        textBox.Text = defaultVariable.ToString();
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
                textBox.Text = defaultVariable.ToString();
                variable = defaultVariable;
            }
            return variable;
        }
    }
}
