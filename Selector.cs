using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace m3u8_Downloader {
    public partial class Selector : Form {
        public string SelectedItem = "";

        public Selector() {
            InitializeComponent();
        }

        public void SetList(List<M3U8> mList) {
            cM3U8.Items.Clear();

            if (!string.IsNullOrEmpty(mList[0].Name))
                cM3U8.DisplayMember = "Name";
            else if (!string.IsNullOrEmpty(mList[0].Resolution))
                cM3U8.DisplayMember = "Resolution";
            else
                cM3U8.DisplayMember = "Bandwidth";

            cM3U8.ValueMember = "Url";
            cM3U8.Items.AddRange(mList.ToArray());
        }

        private void bSelect_Click(object sender, EventArgs e) {
            SelectedItem = ((M3U8)cM3U8.SelectedItem).Url;
            this.Close();
        }
    }
}
