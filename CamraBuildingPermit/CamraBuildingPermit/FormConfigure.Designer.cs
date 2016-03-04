namespace CamraBuildingPermit
{
    partial class FormConfigure
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
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.txtIPAddress = new System.Windows.Forms.TextBox();
			this.BrowseForPictureFolderLink = new System.Windows.Forms.LinkLabel();
			this.txtPicturePath = new System.Windows.Forms.TextBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 44);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "IP Address:";
			// 
			// folderBrowserDialog1
			// 
			this.folderBrowserDialog1.SelectedPath = "C:\\Users\\dave\\Desktop";
			// 
			// txtIPAddress
			// 
			this.txtIPAddress.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::CamraBuildingPermit.Properties.Settings.Default, "IPAddress", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.txtIPAddress.Location = new System.Drawing.Point(143, 41);
			this.txtIPAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtIPAddress.Name = "txtIPAddress";
			this.txtIPAddress.Size = new System.Drawing.Size(196, 22);
			this.txtIPAddress.TabIndex = 1;
			this.txtIPAddress.Text = global::CamraBuildingPermit.Properties.Settings.Default.IPAddress;
			// 
			// BrowseForPictureFolderLink
			// 
			this.BrowseForPictureFolderLink.AutoSize = true;
			this.BrowseForPictureFolderLink.Location = new System.Drawing.Point(16, 76);
			this.BrowseForPictureFolderLink.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.BrowseForPictureFolderLink.Name = "BrowseForPictureFolderLink";
			this.BrowseForPictureFolderLink.Size = new System.Drawing.Size(114, 17);
			this.BrowseForPictureFolderLink.TabIndex = 2;
			this.BrowseForPictureFolderLink.TabStop = true;
			this.BrowseForPictureFolderLink.Text = "Picture Location:";
			this.BrowseForPictureFolderLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// txtPicturePath
			// 
			this.txtPicturePath.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::CamraBuildingPermit.Properties.Settings.Default, "PicturePath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.txtPicturePath.Location = new System.Drawing.Point(143, 73);
			this.txtPicturePath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtPicturePath.Name = "txtPicturePath";
			this.txtPicturePath.ReadOnly = true;
			this.txtPicturePath.Size = new System.Drawing.Size(196, 22);
			this.txtPicturePath.TabIndex = 3;
			this.txtPicturePath.Text = global::CamraBuildingPermit.Properties.Settings.Default.PicturePath;
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Location = new System.Drawing.Point(179, 134);
			this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(77, 30);
			this.btnSave.TabIndex = 4;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(264, 134);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(77, 30);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// FormConfigure
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Silver;
			this.ClientSize = new System.Drawing.Size(356, 178);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.txtPicturePath);
			this.Controls.Add(this.BrowseForPictureFolderLink);
			this.Controls.Add(this.txtIPAddress);
			this.Controls.Add(this.label1);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "FormConfigure";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Configuration";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.LinkLabel BrowseForPictureFolderLink;
        private System.Windows.Forms.TextBox txtPicturePath;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}