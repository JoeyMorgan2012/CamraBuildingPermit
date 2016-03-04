using System;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace SWallTech
{
	public class MapConfig : IDBTable
	{
		public enum AdjustmentStyles
		{
			RIGHT,
			LEFT
		}

		#region Variables

		// DFFREEYN - Freeform Map# Y/n
		private FixedString DFFREEYN = new FixedString(1);

		// DFMAP - Map # Length
		private FixedDecimal DFMAP = new FixedDecimal(1, 0);

		// DFINS - Insert Length
		private FixedDecimal DFINS = new FixedDecimal(1, 0);

		// DFDCIR - Dc Length
		private FixedDecimal DFDCIR = new FixedDecimal(1, 0);

		// DFBLOCK - Block Length
		private FixedDecimal DFBLOCK = new FixedDecimal(1, 0);

		// DFLOT - Lot Length
		private FixedDecimal DFLOT = new FixedDecimal(1, 0);

		// DFSLOT - Sub-lot Length
		private FixedDecimal DFSLOT = new FixedDecimal(1, 0);

		// DFINSLR - Insert Adjust
		private FixedString DFINSLR = new FixedString(1);

		// DFDCIRLR - Dc Adjust
		private FixedString DFDCIRLR = new FixedString(1);

		// DFBLOCKLR - Block Adjust
		private FixedString DFBLOCKLR = new FixedString(1);

		// DFLOTLR - Lot Adjust
		private FixedString DFLOTLR = new FixedString(1);

		// DFSLOTLR - Sub-lot Adjust
		private FixedString DFSLOTLR = new FixedString(1);

		// DFSEPCHR - Sep Character
		private FixedString DFSEPCHR = new FixedString(1);

		// DFSPINS - Insert Start Pt
		private FixedDecimal DFSPINS = new FixedDecimal(2, 0);

		// DFSPDCIR - Dc Start Pt
		private FixedDecimal DFSPDCIR = new FixedDecimal(2, 0);

		// DFSPBLOCK - Block Start Pt
		private FixedDecimal DFSPBLOCK = new FixedDecimal(2, 0);

		// DFSPLOT - Lot Start Pt
		private FixedDecimal DFSPLOT = new FixedDecimal(2, 0);

		// DFSPSLOT - S-lot Start Pt
		private FixedDecimal DFSPSLOT = new FixedDecimal(2, 0);

		// DFMAPZ - Map Zero Fill
		private FixedString DFMAPZ = new FixedString(1);

		// DFINSZ - Ins Zero Fill
		private FixedString DFINSZ = new FixedString(1);

		// DFDCIRZ - Dc Zero Fill
		private FixedString DFDCIRZ = new FixedString(1);

		// DFBLOCKZ - Blk Zero Fill
		private FixedString DFBLOCKZ = new FixedString(1);

		// DFLOTZ - Lot Zero Fill
		private FixedString DFLOTZ = new FixedString(1);

		// DFSLOTZ - Slot Zero Fill
		private FixedString DFSLOTZ = new FixedString(1);

		// DFMAPSEP - Map Seperator
		private FixedString DFMAPSEP = new FixedString(1);

		// DFINSSEP - Ins Zero Fill
		private FixedString DFINSSEP = new FixedString(1);

		// DFDCIRSEP - Dc Seperator
		private FixedString DFDCIRSEP = new FixedString(1);

		// DFBLKSEP - Blk Seperator
		private FixedString DFBLKSEP = new FixedString(1);

		// DFLOTSEP - Lot Seperator
		private FixedString DFLOTSEP = new FixedString(1);

		// DFSLOTSEP - Slot Seperator
		private FixedString DFSLOTSEP = new FixedString(1);

		// DFSPMAPPS - Lot Sep Start Pt
		private FixedDecimal DFSPMAPPS = new FixedDecimal(2, 0);

		// DFSPINSPS - Ins Sep Start Pt
		private FixedDecimal DFSPINSPS = new FixedDecimal(2, 0);

		// DFSPDCPS - Dc Sep Start Pt
		private FixedDecimal DFSPDCPS = new FixedDecimal(2, 0);

		// DFSPBLKPS - Blk Sep Start Pt
		private FixedDecimal DFSPBLKPS = new FixedDecimal(2, 0);

		// DFSPLOTPS - Lot Sep Start Pt
		private FixedDecimal DFSPLOTPS = new FixedDecimal(2, 0);

		// DFSPSLOTPS - Slot Sep Start Pt
		private FixedDecimal DFSPSLOTPS = new FixedDecimal(2, 0);

		private string dataBase = "CAMRALIB";
		private string fileName = "DEFNPF";

		//string fileName = "";
		private string separator = ".";

		private string localityPrefix = "";
		private IDBAccess db;
		private DataSet rs;
		private DataTable dt;
		private DataRow dr;
		private Exception lastException = null;

		#endregion Variables

		#region Constructors

		private MapConfig()
		{
		}

		public MapConfig(IDBAccess db, string library, string localityPrefix)
		{
			this.db = db;
			this.dataBase = library;
			this.LocalityPrefix = localityPrefix;
			this.populate();
		}

		#endregion Constructors

		#region Properties

		/// <summary>
		/// Gets or sets IDBAccess Connection Object.
		/// </summary>
		public IDBAccess DBAccessObject
		{
			get
			{
				return this.db;
			}

			set
			{
				this.db = value;
			}
		}

		/// <summary>
		/// Gets or sets the DataBase name.
		/// </summary>
		public string DataBase
		{
			get
			{
				return this.dataBase;
			}

			set
			{
				this.dataBase = value;
			}
		}

		/// <summary>
		/// Gets or sets the 3-letter LocalityPrefix name.
		/// </summary>
		public string LocalityPrefix
		{
			get
			{
				return this.localityPrefix;
			}

			set
			{
				if (value.Length == 3)
				{
					this.localityPrefix = value;
				}
				else
				{
					//throw new ArgumentException("A LocalityPrefix must be 3 characters long.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the Database Table name.
		/// </summary>

		public string FileName
		{
			get
			{
				return this.fileName;
			}

			set
			{
				this.fileName = value;
			}
		}

		/// <summary>
		/// Gets or sets the Database Filename Separator.
		/// </summary>
		public string Separator
		{
			get
			{
				return this.separator;
			}

			set
			{
				this.separator = value;
			}
		}

		/// <summary>
		/// Gets the fully qualified Database Table name.
		/// </summary>
		public string FullFileName
		{
			get
			{
				string fullFileName = this.dataBase + this.Separator + this.LocalityPrefix + this.fileName;
				return fullFileName;
			}
		}

		/// <summary>
		/// Gets the Database Exception object from the
		/// most recent Database operation.
		/// </summary>
		/// <remarks>
		/// Returns NULL if no Exception occurred.
		/// </remarks>
		public Exception LastException
		{
			get
			{
				return this.lastException;
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - DFFREEYN
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHARACTER(1)
		/// <para>Description: Freeform Map# Y/n</para>
		/// </remarks>
		/// <returns>
		/// A boolean value indicating whether or not this MapConfig is freeform.
		/// </returns>
		public bool IsFreeformMap
		{
			get
			{
				return "Y".Equals(this.DFFREEYN.Text.Trim());
			}

			set
			{
				if (value == true)
				{
					this.DFFREEYN.setValue("Y");
				}
				else
				{
					this.DFFREEYN.setValue("N");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - DFMAP
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as PACKED(1,0)
		/// <para>Description: Map # Length</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal MapLength
		{
			get
			{
				return this.DFMAP;
			}

			set
			{
				if (this.DFMAP.checkValue(value))
				{
					this.DFMAP.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for MapLength.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - DFINS
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as PACKED(1,0)
		/// <para>Description: Insert Length</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal InsertLength
		{
			get
			{
				return this.DFINS;
			}

			set
			{
				if (this.DFINS.checkValue(value))
				{
					this.DFINS.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for InsertLength.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - DFDCIR
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as PACKED(1,0)
		/// <para>Description: Dc Length</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal DoubleCircleLength
		{
			get
			{
				return this.DFDCIR;
			}

			set
			{
				if (this.DFDCIR.checkValue(value))
				{
					this.DFDCIR.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for DoubleCircleLength.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - DFBLOCK
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as PACKED(1,0)
		/// <para>Description: Block Length</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal BlockLength
		{
			get
			{
				return this.DFBLOCK;
			}

			set
			{
				if (this.DFBLOCK.checkValue(value))
				{
					this.DFBLOCK.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for BlockLength.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - DFLOT
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as PACKED(1,0)
		/// <para>Description: Lot Length</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal LotLength
		{
			get
			{
				return this.DFLOT;
			}

			set
			{
				if (this.DFLOT.checkValue(value))
				{
					this.DFLOT.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for LotLength.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - DFSLOT
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as PACKED(1,0)
		/// <para>Description: Sub-lot Length</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal SubLotLength
		{
			get
			{
				return this.DFSLOT;
			}

			set
			{
				if (this.DFSLOT.checkValue(value))
				{
					this.DFSLOT.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for SubLotLength.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - DFINSLR
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHARACTER(1)
		/// <para>Description: Insert Adjust</para>
		/// An adjustment indicates whether the field data will be left or right adjusted within its defined space.
		/// </remarks>
		/// <returns>
		/// The Adjustment Style for the Insert portion of the map.
		/// </returns>
		public AdjustmentStyles InsertAdjustment
		{
			get
			{
				AdjustmentStyles leftright = AdjustmentStyles.LEFT;
				if ("R".Equals(this.DFINSLR.Text))
				{
					leftright = AdjustmentStyles.RIGHT;
				}
				return leftright;
			}

			set
			{
				if (value == AdjustmentStyles.LEFT)
				{
					this.DFINSLR.setValue("L");
				}
				else if (value == AdjustmentStyles.RIGHT)
				{
					this.DFINSLR.setValue("R");
				}
				else
				{
					throw new OverflowException("Value outside established bounds for InsertAdjustment.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - DFDCIRLR
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHARACTER(1)
		/// <para>Description: Dc Adjust</para>
		/// An adjustment indicates whether the field data will be left or right adjusted within its defined space.
		/// </remarks>
		/// <returns>
		/// The Adjustment Style for the Insert portion of the map.
		/// </returns>
		public AdjustmentStyles DoubleCircleAdjustment
		{
			get
			{
				AdjustmentStyles leftright = AdjustmentStyles.LEFT;
				if ("R".Equals(this.DFDCIRLR.Text))
				{
					leftright = AdjustmentStyles.RIGHT;
				}
				return leftright;
			}

			set
			{
				if (value == AdjustmentStyles.LEFT)
				{
					this.DFDCIRLR.setValue("L");
				}
				else if (value == AdjustmentStyles.RIGHT)
				{
					this.DFDCIRLR.setValue("R");
				}
				else
				{
					throw new OverflowException("Value outside established bounds for DoubleCircleAdjustment.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - DFBLOCKLR
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHARACTER(1)
		/// <para>Description: Block Adjust</para>
		/// An adjustment indicates whether the field data will be left or right adjusted within its defined space.
		/// </remarks>
		/// <returns>
		/// The Adjustment Style for the Insert portion of the map.
		/// </returns>
		public AdjustmentStyles BlockAdjustment
		{
			get
			{
				AdjustmentStyles leftright = AdjustmentStyles.LEFT;
				if ("R".Equals(this.DFBLOCKLR.Text))
				{
					leftright = AdjustmentStyles.RIGHT;
				}
				return leftright;
			}

			set
			{
				if (value == AdjustmentStyles.LEFT)
				{
					this.DFBLOCKLR.setValue("L");
				}
				else if (value == AdjustmentStyles.RIGHT)
				{
					this.DFBLOCKLR.setValue("R");
				}
				else
				{
					throw new OverflowException("Value outside established bounds for BlockAdjustment.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - DFLOTLR
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHARACTER(1)
		/// <para>Description: Lot Adjust</para>
		/// An adjustment indicates whether the field data will be left or right adjusted within its defined space.
		/// </remarks>
		/// <returns>
		/// The Adjustment Style for the Insert portion of the map.
		/// </returns>
		public AdjustmentStyles LotAdjustment
		{
			get
			{
				AdjustmentStyles leftright = AdjustmentStyles.LEFT;
				if ("R".Equals(this.DFLOTLR.Text))
				{
					leftright = AdjustmentStyles.RIGHT;
				}
				return leftright;
			}

			set
			{
				if (value == AdjustmentStyles.LEFT)
				{
					this.DFLOTLR.setValue("L");
				}
				else if (value == AdjustmentStyles.RIGHT)
				{
					this.DFLOTLR.setValue("R");
				}
				else
				{
					throw new OverflowException("Value outside established bounds for LotAdjustment.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - DFSLOTLR
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHARACTER(1)
		/// <para>Description: Sub-lot Adjust</para>
		/// An adjustment indicates whether the field data will be left or right adjusted within its defined space.
		/// </remarks>
		/// <returns>
		/// The Adjustment Style for the Insert portion of the map.
		/// </returns>
		public AdjustmentStyles SubLotAdjustment
		{
			get
			{
				AdjustmentStyles leftright = AdjustmentStyles.LEFT;
				if ("R".Equals(this.DFSLOTLR.Text))
				{
					leftright = AdjustmentStyles.RIGHT;
				}
				return leftright;
			}

			set
			{
				if (value == AdjustmentStyles.LEFT)
				{
					this.DFSLOTLR.setValue("L");
				}
				else if (value == AdjustmentStyles.RIGHT)
				{
					this.DFSLOTLR.setValue("R");
				}
				else
				{
					throw new OverflowException("Value outside established bounds for SubLotAdjustment.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - DFSEPCHR
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHARACTER(1)
		/// <para>Description: Sep Character</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString SeparatorCharacter
		{
			get
			{
				return this.DFSEPCHR;
			}

			set
			{
				if (this.DFSEPCHR.checkValue(value))
				{
					this.DFSEPCHR.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for SeparatorCharacter.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - DFSPINS
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as PACKED(2,0)
		/// <para>Description: Insert Start Pt</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal InsertStartPoint
		{
			get
			{
				return this.DFSPINS;
			}

			set
			{
				if (this.DFSPINS.checkValue(value))
				{
					this.DFSPINS.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for InsertStartPoint.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - DFSPDCIR
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as PACKED(2,0)
		/// <para>Description: Dc Start Pt</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal DoubleCircleStartPoint
		{
			get
			{
				return this.DFSPDCIR;
			}

			set
			{
				if (this.DFSPDCIR.checkValue(value))
				{
					this.DFSPDCIR.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for DoubleCircleStartPoint.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - DFSPBLOCK
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as PACKED(2,0)
		/// <para>Description: Block Start Pt</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal BlockStartPoint
		{
			get
			{
				return this.DFSPBLOCK;
			}

			set
			{
				if (this.DFSPBLOCK.checkValue(value))
				{
					this.DFSPBLOCK.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for BlockStartPoint.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - DFSPLOT
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as PACKED(2,0)
		/// <para>Description: Lot Start Pt</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal LotStartPoint
		{
			get
			{
				return this.DFSPLOT;
			}

			set
			{
				if (this.DFSPLOT.checkValue(value))
				{
					this.DFSPLOT.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for LotStartPoint.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - DFSPSLOT
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as PACKED(2,0)
		/// <para>Description: S-lot Start Pt</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal SubLotStartPoint
		{
			get
			{
				return this.DFSPSLOT;
			}

			set
			{
				if (this.DFSPSLOT.checkValue(value))
				{
					this.DFSPSLOT.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for SubLotStartPoint.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - DFMAPZ
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHARACTER(1)
		/// <para>Description: Map Zero Fill</para>
		/// </remarks>
		/// <returns>
		/// A boolean value indicating whether or not the map segment is Zero-Filled.
		/// </returns>
		public bool IsMapZeroFilled
		{
			get
			{
				return "Y".Equals(this.DFMAPZ.Text.Trim());
			}

			set
			{
				if (value == true)
				{
					this.DFMAPZ.setValue("Y");
				}
				else
				{
					this.DFMAPZ.setValue("N");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - DFINSZ
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHARACTER(1)
		/// <para>Description: Ins Zero Fill</para>
		/// </remarks>
		/// <returns>
		/// A boolean value indicating whether or not the map segment is Zero-Filled.
		/// </returns>
		public bool IsInsertZeroFilled
		{
			get
			{
				return "Y".Equals(this.DFINSZ.Text.Trim());
			}

			set
			{
				if (value == true)
				{
					this.DFINSZ.setValue("Y");
				}
				else
				{
					this.DFINSZ.setValue("N");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - DFDCIRZ
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHARACTER(1)
		/// <para>Description: Dc Zero Fill</para>
		/// </remarks>
		/// <returns>
		/// A boolean value indicating whether or not the map segment is Zero-Filled.
		/// </returns>
		public bool IsDoubleCircleZeroFilled
		{
			get
			{
				return "Y".Equals(this.DFDCIRZ.Text.Trim());
			}

			set
			{
				if (value == true)
				{
					this.DFDCIRZ.setValue("Y");
				}
				else
				{
					this.DFDCIRZ.setValue("N");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - DFBLOCKZ
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHARACTER(1)
		/// <para>Description: Blk Zero Fill</para>
		/// </remarks>
		/// <returns>
		/// A boolean value indicating whether or not the map segment is Zero-Filled.
		/// </returns>
		public bool IsBlockZeroFilled
		{
			get
			{
				return "Y".Equals(this.DFBLOCKZ.Text.Trim());
			}

			set
			{
				if (value == true)
				{
					this.DFBLOCKZ.setValue("Y");
				}
				else
				{
					this.DFBLOCKZ.setValue("N");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - DFLOTZ
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHARACTER(1)
		/// <para>Description: Lot Zero Fill</para>
		/// </remarks>
		/// <returns>
		/// A boolean value indicating whether or not the map segment is Zero-Filled.
		/// </returns>
		public bool IsLotZeroFilled
		{
			get
			{
				return "Y".Equals(this.DFLOTZ.Text.Trim());
			}

			set
			{
				if (value == true)
				{
					this.DFLOTZ.setValue("Y");
				}
				else
				{
					this.DFLOTZ.setValue("N");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - DFSLOTZ
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHARACTER(1)
		/// <para>Description: Slot Zero Fill</para>
		/// </remarks>
		/// <returns>
		/// A boolean value indicating whether or not the map segment is Zero-Filled.
		/// </returns>
		public bool IsSubLotZeroFilled
		{
			get
			{
				return "Y".Equals(this.DFSLOTZ.Text.Trim());
			}

			set
			{
				if (value == true)
				{
					this.DFSLOTZ.setValue("Y");
				}
				else
				{
					this.DFSLOTZ.setValue("N");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - DFMAPSEP
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHARACTER(1)
		/// <para>Description: Map Seperator</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString MapSeparatorCharacter
		{
			get
			{
				return this.DFMAPSEP;
			}

			set
			{
				if (this.DFMAPSEP.checkValue(value))
				{
					this.DFMAPSEP.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for MapSeparatorCharacter.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - DFINSSEP
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHARACTER(1)
		/// <para>Description: Ins Zero Fill</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString InsertSeparatorCharacter
		{
			get
			{
				return this.DFINSSEP;
			}

			set
			{
				if (this.DFINSSEP.checkValue(value))
				{
					this.DFINSSEP.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for InsertSeparatorCharacter.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - DFDCIRSEP
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHARACTER(1)
		/// <para>Description: Dc Seperator</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString DoubleCircleSeparatorCharacter
		{
			get
			{
				return this.DFDCIRSEP;
			}

			set
			{
				if (this.DFDCIRSEP.checkValue(value))
				{
					this.DFDCIRSEP.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for DoubleCircleSeparatorCharacter.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - DFBLKSEP
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHARACTER(1)
		/// <para>Description: Blk Seperator</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString BlockSeparatorCharacter
		{
			get
			{
				return this.DFBLKSEP;
			}

			set
			{
				if (this.DFBLKSEP.checkValue(value))
				{
					this.DFBLKSEP.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for BlockSeparatorCharacter.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - DFLOTSEP
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHARACTER(1)
		/// <para>Description: Lot Seperator</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString LotSeparatorCharacter
		{
			get
			{
				return this.DFLOTSEP;
			}

			set
			{
				if (this.DFLOTSEP.checkValue(value))
				{
					this.DFLOTSEP.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for LotSeparatorCharacter.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - DFSLOTSEP
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHARACTER(1)
		/// <para>Description: Slot Seperator</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString SubLotSeparatorCharacter
		{
			get
			{
				return this.DFSLOTSEP;
			}

			set
			{
				if (this.DFSLOTSEP.checkValue(value))
				{
					this.DFSLOTSEP.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for SubLotSeparatorCharacter.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - DFSPMAPPS
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as PACKED(2,0)
		/// <para>Description: Map Sep Start Pt</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal MapSeparatorStartPoint
		{
			get
			{
				return this.DFSPMAPPS;
			}

			set
			{
				if (this.DFSPMAPPS.checkValue(value))
				{
					this.DFSPMAPPS.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for MapSeparatorStartPoint.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - DFSPINSPS
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as PACKED(2,0)
		/// <para>Description: Ins Sep Start Pt</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal InsertSeparatorStartPoint
		{
			get
			{
				return this.DFSPINSPS;
			}

			set
			{
				if (this.DFSPINSPS.checkValue(value))
				{
					this.DFSPINSPS.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for InsertSeparatorStartPoint.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - DFSPDCPS
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as PACKED(2,0)
		/// <para>Description: Dc Sep Start Pt</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal DoubleCircleSeparatorStartPoint
		{
			get
			{
				return this.DFSPDCPS;
			}

			set
			{
				if (this.DFSPDCPS.checkValue(value))
				{
					this.DFSPDCPS.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for DoubleCircleSeparatorStartPoint.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - DFSPBLKPS
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as PACKED(2,0)
		/// <para>Description: Block Sep Start Pt</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal BlockSeparatorStartPoint
		{
			get
			{
				return this.DFSPBLKPS;
			}

			set
			{
				if (this.DFSPBLKPS.checkValue(value))
				{
					this.DFSPBLKPS.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for BlockSeparatorStartPoint.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - DFSPLOTPS
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as PACKED(2,0)
		/// <para>Description: Lot Sep Start Pt</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal LotSeparatorStartPoint
		{
			get
			{
				return this.DFSPLOTPS;
			}

			set
			{
				if (this.DFSPLOTPS.checkValue(value))
				{
					this.DFSPLOTPS.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for LotSeparatorStartPoint.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - DFSPSLOTPS
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as PACKED(2,0)
		/// <para>Description: Slot Sep Start Pt</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal SubLotSeparatorStartPoint
		{
			get
			{
				return this.DFSPSLOTPS;
			}

			set
			{
				if (this.DFSPSLOTPS.checkValue(value))
				{
					this.DFSPSLOTPS.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for SubLotSeparatorStartPoint.");
				}
			}
		}

		#endregion Properties

		#region Public Methods

		/// <summary>
		/// Populates the instance properties with data from the database table based on the
		/// current key settings.
		/// </summary>
		public bool populate()
		{
			return this.getTableData();
		}

		/// <summary>
		/// Updates the database table with the current property values using the
		/// current key settings.
		/// </summary>
		///<returns>The number of rows updated.</returns>
		public int update()
		{
			this.lastException = null;
			int rowCount = -1;
			try
			{
				StringBuilder sb = new StringBuilder();
				sb.Append("update ");
				sb.Append(this.FullFileName);
				sb.Append(" set ");
				sb.Append("DFFREEYN = '" + this.DFFREEYN.Text + "'");
				sb.Append(", ");
				sb.Append("DFMAP = " + this.DFMAP.ToString());
				sb.Append(", ");
				sb.Append("DFINS = " + this.DFINS.ToString());
				sb.Append(", ");
				sb.Append("DFDCIR = " + this.DFDCIR.ToString());
				sb.Append(", ");
				sb.Append("DFBLOCK = " + this.DFBLOCK.ToString());
				sb.Append(", ");
				sb.Append("DFLOT = " + this.DFLOT.ToString());
				sb.Append(", ");
				sb.Append("DFSLOT = " + this.DFSLOT.ToString());
				sb.Append(", ");
				sb.Append("DFINSLR = '" + this.DFINSLR.Text + "'");
				sb.Append(", ");
				sb.Append("DFDCIRLR = '" + this.DFDCIRLR.Text + "'");
				sb.Append(", ");
				sb.Append("DFBLOCKLR = '" + this.DFBLOCKLR.Text + "'");
				sb.Append(", ");
				sb.Append("DFLOTLR = '" + this.DFLOTLR.Text + "'");
				sb.Append(", ");
				sb.Append("DFSLOTLR = '" + this.DFSLOTLR.Text + "'");
				sb.Append(", ");
				sb.Append("DFSEPCHR = '" + this.DFSEPCHR.Text + "'");
				sb.Append(", ");
				sb.Append("DFSPINS = " + this.DFSPINS.ToString());
				sb.Append(", ");
				sb.Append("DFSPDCIR = " + this.DFSPDCIR.ToString());
				sb.Append(", ");
				sb.Append("DFSPBLOCK = " + this.DFSPBLOCK.ToString());
				sb.Append(", ");
				sb.Append("DFSPLOT = " + this.DFSPLOT.ToString());
				sb.Append(", ");
				sb.Append("DFSPSLOT = " + this.DFSPSLOT.ToString());
				sb.Append(", ");
				sb.Append("DFMAPZ = '" + this.DFMAPZ.Text + "'");
				sb.Append(", ");
				sb.Append("DFINSZ = '" + this.DFINSZ.Text + "'");
				sb.Append(", ");
				sb.Append("DFDCIRZ = '" + this.DFDCIRZ.Text + "'");
				sb.Append(", ");
				sb.Append("DFBLOCKZ = '" + this.DFBLOCKZ.Text + "'");
				sb.Append(", ");
				sb.Append("DFLOTZ = '" + this.DFLOTZ.Text + "'");
				sb.Append(", ");
				sb.Append("DFSLOTZ = '" + this.DFSLOTZ.Text + "'");
				sb.Append(", ");
				sb.Append("DFMAPSEP = '" + this.DFMAPSEP.Text + "'");
				sb.Append(", ");
				sb.Append("DFINSSEP = '" + this.DFINSSEP.Text + "'");
				sb.Append(", ");
				sb.Append("DFDCIRSEP = '" + this.DFDCIRSEP.Text + "'");
				sb.Append(", ");
				sb.Append("DFBLKSEP = '" + this.DFBLKSEP.Text + "'");
				sb.Append(", ");
				sb.Append("DFLOTSEP = '" + this.DFLOTSEP.Text + "'");
				sb.Append(", ");
				sb.Append("DFSLOTSEP = '" + this.DFSLOTSEP.Text + "'");
				sb.Append(", ");
				sb.Append("DFSPMAPPS = " + this.DFSPMAPPS.ToString());
				sb.Append(", ");
				sb.Append("DFSPINSPS = " + this.DFSPINSPS.ToString());
				sb.Append(", ");
				sb.Append("DFSPDCPS = " + this.DFSPDCPS.ToString());
				sb.Append(", ");
				sb.Append("DFSPBLKPS = " + this.DFSPBLKPS.ToString());
				sb.Append(", ");
				sb.Append("DFSPLOTPS = " + this.DFSPLOTPS.ToString());
				sb.Append(", ");
				sb.Append("DFSPSLOTPS = " + this.DFSPSLOTPS.ToString());

				string cmd = sb.ToString();
				rowCount = this.db.ExecuteNonSelectStatement(cmd);
			}
			catch (System.Exception ex)
			{
				this.lastException = ex;
			}
			return rowCount;
		}

		/// <summary>
		/// Inserts a record into the database table using all current property values.
		/// </summary>
		///<returns>The number of rows inserted.</returns>
		public int insert()
		{
			this.lastException = null;
			int rowCount = -1;
			try
			{
				StringBuilder sb = new StringBuilder();
				sb.Append("insert into ");
				sb.Append(this.FullFileName);
				sb.Append(" (DFFREEYN,DFMAP,DFINS,DFDCIR,DFBLOCK,DFLOT,DFSLOT,DFINSLR,DFDCIRLR,DFBLOCKLR,DFLOTLR,DFSLOTLR,DFSEPCHR,DFSPINS,DFSPDCIR,DFSPBLOCK,DFSPLOT,DFSPSLOT,DFMAPZ,DFINSZ,DFDCIRZ,DFBLOCKZ,DFLOTZ,DFSLOTZ,DFMAPSEP,DFINSSEP,DFDCIRSEP,DFBLKSEP,DFLOTSEP,DFSLOTSEP,DFSPMAPPS,DFSPINSPS,DFSPDCPS,DFSPBLKPS,DFSPLOTPS,DFSPSLOTPS) ");
				sb.Append("values( ");
				sb.Append("'" + this.DFFREEYN.Text + "'");
				sb.Append(", ");
				sb.Append(this.DFMAP.ToString());
				sb.Append(", ");
				sb.Append(this.DFINS.ToString());
				sb.Append(", ");
				sb.Append(this.DFDCIR.ToString());
				sb.Append(", ");
				sb.Append(this.DFBLOCK.ToString());
				sb.Append(", ");
				sb.Append(this.DFLOT.ToString());
				sb.Append(", ");
				sb.Append(this.DFSLOT.ToString());
				sb.Append(", ");
				sb.Append("'" + this.DFINSLR.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.DFDCIRLR.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.DFBLOCKLR.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.DFLOTLR.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.DFSLOTLR.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.DFSEPCHR.Text + "'");
				sb.Append(", ");
				sb.Append(this.DFSPINS.ToString());
				sb.Append(", ");
				sb.Append(this.DFSPDCIR.ToString());
				sb.Append(", ");
				sb.Append(this.DFSPBLOCK.ToString());
				sb.Append(", ");
				sb.Append(this.DFSPLOT.ToString());
				sb.Append(", ");
				sb.Append(this.DFSPSLOT.ToString());
				sb.Append(", ");
				sb.Append("'" + this.DFMAPZ.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.DFINSZ.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.DFDCIRZ.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.DFBLOCKZ.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.DFLOTZ.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.DFSLOTZ.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.DFMAPSEP.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.DFINSSEP.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.DFDCIRSEP.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.DFBLKSEP.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.DFLOTSEP.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.DFSLOTSEP.Text + "'");
				sb.Append(", ");
				sb.Append(this.DFSPMAPPS.ToString());
				sb.Append(", ");
				sb.Append(this.DFSPINSPS.ToString());
				sb.Append(", ");
				sb.Append(this.DFSPDCPS.ToString());
				sb.Append(", ");
				sb.Append(this.DFSPBLKPS.ToString());
				sb.Append(", ");
				sb.Append(this.DFSPLOTPS.ToString());
				sb.Append(", ");
				sb.Append(this.DFSPSLOTPS.ToString());
				sb.Append(" )");

				string cmd = sb.ToString();
				rowCount = this.db.ExecuteNonSelectStatement(cmd);
			}
			catch (System.Exception ex)
			{
				this.lastException = ex;
			}
			return rowCount;
		}

		/// <summary>
		/// Deletes from the database table all records /// with the current key settings.
		/// </summary>
		///<returns>The number of rows deleted.</returns>
		public int delete()
		{
			this.lastException = null;
			int rowCount = -1;
			try
			{
				StringBuilder sb = new StringBuilder();
				sb.Append("delete from ");
				sb.Append(this.FullFileName);

				string cmd = sb.ToString();
				rowCount = this.db.ExecuteNonSelectStatement(cmd);
			}
			catch (System.Exception ex)
			{
				this.lastException = ex;
			}
			return rowCount;
		}

		#endregion Public Methods

		#region Private Methods

		private bool getTableData()
		{
			bool isOK = false;
			this.lastException = null;
			try
			{
				StringBuilder sb = new StringBuilder();

				// Add code here to read table
				sb.Append("Select * from ");
				sb.Append(this.FullFileName);

				string cmd = sb.ToString();
				rs = this.db.RunSelectStatement(cmd);
				if (rs.Tables.Count > 0)
				{
					dt = rs.Tables[0];
					if (dt.Rows.Count > 0)
					{
						dr = dt.Rows[0];

						// Add code here to populate variables
						this.DFFREEYN.Text = (string)dr["DFFREEYN"];
						string s = dr["DFMAP"].ToString();
						this.DFMAP.setValue(dr["DFMAP"].ToString());
						this.DFINS.setValue(dr["DFINS"].ToString());
						this.DFDCIR.setValue(dr["DFDCIR"].ToString());
						this.DFBLOCK.setValue(dr["DFBLOCK"].ToString());
						this.DFLOT.setValue(dr["DFLOT"].ToString());
						this.DFSLOT.setValue(dr["DFSLOT"].ToString());
						this.DFINSLR.Text = (string)dr["DFINSLR"];
						this.DFDCIRLR.Text = (string)dr["DFDCIRLR"];
						this.DFBLOCKLR.Text = (string)dr["DFBLOCKLR"];
						this.DFLOTLR.Text = (string)dr["DFLOTLR"];
						this.DFSLOTLR.Text = (string)dr["DFSLOTLR"];
						this.DFSEPCHR.Text = (string)dr["DFSEPCHR"];
						this.DFSPINS.setValue(dr["DFSPINS"].ToString());
						this.DFSPDCIR.setValue(dr["DFSPDCIR"].ToString());
						this.DFSPBLOCK.setValue(dr["DFSPBLOCK"].ToString());
						this.DFSPLOT.setValue(dr["DFSPLOT"].ToString());
						this.DFSPSLOT.setValue(dr["DFSPSLOT"].ToString());
						this.DFMAPZ.Text = (string)dr["DFMAPZ"];
						this.DFINSZ.Text = (string)dr["DFINSZ"];
						this.DFDCIRZ.Text = (string)dr["DFDCIRZ"];
						this.DFBLOCKZ.Text = (string)dr["DFBLOCKZ"];
						this.DFLOTZ.Text = (string)dr["DFLOTZ"];
						this.DFSLOTZ.Text = (string)dr["DFSLOTZ"];
						this.DFMAPSEP.Text = (string)dr["DFMAPSEP"];
						this.DFINSSEP.Text = (string)dr["DFINSSEP"];
						this.DFDCIRSEP.Text = (string)dr["DFDCIRSEP"];
						this.DFBLKSEP.Text = (string)dr["DFBLKSEP"];
						this.DFLOTSEP.Text = (string)dr["DFLOTSEP"];
						this.DFSLOTSEP.Text = (string)dr["DFSLOTSEP"];
						this.DFSPMAPPS.setValue(dr["DFSPMAPPS"].ToString());
						this.DFSPINSPS.setValue(dr["DFSPINSPS"].ToString());
						this.DFSPDCPS.setValue(dr["DFSPDCPS"].ToString());
						this.DFSPBLKPS.setValue(dr["DFSPBLKPS"].ToString());
						this.DFSPLOTPS.setValue(dr["DFSPLOTPS"].ToString());
						this.DFSPSLOTPS.setValue(dr["DFSPSLOTPS"].ToString());

						isOK = true;
					}
				}
				else
				{
					Console.WriteLine(string.Format("Command {0} failed.", cmd));
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine(string.Format("Error occurred in {0}, in procedure {1}.", MethodBase.GetCurrentMethod().Module, MethodBase.GetCurrentMethod().Name));
				this.lastException = ex;
			}
			return isOK;
		}

		#endregion Private Methods
	}
}