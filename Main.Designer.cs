
namespace m3u8_Downloader {
    partial class Main {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            bDownload = new System.Windows.Forms.Button();
            tLink = new System.Windows.Forms.TextBox();
            cConvert = new System.Windows.Forms.CheckBox();
            progressBar = new System.Windows.Forms.ProgressBar();
            lStatus = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            tName = new System.Windows.Forms.TextBox();
            cOpenFolder = new System.Windows.Forms.CheckBox();
            bFolder = new System.Windows.Forms.Button();
            cAutoName = new System.Windows.Forms.CheckBox();
            cHighestRes = new System.Windows.Forms.CheckBox();
            bPasteStart = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // bDownload
            // 
            bDownload.Location = new System.Drawing.Point(524, 95);
            bDownload.Name = "bDownload";
            bDownload.Size = new System.Drawing.Size(75, 23);
            bDownload.TabIndex = 5;
            bDownload.Text = "Download";
            bDownload.UseVisualStyleBackColor = true;
            bDownload.Click += BDownload_Click;
            // 
            // tLink
            // 
            tLink.Location = new System.Drawing.Point(53, 41);
            tLink.Name = "tLink";
            tLink.Size = new System.Drawing.Size(546, 23);
            tLink.TabIndex = 2;
            // 
            // cConvert
            // 
            cConvert.AutoSize = true;
            cConvert.Checked = true;
            cConvert.CheckState = System.Windows.Forms.CheckState.Checked;
            cConvert.Location = new System.Drawing.Point(15, 70);
            cConvert.Name = "cConvert";
            cConvert.Size = new System.Drawing.Size(109, 19);
            cConvert.TabIndex = 3;
            cConvert.Text = "Convert to mp4";
            cConvert.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            progressBar.Location = new System.Drawing.Point(299, 70);
            progressBar.Name = "progressBar";
            progressBar.Size = new System.Drawing.Size(300, 19);
            progressBar.TabIndex = 4;
            // 
            // lStatus
            // 
            lStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            lStatus.AutoSize = true;
            lStatus.Location = new System.Drawing.Point(299, 99);
            lStatus.Name = "lStatus";
            lStatus.Size = new System.Drawing.Size(42, 15);
            lStatus.TabIndex = 5;
            lStatus.Text = "lStatus";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(15, 44);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(32, 15);
            label1.TabIndex = 6;
            label1.Text = "Link:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(5, 15);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(42, 15);
            label2.TabIndex = 8;
            label2.Text = "Name:";
            // 
            // tName
            // 
            tName.Location = new System.Drawing.Point(53, 12);
            tName.Name = "tName";
            tName.ReadOnly = true;
            tName.Size = new System.Drawing.Size(546, 23);
            tName.TabIndex = 1;
            // 
            // cOpenFolder
            // 
            cOpenFolder.AutoSize = true;
            cOpenFolder.Location = new System.Drawing.Point(130, 98);
            cOpenFolder.Name = "cOpenFolder";
            cOpenFolder.Size = new System.Drawing.Size(91, 19);
            cOpenFolder.TabIndex = 4;
            cOpenFolder.Text = "Open Folder";
            cOpenFolder.UseVisualStyleBackColor = true;
            // 
            // bFolder
            // 
            bFolder.Location = new System.Drawing.Point(241, 67);
            bFolder.Name = "bFolder";
            bFolder.Size = new System.Drawing.Size(52, 23);
            bFolder.TabIndex = 9;
            bFolder.Text = "Folder";
            bFolder.UseVisualStyleBackColor = true;
            bFolder.Click += bFolder_Click;
            // 
            // cAutoName
            // 
            cAutoName.AutoSize = true;
            cAutoName.Checked = true;
            cAutoName.CheckState = System.Windows.Forms.CheckState.Checked;
            cAutoName.Location = new System.Drawing.Point(130, 70);
            cAutoName.Name = "cAutoName";
            cAutoName.Size = new System.Drawing.Size(87, 19);
            cAutoName.TabIndex = 10;
            cAutoName.Text = "Auto Name";
            cAutoName.UseVisualStyleBackColor = true;
            cAutoName.CheckedChanged += cAutoName_CheckedChanged;
            // 
            // cHighestRes
            // 
            cHighestRes.AutoSize = true;
            cHighestRes.Checked = true;
            cHighestRes.CheckState = System.Windows.Forms.CheckState.Checked;
            cHighestRes.Location = new System.Drawing.Point(15, 98);
            cHighestRes.Name = "cHighestRes";
            cHighestRes.Size = new System.Drawing.Size(88, 19);
            cHighestRes.TabIndex = 11;
            cHighestRes.Text = "Highest Res";
            cHighestRes.UseVisualStyleBackColor = true;
            // 
            // bPasteStart
            // 
            bPasteStart.Location = new System.Drawing.Point(443, 95);
            bPasteStart.Name = "bPasteStart";
            bPasteStart.Size = new System.Drawing.Size(75, 23);
            bPasteStart.TabIndex = 12;
            bPasteStart.Text = "Paste Start";
            bPasteStart.UseVisualStyleBackColor = true;
            bPasteStart.Click += bPasteStart_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(610, 127);
            Controls.Add(bPasteStart);
            Controls.Add(cHighestRes);
            Controls.Add(cAutoName);
            Controls.Add(bFolder);
            Controls.Add(cOpenFolder);
            Controls.Add(label2);
            Controls.Add(tName);
            Controls.Add(label1);
            Controls.Add(lStatus);
            Controls.Add(progressBar);
            Controls.Add(cConvert);
            Controls.Add(tLink);
            Controls.Add(bDownload);
            Name = "Main";
            Text = "m3u8 Downloader";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button bDownload;
        private System.Windows.Forms.TextBox tLink;
        private System.Windows.Forms.CheckBox cConvert;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tName;
        private System.Windows.Forms.CheckBox cOpenFolder;
        private System.Windows.Forms.Button bFolder;
        private System.Windows.Forms.CheckBox cAutoName;
        private System.Windows.Forms.CheckBox cHighestRes;
        private System.Windows.Forms.Button bPasteStart;
    }
}

