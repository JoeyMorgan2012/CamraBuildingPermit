using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CamraBuildingPermit
{
    public partial class FormConfigure : Form
    {
        public FormConfigure()
        {
            InitializeComponent();
        }

        public string IPAddress
        {
            get { return txtIPAddress.Text; }
            set
            {
                txtIPAddress.Text = value;

            }
        }
        public string PicturePath
        {
            get { return txtPicturePath.Text; }
            set
            {
                txtPicturePath.Text = value;
            }
        }

        private void FormConfigure_Load(object sender, EventArgs e)
        {

        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                txtPicturePath.Text = folderBrowserDialog1.SelectedPath;

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            string iptx = txtIPAddress.Text.ToString().Trim();

            string pictxt = txtPicturePath.Text.ToString().Trim();

            Properties.Settings.Default.IPAddress = iptx;

            Properties.Settings.Default.PicturePath = pictxt;

            Properties.Settings.Default.Save();

            this.DialogResult = DialogResult.OK;
            this.Close();


        }

       
    }
}
