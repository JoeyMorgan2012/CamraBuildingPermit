using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SWallTech;
using System.Data;


namespace CamraBuildingPermit
{
    public partial class MainForm : Form
    {
        DBAccessManager _db = null;
        CAMRA_Connection _conn = null;

        public static string FCLib = String.Empty;
        public static string FCLoc = String.Empty;
        public static string FCLocName = String.Empty;

        public MainForm()
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(Properties.Settings.Default.IPAddress))
            //if (!"".Equals(Properties.Settings.Default.IPAddress))
            {
                ConnectToCamra();
            }
            else
            {
                FormConfigure config = new FormConfigure();
                config.ShowDialog(this);
            }

            txtPictureDrive.Text = Properties.Settings.Default.PicturePath;

            txtIPAddress.Text = Properties.Settings.Default.IPAddress;
        }

        public void UpdateStatus(string status)
        {
            statusMessage.Text = status;
        }

        private void ConnectToCamra()
        {
            cboxLocs.Items.Clear();

            string ipsxx = Properties.Settings.Default.IPAddress.ToString();

            _conn = new CAMRA_Connection()
            {
                DataSource = Properties.Settings.Default.IPAddress,

                User = "camra2",
                Password = "camra2"
            };

            if (_conn.DBConnection == null)
            {
                string jlwe = "L";
            }


            _db = _conn.DBConnection;

            if (_db == null)
            {
                string hhewl = "L";
            }


            if (_conn.Localities != null)
            {
                string listString = "< Locality Listing >";
                int cntx = _conn.Localities.GetListByName.Keys.Count;
                if(cntx > 0)
                {
                    cboxLocs.Items.Add(listString);
                }

                foreach (var loc in _conn.Localities.GetListByName.Keys)
                {
                    cboxLocs.Items.Add(loc);
                }

            }

            cboxLocs.SelectedIndex = 0;


            if (_db.IsConnected)
            {
                UpdateStatus(string.Format("Successfully Opened Connection to {0}", _conn.DataSource));

            }
            else
            {
                UpdateStatus(String.Format("Failed to Open Connection to {0}", _conn.DataSource));

            }

            string jewel = "L";

            string t1 = FCLib;
            string t2 = FCLoc;

            

        }

        private string GetLocalityPrefix()
        {

            string prefix = String.Empty;
            if (cboxLocs.SelectedIndex >= 0)
            {
                prefix = _conn.Localities.GetLocalityPrefix(cboxLocs.Items[cboxLocs.SelectedIndex].ToString());
                
            }
            _conn.LocalityPrefix = prefix;

            FCLocName = cboxLocs.SelectedItem.ToString();

            FCLoc = prefix;
            FCLib = _conn.Library.ToString();
            txtLibrary.Text = FCLib;
            txtLocPrefix.Text = FCLoc;
            return prefix;
        }

        private void cboxLocs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxLocs.SelectedIndex > 0)
            {
                GetLocalityPrefix();

            }
        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            FormConfigure config = new FormConfigure();
            config.ShowDialog(this);

            if (_db.IsConnected)
            {
                UpdateStatus(string.Format("Successfully Opened Connection to {0}", _conn.DataSource));

            }
            else
            {
                UpdateStatus(String.Format("Failed to Open Connection to {0}", _conn.DataSource));

            }


            txtPictureDrive.Text = Properties.Settings.Default.PicturePath;

            txtIPAddress.Text = Properties.Settings.Default.IPAddress;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PermitForm addper = new PermitForm(_conn,_db);
            addper.ShowDialog(this);
        }
    }
}
