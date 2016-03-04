using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SWallTech
{
	/* C# Bean representing the following Table:
        Library  : CAMRALIB
        Table    : CAFPMOBH
        Created  : 5/14/2007 3:41:57 PM
        Generator: Stonewall Technologies BeanMaker 0.0.1

	This class is an Abstract base class for this Database Table. SWallTech.REMobh
	inherits from this class so that you can regenerate this Base class
	to reflect any database changes without losing your custom code.

    */

	public abstract class REMobh_Base : IDBTable
	{
		#region Variables

		private string dataBase = "CAMRALIB";
		private string fileName = "CAFPMOBH";
		private string separator = ".";
		protected IDBAccess db;
		private DataSet rs;
		private DataTable dt;
		private DataRow dr;
		private Exception lastException = null;
		public static string allFieldNamesActual = "HID,HRECNO,HFILL1,HLNAM,HPPACT,HPPSEQ,HOSSN2,HADD3,HPRVAL,HFACTR,HDEPRC,HTOTOI,HMHVAL,HTOTPR,HMHBAS,HSWDW,HMAKE,HMODEL,HBODY,HOZIP,HAC,HPURDT,HFAIRV,HOVRRT,HMAP#,HLOT#,HFILL3,HYEAR,HCOND,HLEN,HWID,HREM1,HREM2,HVALUE,HMREC#,HONAME,HOSSN,HMDWL,HTITL#,HTITDT,HWGHT,HID#,HPURCH,HADD1,HADD2,HFILL5";
		public static string allFieldNamesAdjusted = "HID,HRECNO,HFILL1,HLNAM,HPPACT,HPPSEQ,HOSSN2,HADD3,HPRVAL,HFACTR,HDEPRC,HTOTOI,HMHVAL,HTOTPR,HMHBAS,HSWDW,HMAKE,HMODEL,HBODY,HOZIP,HAC,HPURDT,HFAIRV,HOVRRT,HMAP_NUM,HLOT_NUM,HFILL3,HYEAR,HCOND,HLEN,HWID,HREM1,HREM2,HVALUE,HMREC_NUM,HONAME,HOSSN,HMDWL,HTITL_NUM,HTITDT,HWGHT,HID_NUM,HPURCH,HADD1,HADD2,HFILL5";
		public static string nonKeyFieldsActual = "HID,HFILL1,HLNAM,HPPACT,HPPSEQ,HOSSN2,HADD3,HPRVAL,HFACTR,HDEPRC,HTOTOI,HMHVAL,HTOTPR,HMHBAS,HSWDW,HMAKE,HMODEL,HBODY,HOZIP,HAC,HPURDT,HFAIRV,HOVRRT,HMAP#,HLOT#,HFILL3,HYEAR,HCOND,HLEN,HWID,HREM1,HREM2,HVALUE,HMREC#,HONAME,HOSSN,HMDWL,HTITL#,HTITDT,HWGHT,HID#,HPURCH,HADD1,HADD2,HFILL5";
		public static string nonKeyFieldsAdjusted = "HID,HFILL1,HLNAM,HPPACT,HPPSEQ,HOSSN2,HADD3,HPRVAL,HFACTR,HDEPRC,HTOTOI,HMHVAL,HTOTPR,HMHBAS,HSWDW,HMAKE,HMODEL,HBODY,HOZIP,HAC,HPURDT,HFAIRV,HOVRRT,HMAP_NUM,HLOT_NUM,HFILL3,HYEAR,HCOND,HLEN,HWID,HREM1,HREM2,HVALUE,HMREC_NUM,HONAME,HOSSN,HMDWL,HTITL_NUM,HTITDT,HWGHT,HID_NUM,HPURCH,HADD1,HADD2,HFILL5";
		private string selectFields = "HID,HRECNO,HFILL1,HLNAM,HPPACT,HPPSEQ,HOSSN2,HADD3,HPRVAL,HFACTR,HDEPRC,HTOTOI,HMHVAL,HTOTPR,HMHBAS,HSWDW,HMAKE,HMODEL,HBODY,HOZIP,HAC,HPURDT,HFAIRV,HOVRRT,HMAP# as HMAP_NUM,HLOT# as HLOT_NUM,HFILL3,HYEAR,HCOND,HLEN,HWID,HREM1,HREM2,HVALUE,HMREC# as HMREC_NUM,HONAME,HOSSN,HMDWL,HTITL# as HTITL_NUM,HTITDT,HWGHT,HID# as HID_NUM,HPURCH,HADD1,HADD2,HFILL5";

		// HID - RECORD ID CODE
		// Managed by Property: Hid
		private FixedString HID = new FixedString(1);

		// HRECNO - MOB HOME REC NO
		// Managed by Property: Hrecno
		private FixedDecimal HRECNO = new FixedDecimal(5, 0);

		// HFILL1 - FILLER 1
		// Managed by Property: Hfill1
		private FixedString HFILL1 = new FixedString(2);

		// HLNAM - LAST NAME
		// Managed by Property: Hlnam
		private FixedString HLNAM = new FixedString(35);

		// HPPACT - PERS PROP ACCT#
		// Managed by Property: Hppact
		private FixedDecimal HPPACT = new FixedDecimal(7, 0);

		// HPPSEQ - PERS PROP SEQ#
		// Managed by Property: Hppseq
		private FixedDecimal HPPSEQ = new FixedDecimal(4, 0);

		// HOSSN2 - MH OWNER SOC SEC
		// Managed by Property: Hossn2
		private FixedDecimal HOSSN2 = new FixedDecimal(9, 0);

		// HADD3 - MH OWNER ADDR 3
		// Managed by Property: Hadd3
		private FixedString HADD3 = new FixedString(35);

		// HPRVAL - MH PRIOR YR VALU
		// Managed by Property: Hprval
		private FixedDecimal HPRVAL = new FixedDecimal(9, 0);

		// HFACTR - MH FACTOR
		// Managed by Property: Hfactr
		private FixedDecimal HFACTR = new FixedDecimal(3, 2);

		// HDEPRC - MH DEPREC
		// Managed by Property: Hdeprc
		private FixedDecimal HDEPRC = new FixedDecimal(3, 2);

		// HTOTOI - MH TOTAL OTH IMP
		// Managed by Property: Htotoi
		private FixedDecimal HTOTOI = new FixedDecimal(9, 0);

		// HMHVAL - MH VALUE
		// Managed by Property: Hmhval
		private FixedDecimal HMHVAL = new FixedDecimal(9, 0);

		// HTOTPR - TOTAL PROP VALUE
		// Managed by Property: Htotpr
		private FixedDecimal HTOTPR = new FixedDecimal(10, 0);

		// HMHBAS - MH BASE VALUE
		// Managed by Property: Hmhbas
		private FixedDecimal HMHBAS = new FixedDecimal(9, 0);

		// HSWDW - SW/DW CODE
		// Managed by Property: Hswdw
		private FixedString HSWDW = new FixedString(2);

		// HMAKE - MH MAKE
		// Managed by Property: Hmake
		private FixedString HMAKE = new FixedString(10);

		// HMODEL - MH MODEL
		// Managed by Property: Hmodel
		private FixedString HMODEL = new FixedString(15);

		// HBODY - MH BODY
		// Managed by Property: Hbody
		private FixedString HBODY = new FixedString(15);

		// HOZIP - MH OWNER ZIP
		// Managed by Property: Hozip
		private FixedDecimal HOZIP = new FixedDecimal(5, 0);

		// HAC - AIR CONDITIONING
		// Managed by Property: Hac
		private FixedString HAC = new FixedString(1);

		// HPURDT - PURCH DATE
		// Managed by Property: Hpurdt
		private FixedDecimal HPURDT = new FixedDecimal(8, 0);

		// HFAIRV - FAIR VALUE
		// Managed by Property: Hfairv
		private FixedDecimal HFAIRV = new FixedDecimal(6, 0);

		// HOVRRT - OVERRIDE RATE PSF
		// Managed by Property: Hovrrt
		private FixedDecimal HOVRRT = new FixedDecimal(4, 2);

		// HMAP_NUM - TAX MAP NO
		// Managed by Property: Hmap_num
		private FixedString HMAP_NUM = new FixedString(20);

		// HLOT_NUM - LOT NO
		// Managed by Property: Hlot_num
		private FixedString HLOT_NUM = new FixedString(8);

		// HFILL3 - FILLER 3
		// Managed by Property: Hfill3
		private FixedString HFILL3 = new FixedString(2);

		// HYEAR - YEAR
		// Managed by Property: Hyear
		private FixedDecimal HYEAR = new FixedDecimal(4, 0);

		// HCOND - CONDITION
		// Managed by Property: Hcond
		private FixedString HCOND = new FixedString(1);

		// HLEN - LENGTH
		// Managed by Property: Hlen
		private FixedDecimal HLEN = new FixedDecimal(4, 1);

		// HWID - WIDTH
		// Managed by Property: Hwid
		private FixedDecimal HWID = new FixedDecimal(4, 1);

		// HREM1 - REMARKS 1
		// Managed by Property: Hrem1
		private FixedString HREM1 = new FixedString(35);

		// HREM2 - REMARKS 2
		// Managed by Property: Hrem2
		private FixedString HREM2 = new FixedString(35);

		// HVALUE - VALUE
		// Managed by Property: Hvalue
		private FixedDecimal HVALUE = new FixedDecimal(9, 2);

		// HMREC_NUM - PARCEL MASTER REC NO
		// Managed by Property: Hmrec_num
		private FixedDecimal HMREC_NUM = new FixedDecimal(7, 0);

		// HONAME - OWNER NAME
		// Managed by Property: Honame
		private FixedString HONAME = new FixedString(35);

		// HOSSN - OWNER SOC SEC NO
		// Managed by Property: Hossn
		private FixedDecimal HOSSN = new FixedDecimal(9, 0);

		// HMDWL - MASTER REC# DWELL #
		// Managed by Property: Hmdwl
		private FixedDecimal HMDWL = new FixedDecimal(2, 0);

		// HTITL_NUM - TITLE#
		// Managed by Property: Htitl_num
		private FixedString HTITL_NUM = new FixedString(8);

		// HTITDT - TITLE DATE
		// Managed by Property: Htitdt
		private FixedDecimal HTITDT = new FixedDecimal(8, 0);

		// HWGHT - WEIGHT
		// Managed by Property: Hwght
		private FixedDecimal HWGHT = new FixedDecimal(6, 0);

		// HID_NUM - ID#-VIN NO.
		// Managed by Property: Hid_num
		private FixedString HID_NUM = new FixedString(20);

		// HPURCH - PURCHASE PRICE
		// Managed by Property: Hpurch
		private FixedDecimal HPURCH = new FixedDecimal(6, 0);

		// HADD1 - MFG HSING ADR 1
		// Managed by Property: Hadd1
		private FixedString HADD1 = new FixedString(35);

		// HADD2 - MFG HSING ADR 2
		// Managed by Property: Hadd2
		private FixedString HADD2 = new FixedString(35);

		// HFILL5 - FILLER 5
		// Managed by Property: Hfill5
		private FixedString HFILL5 = new FixedString(7);

		#endregion Variables

		#region Constructors

		public REMobh_Base()
		{
		}

		public REMobh_Base(IDBAccess db)
		{
			this.db = db;
		}

		public REMobh_Base(IDBAccess db, FixedDecimal HRECNO) : this(db)
		{
			this.HRECNO = HRECNO;

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
		/// Gets the Database Filename Separator.
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
				string fullFileName = this.dataBase + this.Separator + this.fileName;
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

		private string WhereClause
		{
			get
			{
				StringBuilder sb = new StringBuilder();
				sb.Append(" where ");
				sb.Append(" HRECNO = " + this.HRECNO.ToString());

				sb.Append(" ");
				return sb.ToString();
			}
		}

		private static string WhereClauseParameterized
		{
			get
			{
				StringBuilder sb = new StringBuilder();
				sb.Append(" where ");
				sb.Append(" HRECNO = @HRECNO ");

				sb.Append(" ");
				return sb.ToString();
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HID
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(1)
		/// <para>Description: RECORD ID CODE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Hid
		{
			get
			{
				return this.HID;
			}

			set
			{
				if (this.HID.checkValue(value))
				{
					this.HID.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hid Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HRECNO
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (5,0)
		/// <para>Description: MOB HOME REC NO</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Hrecno
		{
			get
			{
				return this.HRECNO;
			}

			set
			{
				if (this.HRECNO.checkValue(value))
				{
					this.HRECNO.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hrecno Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HFILL1
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(2)
		/// <para>Description: FILLER 1</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Hfill1
		{
			get
			{
				return this.HFILL1;
			}

			set
			{
				if (this.HFILL1.checkValue(value))
				{
					this.HFILL1.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hfill1 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HLNAM
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(35)
		/// <para>Description: LAST NAME</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Hlnam
		{
			get
			{
				return this.HLNAM;
			}

			set
			{
				if (this.HLNAM.checkValue(value))
				{
					this.HLNAM.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hlnam Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HPPACT
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (7,0)
		/// <para>Description: PERS PROP ACCT#</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Hppact
		{
			get
			{
				return this.HPPACT;
			}

			set
			{
				if (this.HPPACT.checkValue(value))
				{
					this.HPPACT.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hppact Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HPPSEQ
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (4,0)
		/// <para>Description: PERS PROP SEQ#</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Hppseq
		{
			get
			{
				return this.HPPSEQ;
			}

			set
			{
				if (this.HPPSEQ.checkValue(value))
				{
					this.HPPSEQ.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hppseq Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HOSSN2
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (9,0)
		/// <para>Description: MH OWNER SOC SEC</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Hossn2
		{
			get
			{
				return this.HOSSN2;
			}

			set
			{
				if (this.HOSSN2.checkValue(value))
				{
					this.HOSSN2.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hossn2 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HADD3
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(35)
		/// <para>Description: MH OWNER ADDR 3</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Hadd3
		{
			get
			{
				return this.HADD3;
			}

			set
			{
				if (this.HADD3.checkValue(value))
				{
					this.HADD3.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hadd3 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HPRVAL
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (9,0)
		/// <para>Description: MH PRIOR YR VALU</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Hprval
		{
			get
			{
				return this.HPRVAL;
			}

			set
			{
				if (this.HPRVAL.checkValue(value))
				{
					this.HPRVAL.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hprval Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HFACTR
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (3,2)
		/// <para>Description: MH FACTOR</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Hfactr
		{
			get
			{
				return this.HFACTR;
			}

			set
			{
				if (this.HFACTR.checkValue(value))
				{
					this.HFACTR.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hfactr Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HDEPRC
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (3,2)
		/// <para>Description: MH DEPREC</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Hdeprc
		{
			get
			{
				return this.HDEPRC;
			}

			set
			{
				if (this.HDEPRC.checkValue(value))
				{
					this.HDEPRC.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hdeprc Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HTOTOI
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (9,0)
		/// <para>Description: MH TOTAL OTH IMP</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Htotoi
		{
			get
			{
				return this.HTOTOI;
			}

			set
			{
				if (this.HTOTOI.checkValue(value))
				{
					this.HTOTOI.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Htotoi Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HMHVAL
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (9,0)
		/// <para>Description: MH VALUE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Hmhval
		{
			get
			{
				return this.HMHVAL;
			}

			set
			{
				if (this.HMHVAL.checkValue(value))
				{
					this.HMHVAL.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hmhval Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HTOTPR
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (10,0)
		/// <para>Description: TOTAL PROP VALUE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Htotpr
		{
			get
			{
				return this.HTOTPR;
			}

			set
			{
				if (this.HTOTPR.checkValue(value))
				{
					this.HTOTPR.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Htotpr Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HMHBAS
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (9,0)
		/// <para>Description: MH BASE VALUE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Hmhbas
		{
			get
			{
				return this.HMHBAS;
			}

			set
			{
				if (this.HMHBAS.checkValue(value))
				{
					this.HMHBAS.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hmhbas Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HSWDW
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(2)
		/// <para>Description: SW/DW CODE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Hswdw
		{
			get
			{
				return this.HSWDW;
			}

			set
			{
				if (this.HSWDW.checkValue(value))
				{
					this.HSWDW.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hswdw Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HMAKE
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(10)
		/// <para>Description: MH MAKE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Hmake
		{
			get
			{
				return this.HMAKE;
			}

			set
			{
				if (this.HMAKE.checkValue(value))
				{
					this.HMAKE.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hmake Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HMODEL
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(15)
		/// <para>Description: MH MODEL</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Hmodel
		{
			get
			{
				return this.HMODEL;
			}

			set
			{
				if (this.HMODEL.checkValue(value))
				{
					this.HMODEL.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hmodel Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HBODY
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(15)
		/// <para>Description: MH BODY</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Hbody
		{
			get
			{
				return this.HBODY;
			}

			set
			{
				if (this.HBODY.checkValue(value))
				{
					this.HBODY.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hbody Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HOZIP
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (5,0)
		/// <para>Description: MH OWNER ZIP</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Hozip
		{
			get
			{
				return this.HOZIP;
			}

			set
			{
				if (this.HOZIP.checkValue(value))
				{
					this.HOZIP.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hozip Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HAC
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(1)
		/// <para>Description: AIR CONDITIONING</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Hac
		{
			get
			{
				return this.HAC;
			}

			set
			{
				if (this.HAC.checkValue(value))
				{
					this.HAC.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hac Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HPURDT
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (8,0)
		/// <para>Description: PURCH DATE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Hpurdt
		{
			get
			{
				return this.HPURDT;
			}

			set
			{
				if (this.HPURDT.checkValue(value))
				{
					this.HPURDT.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hpurdt Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HFAIRV
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (6,0)
		/// <para>Description: FAIR VALUE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Hfairv
		{
			get
			{
				return this.HFAIRV;
			}

			set
			{
				if (this.HFAIRV.checkValue(value))
				{
					this.HFAIRV.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hfairv Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HOVRRT
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (4,2)
		/// <para>Description: OVERRIDE RATE PSF</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Hovrrt
		{
			get
			{
				return this.HOVRRT;
			}

			set
			{
				if (this.HOVRRT.checkValue(value))
				{
					this.HOVRRT.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hovrrt Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HMAP_NUM
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(20)
		/// <para>Description: TAX MAP NO</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Hmap_num
		{
			get
			{
				return this.HMAP_NUM;
			}

			set
			{
				if (this.HMAP_NUM.checkValue(value))
				{
					this.HMAP_NUM.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hmap_num Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HLOT_NUM
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(8)
		/// <para>Description: LOT NO</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Hlot_num
		{
			get
			{
				return this.HLOT_NUM;
			}

			set
			{
				if (this.HLOT_NUM.checkValue(value))
				{
					this.HLOT_NUM.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hlot_num Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HFILL3
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(2)
		/// <para>Description: FILLER 3</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Hfill3
		{
			get
			{
				return this.HFILL3;
			}

			set
			{
				if (this.HFILL3.checkValue(value))
				{
					this.HFILL3.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hfill3 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HYEAR
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (4,0)
		/// <para>Description: YEAR</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Hyear
		{
			get
			{
				return this.HYEAR;
			}

			set
			{
				if (this.HYEAR.checkValue(value))
				{
					this.HYEAR.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hyear Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HCOND
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(1)
		/// <para>Description: CONDITION</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Hcond
		{
			get
			{
				return this.HCOND;
			}

			set
			{
				if (this.HCOND.checkValue(value))
				{
					this.HCOND.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hcond Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HLEN
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (4,1)
		/// <para>Description: LENGTH</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Hlen
		{
			get
			{
				return this.HLEN;
			}

			set
			{
				if (this.HLEN.checkValue(value))
				{
					this.HLEN.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hlen Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HWID
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (4,1)
		/// <para>Description: WIDTH</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Hwid
		{
			get
			{
				return this.HWID;
			}

			set
			{
				if (this.HWID.checkValue(value))
				{
					this.HWID.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hwid Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HREM1
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(35)
		/// <para>Description: REMARKS 1</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Hrem1
		{
			get
			{
				return this.HREM1;
			}

			set
			{
				if (this.HREM1.checkValue(value))
				{
					this.HREM1.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hrem1 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HREM2
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(35)
		/// <para>Description: REMARKS 2</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Hrem2
		{
			get
			{
				return this.HREM2;
			}

			set
			{
				if (this.HREM2.checkValue(value))
				{
					this.HREM2.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hrem2 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HVALUE
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (9,2)
		/// <para>Description: VALUE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Hvalue
		{
			get
			{
				return this.HVALUE;
			}

			set
			{
				if (this.HVALUE.checkValue(value))
				{
					this.HVALUE.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hvalue Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HMREC_NUM
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (7,0)
		/// <para>Description: PARCEL MASTER REC NO</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Hmrec_num
		{
			get
			{
				return this.HMREC_NUM;
			}

			set
			{
				if (this.HMREC_NUM.checkValue(value))
				{
					this.HMREC_NUM.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hmrec_num Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HONAME
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(35)
		/// <para>Description: OWNER NAME</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Honame
		{
			get
			{
				return this.HONAME;
			}

			set
			{
				if (this.HONAME.checkValue(value))
				{
					this.HONAME.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Honame Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HOSSN
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (9,0)
		/// <para>Description: OWNER SOC SEC NO</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Hossn
		{
			get
			{
				return this.HOSSN;
			}

			set
			{
				if (this.HOSSN.checkValue(value))
				{
					this.HOSSN.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hossn Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HMDWL
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: MASTER REC# DWELL #</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Hmdwl
		{
			get
			{
				return this.HMDWL;
			}

			set
			{
				if (this.HMDWL.checkValue(value))
				{
					this.HMDWL.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hmdwl Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HTITL_NUM
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(8)
		/// <para>Description: TITLE#</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Htitl_num
		{
			get
			{
				return this.HTITL_NUM;
			}

			set
			{
				if (this.HTITL_NUM.checkValue(value))
				{
					this.HTITL_NUM.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Htitl_num Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HTITDT
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (8,0)
		/// <para>Description: TITLE DATE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Htitdt
		{
			get
			{
				return this.HTITDT;
			}

			set
			{
				if (this.HTITDT.checkValue(value))
				{
					this.HTITDT.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Htitdt Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HWGHT
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (6,0)
		/// <para>Description: WEIGHT</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Hwght
		{
			get
			{
				return this.HWGHT;
			}

			set
			{
				if (this.HWGHT.checkValue(value))
				{
					this.HWGHT.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hwght Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HID_NUM
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(20)
		/// <para>Description: ID#-VIN NO.</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Hid_num
		{
			get
			{
				return this.HID_NUM;
			}

			set
			{
				if (this.HID_NUM.checkValue(value))
				{
					this.HID_NUM.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hid_num Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HPURCH
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (6,0)
		/// <para>Description: PURCHASE PRICE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Hpurch
		{
			get
			{
				return this.HPURCH;
			}

			set
			{
				if (this.HPURCH.checkValue(value))
				{
					this.HPURCH.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hpurch Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HADD1
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(35)
		/// <para>Description: MFG HSING ADR 1</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Hadd1
		{
			get
			{
				return this.HADD1;
			}

			set
			{
				if (this.HADD1.checkValue(value))
				{
					this.HADD1.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hadd1 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HADD2
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(35)
		/// <para>Description: MFG HSING ADR 2</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Hadd2
		{
			get
			{
				return this.HADD2;
			}

			set
			{
				if (this.HADD2.checkValue(value))
				{
					this.HADD2.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hadd2 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - HFILL5
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(7)
		/// <para>Description: FILLER 5</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Hfill5
		{
			get
			{
				return this.HFILL5;
			}

			set
			{
				if (this.HFILL5.checkValue(value))
				{
					this.HFILL5.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Hfill5 Property.");
				}
			}
		}

		#endregion Properties

		#region Public Static Methods

		/// <summary>
		/// Builds a parameterized string for Updating the file.
		/// </summary>
		/// <param name="QualifiedDatabaseAndTableName">The qualified database and Table name for the update.</param>
		/// <example>string sql = REMobh.ParameterizedUpdateSQL("database.table");
		/// </example>
		/// <returns>The parameterized SQL statement.</returns>
		public static string ParameterizedUpdateSQL(string QualifiedDatabaseAndTableName)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("update ");
			sb.Append(QualifiedDatabaseAndTableName);
			sb.Append(" set ");
			string[] updFieldsActual = REMobh.nonKeyFieldsActual.Split(new char[] { ',' });
			string[] updFieldsAdjusted = REMobh.nonKeyFieldsAdjusted.Split(new char[] { ',' });
			for (int i = 0; i < updFieldsActual.Length; i++)
			{
				if (i > 0)
				{
					sb.Append(", ");
				}
				sb.Append(updFieldsActual[i]);
				sb.Append(" = @");
				sb.Append(updFieldsAdjusted[i]);
			}
			sb.Append(WhereClauseParameterized);
			return sb.ToString();
		}

		/// <summary>
		/// Builds a parameterized string for Inserting into the file.
		/// </summary>
		/// <param name="QualifiedDatabaseAndTableName">The qualified database and Table name for the update.</param>
		/// <example>string sql = REMobh.ParameterizedInsertSQL("database.table");
		/// </example>
		/// <returns>The parameterized SQL statement.</returns>
		public static string ParameterizedInsertSQL(string QualifiedDatabaseAndTableName)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("insert into ");
			sb.Append(QualifiedDatabaseAndTableName);
			sb.Append(" (");
			sb.Append(REMobh.allFieldNamesActual);
			sb.Append(") ");
			sb.Append("values( ");
			string[] insFields = REMobh.allFieldNamesAdjusted.Split(new char[] { ',' });
			for (int i = 0; i < insFields.Length; i++)
			{
				if (i > 0)
				{
					sb.Append(", ");
				}
				sb.Append("@");
				sb.Append(insFields[i]);
			}
			sb.Append(" ) ");
			return sb.ToString();
		}

		/// <summary>
		/// A generic List of IDbDataParameter objects.  Useful for Parameterized queries.
		/// </summary>
		/// <param name="db"></param>
		/// <returns></returns>
		public static List<IDataParameter> ParameterCollection(DBAccessManager db)
		{
			List<IDataParameter> parms = new List<IDataParameter>();
			IDataParameter parm_HID = db.CreateParameter("@HID", DatabaseConstants.DataTypes.Char, "HID", 1, 0);
			parms.Add(parm_HID);
			IDataParameter parm_HRECNO = db.CreateParameter("@HRECNO", DatabaseConstants.DataTypes.Char, "HRECNO", 5, 0);
			parms.Add(parm_HRECNO);
			IDataParameter parm_HFILL1 = db.CreateParameter("@HFILL1", DatabaseConstants.DataTypes.Char, "HFILL1", 2, 0);
			parms.Add(parm_HFILL1);
			IDataParameter parm_HLNAM = db.CreateParameter("@HLNAM", DatabaseConstants.DataTypes.Char, "HLNAM", 35, 0);
			parms.Add(parm_HLNAM);
			IDataParameter parm_HPPACT = db.CreateParameter("@HPPACT", DatabaseConstants.DataTypes.Char, "HPPACT", 7, 0);
			parms.Add(parm_HPPACT);
			IDataParameter parm_HPPSEQ = db.CreateParameter("@HPPSEQ", DatabaseConstants.DataTypes.Char, "HPPSEQ", 4, 0);
			parms.Add(parm_HPPSEQ);
			IDataParameter parm_HOSSN2 = db.CreateParameter("@HOSSN2", DatabaseConstants.DataTypes.Char, "HOSSN2", 9, 0);
			parms.Add(parm_HOSSN2);
			IDataParameter parm_HADD3 = db.CreateParameter("@HADD3", DatabaseConstants.DataTypes.Char, "HADD3", 35, 0);
			parms.Add(parm_HADD3);
			IDataParameter parm_HPRVAL = db.CreateParameter("@HPRVAL", DatabaseConstants.DataTypes.Char, "HPRVAL", 9, 0);
			parms.Add(parm_HPRVAL);
			IDataParameter parm_HFACTR = db.CreateParameter("@HFACTR", DatabaseConstants.DataTypes.Char, "HFACTR", 3, 2);
			parms.Add(parm_HFACTR);
			IDataParameter parm_HDEPRC = db.CreateParameter("@HDEPRC", DatabaseConstants.DataTypes.Char, "HDEPRC", 3, 2);
			parms.Add(parm_HDEPRC);
			IDataParameter parm_HTOTOI = db.CreateParameter("@HTOTOI", DatabaseConstants.DataTypes.Char, "HTOTOI", 9, 0);
			parms.Add(parm_HTOTOI);
			IDataParameter parm_HMHVAL = db.CreateParameter("@HMHVAL", DatabaseConstants.DataTypes.Char, "HMHVAL", 9, 0);
			parms.Add(parm_HMHVAL);
			IDataParameter parm_HTOTPR = db.CreateParameter("@HTOTPR", DatabaseConstants.DataTypes.Char, "HTOTPR", 10, 0);
			parms.Add(parm_HTOTPR);
			IDataParameter parm_HMHBAS = db.CreateParameter("@HMHBAS", DatabaseConstants.DataTypes.Char, "HMHBAS", 9, 0);
			parms.Add(parm_HMHBAS);
			IDataParameter parm_HSWDW = db.CreateParameter("@HSWDW", DatabaseConstants.DataTypes.Char, "HSWDW", 2, 0);
			parms.Add(parm_HSWDW);
			IDataParameter parm_HMAKE = db.CreateParameter("@HMAKE", DatabaseConstants.DataTypes.Char, "HMAKE", 10, 0);
			parms.Add(parm_HMAKE);
			IDataParameter parm_HMODEL = db.CreateParameter("@HMODEL", DatabaseConstants.DataTypes.Char, "HMODEL", 15, 0);
			parms.Add(parm_HMODEL);
			IDataParameter parm_HBODY = db.CreateParameter("@HBODY", DatabaseConstants.DataTypes.Char, "HBODY", 15, 0);
			parms.Add(parm_HBODY);
			IDataParameter parm_HOZIP = db.CreateParameter("@HOZIP", DatabaseConstants.DataTypes.Char, "HOZIP", 5, 0);
			parms.Add(parm_HOZIP);
			IDataParameter parm_HAC = db.CreateParameter("@HAC", DatabaseConstants.DataTypes.Char, "HAC", 1, 0);
			parms.Add(parm_HAC);
			IDataParameter parm_HPURDT = db.CreateParameter("@HPURDT", DatabaseConstants.DataTypes.Char, "HPURDT", 8, 0);
			parms.Add(parm_HPURDT);
			IDataParameter parm_HFAIRV = db.CreateParameter("@HFAIRV", DatabaseConstants.DataTypes.Char, "HFAIRV", 6, 0);
			parms.Add(parm_HFAIRV);
			IDataParameter parm_HOVRRT = db.CreateParameter("@HOVRRT", DatabaseConstants.DataTypes.Char, "HOVRRT", 4, 2);
			parms.Add(parm_HOVRRT);
			IDataParameter parm_HMAP_NUM = db.CreateParameter("@HMAP_NUM", DatabaseConstants.DataTypes.Char, "HMAP#", 20, 0);
			parms.Add(parm_HMAP_NUM);
			IDataParameter parm_HLOT_NUM = db.CreateParameter("@HLOT_NUM", DatabaseConstants.DataTypes.Char, "HLOT#", 8, 0);
			parms.Add(parm_HLOT_NUM);
			IDataParameter parm_HFILL3 = db.CreateParameter("@HFILL3", DatabaseConstants.DataTypes.Char, "HFILL3", 2, 0);
			parms.Add(parm_HFILL3);
			IDataParameter parm_HYEAR = db.CreateParameter("@HYEAR", DatabaseConstants.DataTypes.Char, "HYEAR", 4, 0);
			parms.Add(parm_HYEAR);
			IDataParameter parm_HCOND = db.CreateParameter("@HCOND", DatabaseConstants.DataTypes.Char, "HCOND", 1, 0);
			parms.Add(parm_HCOND);
			IDataParameter parm_HLEN = db.CreateParameter("@HLEN", DatabaseConstants.DataTypes.Char, "HLEN", 4, 1);
			parms.Add(parm_HLEN);
			IDataParameter parm_HWID = db.CreateParameter("@HWID", DatabaseConstants.DataTypes.Char, "HWID", 4, 1);
			parms.Add(parm_HWID);
			IDataParameter parm_HREM1 = db.CreateParameter("@HREM1", DatabaseConstants.DataTypes.Char, "HREM1", 35, 0);
			parms.Add(parm_HREM1);
			IDataParameter parm_HREM2 = db.CreateParameter("@HREM2", DatabaseConstants.DataTypes.Char, "HREM2", 35, 0);
			parms.Add(parm_HREM2);
			IDataParameter parm_HVALUE = db.CreateParameter("@HVALUE", DatabaseConstants.DataTypes.Char, "HVALUE", 9, 2);
			parms.Add(parm_HVALUE);
			IDataParameter parm_HMREC_NUM = db.CreateParameter("@HMREC_NUM", DatabaseConstants.DataTypes.Char, "HMREC#", 7, 0);
			parms.Add(parm_HMREC_NUM);
			IDataParameter parm_HONAME = db.CreateParameter("@HONAME", DatabaseConstants.DataTypes.Char, "HONAME", 35, 0);
			parms.Add(parm_HONAME);
			IDataParameter parm_HOSSN = db.CreateParameter("@HOSSN", DatabaseConstants.DataTypes.Char, "HOSSN", 9, 0);
			parms.Add(parm_HOSSN);
			IDataParameter parm_HMDWL = db.CreateParameter("@HMDWL", DatabaseConstants.DataTypes.Char, "HMDWL", 2, 0);
			parms.Add(parm_HMDWL);
			IDataParameter parm_HTITL_NUM = db.CreateParameter("@HTITL_NUM", DatabaseConstants.DataTypes.Char, "HTITL#", 8, 0);
			parms.Add(parm_HTITL_NUM);
			IDataParameter parm_HTITDT = db.CreateParameter("@HTITDT", DatabaseConstants.DataTypes.Char, "HTITDT", 8, 0);
			parms.Add(parm_HTITDT);
			IDataParameter parm_HWGHT = db.CreateParameter("@HWGHT", DatabaseConstants.DataTypes.Char, "HWGHT", 6, 0);
			parms.Add(parm_HWGHT);
			IDataParameter parm_HID_NUM = db.CreateParameter("@HID_NUM", DatabaseConstants.DataTypes.Char, "HID#", 20, 0);
			parms.Add(parm_HID_NUM);
			IDataParameter parm_HPURCH = db.CreateParameter("@HPURCH", DatabaseConstants.DataTypes.Char, "HPURCH", 6, 0);
			parms.Add(parm_HPURCH);
			IDataParameter parm_HADD1 = db.CreateParameter("@HADD1", DatabaseConstants.DataTypes.Char, "HADD1", 35, 0);
			parms.Add(parm_HADD1);
			IDataParameter parm_HADD2 = db.CreateParameter("@HADD2", DatabaseConstants.DataTypes.Char, "HADD2", 35, 0);
			parms.Add(parm_HADD2);
			IDataParameter parm_HFILL5 = db.CreateParameter("@HFILL5", DatabaseConstants.DataTypes.Char, "HFILL5", 7, 0);
			parms.Add(parm_HFILL5);

			return parms;
		}

		#endregion Public Static Methods

		#region Public Methods

		/// <summary>
		/// Populates the Parameter collection and Executes the passed command.  Only used for Parameterized Non-Select statements.
		/// </summary>
		/// <param name="comm">The parameterized command to execute.</param>
		/// <returns>The number of rows affected by the command.</returns>
		public int ExecuteByDataParameterCollection(IDbCommand comm)
		{
			int rowCount = 0;
			try
			{
				this.db.SetParameterValue(comm.Parameters, "@HID", this.HID.Value);
				this.db.SetParameterValue(comm.Parameters, "@HRECNO", this.HRECNO.Value);
				this.db.SetParameterValue(comm.Parameters, "@HFILL1", this.HFILL1.Value);
				this.db.SetParameterValue(comm.Parameters, "@HLNAM", this.HLNAM.Value);
				this.db.SetParameterValue(comm.Parameters, "@HPPACT", this.HPPACT.Value);
				this.db.SetParameterValue(comm.Parameters, "@HPPSEQ", this.HPPSEQ.Value);
				this.db.SetParameterValue(comm.Parameters, "@HOSSN2", this.HOSSN2.Value);
				this.db.SetParameterValue(comm.Parameters, "@HADD3", this.HADD3.Value);
				this.db.SetParameterValue(comm.Parameters, "@HPRVAL", this.HPRVAL.Value);
				this.db.SetParameterValue(comm.Parameters, "@HFACTR", this.HFACTR.Value);
				this.db.SetParameterValue(comm.Parameters, "@HDEPRC", this.HDEPRC.Value);
				this.db.SetParameterValue(comm.Parameters, "@HTOTOI", this.HTOTOI.Value);
				this.db.SetParameterValue(comm.Parameters, "@HMHVAL", this.HMHVAL.Value);
				this.db.SetParameterValue(comm.Parameters, "@HTOTPR", this.HTOTPR.Value);
				this.db.SetParameterValue(comm.Parameters, "@HMHBAS", this.HMHBAS.Value);
				this.db.SetParameterValue(comm.Parameters, "@HSWDW", this.HSWDW.Value);
				this.db.SetParameterValue(comm.Parameters, "@HMAKE", this.HMAKE.Value);
				this.db.SetParameterValue(comm.Parameters, "@HMODEL", this.HMODEL.Value);
				this.db.SetParameterValue(comm.Parameters, "@HBODY", this.HBODY.Value);
				this.db.SetParameterValue(comm.Parameters, "@HOZIP", this.HOZIP.Value);
				this.db.SetParameterValue(comm.Parameters, "@HAC", this.HAC.Value);
				this.db.SetParameterValue(comm.Parameters, "@HPURDT", this.HPURDT.Value);
				this.db.SetParameterValue(comm.Parameters, "@HFAIRV", this.HFAIRV.Value);
				this.db.SetParameterValue(comm.Parameters, "@HOVRRT", this.HOVRRT.Value);
				this.db.SetParameterValue(comm.Parameters, "@HMAP_NUM", this.HMAP_NUM.Value);
				this.db.SetParameterValue(comm.Parameters, "@HLOT_NUM", this.HLOT_NUM.Value);
				this.db.SetParameterValue(comm.Parameters, "@HFILL3", this.HFILL3.Value);
				this.db.SetParameterValue(comm.Parameters, "@HYEAR", this.HYEAR.Value);
				this.db.SetParameterValue(comm.Parameters, "@HCOND", this.HCOND.Value);
				this.db.SetParameterValue(comm.Parameters, "@HLEN", this.HLEN.Value);
				this.db.SetParameterValue(comm.Parameters, "@HWID", this.HWID.Value);
				this.db.SetParameterValue(comm.Parameters, "@HREM1", this.HREM1.Value);
				this.db.SetParameterValue(comm.Parameters, "@HREM2", this.HREM2.Value);
				this.db.SetParameterValue(comm.Parameters, "@HVALUE", this.HVALUE.Value);
				this.db.SetParameterValue(comm.Parameters, "@HMREC_NUM", this.HMREC_NUM.Value);
				this.db.SetParameterValue(comm.Parameters, "@HONAME", this.HONAME.Value);
				this.db.SetParameterValue(comm.Parameters, "@HOSSN", this.HOSSN.Value);
				this.db.SetParameterValue(comm.Parameters, "@HMDWL", this.HMDWL.Value);
				this.db.SetParameterValue(comm.Parameters, "@HTITL_NUM", this.HTITL_NUM.Value);
				this.db.SetParameterValue(comm.Parameters, "@HTITDT", this.HTITDT.Value);
				this.db.SetParameterValue(comm.Parameters, "@HWGHT", this.HWGHT.Value);
				this.db.SetParameterValue(comm.Parameters, "@HID_NUM", this.HID_NUM.Value);
				this.db.SetParameterValue(comm.Parameters, "@HPURCH", this.HPURCH.Value);
				this.db.SetParameterValue(comm.Parameters, "@HADD1", this.HADD1.Value);
				this.db.SetParameterValue(comm.Parameters, "@HADD2", this.HADD2.Value);
				this.db.SetParameterValue(comm.Parameters, "@HFILL5", this.HFILL5.Value);

				rowCount = comm.ExecuteNonQuery();
			}
			catch (System.Exception ex)
			{
				Console.WriteLine(string.Format("Error: {0}", ex.Message));
			}
			return rowCount;
		}

		/// <summary>
		/// Populates the instance properties with data from the database table based on the
		/// current key settings.
		/// </summary>
		public bool populate()
		{
			bool isOK = false;
			this.lastException = null;
			try
			{
				StringBuilder sb = new StringBuilder();

				// Add code here to read table
				sb.Append("Select ");
				sb.Append(this.selectFields);
				sb.Append(" from ");
				sb.Append(this.FullFileName);
				sb.Append(this.WhereClause);

				string cmd = sb.ToString();
				rs = this.db.RunSelectStatement(cmd);
				dt = rs.Tables[0];
				dr = dt.Rows[0];

				this.HID.setValue(dr["HID"].ToString());
				this.HRECNO.setValue(dr["HRECNO"].ToString());
				this.HFILL1.setValue(dr["HFILL1"].ToString());
				this.HLNAM.setValue(dr["HLNAM"].ToString());
				this.HPPACT.setValue(dr["HPPACT"].ToString());
				this.HPPSEQ.setValue(dr["HPPSEQ"].ToString());
				this.HOSSN2.setValue(dr["HOSSN2"].ToString());
				this.HADD3.setValue(dr["HADD3"].ToString());
				this.HPRVAL.setValue(dr["HPRVAL"].ToString());
				this.HFACTR.setValue(dr["HFACTR"].ToString());
				this.HDEPRC.setValue(dr["HDEPRC"].ToString());
				this.HTOTOI.setValue(dr["HTOTOI"].ToString());
				this.HMHVAL.setValue(dr["HMHVAL"].ToString());
				this.HTOTPR.setValue(dr["HTOTPR"].ToString());
				this.HMHBAS.setValue(dr["HMHBAS"].ToString());
				this.HSWDW.setValue(dr["HSWDW"].ToString());
				this.HMAKE.setValue(dr["HMAKE"].ToString());
				this.HMODEL.setValue(dr["HMODEL"].ToString());
				this.HBODY.setValue(dr["HBODY"].ToString());
				this.HOZIP.setValue(dr["HOZIP"].ToString());
				this.HAC.setValue(dr["HAC"].ToString());
				this.HPURDT.setValue(dr["HPURDT"].ToString());
				this.HFAIRV.setValue(dr["HFAIRV"].ToString());
				this.HOVRRT.setValue(dr["HOVRRT"].ToString());
				this.HMAP_NUM.setValue(dr["HMAP_NUM"].ToString());
				this.HLOT_NUM.setValue(dr["HLOT_NUM"].ToString());
				this.HFILL3.setValue(dr["HFILL3"].ToString());
				this.HYEAR.setValue(dr["HYEAR"].ToString());
				this.HCOND.setValue(dr["HCOND"].ToString());
				this.HLEN.setValue(dr["HLEN"].ToString());
				this.HWID.setValue(dr["HWID"].ToString());
				this.HREM1.setValue(dr["HREM1"].ToString());
				this.HREM2.setValue(dr["HREM2"].ToString());
				this.HVALUE.setValue(dr["HVALUE"].ToString());
				this.HMREC_NUM.setValue(dr["HMREC_NUM"].ToString());
				this.HONAME.setValue(dr["HONAME"].ToString());
				this.HOSSN.setValue(dr["HOSSN"].ToString());
				this.HMDWL.setValue(dr["HMDWL"].ToString());
				this.HTITL_NUM.setValue(dr["HTITL_NUM"].ToString());
				this.HTITDT.setValue(dr["HTITDT"].ToString());
				this.HWGHT.setValue(dr["HWGHT"].ToString());
				this.HID_NUM.setValue(dr["HID_NUM"].ToString());
				this.HPURCH.setValue(dr["HPURCH"].ToString());
				this.HADD1.setValue(dr["HADD1"].ToString());
				this.HADD2.setValue(dr["HADD2"].ToString());
				this.HFILL5.setValue(dr["HFILL5"].ToString());

				isOK = true;
			}
			catch (System.Exception ex)
			{
				this.lastException = ex;
			}
			return isOK;
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
				sb.Append(" ( ");
				sb.Append(REMobh.allFieldNamesActual);
				sb.Append(" ) ");
				sb.Append("values( ");
				sb.Append("'" + this.HID.Text + "'");
				sb.Append(", ");
				sb.Append(this.HRECNO.ToString());
				sb.Append(", ");
				sb.Append("'" + this.HFILL1.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.HLNAM.Text + "'");
				sb.Append(", ");
				sb.Append(this.HPPACT.ToString());
				sb.Append(", ");
				sb.Append(this.HPPSEQ.ToString());
				sb.Append(", ");
				sb.Append(this.HOSSN2.ToString());
				sb.Append(", ");
				sb.Append("'" + this.HADD3.Text + "'");
				sb.Append(", ");
				sb.Append(this.HPRVAL.ToString());
				sb.Append(", ");
				sb.Append(this.HFACTR.ToString());
				sb.Append(", ");
				sb.Append(this.HDEPRC.ToString());
				sb.Append(", ");
				sb.Append(this.HTOTOI.ToString());
				sb.Append(", ");
				sb.Append(this.HMHVAL.ToString());
				sb.Append(", ");
				sb.Append(this.HTOTPR.ToString());
				sb.Append(", ");
				sb.Append(this.HMHBAS.ToString());
				sb.Append(", ");
				sb.Append("'" + this.HSWDW.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.HMAKE.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.HMODEL.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.HBODY.Text + "'");
				sb.Append(", ");
				sb.Append(this.HOZIP.ToString());
				sb.Append(", ");
				sb.Append("'" + this.HAC.Text + "'");
				sb.Append(", ");
				sb.Append(this.HPURDT.ToString());
				sb.Append(", ");
				sb.Append(this.HFAIRV.ToString());
				sb.Append(", ");
				sb.Append(this.HOVRRT.ToString());
				sb.Append(", ");
				sb.Append("'" + this.HMAP_NUM.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.HLOT_NUM.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.HFILL3.Text + "'");
				sb.Append(", ");
				sb.Append(this.HYEAR.ToString());
				sb.Append(", ");
				sb.Append("'" + this.HCOND.Text + "'");
				sb.Append(", ");
				sb.Append(this.HLEN.ToString());
				sb.Append(", ");
				sb.Append(this.HWID.ToString());
				sb.Append(", ");
				sb.Append("'" + this.HREM1.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.HREM2.Text + "'");
				sb.Append(", ");
				sb.Append(this.HVALUE.ToString());
				sb.Append(", ");
				sb.Append(this.HMREC_NUM.ToString());
				sb.Append(", ");
				sb.Append("'" + this.HONAME.Text + "'");
				sb.Append(", ");
				sb.Append(this.HOSSN.ToString());
				sb.Append(", ");
				sb.Append(this.HMDWL.ToString());
				sb.Append(", ");
				sb.Append("'" + this.HTITL_NUM.Text + "'");
				sb.Append(", ");
				sb.Append(this.HTITDT.ToString());
				sb.Append(", ");
				sb.Append(this.HWGHT.ToString());
				sb.Append(", ");
				sb.Append("'" + this.HID_NUM.Text + "'");
				sb.Append(", ");
				sb.Append(this.HPURCH.ToString());
				sb.Append(", ");
				sb.Append("'" + this.HADD1.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.HADD2.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.HFILL5.Text + "'");

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
				sb.Append("HID = '" + this.HID.Text + "'");
				sb.Append(", ");
				sb.Append("HRECNO = " + this.HRECNO.ToString());
				sb.Append(", ");
				sb.Append("HFILL1 = '" + this.HFILL1.Text + "'");
				sb.Append(", ");
				sb.Append("HLNAM = '" + this.HLNAM.Text + "'");
				sb.Append(", ");
				sb.Append("HPPACT = " + this.HPPACT.ToString());
				sb.Append(", ");
				sb.Append("HPPSEQ = " + this.HPPSEQ.ToString());
				sb.Append(", ");
				sb.Append("HOSSN2 = " + this.HOSSN2.ToString());
				sb.Append(", ");
				sb.Append("HADD3 = '" + this.HADD3.Text + "'");
				sb.Append(", ");
				sb.Append("HPRVAL = " + this.HPRVAL.ToString());
				sb.Append(", ");
				sb.Append("HFACTR = " + this.HFACTR.ToString());
				sb.Append(", ");
				sb.Append("HDEPRC = " + this.HDEPRC.ToString());
				sb.Append(", ");
				sb.Append("HTOTOI = " + this.HTOTOI.ToString());
				sb.Append(", ");
				sb.Append("HMHVAL = " + this.HMHVAL.ToString());
				sb.Append(", ");
				sb.Append("HTOTPR = " + this.HTOTPR.ToString());
				sb.Append(", ");
				sb.Append("HMHBAS = " + this.HMHBAS.ToString());
				sb.Append(", ");
				sb.Append("HSWDW = '" + this.HSWDW.Text + "'");
				sb.Append(", ");
				sb.Append("HMAKE = '" + this.HMAKE.Text + "'");
				sb.Append(", ");
				sb.Append("HMODEL = '" + this.HMODEL.Text + "'");
				sb.Append(", ");
				sb.Append("HBODY = '" + this.HBODY.Text + "'");
				sb.Append(", ");
				sb.Append("HOZIP = " + this.HOZIP.ToString());
				sb.Append(", ");
				sb.Append("HAC = '" + this.HAC.Text + "'");
				sb.Append(", ");
				sb.Append("HPURDT = " + this.HPURDT.ToString());
				sb.Append(", ");
				sb.Append("HFAIRV = " + this.HFAIRV.ToString());
				sb.Append(", ");
				sb.Append("HOVRRT = " + this.HOVRRT.ToString());
				sb.Append(", ");
				sb.Append("HMAP# = '" + this.HMAP_NUM.Text + "'");
				sb.Append(", ");
				sb.Append("HLOT# = '" + this.HLOT_NUM.Text + "'");
				sb.Append(", ");
				sb.Append("HFILL3 = '" + this.HFILL3.Text + "'");
				sb.Append(", ");
				sb.Append("HYEAR = " + this.HYEAR.ToString());
				sb.Append(", ");
				sb.Append("HCOND = '" + this.HCOND.Text + "'");
				sb.Append(", ");
				sb.Append("HLEN = " + this.HLEN.ToString());
				sb.Append(", ");
				sb.Append("HWID = " + this.HWID.ToString());
				sb.Append(", ");
				sb.Append("HREM1 = '" + this.HREM1.Text + "'");
				sb.Append(", ");
				sb.Append("HREM2 = '" + this.HREM2.Text + "'");
				sb.Append(", ");
				sb.Append("HVALUE = " + this.HVALUE.ToString());
				sb.Append(", ");
				sb.Append("HMREC# = " + this.HMREC_NUM.ToString());
				sb.Append(", ");
				sb.Append("HONAME = '" + this.HONAME.Text + "'");
				sb.Append(", ");
				sb.Append("HOSSN = " + this.HOSSN.ToString());
				sb.Append(", ");
				sb.Append("HMDWL = " + this.HMDWL.ToString());
				sb.Append(", ");
				sb.Append("HTITL# = '" + this.HTITL_NUM.Text + "'");
				sb.Append(", ");
				sb.Append("HTITDT = " + this.HTITDT.ToString());
				sb.Append(", ");
				sb.Append("HWGHT = " + this.HWGHT.ToString());
				sb.Append(", ");
				sb.Append("HID# = '" + this.HID_NUM.Text + "'");
				sb.Append(", ");
				sb.Append("HPURCH = " + this.HPURCH.ToString());
				sb.Append(", ");
				sb.Append("HADD1 = '" + this.HADD1.Text + "'");
				sb.Append(", ");
				sb.Append("HADD2 = '" + this.HADD2.Text + "'");
				sb.Append(", ");
				sb.Append("HFILL5 = '" + this.HFILL5.Text + "'");

				sb.Append(this.WhereClause);

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
		/// Deletes from the database table all records
		/// with the current key settings.
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
				sb.Append(this.WhereClause);

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

		#endregion Private Methods
	}
}