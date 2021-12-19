
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
            this.bDownload = new System.Windows.Forms.Button();
            this.tLink = new System.Windows.Forms.TextBox();
            this.cConvert = new System.Windows.Forms.CheckBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tName = new System.Windows.Forms.TextBox();
            this.cOpenFolder = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // bDownload
            // 
            this.bDownload.Location = new System.Drawing.Point(524, 95);
            this.bDownload.Name = "bDownload";
            this.bDownload.Size = new System.Drawing.Size(75, 23);
            this.bDownload.TabIndex = 5;
            this.bDownload.Text = "Download";
            this.bDownload.UseVisualStyleBackColor = true;
            this.bDownload.Click += new System.EventHandler(this.BDownload_Click);
            // 
            // tLink
            // 
            this.tLink.Location = new System.Drawing.Point(53, 41);
            this.tLink.Name = "tLink";
            this.tLink.Size = new System.Drawing.Size(546, 23);
            this.tLink.TabIndex = 2;
            // 
            // cConvert
            // 
            this.cConvert.AutoSize = true;
            this.cConvert.Location = new System.Drawing.Point(15, 70);
            this.cConvert.Name = "cConvert";
            this.cConvert.Size = new System.Drawing.Size(109, 19);
            this.cConvert.TabIndex = 3;
            this.cConvert.Text = "Convert to mp4";
            this.cConvert.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(229, 70);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(370, 19);
            this.progressBar.TabIndex = 4;
            // 
            // lStatus
            // 
            this.lStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lStatus.AutoSize = true;
            this.lStatus.Location = new System.Drawing.Point(227, 92);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(42, 15);
            this.lStatus.TabIndex = 5;
            this.lStatus.Text = "lStatus";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Link:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Name:";
            // 
            // tName
            // 
            this.tName.Location = new System.Drawing.Point(53, 12);
            this.tName.Name = "tName";
            this.tName.Size = new System.Drawing.Size(546, 23);
            this.tName.TabIndex = 1;
            // 
            // cOpenFolder
            // 
            this.cOpenFolder.AutoSize = true;
            this.cOpenFolder.Location = new System.Drawing.Point(15, 95);
            this.cOpenFolder.Name = "cOpenFolder";
            this.cOpenFolder.Size = new System.Drawing.Size(91, 19);
            this.cOpenFolder.TabIndex = 4;
            this.cOpenFolder.Text = "Open Folder";
            this.cOpenFolder.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 127);
            this.Controls.Add(this.cOpenFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lStatus);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.cConvert);
            this.Controls.Add(this.tLink);
            this.Controls.Add(this.bDownload);
            this.Name = "Main";
            this.Text = "m3u8 Downloader";
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

