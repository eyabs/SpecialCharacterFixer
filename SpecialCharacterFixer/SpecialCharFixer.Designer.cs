namespace SpecialCharacterFixer
{
    partial class frmSpecialCharRemover
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSelectedFile = new System.Windows.Forms.TextBox();
            this.btnSelectCSV = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.ofdSelectCSV = new System.Windows.Forms.OpenFileDialog();
            this.btnFindSpecChars = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.sfdExportClean = new System.Windows.Forms.SaveFileDialog();
            this.btnClearWindow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSelectedFile
            // 
            this.txtSelectedFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSelectedFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSelectedFile.Location = new System.Drawing.Point(12, 33);
            this.txtSelectedFile.Name = "txtSelectedFile";
            this.txtSelectedFile.Size = new System.Drawing.Size(710, 24);
            this.txtSelectedFile.TabIndex = 0;
            // 
            // btnSelectCSV
            // 
            this.btnSelectCSV.Location = new System.Drawing.Point(12, 4);
            this.btnSelectCSV.Name = "btnSelectCSV";
            this.btnSelectCSV.Size = new System.Drawing.Size(75, 23);
            this.btnSelectCSV.TabIndex = 1;
            this.btnSelectCSV.Text = "Open File";
            this.btnSelectCSV.UseVisualStyleBackColor = true;
            this.btnSelectCSV.Click += new System.EventHandler(this.btnSelectCSV_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.BackColor = System.Drawing.SystemColors.Desktop;
            this.txtOutput.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.ForeColor = System.Drawing.Color.Chartreuse;
            this.txtOutput.Location = new System.Drawing.Point(12, 63);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(710, 256);
            this.txtOutput.TabIndex = 2;
            this.txtOutput.WordWrap = false;
            // 
            // ofdSelectCSV
            // 
            this.ofdSelectCSV.FileName = "international.csv";
            this.ofdSelectCSV.Filter = "\"CSV Files\"|*.csv|\"Text Files\"|*.txt|\"All Files\"|*.*";
            this.ofdSelectCSV.Title = "\"Select CSV\"";
            // 
            // btnFindSpecChars
            // 
            this.btnFindSpecChars.Enabled = false;
            this.btnFindSpecChars.Location = new System.Drawing.Point(93, 4);
            this.btnFindSpecChars.Name = "btnFindSpecChars";
            this.btnFindSpecChars.Size = new System.Drawing.Size(132, 23);
            this.btnFindSpecChars.TabIndex = 3;
            this.btnFindSpecChars.Text = "Find Special Characters";
            this.btnFindSpecChars.UseVisualStyleBackColor = true;
            this.btnFindSpecChars.Click += new System.EventHandler(this.btnFindSpecChars_Click);
            // 
            // btnExport
            // 
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(231, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(123, 23);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "Export Clean File";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // sfdExportClean
            // 
            this.sfdExportClean.DefaultExt = "csv";
            // 
            // btnClearWindow
            // 
            this.btnClearWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearWindow.Location = new System.Drawing.Point(633, 4);
            this.btnClearWindow.Name = "btnClearWindow";
            this.btnClearWindow.Size = new System.Drawing.Size(89, 23);
            this.btnClearWindow.TabIndex = 5;
            this.btnClearWindow.Text = "Clear Window";
            this.btnClearWindow.UseVisualStyleBackColor = true;
            this.btnClearWindow.Click += new System.EventHandler(this.btnClearWindow_Click);
            // 
            // frmSpecialCharRemover
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 331);
            this.Controls.Add(this.btnClearWindow);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnFindSpecChars);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnSelectCSV);
            this.Controls.Add(this.txtSelectedFile);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "frmSpecialCharRemover";
            this.Text = "Special Chartacter Remover";
            this.Load += new System.EventHandler(this.frmSpecialCharRemover_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSelectedFile;
        private System.Windows.Forms.Button btnSelectCSV;
        private System.Windows.Forms.OpenFileDialog ofdSelectCSV;
        private System.Windows.Forms.Button btnFindSpecChars;
        public System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.SaveFileDialog sfdExportClean;
        private System.Windows.Forms.Button btnClearWindow;
    }
}

