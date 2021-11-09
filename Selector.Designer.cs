
namespace m3u8_Downloader {
    partial class Selector {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.cM3U8 = new System.Windows.Forms.ComboBox();
            this.bSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cM3U8
            // 
            this.cM3U8.FormattingEnabled = true;
            this.cM3U8.Location = new System.Drawing.Point(12, 12);
            this.cM3U8.Name = "cM3U8";
            this.cM3U8.Size = new System.Drawing.Size(376, 23);
            this.cM3U8.TabIndex = 0;
            // 
            // bSelect
            // 
            this.bSelect.Location = new System.Drawing.Point(313, 41);
            this.bSelect.Name = "bSelect";
            this.bSelect.Size = new System.Drawing.Size(75, 23);
            this.bSelect.TabIndex = 1;
            this.bSelect.Text = "Select";
            this.bSelect.UseVisualStyleBackColor = true;
            this.bSelect.Click += new System.EventHandler(this.bSelect_Click);
            // 
            // Selector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 73);
            this.Controls.Add(this.bSelect);
            this.Controls.Add(this.cM3U8);
            this.Name = "Selector";
            this.Text = "m3u8 Selector";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cM3U8;
        private System.Windows.Forms.Button bSelect;
    }
}