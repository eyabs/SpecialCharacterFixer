using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpecialCharacterFixer
{
    class CSVParser
    {
        // TO DO:
        // Add parsing to dictionary.
        // Add exception handling.

        //
        // Getters/Setters.
        private Regex rxCommaDelim = new Regex(@",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))", RegexOptions.Compiled);
        private char commaDelim = ',';

        public bool isInitalized { get; private set; }

        public string inFilePath { get; private set; }
        //public string outPath { get; set; }
        public string fName { get; private set; }
        public string fNameWithExtension { get; private set; }

        public string StrHeader { get; private set; }
        public string[] ArrHeader { get; private set; }
        public string StrLine { get; private set; }
        public string[] ArrLine { get; private set; }

        //
        // Constructors;

        public CSVParser()
        {

        }

        public CSVParser(string aInFilePath)
        {
            setPath(aInFilePath);
        }

        //
        // Members.
        
        public void setPath(string aInFilePath)
        {
            if (File.Exists(aInFilePath))
            {
                inFilePath = aInFilePath;
                findFName();
                isInitalized = true;
            }
        }

        public void setLine (string aLine)
        {
            StrLine = aLine;
        }

        public void setAndParseLine(string aLine)
        {
            StrLine = aLine;
            fParseLine();
        }

        public void setAndParseHeader (string aHeader)
        {
            StrHeader = aHeader;
            ArrHeader = rxCommaDelim.Split(StrHeader);
            
            int loop = 0;
            foreach (string record in ArrHeader)
            {
                ArrHeader[loop] = record.Trim('\"');
                loop++;
            }
        }
        
        // sParseLine()
        // Simple parsing, does not check for quotes containing commas, nor trim quotes.
        // Converts StrLine to an array as ArrLine
        public void sParseLine()
        {
            ArrLine = StrLine.Split(commaDelim);
        }

        // fParseLine()
        // Full Parsing. Ignores commas within records and trims quotes surrounding records.
        // Converts StrLine to an array as ArrLine
        public void fParseLine()
        {
            ArrLine = rxCommaDelim.Split(StrLine);

            int loop = 0;
            foreach (string record in ArrLine)
            {
                ArrLine[loop] = record.Trim('\"');
                loop++;
            }
        }

        // fParseLine(string)
        // Full Parsing. Ignores commas within records and trims quotes surrounding records.
        // returns an array .of the split input string.
        public string [] fParseLine(string aLine)
        {
            string [] array = rxCommaDelim.Split(aLine);

            int loop = 0;
            foreach (string record in array)
            {
                array[loop] = record.Trim('\"');
                loop++;
            }

            return array;
        }

        public void findFName()
        {
            if (File.Exists(inFilePath))
            {
                fName = Path.GetFileNameWithoutExtension(inFilePath);
                fNameWithExtension = Path.GetFileName(inFilePath);
            }
        }

        public long findNumRecords()
        {
            // Checked if file exists

            if (!File.Exists(inFilePath))
            {
                return 0;
            }

            long loopCounter = 0;
            string line;
            StreamReader reader = new StreamReader(inFilePath);
            
            // Count the number of lines;
            do
            {
                line = reader.ReadLine();
                loopCounter++;
            } while (reader.Peek() != -1);

            // Decrement count if last line is blank.
            if (String.IsNullOrWhiteSpace(line))
            {
                loopCounter--;
            }
            reader.Close();
            reader.Dispose();
            return loopCounter;
        }
    }

    /*
    class CSVFile : CSVParser
    {
        public List<string[]> FileData;
    }*/


    // >>>-------------------;;;;;;;;----------->

    class DataPrinter
    {
        private TextBox _txtBox;

        public DataPrinter(TextBox aTxtBox)
        {
            _txtBox = aTxtBox;
        }
        // printList() + overloads
        // Prints the specified numbner of items in a list in the error textbox w/ fixed width Default width = 15.
        public void printList(List<string[]> aList)
        {
            printList(aList, 25, 15);

        }
        public void printList(List<string[]> aList, int aMaxRecords, bool aFindWidth)
        {
            int[] widths;
            widths = allMaxLengths(aList, aMaxRecords);
            printList(aList, aMaxRecords, widths);
        }
        public void printList(List<string[]> aList, int aMaxRecords, int aWidth)
        {
            int loop = 0;
            int recordCount = aList.Count;
            foreach (string[] array in aList)
            {
                loop++;
                foreach (string item in array)
                {
                    _txtBox.Text += item.PadRight(aWidth);
                    _txtBox.Refresh();
                }
                _txtBox.Text += Environment.NewLine;
                if (loop >= aMaxRecords) break;
            }
            if (recordCount > aMaxRecords)
            {
                _txtBox.Text += "(" + (recordCount - aMaxRecords).ToString() + " more)" + Environment.NewLine;
                _txtBox.Refresh();
            }
            _txtBox.Text += Environment.NewLine;
            _txtBox.Refresh();
        }
        public void printList(List<string[]> aList, int aMaxRecords, int[] aWidths)
        {
            int colNum;
            int recordCount = aList.Count;

            int loop = 0;
            foreach (string[] array in aList)
            {
                loop++;
                colNum = 0;
                foreach (string item in array)
                {
                    try
                    {
                        _txtBox.Text += item.PadRight(aWidths[colNum] + 3);
                        _txtBox.Refresh();
                    }
                    catch
                    {
                        // Do Nothing
                        //_txtBox.Text += item.PadRight(40);
                    }
                    colNum++;
                }
                _txtBox.Text += Environment.NewLine;
                if (loop >= aMaxRecords) break;
            }
            if (recordCount > aMaxRecords)
            {
                _txtBox.Text += "(" + (recordCount - aMaxRecords).ToString() + " more)" + Environment.NewLine;
            }
            _txtBox.Text += Environment.NewLine;
            _txtBox.Refresh();
        }

        // maxLength( ... )
        // Find the largest width of an entry in a List<string[]> withing the first specified number of records.
        private int maxLength(List<string[]> aList, int aCutoff)
        {
            int max = 0;
            string[] arr;

            // Set cutoff to the length of list if the list is smaller than the cutoff.
            aCutoff = (aCutoff < aList.Count) ? aCutoff : aList.Count;
            for (int loop = 0; loop < aCutoff; ++loop)
            {
                arr = aList[loop];
                foreach (string item in arr)
                {
                    max = (item.Length > max) ? item.Length : max;
                }
            }
            return max;
        }

        // allMaxLengths( ... )
        // Return the largest widths in each col of a list of string arrays as in int array
        private int[] allMaxLengths(List<string[]> aList, int aCutoff)
        {
            // Declare max size array as same size as the number of cols, initialize to 1.
            int[] maxima = new int[aList[0].Length];
            for (int loop = 0; loop < maxima.Length; ++loop) maxima[loop] = 1;

            string[] arr;

            // Set cutoff to the length of list if the list is smaller than the cutoff.
            aCutoff = (aCutoff < aList.Count) ? aCutoff : aList.Count;
            for (int line = 0; line < aCutoff; ++line)
            {
                arr = aList[line];
                for (int colLoop = 0; colLoop < maxima.Length; ++colLoop)
                {
                    try
                    {
                        maxima[colLoop] = (maxima[colLoop] < arr[colLoop].Length) ? arr[colLoop].Length : maxima[colLoop];
                    }
                    catch
                    {
                        // Do Nothing.

                        ////maxima[colLoop] = 40;
                    }
                }
                /*
                foreach (string item in arr)
                {
                    maxima = (item.Length > max) ? item.Length : max;
                }*/
            }
            return maxima;

        }

        // Prints a string array in the error textbox w/ tab separated values.
        private void printArray(string[] aArray)
        {

            foreach (string detail in aArray)
            {
                _txtBox.Text += detail + "\t\t";
                _txtBox.Refresh();
            }
            _txtBox.Text += Environment.NewLine;
            _txtBox.Refresh();

        }
    }

}
