namespace CamraBuildingPermit
{
    partial class PermitForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRecord = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CardNocbox = new System.Windows.Forms.ComboBox();
            this.txtownName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.LocalityLabel = new System.Windows.Forms.Label();
            this.updateBtn = new System.Windows.Forms.Button();
            this.dleteBtn = new System.Windows.Forms.Button();
            this.txtDesc1 = new System.Windows.Forms.TextBox();
            this.txtDesc2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtExplain = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.AddRecbtn = new System.Windows.Forms.Button();
            this.txtIssueDate = new System.Windows.Forms.MaskedTextBox();
            this.txtMapNo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtChgDate = new System.Windows.Forms.MaskedTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtEstCost = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCODate = new System.Windows.Forms.MaskedTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtPermitNo = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.completechkbx = new System.Windows.Forms.CheckBox();
            this.SeqNocbox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(235, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Blue Ridge Mass Appraisal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Locality :";
            // 
            // txtRecord
            // 
            this.txtRecord.Location = new System.Drawing.Point(100, 83);
            this.txtRecord.Name = "txtRecord";
            this.txtRecord.Size = new System.Drawing.Size(100, 20);
            this.txtRecord.TabIndex = 0;
            this.txtRecord.Click += new System.EventHandler(this.txtRecord_Click);
            this.txtRecord.Leave += new System.EventHandler(this.txtRecord_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Record No :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Card No :";
            // 
            // CardNocbox
            // 
            this.CardNocbox.FormattingEnabled = true;
            this.CardNocbox.Location = new System.Drawing.Point(100, 116);
            this.CardNocbox.Name = "CardNocbox";
            this.CardNocbox.Size = new System.Drawing.Size(63, 21);
            this.CardNocbox.TabIndex = 14;
            this.CardNocbox.SelectedIndexChanged += new System.EventHandler(this.CardNocbox_SelectedIndexChanged);
            // 
            // txtownName
            // 
            this.txtownName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtownName.Location = new System.Drawing.Point(272, 79);
            this.txtownName.Name = "txtownName";
            this.txtownName.Size = new System.Drawing.Size(194, 20);
            this.txtownName.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(221, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Owner :";
            // 
            // txtAddress
            // 
            this.txtAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAddress.Location = new System.Drawing.Point(272, 112);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(194, 20);
            this.txtAddress.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(214, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Address :";
            // 
            // LocalityLabel
            // 
            this.LocalityLabel.AutoSize = true;
            this.LocalityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LocalityLabel.Location = new System.Drawing.Point(100, 46);
            this.LocalityLabel.Name = "LocalityLabel";
            this.LocalityLabel.Size = new System.Drawing.Size(100, 17);
            this.LocalityLabel.TabIndex = 13;
            this.LocalityLabel.Text = "localityName";
            // 
            // updateBtn
            // 
            this.updateBtn.BackColor = System.Drawing.Color.Yellow;
            this.updateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateBtn.Location = new System.Drawing.Point(629, 32);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(75, 31);
            this.updateBtn.TabIndex = 14;
            this.updateBtn.Text = "Up Date";
            this.updateBtn.UseVisualStyleBackColor = false;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // dleteBtn
            // 
            this.dleteBtn.BackColor = System.Drawing.Color.Red;
            this.dleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dleteBtn.ForeColor = System.Drawing.Color.White;
            this.dleteBtn.Location = new System.Drawing.Point(629, 71);
            this.dleteBtn.Name = "dleteBtn";
            this.dleteBtn.Size = new System.Drawing.Size(75, 31);
            this.dleteBtn.TabIndex = 15;
            this.dleteBtn.Text = "Delete ";
            this.dleteBtn.UseVisualStyleBackColor = false;
            this.dleteBtn.Click += new System.EventHandler(this.dleteBtn_Click);
            // 
            // txtDesc1
            // 
            this.txtDesc1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDesc1.Location = new System.Drawing.Point(100, 334);
            this.txtDesc1.Name = "txtDesc1";
            this.txtDesc1.Size = new System.Drawing.Size(373, 20);
            this.txtDesc1.TabIndex = 7;
            this.txtDesc1.Leave += new System.EventHandler(this.txtDesc1_Leave);
            // 
            // txtDesc2
            // 
            this.txtDesc2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDesc2.Location = new System.Drawing.Point(100, 365);
            this.txtDesc2.Name = "txtDesc2";
            this.txtDesc2.Size = new System.Drawing.Size(373, 20);
            this.txtDesc2.TabIndex = 8;
            this.txtDesc2.Leave += new System.EventHandler(this.txtDesc2_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 334);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Description 1 :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 366);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Description 2  :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 154);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Sequence No :";
            // 
            // txtExplain
            // 
            this.txtExplain.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtExplain.Location = new System.Drawing.Point(103, 400);
            this.txtExplain.Name = "txtExplain";
            this.txtExplain.Size = new System.Drawing.Size(373, 20);
            this.txtExplain.TabIndex = 9;
            this.txtExplain.Leave += new System.EventHandler(this.txtExplain_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 403);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Explanation :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(195, 190);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Date Issued :";
            // 
            // AddRecbtn
            // 
            this.AddRecbtn.BackColor = System.Drawing.Color.Cyan;
            this.AddRecbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddRecbtn.Location = new System.Drawing.Point(629, 113);
            this.AddRecbtn.Name = "AddRecbtn";
            this.AddRecbtn.Size = new System.Drawing.Size(75, 38);
            this.AddRecbtn.TabIndex = 26;
            this.AddRecbtn.Text = "Add Record";
            this.AddRecbtn.UseVisualStyleBackColor = false;
            this.AddRecbtn.Click += new System.EventHandler(this.AddRecbtn_Click);
            // 
            // txtIssueDate
            // 
            this.txtIssueDate.Location = new System.Drawing.Point(272, 188);
            this.txtIssueDate.Mask = "00/00/0000";
            this.txtIssueDate.Name = "txtIssueDate";
            this.txtIssueDate.Size = new System.Drawing.Size(100, 20);
            this.txtIssueDate.TabIndex = 1;
            this.txtIssueDate.ValidatingType = typeof(System.DateTime);
            this.txtIssueDate.Leave += new System.EventHandler(this.txtIssueDate_Leave);
            // 
            // txtMapNo
            // 
            this.txtMapNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMapNo.Location = new System.Drawing.Point(272, 147);
            this.txtMapNo.Name = "txtMapNo";
            this.txtMapNo.Size = new System.Drawing.Size(194, 20);
            this.txtMapNo.TabIndex = 18;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(211, 150);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "Map No. :";
            // 
            // txtChgDate
            // 
            this.txtChgDate.Location = new System.Drawing.Point(272, 224);
            this.txtChgDate.Mask = "00/00/0000";
            this.txtChgDate.Name = "txtChgDate";
            this.txtChgDate.Size = new System.Drawing.Size(100, 20);
            this.txtChgDate.TabIndex = 2;
            this.txtChgDate.ValidatingType = typeof(System.DateTime);
            this.txtChgDate.Leave += new System.EventHandler(this.txtChgDate_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(183, 227);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 13);
            this.label13.TabIndex = 31;
            this.label13.Text = "Date Changed :";
            // 
            // txtEstCost
            // 
            this.txtEstCost.Location = new System.Drawing.Point(472, 226);
            this.txtEstCost.Name = "txtEstCost";
            this.txtEstCost.Size = new System.Drawing.Size(100, 20);
            this.txtEstCost.TabIndex = 5;
            this.txtEstCost.Leave += new System.EventHandler(this.txtEstCost_Leave);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(384, 229);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 13);
            this.label14.TabIndex = 11;
            this.label14.Text = "Estimated Cost :";
            // 
            // txtCODate
            // 
            this.txtCODate.Location = new System.Drawing.Point(272, 261);
            this.txtCODate.Mask = "00/00/0000";
            this.txtCODate.Name = "txtCODate";
            this.txtCODate.Size = new System.Drawing.Size(100, 20);
            this.txtCODate.TabIndex = 3;
            this.txtCODate.ValidatingType = typeof(System.DateTime);
            this.txtCODate.Leave += new System.EventHandler(this.txtCODate_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(183, 264);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(81, 13);
            this.label15.TabIndex = 33;
            this.label15.Text = "Cert Occ Date :";
            // 
            // txtPermitNo
            // 
            this.txtPermitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPermitNo.Location = new System.Drawing.Point(472, 188);
            this.txtPermitNo.Name = "txtPermitNo";
            this.txtPermitNo.Size = new System.Drawing.Size(100, 20);
            this.txtPermitNo.TabIndex = 4;
            this.txtPermitNo.Leave += new System.EventHandler(this.txtPermitNo_Leave);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(388, 191);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(74, 13);
            this.label16.TabIndex = 35;
            this.label16.Text = "Permit No  :";
            // 
            // completechkbx
            // 
            this.completechkbx.AutoSize = true;
            this.completechkbx.Location = new System.Drawing.Point(472, 263);
            this.completechkbx.Name = "completechkbx";
            this.completechkbx.Size = new System.Drawing.Size(76, 17);
            this.completechkbx.TabIndex = 6;
            this.completechkbx.Text = "Completed";
            this.completechkbx.UseVisualStyleBackColor = true;
            // 
            // SeqNocbox
            // 
            this.SeqNocbox.FormattingEnabled = true;
            this.SeqNocbox.Location = new System.Drawing.Point(103, 154);
            this.SeqNocbox.Name = "SeqNocbox";
            this.SeqNocbox.Size = new System.Drawing.Size(60, 21);
            this.SeqNocbox.TabIndex = 36;
            this.SeqNocbox.SelectedIndexChanged += new System.EventHandler(this.SeqNocbox_SelectedIndexChanged);
            // 
            // PermitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(753, 465);
            this.Controls.Add(this.SeqNocbox);
            this.Controls.Add(this.completechkbx);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtPermitNo);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtCODate);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtEstCost);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtChgDate);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtMapNo);
            this.Controls.Add(this.txtIssueDate);
            this.Controls.Add(this.AddRecbtn);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtExplain);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDesc2);
            this.Controls.Add(this.txtDesc1);
            this.Controls.Add(this.dleteBtn);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.LocalityLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtownName);
            this.Controls.Add(this.CardNocbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRecord);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PermitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Building Permit Data";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRecord;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CardNocbox;
        private System.Windows.Forms.TextBox txtownName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LocalityLabel;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Button dleteBtn;
        private System.Windows.Forms.TextBox txtDesc1;
        private System.Windows.Forms.TextBox txtDesc2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtExplain;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button AddRecbtn;
        private System.Windows.Forms.MaskedTextBox txtIssueDate;
        private System.Windows.Forms.TextBox txtMapNo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox txtChgDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtEstCost;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.MaskedTextBox txtCODate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtPermitNo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox completechkbx;
        private System.Windows.Forms.ComboBox SeqNocbox;
    }
}