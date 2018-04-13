namespace ExcelReaderTest
{
    partial class Main
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
            this.btnGetRep = new System.Windows.Forms.Button();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.ofdChoose = new System.Windows.Forms.OpenFileDialog();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.txtDest = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetRep
            // 
            this.btnGetRep.Location = new System.Drawing.Point(75, 198);
            this.btnGetRep.Name = "btnGetRep";
            this.btnGetRep.Size = new System.Drawing.Size(197, 37);
            this.btnGetRep.TabIndex = 0;
            this.btnGetRep.Text = "Analizuj";
            this.btnGetRep.UseVisualStyleBackColor = true;
            this.btnGetRep.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvResult
            // 
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Location = new System.Drawing.Point(75, 263);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.RowTemplate.Height = 24;
            this.dgvResult.Size = new System.Drawing.Size(646, 241);
            this.dgvResult.TabIndex = 1;
            // 
            // ofdChoose
            // 
            this.ofdChoose.FileName = "ofdChoose";
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Location = new System.Drawing.Point(271, 77);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(108, 28);
            this.btnChooseFile.TabIndex = 2;
            this.btnChooseFile.Text = "Wybierz plik";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // txtDest
            // 
            this.txtDest.Location = new System.Drawing.Point(78, 80);
            this.txtDest.Name = "txtDest";
            this.txtDest.Size = new System.Drawing.Size(171, 22);
            this.txtDest.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Wybierz plik do analizy";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 594);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDest);
            this.Controls.Add(this.btnChooseFile);
            this.Controls.Add(this.dgvResult);
            this.Controls.Add(this.btnGetRep);
            this.Name = "Main";
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetRep;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.OpenFileDialog ofdChoose;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.TextBox txtDest;
        private System.Windows.Forms.Label label1;
    }
}

