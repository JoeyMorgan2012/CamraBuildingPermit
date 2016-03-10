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
    public partial class PermitForm : Form
    {
        CAMRA_Connection _conn = null;
        DBAccessManager _db = null;

        public int record = 0;
        public int card = 0;
        public int bpcnt = 0;
        public string Owner = String.Empty;
        public string Address = String.Empty;
        public string mapno = String.Empty;

        public bool hasMaster = false;
        public bool hasAddedSeq = false;

        public int Bpcounter = 0;
       
       
        public string desc1 = String.Empty;
        public string desc2 = String.Empty;
        public string explain = String.Empty;
        public int estcost = 0;
        public string issueDate = String.Empty;
        public string changeDate = String.Empty;
        public string COdate = String.Empty;
        public string PermitNo = String.Empty;
        public int local_id = 0;
        public string county_id = String.Empty;
        public string completed = String.Empty;
        public int seqno = 0;
        public int seqcnt = 0;
        
        public PermitForm(CAMRA_Connection conn,DBAccessManager db)
        {
            InitializeComponent();

            _conn = conn;
            _db = db;
            LocalityLabel.Text = MainForm.FCLocName;

            CheckFile();
            RefreshForm();

        }

        public void RefreshForm()
        {
            record = 0;
            card = 0;
            bpcnt = 0;
            Owner = String.Empty;
            Address = String.Empty;
            mapno = String.Empty;

            hasMaster = false;
            hasAddedSeq = false;
            Bpcounter = 0;
            


            desc1 = String.Empty;
            desc2 = String.Empty;
            explain = String.Empty;
            estcost = 0;
            issueDate = String.Empty;
            changeDate = String.Empty;
            COdate = String.Empty;
            PermitNo = String.Empty;
            local_id = 0;
            county_id = String.Empty;
            completed = String.Empty;
            seqno = 0;
            seqcnt = 0;

            SeqNocbox.Items.Clear();
            SeqNocbox.SelectedIndex = -1;
            CardNocbox.Items.Clear();
            CardNocbox.SelectedIndex = -1;


            txtownName.Text = Owner.Trim();
            txtAddress.Text = Address.Trim();
            txtMapNo.Text = mapno.Trim();
            txtRecord.Text = String.Empty;
            txtIssueDate.Text = String.Empty;
            txtChgDate.Text = String.Empty;
            txtCODate.Text = String.Empty;
            completechkbx.Checked = false;
            txtDesc1.Text = String.Empty;
            txtDesc2.Text = String.Empty;
            txtEstCost.Text = String.Empty;
            txtExplain.Text = String.Empty;
            txtPermitNo.Text = String.Empty;

        }

        public void CheckFile()
        {
            StringBuilder cntper = new StringBuilder();
            cntper.Append(String.Format("select count(*) from {0}.{1}bpermit ", MainForm.FCLib, MainForm.FCLoc));

            try
            {
                Bpcounter = (int)_db.ExecuteScalar(cntper.ToString());
            }
            catch
            {
                MessageBox.Show("Permit File does not Exist - Create ? ");

                StringBuilder bldfile = new StringBuilder();
                bldfile.Append(String.Format("create table {0}.{1}bpermit ", MainForm.FCLib, MainForm.FCLoc));
                bldfile.Append("(issuedate char(10) not null default ' ',localid numeric(10,0) not null default 0, ");
                bldfile.Append("permit_no char(10) not null default ' ',mapno char(20) not null default ' ',seqno numeric(2,0) not null default 0,");
                bldfile.Append("countyid char(30) not null default ' ',owner char(35),hse_no numeric(5,0) not null default 0,");
                bldfile.Append("unit_dir char(10) not null default ' ',address char(35) not null default ' ',estcost numeric(10,2) not null default 0,");
                bldfile.Append("desc1 char(35) not null default ' ',codate char(10) not null default ' ',explain char(35) not null default ' ',");
                bldfile.Append("chgdate char(10) not null default ' ',complete char(1) not null default ' ',dwellno numeric(2,0) not null default 0, ");
                bldfile.Append("desc2 char(35) not null default ' ',recno numeric(7,0) not null default 0, ");
                bldfile.Append("startland numeric(10,0) not null default 0,startbldg numeric(10,0) not null default 0,starttotal numeric(10,0) not null default 0, ");
                bldfile.Append("endland numeric(10,0) not null default 0,endbldg numeric(10,0) not null default 0,endtotal numeric(10,0) not null default 0 )");

                _db.ExecuteNonSelectStatement(bldfile.ToString());

            }
        }
        private void CountCards()
        {
            StringBuilder cntcard = new StringBuilder();
            cntcard.Append(String.Format("select mdwell from {0}.{1}mast where mrecno = {2}  ", MainForm.FCLib, MainForm.FCLoc, record));

            DataSet s2 = _db.RunSelectStatement(cntcard.ToString());

            if(s2.Tables[0].Rows.Count > 0)
            {
                for(int i = 0;i < s2.Tables[0].Rows.Count;i++)
                {
                    if(s2.Tables[0].Rows.Count == 1)
                    {
                        CardNocbox.Items.Add(Convert.ToInt32(s2.Tables[0].Rows[i]["mdwell"].ToString()));
                        card = Convert.ToInt32(s2.Tables[0].Rows[i]["mdwell"].ToString());

                    }
                    if (s2.Tables[0].Rows.Count > 1)
                    {
                        CardNocbox.Items.Add(Convert.ToInt32(s2.Tables[0].Rows[i]["mdwell"].ToString()));

                    }

                }
                CardNocbox.SelectedIndex = 0;

            }

            hasMaster = true;

        }
        private void CountSeq()
        {
            hasAddedSeq = false;
            seqcnt = 0;
            SeqNocbox.Items.Clear();

            StringBuilder cntsq = new StringBuilder();
            cntsq.Append(String.Format("select count(*) from {0}.{1}bpermit where recno = {2} and dwellno = {3} ",
                                MainForm.FCLib, MainForm.FCLoc, record, card));

            seqcnt = (int)_db.ExecuteScalar(cntsq.ToString());

            if(seqcnt < 1)
            {
                SeqNocbox.Items.Add(1);
            }
            if(seqcnt >= 1)
            {
                for(int i = 0;i < seqcnt;i++)
                {
                    SeqNocbox.Items.Add(i + 1);

                }

                hasAddedSeq = true;
            }

           
        }

        private void FindMaster()
        {
            if (hasMaster == false)
            {
                CountCards();
                //CountSeq();
            }
           
            StringBuilder getrec = new StringBuilder();
            getrec.Append("select mlnam, trim(cast(mhse# as char(10)))||' '||trim(mdirct)||' '||trim(mstrt)||' '||trim(msttyp) as subAddr, ");
            getrec.Append("mmap ");
            getrec.Append(String.Format("from {0}.{1}mast where mrecno = {2} and mdwell = {3} ", MainForm.FCLib, MainForm.FCLoc, record,card));

            DataSet s1 = _db.RunSelectStatement(getrec.ToString());

            if(s1.Tables[0].Rows.Count > 0)
            {
                for(int i = 0;i < s1.Tables[0].Rows.Count;i++)
                {
                    Owner = s1.Tables[0].Rows[i]["mlnam"].ToString().Trim();
                    Address = s1.Tables[0].Rows[i]["subAddr"].ToString().Trim();
                    mapno = s1.Tables[0].Rows[i]["mmap"].ToString().Trim();

                }

            }

            if (hasAddedSeq == false)
            {
                bpcnt = SeqNocbox.Items.Count;

                if (Bpcounter > 1)
                {
                    for (int i = 0; i < Bpcounter; i++)
                    {
                        SeqNocbox.Items.Add(i + 1);
                    }

                }

                if (Bpcounter == 0)
                {
                    bpcnt = 1;
                    SeqNocbox.Items.Add(1);
                    SeqNocbox.SelectedIndex = 0;
                }

                int tseq = 0;
                //int.TryParse(txtSeqNo.Text, out tseq);
                int.TryParse(SeqNocbox.SelectedItem.ToString(), out tseq);

                seqno = tseq;
            }

            txtownName.Text = Owner.Trim();
            txtAddress.Text = Address.Trim();
            txtMapNo.Text = mapno.Trim();
           
        }
       

        private void txtRecord_Leave(object sender, EventArgs e)
        {
            int recno = 0;
            int.TryParse(txtRecord.Text, out recno);

            record = recno;

            FindMaster();
            AddRecord();
        }

        private void SeqNocbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            seqno = Convert.ToInt32(SeqNocbox.SelectedItem.ToString());
        }

        private void CardNocbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            card = Convert.ToInt32(CardNocbox.SelectedItem.ToString());
            hasMaster = true;
            FindMaster();
        }
        private void AddRecord()
        {
            if(hasAddedSeq == true)
            {
                seqno = Convert.ToInt32(SeqNocbox.SelectedItem.ToString());
            }
            if(hasAddedSeq == false)
            {
                seqno = 1;
            }

            StringBuilder addrec = new StringBuilder();
            addrec.Append(String.Format("insert into {0}.{1}bpermit ", MainForm.FCLib, MainForm.FCLoc));
            addrec.Append("( recno,dwellno,seqno,owner,address,mapno )");
            addrec.Append(String.Format("values ( {0},{1},{2},'{3}','{4}','{5}' ) ", record, card, seqno, Owner,Address, mapno));

            _db.ExecuteNonSelectStatement(addrec.ToString());
        }
         
        private void UpDateRecord()
        {
            if(completechkbx.Checked == true)
            {
                completed = "Y";
            }

            StringBuilder uprec = new StringBuilder();
            uprec.Append(String.Format("update {0}.{1}bpermit ", MainForm.FCLib, MainForm.FCLoc));
            uprec.Append(String.Format("set permit_no = '{0}',countyid = '{1}',estcost = {2},desc1 = '{3}',issuedate = '{4}', ", PermitNo, county_id, estcost, desc1, issueDate));
            uprec.Append(String.Format("codate = '{0}',explain = '{1}',chgdate = '{2}',complete = '{3}',desc2 = '{4}'  ", COdate, explain, changeDate, completed,desc2));
            uprec.Append(String.Format("where recno = {0} and dwellno = {1} and seqno = {2} ", record, card, seqno));

            _db.ExecuteNonSelectStatement(uprec.ToString());

            
        }
        private void DeleteRecord()
        {
            StringBuilder delrec = new StringBuilder();
            delrec.Append(String.Format("delete from {0}.{1}bpermit ", MainForm.FCLib, MainForm.FCLoc));
            delrec.Append(String.Format("where recno = {0} and dwellno = {1} and seqno = {2} ", record, card, seqno));

            _db.ExecuteNonSelectStatement(delrec.ToString());
        }

        private void AddRecbtn_Click(object sender, EventArgs e)
        {
            AddRecord();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            UpDateRecord();

            RefreshForm();
        }

        private void dleteBtn_Click(object sender, EventArgs e)
        {
            DeleteRecord();

            RefreshForm();
        }

        private void txtEstCost_Leave(object sender, EventArgs e)
        {
            int cost = 0;
            int.TryParse(txtEstCost.Text, out cost);

            estcost = cost;
        }

        private void txtIssueDate_Leave(object sender, EventArgs e)
        {
            issueDate = txtIssueDate.Text.ToString();
           
        }
        private void txtChgDate_Leave(object sender, EventArgs e)
        {
            changeDate = txtChgDate.Text.ToString();
        }
        private void txtCODate_Leave(object sender, EventArgs e)
        {
            COdate = txtCODate.Text.ToString();
        }

        private void txtPermitNo_Leave(object sender, EventArgs e)
        {
            PermitNo = txtPermitNo.Text.ToString();
        }

        private void txtDesc1_Leave(object sender, EventArgs e)
        {
            if(txtDesc1.Text.ToString().Trim().Length > 35)
            {
                MessageBox.Show("String Length too long ");
                txtDesc1.Text = txtDesc1.Text.ToString().Substring(0, 34);
            }
            desc1 = txtDesc1.Text.ToString().Trim();
        }

        private void txtDesc2_Leave(object sender, EventArgs e)
        {
            if (txtDesc2.Text.ToString().Trim().Length > 35)
            {
                MessageBox.Show("String Length too long ");
                txtDesc2.Text = txtDesc2.Text.ToString().Substring(0, 34);
            }

            desc2 = txtDesc2.Text.ToString().Trim();
        }

        private void txtExplain_Leave(object sender, EventArgs e)
        {

            if (txtExplain.Text.ToString().Trim().Length > 35)
            {
                MessageBox.Show("String Length too long ");
                txtExplain.Text = txtExplain.Text.ToString().Substring(0, 34);
            }
            explain = txtExplain.Text.ToString().Trim();
        }

        private void txtRecord_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }
	}
}
