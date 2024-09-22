using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Physics_Data_Debug
{
    public class CSVReadWrite
    {
        #region Fields

        public static string fileText = "";
        public static string fileName = "";
        public static string fileCompletePathAndName = "";

        public string header001 = "";
        public string header002 = "";
        public string header003 = "";
        public string header004 = "";
        public string header005 = "";
        public string header006 = "";
        public string header007 = "";
        public string header008 = "";
        public string header009 = "";
        public string header010 = "";
        public string header011 = "";
        public string header012 = "";
        public string header013 = "";
        public string header014 = "";
        public string header015 = "";
        public string header016 = "";
        public string header017 = "";
        public string header018 = "";
        public string header019 = "";
        public string header020 = "";
        public string header021 = "";
        public string header022 = "";
        public string header023 = "";
        public string header024 = "";
        public string header025 = "";
        public string header026 = "";
        public string header027 = "";
        public string header028 = "";
        public string header029 = "";
        public string header030 = "";

        public List<double> dVals001 = new List<double>();
        //public List<DateTime> xValsDate = new List<DateTime>(); // Not needed. Just an example

        public List<double> dVals002 = new List<double>();
        public List<double> dVals003 = new List<double>();
        public List<double> dVals004 = new List<double>();
        public List<double> dVals005 = new List<double>();
        public List<double> dVals006 = new List<double>();
        public List<double> dVals007 = new List<double>();
        public List<double> dVals008 = new List<double>();
        public List<double> dVals009 = new List<double>();
        public List<double> dVals010 = new List<double>();
        public List<double> dVals011 = new List<double>();
        public List<double> dVals012 = new List<double>();
        public List<double> dVals013 = new List<double>();
        public List<double> dVals014 = new List<double>();
        public List<double> dVals015 = new List<double>();
        public List<double> dVals016 = new List<double>();
        public List<double> dVals017 = new List<double>();
        public List<double> dVals018 = new List<double>();
        public List<double> dVals019 = new List<double>();
        public List<double> dVals020 = new List<double>();
        public List<double> dVals021 = new List<double>();
        public List<double> dVals022 = new List<double>();
        public List<double> dVals023 = new List<double>();
        public List<double> dVals024 = new List<double>();
        public List<double> dVals025 = new List<double>();
        public List<double> dVals026 = new List<double>();
        public List<double> dVals027 = new List<double>();
        public List<double> dVals028 = new List<double>();
        public List<double> dVals029 = new List<double>();
        public List<double> dVals030 = new List<double>();

        public int numValsPerLine;

        public List<string> fileLinesList = new List<string>();

        public List<string> headersList = new List<string>();

        public string[] lineSplitsStrArray;
        public string headerString;

        public int xValFormat = 0;

        #endregion

        #region Methods

        public void ClearListValues()
        {
            dVals001.Clear();
            dVals002.Clear();
            dVals003.Clear();
            dVals004.Clear();
            dVals005.Clear();
            dVals006.Clear();
            dVals007.Clear();
            dVals008.Clear();
            dVals009.Clear();
            dVals010.Clear();
            dVals011.Clear();
            dVals012.Clear();
            dVals013.Clear();
            dVals014.Clear();
            dVals015.Clear();
            dVals016.Clear();
            dVals017.Clear();
            dVals018.Clear();
            dVals019.Clear();
            dVals020.Clear();
            dVals021.Clear();
            dVals022.Clear();
            dVals023.Clear();
            dVals024.Clear();
            dVals025.Clear();
            dVals026.Clear();
            dVals027.Clear();
            dVals028.Clear();
            dVals029.Clear();
            dVals030.Clear();
        }

        public void ReadFile(string initialDir)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = initialDir;
            ofd.Filter = "Text files (*txt)|*.txt|CSV files (*csv)|*.csv|All files (*.*)|*.*";

            DialogResult result = ofd.ShowDialog();

            if (result == DialogResult.OK)
            {
                ClearListValues();
                fileCompletePathAndName = ofd.FileName;
                fileName = ofd.SafeFileName;
                try
                {
                    fileText = File.ReadAllText(fileCompletePathAndName);
                    
                    ParseFileString();
                }
                catch (Exception)
                {
                }
            }

        }

        public void WriteToFile(string filePath)
        {
            using (StreamWriter outputFile = new StreamWriter(filePath))
            {
                
                if (String.IsNullOrEmpty(headerString) == false)
                {
                    outputFile.WriteLine(headerString);
                }

                foreach (string str in fileLinesList)
                {
                    outputFile.WriteLine(str);
                }
            }
        }

        public void GetHeaders()
        {
            string[] fileLinesArray = headerString.Split(';');
            headersList = fileLinesArray.ToList();

            // Headers from the array
            header001 = fileLinesArray[0];
            header002 = fileLinesArray[1];
            header003 = fileLinesArray[2];
            header004 = fileLinesArray[3];
            header005 = fileLinesArray[4];
            header006 = fileLinesArray[5];
            header007 = fileLinesArray[6];
            header008 = fileLinesArray[7];
            header009 = fileLinesArray[8];
            header010 = fileLinesArray[9];
            header011 = fileLinesArray[10];
            header012 = fileLinesArray[11];
            header013 = fileLinesArray[12];
            header014 = fileLinesArray[13];
            header015 = fileLinesArray[14];
            header016 = fileLinesArray[15];
            header017 = fileLinesArray[16];
            header018 = fileLinesArray[17];
            header019 = fileLinesArray[18];
            header020 = fileLinesArray[19];
            header021 = fileLinesArray[20];
            header022 = fileLinesArray[21];
            header023 = fileLinesArray[22];
            header024 = fileLinesArray[23];
            header025 = fileLinesArray[24];
            header026 = fileLinesArray[25];
            header027 = fileLinesArray[26];
            header028 = fileLinesArray[27];
            header029 = fileLinesArray[28];
            header030 = fileLinesArray[29];
            //header031 = fileLinesArray[30];
            
        }

        public void ParseFileString()
        {
            // Define the end-of-line characters to allow separating each line of the file into a string
            char[] EOLChars = new[] { '\r', '\n' };

            // Make an array of strings containing all the lines of the file
            string[] fileLinesArray = fileText.Split(EOLChars, StringSplitOptions.RemoveEmptyEntries);

            // Convert that array to a List<string>
            fileLinesList = fileLinesArray.ToList();

            //string[] fileHeadersArray = headerString.Split(';');
            //headersList = fileHeadersArray.ToList();

            // Check to see if the first line can be parsed to doubles and if not, save the first line as "headerString" and remove the first line from the fileLinesList
            CheckForHeader();

            CheckXValFormat();

            foreach (string str in fileLinesList)
            {
                lineSplitsStrArray = str.Split(';');// what's the limiter to use to split. Here it's ;
                List<string> lineSplitStrList = lineSplitsStrArray.ToList();

                for (int i = 0; i < lineSplitStrList.Count(); i++)
                {
                    if (String.IsNullOrEmpty(lineSplitStrList[i]))
                    {
                        lineSplitStrList.RemoveAt(i);
                    }
                }

                // Deal with null or empty characters in strings

                // Get the number of CSV values in the lines, ignoring the first value
                numValsPerLine = lineSplitStrList.Count - 1;

                if (xValFormat == 1) // if format is double
                {
                    if (double.TryParse(lineSplitStrList[0], out double parsedVals001)) // Take 0th element of each line and try parse it as double
                    {
                        dVals001.Add(parsedVals001); // add it as parsedVals001
                    }
                }
                /* Not needed, just an example
                else if (xValFormat == 2) // if format if date time
                {
                    if (DateTime.TryParse(lineSplitStrList[0], out DateTime parsedX) )// Take 0th element of each line and try parse it as double
                    {
                        xValsDate.Add(parsedX);  // add it as parsedX
                    }
                }*/
                // We know there's at least one Y value so no need if (numValsPerLine >=1)
                if (double.TryParse(lineSplitStrList[1], out double parsedVals002))
                {
                    dVals002.Add(parsedVals002);
                }
                // if we have 2 (or more) values
                if (numValsPerLine >=2)
                {
                    if (double.TryParse(lineSplitStrList[2], out double parsedVals003)) // Take 2nd element of each line and try parse it as double
                    {
                        dVals003.Add(parsedVals003); // add it as parsedVals003
                    }
                }
                // if we have 3 (or more) values
                if (numValsPerLine >= 3)
                {
                    if (double.TryParse(lineSplitStrList[3], out double parsedVals004)) // Take 3rd element of each line and try parse it as double
                    {
                        dVals004.Add(parsedVals004); // add it as parsedVals004
                    }
                }
                // if we have 4 (or more) values
                if (numValsPerLine >= 4)
                {
                    if (double.TryParse(lineSplitStrList[4], out double parsedVals005)) // Take 4th element of each line and try parse it as double
                    {
                        dVals005.Add(parsedVals005); // add it as parsedVals005
                    }
                }
                // if we have 5 (or more) values
                if (numValsPerLine >= 5)
                {
                    if (double.TryParse(lineSplitStrList[5], out double parsedVals006)) // Take 5th element of each line and try parse it as double
                    {
                        dVals006.Add(parsedVals006); // add it as parsedVals006
                    }
                }
                // if we have 6 (or more) values
                if (numValsPerLine >= 6)
                {
                    if (double.TryParse(lineSplitStrList[6], out double parsedVals007)) // Take 6th element of each line and try parse it as double
                    {
                        dVals007.Add(parsedVals007); // add it as parsedVals007
                    }
                }
                // if we have 7 (or more) values
                if (numValsPerLine >= 7)
                {
                    if (double.TryParse(lineSplitStrList[7], out double parsedVals008)) // Take 7th element of each line and try parse it as double
                    {
                        dVals008.Add(parsedVals008); // add it as parsedVals008
                    }
                }
                // if we have 8 (or more) values
                if (numValsPerLine >= 8)
                {
                    if (double.TryParse(lineSplitStrList[8], out double parsedVals009)) // Take 8th element of each line and try parse it as double
                    {
                        dVals009.Add(parsedVals009); // add it as parsedVals009
                    }
                }
                // if we have 9 (or more) values
                if (numValsPerLine >= 9)
                {
                    if (double.TryParse(lineSplitStrList[9], out double parsedVals010)) // Take 9th element of each line and try parse it as double
                    {
                        dVals010.Add(parsedVals010); // add it as parsedVals010
                    }
                }
                // if we have 10 (or more) values
                if (numValsPerLine >= 10)
                {
                    if (double.TryParse(lineSplitStrList[10], out double parsedVals011)) // Take 10th element of each line and try parse it as double
                    {
                        dVals011.Add(parsedVals011); // add it as parsedVals011
                    }
                }
                // if we have 11 (or more) values
                if (numValsPerLine >= 11)
                {
                    if (double.TryParse(lineSplitStrList[11], out double parsedVals012)) // Take 11th element of each line and try parse it as double
                    {
                        dVals012.Add(parsedVals012); // add it as parsedVals012
                    }
                }
                // if we have 12 (or more) values
                if (numValsPerLine >= 12)
                {
                    if (double.TryParse(lineSplitStrList[12], out double parsedVals013)) // Take 13th element of each line and try parse it as double
                    {
                        dVals013.Add(parsedVals013); // add it as parsedVals013
                    }
                }
                // if we have 13 (or more) values
                if (numValsPerLine >= 13)
                {
                    if (double.TryParse(lineSplitStrList[13], out double parsedVals014)) // Take 14th element of each line and try parse it as double
                    {
                        dVals014.Add(parsedVals014); // add it as parsedVals014
                    }
                }
                // if we have 14 (or more) values
                if (numValsPerLine >= 14)
                {
                    if (double.TryParse(lineSplitStrList[14], out double parsedVals015)) // Take 15th element of each line and try parse it as double
                    {
                        dVals015.Add(parsedVals015); // add it as parsedVals015
                    }
                }
                // if we have 15 (or more) values
                if (numValsPerLine >= 15)
                {
                    if (double.TryParse(lineSplitStrList[15], out double parsedVals016)) // Take 16th element of each line and try parse it as double
                    {
                        dVals016.Add(parsedVals016); // add it as parsedVals016
                    }
                }
                // if we have 16 (or more) values
                if (numValsPerLine >= 16)
                {
                    if (double.TryParse(lineSplitStrList[16], out double parsedVals017)) // Take 17th element of each line and try parse it as double
                    {
                        dVals017.Add(parsedVals017); // add it as parsedVals017
                    }
                }
                // if we have 17 (or more) values
                if (numValsPerLine >= 17)
                {
                    if (double.TryParse(lineSplitStrList[17], out double parsedVals018)) // Take 18th element of each line and try parse it as double
                    {
                        dVals018.Add(parsedVals018); // add it as parsedVals018
                    }
                }
                // if we have 18 (or more) values
                if (numValsPerLine >= 18)
                {
                    if (double.TryParse(lineSplitStrList[18], out double parsedVals019)) // Take 19th element of each line and try parse it as double
                    {
                        dVals019.Add(parsedVals019); // add it as parsedVals019
                    }
                }
                // if we have 19 (or more) values
                if (numValsPerLine >= 19)
                {
                    if (double.TryParse(lineSplitStrList[19], out double parsedVals020)) // Take 20th element of each line and try parse it as double
                    {
                        dVals020.Add(parsedVals020); // add it as parsedVals020
                    }
                }
                // if we have 20 (or more) values
                if (numValsPerLine >= 20)
                {
                    if (double.TryParse(lineSplitStrList[20], out double parsedVals021)) // Take 21st element of each line and try parse it as double
                    {
                        dVals021.Add(parsedVals021); // add it as parsedVals021
                    }
                }
                // if we have 21 (or more) values
                if (numValsPerLine >= 21)
                {
                    if (double.TryParse(lineSplitStrList[21], out double parsedVals022)) // Take 22nd element of each line and try parse it as double
                    {
                        dVals022.Add(parsedVals022); // add it as parsedVals022
                    }
                }
                // if we have 22 (or more) values
                if (numValsPerLine >= 22)
                {
                    if (double.TryParse(lineSplitStrList[22], out double parsedVals023)) // Take 23rd element of each line and try parse it as double
                    {
                        dVals023.Add(parsedVals023); // add it as parsedVals023
                    }
                }
                // if we have 23 (or more) values
                if (numValsPerLine >= 23)
                {
                    if (double.TryParse(lineSplitStrList[23], out double parsedVals024)) // Take 24th element of each line and try parse it as double
                    {
                        dVals024.Add(parsedVals024); // add it as parsedVals024
                    }
                }
                // if we have 24 (or more) values
                if (numValsPerLine >= 24)
                {
                    if (double.TryParse(lineSplitStrList[24], out double parsedVals025)) // Take 25th element of each line and try parse it as double
                    {
                        dVals025.Add(parsedVals025); // add it as parsedVals025
                    }
                }
                // if we have 25 (or more) values
                if (numValsPerLine >= 25)
                {
                    if (double.TryParse(lineSplitStrList[25], out double parsedVals026)) // Take 26th element of each line and try parse it as double
                    {
                        dVals026.Add(parsedVals026); // add it as parsedVals026
                    }
                }
                // if we have 26 (or more) values
                if (numValsPerLine >= 26)
                {
                    if (double.TryParse(lineSplitStrList[26], out double parsedVals027)) // Take 27th element of each line and try parse it as double
                    {
                        dVals027.Add(parsedVals027); // add it as parsedVals027
                    }
                }
                // if we have 27 (or more) values
                if (numValsPerLine >= 27)
                {
                    if (double.TryParse(lineSplitStrList[27], out double parsedVals028)) // Take 28th element of each line and try parse it as double
                    {
                        dVals028.Add(parsedVals028); // add it as parsedVals028
                    }
                }
                // if we have 28 (or more) values
                if (numValsPerLine >= 28)
                {
                    if (double.TryParse(lineSplitStrList[28], out double parsedVals029)) // Take 29th element of each line and try parse it as double
                    {
                        dVals029.Add(parsedVals029); // add it as parsedVals029
                    }
                }
                // if we have 29 (or more) values
                if (numValsPerLine >= 29)
                {
                    if (double.TryParse(lineSplitStrList[29], out double parsedVals030)) // Take 30th element of each line and try parse it as double
                    {
                        dVals030.Add(parsedVals030); // add it as parsedVals030
                    }
                }
                // can add more
            }
            GetHeaders();
        }

        public void CheckForHeader()
        {
            // Try parse the first line into doubles to see if a header exists
            lineSplitsStrArray = fileLinesList[0].Split(FormLogSettings.Delimiter);

            if (double.TryParse(lineSplitsStrArray[0], out double firsVal))
            {
                // First value in first line was successfully parsed as double, therefore the first line is assumed to not be a header
            }
            else
            {
                // First value in first line wasn't successfully parsed as a double, therefore the first line is assumed to be a header
                //GetHeaders();
                headerString = fileLinesList[0];
                fileLinesList.RemoveAt(0);
            }
        }

        public void CheckXValFormat()
        {
            lineSplitsStrArray = fileLinesList[0].Split(FormLogSettings.Delimiter);
            
            if (double.TryParse(lineSplitsStrArray[0], out double firstVal)) // Take 0th element of each line and try parse it as double
            {
                xValFormat = 1;  // format is double if parsed as double
            }

            /* Not needed, just an example
            else if (DateTime.TryParse(lineSplitsStrArray[0], out DateTime dateTimeVal))// Take 0th element of each line and try parse it as DateTime
            {
                xValFormat = 2;  // format is DateTime if parsed as DateTime
            }
            */
        }

        #endregion
    }
}
