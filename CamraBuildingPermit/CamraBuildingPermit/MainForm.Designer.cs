namespace CamraBuildingPermit
{
    partial class MainForm
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
			this.label7 = new System.Windows.Forms.Label();
			this.cboxLocs = new System.Windows.Forms.ComboBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.statusMessage = new System.Windows.Forms.ToolStripStatusLabel();
			this.mainFormContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.configureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtLocPrefix = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtLibrary = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtPictureDrive = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtIPAddress = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.configTipLabel = new System.Windows.Forms.Label();
			this.statusStrip1.SuspendLayout();
			this.mainFormContextMenu.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(215, 31);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(363, 31);
			this.label1.TabIndex = 1;
			this.label1.Text = "Blue Ridge Mass Appraisal";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(233, 80);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(344, 29);
			this.label2.TabIndex = 2;
			this.label2.Text = "Building Permit Admistration";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(71, 138);
			this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(67, 17);
			this.label7.TabIndex = 13;
			this.label7.Text = "Localities";
			// 
			// cboxLocs
			// 
			this.cboxLocs.FormattingEnabled = true;
			this.cboxLocs.Location = new System.Drawing.Point(161, 134);
			this.cboxLocs.Margin = new System.Windows.Forms.Padding(4);
			this.cboxLocs.Name = "cboxLocs";
			this.cboxLocs.Size = new System.Drawing.Size(205, 24);
			this.cboxLocs.TabIndex = 14;
			this.cboxLocs.SelectedIndexChanged += new System.EventHandler(this.cboxLocs_SelectedIndexChanged);
			// 
			// statusStrip1
			// 
			this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusMessage});
			this.statusStrip1.Location = new System.Drawing.Point(0, 502);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
			this.statusStrip1.Size = new System.Drawing.Size(807, 25);
			this.statusStrip1.TabIndex = 19;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// statusMessage
			// 
			this.statusMessage.Name = "statusMessage";
			this.statusMessage.Size = new System.Drawing.Size(13, 20);
			this.statusMessage.Text = " ";
			// 
			// mainFormContextMenu
			// 
			this.mainFormContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.mainFormContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configureToolStripMenuItem});
			this.mainFormContextMenu.Name = "contextMenuStrip1";
			this.mainFormContextMenu.Size = new System.Drawing.Size(144, 28);
			this.mainFormContextMenu.Click += new System.EventHandler(this.contextMenuStrip1_Click);
			// 
			// configureToolStripMenuItem
			// 
			this.configureToolStripMenuItem.Name = "configureToolStripMenuItem";
			this.configureToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
			this.configureToolStripMenuItem.Text = "Configure";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(433, 134);
			this.button1.Margin = new System.Windows.Forms.Padding(4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(100, 28);
			this.button1.TabIndex = 26;
			this.button1.Text = "Add Permits";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.configTipLabel);
			this.groupBox1.Controls.Add(this.txtLocPrefix);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.txtLibrary);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtPictureDrive);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.txtIPAddress);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Location = new System.Drawing.Point(140, 356);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(437, 132);
			this.groupBox1.TabIndex = 27;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Current Configuration";
			// 
			// txtLocPrefix
			// 
			this.txtLocPrefix.Location = new System.Drawing.Point(230, 57);
			this.txtLocPrefix.Margin = new System.Windows.Forms.Padding(4);
			this.txtLocPrefix.Name = "txtLocPrefix";
			this.txtLocPrefix.Size = new System.Drawing.Size(132, 22);
			this.txtLocPrefix.TabIndex = 31;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(119, 56);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(103, 17);
			this.label4.TabIndex = 30;
			this.label4.Text = "Locality Prefix :";
			// 
			// txtLibrary
			// 
			this.txtLibrary.Location = new System.Drawing.Point(230, 22);
			this.txtLibrary.Margin = new System.Windows.Forms.Padding(4);
			this.txtLibrary.Name = "txtLibrary";
			this.txtLibrary.Size = new System.Drawing.Size(132, 22);
			this.txtLibrary.TabIndex = 29;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(162, 25);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(60, 17);
			this.label3.TabIndex = 28;
			this.label3.Text = "Library :";
			// 
			// txtPictureDrive
			// 
			this.txtPictureDrive.Location = new System.Drawing.Point(-60, 52);
			this.txtPictureDrive.Margin = new System.Windows.Forms.Padding(4);
			this.txtPictureDrive.Name = "txtPictureDrive";
			this.txtPictureDrive.Size = new System.Drawing.Size(132, 22);
			this.txtPictureDrive.TabIndex = 27;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(-161, 52);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(93, 17);
			this.label6.TabIndex = 26;
			this.label6.Text = "Picture Path :";
			// 
			// txtIPAddress
			// 
			this.txtIPAddress.Location = new System.Drawing.Point(-60, 22);
			this.txtIPAddress.Margin = new System.Windows.Forms.Padding(4);
			this.txtIPAddress.Name = "txtIPAddress";
			this.txtIPAddress.Size = new System.Drawing.Size(188, 22);
			this.txtIPAddress.TabIndex = 25;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(-148, 25);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 17);
			this.label5.TabIndex = 24;
			this.label5.Text = "IPAddress :";
			// 
			// configTipLabel
			// 
			this.configTipLabel.AutoSize = true;
			this.configTipLabel.Location = new System.Drawing.Point(78, 94);
			this.configTipLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.configTipLabel.Name = "configTipLabel";
			this.configTipLabel.Size = new System.Drawing.Size(241, 17);
			this.configTipLabel.TabIndex = 32;
			this.configTipLabel.Text = "(Right Click to Change Configuration)";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.ClientSize = new System.Drawing.Size(807, 527);
			this.ContextMenuStrip = this.mainFormContextMenu;
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.cboxLocs);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Building Permit Administration";
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.mainFormContextMenu.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboxLocs;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusMessage;
        private System.Windows.Forms.ContextMenuStrip mainFormContextMenu;
        private System.Windows.Forms.ToolStripMenuItem configureToolStripMenuItem;
        private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label configTipLabel;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtIPAddress;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtPictureDrive;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtLibrary;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtLocPrefix;
	}
}

