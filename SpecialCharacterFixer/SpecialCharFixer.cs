////////////////////////
//
// SpecialCharFixer
//
// Author: Eric Yablunosky
//
// This program generates a report detailing lines in a csv (or text) 
// file which contain non standard latin characters (eg. accented letters) 
// and includes a feature to export cleaned version of file with accents 
// removed from letters and other characters deleted
//
////////////////////////


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpecialCharacterFixer
{
    public partial class frmSpecialCharRemover : Form
    {

        CSVParser infile;
        List<string[]> FileData;
        DataPrinter printer;

        public frmSpecialCharRemover()
        {
            InitializeComponent();
        }

        private void frmSpecialCharRemover_Load(object sender, EventArgs e)
        {
            printer = new DataPrinter(txtOutput);
        }

        private void btnSelectCSV_Click(object sender, EventArgs e)
        {
            if (ofdSelectCSV.ShowDialog() == DialogResult.OK)
            {
                infile = new CSVParser(ofdSelectCSV.FileName);

                txtSelectedFile.Text = infile.inFilePath;
                txtSelectedFile.Refresh();

                this.Text = "Special Character Remover (" + infile.fNameWithExtension + ")";
                btnFindSpecChars.Enabled = true;
            }

            btnExport.Enabled = false;
        }

        private void btnFindSpecChars_Click(object sender, EventArgs e)
        {
            int lineCounter;
            if (infile.isInitalized)
            {
                string originalLine;
                string fixedLine;
                FileData = new List<string[]>();
                using (StreamReader reader = new StreamReader(infile.inFilePath, Encoding.Default, true))
                {;
                    infile.setAndParseHeader(reader.ReadLine());
                    FileData.Add(infile.ArrHeader);

                    lineCounter = 0;
                    do
                    {
                        originalLine = reader.ReadLine();
                        fixedLine = RemoveSpecialChars(originalLine);
                        //infile.setAndParseLine(fixedLine);
                        if (!String.Equals(originalLine, fixedLine))
                        {
                            FileData.Add(infile.fParseLine(originalLine));
                            FileData.Add(infile.fParseLine(fixedLine));
                            FileData.Add(new string[1] { Environment.NewLine });
                            ++lineCounter;
                        }
                    } while (reader.Peek() != -1);
                }


                //////////////
                //

                // Printing the report

                ///////
                MessageBox.Show(String.Format("{0} Record{1} with special characters found.",
                                             lineCounter,
                                             (lineCounter == 1) ? "" : "s"));

                txtOutput.Text += "In File '" + infile.fNameWithExtension + "':" + Environment.NewLine;
                if (lineCounter == 0)
                {
                    txtOutput.Text += "No special characters found." + Environment.NewLine;
                }
                else
                {
                    txtOutput.Text += String.Format("{0} Record{1} with special characters found:", lineCounter, (lineCounter == 1) ? "" : "s");
                    txtOutput.Text += Environment.NewLine + Environment.NewLine;
                    printer.printList(FileData, 51, true);
                }
            } //----------End of if   

            btnExport.Enabled = true;
        } //--- End of function

        // RemoveDiacritics(string)
        // Strips accents from characters in the string.
        private string RemoveSpecialChars(string text)
        {
            // Specified replacements
            Dictionary<char, string> charSubs = new Dictionary<char, string>()
            {
                { 'ß', "ss" },
                { '°', "o. " },
                {'º', "o." },
                { 'æ', "ae" }
            };
            
            Regex illegalChars = new Regex(@"\P{IsBasicLatin}", RegexOptions.Compiled);

            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            // Separate accent characters into an unaccented character,
            // and a non-spacing accent, then removing the accent.
            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                // Do the accent / character splitting
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    // This if rejects non-ASCII characters (save for the replacements above)
                    if (!illegalChars.IsMatch(c.ToString())) stringBuilder.Append(c);
                    else if (charSubs.ContainsKey(c)) stringBuilder.Append(charSubs[c]);
                    else stringBuilder.Append(" ");
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }


        //ExportClean(infilepath, outfilepath)
        // Copies the file located at infile path to outfilepath while cleaning forering characters
        private void ExportClean (string aInFile,string aOutPath)
        {
            string line;

            using (StreamReader reader = new StreamReader(aInFile,Encoding.Default, true))
            using (StreamWriter writer = new StreamWriter(aOutPath,true,Encoding.UTF8))
            {
                do
                {
                    try
                    {
                        line = RemoveSpecialChars(reader.ReadLine());
                        writer.WriteLine(line);
                    }
                    catch
                    {
                        MessageBox.Show("Error exporting file!");
                        return;
                    }
                }while(reader.Peek() != -1);
            }
        }

        // Saves cleaned file to specified location
        private void btnExport_Click(object sender, EventArgs e)
        {
            if(sfdExportClean.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    ExportClean(infile.inFilePath, sfdExportClean.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to save file to selected location."
                                  + Environment.NewLine
                                  + "Error:" + ex.ToString() );                    
                }
            }

            MessageBox.Show("File Saved");
        }
        
        // Clears the output/report textbox
        private void btnClearWindow_Click(object sender, EventArgs e)
        {
            txtOutput.Text = "";
        }
    }



}
