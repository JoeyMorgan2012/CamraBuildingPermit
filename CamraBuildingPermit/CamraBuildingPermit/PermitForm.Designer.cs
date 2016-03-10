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
			this.components = new System.ComponentModel.Container();
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
			this.permitFormMenu = new System.Windows.Forms.MenuStrip();
			this.PermitFormContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.PermitFormStatusStrip = new System.Windows.Forms.StatusStrip();
			this.localityStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.currentParcelLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.PermitFormStatusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(313, 12);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(363, 31);
			this.label1.TabIndex = 1;
			this.label1.Text = "Blue Ridge Mass Appraisal";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(56, 57);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 17);
			this.label2.TabIndex = 2;
			this.label2.Text = "Locality :";
			// 
			// txtRecord
			// 
			this.txtRecord.Location = new System.Drawing.Point(133, 102);
			this.txtRecord.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtRecord.Name = "txtRecord";
			this.txtRecord.Size = new System.Drawing.Size(132, 22);
			this.txtRecord.TabIndex = 7;
			this.txtRecord.Click += new System.EventHandler(this.txtRecord_Click);
			this.txtRecord.Leave += new System.EventHandler(this.txtRecord_Leave);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(35, 105);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(84, 17);
			this.label3.TabIndex = 6;
			this.label3.Text = "Record No :";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(52, 144);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(68, 17);
			this.label4.TabIndex = 11;
			this.label4.Text = "Card No :";
			// 
			// CardNocbox
			// 
			this.CardNocbox.FormattingEnabled = true;
			this.CardNocbox.Location = new System.Drawing.Point(133, 143);
			this.CardNocbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.CardNocbox.Name = "CardNocbox";
			this.CardNocbox.Size = new System.Drawing.Size(83, 24);
			this.CardNocbox.TabIndex = 12;
			this.CardNocbox.SelectedIndexChanged += new System.EventHandler(this.CardNocbox_SelectedIndexChanged);
			// 
			// txtownName
			// 
			this.txtownName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtownName.Location = new System.Drawing.Point(363, 97);
			this.txtownName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtownName.Name = "txtownName";
			this.txtownName.Size = new System.Drawing.Size(257, 22);
			this.txtownName.TabIndex = 5;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(295, 103);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(57, 17);
			this.label5.TabIndex = 8;
			this.label5.Text = "Owner :";
			// 
			// txtAddress
			// 
			this.txtAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtAddress.Location = new System.Drawing.Point(363, 138);
			this.txtAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtAddress.Name = "txtAddress";
			this.txtAddress.Size = new System.Drawing.Size(257, 22);
			this.txtAddress.TabIndex = 10;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(285, 144);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(68, 17);
			this.label6.TabIndex = 13;
			this.label6.Text = "Address :";
			// 
			// LocalityLabel
			// 
			this.LocalityLabel.AutoSize = true;
			this.LocalityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LocalityLabel.Location = new System.Drawing.Point(133, 57);
			this.LocalityLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.LocalityLabel.Name = "LocalityLabel";
			this.LocalityLabel.Size = new System.Drawing.Size(117, 20);
			this.LocalityLabel.TabIndex = 3;
			this.LocalityLabel.Text = "localityName";
			// 
			// updateBtn
			// 
			this.updateBtn.BackColor = System.Drawing.Color.Yellow;
			this.updateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.updateBtn.Location = new System.Drawing.Point(839, 39);
			this.updateBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.updateBtn.Name = "updateBtn";
			this.updateBtn.Size = new System.Drawing.Size(100, 38);
			this.updateBtn.TabIndex = 4;
			this.updateBtn.Text = "Up Date";
			this.updateBtn.UseVisualStyleBackColor = false;
			this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
			// 
			// dleteBtn
			// 
			this.dleteBtn.BackColor = System.Drawing.Color.Red;
			this.dleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dleteBtn.ForeColor = System.Drawing.Color.White;
			this.dleteBtn.Location = new System.Drawing.Point(839, 87);
			this.dleteBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.dleteBtn.Name = "dleteBtn";
			this.dleteBtn.Size = new System.Drawing.Size(100, 38);
			this.dleteBtn.TabIndex = 9;
			this.dleteBtn.Text = "Delete ";
			this.dleteBtn.UseVisualStyleBackColor = false;
			this.dleteBtn.Click += new System.EventHandler(this.dleteBtn_Click);
			// 
			// txtDesc1
			// 
			this.txtDesc1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtDesc1.Location = new System.Drawing.Point(133, 411);
			this.txtDesc1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtDesc1.Name = "txtDesc1";
			this.txtDesc1.Size = new System.Drawing.Size(496, 22);
			this.txtDesc1.TabIndex = 31;
			this.txtDesc1.Leave += new System.EventHandler(this.txtDesc1_Leave);
			// 
			// txtDesc2
			// 
			this.txtDesc2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtDesc2.Location = new System.Drawing.Point(133, 449);
			this.txtDesc2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtDesc2.Name = "txtDesc2";
			this.txtDesc2.Size = new System.Drawing.Size(496, 22);
			this.txtDesc2.TabIndex = 33;
			this.txtDesc2.Leave += new System.EventHandler(this.txtDesc2_Leave);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(21, 411);
			this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(99, 17);
			this.label7.TabIndex = 30;
			this.label7.Text = "Description 1 :";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(17, 450);
			this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(103, 17);
			this.label8.TabIndex = 32;
			this.label8.Text = "Description 2  :";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(16, 190);
			this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(102, 17);
			this.label9.TabIndex = 17;
			this.label9.Text = "Sequence No :";
			// 
			// txtExplain
			// 
			this.txtExplain.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtExplain.Location = new System.Drawing.Point(137, 492);
			this.txtExplain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtExplain.Name = "txtExplain";
			this.txtExplain.Size = new System.Drawing.Size(496, 22);
			this.txtExplain.TabIndex = 35;
			this.txtExplain.Leave += new System.EventHandler(this.txtExplain_Leave);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(31, 496);
			this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(89, 17);
			this.label10.TabIndex = 34;
			this.label10.Text = "Explanation :";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(260, 234);
			this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(91, 17);
			this.label11.TabIndex = 19;
			this.label11.Text = "Date Issued :";
			// 
			// AddRecbtn
			// 
			this.AddRecbtn.BackColor = System.Drawing.Color.Cyan;
			this.AddRecbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AddRecbtn.Location = new System.Drawing.Point(839, 139);
			this.AddRecbtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.AddRecbtn.Name = "AddRecbtn";
			this.AddRecbtn.Size = new System.Drawing.Size(100, 47);
			this.AddRecbtn.TabIndex = 14;
			this.AddRecbtn.Text = "Add Record";
			this.AddRecbtn.UseVisualStyleBackColor = false;
			this.AddRecbtn.Click += new System.EventHandler(this.AddRecbtn_Click);
			// 
			// txtIssueDate
			// 
			this.txtIssueDate.Location = new System.Drawing.Point(363, 231);
			this.txtIssueDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtIssueDate.Mask = "00/00/0000";
			this.txtIssueDate.Name = "txtIssueDate";
			this.txtIssueDate.Size = new System.Drawing.Size(132, 22);
			this.txtIssueDate.TabIndex = 20;
			this.txtIssueDate.ValidatingType = typeof(System.DateTime);
			this.txtIssueDate.Leave += new System.EventHandler(this.txtIssueDate_Leave);
			// 
			// txtMapNo
			// 
			this.txtMapNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMapNo.Location = new System.Drawing.Point(363, 181);
			this.txtMapNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtMapNo.Name = "txtMapNo";
			this.txtMapNo.Size = new System.Drawing.Size(257, 22);
			this.txtMapNo.TabIndex = 16;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(281, 185);
			this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(69, 17);
			this.label12.TabIndex = 15;
			this.label12.Text = "Map No. :";
			// 
			// txtChgDate
			// 
			this.txtChgDate.Location = new System.Drawing.Point(363, 276);
			this.txtChgDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtChgDate.Mask = "00/00/0000";
			this.txtChgDate.Name = "txtChgDate";
			this.txtChgDate.Size = new System.Drawing.Size(132, 22);
			this.txtChgDate.TabIndex = 24;
			this.txtChgDate.ValidatingType = typeof(System.DateTime);
			this.txtChgDate.Leave += new System.EventHandler(this.txtChgDate_Leave);
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(244, 279);
			this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(107, 17);
			this.label13.TabIndex = 23;
			this.label13.Text = "Date Changed :";
			// 
			// txtEstCost
			// 
			this.txtEstCost.Location = new System.Drawing.Point(629, 278);
			this.txtEstCost.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtEstCost.Name = "txtEstCost";
			this.txtEstCost.Size = new System.Drawing.Size(132, 22);
			this.txtEstCost.TabIndex = 26;
			this.txtEstCost.Leave += new System.EventHandler(this.txtEstCost_Leave);
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(512, 282);
			this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(110, 17);
			this.label14.TabIndex = 25;
			this.label14.Text = "Estimated Cost :";
			// 
			// txtCODate
			// 
			this.txtCODate.Location = new System.Drawing.Point(363, 321);
			this.txtCODate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtCODate.Mask = "00/00/0000";
			this.txtCODate.Name = "txtCODate";
			this.txtCODate.Size = new System.Drawing.Size(132, 22);
			this.txtCODate.TabIndex = 28;
			this.txtCODate.ValidatingType = typeof(System.DateTime);
			this.txtCODate.Leave += new System.EventHandler(this.txtCODate_Leave);
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(244, 325);
			this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(105, 17);
			this.label15.TabIndex = 27;
			this.label15.Text = "Cert Occ Date :";
			// 
			// txtPermitNo
			// 
			this.txtPermitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtPermitNo.Location = new System.Drawing.Point(629, 231);
			this.txtPermitNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtPermitNo.Name = "txtPermitNo";
			this.txtPermitNo.Size = new System.Drawing.Size(132, 22);
			this.txtPermitNo.TabIndex = 22;
			this.txtPermitNo.Leave += new System.EventHandler(this.txtPermitNo_Leave);
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label16.Location = new System.Drawing.Point(517, 235);
			this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(94, 17);
			this.label16.TabIndex = 21;
			this.label16.Text = "Permit No  :";
			// 
			// completechkbx
			// 
			this.completechkbx.AutoSize = true;
			this.completechkbx.Location = new System.Drawing.Point(629, 324);
			this.completechkbx.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.completechkbx.Name = "completechkbx";
			this.completechkbx.Size = new System.Drawing.Size(97, 21);
			this.completechkbx.TabIndex = 29;
			this.completechkbx.Text = "Completed";
			this.completechkbx.UseVisualStyleBackColor = true;
			// 
			// SeqNocbox
			// 
			this.SeqNocbox.FormattingEnabled = true;
			this.SeqNocbox.Location = new System.Drawing.Point(137, 190);
			this.SeqNocbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.SeqNocbox.Name = "SeqNocbox";
			this.SeqNocbox.Size = new System.Drawing.Size(79, 24);
			this.SeqNocbox.TabIndex = 18;
			this.SeqNocbox.SelectedIndexChanged += new System.EventHandler(this.SeqNocbox_SelectedIndexChanged);
			// 
			// permitFormMenu
			// 
			this.permitFormMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.permitFormMenu.Location = new System.Drawing.Point(0, 0);
			this.permitFormMenu.Name = "permitFormMenu";
			this.permitFormMenu.Size = new System.Drawing.Size(1004, 24);
			this.permitFormMenu.TabIndex = 0;
			this.permitFormMenu.Text = "menuStrip1";
			// 
			// PermitFormContextMenu
			// 
			this.PermitFormContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.PermitFormContextMenu.Name = "PermitFormContextMenu";
			this.PermitFormContextMenu.Size = new System.Drawing.Size(182, 32);
			// 
			// PermitFormStatusStrip
			// 
			this.PermitFormStatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.PermitFormStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localityStatusLabel,
            this.currentParcelLabel});
			this.PermitFormStatusStrip.Location = new System.Drawing.Point(0, 547);
			this.PermitFormStatusStrip.Name = "PermitFormStatusStrip";
			this.PermitFormStatusStrip.Size = new System.Drawing.Size(1004, 25);
			this.PermitFormStatusStrip.TabIndex = 36;
			this.PermitFormStatusStrip.Text = "statusStrip1";
			// 
			// localityStatusLabel
			// 
			this.localityStatusLabel.Name = "localityStatusLabel";
			this.localityStatusLabel.Size = new System.Drawing.Size(36, 20);
			this.localityStatusLabel.Text = global::CamraBuildingPermit.Properties.Settings.Default.Locality;
			this.localityStatusLabel.ToolTipText = "Selected Locality Prefix";
			// 
			// currentParcelLabel
			// 
			this.currentParcelLabel.Name = "currentParcelLabel";
			this.currentParcelLabel.Size = new System.Drawing.Size(0, 20);
			// 
			// PermitForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.ClientSize = new System.Drawing.Size(1004, 572);
			this.Controls.Add(this.PermitFormStatusStrip);
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
			this.Controls.Add(this.permitFormMenu);
			this.MainMenuStrip = this.permitFormMenu;
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "PermitForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Building Permit Data";
			this.PermitFormStatusStrip.ResumeLayout(false);
			this.PermitFormStatusStrip.PerformLayout();
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
		private System.Windows.Forms.MenuStrip permitFormMenu;
		private System.Windows.Forms.ContextMenuStrip PermitFormContextMenu;
		private System.Windows.Forms.StatusStrip PermitFormStatusStrip;
		private System.Windows.Forms.ToolStripStatusLabel localityStatusLabel;
		private System.Windows.Forms.ToolStripStatusLabel currentParcelLabel;
	}
}