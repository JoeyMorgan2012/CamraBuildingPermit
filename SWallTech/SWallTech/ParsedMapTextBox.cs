using System;
using System.Windows.Forms;

namespace SWallTech
{
	/// <summary>
	/// Summary description for ParsedMapTextDocument.
	/// </summary>
	public class ParsedMapTextBox : System.Windows.Forms.UserControl
	{
		public ParsedMapTextBox()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitComponent call
			//            this.resetControl();
		}

		/// <summary>
		/// Gets or Sets the Block segment of the Control.
		/// </summary>
		public string Block
		{
			get
			{
				return this.txtBlock.Text;
			}

			set
			{
				if (value.Length <= this.txtBlock.MaxLength)
				{
					this.txtBlock.Text = value;
				}
				else
				{
					throw new ArgumentOutOfRangeException("The string '" + value + "' is longer than the configuration allows.");
				}
			}
		}

		/// <summary>
		/// Sets the Character Casing of all map segments
		/// </summary>
		public CharacterCasing CharacterCasing
		{
			get
			{
				return this.txtMap.CharacterCasing;
			}

			set
			{
				this.txtMap.CharacterCasing = value;
				this.txtInsert.CharacterCasing = value;
				this.txtDCir.CharacterCasing = value;
				this.txtBlock.CharacterCasing = value;
				this.txtLot.CharacterCasing = value;
				this.txtSubLot.CharacterCasing = value;
			}
		}

		/// <summary>
		/// Gets or Sets the Double Circle segment of the Control.
		/// </summary>
		public string DoubleCircle
		{
			get
			{
				return this.txtDCir.Text;
			}

			set
			{
				if (value.Length <= this.txtDCir.MaxLength)
				{
					this.txtDCir.Text = value;
				}
				else
				{
					throw new ArgumentOutOfRangeException("The string '" + value + "' is longer than the configuration allows.");
				}
			}
		}

		/// <summary>
		/// Gets or Sets the Insert segment of the Control.
		/// </summary>
		public string Insert
		{
			get
			{
				return this.txtInsert.Text;
			}

			set
			{
				if (value.Length <= this.txtInsert.MaxLength)
				{
					this.txtInsert.Text = value;
				}
				else
				{
					throw new ArgumentOutOfRangeException("The string '" + value + "' is longer than the configuration allows.");
				}
			}
		}

		/// <summary>
		/// Gets or Sets the Lot segment of the Control.
		/// </summary>
		public string Lot
		{
			get
			{
				return this.txtLot.Text;
			}

			set
			{
				if (value.Length <= this.txtLot.MaxLength)
				{
					this.txtLot.Text = value;
				}
				else
				{
					throw new ArgumentOutOfRangeException("The string '" + value + "' is longer than the configuration allows.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the Map segment of the Control.
		/// </summary>
		public string Map
		{
			get
			{
				return this.txtMap.Text;
			}

			set
			{
				if (value.Length <= this.txtMap.MaxLength)
				{
					this.txtMap.Text = value;
				}
				else
				{
					throw new ArgumentOutOfRangeException("The string '" + value + "' is longer than the configuration allows.");
				}
			}
		}

		/// <summary>
		/// Gets or Sets the MapConfig object for the control.
		/// This object controls the entry properties of each text box.
		/// <para>SWallTech.MapConfig object.</para>
		/// </summary>
		public MapConfig MapConfig
		{
			get
			{
				return this.config;
			}

			set
			{
				this.resetControl();
				this.config = value;
				if (this.config != null)
				{
					this.txtMap.MaxLength = Convert.ToInt32(this.config.MapLength.Number);
					this.txtMap.Enabled = true;
					if (this.config.InsertLength.Number > 0)
					{
						this.txtInsert.MaxLength = Convert.ToInt32(this.config.InsertLength.Number);
						this.txtInsert.Enabled = true;
					}
					if (this.config.DoubleCircleLength.Number > 0)
					{
						this.txtDCir.MaxLength = Convert.ToInt32(this.config.DoubleCircleLength.Number);
						this.txtDCir.Enabled = true;
					}
					if (this.config.BlockLength.Number > 0)
					{
						this.txtBlock.MaxLength = Convert.ToInt32(this.config.BlockLength.Number);
						this.txtBlock.Enabled = true;
					}
					if (this.config.LotLength.Number > 0)
					{
						this.txtLot.MaxLength = Convert.ToInt32(this.config.LotLength.Number);
						this.txtLot.Enabled = true;
					}
					if (this.config.SubLotLength.Number > 0)
					{
						this.txtSubLot.MaxLength = Convert.ToInt32(this.config.SubLotLength.Number);
						this.txtSubLot.Enabled = true;
					}
				}
			}
		}

		/// <summary>
		/// Gets or Sets the SubLot segment of the Control.
		/// </summary>
		public string SubLot
		{
			get
			{
				return this.txtSubLot.Text;
			}

			set
			{
				if (value.Length <= this.txtSubLot.MaxLength)
				{
					this.txtSubLot.Text = value;
				}
				else
				{
					throw new ArgumentOutOfRangeException("The string '" + value + "' is longer than the configuration allows.");
				}
			}
		}

		public void Clear()
		{
			this.txtMap.Text = "";
			this.txtInsert.Text = "";
			this.txtDCir.Text = "";
			this.txtBlock.Text = "";
			this.txtLot.Text = "";
			this.txtSubLot.Text = "";
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
					components.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private MapConfig config = null;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private Label label5;
		private Label label6;
		private TextBox txtBlock;
		private TextBox txtDCir;
		private TextBox txtInsert;
		private TextBox txtLot;
		private TextBox txtMap;
		private TextBox txtSubLot;

		#region Component Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtMap = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtInsert = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtDCir = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtBlock = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtLot = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtSubLot = new System.Windows.Forms.TextBox();
			this.SuspendLayout();

			//
			// txtMap
			//
			this.txtMap.Enabled = false;
			this.txtMap.Location = new System.Drawing.Point(3, 3);
			this.txtMap.MaxLength = 3;
			this.txtMap.Name = "txtMap";
			this.txtMap.Size = new System.Drawing.Size(33, 20);
			this.txtMap.TabIndex = 0;

			//
			// label1
			//
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(28, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Map";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

			//
			// label2
			//
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(46, 26);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(21, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Ins";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

			//
			// txtInsert
			//
			this.txtInsert.Enabled = false;
			this.txtInsert.Location = new System.Drawing.Point(42, 3);
			this.txtInsert.MaxLength = 2;
			this.txtInsert.Name = "txtInsert";
			this.txtInsert.Size = new System.Drawing.Size(30, 20);
			this.txtInsert.TabIndex = 2;

			//
			// label3
			//
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(80, 26);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(27, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "DCir";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

			//
			// txtDCir
			//
			this.txtDCir.Enabled = false;
			this.txtDCir.Location = new System.Drawing.Point(78, 3);
			this.txtDCir.MaxLength = 2;
			this.txtDCir.Name = "txtDCir";
			this.txtDCir.Size = new System.Drawing.Size(30, 20);
			this.txtDCir.TabIndex = 4;

			//
			// label4
			//
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(114, 26);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(34, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Block";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

			//
			// txtBlock
			//
			this.txtBlock.Enabled = false;
			this.txtBlock.Location = new System.Drawing.Point(114, 3);
			this.txtBlock.MaxLength = 2;
			this.txtBlock.Name = "txtBlock";
			this.txtBlock.Size = new System.Drawing.Size(33, 20);
			this.txtBlock.TabIndex = 6;

			//
			// label5
			//
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(160, 26);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(22, 13);
			this.label5.TabIndex = 9;
			this.label5.Text = "Lot";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

			//
			// txtLot
			//
			this.txtLot.Enabled = false;
			this.txtLot.Location = new System.Drawing.Point(153, 3);
			this.txtLot.MaxLength = 4;
			this.txtLot.Name = "txtLot";
			this.txtLot.Size = new System.Drawing.Size(40, 20);
			this.txtLot.TabIndex = 8;

			//
			// label6
			//
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(206, 26);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(37, 13);
			this.label6.TabIndex = 11;
			this.label6.Text = "Sublot";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

			//
			// txtSubLot
			//
			this.txtSubLot.Enabled = false;
			this.txtSubLot.Location = new System.Drawing.Point(199, 3);
			this.txtSubLot.MaxLength = 7;
			this.txtSubLot.Name = "txtSubLot";
			this.txtSubLot.Size = new System.Drawing.Size(53, 20);
			this.txtSubLot.TabIndex = 10;

			//
			// ParsedMapTextBox
			//
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtSubLot);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtLot);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtBlock);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtDCir);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtInsert);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtMap);
			this.Name = "ParsedMapTextBox";
			this.Size = new System.Drawing.Size(257, 43);
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion Component Designer generated code

		private void resetControl()
		{
			this.txtMap.Text = "";
			this.txtMap.MaxLength = 3;
			this.txtMap.Enabled = false;
			this.txtInsert.Text = "";
			this.txtInsert.MaxLength = 2;
			this.txtInsert.Enabled = false;
			this.txtDCir.Text = "";
			this.txtDCir.MaxLength = 2;
			this.txtDCir.Enabled = false;
			this.txtBlock.Text = "";
			this.txtBlock.MaxLength = 2;
			this.txtBlock.Enabled = false;
			this.txtLot.Text = "";
			this.txtLot.MaxLength = 4;
			this.txtLot.Enabled = false;
			this.txtSubLot.Text = "";
			this.txtSubLot.MaxLength = 7;
			this.txtSubLot.Enabled = false;
		}
	}
}