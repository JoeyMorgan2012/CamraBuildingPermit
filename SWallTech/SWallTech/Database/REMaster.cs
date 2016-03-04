using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SWallTech
{
	/* C# Bean representing the following Table:
        Library  : CAMRALIB
        Table    : CAFPMAST
        Created  : 11/1/2006 4:14:54 PM
        Generator: Stonewall Technologies BeanMaker 0.0.1
    */

	public class REMaster : IDBTable
	{
		#region Variables

		private string dataBase = "CAMRALIB";
		private string fileName = "CAFPMAST";
		private string separator = ".";
		private IDBAccess db;
		private DataSet rs;
		private DataTable dt;
		private DataRow dr;
		private Exception lastException = null;
		public static string allFieldNamesActual = "MRECID,MRECNO,MDWELL,MMAP,MLNAM,MFNAM,MADD1,MADD2,MCITY,MSTATE,MZIP5,MZIP4,MACRE,MZONE,MLUSE,MOCCUP,MSTORY,MAGE,MCOND,MCLASS,MFACTR,MDEPRC,MFOUND,MEXWLL,MROOFT,MROOFG,M#DUNT,M#ROOM,M#BR,M#FBTH,M#HBTH,MFP2,MLTRCD,MHEAT,MFUEL,MAC,MFP1,MCDR,MEKIT,MBASTP,MPBTOT,MSBTOT,MPBFIN,MSBFIN,MBRATE,M#FLUE,MFLUTP,MGART,MGAR#C,MCARPT,MCAR#C,MBI#C,MROW,MEASE,MWATER,MSEWER,MGAS,MELEC,MTERRN,MCHAR,MOTDES,MGART2,MGAR#2,MDATLG,MDATPR,MINTYP,MINTYR,MINNO#,MINNO2,MDSUFX,MWSUFX,MPSUFX,MIMPRV,MTOTLD,MTOTOI,MTOTPR,MASSB,MACPCT,M1FRNT,M1DPTH,M1AREA,MMCODE,M0DEPR,M1UM,M2FRNT,M2DPTH,M2AREA,MZIPBR,MDELAY,M2UM,MSTRT,MDIRCT,MHSE#,MCDMO,MCDDA,MCDYR,M1DFAC,MREM1,MREM2,MMAGCD,MATHOM,MDESC1,MDESC2,MDESC3,MDESC4,MFAIRV,MLGITY,MLGIYR,MLGNO#,MLGNO2,MSUBDV,MSELLP,M2DFAC,MINIT,MINSPD,MSWL,MTUTIL,MNBADJ,MASSL,MACSF,MCOMM1,MCOMM2,MCOMM3,MACCT,MEXWL2,MCALC,MFILL4,MTBV,MTBAS,MTFBAS,MTPLUM,MTHEAT,MTAC,MTFP,MTFL,MTBI,MTTADD,MTSUBT,MTOTBV,MUSRID,MBASA,MTOTA,MPSF,MINWLL,MFLOOR,MYRBLT,MCNST1,MCNST2,MASSLU,MMOSLD,MDASLD,MYRSLD,MTIME,MHSE#2,M1ADJ,M2ADJ,MLGBKC,MLGBK#,MLGPG#,MEFFAG,MPCOMP,MSTTYP,MSDIRS,M1RATE,M2RATE,MFUNCD,MECOND,MNBRHD,MUSER1,MUSER2,MDBOOK,MDPAGE,MWBOOK,MWPAGE,MDCODE,MWCODE,MMORTC,MFILL7,MACRE#,MGISPN,MUSER3,MUSER4,MIMADJ,MCDRDT,MMNUD,MMNNUD,MSS1,MPCODE,MPBOOK,MPPAGE,MSS2,MASSM,MFILL9,MGRNTR,MCVMO,MCVDA,MCVYR,MPROUT,MPERR,MTBIMP,MPUSE,MCVEXP,METXYR,MQAPCH,MQAFIL,MPICT,MEACRE,MPRCIT,MPRSTA,MPRZP1,MPRZP4,MFP#,MSFP#,MFL#,MSFL#,MMFL#,MIOFP#,MSTOR#,MASCOM,MHRPH#,MHRDAT,MHRTIM,MHRNAM,MHRSES,MHIDPC,MHIDNM,MCAMO,MCADA,MCAYR,MOLDOC";
		public static string allFieldNamesAdjusted = "MRECID,MRECNO,MDWELL,MMAP,MLNAM,MFNAM,MADD1,MADD2,MCITY,MSTATE,MZIP5,MZIP4,MACRE,MZONE,MLUSE,MOCCUP,MSTORY,MAGE,MCOND,MCLASS,MFACTR,MDEPRC,MFOUND,MEXWLL,MROOFT,MROOFG,M_NUMDUNT,M_NUMROOM,M_NUMBR,M_NUMFBTH,M_NUMHBTH,MFP2,MLTRCD,MHEAT,MFUEL,MAC,MFP1,MCDR,MEKIT,MBASTP,MPBTOT,MSBTOT,MPBFIN,MSBFIN,MBRATE,M_NUMFLUE,MFLUTP,MGART,MGAR_NUMC,MCARPT,MCAR_NUMC,MBI_NUMC,MROW,MEASE,MWATER,MSEWER,MGAS,MELEC,MTERRN,MCHAR,MOTDES,MGART2,MGAR_NUM2,MDATLG,MDATPR,MINTYP,MINTYR,MINNO_NUM,MINNO2,MDSUFX,MWSUFX,MPSUFX,MIMPRV,MTOTLD,MTOTOI,MTOTPR,MASSB,MACPCT,M1FRNT,M1DPTH,M1AREA,MMCODE,M0DEPR,M1UM,M2FRNT,M2DPTH,M2AREA,MZIPBR,MDELAY,M2UM,MSTRT,MDIRCT,MHSE_NUM,MCDMO,MCDDA,MCDYR,M1DFAC,MREM1,MREM2,MMAGCD,MATHOM,MDESC1,MDESC2,MDESC3,MDESC4,MFAIRV,MLGITY,MLGIYR,MLGNO_NUM,MLGNO2,MSUBDV,MSELLP,M2DFAC,MINIT,MINSPD,MSWL,MTUTIL,MNBADJ,MASSL,MACSF,MCOMM1,MCOMM2,MCOMM3,MACCT,MEXWL2,MCALC,MFILL4,MTBV,MTBAS,MTFBAS,MTPLUM,MTHEAT,MTAC,MTFP,MTFL,MTBI,MTTADD,MTSUBT,MTOTBV,MUSRID,MBASA,MTOTA,MPSF,MINWLL,MFLOOR,MYRBLT,MCNST1,MCNST2,MASSLU,MMOSLD,MDASLD,MYRSLD,MTIME,MHSE_NUM2,M1ADJ,M2ADJ,MLGBKC,MLGBK_NUM,MLGPG_NUM,MEFFAG,MPCOMP,MSTTYP,MSDIRS,M1RATE,M2RATE,MFUNCD,MECOND,MNBRHD,MUSER1,MUSER2,MDBOOK,MDPAGE,MWBOOK,MWPAGE,MDCODE,MWCODE,MMORTC,MFILL7,MACRE_NUM,MGISPN,MUSER3,MUSER4,MIMADJ,MCDRDT,MMNUD,MMNNUD,MSS1,MPCODE,MPBOOK,MPPAGE,MSS2,MASSM,MFILL9,MGRNTR,MCVMO,MCVDA,MCVYR,MPROUT,MPERR,MTBIMP,MPUSE,MCVEXP,METXYR,MQAPCH,MQAFIL,MPICT,MEACRE,MPRCIT,MPRSTA,MPRZP1,MPRZP4,MFP_NUM,MSFP_NUM,MFL_NUM,MSFL_NUM,MMFL_NUM,MIOFP_NUM,MSTOR_NUM,MASCOM,MHRPH_NUM,MHRDAT,MHRTIM,MHRNAM,MHRSES,MHIDPC,MHIDNM,MCAMO,MCADA,MCAYR,MOLDOC";
		public static string nonKeyFieldsActual = "MRECID,MMAP,MLNAM,MFNAM,MADD1,MADD2,MCITY,MSTATE,MZIP5,MZIP4,MACRE,MZONE,MLUSE,MOCCUP,MSTORY,MAGE,MCOND,MCLASS,MFACTR,MDEPRC,MFOUND,MEXWLL,MROOFT,MROOFG,M#DUNT,M#ROOM,M#BR,M#FBTH,M#HBTH,MFP2,MLTRCD,MHEAT,MFUEL,MAC,MFP1,MCDR,MEKIT,MBASTP,MPBTOT,MSBTOT,MPBFIN,MSBFIN,MBRATE,M#FLUE,MFLUTP,MGART,MGAR#C,MCARPT,MCAR#C,MBI#C,MROW,MEASE,MWATER,MSEWER,MGAS,MELEC,MTERRN,MCHAR,MOTDES,MGART2,MGAR#2,MDATLG,MDATPR,MINTYP,MINTYR,MINNO#,MINNO2,MDSUFX,MWSUFX,MPSUFX,MIMPRV,MTOTLD,MTOTOI,MTOTPR,MASSB,MACPCT,M1FRNT,M1DPTH,M1AREA,MMCODE,M0DEPR,M1UM,M2FRNT,M2DPTH,M2AREA,MZIPBR,MDELAY,M2UM,MSTRT,MDIRCT,MHSE#,MCDMO,MCDDA,MCDYR,M1DFAC,MREM1,MREM2,MMAGCD,MATHOM,MDESC1,MDESC2,MDESC3,MDESC4,MFAIRV,MLGITY,MLGIYR,MLGNO#,MLGNO2,MSUBDV,MSELLP,M2DFAC,MINIT,MINSPD,MSWL,MTUTIL,MNBADJ,MASSL,MACSF,MCOMM1,MCOMM2,MCOMM3,MACCT,MEXWL2,MCALC,MFILL4,MTBV,MTBAS,MTFBAS,MTPLUM,MTHEAT,MTAC,MTFP,MTFL,MTBI,MTTADD,MTSUBT,MTOTBV,MUSRID,MBASA,MTOTA,MPSF,MINWLL,MFLOOR,MYRBLT,MCNST1,MCNST2,MASSLU,MMOSLD,MDASLD,MYRSLD,MTIME,MHSE#2,M1ADJ,M2ADJ,MLGBKC,MLGBK#,MLGPG#,MEFFAG,MPCOMP,MSTTYP,MSDIRS,M1RATE,M2RATE,MFUNCD,MECOND,MNBRHD,MUSER1,MUSER2,MDBOOK,MDPAGE,MWBOOK,MWPAGE,MDCODE,MWCODE,MMORTC,MFILL7,MACRE#,MGISPN,MUSER3,MUSER4,MIMADJ,MCDRDT,MMNUD,MMNNUD,MSS1,MPCODE,MPBOOK,MPPAGE,MSS2,MASSM,MFILL9,MGRNTR,MCVMO,MCVDA,MCVYR,MPROUT,MPERR,MTBIMP,MPUSE,MCVEXP,METXYR,MQAPCH,MQAFIL,MPICT,MEACRE,MPRCIT,MPRSTA,MPRZP1,MPRZP4,MFP#,MSFP#,MFL#,MSFL#,MMFL#,MIOFP#,MSTOR#,MASCOM,MHRPH#,MHRDAT,MHRTIM,MHRNAM,MHRSES,MHIDPC,MHIDNM,MCAMO,MCADA,MCAYR,MOLDOC";
		public static string nonKeyFieldsAdjusted = "MRECID,MMAP,MLNAM,MFNAM,MADD1,MADD2,MCITY,MSTATE,MZIP5,MZIP4,MACRE,MZONE,MLUSE,MOCCUP,MSTORY,MAGE,MCOND,MCLASS,MFACTR,MDEPRC,MFOUND,MEXWLL,MROOFT,MROOFG,M_NUMDUNT,M_NUMROOM,M_NUMBR,M_NUMFBTH,M_NUMHBTH,MFP2,MLTRCD,MHEAT,MFUEL,MAC,MFP1,MCDR,MEKIT,MBASTP,MPBTOT,MSBTOT,MPBFIN,MSBFIN,MBRATE,M_NUMFLUE,MFLUTP,MGART,MGAR_NUMC,MCARPT,MCAR_NUMC,MBI_NUMC,MROW,MEASE,MWATER,MSEWER,MGAS,MELEC,MTERRN,MCHAR,MOTDES,MGART2,MGAR_NUM2,MDATLG,MDATPR,MINTYP,MINTYR,MINNO_NUM,MINNO2,MDSUFX,MWSUFX,MPSUFX,MIMPRV,MTOTLD,MTOTOI,MTOTPR,MASSB,MACPCT,M1FRNT,M1DPTH,M1AREA,MMCODE,M0DEPR,M1UM,M2FRNT,M2DPTH,M2AREA,MZIPBR,MDELAY,M2UM,MSTRT,MDIRCT,MHSE_NUM,MCDMO,MCDDA,MCDYR,M1DFAC,MREM1,MREM2,MMAGCD,MATHOM,MDESC1,MDESC2,MDESC3,MDESC4,MFAIRV,MLGITY,MLGIYR,MLGNO_NUM,MLGNO2,MSUBDV,MSELLP,M2DFAC,MINIT,MINSPD,MSWL,MTUTIL,MNBADJ,MASSL,MACSF,MCOMM1,MCOMM2,MCOMM3,MACCT,MEXWL2,MCALC,MFILL4,MTBV,MTBAS,MTFBAS,MTPLUM,MTHEAT,MTAC,MTFP,MTFL,MTBI,MTTADD,MTSUBT,MTOTBV,MUSRID,MBASA,MTOTA,MPSF,MINWLL,MFLOOR,MYRBLT,MCNST1,MCNST2,MASSLU,MMOSLD,MDASLD,MYRSLD,MTIME,MHSE_NUM2,M1ADJ,M2ADJ,MLGBKC,MLGBK_NUM,MLGPG_NUM,MEFFAG,MPCOMP,MSTTYP,MSDIRS,M1RATE,M2RATE,MFUNCD,MECOND,MNBRHD,MUSER1,MUSER2,MDBOOK,MDPAGE,MWBOOK,MWPAGE,MDCODE,MWCODE,MMORTC,MFILL7,MACRE_NUM,MGISPN,MUSER3,MUSER4,MIMADJ,MCDRDT,MMNUD,MMNNUD,MSS1,MPCODE,MPBOOK,MPPAGE,MSS2,MASSM,MFILL9,MGRNTR,MCVMO,MCVDA,MCVYR,MPROUT,MPERR,MTBIMP,MPUSE,MCVEXP,METXYR,MQAPCH,MQAFIL,MPICT,MEACRE,MPRCIT,MPRSTA,MPRZP1,MPRZP4,MFP_NUM,MSFP_NUM,MFL_NUM,MSFL_NUM,MMFL_NUM,MIOFP_NUM,MSTOR_NUM,MASCOM,MHRPH_NUM,MHRDAT,MHRTIM,MHRNAM,MHRSES,MHIDPC,MHIDNM,MCAMO,MCADA,MCAYR,MOLDOC";
		private string selectFields = "MRECID,MRECNO,MDWELL,MMAP,MLNAM,MFNAM,MADD1,MADD2,MCITY,MSTATE,MZIP5,MZIP4,MACRE,MZONE,MLUSE,MOCCUP,MSTORY,MAGE,MCOND,MCLASS,MFACTR,MDEPRC,MFOUND,MEXWLL,MROOFT,MROOFG,M#DUNT as M_NUMDUNT,M#ROOM as M_NUMROOM,M#BR as M_NUMBR,M#FBTH as M_NUMFBTH,M#HBTH as M_NUMHBTH,MFP2,MLTRCD,MHEAT,MFUEL,MAC,MFP1,MCDR,MEKIT,MBASTP,MPBTOT,MSBTOT,MPBFIN,MSBFIN,MBRATE,M#FLUE as M_NUMFLUE,MFLUTP,MGART,MGAR#C as MGAR_NUMC,MCARPT,MCAR#C as MCAR_NUMC,MBI#C as MBI_NUMC,MROW,MEASE,MWATER,MSEWER,MGAS,MELEC,MTERRN,MCHAR,MOTDES,MGART2,MGAR#2 as MGAR_NUM2,MDATLG,MDATPR,MINTYP,MINTYR,MINNO# as MINNO_NUM,MINNO2,MDSUFX,MWSUFX,MPSUFX,MIMPRV,MTOTLD,MTOTOI,MTOTPR,MASSB,MACPCT,M1FRNT,M1DPTH,M1AREA,MMCODE,M0DEPR,M1UM,M2FRNT,M2DPTH,M2AREA,MZIPBR,MDELAY,M2UM,MSTRT,MDIRCT,MHSE# as MHSE_NUM,MCDMO,MCDDA,MCDYR,M1DFAC,MREM1,MREM2,MMAGCD,MATHOM,MDESC1,MDESC2,MDESC3,MDESC4,MFAIRV,MLGITY,MLGIYR,MLGNO# as MLGNO_NUM,MLGNO2,MSUBDV,MSELLP,M2DFAC,MINIT,MINSPD,MSWL,MTUTIL,MNBADJ,MASSL,MACSF,MCOMM1,MCOMM2,MCOMM3,MACCT,MEXWL2,MCALC,MFILL4,MTBV,MTBAS,MTFBAS,MTPLUM,MTHEAT,MTAC,MTFP,MTFL,MTBI,MTTADD,MTSUBT,MTOTBV,MUSRID,MBASA,MTOTA,MPSF,MINWLL,MFLOOR,MYRBLT,MCNST1,MCNST2,MASSLU,MMOSLD,MDASLD,MYRSLD,MTIME,MHSE#2 as MHSE_NUM2,M1ADJ,M2ADJ,MLGBKC,MLGBK# as MLGBK_NUM,MLGPG# as MLGPG_NUM,MEFFAG,MPCOMP,MSTTYP,MSDIRS,M1RATE,M2RATE,MFUNCD,MECOND,MNBRHD,MUSER1,MUSER2,MDBOOK,MDPAGE,MWBOOK,MWPAGE,MDCODE,MWCODE,MMORTC,MFILL7,MACRE# as MACRE_NUM,MGISPN,MUSER3,MUSER4,MIMADJ,MCDRDT,MMNUD,MMNNUD,MSS1,MPCODE,MPBOOK,MPPAGE,MSS2,MASSM,MFILL9,MGRNTR,MCVMO,MCVDA,MCVYR,MPROUT,MPERR,MTBIMP,MPUSE,MCVEXP,METXYR,MQAPCH,MQAFIL,MPICT,MEACRE,MPRCIT,MPRSTA,MPRZP1,MPRZP4,MFP# as MFP_NUM,MSFP# as MSFP_NUM,MFL# as MFL_NUM,MSFL# as MSFL_NUM,MMFL# as MMFL_NUM,MIOFP# as MIOFP_NUM,MSTOR# as MSTOR_NUM,MASCOM,MHRPH# as MHRPH_NUM,MHRDAT,MHRTIM,MHRNAM,MHRSES,MHIDPC,MHIDNM,MCAMO,MCADA,MCAYR,MOLDOC";

		// MRECID - RECORD ID CODE
		// Managed by Property: Mrecid
		private FixedString MRECID = new FixedString(1);

		// MRECNO - RECORD NUMBER
		// Managed by Property: Mrecno
		private FixedDecimal MRECNO = new FixedDecimal(7, 0);

		// MDWELL - DWELLING NO
		// Managed by Property: Mdwell
		private FixedDecimal MDWELL = new FixedDecimal(2, 0);

		// MMAP - TAX MAP NO
		// Managed by Property: Mmap
		private FixedString MMAP = new FixedString(20);

		// MLNAM - OWNER NAME1
		// Managed by Property: Mlnam
		private FixedString MLNAM = new FixedString(35);

		// MFNAM - OWNER NAME2
		// Managed by Property: Mfnam
		private FixedString MFNAM = new FixedString(35);

		// MADD1 - OWNER ADDRESS 1
		// Managed by Property: Madd1
		private FixedString MADD1 = new FixedString(50);

		// MADD2 - OWNER ADDRESS 2
		// Managed by Property: Madd2
		private FixedString MADD2 = new FixedString(50);

		// MCITY - OWNER CITY
		// Managed by Property: Mcity
		private FixedString MCITY = new FixedString(25);

		// MSTATE - OWNER STATE
		// Managed by Property: Mstate
		private FixedString MSTATE = new FixedString(2);

		// MZIP5 - OWNER ZIP
		// Managed by Property: Mzip5
		private FixedDecimal MZIP5 = new FixedDecimal(5, 0);

		// MZIP4 - OWNER ZIP+4
		// Managed by Property: Mzip4
		private FixedString MZIP4 = new FixedString(4);

		// MACRE - TOTAL ACREAGE
		// Managed by Property: Macre
		private FixedString MACRE = new FixedString(9);

		// MZONE - ZONING
		// Managed by Property: Mzone
		private FixedString MZONE = new FixedString(4);

		// MLUSE - LAND USE CLASS
		// Managed by Property: Mluse
		private FixedString MLUSE = new FixedString(2);

		// MOCCUP - OCCUPANCY CODE
		// Managed by Property: Moccup
		private FixedDecimal MOCCUP = new FixedDecimal(2, 0);

		// MSTORY - STORY HEIGHT
		// Managed by Property: Mstory
		private FixedString MSTORY = new FixedString(3);

		// MAGE - AGE OF BLDG
		// Managed by Property: Mage
		private FixedDecimal MAGE = new FixedDecimal(3, 0);

		// MCOND - CONDITION
		// Managed by Property: Mcond
		private FixedString MCOND = new FixedString(1);

		// MCLASS - CLASS
		// Managed by Property: Mclass
		private FixedString MCLASS = new FixedString(1);

		// MFACTR - FACTOR
		// Managed by Property: Mfactr
		private FixedDecimal MFACTR = new FixedDecimal(3, 2);

		// MDEPRC - PHYSICAL DEPRECIATION
		// Managed by Property: Mdeprc
		private FixedDecimal MDEPRC = new FixedDecimal(3, 2);

		// MFOUND - FOUNDATION TYPE
		// Managed by Property: Mfound
		private FixedDecimal MFOUND = new FixedDecimal(2, 0);

		// MEXWLL - EXT. WALL TYPE
		// Managed by Property: Mexwll
		private FixedDecimal MEXWLL = new FixedDecimal(2, 0);

		// MROOFT - ROOF TYPE
		// Managed by Property: Mrooft
		private FixedDecimal MROOFT = new FixedDecimal(2, 0);

		// MROOFG - ROOFING MATERIAL
		// Managed by Property: Mroofg
		private FixedDecimal MROOFG = new FixedDecimal(2, 0);

		// M_NUMDUNT - NO. DWELLING UNITS
		// Managed by Property: M_numdunt
		private FixedDecimal M_NUMDUNT = new FixedDecimal(3, 0);

		// M_NUMROOM - NO. OF ROOMS
		// Managed by Property: M_numroom
		private FixedDecimal M_NUMROOM = new FixedDecimal(3, 0);

		// M_NUMBR - NO. OF BEDROOMS
		// Managed by Property: M_numbr
		private FixedDecimal M_NUMBR = new FixedDecimal(3, 0);

		// M_NUMFBTH - NO. OF FULL BATHS
		// Managed by Property: M_numfbth
		private FixedDecimal M_NUMFBTH = new FixedDecimal(2, 0);

		// M_NUMHBTH - NO. OF HALF BATHS
		// Managed by Property: M_numhbth
		private FixedDecimal M_NUMHBTH = new FixedDecimal(2, 0);

		// MFP2 - FIREPLACE CODE 2
		// Managed by Property: Mfp2
		private FixedString MFP2 = new FixedString(3);

		// MLTRCD - CHG/NO CHG ASSMT LTR
		// Managed by Property: Mltrcd
		private FixedString MLTRCD = new FixedString(1);

		// MHEAT - TYPE OF HEAT
		// Managed by Property: Mheat
		private FixedDecimal MHEAT = new FixedDecimal(2, 0);

		// MFUEL - TYPE OF FUEL
		// Managed by Property: Mfuel
		private FixedDecimal MFUEL = new FixedDecimal(2, 0);

		// MAC - AIR COND.(Y/N)
		// Managed by Property: Mac
		private FixedString MAC = new FixedString(1);

		// MFP1 - FIREPLACE CODE 1
		// Managed by Property: Mfp1
		private FixedString MFP1 = new FixedString(2);

		// MCDR - CHG DURING REASS
		// Managed by Property: Mcdr
		private FixedString MCDR = new FixedString(1);

		// MEKIT - NO. OF KITCHENS
		// Managed by Property: Mekit
		private FixedDecimal MEKIT = new FixedDecimal(1, 0);

		// MBASTP - BASEMENT TYPE CODE
		// Managed by Property: Mbastp
		private FixedDecimal MBASTP = new FixedDecimal(2, 0);

		// MPBTOT - BASEMENT PERCENT
		// Managed by Property: Mpbtot
		private FixedDecimal MPBTOT = new FixedDecimal(3, 2);

		// MSBTOT - BASEMENT SQ FT
		// Managed by Property: Msbtot
		private FixedDecimal MSBTOT = new FixedDecimal(6, 0);

		// MPBFIN - FIN BASMT PERCENT
		// Managed by Property: Mpbfin
		private FixedDecimal MPBFIN = new FixedDecimal(3, 2);

		// MSBFIN - FIN BASMT SQ FT
		// Managed by Property: Msbfin
		private FixedDecimal MSBFIN = new FixedDecimal(6, 0);

		// MBRATE - FIN BASMT RATE
		// Managed by Property: Mbrate
		private FixedDecimal MBRATE = new FixedDecimal(5, 2);

		// M_NUMFLUE - NO. OF FLUES
		// Managed by Property: M_numflue
		private FixedDecimal M_NUMFLUE = new FixedDecimal(2, 0);

		// MFLUTP - FLUE TYPE
		// Managed by Property: Mflutp
		private FixedString MFLUTP = new FixedString(1);

		// MGART - GARAGE TYPE
		// Managed by Property: Mgart
		private FixedDecimal MGART = new FixedDecimal(2, 0);

		// MGAR_NUMC - NO. CARS GARAGE
		// Managed by Property: Mgar_numc
		private FixedDecimal MGAR_NUMC = new FixedDecimal(2, 0);

		// MCARPT - CARPORT TYPE
		// Managed by Property: Mcarpt
		private FixedDecimal MCARPT = new FixedDecimal(2, 0);

		// MCAR_NUMC - NO. CARS CARPORT
		// Managed by Property: Mcar_numc
		private FixedDecimal MCAR_NUMC = new FixedDecimal(2, 0);

		// MBI_NUMC - NO. CARS BUILT-IN
		// Managed by Property: Mbi_numc
		private FixedDecimal MBI_NUMC = new FixedDecimal(2, 0);

		// MROW - RIGHT OF WAY
		// Managed by Property: Mrow
		private FixedDecimal MROW = new FixedDecimal(2, 0);

		// MEASE - EASEMENT
		// Managed by Property: Mease
		private FixedDecimal MEASE = new FixedDecimal(2, 0);

		// MWATER - WATER
		// Managed by Property: Mwater
		private FixedDecimal MWATER = new FixedDecimal(2, 0);

		// MSEWER - SEWER
		// Managed by Property: Msewer
		private FixedDecimal MSEWER = new FixedDecimal(2, 0);

		// MGAS - GAS
		// Managed by Property: Mgas
		private FixedString MGAS = new FixedString(1);

		// MELEC - ELECTRIC
		// Managed by Property: Melec
		private FixedString MELEC = new FixedString(1);

		// MTERRN - TERRAIN
		// Managed by Property: Mterrn
		private FixedDecimal MTERRN = new FixedDecimal(2, 0);

		// MCHAR - CHARACTERISTICS
		// Managed by Property: Mchar
		private FixedDecimal MCHAR = new FixedDecimal(2, 0);

		// MOTDES - OTHER DESCRIPTION
		// Managed by Property: Motdes
		private FixedString MOTDES = new FixedString(20);

		// MGART2 - GARAGE TYPE 2
		// Managed by Property: Mgart2
		private FixedDecimal MGART2 = new FixedDecimal(2, 0);

		// MGAR_NUM2 - NO. CARS GARAGE 2
		// Managed by Property: Mgar_num2
		private FixedDecimal MGAR_NUM2 = new FixedDecimal(2, 0);

		// MDATLG - LEGAL MOD DATE
		// Managed by Property: Mdatlg
		private FixedDecimal MDATLG = new FixedDecimal(8, 0);

		// MDATPR - PRORATE DATE
		// Managed by Property: Mdatpr
		private FixedDecimal MDATPR = new FixedDecimal(8, 0);

		// MINTYP - INSTRUMENT TYPE
		// Managed by Property: Mintyp
		private FixedString MINTYP = new FixedString(2);

		// MINTYR - INSTRUMENT YEAR
		// Managed by Property: Mintyr
		private FixedDecimal MINTYR = new FixedDecimal(4, 0);

		// MINNO_NUM - INSTRUMENT #
		// Managed by Property: Minno_num
		private FixedDecimal MINNO_NUM = new FixedDecimal(7, 0);

		// MINNO2 - INSTRUMENT # 2
		// Managed by Property: Minno2
		private FixedDecimal MINNO2 = new FixedDecimal(2, 0);

		// MDSUFX - DEED BK SUFFIX
		// Managed by Property: Mdsufx
		private FixedString MDSUFX = new FixedString(1);

		// MWSUFX - WILL BK SUFFIX
		// Managed by Property: Mwsufx
		private FixedString MWSUFX = new FixedString(1);

		// MPSUFX - PALT BK SUFFIX
		// Managed by Property: Mpsufx
		private FixedString MPSUFX = new FixedString(1);

		// MIMPRV - TOTAL IMPROVED VALUE
		// Managed by Property: Mimprv
		private FixedDecimal MIMPRV = new FixedDecimal(10, 0);

		// MTOTLD - TOTAL LAND VALUE
		// Managed by Property: Mtotld
		private FixedDecimal MTOTLD = new FixedDecimal(10, 0);

		// MTOTOI - OTHER IMPROV SUB-TOT
		// Managed by Property: Mtotoi
		private FixedDecimal MTOTOI = new FixedDecimal(10, 0);

		// MTOTPR - TOTAL PROPERTY VALUE
		// Managed by Property: Mtotpr
		private FixedDecimal MTOTPR = new FixedDecimal(10, 0);

		// MASSB - ASSESSMT IMPR FROM LOC
		// Managed by Property: Massb
		private FixedDecimal MASSB = new FixedDecimal(10, 0);

		// MACPCT - AIR COND % OF AREA
		// Managed by Property: Macpct
		private FixedDecimal MACPCT = new FixedDecimal(3, 2);

		// M1FRNT - #1 FRONTAGE
		// Managed by Property: M1frnt
		private FixedDecimal M1FRNT = new FixedDecimal(7, 2);

		// M1DPTH - #1 DEPTH
		// Managed by Property: M1dpth
		private FixedDecimal M1DPTH = new FixedDecimal(7, 2);

		// M1AREA - #1 AREA
		// Managed by Property: M1area
		private FixedDecimal M1AREA = new FixedDecimal(7, 0);

		// MMCODE - NO PARCELS IN SALE
		// Managed by Property: Mmcode
		private FixedDecimal MMCODE = new FixedDecimal(3, 0);

		// M0DEPR - 0 PHYS DEPREC
		// Managed by Property: M0depr
		private FixedString M0DEPR = new FixedString(1);

		// M1UM - #1 UNIT OF MEASURE
		// Managed by Property: M1um
		private FixedString M1UM = new FixedString(1);

		// M2FRNT - #2 FRONTAGE
		// Managed by Property: M2frnt
		private FixedDecimal M2FRNT = new FixedDecimal(7, 2);

		// M2DPTH - #2 DEPTH
		// Managed by Property: M2dpth
		private FixedDecimal M2DPTH = new FixedDecimal(7, 2);

		// M2AREA - #2 AREA
		// Managed by Property: M2area
		private FixedDecimal M2AREA = new FixedDecimal(7, 0);

		// MZIPBR - BAR CODE ZIP
		// Managed by Property: Mzipbr
		private FixedDecimal MZIPBR = new FixedDecimal(3, 0);

		// MDELAY - DELAY UPDATE TO REAL EST
		// Managed by Property: Mdelay
		private FixedString MDELAY = new FixedString(1);

		// M2UM - #2 UNIT OF MEASURE
		// Managed by Property: M2um
		private FixedString M2UM = new FixedString(1);

		// MSTRT - LOCATION STREET NAME
		// Managed by Property: Mstrt
		private FixedString MSTRT = new FixedString(17);

		// MDIRCT - LOCATION STREET DIRECT
		// Managed by Property: Mdirct
		private FixedString MDIRCT = new FixedString(2);

		// MHSE_NUM - LOCATION HOUSE NO.
		// Managed by Property: Mhse_num
		private FixedDecimal MHSE_NUM = new FixedDecimal(5, 0);

		// MCDMO - MONTH OF LAST CHANGE
		// Managed by Property: Mcdmo
		private FixedDecimal MCDMO = new FixedDecimal(2, 0);

		// MCDDA - DAY OF LAST CHANGE
		// Managed by Property: Mcdda
		private FixedDecimal MCDDA = new FixedDecimal(2, 0);

		// MCDYR - YEAR OF LAST CHANGE
		// Managed by Property: Mcdyr
		private FixedDecimal MCDYR = new FixedDecimal(4, 0);

		// M1DFAC - #1 DEPTH FACTOR
		// Managed by Property: M1dfac
		private FixedDecimal M1DFAC = new FixedDecimal(4, 3);

		// MREM1 - REMARKS 1
		// Managed by Property: Mrem1
		private FixedString MREM1 = new FixedString(35);

		// MREM2 - REMARKS 2
		// Managed by Property: Mrem2
		private FixedString MREM2 = new FixedString(35);

		// MMAGCD - MAGISTERIAL CODE
		// Managed by Property: Mmagcd
		private FixedString MMAGCD = new FixedString(2);

		// MATHOM - AT HOME Y/N
		// Managed by Property: Mathom
		private FixedString MATHOM = new FixedString(1);

		// MDESC1 - LEGAL DESCRIPTION 1
		// Managed by Property: Mdesc1
		private FixedString MDESC1 = new FixedString(35);

		// MDESC2 - LEGAL DESCRIPTION 2
		// Managed by Property: Mdesc2
		private FixedString MDESC2 = new FixedString(35);

		// MDESC3 - LEGAL DESCRIPTION 3
		// Managed by Property: Mdesc3
		private FixedString MDESC3 = new FixedString(35);

		// MDESC4 - LEGAL DESCRIPTION 4
		// Managed by Property: Mdesc4
		private FixedString MDESC4 = new FixedString(35);

		// MFAIRV - FAIR VALUE
		// Managed by Property: Mfairv
		private FixedDecimal MFAIRV = new FixedDecimal(8, 0);

		// MLGITY - LEGAL MOD DT INSTR TYPE
		// Managed by Property: Mlgity
		private FixedString MLGITY = new FixedString(2);

		// MLGIYR - LEGAL MOD DT INSTR YEAR
		// Managed by Property: Mlgiyr
		private FixedDecimal MLGIYR = new FixedDecimal(4, 0);

		// MLGNO_NUM - LEGAL MOD DT INSTR NUMB
		// Managed by Property: Mlgno_num
		private FixedDecimal MLGNO_NUM = new FixedDecimal(5, 0);

		// MLGNO2 - LEGAL MOD DT INSTR NO 2
		// Managed by Property: Mlgno2
		private FixedDecimal MLGNO2 = new FixedDecimal(2, 0);

		// MSUBDV - SUBDIVISION CODE
		// Managed by Property: Msubdv
		private FixedString MSUBDV = new FixedString(3);

		// MSELLP - SELLING PRICE
		// Managed by Property: Msellp
		private FixedDecimal MSELLP = new FixedDecimal(8, 0);

		// M2DFAC - #2 DEPTH FACTOR
		// Managed by Property: M2dfac
		private FixedDecimal M2DFAC = new FixedDecimal(4, 3);

		// MINIT - APPRAISOR INITIALS
		// Managed by Property: Minit
		private FixedString MINIT = new FixedString(5);

		// MINSPD - DATE INSPECTED
		// Managed by Property: Minspd
		private FixedDecimal MINSPD = new FixedDecimal(8, 0);

		// MSWL - SEW/WAT/LANDSCAPE VALUE
		// Managed by Property: Mswl
		private FixedDecimal MSWL = new FixedDecimal(5, 0);

		// MTUTIL - TOTAL UTILITY VALUE
		// Managed by Property: Mtutil
		private FixedDecimal MTUTIL = new FixedDecimal(5, 0);

		// MNBADJ - NEIGHBORHOOD ADJUSTMENT
		// Managed by Property: Mnbadj
		private FixedDecimal MNBADJ = new FixedDecimal(3, 2);

		// MASSL - ASSESSMT LAND FROM LOC
		// Managed by Property: Massl
		private FixedDecimal MASSL = new FixedDecimal(10, 0);

		// MACSF - AIR COND #SQ FT
		// Managed by Property: Macsf
		private FixedDecimal MACSF = new FixedDecimal(6, 0);

		// MCOMM1 - COMMENT LINE 1
		// Managed by Property: Mcomm1
		private FixedString MCOMM1 = new FixedString(25);

		// MCOMM2 - COMMENT LINE 2
		// Managed by Property: Mcomm2
		private FixedString MCOMM2 = new FixedString(25);

		// MCOMM3 - COMMENT LINE 3
		// Managed by Property: Mcomm3
		private FixedString MCOMM3 = new FixedString(25);

		// MACCT - ACCOUNT NUMBER
		// Managed by Property: Macct
		private FixedDecimal MACCT = new FixedDecimal(10, 0);

		// MEXWL2 - EXTERIOR WALL TYPE 2
		// Managed by Property: Mexwl2
		private FixedDecimal MEXWL2 = new FixedDecimal(2, 0);

		// MCALC - CALCULATED CODE
		// Managed by Property: Mcalc
		private FixedString MCALC = new FixedString(1);

		// MFILL4 - QUAL ASSUR MLT SAL
		// Managed by Property: Mfill4
		private FixedString MFILL4 = new FixedString(1);

		// MTBV - BUILDING VALUE
		// Managed by Property: Mtbv
		private FixedDecimal MTBV = new FixedDecimal(9, 0);

		// MTBAS - BASEMENT VALUE
		// Managed by Property: Mtbas
		private FixedDecimal MTBAS = new FixedDecimal(9, 0);

		// MTFBAS - FIN BSMT VALUE
		// Managed by Property: Mtfbas
		private FixedDecimal MTFBAS = new FixedDecimal(9, 0);

		// MTPLUM - PLUMBING VALUE
		// Managed by Property: Mtplum
		private FixedDecimal MTPLUM = new FixedDecimal(9, 0);

		// MTHEAT - HEATING VALUE
		// Managed by Property: Mtheat
		private FixedDecimal MTHEAT = new FixedDecimal(9, 0);

		// MTAC - AIR CONDITIONING VALUE
		// Managed by Property: Mtac
		private FixedDecimal MTAC = new FixedDecimal(9, 0);

		// MTFP - FIREPLACE VALUE
		// Managed by Property: Mtfp
		private FixedDecimal MTFP = new FixedDecimal(9, 0);

		// MTFL - FLUE VALUE
		// Managed by Property: Mtfl
		private FixedDecimal MTFL = new FixedDecimal(9, 0);

		// MTBI - BUILT-IN VALUE
		// Managed by Property: Mtbi
		private FixedDecimal MTBI = new FixedDecimal(9, 0);

		// MTTADD - ADDITIONS VALUE
		// Managed by Property: Mttadd
		private FixedDecimal MTTADD = new FixedDecimal(9, 0);

		// MTSUBT - SUBTOTAL VALUE
		// Managed by Property: Mtsubt
		private FixedDecimal MTSUBT = new FixedDecimal(9, 0);

		// MTOTBV - TOTAL BUILDING VALUE
		// Managed by Property: Mtotbv
		private FixedDecimal MTOTBV = new FixedDecimal(9, 0);

		// MUSRID - USER ID CODE
		// Managed by Property: Musrid
		private FixedString MUSRID = new FixedString(10);

		// MBASA - BASE AREA
		// Managed by Property: Mbasa
		private FixedDecimal MBASA = new FixedDecimal(7, 1);

		// MTOTA - TOTAL AREA
		// Managed by Property: Mtota
		private FixedDecimal MTOTA = new FixedDecimal(7, 1);

		// MPSF - PRICE PER SQ FT
		// Managed by Property: Mpsf
		private FixedDecimal MPSF = new FixedDecimal(5, 2);

		// MINWLL - INTERIOR WALL CODES
		// Managed by Property: Minwll
		private FixedString MINWLL = new FixedString(8);

		// MFLOOR - FLOOR CODES
		// Managed by Property: Mfloor
		private FixedString MFLOOR = new FixedString(8);

		// MYRBLT - YEAR BUILT
		// Managed by Property: Myrblt
		private FixedDecimal MYRBLT = new FixedDecimal(4, 0);

		// MCNST1 - CENSUS TRACT 1
		// Managed by Property: Mcnst1
		private FixedString MCNST1 = new FixedString(2);

		// MCNST2 - CENSUS TRACT 2
		// Managed by Property: Mcnst2
		private FixedString MCNST2 = new FixedString(2);

		// MASSLU - LAND USE VALUE FROM LOC
		// Managed by Property: Masslu
		private FixedDecimal MASSLU = new FixedDecimal(9, 0);

		// MMOSLD - MONTH SOLD
		// Managed by Property: Mmosld
		private FixedDecimal MMOSLD = new FixedDecimal(2, 0);

		// MDASLD - DAY SOLD
		// Managed by Property: Mdasld
		private FixedDecimal MDASLD = new FixedDecimal(2, 0);

		// MYRSLD - YEAR SOLD
		// Managed by Property: Myrsld
		private FixedDecimal MYRSLD = new FixedDecimal(4, 0);

		// MTIME - TIME OF LAST CHG
		// Managed by Property: Mtime
		private FixedDecimal MTIME = new FixedDecimal(6, 0);

		// MHSE_NUM2 - HOUSE# CONT PARCEL LOC
		// Managed by Property: Mhse_num2
		private FixedString MHSE_NUM2 = new FixedString(5);

		// M1ADJ - #1 FRONTAGE ADJUSTMENT %
		// Managed by Property: M1adj
		private FixedDecimal M1ADJ = new FixedDecimal(3, 2);

		// M2ADJ - #2 FRONTAGE ADJUSTMENT %
		// Managed by Property: M2adj
		private FixedDecimal M2ADJ = new FixedDecimal(3, 2);

		// MLGBKC - LEG MOD DATE BOOK TYPE
		// Managed by Property: Mlgbkc
		private FixedString MLGBKC = new FixedString(1);

		// MLGBK_NUM - LEG MOD DATE BOOK NUMBER
		// Managed by Property: Mlgbk_num
		private FixedString MLGBK_NUM = new FixedString(4);

		// MLGPG_NUM - LEG MOD DATE PAGE NUMBER
		// Managed by Property: Mlgpg_num
		private FixedDecimal MLGPG_NUM = new FixedDecimal(4, 0);

		// MEFFAG - EFFECTIVE AGE
		// Managed by Property: Meffag
		private FixedDecimal MEFFAG = new FixedDecimal(3, 0);

		// MPCOMP - PERCENT COMPLETE
		// Managed by Property: Mpcomp
		private FixedDecimal MPCOMP = new FixedDecimal(3, 2);

		// MSTTYP - PARCEL LOC STREET TYPE
		// Managed by Property: Msttyp
		private FixedString MSTTYP = new FixedString(4);

		// MSDIRS - PARCEL LOC DIRECT SUFFIX
		// Managed by Property: Msdirs
		private FixedString MSDIRS = new FixedString(2);

		// M1RATE - #1 FRONTAGE RATE
		// Managed by Property: M1rate
		private FixedDecimal M1RATE = new FixedDecimal(9, 2);

		// M2RATE - #2 FRONTAGE RATE
		// Managed by Property: M2rate
		private FixedDecimal M2RATE = new FixedDecimal(9, 2);

		// MFUNCD - FUNCTIONAL DEPRECIATION
		// Managed by Property: Mfuncd
		private FixedDecimal MFUNCD = new FixedDecimal(3, 2);

		// MECOND - ECONOMICAL DEPRECIATION
		// Managed by Property: Mecond
		private FixedDecimal MECOND = new FixedDecimal(3, 2);

		// MNBRHD - NEIGHBORHOOD CODE
		// Managed by Property: Mnbrhd
		private FixedDecimal MNBRHD = new FixedDecimal(4, 0);

		// MUSER1 - USER FIELD 1
		// Managed by Property: Muser1
		private FixedString MUSER1 = new FixedString(1);

		// MUSER2 - USER FIELD 2
		// Managed by Property: Muser2
		private FixedString MUSER2 = new FixedString(1);

		// MDBOOK - DEED BOOK NO
		// Managed by Property: Mdbook
		private FixedString MDBOOK = new FixedString(4);

		// MDPAGE - DEED BOOK PAGE NO
		// Managed by Property: Mdpage
		private FixedDecimal MDPAGE = new FixedDecimal(4, 0);

		// MWBOOK - WILL BOOK NO
		// Managed by Property: Mwbook
		private FixedString MWBOOK = new FixedString(4);

		// MWPAGE - WILL BOOK PAGE NO
		// Managed by Property: Mwpage
		private FixedDecimal MWPAGE = new FixedDecimal(4, 0);

		// MDCODE - DEED BOOK CODE
		// Managed by Property: Mdcode
		private FixedString MDCODE = new FixedString(1);

		// MWCODE - WILL BOOK CODE
		// Managed by Property: Mwcode
		private FixedString MWCODE = new FixedString(1);

		// MMORTC - MORTGAGE CO CODE
		// Managed by Property: Mmortc
		private FixedDecimal MMORTC = new FixedDecimal(3, 0);

		// MFILL7 - QUAL ASSUR APPR
		// Managed by Property: Mfill7
		private FixedString MFILL7 = new FixedString(1);

		// MACRE_NUM - TOTAL ACREAGE NUMERIC
		// Managed by Property: Macre_num
		private FixedDecimal MACRE_NUM = new FixedDecimal(11, 5);

		// MGISPN - GIS PIN#
		// Managed by Property: Mgispn
		private FixedString MGISPN = new FixedString(30);

		// MUSER3 - USER FIELD 3
		// Managed by Property: Muser3
		private FixedString MUSER3 = new FixedString(1);

		// MUSER4 - USER FIELD 4
		// Managed by Property: Muser4
		private FixedString MUSER4 = new FixedString(1);

		// MIMADJ - IMPROVED VAL ADJUSTMENT
		// Managed by Property: Mimadj
		private FixedDecimal MIMADJ = new FixedDecimal(8, 0);

		// MCDRDT - DATE OF CHG IN REASSM
		// Managed by Property: Mcdrdt
		private FixedDecimal MCDRDT = new FixedDecimal(8, 0);

		// MMNUD - MINERAL VALUE UNDER DEV
		// Managed by Property: Mmnud
		private FixedDecimal MMNUD = new FixedDecimal(9, 0);

		// MMNNUD - MINERAL VAL NOT UNDER DV
		// Managed by Property: Mmnnud
		private FixedDecimal MMNNUD = new FixedDecimal(9, 0);

		// MSS1 - PRIMARY SOC SEC NO
		// Managed by Property: Mss1
		private FixedDecimal MSS1 = new FixedDecimal(9, 0);

		// MPCODE - PLAT BOOK CODE
		// Managed by Property: Mpcode
		private FixedString MPCODE = new FixedString(1);

		// MPBOOK - PLAT BOOK NO
		// Managed by Property: Mpbook
		private FixedString MPBOOK = new FixedString(4);

		// MPPAGE - PLAT BOOK PAGE NO
		// Managed by Property: Mppage
		private FixedDecimal MPPAGE = new FixedDecimal(4, 0);

		// MSS2 - SECONDARY SOC SEC NO
		// Managed by Property: Mss2
		private FixedDecimal MSS2 = new FixedDecimal(9, 0);

		// MASSM - MINERAL VAL FROM LOC
		// Managed by Property: Massm
		private FixedDecimal MASSM = new FixedDecimal(9, 0);

		// MFILL9 - FILL9 UPDATE CD
		// Managed by Property: Mfill9
		private FixedString MFILL9 = new FixedString(4);

		// MGRNTR - GRANTOR
		// Managed by Property: Mgrntr
		private FixedString MGRNTR = new FixedString(35);

		// MCVMO - MONTH-LAST VALUE CHG
		// Managed by Property: Mcvmo
		private FixedDecimal MCVMO = new FixedDecimal(2, 0);

		// MCVDA - DAY-LAST VALUE CHG
		// Managed by Property: Mcvda
		private FixedDecimal MCVDA = new FixedDecimal(2, 0);

		// MCVYR - YEAR-LAST VALUE CHG
		// Managed by Property: Mcvyr
		private FixedDecimal MCVYR = new FixedDecimal(4, 0);

		// MPROUT - POSTAL CARRIER RT
		// Managed by Property: Mprout
		private FixedString MPROUT = new FixedString(4);

		// MPERR - POSTAL ERROR CODE
		// Managed by Property: Mperr
		private FixedString MPERR = new FixedString(3);

		// MTBIMP - INTERIOR IMPROV VALUE
		// Managed by Property: Mtbimp
		private FixedDecimal MTBIMP = new FixedDecimal(10, 0);

		// MPUSE - PROP USE CODE
		// Managed by Property: Mpuse
		private FixedDecimal MPUSE = new FixedDecimal(6, 0);

		// MCVEXP - VAL CHG EXPLAINED
		// Managed by Property: Mcvexp
		private FixedString MCVEXP = new FixedString(23);

		// METXYR - EFF TAX YR CURR VAL
		// Managed by Property: Metxyr
		private FixedDecimal METXYR = new FixedDecimal(4, 0);

		// MQAPCH - QUAL ASSUR % OF CHG
		// Managed by Property: Mqapch
		private FixedDecimal MQAPCH = new FixedDecimal(8, 4);

		// MQAFIL - QUAL ASSUR WORK FIELD
		// Managed by Property: Mqafil
		private FixedString MQAFIL = new FixedString(10);

		// MPICT - DIGITAL PICT REFERENCE
		// Managed by Property: Mpict
		private FixedString MPICT = new FixedString(6);

		// MEACRE - GIS ESTIMATED ACREAGE
		// Managed by Property: Meacre
		private FixedDecimal MEACRE = new FixedDecimal(11, 5);

		// MPRCIT - PROP ADR CITY
		// Managed by Property: Mprcit
		private FixedString MPRCIT = new FixedString(25);

		// MPRSTA - PROP ADR STATE
		// Managed by Property: Mprsta
		private FixedString MPRSTA = new FixedString(2);

		// MPRZP1 - PROP ADR ZIP
		// Managed by Property: Mprzp1
		private FixedDecimal MPRZP1 = new FixedDecimal(5, 0);

		// MPRZP4 - PROP ADR ZIP+4
		// Managed by Property: Mprzp4
		private FixedString MPRZP4 = new FixedString(4);

		// MFP_NUM - # FIREPLACES
		// Managed by Property: Mfp_num
		private FixedDecimal MFP_NUM = new FixedDecimal(2, 0);

		// MSFP_NUM - # STACKED FP
		// Managed by Property: Msfp_num
		private FixedDecimal MSFP_NUM = new FixedDecimal(2, 0);

		// MFL_NUM - # FLUES
		// Managed by Property: Mfl_num
		private FixedDecimal MFL_NUM = new FixedDecimal(2, 0);

		// MSFL_NUM - # STACKED FL
		// Managed by Property: Msfl_num
		private FixedDecimal MSFL_NUM = new FixedDecimal(2, 0);

		// MMFL_NUM - # METAL FLUES
		// Managed by Property: Mmfl_num
		private FixedDecimal MMFL_NUM = new FixedDecimal(2, 0);

		// MIOFP_NUM - # INOPERABLE FL/FP
		// Managed by Property: Miofp_num
		private FixedDecimal MIOFP_NUM = new FixedDecimal(2, 0);

		// MSTOR_NUM - STORY HEIGHT
		// Managed by Property: Mstor_num
		private FixedDecimal MSTOR_NUM = new FixedDecimal(4, 2);

		// MASCOM - ASSESSOR COMM
		// Managed by Property: Mascom
		private FixedString MASCOM = new FixedString(30);

		// MHRPH_NUM - HEARG PHONE#
		// Managed by Property: Mhrph_num
		private FixedDecimal MHRPH_NUM = new FixedDecimal(9, 0);

		// MHRDAT - HEARG DATE
		// Managed by Property: Mhrdat
		private FixedDecimal MHRDAT = new FixedDecimal(8, 0);

		// MHRTIM - HEARG TIME
		// Managed by Property: Mhrtim
		private FixedDecimal MHRTIM = new FixedDecimal(4, 0);

		// MHRNAM - HEARG CALLER NAM
		// Managed by Property: Mhrnam
		private FixedString MHRNAM = new FixedString(35);

		// MHRSES - HEARG SESSION
		// Managed by Property: Mhrses
		private FixedString MHRSES = new FixedString(1);

		// MHIDPC - HIDE PICTURE
		// Managed by Property: Mhidpc
		private FixedString MHIDPC = new FixedString(1);

		// MHIDNM - HIDE NAME
		// Managed by Property: Mhidnm
		private FixedString MHIDNM = new FixedString(1);

		// MCAMO - MONTH-LAST ADDRS CHG
		// Managed by Property: Mcamo
		private FixedDecimal MCAMO = new FixedDecimal(2, 0);

		// MCADA - DAY-LAST ADDRS CHG
		// Managed by Property: Mcada
		private FixedDecimal MCADA = new FixedDecimal(2, 0);

		// MCAYR - YEAR-LAST ADDRS CHG
		// Managed by Property: Mcayr
		private FixedDecimal MCAYR = new FixedDecimal(4, 0);

		// MOLDOC - OLD OCCUP CODE
		// Managed by Property: Moldoc
		private FixedDecimal MOLDOC = new FixedDecimal(2, 0);

		#endregion Variables

		#region Constructors

		private REMaster()
		{
		}

		/// <summary>
		/// Creates an empty REMaster instance.
		/// </summary>
		/// <param name="db">DBAccessManager object.  Used to control all database communications.</param>
		public REMaster(IDBAccess db)
		{
			this.db = db;
		}

		/// <summary>
		/// Creates an REMaster instance populated with the database values for this Key combination.
		/// </summary>
		/// <param name="db">DBAccessManager object.  Used to control all database communications.</param>
		/// <param name="MRECNO">Record Number.</param>
		/// <param name="MDWELL">Card Number.</param>
		public REMaster(IDBAccess db, FixedDecimal MRECNO, FixedDecimal MDWELL)
			: this(db)
		{
			this.MRECNO = MRECNO;
			this.MDWELL = MDWELL;

			this.populate();
		}

		/// <summary>
		/// RECOMMENDED: Creates an REMaster instance populated with the database values for this Key combination.
		/// </summary>
		/// <param name="db">Creates an REMaster instance populated with the database values for this Key combination.</param>
		/// <param name="installedLibrary">Overrides the default Database property with the actual library name.</param>
		/// <param name="localityCode">Used to override the FileName property.</param>
		/// <param name="record">Record Number.</param>
		/// <param name="card">Card Number.</param>
		public REMaster(IDBAccess db, string installedLibrary, string localityCode,
			int record, int card) : this(db)
		{
			this.dataBase = installedLibrary;
			this.fileName = localityCode + "MAST";
			this.MRECNO.setValue(record);
			this.MDWELL.setValue(card);
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
				sb.Append(" MRECNO = " + this.MRECNO.ToString());
				sb.Append(" and ");
				sb.Append(" MDWELL = " + this.MDWELL.ToString());
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
				sb.Append(" MRECNO = @MRECNO ");
				sb.Append(" and ");
				sb.Append(" MDWELL = @MDWELL ");

				sb.Append(" ");
				return sb.ToString();
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MRECID
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(1)
		/// <para>Description: RECORD ID CODE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mrecid
		{
			get
			{
				return this.MRECID;
			}

			set
			{
				if (this.MRECID.checkValue(value))
				{
					this.MRECID.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mrecid Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MRECNO
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (7,0)
		/// <para>Description: RECORD NUMBER</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mrecno
		{
			get
			{
				return this.MRECNO;
			}

			set
			{
				if (this.MRECNO.checkValue(value))
				{
					this.MRECNO.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mrecno Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MDWELL
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: DWELLING NO</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mdwell
		{
			get
			{
				return this.MDWELL;
			}

			set
			{
				if (this.MDWELL.checkValue(value))
				{
					this.MDWELL.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mdwell Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MMAP
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(20)
		/// <para>Description: TAX MAP NO</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mmap
		{
			get
			{
				return this.MMAP;
			}

			set
			{
				if (this.MMAP.checkValue(value))
				{
					this.MMAP.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mmap Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MLNAM
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(35)
		/// <para>Description: OWNER NAME1</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mlnam
		{
			get
			{
				return this.MLNAM;
			}

			set
			{
				if (this.MLNAM.checkValue(value))
				{
					this.MLNAM.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mlnam Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MFNAM
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(35)
		/// <para>Description: OWNER NAME2</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mfnam
		{
			get
			{
				return this.MFNAM;
			}

			set
			{
				if (this.MFNAM.checkValue(value))
				{
					this.MFNAM.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mfnam Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MADD1
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(50)
		/// <para>Description: OWNER ADDRESS 1</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Madd1
		{
			get
			{
				return this.MADD1;
			}

			set
			{
				if (this.MADD1.checkValue(value))
				{
					this.MADD1.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Madd1 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MADD2
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(50)
		/// <para>Description: OWNER ADDRESS 2</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Madd2
		{
			get
			{
				return this.MADD2;
			}

			set
			{
				if (this.MADD2.checkValue(value))
				{
					this.MADD2.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Madd2 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MCITY
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(25)
		/// <para>Description: OWNER CITY</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mcity
		{
			get
			{
				return this.MCITY;
			}

			set
			{
				if (this.MCITY.checkValue(value))
				{
					this.MCITY.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mcity Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MSTATE
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(2)
		/// <para>Description: OWNER STATE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mstate
		{
			get
			{
				return this.MSTATE;
			}

			set
			{
				if (this.MSTATE.checkValue(value))
				{
					this.MSTATE.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mstate Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MZIP5
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (5,0)
		/// <para>Description: OWNER ZIP</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mzip5
		{
			get
			{
				return this.MZIP5;
			}

			set
			{
				if (this.MZIP5.checkValue(value))
				{
					this.MZIP5.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mzip5 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MZIP4
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(4)
		/// <para>Description: OWNER ZIP+4</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mzip4
		{
			get
			{
				return this.MZIP4;
			}

			set
			{
				if (this.MZIP4.checkValue(value))
				{
					this.MZIP4.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mzip4 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MACRE
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(9)
		/// <para>Description: TOTAL ACREAGE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Macre
		{
			get
			{
				return this.MACRE;
			}

			set
			{
				if (this.MACRE.checkValue(value))
				{
					this.MACRE.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Macre Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MZONE
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(4)
		/// <para>Description: ZONING</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mzone
		{
			get
			{
				return this.MZONE;
			}

			set
			{
				if (this.MZONE.checkValue(value))
				{
					this.MZONE.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mzone Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MLUSE
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(2)
		/// <para>Description: LAND USE CLASS</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mluse
		{
			get
			{
				return this.MLUSE;
			}

			set
			{
				if (this.MLUSE.checkValue(value))
				{
					this.MLUSE.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mluse Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MOCCUP
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: OCCUPANCY CODE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Moccup
		{
			get
			{
				return this.MOCCUP;
			}

			set
			{
				if (this.MOCCUP.checkValue(value))
				{
					this.MOCCUP.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Moccup Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MSTORY
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(3)
		/// <para>Description: STORY HEIGHT</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mstory
		{
			get
			{
				return this.MSTORY;
			}

			set
			{
				if (this.MSTORY.checkValue(value))
				{
					this.MSTORY.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mstory Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MAGE
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (3,0)
		/// <para>Description: AGE OF BLDG</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mage
		{
			get
			{
				return this.MAGE;
			}

			set
			{
				if (this.MAGE.checkValue(value))
				{
					this.MAGE.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mage Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MCOND
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(1)
		/// <para>Description: CONDITION</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mcond
		{
			get
			{
				return this.MCOND;
			}

			set
			{
				if (this.MCOND.checkValue(value))
				{
					this.MCOND.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mcond Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MCLASS
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(1)
		/// <para>Description: CLASS</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mclass
		{
			get
			{
				return this.MCLASS;
			}

			set
			{
				if (this.MCLASS.checkValue(value))
				{
					this.MCLASS.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mclass Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MFACTR
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (3,2)
		/// <para>Description: FACTOR</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mfactr
		{
			get
			{
				return this.MFACTR;
			}

			set
			{
				if (this.MFACTR.checkValue(value))
				{
					this.MFACTR.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mfactr Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MDEPRC
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (3,2)
		/// <para>Description: PHYSICAL DEPRECIATION</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mdeprc
		{
			get
			{
				return this.MDEPRC;
			}

			set
			{
				if (this.MDEPRC.checkValue(value))
				{
					this.MDEPRC.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mdeprc Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MFOUND
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: FOUNDATION TYPE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mfound
		{
			get
			{
				return this.MFOUND;
			}

			set
			{
				if (this.MFOUND.checkValue(value))
				{
					this.MFOUND.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mfound Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MEXWLL
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: EXT. WALL TYPE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mexwll
		{
			get
			{
				return this.MEXWLL;
			}

			set
			{
				if (this.MEXWLL.checkValue(value))
				{
					this.MEXWLL.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mexwll Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MROOFT
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: ROOF TYPE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mrooft
		{
			get
			{
				return this.MROOFT;
			}

			set
			{
				if (this.MROOFT.checkValue(value))
				{
					this.MROOFT.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mrooft Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MROOFG
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: ROOFING MATERIAL</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mroofg
		{
			get
			{
				return this.MROOFG;
			}

			set
			{
				if (this.MROOFG.checkValue(value))
				{
					this.MROOFG.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mroofg Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - M_NUMDUNT
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (3,0)
		/// <para>Description: NO. DWELLING UNITS</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal M_numdunt
		{
			get
			{
				return this.M_NUMDUNT;
			}

			set
			{
				if (this.M_NUMDUNT.checkValue(value))
				{
					this.M_NUMDUNT.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the M_numdunt Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - M_NUMROOM
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (3,0)
		/// <para>Description: NO. OF ROOMS</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal M_numroom
		{
			get
			{
				return this.M_NUMROOM;
			}

			set
			{
				if (this.M_NUMROOM.checkValue(value))
				{
					this.M_NUMROOM.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the M_numroom Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - M_NUMBR
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (3,0)
		/// <para>Description: NO. OF BEDROOMS</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal M_numbr
		{
			get
			{
				return this.M_NUMBR;
			}

			set
			{
				if (this.M_NUMBR.checkValue(value))
				{
					this.M_NUMBR.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the M_numbr Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - M_NUMFBTH
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: NO. OF FULL BATHS</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal M_numfbth
		{
			get
			{
				return this.M_NUMFBTH;
			}

			set
			{
				if (this.M_NUMFBTH.checkValue(value))
				{
					this.M_NUMFBTH.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the M_numfbth Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - M_NUMHBTH
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: NO. OF HALF BATHS</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal M_numhbth
		{
			get
			{
				return this.M_NUMHBTH;
			}

			set
			{
				if (this.M_NUMHBTH.checkValue(value))
				{
					this.M_NUMHBTH.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the M_numhbth Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MFP2
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(3)
		/// <para>Description: FIREPLACE CODE 2</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mfp2
		{
			get
			{
				return this.MFP2;
			}

			set
			{
				if (this.MFP2.checkValue(value))
				{
					this.MFP2.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mfp2 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MLTRCD
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(1)
		/// <para>Description: CHG/NO CHG ASSMT LTR</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mltrcd
		{
			get
			{
				return this.MLTRCD;
			}

			set
			{
				if (this.MLTRCD.checkValue(value))
				{
					this.MLTRCD.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mltrcd Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MHEAT
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: TYPE OF HEAT</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mheat
		{
			get
			{
				return this.MHEAT;
			}

			set
			{
				if (this.MHEAT.checkValue(value))
				{
					this.MHEAT.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mheat Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MFUEL
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: TYPE OF FUEL</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mfuel
		{
			get
			{
				return this.MFUEL;
			}

			set
			{
				if (this.MFUEL.checkValue(value))
				{
					this.MFUEL.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mfuel Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MAC
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(1)
		/// <para>Description: AIR COND.(Y/N)</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mac
		{
			get
			{
				return this.MAC;
			}

			set
			{
				if (this.MAC.checkValue(value))
				{
					this.MAC.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mac Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MFP1
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(2)
		/// <para>Description: FIREPLACE CODE 1</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mfp1
		{
			get
			{
				return this.MFP1;
			}

			set
			{
				if (this.MFP1.checkValue(value))
				{
					this.MFP1.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mfp1 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MCDR
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(1)
		/// <para>Description: CHG DURING REASS</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mcdr
		{
			get
			{
				return this.MCDR;
			}

			set
			{
				if (this.MCDR.checkValue(value))
				{
					this.MCDR.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mcdr Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MEKIT
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (1,0)
		/// <para>Description: NO. OF KITCHENS</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mekit
		{
			get
			{
				return this.MEKIT;
			}

			set
			{
				if (this.MEKIT.checkValue(value))
				{
					this.MEKIT.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mekit Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MBASTP
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: BASEMENT TYPE CODE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mbastp
		{
			get
			{
				return this.MBASTP;
			}

			set
			{
				if (this.MBASTP.checkValue(value))
				{
					this.MBASTP.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mbastp Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MPBTOT
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (3,2)
		/// <para>Description: BASEMENT PERCENT</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mpbtot
		{
			get
			{
				return this.MPBTOT;
			}

			set
			{
				if (this.MPBTOT.checkValue(value))
				{
					this.MPBTOT.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mpbtot Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MSBTOT
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (6,0)
		/// <para>Description: BASEMENT SQ FT</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Msbtot
		{
			get
			{
				return this.MSBTOT;
			}

			set
			{
				if (this.MSBTOT.checkValue(value))
				{
					this.MSBTOT.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Msbtot Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MPBFIN
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (3,2)
		/// <para>Description: FIN BASMT PERCENT</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mpbfin
		{
			get
			{
				return this.MPBFIN;
			}

			set
			{
				if (this.MPBFIN.checkValue(value))
				{
					this.MPBFIN.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mpbfin Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MSBFIN
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (6,0)
		/// <para>Description: FIN BASMT SQ FT</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Msbfin
		{
			get
			{
				return this.MSBFIN;
			}

			set
			{
				if (this.MSBFIN.checkValue(value))
				{
					this.MSBFIN.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Msbfin Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MBRATE
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (5,2)
		/// <para>Description: FIN BASMT RATE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mbrate
		{
			get
			{
				return this.MBRATE;
			}

			set
			{
				if (this.MBRATE.checkValue(value))
				{
					this.MBRATE.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mbrate Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - M_NUMFLUE
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: NO. OF FLUES</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal M_numflue
		{
			get
			{
				return this.M_NUMFLUE;
			}

			set
			{
				if (this.M_NUMFLUE.checkValue(value))
				{
					this.M_NUMFLUE.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the M_numflue Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MFLUTP
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(1)
		/// <para>Description: FLUE TYPE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mflutp
		{
			get
			{
				return this.MFLUTP;
			}

			set
			{
				if (this.MFLUTP.checkValue(value))
				{
					this.MFLUTP.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mflutp Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MGART
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: GARAGE TYPE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mgart
		{
			get
			{
				return this.MGART;
			}

			set
			{
				if (this.MGART.checkValue(value))
				{
					this.MGART.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mgart Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MGAR_NUMC
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: NO. CARS GARAGE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mgar_numc
		{
			get
			{
				return this.MGAR_NUMC;
			}

			set
			{
				if (this.MGAR_NUMC.checkValue(value))
				{
					this.MGAR_NUMC.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mgar_numc Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MCARPT
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: CARPORT TYPE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mcarpt
		{
			get
			{
				return this.MCARPT;
			}

			set
			{
				if (this.MCARPT.checkValue(value))
				{
					this.MCARPT.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mcarpt Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MCAR_NUMC
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: NO. CARS CARPORT</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mcar_numc
		{
			get
			{
				return this.MCAR_NUMC;
			}

			set
			{
				if (this.MCAR_NUMC.checkValue(value))
				{
					this.MCAR_NUMC.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mcar_numc Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MBI_NUMC
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: NO. CARS BUILT-IN</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mbi_numc
		{
			get
			{
				return this.MBI_NUMC;
			}

			set
			{
				if (this.MBI_NUMC.checkValue(value))
				{
					this.MBI_NUMC.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mbi_numc Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MROW
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: RIGHT OF WAY</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mrow
		{
			get
			{
				return this.MROW;
			}

			set
			{
				if (this.MROW.checkValue(value))
				{
					this.MROW.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mrow Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MEASE
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: EASEMENT</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mease
		{
			get
			{
				return this.MEASE;
			}

			set
			{
				if (this.MEASE.checkValue(value))
				{
					this.MEASE.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mease Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MWATER
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: WATER</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mwater
		{
			get
			{
				return this.MWATER;
			}

			set
			{
				if (this.MWATER.checkValue(value))
				{
					this.MWATER.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mwater Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MSEWER
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: SEWER</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Msewer
		{
			get
			{
				return this.MSEWER;
			}

			set
			{
				if (this.MSEWER.checkValue(value))
				{
					this.MSEWER.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Msewer Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MGAS
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(1)
		/// <para>Description: GAS</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mgas
		{
			get
			{
				return this.MGAS;
			}

			set
			{
				if (this.MGAS.checkValue(value))
				{
					this.MGAS.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mgas Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MELEC
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(1)
		/// <para>Description: ELECTRIC</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Melec
		{
			get
			{
				return this.MELEC;
			}

			set
			{
				if (this.MELEC.checkValue(value))
				{
					this.MELEC.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Melec Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MTERRN
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: TERRAIN</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mterrn
		{
			get
			{
				return this.MTERRN;
			}

			set
			{
				if (this.MTERRN.checkValue(value))
				{
					this.MTERRN.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mterrn Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MCHAR
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: CHARACTERISTICS</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mchar
		{
			get
			{
				return this.MCHAR;
			}

			set
			{
				if (this.MCHAR.checkValue(value))
				{
					this.MCHAR.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mchar Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MOTDES
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(20)
		/// <para>Description: OTHER DESCRIPTION</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Motdes
		{
			get
			{
				return this.MOTDES;
			}

			set
			{
				if (this.MOTDES.checkValue(value))
				{
					this.MOTDES.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Motdes Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MGART2
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: GARAGE TYPE 2</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mgart2
		{
			get
			{
				return this.MGART2;
			}

			set
			{
				if (this.MGART2.checkValue(value))
				{
					this.MGART2.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mgart2 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MGAR_NUM2
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: NO. CARS GARAGE 2</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mgar_num2
		{
			get
			{
				return this.MGAR_NUM2;
			}

			set
			{
				if (this.MGAR_NUM2.checkValue(value))
				{
					this.MGAR_NUM2.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mgar_num2 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MDATLG
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (8,0)
		/// <para>Description: LEGAL MOD DATE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mdatlg
		{
			get
			{
				return this.MDATLG;
			}

			set
			{
				if (this.MDATLG.checkValue(value))
				{
					this.MDATLG.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mdatlg Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MDATPR
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (8,0)
		/// <para>Description: PRORATE DATE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mdatpr
		{
			get
			{
				return this.MDATPR;
			}

			set
			{
				if (this.MDATPR.checkValue(value))
				{
					this.MDATPR.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mdatpr Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MINTYP
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(2)
		/// <para>Description: INSTRUMENT TYPE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mintyp
		{
			get
			{
				return this.MINTYP;
			}

			set
			{
				if (this.MINTYP.checkValue(value))
				{
					this.MINTYP.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mintyp Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MINTYR
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (4,0)
		/// <para>Description: INSTRUMENT YEAR</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mintyr
		{
			get
			{
				return this.MINTYR;
			}

			set
			{
				if (this.MINTYR.checkValue(value))
				{
					this.MINTYR.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mintyr Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MINNO_NUM
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (7,0)
		/// <para>Description: INSTRUMENT #</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Minno_num
		{
			get
			{
				return this.MINNO_NUM;
			}

			set
			{
				if (this.MINNO_NUM.checkValue(value))
				{
					this.MINNO_NUM.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Minno_num Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MINNO2
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: INSTRUMENT # 2</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Minno2
		{
			get
			{
				return this.MINNO2;
			}

			set
			{
				if (this.MINNO2.checkValue(value))
				{
					this.MINNO2.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Minno2 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MDSUFX
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(1)
		/// <para>Description: DEED BK SUFFIX</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mdsufx
		{
			get
			{
				return this.MDSUFX;
			}

			set
			{
				if (this.MDSUFX.checkValue(value))
				{
					this.MDSUFX.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mdsufx Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MWSUFX
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(1)
		/// <para>Description: WILL BK SUFFIX</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mwsufx
		{
			get
			{
				return this.MWSUFX;
			}

			set
			{
				if (this.MWSUFX.checkValue(value))
				{
					this.MWSUFX.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mwsufx Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MPSUFX
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(1)
		/// <para>Description: PALT BK SUFFIX</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mpsufx
		{
			get
			{
				return this.MPSUFX;
			}

			set
			{
				if (this.MPSUFX.checkValue(value))
				{
					this.MPSUFX.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mpsufx Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MIMPRV
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (10,0)
		/// <para>Description: TOTAL IMPROVED VALUE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mimprv
		{
			get
			{
				return this.MIMPRV;
			}

			set
			{
				if (this.MIMPRV.checkValue(value))
				{
					this.MIMPRV.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mimprv Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MTOTLD
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (10,0)
		/// <para>Description: TOTAL LAND VALUE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mtotld
		{
			get
			{
				return this.MTOTLD;
			}

			set
			{
				if (this.MTOTLD.checkValue(value))
				{
					this.MTOTLD.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mtotld Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MTOTOI
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (10,0)
		/// <para>Description: OTHER IMPROV SUB-TOT</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mtotoi
		{
			get
			{
				return this.MTOTOI;
			}

			set
			{
				if (this.MTOTOI.checkValue(value))
				{
					this.MTOTOI.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mtotoi Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MTOTPR
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (10,0)
		/// <para>Description: TOTAL PROPERTY VALUE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mtotpr
		{
			get
			{
				return this.MTOTPR;
			}

			set
			{
				if (this.MTOTPR.checkValue(value))
				{
					this.MTOTPR.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mtotpr Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MASSB
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (10,0)
		/// <para>Description: ASSESSMT IMPR FROM LOC</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Massb
		{
			get
			{
				return this.MASSB;
			}

			set
			{
				if (this.MASSB.checkValue(value))
				{
					this.MASSB.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Massb Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MACPCT
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (3,2)
		/// <para>Description: AIR COND % OF AREA</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Macpct
		{
			get
			{
				return this.MACPCT;
			}

			set
			{
				if (this.MACPCT.checkValue(value))
				{
					this.MACPCT.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Macpct Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - M1FRNT
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (7,2)
		/// <para>Description: #1 FRONTAGE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal M1frnt
		{
			get
			{
				return this.M1FRNT;
			}

			set
			{
				if (this.M1FRNT.checkValue(value))
				{
					this.M1FRNT.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the M1frnt Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - M1DPTH
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (7,2)
		/// <para>Description: #1 DEPTH</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal M1dpth
		{
			get
			{
				return this.M1DPTH;
			}

			set
			{
				if (this.M1DPTH.checkValue(value))
				{
					this.M1DPTH.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the M1dpth Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - M1AREA
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (7,0)
		/// <para>Description: #1 AREA</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal M1area
		{
			get
			{
				return this.M1AREA;
			}

			set
			{
				if (this.M1AREA.checkValue(value))
				{
					this.M1AREA.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the M1area Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MMCODE
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (3,0)
		/// <para>Description: NO PARCELS IN SALE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mmcode
		{
			get
			{
				return this.MMCODE;
			}

			set
			{
				if (this.MMCODE.checkValue(value))
				{
					this.MMCODE.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mmcode Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - M0DEPR
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(1)
		/// <para>Description: 0 PHYS DEPREC</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString M0depr
		{
			get
			{
				return this.M0DEPR;
			}

			set
			{
				if (this.M0DEPR.checkValue(value))
				{
					this.M0DEPR.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the M0depr Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - M1UM
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(1)
		/// <para>Description: #1 UNIT OF MEASURE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString M1um
		{
			get
			{
				return this.M1UM;
			}

			set
			{
				if (this.M1UM.checkValue(value))
				{
					this.M1UM.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the M1um Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - M2FRNT
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (7,2)
		/// <para>Description: #2 FRONTAGE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal M2frnt
		{
			get
			{
				return this.M2FRNT;
			}

			set
			{
				if (this.M2FRNT.checkValue(value))
				{
					this.M2FRNT.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the M2frnt Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - M2DPTH
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (7,2)
		/// <para>Description: #2 DEPTH</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal M2dpth
		{
			get
			{
				return this.M2DPTH;
			}

			set
			{
				if (this.M2DPTH.checkValue(value))
				{
					this.M2DPTH.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the M2dpth Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - M2AREA
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (7,0)
		/// <para>Description: #2 AREA</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal M2area
		{
			get
			{
				return this.M2AREA;
			}

			set
			{
				if (this.M2AREA.checkValue(value))
				{
					this.M2AREA.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the M2area Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MZIPBR
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (3,0)
		/// <para>Description: BAR CODE ZIP</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mzipbr
		{
			get
			{
				return this.MZIPBR;
			}

			set
			{
				if (this.MZIPBR.checkValue(value))
				{
					this.MZIPBR.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mzipbr Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MDELAY
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(1)
		/// <para>Description: DELAY UPDATE TO REAL EST</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mdelay
		{
			get
			{
				return this.MDELAY;
			}

			set
			{
				if (this.MDELAY.checkValue(value))
				{
					this.MDELAY.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mdelay Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - M2UM
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(1)
		/// <para>Description: #2 UNIT OF MEASURE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString M2um
		{
			get
			{
				return this.M2UM;
			}

			set
			{
				if (this.M2UM.checkValue(value))
				{
					this.M2UM.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the M2um Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MSTRT
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(17)
		/// <para>Description: LOCATION STREET NAME</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mstrt
		{
			get
			{
				return this.MSTRT;
			}

			set
			{
				if (this.MSTRT.checkValue(value))
				{
					this.MSTRT.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mstrt Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MDIRCT
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(2)
		/// <para>Description: LOCATION STREET DIRECT</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mdirct
		{
			get
			{
				return this.MDIRCT;
			}

			set
			{
				if (this.MDIRCT.checkValue(value))
				{
					this.MDIRCT.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mdirct Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MHSE_NUM
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (5,0)
		/// <para>Description: LOCATION HOUSE NO.</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mhse_num
		{
			get
			{
				return this.MHSE_NUM;
			}

			set
			{
				if (this.MHSE_NUM.checkValue(value))
				{
					this.MHSE_NUM.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mhse_num Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MCDMO
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: MONTH OF LAST CHANGE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mcdmo
		{
			get
			{
				return this.MCDMO;
			}

			set
			{
				if (this.MCDMO.checkValue(value))
				{
					this.MCDMO.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mcdmo Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MCDDA
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: DAY OF LAST CHANGE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mcdda
		{
			get
			{
				return this.MCDDA;
			}

			set
			{
				if (this.MCDDA.checkValue(value))
				{
					this.MCDDA.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mcdda Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MCDYR
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (4,0)
		/// <para>Description: YEAR OF LAST CHANGE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mcdyr
		{
			get
			{
				return this.MCDYR;
			}

			set
			{
				if (this.MCDYR.checkValue(value))
				{
					this.MCDYR.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mcdyr Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - M1DFAC
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (4,3)
		/// <para>Description: #1 DEPTH FACTOR</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal M1dfac
		{
			get
			{
				return this.M1DFAC;
			}

			set
			{
				if (this.M1DFAC.checkValue(value))
				{
					this.M1DFAC.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the M1dfac Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MREM1
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(35)
		/// <para>Description: REMARKS 1</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mrem1
		{
			get
			{
				return this.MREM1;
			}

			set
			{
				if (this.MREM1.checkValue(value))
				{
					this.MREM1.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mrem1 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MREM2
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(35)
		/// <para>Description: REMARKS 2</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mrem2
		{
			get
			{
				return this.MREM2;
			}

			set
			{
				if (this.MREM2.checkValue(value))
				{
					this.MREM2.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mrem2 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MMAGCD
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(2)
		/// <para>Description: MAGISTERIAL CODE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mmagcd
		{
			get
			{
				return this.MMAGCD;
			}

			set
			{
				if (this.MMAGCD.checkValue(value))
				{
					this.MMAGCD.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mmagcd Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MATHOM
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(1)
		/// <para>Description: AT HOME Y/N</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mathom
		{
			get
			{
				return this.MATHOM;
			}

			set
			{
				if (this.MATHOM.checkValue(value))
				{
					this.MATHOM.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mathom Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MDESC1
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(35)
		/// <para>Description: LEGAL DESCRIPTION 1</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mdesc1
		{
			get
			{
				return this.MDESC1;
			}

			set
			{
				if (this.MDESC1.checkValue(value))
				{
					this.MDESC1.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mdesc1 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MDESC2
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(35)
		/// <para>Description: LEGAL DESCRIPTION 2</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mdesc2
		{
			get
			{
				return this.MDESC2;
			}

			set
			{
				if (this.MDESC2.checkValue(value))
				{
					this.MDESC2.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mdesc2 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MDESC3
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(35)
		/// <para>Description: LEGAL DESCRIPTION 3</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mdesc3
		{
			get
			{
				return this.MDESC3;
			}

			set
			{
				if (this.MDESC3.checkValue(value))
				{
					this.MDESC3.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mdesc3 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MDESC4
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(35)
		/// <para>Description: LEGAL DESCRIPTION 4</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mdesc4
		{
			get
			{
				return this.MDESC4;
			}

			set
			{
				if (this.MDESC4.checkValue(value))
				{
					this.MDESC4.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mdesc4 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MFAIRV
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (8,0)
		/// <para>Description: FAIR VALUE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mfairv
		{
			get
			{
				return this.MFAIRV;
			}

			set
			{
				if (this.MFAIRV.checkValue(value))
				{
					this.MFAIRV.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mfairv Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MLGITY
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(2)
		/// <para>Description: LEGAL MOD DT INSTR TYPE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mlgity
		{
			get
			{
				return this.MLGITY;
			}

			set
			{
				if (this.MLGITY.checkValue(value))
				{
					this.MLGITY.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mlgity Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MLGIYR
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (4,0)
		/// <para>Description: LEGAL MOD DT INSTR YEAR</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mlgiyr
		{
			get
			{
				return this.MLGIYR;
			}

			set
			{
				if (this.MLGIYR.checkValue(value))
				{
					this.MLGIYR.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mlgiyr Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MLGNO_NUM
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (5,0)
		/// <para>Description: LEGAL MOD DT INSTR NUMB</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mlgno_num
		{
			get
			{
				return this.MLGNO_NUM;
			}

			set
			{
				if (this.MLGNO_NUM.checkValue(value))
				{
					this.MLGNO_NUM.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mlgno_num Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MLGNO2
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: LEGAL MOD DT INSTR NO 2</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mlgno2
		{
			get
			{
				return this.MLGNO2;
			}

			set
			{
				if (this.MLGNO2.checkValue(value))
				{
					this.MLGNO2.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mlgno2 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MSUBDV
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(3)
		/// <para>Description: SUBDIVISION CODE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Msubdv
		{
			get
			{
				return this.MSUBDV;
			}

			set
			{
				if (this.MSUBDV.checkValue(value))
				{
					this.MSUBDV.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Msubdv Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MSELLP
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (8,0)
		/// <para>Description: SELLING PRICE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Msellp
		{
			get
			{
				return this.MSELLP;
			}

			set
			{
				if (this.MSELLP.checkValue(value))
				{
					this.MSELLP.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Msellp Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - M2DFAC
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (4,3)
		/// <para>Description: #2 DEPTH FACTOR</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal M2dfac
		{
			get
			{
				return this.M2DFAC;
			}

			set
			{
				if (this.M2DFAC.checkValue(value))
				{
					this.M2DFAC.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the M2dfac Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MINIT
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(5)
		/// <para>Description: APPRAISOR INITIALS</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Minit
		{
			get
			{
				return this.MINIT;
			}

			set
			{
				if (this.MINIT.checkValue(value))
				{
					this.MINIT.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Minit Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MINSPD
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (8,0)
		/// <para>Description: DATE INSPECTED</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Minspd
		{
			get
			{
				return this.MINSPD;
			}

			set
			{
				if (this.MINSPD.checkValue(value))
				{
					this.MINSPD.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Minspd Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MSWL
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (5,0)
		/// <para>Description: SEW/WAT/LANDSCAPE VALUE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mswl
		{
			get
			{
				return this.MSWL;
			}

			set
			{
				if (this.MSWL.checkValue(value))
				{
					this.MSWL.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mswl Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MTUTIL
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (5,0)
		/// <para>Description: TOTAL UTILITY VALUE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mtutil
		{
			get
			{
				return this.MTUTIL;
			}

			set
			{
				if (this.MTUTIL.checkValue(value))
				{
					this.MTUTIL.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mtutil Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MNBADJ
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (3,2)
		/// <para>Description: NEIGHBORHOOD ADJUSTMENT</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mnbadj
		{
			get
			{
				return this.MNBADJ;
			}

			set
			{
				if (this.MNBADJ.checkValue(value))
				{
					this.MNBADJ.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mnbadj Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MASSL
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (10,0)
		/// <para>Description: ASSESSMT LAND FROM LOC</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Massl
		{
			get
			{
				return this.MASSL;
			}

			set
			{
				if (this.MASSL.checkValue(value))
				{
					this.MASSL.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Massl Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MACSF
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (6,0)
		/// <para>Description: AIR COND #SQ FT</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Macsf
		{
			get
			{
				return this.MACSF;
			}

			set
			{
				if (this.MACSF.checkValue(value))
				{
					this.MACSF.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Macsf Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MCOMM1
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(25)
		/// <para>Description: COMMENT LINE 1</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mcomm1
		{
			get
			{
				return this.MCOMM1;
			}

			set
			{
				if (this.MCOMM1.checkValue(value))
				{
					this.MCOMM1.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mcomm1 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MCOMM2
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(25)
		/// <para>Description: COMMENT LINE 2</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mcomm2
		{
			get
			{
				return this.MCOMM2;
			}

			set
			{
				if (this.MCOMM2.checkValue(value))
				{
					this.MCOMM2.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mcomm2 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MCOMM3
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(25)
		/// <para>Description: COMMENT LINE 3</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mcomm3
		{
			get
			{
				return this.MCOMM3;
			}

			set
			{
				if (this.MCOMM3.checkValue(value))
				{
					this.MCOMM3.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mcomm3 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MACCT
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (10,0)
		/// <para>Description: ACCOUNT NUMBER</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Macct
		{
			get
			{
				return this.MACCT;
			}

			set
			{
				if (this.MACCT.checkValue(value))
				{
					this.MACCT.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Macct Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MEXWL2
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: EXTERIOR WALL TYPE 2</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mexwl2
		{
			get
			{
				return this.MEXWL2;
			}

			set
			{
				if (this.MEXWL2.checkValue(value))
				{
					this.MEXWL2.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mexwl2 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MCALC
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(1)
		/// <para>Description: CALCULATED CODE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mcalc
		{
			get
			{
				return this.MCALC;
			}

			set
			{
				if (this.MCALC.checkValue(value))
				{
					this.MCALC.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mcalc Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MFILL4
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(1)
		/// <para>Description: QUAL ASSUR MLT SAL</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mfill4
		{
			get
			{
				return this.MFILL4;
			}

			set
			{
				if (this.MFILL4.checkValue(value))
				{
					this.MFILL4.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mfill4 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MTBV
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (9,0)
		/// <para>Description: BUILDING VALUE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mtbv
		{
			get
			{
				return this.MTBV;
			}

			set
			{
				if (this.MTBV.checkValue(value))
				{
					this.MTBV.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mtbv Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MTBAS
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (9,0)
		/// <para>Description: BASEMENT VALUE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mtbas
		{
			get
			{
				return this.MTBAS;
			}

			set
			{
				if (this.MTBAS.checkValue(value))
				{
					this.MTBAS.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mtbas Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MTFBAS
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (9,0)
		/// <para>Description: FIN BSMT VALUE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mtfbas
		{
			get
			{
				return this.MTFBAS;
			}

			set
			{
				if (this.MTFBAS.checkValue(value))
				{
					this.MTFBAS.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mtfbas Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MTPLUM
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (9,0)
		/// <para>Description: PLUMBING VALUE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mtplum
		{
			get
			{
				return this.MTPLUM;
			}

			set
			{
				if (this.MTPLUM.checkValue(value))
				{
					this.MTPLUM.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mtplum Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MTHEAT
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (9,0)
		/// <para>Description: HEATING VALUE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mtheat
		{
			get
			{
				return this.MTHEAT;
			}

			set
			{
				if (this.MTHEAT.checkValue(value))
				{
					this.MTHEAT.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mtheat Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MTAC
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (9,0)
		/// <para>Description: AIR CONDITIONING VALUE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mtac
		{
			get
			{
				return this.MTAC;
			}

			set
			{
				if (this.MTAC.checkValue(value))
				{
					this.MTAC.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mtac Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MTFP
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (9,0)
		/// <para>Description: FIREPLACE VALUE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mtfp
		{
			get
			{
				return this.MTFP;
			}

			set
			{
				if (this.MTFP.checkValue(value))
				{
					this.MTFP.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mtfp Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MTFL
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (9,0)
		/// <para>Description: FLUE VALUE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mtfl
		{
			get
			{
				return this.MTFL;
			}

			set
			{
				if (this.MTFL.checkValue(value))
				{
					this.MTFL.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mtfl Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MTBI
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (9,0)
		/// <para>Description: BUILT-IN VALUE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mtbi
		{
			get
			{
				return this.MTBI;
			}

			set
			{
				if (this.MTBI.checkValue(value))
				{
					this.MTBI.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mtbi Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MTTADD
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (9,0)
		/// <para>Description: ADDITIONS VALUE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mttadd
		{
			get
			{
				return this.MTTADD;
			}

			set
			{
				if (this.MTTADD.checkValue(value))
				{
					this.MTTADD.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mttadd Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MTSUBT
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (9,0)
		/// <para>Description: SUBTOTAL VALUE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mtsubt
		{
			get
			{
				return this.MTSUBT;
			}

			set
			{
				if (this.MTSUBT.checkValue(value))
				{
					this.MTSUBT.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mtsubt Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MTOTBV
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (9,0)
		/// <para>Description: TOTAL BUILDING VALUE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mtotbv
		{
			get
			{
				return this.MTOTBV;
			}

			set
			{
				if (this.MTOTBV.checkValue(value))
				{
					this.MTOTBV.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mtotbv Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MUSRID
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(10)
		/// <para>Description: USER ID CODE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Musrid
		{
			get
			{
				return this.MUSRID;
			}

			set
			{
				if (this.MUSRID.checkValue(value))
				{
					this.MUSRID.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Musrid Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MBASA
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (7,1)
		/// <para>Description: BASE AREA</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mbasa
		{
			get
			{
				return this.MBASA;
			}

			set
			{
				if (this.MBASA.checkValue(value))
				{
					this.MBASA.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mbasa Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MTOTA
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (7,1)
		/// <para>Description: TOTAL AREA</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mtota
		{
			get
			{
				return this.MTOTA;
			}

			set
			{
				if (this.MTOTA.checkValue(value))
				{
					this.MTOTA.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mtota Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MPSF
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (5,2)
		/// <para>Description: PRICE PER SQ FT</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mpsf
		{
			get
			{
				return this.MPSF;
			}

			set
			{
				if (this.MPSF.checkValue(value))
				{
					this.MPSF.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mpsf Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MINWLL
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(8)
		/// <para>Description: INTERIOR WALL CODES</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Minwll
		{
			get
			{
				return this.MINWLL;
			}

			set
			{
				if (this.MINWLL.checkValue(value))
				{
					this.MINWLL.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Minwll Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MFLOOR
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(8)
		/// <para>Description: FLOOR CODES</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mfloor
		{
			get
			{
				return this.MFLOOR;
			}

			set
			{
				if (this.MFLOOR.checkValue(value))
				{
					this.MFLOOR.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mfloor Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MYRBLT
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (4,0)
		/// <para>Description: YEAR BUILT</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Myrblt
		{
			get
			{
				return this.MYRBLT;
			}

			set
			{
				if (this.MYRBLT.checkValue(value))
				{
					this.MYRBLT.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Myrblt Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MCNST1
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(2)
		/// <para>Description: CENSUS TRACT 1</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mcnst1
		{
			get
			{
				return this.MCNST1;
			}

			set
			{
				if (this.MCNST1.checkValue(value))
				{
					this.MCNST1.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mcnst1 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MCNST2
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(2)
		/// <para>Description: CENSUS TRACT 2</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mcnst2
		{
			get
			{
				return this.MCNST2;
			}

			set
			{
				if (this.MCNST2.checkValue(value))
				{
					this.MCNST2.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mcnst2 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MASSLU
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (9,0)
		/// <para>Description: LAND USE VALUE FROM LOC</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Masslu
		{
			get
			{
				return this.MASSLU;
			}

			set
			{
				if (this.MASSLU.checkValue(value))
				{
					this.MASSLU.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Masslu Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MMOSLD
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: MONTH SOLD</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mmosld
		{
			get
			{
				return this.MMOSLD;
			}

			set
			{
				if (this.MMOSLD.checkValue(value))
				{
					this.MMOSLD.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mmosld Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MDASLD
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: DAY SOLD</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mdasld
		{
			get
			{
				return this.MDASLD;
			}

			set
			{
				if (this.MDASLD.checkValue(value))
				{
					this.MDASLD.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mdasld Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MYRSLD
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (4,0)
		/// <para>Description: YEAR SOLD</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Myrsld
		{
			get
			{
				return this.MYRSLD;
			}

			set
			{
				if (this.MYRSLD.checkValue(value))
				{
					this.MYRSLD.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Myrsld Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MTIME
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (6,0)
		/// <para>Description: TIME OF LAST CHG</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mtime
		{
			get
			{
				return this.MTIME;
			}

			set
			{
				if (this.MTIME.checkValue(value))
				{
					this.MTIME.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mtime Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MHSE_NUM2
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(5)
		/// <para>Description: HOUSE# CONT PARCEL LOC</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mhse_num2
		{
			get
			{
				return this.MHSE_NUM2;
			}

			set
			{
				if (this.MHSE_NUM2.checkValue(value))
				{
					this.MHSE_NUM2.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mhse_num2 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - M1ADJ
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (3,2)
		/// <para>Description: #1 FRONTAGE ADJUSTMENT %</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal M1adj
		{
			get
			{
				return this.M1ADJ;
			}

			set
			{
				if (this.M1ADJ.checkValue(value))
				{
					this.M1ADJ.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the M1adj Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - M2ADJ
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (3,2)
		/// <para>Description: #2 FRONTAGE ADJUSTMENT %</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal M2adj
		{
			get
			{
				return this.M2ADJ;
			}

			set
			{
				if (this.M2ADJ.checkValue(value))
				{
					this.M2ADJ.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the M2adj Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MLGBKC
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(1)
		/// <para>Description: LEG MOD DATE BOOK TYPE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mlgbkc
		{
			get
			{
				return this.MLGBKC;
			}

			set
			{
				if (this.MLGBKC.checkValue(value))
				{
					this.MLGBKC.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mlgbkc Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MLGBK_NUM
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(4)
		/// <para>Description: LEG MOD DATE BOOK NUMBER</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mlgbk_num
		{
			get
			{
				return this.MLGBK_NUM;
			}

			set
			{
				if (this.MLGBK_NUM.checkValue(value))
				{
					this.MLGBK_NUM.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mlgbk_num Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MLGPG_NUM
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (4,0)
		/// <para>Description: LEG MOD DATE PAGE NUMBER</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mlgpg_num
		{
			get
			{
				return this.MLGPG_NUM;
			}

			set
			{
				if (this.MLGPG_NUM.checkValue(value))
				{
					this.MLGPG_NUM.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mlgpg_num Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MEFFAG
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (3,0)
		/// <para>Description: EFFECTIVE AGE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Meffag
		{
			get
			{
				return this.MEFFAG;
			}

			set
			{
				if (this.MEFFAG.checkValue(value))
				{
					this.MEFFAG.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Meffag Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MPCOMP
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (3,2)
		/// <para>Description: PERCENT COMPLETE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mpcomp
		{
			get
			{
				return this.MPCOMP;
			}

			set
			{
				if (this.MPCOMP.checkValue(value))
				{
					this.MPCOMP.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mpcomp Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MSTTYP
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(4)
		/// <para>Description: PARCEL LOC STREET TYPE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Msttyp
		{
			get
			{
				return this.MSTTYP;
			}

			set
			{
				if (this.MSTTYP.checkValue(value))
				{
					this.MSTTYP.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Msttyp Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MSDIRS
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(2)
		/// <para>Description: PARCEL LOC DIRECT SUFFIX</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Msdirs
		{
			get
			{
				return this.MSDIRS;
			}

			set
			{
				if (this.MSDIRS.checkValue(value))
				{
					this.MSDIRS.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Msdirs Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - M1RATE
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (9,2)
		/// <para>Description: #1 FRONTAGE RATE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal M1rate
		{
			get
			{
				return this.M1RATE;
			}

			set
			{
				if (this.M1RATE.checkValue(value))
				{
					this.M1RATE.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the M1rate Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - M2RATE
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (9,2)
		/// <para>Description: #2 FRONTAGE RATE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal M2rate
		{
			get
			{
				return this.M2RATE;
			}

			set
			{
				if (this.M2RATE.checkValue(value))
				{
					this.M2RATE.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the M2rate Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MFUNCD
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (3,2)
		/// <para>Description: FUNCTIONAL DEPRECIATION</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mfuncd
		{
			get
			{
				return this.MFUNCD;
			}

			set
			{
				if (this.MFUNCD.checkValue(value))
				{
					this.MFUNCD.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mfuncd Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MECOND
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (3,2)
		/// <para>Description: ECONOMICAL DEPRECIATION</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mecond
		{
			get
			{
				return this.MECOND;
			}

			set
			{
				if (this.MECOND.checkValue(value))
				{
					this.MECOND.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mecond Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MNBRHD
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (4,0)
		/// <para>Description: NEIGHBORHOOD CODE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mnbrhd
		{
			get
			{
				return this.MNBRHD;
			}

			set
			{
				if (this.MNBRHD.checkValue(value))
				{
					this.MNBRHD.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mnbrhd Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MUSER1
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(1)
		/// <para>Description: USER FIELD 1</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Muser1
		{
			get
			{
				return this.MUSER1;
			}

			set
			{
				if (this.MUSER1.checkValue(value))
				{
					this.MUSER1.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Muser1 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MUSER2
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(1)
		/// <para>Description: USER FIELD 2</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Muser2
		{
			get
			{
				return this.MUSER2;
			}

			set
			{
				if (this.MUSER2.checkValue(value))
				{
					this.MUSER2.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Muser2 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MDBOOK
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(4)
		/// <para>Description: DEED BOOK NO</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mdbook
		{
			get
			{
				return this.MDBOOK;
			}

			set
			{
				if (this.MDBOOK.checkValue(value))
				{
					this.MDBOOK.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mdbook Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MDPAGE
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (4,0)
		/// <para>Description: DEED BOOK PAGE NO</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mdpage
		{
			get
			{
				return this.MDPAGE;
			}

			set
			{
				if (this.MDPAGE.checkValue(value))
				{
					this.MDPAGE.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mdpage Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MWBOOK
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(4)
		/// <para>Description: WILL BOOK NO</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mwbook
		{
			get
			{
				return this.MWBOOK;
			}

			set
			{
				if (this.MWBOOK.checkValue(value))
				{
					this.MWBOOK.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mwbook Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MWPAGE
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (4,0)
		/// <para>Description: WILL BOOK PAGE NO</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mwpage
		{
			get
			{
				return this.MWPAGE;
			}

			set
			{
				if (this.MWPAGE.checkValue(value))
				{
					this.MWPAGE.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mwpage Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MDCODE
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(1)
		/// <para>Description: DEED BOOK CODE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mdcode
		{
			get
			{
				return this.MDCODE;
			}

			set
			{
				if (this.MDCODE.checkValue(value))
				{
					this.MDCODE.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mdcode Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MWCODE
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(1)
		/// <para>Description: WILL BOOK CODE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mwcode
		{
			get
			{
				return this.MWCODE;
			}

			set
			{
				if (this.MWCODE.checkValue(value))
				{
					this.MWCODE.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mwcode Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MMORTC
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (3,0)
		/// <para>Description: MORTGAGE CO CODE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mmortc
		{
			get
			{
				return this.MMORTC;
			}

			set
			{
				if (this.MMORTC.checkValue(value))
				{
					this.MMORTC.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mmortc Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MFILL7
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(1)
		/// <para>Description: QUAL ASSUR APPR</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mfill7
		{
			get
			{
				return this.MFILL7;
			}

			set
			{
				if (this.MFILL7.checkValue(value))
				{
					this.MFILL7.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mfill7 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MACRE_NUM
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (11,5)
		/// <para>Description: TOTAL ACREAGE NUMERIC</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Macre_num
		{
			get
			{
				return this.MACRE_NUM;
			}

			set
			{
				if (this.MACRE_NUM.checkValue(value))
				{
					this.MACRE_NUM.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Macre_num Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MGISPN
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(30)
		/// <para>Description: GIS PIN#</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mgispn
		{
			get
			{
				return this.MGISPN;
			}

			set
			{
				if (this.MGISPN.checkValue(value))
				{
					this.MGISPN.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mgispn Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MUSER3
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(1)
		/// <para>Description: USER FIELD 3</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Muser3
		{
			get
			{
				return this.MUSER3;
			}

			set
			{
				if (this.MUSER3.checkValue(value))
				{
					this.MUSER3.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Muser3 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MUSER4
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(1)
		/// <para>Description: USER FIELD 4</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Muser4
		{
			get
			{
				return this.MUSER4;
			}

			set
			{
				if (this.MUSER4.checkValue(value))
				{
					this.MUSER4.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Muser4 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MIMADJ
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (8,0)
		/// <para>Description: IMPROVED VAL ADJUSTMENT</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mimadj
		{
			get
			{
				return this.MIMADJ;
			}

			set
			{
				if (this.MIMADJ.checkValue(value))
				{
					this.MIMADJ.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mimadj Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MCDRDT
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (8,0)
		/// <para>Description: DATE OF CHG IN REASSM</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mcdrdt
		{
			get
			{
				return this.MCDRDT;
			}

			set
			{
				if (this.MCDRDT.checkValue(value))
				{
					this.MCDRDT.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mcdrdt Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MMNUD
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (9,0)
		/// <para>Description: MINERAL VALUE UNDER DEV</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mmnud
		{
			get
			{
				return this.MMNUD;
			}

			set
			{
				if (this.MMNUD.checkValue(value))
				{
					this.MMNUD.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mmnud Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MMNNUD
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (9,0)
		/// <para>Description: MINERAL VAL NOT UNDER DV</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mmnnud
		{
			get
			{
				return this.MMNNUD;
			}

			set
			{
				if (this.MMNNUD.checkValue(value))
				{
					this.MMNNUD.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mmnnud Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MSS1
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (9,0)
		/// <para>Description: PRIMARY SOC SEC NO</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mss1
		{
			get
			{
				return this.MSS1;
			}

			set
			{
				if (this.MSS1.checkValue(value))
				{
					this.MSS1.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mss1 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MPCODE
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(1)
		/// <para>Description: PLAT BOOK CODE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mpcode
		{
			get
			{
				return this.MPCODE;
			}

			set
			{
				if (this.MPCODE.checkValue(value))
				{
					this.MPCODE.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mpcode Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MPBOOK
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(4)
		/// <para>Description: PLAT BOOK NO</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mpbook
		{
			get
			{
				return this.MPBOOK;
			}

			set
			{
				if (this.MPBOOK.checkValue(value))
				{
					this.MPBOOK.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mpbook Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MPPAGE
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (4,0)
		/// <para>Description: PLAT BOOK PAGE NO</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mppage
		{
			get
			{
				return this.MPPAGE;
			}

			set
			{
				if (this.MPPAGE.checkValue(value))
				{
					this.MPPAGE.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mppage Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MSS2
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (9,0)
		/// <para>Description: SECONDARY SOC SEC NO</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mss2
		{
			get
			{
				return this.MSS2;
			}

			set
			{
				if (this.MSS2.checkValue(value))
				{
					this.MSS2.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mss2 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MASSM
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (9,0)
		/// <para>Description: MINERAL VAL FROM LOC</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Massm
		{
			get
			{
				return this.MASSM;
			}

			set
			{
				if (this.MASSM.checkValue(value))
				{
					this.MASSM.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Massm Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MFILL9
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(4)
		/// <para>Description: FILL9 UPDATE CD</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mfill9
		{
			get
			{
				return this.MFILL9;
			}

			set
			{
				if (this.MFILL9.checkValue(value))
				{
					this.MFILL9.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mfill9 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MGRNTR
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(35)
		/// <para>Description: GRANTOR</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mgrntr
		{
			get
			{
				return this.MGRNTR;
			}

			set
			{
				if (this.MGRNTR.checkValue(value))
				{
					this.MGRNTR.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mgrntr Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MCVMO
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: MONTH-LAST VALUE CHG</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mcvmo
		{
			get
			{
				return this.MCVMO;
			}

			set
			{
				if (this.MCVMO.checkValue(value))
				{
					this.MCVMO.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mcvmo Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MCVDA
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: DAY-LAST VALUE CHG</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mcvda
		{
			get
			{
				return this.MCVDA;
			}

			set
			{
				if (this.MCVDA.checkValue(value))
				{
					this.MCVDA.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mcvda Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MCVYR
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (4,0)
		/// <para>Description: YEAR-LAST VALUE CHG</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mcvyr
		{
			get
			{
				return this.MCVYR;
			}

			set
			{
				if (this.MCVYR.checkValue(value))
				{
					this.MCVYR.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mcvyr Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MPROUT
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(4)
		/// <para>Description: POSTAL CARRIER RT</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mprout
		{
			get
			{
				return this.MPROUT;
			}

			set
			{
				if (this.MPROUT.checkValue(value))
				{
					this.MPROUT.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mprout Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MPERR
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(3)
		/// <para>Description: POSTAL ERROR CODE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mperr
		{
			get
			{
				return this.MPERR;
			}

			set
			{
				if (this.MPERR.checkValue(value))
				{
					this.MPERR.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mperr Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MTBIMP
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (10,0)
		/// <para>Description: INTERIOR IMPROV VALUE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mtbimp
		{
			get
			{
				return this.MTBIMP;
			}

			set
			{
				if (this.MTBIMP.checkValue(value))
				{
					this.MTBIMP.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mtbimp Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MPUSE
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (6,0)
		/// <para>Description: PROP USE CODE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mpuse
		{
			get
			{
				return this.MPUSE;
			}

			set
			{
				if (this.MPUSE.checkValue(value))
				{
					this.MPUSE.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mpuse Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MCVEXP
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(23)
		/// <para>Description: VAL CHG EXPLAINED</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mcvexp
		{
			get
			{
				return this.MCVEXP;
			}

			set
			{
				if (this.MCVEXP.checkValue(value))
				{
					this.MCVEXP.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mcvexp Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - METXYR
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (4,0)
		/// <para>Description: EFF TAX YR CURR VAL</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Metxyr
		{
			get
			{
				return this.METXYR;
			}

			set
			{
				if (this.METXYR.checkValue(value))
				{
					this.METXYR.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Metxyr Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MQAPCH
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (8,4)
		/// <para>Description: QUAL ASSUR % OF CHG</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mqapch
		{
			get
			{
				return this.MQAPCH;
			}

			set
			{
				if (this.MQAPCH.checkValue(value))
				{
					this.MQAPCH.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mqapch Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MQAFIL
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(10)
		/// <para>Description: QUAL ASSUR WORK FIELD</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mqafil
		{
			get
			{
				return this.MQAFIL;
			}

			set
			{
				if (this.MQAFIL.checkValue(value))
				{
					this.MQAFIL.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mqafil Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MPICT
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(6)
		/// <para>Description: DIGITAL PICT REFERENCE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mpict
		{
			get
			{
				return this.MPICT;
			}

			set
			{
				if (this.MPICT.checkValue(value))
				{
					this.MPICT.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mpict Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MEACRE
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (11,5)
		/// <para>Description: GIS ESTIMATED ACREAGE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Meacre
		{
			get
			{
				return this.MEACRE;
			}

			set
			{
				if (this.MEACRE.checkValue(value))
				{
					this.MEACRE.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Meacre Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MPRCIT
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(25)
		/// <para>Description: PROP ADR CITY</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mprcit
		{
			get
			{
				return this.MPRCIT;
			}

			set
			{
				if (this.MPRCIT.checkValue(value))
				{
					this.MPRCIT.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mprcit Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MPRSTA
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(2)
		/// <para>Description: PROP ADR STATE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mprsta
		{
			get
			{
				return this.MPRSTA;
			}

			set
			{
				if (this.MPRSTA.checkValue(value))
				{
					this.MPRSTA.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mprsta Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MPRZP1
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (5,0)
		/// <para>Description: PROP ADR ZIP</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mprzp1
		{
			get
			{
				return this.MPRZP1;
			}

			set
			{
				if (this.MPRZP1.checkValue(value))
				{
					this.MPRZP1.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mprzp1 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MPRZP4
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(4)
		/// <para>Description: PROP ADR ZIP+4</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mprzp4
		{
			get
			{
				return this.MPRZP4;
			}

			set
			{
				if (this.MPRZP4.checkValue(value))
				{
					this.MPRZP4.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mprzp4 Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MFP_NUM
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: # FIREPLACES</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mfp_num
		{
			get
			{
				return this.MFP_NUM;
			}

			set
			{
				if (this.MFP_NUM.checkValue(value))
				{
					this.MFP_NUM.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mfp_num Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MSFP_NUM
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: # STACKED FP</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Msfp_num
		{
			get
			{
				return this.MSFP_NUM;
			}

			set
			{
				if (this.MSFP_NUM.checkValue(value))
				{
					this.MSFP_NUM.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Msfp_num Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MFL_NUM
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: # FLUES</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mfl_num
		{
			get
			{
				return this.MFL_NUM;
			}

			set
			{
				if (this.MFL_NUM.checkValue(value))
				{
					this.MFL_NUM.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mfl_num Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MSFL_NUM
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: # STACKED FL</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Msfl_num
		{
			get
			{
				return this.MSFL_NUM;
			}

			set
			{
				if (this.MSFL_NUM.checkValue(value))
				{
					this.MSFL_NUM.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Msfl_num Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MMFL_NUM
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: # METAL FLUES</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mmfl_num
		{
			get
			{
				return this.MMFL_NUM;
			}

			set
			{
				if (this.MMFL_NUM.checkValue(value))
				{
					this.MMFL_NUM.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mmfl_num Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MIOFP_NUM
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: # INOPERABLE FL/FP</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Miofp_num
		{
			get
			{
				return this.MIOFP_NUM;
			}

			set
			{
				if (this.MIOFP_NUM.checkValue(value))
				{
					this.MIOFP_NUM.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Miofp_num Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MSTOR_NUM
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (4,2)
		/// <para>Description: STORY HEIGHT</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mstor_num
		{
			get
			{
				return this.MSTOR_NUM;
			}

			set
			{
				if (this.MSTOR_NUM.checkValue(value))
				{
					this.MSTOR_NUM.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mstor_num Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MASCOM
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(30)
		/// <para>Description: ASSESSOR COMM</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mascom
		{
			get
			{
				return this.MASCOM;
			}

			set
			{
				if (this.MASCOM.checkValue(value))
				{
					this.MASCOM.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mascom Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MHRPH_NUM
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (9,0)
		/// <para>Description: HEARG PHONE#</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mhrph_num
		{
			get
			{
				return this.MHRPH_NUM;
			}

			set
			{
				if (this.MHRPH_NUM.checkValue(value))
				{
					this.MHRPH_NUM.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mhrph_num Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MHRDAT
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (8,0)
		/// <para>Description: HEARG DATE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mhrdat
		{
			get
			{
				return this.MHRDAT;
			}

			set
			{
				if (this.MHRDAT.checkValue(value))
				{
					this.MHRDAT.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mhrdat Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MHRTIM
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (4,0)
		/// <para>Description: HEARG TIME</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mhrtim
		{
			get
			{
				return this.MHRTIM;
			}

			set
			{
				if (this.MHRTIM.checkValue(value))
				{
					this.MHRTIM.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mhrtim Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MHRNAM
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(35)
		/// <para>Description: HEARG CALLER NAM</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mhrnam
		{
			get
			{
				return this.MHRNAM;
			}

			set
			{
				if (this.MHRNAM.checkValue(value))
				{
					this.MHRNAM.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mhrnam Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MHRSES
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(1)
		/// <para>Description: HEARG SESSION</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mhrses
		{
			get
			{
				return this.MHRSES;
			}

			set
			{
				if (this.MHRSES.checkValue(value))
				{
					this.MHRSES.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mhrses Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MHIDPC
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(1)
		/// <para>Description: HIDE PICTURE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mhidpc
		{
			get
			{
				return this.MHIDPC;
			}

			set
			{
				if (this.MHIDPC.checkValue(value))
				{
					this.MHIDPC.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mhidpc Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MHIDNM
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as CHAR(1)
		/// <para>Description: HIDE NAME</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedString
		/// </returns>
		public FixedString Mhidnm
		{
			get
			{
				return this.MHIDNM;
			}

			set
			{
				if (this.MHIDNM.checkValue(value))
				{
					this.MHIDNM.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mhidnm Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MCAMO
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: MONTH-LAST ADDRS CHG</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mcamo
		{
			get
			{
				return this.MCAMO;
			}

			set
			{
				if (this.MCAMO.checkValue(value))
				{
					this.MCAMO.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mcamo Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MCADA
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: DAY-LAST ADDRS CHG</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mcada
		{
			get
			{
				return this.MCADA;
			}

			set
			{
				if (this.MCADA.checkValue(value))
				{
					this.MCADA.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mcada Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MCAYR
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (4,0)
		/// <para>Description: YEAR-LAST ADDRS CHG</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Mcayr
		{
			get
			{
				return this.MCAYR;
			}

			set
			{
				if (this.MCAYR.checkValue(value))
				{
					this.MCAYR.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Mcayr Property.");
				}
			}
		}

		/// <summary>
		/// Gets or sets the DataBase Field - MOLDOC
		/// </summary>
		/// <remarks>
		/// Field defined in DataBase as NUMERIC (2,0)
		/// <para>Description: OLD OCCUP CODE</para>
		/// </remarks>
		/// <returns>
		/// The property as a FixedDecimal
		/// </returns>
		public FixedDecimal Moldoc
		{
			get
			{
				return this.MOLDOC;
			}

			set
			{
				if (this.MOLDOC.checkValue(value))
				{
					this.MOLDOC.setValue(value);
				}
				else
				{
					throw new OverflowException("Value outside established bounds for the Moldoc Property.");
				}
			}
		}

		#endregion Properties

		#region Public Static Methods

		/// <summary>
		/// Builds a parameterized string for Updating the file.
		/// </summary>
		/// <param name="QualifiedDatabaseAndTableName">The qualified database and Table name for the update.</param>
		/// <example>string sql = REMaster.ParameterizedUpdateSQL("database.table");
		/// </example>
		/// <returns>The parameterized SQL statement.</returns>
		public static string ParameterizedUpdateSQL(string QualifiedDatabaseAndTableName)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("update ");
			sb.Append(QualifiedDatabaseAndTableName);
			sb.Append(" set ");
			string[] updFieldsActual = REMaster.nonKeyFieldsActual.Split(new char[] { ',' });
			string[] updFieldsAdjusted = REMaster.nonKeyFieldsAdjusted.Split(new char[] { ',' });
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
		/// <example>string sql = REMaster.ParameterizedInsertSQL("database.table");
		/// </example>
		/// <returns>The parameterized SQL statement.</returns>
		public static string ParameterizedInsertSQL(string QualifiedDatabaseAndTableName)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("insert into ");
			sb.Append(QualifiedDatabaseAndTableName);
			sb.Append(" (");
			sb.Append(REMaster.allFieldNamesActual);
			sb.Append(") ");
			sb.Append("values( ");
			string[] insFields = REMaster.allFieldNamesAdjusted.Split(new char[] { ',' });
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
			IDataParameter parm_MRECID = db.CreateParameter("@MRECID", DatabaseConstants.DataTypes.Char, "MRECID", 1, 0);
			parms.Add(parm_MRECID);
			IDataParameter parm_MRECNO = db.CreateParameter("@MRECNO", DatabaseConstants.DataTypes.Numeric, "MRECNO", 7, 0);
			parms.Add(parm_MRECNO);
			IDataParameter parm_MDWELL = db.CreateParameter("@MDWELL", DatabaseConstants.DataTypes.Numeric, "MDWELL", 2, 0);
			parms.Add(parm_MDWELL);
			IDataParameter parm_MMAP = db.CreateParameter("@MMAP", DatabaseConstants.DataTypes.Char, "MMAP", 20, 0);
			parms.Add(parm_MMAP);
			IDataParameter parm_MLNAM = db.CreateParameter("@MLNAM", DatabaseConstants.DataTypes.Char, "MLNAM", 35, 0);
			parms.Add(parm_MLNAM);
			IDataParameter parm_MFNAM = db.CreateParameter("@MFNAM", DatabaseConstants.DataTypes.Char, "MFNAM", 35, 0);
			parms.Add(parm_MFNAM);
			IDataParameter parm_MADD1 = db.CreateParameter("@MADD1", DatabaseConstants.DataTypes.Char, "MADD1", 50, 0);
			parms.Add(parm_MADD1);
			IDataParameter parm_MADD2 = db.CreateParameter("@MADD2", DatabaseConstants.DataTypes.Char, "MADD2", 50, 0);
			parms.Add(parm_MADD2);
			IDataParameter parm_MCITY = db.CreateParameter("@MCITY", DatabaseConstants.DataTypes.Char, "MCITY", 25, 0);
			parms.Add(parm_MCITY);
			IDataParameter parm_MSTATE = db.CreateParameter("@MSTATE", DatabaseConstants.DataTypes.Char, "MSTATE", 2, 0);
			parms.Add(parm_MSTATE);
			IDataParameter parm_MZIP5 = db.CreateParameter("@MZIP5", DatabaseConstants.DataTypes.Numeric, "MZIP5", 5, 0);
			parms.Add(parm_MZIP5);
			IDataParameter parm_MZIP4 = db.CreateParameter("@MZIP4", DatabaseConstants.DataTypes.Char, "MZIP4", 4, 0);
			parms.Add(parm_MZIP4);
			IDataParameter parm_MACRE = db.CreateParameter("@MACRE", DatabaseConstants.DataTypes.Char, "MACRE", 9, 0);
			parms.Add(parm_MACRE);
			IDataParameter parm_MZONE = db.CreateParameter("@MZONE", DatabaseConstants.DataTypes.Char, "MZONE", 4, 0);
			parms.Add(parm_MZONE);
			IDataParameter parm_MLUSE = db.CreateParameter("@MLUSE", DatabaseConstants.DataTypes.Char, "MLUSE", 2, 0);
			parms.Add(parm_MLUSE);
			IDataParameter parm_MOCCUP = db.CreateParameter("@MOCCUP", DatabaseConstants.DataTypes.Numeric, "MOCCUP", 2, 0);
			parms.Add(parm_MOCCUP);
			IDataParameter parm_MSTORY = db.CreateParameter("@MSTORY", DatabaseConstants.DataTypes.Char, "MSTORY", 3, 0);
			parms.Add(parm_MSTORY);
			IDataParameter parm_MAGE = db.CreateParameter("@MAGE", DatabaseConstants.DataTypes.Numeric, "MAGE", 3, 0);
			parms.Add(parm_MAGE);
			IDataParameter parm_MCOND = db.CreateParameter("@MCOND", DatabaseConstants.DataTypes.Char, "MCOND", 1, 0);
			parms.Add(parm_MCOND);
			IDataParameter parm_MCLASS = db.CreateParameter("@MCLASS", DatabaseConstants.DataTypes.Char, "MCLASS", 1, 0);
			parms.Add(parm_MCLASS);
			IDataParameter parm_MFACTR = db.CreateParameter("@MFACTR", DatabaseConstants.DataTypes.Numeric, "MFACTR", 3, 2);
			parms.Add(parm_MFACTR);
			IDataParameter parm_MDEPRC = db.CreateParameter("@MDEPRC", DatabaseConstants.DataTypes.Numeric, "MDEPRC", 3, 2);
			parms.Add(parm_MDEPRC);
			IDataParameter parm_MFOUND = db.CreateParameter("@MFOUND", DatabaseConstants.DataTypes.Numeric, "MFOUND", 2, 0);
			parms.Add(parm_MFOUND);
			IDataParameter parm_MEXWLL = db.CreateParameter("@MEXWLL", DatabaseConstants.DataTypes.Numeric, "MEXWLL", 2, 0);
			parms.Add(parm_MEXWLL);
			IDataParameter parm_MROOFT = db.CreateParameter("@MROOFT", DatabaseConstants.DataTypes.Numeric, "MROOFT", 2, 0);
			parms.Add(parm_MROOFT);
			IDataParameter parm_MROOFG = db.CreateParameter("@MROOFG", DatabaseConstants.DataTypes.Numeric, "MROOFG", 2, 0);
			parms.Add(parm_MROOFG);
			IDataParameter parm_M_NUMDUNT = db.CreateParameter("@M_NUMDUNT", DatabaseConstants.DataTypes.Numeric, "M#DUNT", 3, 0);
			parms.Add(parm_M_NUMDUNT);
			IDataParameter parm_M_NUMROOM = db.CreateParameter("@M_NUMROOM", DatabaseConstants.DataTypes.Numeric, "M#ROOM", 3, 0);
			parms.Add(parm_M_NUMROOM);
			IDataParameter parm_M_NUMBR = db.CreateParameter("@M_NUMBR", DatabaseConstants.DataTypes.Numeric, "M#BR", 3, 0);
			parms.Add(parm_M_NUMBR);
			IDataParameter parm_M_NUMFBTH = db.CreateParameter("@M_NUMFBTH", DatabaseConstants.DataTypes.Numeric, "M#FBTH", 2, 0);
			parms.Add(parm_M_NUMFBTH);
			IDataParameter parm_M_NUMHBTH = db.CreateParameter("@M_NUMHBTH", DatabaseConstants.DataTypes.Numeric, "M#HBTH", 2, 0);
			parms.Add(parm_M_NUMHBTH);
			IDataParameter parm_MFP2 = db.CreateParameter("@MFP2", DatabaseConstants.DataTypes.Char, "MFP2", 3, 0);
			parms.Add(parm_MFP2);
			IDataParameter parm_MLTRCD = db.CreateParameter("@MLTRCD", DatabaseConstants.DataTypes.Char, "MLTRCD", 1, 0);
			parms.Add(parm_MLTRCD);
			IDataParameter parm_MHEAT = db.CreateParameter("@MHEAT", DatabaseConstants.DataTypes.Numeric, "MHEAT", 2, 0);
			parms.Add(parm_MHEAT);
			IDataParameter parm_MFUEL = db.CreateParameter("@MFUEL", DatabaseConstants.DataTypes.Numeric, "MFUEL", 2, 0);
			parms.Add(parm_MFUEL);
			IDataParameter parm_MAC = db.CreateParameter("@MAC", DatabaseConstants.DataTypes.Char, "MAC", 1, 0);
			parms.Add(parm_MAC);
			IDataParameter parm_MFP1 = db.CreateParameter("@MFP1", DatabaseConstants.DataTypes.Char, "MFP1", 2, 0);
			parms.Add(parm_MFP1);
			IDataParameter parm_MCDR = db.CreateParameter("@MCDR", DatabaseConstants.DataTypes.Char, "MCDR", 1, 0);
			parms.Add(parm_MCDR);
			IDataParameter parm_MEKIT = db.CreateParameter("@MEKIT", DatabaseConstants.DataTypes.Numeric, "MEKIT", 1, 0);
			parms.Add(parm_MEKIT);
			IDataParameter parm_MBASTP = db.CreateParameter("@MBASTP", DatabaseConstants.DataTypes.Numeric, "MBASTP", 2, 0);
			parms.Add(parm_MBASTP);
			IDataParameter parm_MPBTOT = db.CreateParameter("@MPBTOT", DatabaseConstants.DataTypes.Numeric, "MPBTOT", 3, 2);
			parms.Add(parm_MPBTOT);
			IDataParameter parm_MSBTOT = db.CreateParameter("@MSBTOT", DatabaseConstants.DataTypes.Numeric, "MSBTOT", 6, 0);
			parms.Add(parm_MSBTOT);
			IDataParameter parm_MPBFIN = db.CreateParameter("@MPBFIN", DatabaseConstants.DataTypes.Numeric, "MPBFIN", 3, 2);
			parms.Add(parm_MPBFIN);
			IDataParameter parm_MSBFIN = db.CreateParameter("@MSBFIN", DatabaseConstants.DataTypes.Numeric, "MSBFIN", 6, 0);
			parms.Add(parm_MSBFIN);
			IDataParameter parm_MBRATE = db.CreateParameter("@MBRATE", DatabaseConstants.DataTypes.Numeric, "MBRATE", 5, 2);
			parms.Add(parm_MBRATE);
			IDataParameter parm_M_NUMFLUE = db.CreateParameter("@M_NUMFLUE", DatabaseConstants.DataTypes.Numeric, "M#FLUE", 2, 0);
			parms.Add(parm_M_NUMFLUE);
			IDataParameter parm_MFLUTP = db.CreateParameter("@MFLUTP", DatabaseConstants.DataTypes.Char, "MFLUTP", 1, 0);
			parms.Add(parm_MFLUTP);
			IDataParameter parm_MGART = db.CreateParameter("@MGART", DatabaseConstants.DataTypes.Numeric, "MGART", 2, 0);
			parms.Add(parm_MGART);
			IDataParameter parm_MGAR_NUMC = db.CreateParameter("@MGAR_NUMC", DatabaseConstants.DataTypes.Numeric, "MGAR#C", 2, 0);
			parms.Add(parm_MGAR_NUMC);
			IDataParameter parm_MCARPT = db.CreateParameter("@MCARPT", DatabaseConstants.DataTypes.Numeric, "MCARPT", 2, 0);
			parms.Add(parm_MCARPT);
			IDataParameter parm_MCAR_NUMC = db.CreateParameter("@MCAR_NUMC", DatabaseConstants.DataTypes.Numeric, "MCAR#C", 2, 0);
			parms.Add(parm_MCAR_NUMC);
			IDataParameter parm_MBI_NUMC = db.CreateParameter("@MBI_NUMC", DatabaseConstants.DataTypes.Numeric, "MBI#C", 2, 0);
			parms.Add(parm_MBI_NUMC);
			IDataParameter parm_MROW = db.CreateParameter("@MROW", DatabaseConstants.DataTypes.Numeric, "MROW", 2, 0);
			parms.Add(parm_MROW);
			IDataParameter parm_MEASE = db.CreateParameter("@MEASE", DatabaseConstants.DataTypes.Numeric, "MEASE", 2, 0);
			parms.Add(parm_MEASE);
			IDataParameter parm_MWATER = db.CreateParameter("@MWATER", DatabaseConstants.DataTypes.Numeric, "MWATER", 2, 0);
			parms.Add(parm_MWATER);
			IDataParameter parm_MSEWER = db.CreateParameter("@MSEWER", DatabaseConstants.DataTypes.Numeric, "MSEWER", 2, 0);
			parms.Add(parm_MSEWER);
			IDataParameter parm_MGAS = db.CreateParameter("@MGAS", DatabaseConstants.DataTypes.Char, "MGAS", 1, 0);
			parms.Add(parm_MGAS);
			IDataParameter parm_MELEC = db.CreateParameter("@MELEC", DatabaseConstants.DataTypes.Char, "MELEC", 1, 0);
			parms.Add(parm_MELEC);
			IDataParameter parm_MTERRN = db.CreateParameter("@MTERRN", DatabaseConstants.DataTypes.Numeric, "MTERRN", 2, 0);
			parms.Add(parm_MTERRN);
			IDataParameter parm_MCHAR = db.CreateParameter("@MCHAR", DatabaseConstants.DataTypes.Numeric, "MCHAR", 2, 0);
			parms.Add(parm_MCHAR);
			IDataParameter parm_MOTDES = db.CreateParameter("@MOTDES", DatabaseConstants.DataTypes.Char, "MOTDES", 20, 0);
			parms.Add(parm_MOTDES);
			IDataParameter parm_MGART2 = db.CreateParameter("@MGART2", DatabaseConstants.DataTypes.Numeric, "MGART2", 2, 0);
			parms.Add(parm_MGART2);
			IDataParameter parm_MGAR_NUM2 = db.CreateParameter("@MGAR_NUM2", DatabaseConstants.DataTypes.Numeric, "MGAR#2", 2, 0);
			parms.Add(parm_MGAR_NUM2);
			IDataParameter parm_MDATLG = db.CreateParameter("@MDATLG", DatabaseConstants.DataTypes.Numeric, "MDATLG", 8, 0);
			parms.Add(parm_MDATLG);
			IDataParameter parm_MDATPR = db.CreateParameter("@MDATPR", DatabaseConstants.DataTypes.Numeric, "MDATPR", 8, 0);
			parms.Add(parm_MDATPR);
			IDataParameter parm_MINTYP = db.CreateParameter("@MINTYP", DatabaseConstants.DataTypes.Char, "MINTYP", 2, 0);
			parms.Add(parm_MINTYP);
			IDataParameter parm_MINTYR = db.CreateParameter("@MINTYR", DatabaseConstants.DataTypes.Numeric, "MINTYR", 4, 0);
			parms.Add(parm_MINTYR);
			IDataParameter parm_MINNO_NUM = db.CreateParameter("@MINNO_NUM", DatabaseConstants.DataTypes.Numeric, "MINNO#", 7, 0);
			parms.Add(parm_MINNO_NUM);
			IDataParameter parm_MINNO2 = db.CreateParameter("@MINNO2", DatabaseConstants.DataTypes.Numeric, "MINNO2", 2, 0);
			parms.Add(parm_MINNO2);
			IDataParameter parm_MDSUFX = db.CreateParameter("@MDSUFX", DatabaseConstants.DataTypes.Char, "MDSUFX", 1, 0);
			parms.Add(parm_MDSUFX);
			IDataParameter parm_MWSUFX = db.CreateParameter("@MWSUFX", DatabaseConstants.DataTypes.Char, "MWSUFX", 1, 0);
			parms.Add(parm_MWSUFX);
			IDataParameter parm_MPSUFX = db.CreateParameter("@MPSUFX", DatabaseConstants.DataTypes.Char, "MPSUFX", 1, 0);
			parms.Add(parm_MPSUFX);
			IDataParameter parm_MIMPRV = db.CreateParameter("@MIMPRV", DatabaseConstants.DataTypes.Numeric, "MIMPRV", 10, 0);
			parms.Add(parm_MIMPRV);
			IDataParameter parm_MTOTLD = db.CreateParameter("@MTOTLD", DatabaseConstants.DataTypes.Numeric, "MTOTLD", 10, 0);
			parms.Add(parm_MTOTLD);
			IDataParameter parm_MTOTOI = db.CreateParameter("@MTOTOI", DatabaseConstants.DataTypes.Numeric, "MTOTOI", 10, 0);
			parms.Add(parm_MTOTOI);
			IDataParameter parm_MTOTPR = db.CreateParameter("@MTOTPR", DatabaseConstants.DataTypes.Numeric, "MTOTPR", 10, 0);
			parms.Add(parm_MTOTPR);
			IDataParameter parm_MASSB = db.CreateParameter("@MASSB", DatabaseConstants.DataTypes.Numeric, "MASSB", 10, 0);
			parms.Add(parm_MASSB);
			IDataParameter parm_MACPCT = db.CreateParameter("@MACPCT", DatabaseConstants.DataTypes.Numeric, "MACPCT", 3, 2);
			parms.Add(parm_MACPCT);
			IDataParameter parm_M1FRNT = db.CreateParameter("@M1FRNT", DatabaseConstants.DataTypes.Numeric, "M1FRNT", 7, 2);
			parms.Add(parm_M1FRNT);
			IDataParameter parm_M1DPTH = db.CreateParameter("@M1DPTH", DatabaseConstants.DataTypes.Numeric, "M1DPTH", 7, 2);
			parms.Add(parm_M1DPTH);
			IDataParameter parm_M1AREA = db.CreateParameter("@M1AREA", DatabaseConstants.DataTypes.Numeric, "M1AREA", 7, 0);
			parms.Add(parm_M1AREA);
			IDataParameter parm_MMCODE = db.CreateParameter("@MMCODE", DatabaseConstants.DataTypes.Numeric, "MMCODE", 3, 0);
			parms.Add(parm_MMCODE);
			IDataParameter parm_M0DEPR = db.CreateParameter("@M0DEPR", DatabaseConstants.DataTypes.Char, "M0DEPR", 1, 0);
			parms.Add(parm_M0DEPR);
			IDataParameter parm_M1UM = db.CreateParameter("@M1UM", DatabaseConstants.DataTypes.Char, "M1UM", 1, 0);
			parms.Add(parm_M1UM);
			IDataParameter parm_M2FRNT = db.CreateParameter("@M2FRNT", DatabaseConstants.DataTypes.Numeric, "M2FRNT", 7, 2);
			parms.Add(parm_M2FRNT);
			IDataParameter parm_M2DPTH = db.CreateParameter("@M2DPTH", DatabaseConstants.DataTypes.Numeric, "M2DPTH", 7, 2);
			parms.Add(parm_M2DPTH);
			IDataParameter parm_M2AREA = db.CreateParameter("@M2AREA", DatabaseConstants.DataTypes.Numeric, "M2AREA", 7, 0);
			parms.Add(parm_M2AREA);
			IDataParameter parm_MZIPBR = db.CreateParameter("@MZIPBR", DatabaseConstants.DataTypes.Char, "MZIPBR", 3, 0);
			parms.Add(parm_MZIPBR);
			IDataParameter parm_MDELAY = db.CreateParameter("@MDELAY", DatabaseConstants.DataTypes.Char, "MDELAY", 1, 0);
			parms.Add(parm_MDELAY);
			IDataParameter parm_M2UM = db.CreateParameter("@M2UM", DatabaseConstants.DataTypes.Char, "M2UM", 1, 0);
			parms.Add(parm_M2UM);
			IDataParameter parm_MSTRT = db.CreateParameter("@MSTRT", DatabaseConstants.DataTypes.Char, "MSTRT", 17, 0);
			parms.Add(parm_MSTRT);
			IDataParameter parm_MDIRCT = db.CreateParameter("@MDIRCT", DatabaseConstants.DataTypes.Char, "MDIRCT", 2, 0);
			parms.Add(parm_MDIRCT);
			IDataParameter parm_MHSE_NUM = db.CreateParameter("@MHSE_NUM", DatabaseConstants.DataTypes.Numeric, "MHSE#", 5, 0);
			parms.Add(parm_MHSE_NUM);
			IDataParameter parm_MCDMO = db.CreateParameter("@MCDMO", DatabaseConstants.DataTypes.Numeric, "MCDMO", 2, 0);
			parms.Add(parm_MCDMO);
			IDataParameter parm_MCDDA = db.CreateParameter("@MCDDA", DatabaseConstants.DataTypes.Numeric, "MCDDA", 2, 0);
			parms.Add(parm_MCDDA);
			IDataParameter parm_MCDYR = db.CreateParameter("@MCDYR", DatabaseConstants.DataTypes.Numeric, "MCDYR", 4, 0);
			parms.Add(parm_MCDYR);
			IDataParameter parm_M1DFAC = db.CreateParameter("@M1DFAC", DatabaseConstants.DataTypes.Numeric, "M1DFAC", 4, 3);
			parms.Add(parm_M1DFAC);
			IDataParameter parm_MREM1 = db.CreateParameter("@MREM1", DatabaseConstants.DataTypes.Char, "MREM1", 35, 0);
			parms.Add(parm_MREM1);
			IDataParameter parm_MREM2 = db.CreateParameter("@MREM2", DatabaseConstants.DataTypes.Char, "MREM2", 35, 0);
			parms.Add(parm_MREM2);
			IDataParameter parm_MMAGCD = db.CreateParameter("@MMAGCD", DatabaseConstants.DataTypes.Char, "MMAGCD", 2, 0);
			parms.Add(parm_MMAGCD);
			IDataParameter parm_MATHOM = db.CreateParameter("@MATHOM", DatabaseConstants.DataTypes.Char, "MATHOM", 1, 0);
			parms.Add(parm_MATHOM);
			IDataParameter parm_MDESC1 = db.CreateParameter("@MDESC1", DatabaseConstants.DataTypes.Char, "MDESC1", 35, 0);
			parms.Add(parm_MDESC1);
			IDataParameter parm_MDESC2 = db.CreateParameter("@MDESC2", DatabaseConstants.DataTypes.Char, "MDESC2", 35, 0);
			parms.Add(parm_MDESC2);
			IDataParameter parm_MDESC3 = db.CreateParameter("@MDESC3", DatabaseConstants.DataTypes.Char, "MDESC3", 35, 0);
			parms.Add(parm_MDESC3);
			IDataParameter parm_MDESC4 = db.CreateParameter("@MDESC4", DatabaseConstants.DataTypes.Char, "MDESC4", 35, 0);
			parms.Add(parm_MDESC4);
			IDataParameter parm_MFAIRV = db.CreateParameter("@MFAIRV", DatabaseConstants.DataTypes.Numeric, "MFAIRV", 8, 0);
			parms.Add(parm_MFAIRV);
			IDataParameter parm_MLGITY = db.CreateParameter("@MLGITY", DatabaseConstants.DataTypes.Char, "MLGITY", 2, 0);
			parms.Add(parm_MLGITY);
			IDataParameter parm_MLGIYR = db.CreateParameter("@MLGIYR", DatabaseConstants.DataTypes.Numeric, "MLGIYR", 4, 0);
			parms.Add(parm_MLGIYR);
			IDataParameter parm_MLGNO_NUM = db.CreateParameter("@MLGNO_NUM", DatabaseConstants.DataTypes.Numeric, "MLGNO#", 5, 0);
			parms.Add(parm_MLGNO_NUM);
			IDataParameter parm_MLGNO2 = db.CreateParameter("@MLGNO2", DatabaseConstants.DataTypes.Numeric, "MLGNO2", 2, 0);
			parms.Add(parm_MLGNO2);
			IDataParameter parm_MSUBDV = db.CreateParameter("@MSUBDV", DatabaseConstants.DataTypes.Char, "MSUBDV", 3, 0);
			parms.Add(parm_MSUBDV);
			IDataParameter parm_MSELLP = db.CreateParameter("@MSELLP", DatabaseConstants.DataTypes.Numeric, "MSELLP", 8, 0);
			parms.Add(parm_MSELLP);
			IDataParameter parm_M2DFAC = db.CreateParameter("@M2DFAC", DatabaseConstants.DataTypes.Numeric, "M2DFAC", 4, 3);
			parms.Add(parm_M2DFAC);
			IDataParameter parm_MINIT = db.CreateParameter("@MINIT", DatabaseConstants.DataTypes.Char, "MINIT", 5, 0);
			parms.Add(parm_MINIT);
			IDataParameter parm_MINSPD = db.CreateParameter("@MINSPD", DatabaseConstants.DataTypes.Numeric, "MINSPD", 8, 0);
			parms.Add(parm_MINSPD);
			IDataParameter parm_MSWL = db.CreateParameter("@MSWL", DatabaseConstants.DataTypes.Numeric, "MSWL", 5, 0);
			parms.Add(parm_MSWL);
			IDataParameter parm_MTUTIL = db.CreateParameter("@MTUTIL", DatabaseConstants.DataTypes.Numeric, "MTUTIL", 5, 0);
			parms.Add(parm_MTUTIL);
			IDataParameter parm_MNBADJ = db.CreateParameter("@MNBADJ", DatabaseConstants.DataTypes.Numeric, "MNBADJ", 3, 2);
			parms.Add(parm_MNBADJ);
			IDataParameter parm_MASSL = db.CreateParameter("@MASSL", DatabaseConstants.DataTypes.Numeric, "MASSL", 10, 0);
			parms.Add(parm_MASSL);
			IDataParameter parm_MACSF = db.CreateParameter("@MACSF", DatabaseConstants.DataTypes.Numeric, "MACSF", 6, 0);
			parms.Add(parm_MACSF);
			IDataParameter parm_MCOMM1 = db.CreateParameter("@MCOMM1", DatabaseConstants.DataTypes.Char, "MCOMM1", 25, 0);
			parms.Add(parm_MCOMM1);
			IDataParameter parm_MCOMM2 = db.CreateParameter("@MCOMM2", DatabaseConstants.DataTypes.Char, "MCOMM2", 25, 0);
			parms.Add(parm_MCOMM2);
			IDataParameter parm_MCOMM3 = db.CreateParameter("@MCOMM3", DatabaseConstants.DataTypes.Char, "MCOMM3", 25, 0);
			parms.Add(parm_MCOMM3);
			IDataParameter parm_MACCT = db.CreateParameter("@MACCT", DatabaseConstants.DataTypes.Numeric, "MACCT", 10, 0);
			parms.Add(parm_MACCT);
			IDataParameter parm_MEXWL2 = db.CreateParameter("@MEXWL2", DatabaseConstants.DataTypes.Numeric, "MEXWL2", 2, 0);
			parms.Add(parm_MEXWL2);
			IDataParameter parm_MCALC = db.CreateParameter("@MCALC", DatabaseConstants.DataTypes.Char, "MCALC", 1, 0);
			parms.Add(parm_MCALC);
			IDataParameter parm_MFILL4 = db.CreateParameter("@MFILL4", DatabaseConstants.DataTypes.Char, "MFILL4", 1, 0);
			parms.Add(parm_MFILL4);
			IDataParameter parm_MTBV = db.CreateParameter("@MTBV", DatabaseConstants.DataTypes.Numeric, "MTBV", 9, 0);
			parms.Add(parm_MTBV);
			IDataParameter parm_MTBAS = db.CreateParameter("@MTBAS", DatabaseConstants.DataTypes.Numeric, "MTBAS", 9, 0);
			parms.Add(parm_MTBAS);
			IDataParameter parm_MTFBAS = db.CreateParameter("@MTFBAS", DatabaseConstants.DataTypes.Numeric, "MTFBAS", 9, 0);
			parms.Add(parm_MTFBAS);
			IDataParameter parm_MTPLUM = db.CreateParameter("@MTPLUM", DatabaseConstants.DataTypes.Numeric, "MTPLUM", 9, 0);
			parms.Add(parm_MTPLUM);
			IDataParameter parm_MTHEAT = db.CreateParameter("@MTHEAT", DatabaseConstants.DataTypes.Numeric, "MTHEAT", 9, 0);
			parms.Add(parm_MTHEAT);
			IDataParameter parm_MTAC = db.CreateParameter("@MTAC", DatabaseConstants.DataTypes.Numeric, "MTAC", 9, 0);
			parms.Add(parm_MTAC);
			IDataParameter parm_MTFP = db.CreateParameter("@MTFP", DatabaseConstants.DataTypes.Numeric, "MTFP", 9, 0);
			parms.Add(parm_MTFP);
			IDataParameter parm_MTFL = db.CreateParameter("@MTFL", DatabaseConstants.DataTypes.Numeric, "MTFL", 9, 0);
			parms.Add(parm_MTFL);
			IDataParameter parm_MTBI = db.CreateParameter("@MTBI", DatabaseConstants.DataTypes.Numeric, "MTBI", 9, 0);
			parms.Add(parm_MTBI);
			IDataParameter parm_MTTADD = db.CreateParameter("@MTTADD", DatabaseConstants.DataTypes.Numeric, "MTTADD", 9, 0);
			parms.Add(parm_MTTADD);
			IDataParameter parm_MTSUBT = db.CreateParameter("@MTSUBT", DatabaseConstants.DataTypes.Numeric, "MTSUBT", 9, 0);
			parms.Add(parm_MTSUBT);
			IDataParameter parm_MTOTBV = db.CreateParameter("@MTOTBV", DatabaseConstants.DataTypes.Numeric, "MTOTBV", 9, 0);
			parms.Add(parm_MTOTBV);
			IDataParameter parm_MUSRID = db.CreateParameter("@MUSRID", DatabaseConstants.DataTypes.Char, "MUSRID", 10, 0);
			parms.Add(parm_MUSRID);
			IDataParameter parm_MBASA = db.CreateParameter("@MBASA", DatabaseConstants.DataTypes.Numeric, "MBASA", 7, 1);
			parms.Add(parm_MBASA);
			IDataParameter parm_MTOTA = db.CreateParameter("@MTOTA", DatabaseConstants.DataTypes.Numeric, "MTOTA", 7, 1);
			parms.Add(parm_MTOTA);
			IDataParameter parm_MPSF = db.CreateParameter("@MPSF", DatabaseConstants.DataTypes.Numeric, "MPSF", 5, 2);
			parms.Add(parm_MPSF);
			IDataParameter parm_MINWLL = db.CreateParameter("@MINWLL", DatabaseConstants.DataTypes.Char, "MINWLL", 8, 0);
			parms.Add(parm_MINWLL);
			IDataParameter parm_MFLOOR = db.CreateParameter("@MFLOOR", DatabaseConstants.DataTypes.Char, "MFLOOR", 8, 0);
			parms.Add(parm_MFLOOR);
			IDataParameter parm_MYRBLT = db.CreateParameter("@MYRBLT", DatabaseConstants.DataTypes.Numeric, "MYRBLT", 4, 0);
			parms.Add(parm_MYRBLT);
			IDataParameter parm_MCNST1 = db.CreateParameter("@MCNST1", DatabaseConstants.DataTypes.Char, "MCNST1", 2, 0);
			parms.Add(parm_MCNST1);
			IDataParameter parm_MCNST2 = db.CreateParameter("@MCNST2", DatabaseConstants.DataTypes.Char, "MCNST2", 2, 0);
			parms.Add(parm_MCNST2);
			IDataParameter parm_MASSLU = db.CreateParameter("@MASSLU", DatabaseConstants.DataTypes.Numeric, "MASSLU", 9, 0);
			parms.Add(parm_MASSLU);
			IDataParameter parm_MMOSLD = db.CreateParameter("@MMOSLD", DatabaseConstants.DataTypes.Numeric, "MMOSLD", 2, 0);
			parms.Add(parm_MMOSLD);
			IDataParameter parm_MDASLD = db.CreateParameter("@MDASLD", DatabaseConstants.DataTypes.Numeric, "MDASLD", 2, 0);
			parms.Add(parm_MDASLD);
			IDataParameter parm_MYRSLD = db.CreateParameter("@MYRSLD", DatabaseConstants.DataTypes.Numeric, "MYRSLD", 4, 0);
			parms.Add(parm_MYRSLD);
			IDataParameter parm_MTIME = db.CreateParameter("@MTIME", DatabaseConstants.DataTypes.Numeric, "MTIME", 6, 0);
			parms.Add(parm_MTIME);
			IDataParameter parm_MHSE_NUM2 = db.CreateParameter("@MHSE_NUM2", DatabaseConstants.DataTypes.Char, "MHSE#2", 5, 0);
			parms.Add(parm_MHSE_NUM2);
			IDataParameter parm_M1ADJ = db.CreateParameter("@M1ADJ", DatabaseConstants.DataTypes.Numeric, "M1ADJ", 3, 2);
			parms.Add(parm_M1ADJ);
			IDataParameter parm_M2ADJ = db.CreateParameter("@M2ADJ", DatabaseConstants.DataTypes.Numeric, "M2ADJ", 3, 2);
			parms.Add(parm_M2ADJ);
			IDataParameter parm_MLGBKC = db.CreateParameter("@MLGBKC", DatabaseConstants.DataTypes.Char, "MLGBKC", 1, 0);
			parms.Add(parm_MLGBKC);
			IDataParameter parm_MLGBK_NUM = db.CreateParameter("@MLGBK_NUM", DatabaseConstants.DataTypes.Char, "MLGBK#", 4, 0);
			parms.Add(parm_MLGBK_NUM);
			IDataParameter parm_MLGPG_NUM = db.CreateParameter("@MLGPG_NUM", DatabaseConstants.DataTypes.Numeric, "MLGPG#", 4, 0);
			parms.Add(parm_MLGPG_NUM);
			IDataParameter parm_MEFFAG = db.CreateParameter("@MEFFAG", DatabaseConstants.DataTypes.Numeric, "MEFFAG", 3, 0);
			parms.Add(parm_MEFFAG);
			IDataParameter parm_MPCOMP = db.CreateParameter("@MPCOMP", DatabaseConstants.DataTypes.Numeric, "MPCOMP", 3, 2);
			parms.Add(parm_MPCOMP);
			IDataParameter parm_MSTTYP = db.CreateParameter("@MSTTYP", DatabaseConstants.DataTypes.Char, "MSTTYP", 4, 0);
			parms.Add(parm_MSTTYP);
			IDataParameter parm_MSDIRS = db.CreateParameter("@MSDIRS", DatabaseConstants.DataTypes.Char, "MSDIRS", 2, 0);
			parms.Add(parm_MSDIRS);
			IDataParameter parm_M1RATE = db.CreateParameter("@M1RATE", DatabaseConstants.DataTypes.Numeric, "M1RATE", 9, 2);
			parms.Add(parm_M1RATE);
			IDataParameter parm_M2RATE = db.CreateParameter("@M2RATE", DatabaseConstants.DataTypes.Numeric, "M2RATE", 9, 2);
			parms.Add(parm_M2RATE);
			IDataParameter parm_MFUNCD = db.CreateParameter("@MFUNCD", DatabaseConstants.DataTypes.Numeric, "MFUNCD", 3, 2);
			parms.Add(parm_MFUNCD);
			IDataParameter parm_MECOND = db.CreateParameter("@MECOND", DatabaseConstants.DataTypes.Numeric, "MECOND", 3, 2);
			parms.Add(parm_MECOND);
			IDataParameter parm_MNBRHD = db.CreateParameter("@MNBRHD", DatabaseConstants.DataTypes.Numeric, "MNBRHD", 4, 0);
			parms.Add(parm_MNBRHD);
			IDataParameter parm_MUSER1 = db.CreateParameter("@MUSER1", DatabaseConstants.DataTypes.Char, "MUSER1", 1, 0);
			parms.Add(parm_MUSER1);
			IDataParameter parm_MUSER2 = db.CreateParameter("@MUSER2", DatabaseConstants.DataTypes.Char, "MUSER2", 1, 0);
			parms.Add(parm_MUSER2);
			IDataParameter parm_MDBOOK = db.CreateParameter("@MDBOOK", DatabaseConstants.DataTypes.Numeric, "MDBOOK", 4, 0);
			parms.Add(parm_MDBOOK);
			IDataParameter parm_MDPAGE = db.CreateParameter("@MDPAGE", DatabaseConstants.DataTypes.Char, "MDPAGE", 4, 0);
			parms.Add(parm_MDPAGE);
			IDataParameter parm_MWBOOK = db.CreateParameter("@MWBOOK", DatabaseConstants.DataTypes.Numeric, "MWBOOK", 4, 0);
			parms.Add(parm_MWBOOK);
			IDataParameter parm_MWPAGE = db.CreateParameter("@MWPAGE", DatabaseConstants.DataTypes.Char, "MWPAGE", 4, 0);
			parms.Add(parm_MWPAGE);
			IDataParameter parm_MDCODE = db.CreateParameter("@MDCODE", DatabaseConstants.DataTypes.Char, "MDCODE", 1, 0);
			parms.Add(parm_MDCODE);
			IDataParameter parm_MWCODE = db.CreateParameter("@MWCODE", DatabaseConstants.DataTypes.Char, "MWCODE", 1, 0);
			parms.Add(parm_MWCODE);
			IDataParameter parm_MMORTC = db.CreateParameter("@MMORTC", DatabaseConstants.DataTypes.Numeric, "MMORTC", 3, 0);
			parms.Add(parm_MMORTC);
			IDataParameter parm_MFILL7 = db.CreateParameter("@MFILL7", DatabaseConstants.DataTypes.Char, "MFILL7", 1, 0);
			parms.Add(parm_MFILL7);
			IDataParameter parm_MACRE_NUM = db.CreateParameter("@MACRE_NUM", DatabaseConstants.DataTypes.Numeric, "MACRE#", 11, 5);
			parms.Add(parm_MACRE_NUM);
			IDataParameter parm_MGISPN = db.CreateParameter("@MGISPN", DatabaseConstants.DataTypes.Char, "MGISPN", 30, 0);
			parms.Add(parm_MGISPN);
			IDataParameter parm_MUSER3 = db.CreateParameter("@MUSER3", DatabaseConstants.DataTypes.Char, "MUSER3", 1, 0);
			parms.Add(parm_MUSER3);
			IDataParameter parm_MUSER4 = db.CreateParameter("@MUSER4", DatabaseConstants.DataTypes.Char, "MUSER4", 1, 0);
			parms.Add(parm_MUSER4);
			IDataParameter parm_MIMADJ = db.CreateParameter("@MIMADJ", DatabaseConstants.DataTypes.Numeric, "MIMADJ", 8, 0);
			parms.Add(parm_MIMADJ);
			IDataParameter parm_MCDRDT = db.CreateParameter("@MCDRDT", DatabaseConstants.DataTypes.Numeric, "MCDRDT", 8, 0);
			parms.Add(parm_MCDRDT);
			IDataParameter parm_MMNUD = db.CreateParameter("@MMNUD", DatabaseConstants.DataTypes.Numeric, "MMNUD", 9, 0);
			parms.Add(parm_MMNUD);
			IDataParameter parm_MMNNUD = db.CreateParameter("@MMNNUD", DatabaseConstants.DataTypes.Numeric, "MMNNUD", 9, 0);
			parms.Add(parm_MMNNUD);
			IDataParameter parm_MSS1 = db.CreateParameter("@MSS1", DatabaseConstants.DataTypes.Numeric, "MSS1", 9, 0);
			parms.Add(parm_MSS1);
			IDataParameter parm_MPCODE = db.CreateParameter("@MPCODE", DatabaseConstants.DataTypes.Char, "MPCODE", 1, 0);
			parms.Add(parm_MPCODE);
			IDataParameter parm_MPBOOK = db.CreateParameter("@MPBOOK", DatabaseConstants.DataTypes.Char, "MPBOOK", 4, 0);
			parms.Add(parm_MPBOOK);
			IDataParameter parm_MPPAGE = db.CreateParameter("@MPPAGE", DatabaseConstants.DataTypes.Numeric, "MPPAGE", 4, 0);
			parms.Add(parm_MPPAGE);
			IDataParameter parm_MSS2 = db.CreateParameter("@MSS2", DatabaseConstants.DataTypes.Numeric, "MSS2", 9, 0);
			parms.Add(parm_MSS2);
			IDataParameter parm_MASSM = db.CreateParameter("@MASSM", DatabaseConstants.DataTypes.Numeric, "MASSM", 9, 0);
			parms.Add(parm_MASSM);
			IDataParameter parm_MFILL9 = db.CreateParameter("@MFILL9", DatabaseConstants.DataTypes.Char, "MFILL9", 4, 0);
			parms.Add(parm_MFILL9);
			IDataParameter parm_MGRNTR = db.CreateParameter("@MGRNTR", DatabaseConstants.DataTypes.Char, "MGRNTR", 35, 0);
			parms.Add(parm_MGRNTR);
			IDataParameter parm_MCVMO = db.CreateParameter("@MCVMO", DatabaseConstants.DataTypes.Numeric, "MCVMO", 2, 0);
			parms.Add(parm_MCVMO);
			IDataParameter parm_MCVDA = db.CreateParameter("@MCVDA", DatabaseConstants.DataTypes.Numeric, "MCVDA", 2, 0);
			parms.Add(parm_MCVDA);
			IDataParameter parm_MCVYR = db.CreateParameter("@MCVYR", DatabaseConstants.DataTypes.Numeric, "MCVYR", 4, 0);
			parms.Add(parm_MCVYR);
			IDataParameter parm_MPROUT = db.CreateParameter("@MPROUT", DatabaseConstants.DataTypes.Char, "MPROUT", 4, 0);
			parms.Add(parm_MPROUT);
			IDataParameter parm_MPERR = db.CreateParameter("@MPERR", DatabaseConstants.DataTypes.Char, "MPERR", 3, 0);
			parms.Add(parm_MPERR);
			IDataParameter parm_MTBIMP = db.CreateParameter("@MTBIMP", DatabaseConstants.DataTypes.Numeric, "MTBIMP", 10, 0);
			parms.Add(parm_MTBIMP);
			IDataParameter parm_MPUSE = db.CreateParameter("@MPUSE", DatabaseConstants.DataTypes.Numeric, "MPUSE", 6, 0);
			parms.Add(parm_MPUSE);
			IDataParameter parm_MCVEXP = db.CreateParameter("@MCVEXP", DatabaseConstants.DataTypes.Char, "MCVEXP", 23, 0);
			parms.Add(parm_MCVEXP);
			IDataParameter parm_METXYR = db.CreateParameter("@METXYR", DatabaseConstants.DataTypes.Numeric, "METXYR", 4, 0);
			parms.Add(parm_METXYR);
			IDataParameter parm_MQAPCH = db.CreateParameter("@MQAPCH", DatabaseConstants.DataTypes.Numeric, "MQAPCH", 8, 4);
			parms.Add(parm_MQAPCH);
			IDataParameter parm_MQAFIL = db.CreateParameter("@MQAFIL", DatabaseConstants.DataTypes.Char, "MQAFIL", 10, 0);
			parms.Add(parm_MQAFIL);
			IDataParameter parm_MPICT = db.CreateParameter("@MPICT", DatabaseConstants.DataTypes.Char, "MPICT", 6, 0);
			parms.Add(parm_MPICT);
			IDataParameter parm_MEACRE = db.CreateParameter("@MEACRE", DatabaseConstants.DataTypes.Numeric, "MEACRE", 11, 5);
			parms.Add(parm_MEACRE);
			IDataParameter parm_MPRCIT = db.CreateParameter("@MPRCIT", DatabaseConstants.DataTypes.Char, "MPRCIT", 25, 0);
			parms.Add(parm_MPRCIT);
			IDataParameter parm_MPRSTA = db.CreateParameter("@MPRSTA", DatabaseConstants.DataTypes.Char, "MPRSTA", 2, 0);
			parms.Add(parm_MPRSTA);
			IDataParameter parm_MPRZP1 = db.CreateParameter("@MPRZP1", DatabaseConstants.DataTypes.Numeric, "MPRZP1", 5, 0);
			parms.Add(parm_MPRZP1);
			IDataParameter parm_MPRZP4 = db.CreateParameter("@MPRZP4", DatabaseConstants.DataTypes.Char, "MPRZP4", 4, 0);
			parms.Add(parm_MPRZP4);
			IDataParameter parm_MFP_NUM = db.CreateParameter("@MFP_NUM", DatabaseConstants.DataTypes.Numeric, "MFP#", 2, 0);
			parms.Add(parm_MFP_NUM);
			IDataParameter parm_MSFP_NUM = db.CreateParameter("@MSFP_NUM", DatabaseConstants.DataTypes.Numeric, "MSFP#", 2, 0);
			parms.Add(parm_MSFP_NUM);
			IDataParameter parm_MFL_NUM = db.CreateParameter("@MFL_NUM", DatabaseConstants.DataTypes.Numeric, "MFL#", 2, 0);
			parms.Add(parm_MFL_NUM);
			IDataParameter parm_MSFL_NUM = db.CreateParameter("@MSFL_NUM", DatabaseConstants.DataTypes.Numeric, "MSFL#", 2, 0);
			parms.Add(parm_MSFL_NUM);
			IDataParameter parm_MMFL_NUM = db.CreateParameter("@MMFL_NUM", DatabaseConstants.DataTypes.Numeric, "MMFL#", 2, 0);
			parms.Add(parm_MMFL_NUM);
			IDataParameter parm_MIOFP_NUM = db.CreateParameter("@MIOFP_NUM", DatabaseConstants.DataTypes.Numeric, "MIOFP#", 2, 0);
			parms.Add(parm_MIOFP_NUM);
			IDataParameter parm_MSTOR_NUM = db.CreateParameter("@MSTOR_NUM", DatabaseConstants.DataTypes.Numeric, "MSTOR#", 4, 2);
			parms.Add(parm_MSTOR_NUM);
			IDataParameter parm_MASCOM = db.CreateParameter("@MASCOM", DatabaseConstants.DataTypes.Char, "MASCOM", 30, 0);
			parms.Add(parm_MASCOM);
			IDataParameter parm_MHRPH_NUM = db.CreateParameter("@MHRPH_NUM", DatabaseConstants.DataTypes.Numeric, "MHRPH#", 9, 0);
			parms.Add(parm_MHRPH_NUM);
			IDataParameter parm_MHRDAT = db.CreateParameter("@MHRDAT", DatabaseConstants.DataTypes.Numeric, "MHRDAT", 8, 0);
			parms.Add(parm_MHRDAT);
			IDataParameter parm_MHRTIM = db.CreateParameter("@MHRTIM", DatabaseConstants.DataTypes.Numeric, "MHRTIM", 4, 0);
			parms.Add(parm_MHRTIM);
			IDataParameter parm_MHRNAM = db.CreateParameter("@MHRNAM", DatabaseConstants.DataTypes.Char, "MHRNAM", 35, 0);
			parms.Add(parm_MHRNAM);
			IDataParameter parm_MHRSES = db.CreateParameter("@MHRSES", DatabaseConstants.DataTypes.Char, "MHRSES", 1, 0);
			parms.Add(parm_MHRSES);
			IDataParameter parm_MHIDPC = db.CreateParameter("@MHIDPC", DatabaseConstants.DataTypes.Char, "MHIDPC", 1, 0);
			parms.Add(parm_MHIDPC);
			IDataParameter parm_MHIDNM = db.CreateParameter("@MHIDNM", DatabaseConstants.DataTypes.Char, "MHIDNM", 1, 0);
			parms.Add(parm_MHIDNM);
			IDataParameter parm_MCAMO = db.CreateParameter("@MCAMO", DatabaseConstants.DataTypes.Numeric, "MCAMO", 2, 0);
			parms.Add(parm_MCAMO);
			IDataParameter parm_MCADA = db.CreateParameter("@MCADA", DatabaseConstants.DataTypes.Numeric, "MCADA", 2, 0);
			parms.Add(parm_MCADA);
			IDataParameter parm_MCAYR = db.CreateParameter("@MCAYR", DatabaseConstants.DataTypes.Numeric, "MCAYR", 4, 0);
			parms.Add(parm_MCAYR);
			IDataParameter parm_MOLDOC = db.CreateParameter("@MOLDOC", DatabaseConstants.DataTypes.Numeric, "MOLDOC", 2, 0);
			parms.Add(parm_MOLDOC);

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
				this.db.SetParameterValue(comm.Parameters, "@MRECID", this.MRECID.Value);
				this.db.SetParameterValue(comm.Parameters, "@MRECNO", this.MRECNO.Value);
				this.db.SetParameterValue(comm.Parameters, "@MDWELL", this.MDWELL.Value);
				this.db.SetParameterValue(comm.Parameters, "@MMAP", this.MMAP.Value);
				this.db.SetParameterValue(comm.Parameters, "@MLNAM", this.MLNAM.Value);
				this.db.SetParameterValue(comm.Parameters, "@MFNAM", this.MFNAM.Value);
				this.db.SetParameterValue(comm.Parameters, "@MADD1", this.MADD1.Value);
				this.db.SetParameterValue(comm.Parameters, "@MADD2", this.MADD2.Value);
				this.db.SetParameterValue(comm.Parameters, "@MCITY", this.MCITY.Value);
				this.db.SetParameterValue(comm.Parameters, "@MSTATE", this.MSTATE.Value);
				this.db.SetParameterValue(comm.Parameters, "@MZIP5", this.MZIP5.Value);
				this.db.SetParameterValue(comm.Parameters, "@MZIP4", this.MZIP4.Value);
				this.db.SetParameterValue(comm.Parameters, "@MACRE", this.MACRE.Value);
				this.db.SetParameterValue(comm.Parameters, "@MZONE", this.MZONE.Value);
				this.db.SetParameterValue(comm.Parameters, "@MLUSE", this.MLUSE.Value);
				this.db.SetParameterValue(comm.Parameters, "@MOCCUP", this.MOCCUP.Value);
				this.db.SetParameterValue(comm.Parameters, "@MSTORY", this.MSTORY.Value);
				this.db.SetParameterValue(comm.Parameters, "@MAGE", this.MAGE.Value);
				this.db.SetParameterValue(comm.Parameters, "@MCOND", this.MCOND.Value);
				this.db.SetParameterValue(comm.Parameters, "@MCLASS", this.MCLASS.Value);
				this.db.SetParameterValue(comm.Parameters, "@MFACTR", this.MFACTR.Value);
				this.db.SetParameterValue(comm.Parameters, "@MDEPRC", this.MDEPRC.Value);
				this.db.SetParameterValue(comm.Parameters, "@MFOUND", this.MFOUND.Value);
				this.db.SetParameterValue(comm.Parameters, "@MEXWLL", this.MEXWLL.Value);
				this.db.SetParameterValue(comm.Parameters, "@MROOFT", this.MROOFT.Value);
				this.db.SetParameterValue(comm.Parameters, "@MROOFG", this.MROOFG.Value);
				this.db.SetParameterValue(comm.Parameters, "@M_NUMDUNT", this.M_NUMDUNT.Value);
				this.db.SetParameterValue(comm.Parameters, "@M_NUMROOM", this.M_NUMROOM.Value);
				this.db.SetParameterValue(comm.Parameters, "@M_NUMBR", this.M_NUMBR.Value);
				this.db.SetParameterValue(comm.Parameters, "@M_NUMFBTH", this.M_NUMFBTH.Value);
				this.db.SetParameterValue(comm.Parameters, "@M_NUMHBTH", this.M_NUMHBTH.Value);
				this.db.SetParameterValue(comm.Parameters, "@MFP2", this.MFP2.Value);
				this.db.SetParameterValue(comm.Parameters, "@MLTRCD", this.MLTRCD.Value);
				this.db.SetParameterValue(comm.Parameters, "@MHEAT", this.MHEAT.Value);
				this.db.SetParameterValue(comm.Parameters, "@MFUEL", this.MFUEL.Value);
				this.db.SetParameterValue(comm.Parameters, "@MAC", this.MAC.Value);
				this.db.SetParameterValue(comm.Parameters, "@MFP1", this.MFP1.Value);
				this.db.SetParameterValue(comm.Parameters, "@MCDR", this.MCDR.Value);
				this.db.SetParameterValue(comm.Parameters, "@MEKIT", this.MEKIT.Value);
				this.db.SetParameterValue(comm.Parameters, "@MBASTP", this.MBASTP.Value);
				this.db.SetParameterValue(comm.Parameters, "@MPBTOT", this.MPBTOT.Value);
				this.db.SetParameterValue(comm.Parameters, "@MSBTOT", this.MSBTOT.Value);
				this.db.SetParameterValue(comm.Parameters, "@MPBFIN", this.MPBFIN.Value);
				this.db.SetParameterValue(comm.Parameters, "@MSBFIN", this.MSBFIN.Value);
				this.db.SetParameterValue(comm.Parameters, "@MBRATE", this.MBRATE.Value);
				this.db.SetParameterValue(comm.Parameters, "@M_NUMFLUE", this.M_NUMFLUE.Value);
				this.db.SetParameterValue(comm.Parameters, "@MFLUTP", this.MFLUTP.Value);
				this.db.SetParameterValue(comm.Parameters, "@MGART", this.MGART.Value);
				this.db.SetParameterValue(comm.Parameters, "@MGAR_NUMC", this.MGAR_NUMC.Value);
				this.db.SetParameterValue(comm.Parameters, "@MCARPT", this.MCARPT.Value);
				this.db.SetParameterValue(comm.Parameters, "@MCAR_NUMC", this.MCAR_NUMC.Value);
				this.db.SetParameterValue(comm.Parameters, "@MBI_NUMC", this.MBI_NUMC.Value);
				this.db.SetParameterValue(comm.Parameters, "@MROW", this.MROW.Value);
				this.db.SetParameterValue(comm.Parameters, "@MEASE", this.MEASE.Value);
				this.db.SetParameterValue(comm.Parameters, "@MWATER", this.MWATER.Value);
				this.db.SetParameterValue(comm.Parameters, "@MSEWER", this.MSEWER.Value);
				this.db.SetParameterValue(comm.Parameters, "@MGAS", this.MGAS.Value);
				this.db.SetParameterValue(comm.Parameters, "@MELEC", this.MELEC.Value);
				this.db.SetParameterValue(comm.Parameters, "@MTERRN", this.MTERRN.Value);
				this.db.SetParameterValue(comm.Parameters, "@MCHAR", this.MCHAR.Value);
				this.db.SetParameterValue(comm.Parameters, "@MOTDES", this.MOTDES.Value);
				this.db.SetParameterValue(comm.Parameters, "@MGART2", this.MGART2.Value);
				this.db.SetParameterValue(comm.Parameters, "@MGAR_NUM2", this.MGAR_NUM2.Value);
				this.db.SetParameterValue(comm.Parameters, "@MDATLG", this.MDATLG.Value);
				this.db.SetParameterValue(comm.Parameters, "@MDATPR", this.MDATPR.Value);
				this.db.SetParameterValue(comm.Parameters, "@MINTYP", this.MINTYP.Value);
				this.db.SetParameterValue(comm.Parameters, "@MINTYR", this.MINTYR.Value);
				this.db.SetParameterValue(comm.Parameters, "@MINNO_NUM", this.MINNO_NUM.Value);
				this.db.SetParameterValue(comm.Parameters, "@MINNO2", this.MINNO2.Value);
				this.db.SetParameterValue(comm.Parameters, "@MDSUFX", this.MDSUFX.Value);
				this.db.SetParameterValue(comm.Parameters, "@MWSUFX", this.MWSUFX.Value);
				this.db.SetParameterValue(comm.Parameters, "@MPSUFX", this.MPSUFX.Value);
				this.db.SetParameterValue(comm.Parameters, "@MIMPRV", this.MIMPRV.Value);
				this.db.SetParameterValue(comm.Parameters, "@MTOTLD", this.MTOTLD.Value);
				this.db.SetParameterValue(comm.Parameters, "@MTOTOI", this.MTOTOI.Value);
				this.db.SetParameterValue(comm.Parameters, "@MTOTPR", this.MTOTPR.Value);
				this.db.SetParameterValue(comm.Parameters, "@MASSB", this.MASSB.Value);
				this.db.SetParameterValue(comm.Parameters, "@MACPCT", this.MACPCT.Value);
				this.db.SetParameterValue(comm.Parameters, "@M1FRNT", this.M1FRNT.Value);
				this.db.SetParameterValue(comm.Parameters, "@M1DPTH", this.M1DPTH.Value);
				this.db.SetParameterValue(comm.Parameters, "@M1AREA", this.M1AREA.Value);
				this.db.SetParameterValue(comm.Parameters, "@MMCODE", this.MMCODE.Value);
				this.db.SetParameterValue(comm.Parameters, "@M0DEPR", this.M0DEPR.Value);
				this.db.SetParameterValue(comm.Parameters, "@M1UM", this.M1UM.Value);
				this.db.SetParameterValue(comm.Parameters, "@M2FRNT", this.M2FRNT.Value);
				this.db.SetParameterValue(comm.Parameters, "@M2DPTH", this.M2DPTH.Value);
				this.db.SetParameterValue(comm.Parameters, "@M2AREA", this.M2AREA.Value);
				this.db.SetParameterValue(comm.Parameters, "@MZIPBR", this.MZIPBR.Value);
				this.db.SetParameterValue(comm.Parameters, "@MDELAY", this.MDELAY.Value);
				this.db.SetParameterValue(comm.Parameters, "@M2UM", this.M2UM.Value);
				this.db.SetParameterValue(comm.Parameters, "@MSTRT", this.MSTRT.Value);
				this.db.SetParameterValue(comm.Parameters, "@MDIRCT", this.MDIRCT.Value);
				this.db.SetParameterValue(comm.Parameters, "@MHSE_NUM", this.MHSE_NUM.Value);
				this.db.SetParameterValue(comm.Parameters, "@MCDMO", this.MCDMO.Value);
				this.db.SetParameterValue(comm.Parameters, "@MCDDA", this.MCDDA.Value);
				this.db.SetParameterValue(comm.Parameters, "@MCDYR", this.MCDYR.Value);
				this.db.SetParameterValue(comm.Parameters, "@M1DFAC", this.M1DFAC.Value);
				this.db.SetParameterValue(comm.Parameters, "@MREM1", this.MREM1.Value);
				this.db.SetParameterValue(comm.Parameters, "@MREM2", this.MREM2.Value);
				this.db.SetParameterValue(comm.Parameters, "@MMAGCD", this.MMAGCD.Value);
				this.db.SetParameterValue(comm.Parameters, "@MATHOM", this.MATHOM.Value);
				this.db.SetParameterValue(comm.Parameters, "@MDESC1", this.MDESC1.Value);
				this.db.SetParameterValue(comm.Parameters, "@MDESC2", this.MDESC2.Value);
				this.db.SetParameterValue(comm.Parameters, "@MDESC3", this.MDESC3.Value);
				this.db.SetParameterValue(comm.Parameters, "@MDESC4", this.MDESC4.Value);
				this.db.SetParameterValue(comm.Parameters, "@MFAIRV", this.MFAIRV.Value);
				this.db.SetParameterValue(comm.Parameters, "@MLGITY", this.MLGITY.Value);
				this.db.SetParameterValue(comm.Parameters, "@MLGIYR", this.MLGIYR.Value);
				this.db.SetParameterValue(comm.Parameters, "@MLGNO_NUM", this.MLGNO_NUM.Value);
				this.db.SetParameterValue(comm.Parameters, "@MLGNO2", this.MLGNO2.Value);
				this.db.SetParameterValue(comm.Parameters, "@MSUBDV", this.MSUBDV.Value);
				this.db.SetParameterValue(comm.Parameters, "@MSELLP", this.MSELLP.Value);
				this.db.SetParameterValue(comm.Parameters, "@M2DFAC", this.M2DFAC.Value);
				this.db.SetParameterValue(comm.Parameters, "@MINIT", this.MINIT.Value);
				this.db.SetParameterValue(comm.Parameters, "@MINSPD", this.MINSPD.Value);
				this.db.SetParameterValue(comm.Parameters, "@MSWL", this.MSWL.Value);
				this.db.SetParameterValue(comm.Parameters, "@MTUTIL", this.MTUTIL.Value);
				this.db.SetParameterValue(comm.Parameters, "@MNBADJ", this.MNBADJ.Value);
				this.db.SetParameterValue(comm.Parameters, "@MASSL", this.MASSL.Value);
				this.db.SetParameterValue(comm.Parameters, "@MACSF", this.MACSF.Value);
				this.db.SetParameterValue(comm.Parameters, "@MCOMM1", this.MCOMM1.Value);
				this.db.SetParameterValue(comm.Parameters, "@MCOMM2", this.MCOMM2.Value);
				this.db.SetParameterValue(comm.Parameters, "@MCOMM3", this.MCOMM3.Value);
				this.db.SetParameterValue(comm.Parameters, "@MACCT", this.MACCT.Value);
				this.db.SetParameterValue(comm.Parameters, "@MEXWL2", this.MEXWL2.Value);
				this.db.SetParameterValue(comm.Parameters, "@MCALC", this.MCALC.Value);
				this.db.SetParameterValue(comm.Parameters, "@MFILL4", this.MFILL4.Value);
				this.db.SetParameterValue(comm.Parameters, "@MTBV", this.MTBV.Value);
				this.db.SetParameterValue(comm.Parameters, "@MTBAS", this.MTBAS.Value);
				this.db.SetParameterValue(comm.Parameters, "@MTFBAS", this.MTFBAS.Value);
				this.db.SetParameterValue(comm.Parameters, "@MTPLUM", this.MTPLUM.Value);
				this.db.SetParameterValue(comm.Parameters, "@MTHEAT", this.MTHEAT.Value);
				this.db.SetParameterValue(comm.Parameters, "@MTAC", this.MTAC.Value);
				this.db.SetParameterValue(comm.Parameters, "@MTFP", this.MTFP.Value);
				this.db.SetParameterValue(comm.Parameters, "@MTFL", this.MTFL.Value);
				this.db.SetParameterValue(comm.Parameters, "@MTBI", this.MTBI.Value);
				this.db.SetParameterValue(comm.Parameters, "@MTTADD", this.MTTADD.Value);
				this.db.SetParameterValue(comm.Parameters, "@MTSUBT", this.MTSUBT.Value);
				this.db.SetParameterValue(comm.Parameters, "@MTOTBV", this.MTOTBV.Value);
				this.db.SetParameterValue(comm.Parameters, "@MUSRID", this.MUSRID.Value);
				this.db.SetParameterValue(comm.Parameters, "@MBASA", this.MBASA.Value);
				this.db.SetParameterValue(comm.Parameters, "@MTOTA", this.MTOTA.Value);
				this.db.SetParameterValue(comm.Parameters, "@MPSF", this.MPSF.Value);
				this.db.SetParameterValue(comm.Parameters, "@MINWLL", this.MINWLL.Value);
				this.db.SetParameterValue(comm.Parameters, "@MFLOOR", this.MFLOOR.Value);
				this.db.SetParameterValue(comm.Parameters, "@MYRBLT", this.MYRBLT.Value);
				this.db.SetParameterValue(comm.Parameters, "@MCNST1", this.MCNST1.Value);
				this.db.SetParameterValue(comm.Parameters, "@MCNST2", this.MCNST2.Value);
				this.db.SetParameterValue(comm.Parameters, "@MASSLU", this.MASSLU.Value);
				this.db.SetParameterValue(comm.Parameters, "@MMOSLD", this.MMOSLD.Value);
				this.db.SetParameterValue(comm.Parameters, "@MDASLD", this.MDASLD.Value);
				this.db.SetParameterValue(comm.Parameters, "@MYRSLD", this.MYRSLD.Value);
				this.db.SetParameterValue(comm.Parameters, "@MTIME", this.MTIME.Value);
				this.db.SetParameterValue(comm.Parameters, "@MHSE_NUM2", this.MHSE_NUM2.Value);
				this.db.SetParameterValue(comm.Parameters, "@M1ADJ", this.M1ADJ.Value);
				this.db.SetParameterValue(comm.Parameters, "@M2ADJ", this.M2ADJ.Value);
				this.db.SetParameterValue(comm.Parameters, "@MLGBKC", this.MLGBKC.Value);
				this.db.SetParameterValue(comm.Parameters, "@MLGBK_NUM", this.MLGBK_NUM.Value);
				this.db.SetParameterValue(comm.Parameters, "@MLGPG_NUM", this.MLGPG_NUM.Value);
				this.db.SetParameterValue(comm.Parameters, "@MEFFAG", this.MEFFAG.Value);
				this.db.SetParameterValue(comm.Parameters, "@MPCOMP", this.MPCOMP.Value);
				this.db.SetParameterValue(comm.Parameters, "@MSTTYP", this.MSTTYP.Value);
				this.db.SetParameterValue(comm.Parameters, "@MSDIRS", this.MSDIRS.Value);
				this.db.SetParameterValue(comm.Parameters, "@M1RATE", this.M1RATE.Value);
				this.db.SetParameterValue(comm.Parameters, "@M2RATE", this.M2RATE.Value);
				this.db.SetParameterValue(comm.Parameters, "@MFUNCD", this.MFUNCD.Value);
				this.db.SetParameterValue(comm.Parameters, "@MECOND", this.MECOND.Value);
				this.db.SetParameterValue(comm.Parameters, "@MNBRHD", this.MNBRHD.Value);
				this.db.SetParameterValue(comm.Parameters, "@MUSER1", this.MUSER1.Value);
				this.db.SetParameterValue(comm.Parameters, "@MUSER2", this.MUSER2.Value);
				this.db.SetParameterValue(comm.Parameters, "@MDBOOK", this.MDBOOK.Value);
				this.db.SetParameterValue(comm.Parameters, "@MDPAGE", this.MDPAGE.Value);
				this.db.SetParameterValue(comm.Parameters, "@MWBOOK", this.MWBOOK.Value);
				this.db.SetParameterValue(comm.Parameters, "@MWPAGE", this.MWPAGE.Value);
				this.db.SetParameterValue(comm.Parameters, "@MDCODE", this.MDCODE.Value);
				this.db.SetParameterValue(comm.Parameters, "@MWCODE", this.MWCODE.Value);
				this.db.SetParameterValue(comm.Parameters, "@MMORTC", this.MMORTC.Value);
				this.db.SetParameterValue(comm.Parameters, "@MFILL7", this.MFILL7.Value);
				this.db.SetParameterValue(comm.Parameters, "@MACRE_NUM", this.MACRE_NUM.Value);
				this.db.SetParameterValue(comm.Parameters, "@MGISPN", this.MGISPN.Value);
				this.db.SetParameterValue(comm.Parameters, "@MUSER3", this.MUSER3.Value);
				this.db.SetParameterValue(comm.Parameters, "@MUSER4", this.MUSER4.Value);
				this.db.SetParameterValue(comm.Parameters, "@MIMADJ", this.MIMADJ.Value);
				this.db.SetParameterValue(comm.Parameters, "@MCDRDT", this.MCDRDT.Value);
				this.db.SetParameterValue(comm.Parameters, "@MMNUD", this.MMNUD.Value);
				this.db.SetParameterValue(comm.Parameters, "@MMNNUD", this.MMNNUD.Value);
				this.db.SetParameterValue(comm.Parameters, "@MSS1", this.MSS1.Value);
				this.db.SetParameterValue(comm.Parameters, "@MPCODE", this.MPCODE.Value);
				this.db.SetParameterValue(comm.Parameters, "@MPBOOK", this.MPBOOK.Value);
				this.db.SetParameterValue(comm.Parameters, "@MPPAGE", this.MPPAGE.Value);
				this.db.SetParameterValue(comm.Parameters, "@MSS2", this.MSS2.Value);
				this.db.SetParameterValue(comm.Parameters, "@MASSM", this.MASSM.Value);
				this.db.SetParameterValue(comm.Parameters, "@MFILL9", this.MFILL9.Value);
				this.db.SetParameterValue(comm.Parameters, "@MGRNTR", this.MGRNTR.Value);
				this.db.SetParameterValue(comm.Parameters, "@MCVMO", this.MCVMO.Value);
				this.db.SetParameterValue(comm.Parameters, "@MCVDA", this.MCVDA.Value);
				this.db.SetParameterValue(comm.Parameters, "@MCVYR", this.MCVYR.Value);
				this.db.SetParameterValue(comm.Parameters, "@MPROUT", this.MPROUT.Value);
				this.db.SetParameterValue(comm.Parameters, "@MPERR", this.MPERR.Value);
				this.db.SetParameterValue(comm.Parameters, "@MTBIMP", this.MTBIMP.Value);
				this.db.SetParameterValue(comm.Parameters, "@MPUSE", this.MPUSE.Value);
				this.db.SetParameterValue(comm.Parameters, "@MCVEXP", this.MCVEXP.Value);
				this.db.SetParameterValue(comm.Parameters, "@METXYR", this.METXYR.Value);
				this.db.SetParameterValue(comm.Parameters, "@MQAPCH", this.MQAPCH.Value);
				this.db.SetParameterValue(comm.Parameters, "@MQAFIL", this.MQAFIL.Value);
				this.db.SetParameterValue(comm.Parameters, "@MPICT", this.MPICT.Value);
				this.db.SetParameterValue(comm.Parameters, "@MEACRE", this.MEACRE.Value);
				this.db.SetParameterValue(comm.Parameters, "@MPRCIT", this.MPRCIT.Value);
				this.db.SetParameterValue(comm.Parameters, "@MPRSTA", this.MPRSTA.Value);
				this.db.SetParameterValue(comm.Parameters, "@MPRZP1", this.MPRZP1.Value);
				this.db.SetParameterValue(comm.Parameters, "@MPRZP4", this.MPRZP4.Value);
				this.db.SetParameterValue(comm.Parameters, "@MFP_NUM", this.MFP_NUM.Value);
				this.db.SetParameterValue(comm.Parameters, "@MSFP_NUM", this.MSFP_NUM.Value);
				this.db.SetParameterValue(comm.Parameters, "@MFL_NUM", this.MFL_NUM.Value);
				this.db.SetParameterValue(comm.Parameters, "@MSFL_NUM", this.MSFL_NUM.Value);
				this.db.SetParameterValue(comm.Parameters, "@MMFL_NUM", this.MMFL_NUM.Value);
				this.db.SetParameterValue(comm.Parameters, "@MIOFP_NUM", this.MIOFP_NUM.Value);
				this.db.SetParameterValue(comm.Parameters, "@MSTOR_NUM", this.MSTOR_NUM.Value);
				this.db.SetParameterValue(comm.Parameters, "@MASCOM", this.MASCOM.Value);
				this.db.SetParameterValue(comm.Parameters, "@MHRPH_NUM", this.MHRPH_NUM.Value);
				this.db.SetParameterValue(comm.Parameters, "@MHRDAT", this.MHRDAT.Value);
				this.db.SetParameterValue(comm.Parameters, "@MHRTIM", this.MHRTIM.Value);
				this.db.SetParameterValue(comm.Parameters, "@MHRNAM", this.MHRNAM.Value);
				this.db.SetParameterValue(comm.Parameters, "@MHRSES", this.MHRSES.Value);
				this.db.SetParameterValue(comm.Parameters, "@MHIDPC", this.MHIDPC.Value);
				this.db.SetParameterValue(comm.Parameters, "@MHIDNM", this.MHIDNM.Value);
				this.db.SetParameterValue(comm.Parameters, "@MCAMO", this.MCAMO.Value);
				this.db.SetParameterValue(comm.Parameters, "@MCADA", this.MCADA.Value);
				this.db.SetParameterValue(comm.Parameters, "@MCAYR", this.MCAYR.Value);
				this.db.SetParameterValue(comm.Parameters, "@MOLDOC", this.MOLDOC.Value);

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

				this.MRECID.setValue(dr["MRECID"].ToString());
				this.MRECNO.setValue(dr["MRECNO"].ToString());
				this.MDWELL.setValue(dr["MDWELL"].ToString());
				this.MMAP.setValue(dr["MMAP"].ToString());
				this.MLNAM.setValue(dr["MLNAM"].ToString());
				this.MFNAM.setValue(dr["MFNAM"].ToString());
				this.MADD1.setValue(dr["MADD1"].ToString());
				this.MADD2.setValue(dr["MADD2"].ToString());
				this.MCITY.setValue(dr["MCITY"].ToString());
				this.MSTATE.setValue(dr["MSTATE"].ToString());
				this.MZIP5.setValue(dr["MZIP5"].ToString());
				this.MZIP4.setValue(dr["MZIP4"].ToString());
				this.MACRE.setValue(dr["MACRE"].ToString());
				this.MZONE.setValue(dr["MZONE"].ToString());
				this.MLUSE.setValue(dr["MLUSE"].ToString());
				this.MOCCUP.setValue(dr["MOCCUP"].ToString());
				this.MSTORY.setValue(dr["MSTORY"].ToString());
				this.MAGE.setValue(dr["MAGE"].ToString());
				this.MCOND.setValue(dr["MCOND"].ToString());
				this.MCLASS.setValue(dr["MCLASS"].ToString());
				this.MFACTR.setValue(dr["MFACTR"].ToString());
				this.MDEPRC.setValue(dr["MDEPRC"].ToString());
				this.MFOUND.setValue(dr["MFOUND"].ToString());
				this.MEXWLL.setValue(dr["MEXWLL"].ToString());
				this.MROOFT.setValue(dr["MROOFT"].ToString());
				this.MROOFG.setValue(dr["MROOFG"].ToString());
				this.M_NUMDUNT.setValue(dr["M_NUMDUNT"].ToString());
				this.M_NUMROOM.setValue(dr["M_NUMROOM"].ToString());
				this.M_NUMBR.setValue(dr["M_NUMBR"].ToString());
				this.M_NUMFBTH.setValue(dr["M_NUMFBTH"].ToString());
				this.M_NUMHBTH.setValue(dr["M_NUMHBTH"].ToString());
				this.MFP2.setValue(dr["MFP2"].ToString());
				this.MLTRCD.setValue(dr["MLTRCD"].ToString());
				this.MHEAT.setValue(dr["MHEAT"].ToString());
				this.MFUEL.setValue(dr["MFUEL"].ToString());
				this.MAC.setValue(dr["MAC"].ToString());
				this.MFP1.setValue(dr["MFP1"].ToString());
				this.MCDR.setValue(dr["MCDR"].ToString());
				this.MEKIT.setValue(dr["MEKIT"].ToString());
				this.MBASTP.setValue(dr["MBASTP"].ToString());
				this.MPBTOT.setValue(dr["MPBTOT"].ToString());
				this.MSBTOT.setValue(dr["MSBTOT"].ToString());
				this.MPBFIN.setValue(dr["MPBFIN"].ToString());
				this.MSBFIN.setValue(dr["MSBFIN"].ToString());
				this.MBRATE.setValue(dr["MBRATE"].ToString());
				this.M_NUMFLUE.setValue(dr["M_NUMFLUE"].ToString());
				this.MFLUTP.setValue(dr["MFLUTP"].ToString());
				this.MGART.setValue(dr["MGART"].ToString());
				this.MGAR_NUMC.setValue(dr["MGAR_NUMC"].ToString());
				this.MCARPT.setValue(dr["MCARPT"].ToString());
				this.MCAR_NUMC.setValue(dr["MCAR_NUMC"].ToString());
				this.MBI_NUMC.setValue(dr["MBI_NUMC"].ToString());
				this.MROW.setValue(dr["MROW"].ToString());
				this.MEASE.setValue(dr["MEASE"].ToString());
				this.MWATER.setValue(dr["MWATER"].ToString());
				this.MSEWER.setValue(dr["MSEWER"].ToString());
				this.MGAS.setValue(dr["MGAS"].ToString());
				this.MELEC.setValue(dr["MELEC"].ToString());
				this.MTERRN.setValue(dr["MTERRN"].ToString());
				this.MCHAR.setValue(dr["MCHAR"].ToString());
				this.MOTDES.setValue(dr["MOTDES"].ToString());
				this.MGART2.setValue(dr["MGART2"].ToString());
				this.MGAR_NUM2.setValue(dr["MGAR_NUM2"].ToString());
				this.MDATLG.setValue(dr["MDATLG"].ToString());
				this.MDATPR.setValue(dr["MDATPR"].ToString());
				this.MINTYP.setValue(dr["MINTYP"].ToString());
				this.MINTYR.setValue(dr["MINTYR"].ToString());
				this.MINNO_NUM.setValue(dr["MINNO_NUM"].ToString());
				this.MINNO2.setValue(dr["MINNO2"].ToString());
				this.MDSUFX.setValue(dr["MDSUFX"].ToString());
				this.MWSUFX.setValue(dr["MWSUFX"].ToString());
				this.MPSUFX.setValue(dr["MPSUFX"].ToString());
				this.MIMPRV.setValue(dr["MIMPRV"].ToString());
				this.MTOTLD.setValue(dr["MTOTLD"].ToString());
				this.MTOTOI.setValue(dr["MTOTOI"].ToString());
				this.MTOTPR.setValue(dr["MTOTPR"].ToString());
				this.MASSB.setValue(dr["MASSB"].ToString());
				this.MACPCT.setValue(dr["MACPCT"].ToString());
				this.M1FRNT.setValue(dr["M1FRNT"].ToString());
				this.M1DPTH.setValue(dr["M1DPTH"].ToString());
				this.M1AREA.setValue(dr["M1AREA"].ToString());
				this.MMCODE.setValue(dr["MMCODE"].ToString());
				this.M0DEPR.setValue(dr["M0DEPR"].ToString());
				this.M1UM.setValue(dr["M1UM"].ToString());
				this.M2FRNT.setValue(dr["M2FRNT"].ToString());
				this.M2DPTH.setValue(dr["M2DPTH"].ToString());
				this.M2AREA.setValue(dr["M2AREA"].ToString());
				this.MZIPBR.setValue(dr["MZIPBR"].ToString());
				this.MDELAY.setValue(dr["MDELAY"].ToString());
				this.M2UM.setValue(dr["M2UM"].ToString());
				this.MSTRT.setValue(dr["MSTRT"].ToString());
				this.MDIRCT.setValue(dr["MDIRCT"].ToString());
				this.MHSE_NUM.setValue(dr["MHSE_NUM"].ToString());
				this.MCDMO.setValue(dr["MCDMO"].ToString());
				this.MCDDA.setValue(dr["MCDDA"].ToString());
				this.MCDYR.setValue(dr["MCDYR"].ToString());
				this.M1DFAC.setValue(dr["M1DFAC"].ToString());
				this.MREM1.setValue(dr["MREM1"].ToString());
				this.MREM2.setValue(dr["MREM2"].ToString());
				this.MMAGCD.setValue(dr["MMAGCD"].ToString());
				this.MATHOM.setValue(dr["MATHOM"].ToString());
				this.MDESC1.setValue(dr["MDESC1"].ToString());
				this.MDESC2.setValue(dr["MDESC2"].ToString());
				this.MDESC3.setValue(dr["MDESC3"].ToString());
				this.MDESC4.setValue(dr["MDESC4"].ToString());
				this.MFAIRV.setValue(dr["MFAIRV"].ToString());
				this.MLGITY.setValue(dr["MLGITY"].ToString());
				this.MLGIYR.setValue(dr["MLGIYR"].ToString());
				this.MLGNO_NUM.setValue(dr["MLGNO_NUM"].ToString());
				this.MLGNO2.setValue(dr["MLGNO2"].ToString());
				this.MSUBDV.setValue(dr["MSUBDV"].ToString());
				this.MSELLP.setValue(dr["MSELLP"].ToString());
				this.M2DFAC.setValue(dr["M2DFAC"].ToString());
				this.MINIT.setValue(dr["MINIT"].ToString());
				this.MINSPD.setValue(dr["MINSPD"].ToString());
				this.MSWL.setValue(dr["MSWL"].ToString());
				this.MTUTIL.setValue(dr["MTUTIL"].ToString());
				this.MNBADJ.setValue(dr["MNBADJ"].ToString());
				this.MASSL.setValue(dr["MASSL"].ToString());
				this.MACSF.setValue(dr["MACSF"].ToString());
				this.MCOMM1.setValue(dr["MCOMM1"].ToString());
				this.MCOMM2.setValue(dr["MCOMM2"].ToString());
				this.MCOMM3.setValue(dr["MCOMM3"].ToString());
				this.MACCT.setValue(dr["MACCT"].ToString());
				this.MEXWL2.setValue(dr["MEXWL2"].ToString());
				this.MCALC.setValue(dr["MCALC"].ToString());
				this.MFILL4.setValue(dr["MFILL4"].ToString());
				this.MTBV.setValue(dr["MTBV"].ToString());
				this.MTBAS.setValue(dr["MTBAS"].ToString());
				this.MTFBAS.setValue(dr["MTFBAS"].ToString());
				this.MTPLUM.setValue(dr["MTPLUM"].ToString());
				this.MTHEAT.setValue(dr["MTHEAT"].ToString());
				this.MTAC.setValue(dr["MTAC"].ToString());
				this.MTFP.setValue(dr["MTFP"].ToString());
				this.MTFL.setValue(dr["MTFL"].ToString());
				this.MTBI.setValue(dr["MTBI"].ToString());
				this.MTTADD.setValue(dr["MTTADD"].ToString());
				this.MTSUBT.setValue(dr["MTSUBT"].ToString());
				this.MTOTBV.setValue(dr["MTOTBV"].ToString());
				this.MUSRID.setValue(dr["MUSRID"].ToString());
				this.MBASA.setValue(dr["MBASA"].ToString());
				this.MTOTA.setValue(dr["MTOTA"].ToString());
				this.MPSF.setValue(dr["MPSF"].ToString());
				this.MINWLL.setValue(dr["MINWLL"].ToString());
				this.MFLOOR.setValue(dr["MFLOOR"].ToString());
				this.MYRBLT.setValue(dr["MYRBLT"].ToString());
				this.MCNST1.setValue(dr["MCNST1"].ToString());
				this.MCNST2.setValue(dr["MCNST2"].ToString());
				this.MASSLU.setValue(dr["MASSLU"].ToString());
				this.MMOSLD.setValue(dr["MMOSLD"].ToString());
				this.MDASLD.setValue(dr["MDASLD"].ToString());
				this.MYRSLD.setValue(dr["MYRSLD"].ToString());
				this.MTIME.setValue(dr["MTIME"].ToString());
				this.MHSE_NUM2.setValue(dr["MHSE_NUM2"].ToString());
				this.M1ADJ.setValue(dr["M1ADJ"].ToString());
				this.M2ADJ.setValue(dr["M2ADJ"].ToString());
				this.MLGBKC.setValue(dr["MLGBKC"].ToString());
				this.MLGBK_NUM.setValue(dr["MLGBK_NUM"].ToString());
				this.MLGPG_NUM.setValue(dr["MLGPG_NUM"].ToString());
				this.MEFFAG.setValue(dr["MEFFAG"].ToString());
				this.MPCOMP.setValue(dr["MPCOMP"].ToString());
				this.MSTTYP.setValue(dr["MSTTYP"].ToString());
				this.MSDIRS.setValue(dr["MSDIRS"].ToString());
				this.M1RATE.setValue(dr["M1RATE"].ToString());
				this.M2RATE.setValue(dr["M2RATE"].ToString());
				this.MFUNCD.setValue(dr["MFUNCD"].ToString());
				this.MECOND.setValue(dr["MECOND"].ToString());
				this.MNBRHD.setValue(dr["MNBRHD"].ToString());
				this.MUSER1.setValue(dr["MUSER1"].ToString());
				this.MUSER2.setValue(dr["MUSER2"].ToString());
				this.MDBOOK.setValue(dr["MDBOOK"].ToString());
				this.MDPAGE.setValue(dr["MDPAGE"].ToString());
				this.MWBOOK.setValue(dr["MWBOOK"].ToString());
				this.MWPAGE.setValue(dr["MWPAGE"].ToString());
				this.MDCODE.setValue(dr["MDCODE"].ToString());
				this.MWCODE.setValue(dr["MWCODE"].ToString());
				this.MMORTC.setValue(dr["MMORTC"].ToString());
				this.MFILL7.setValue(dr["MFILL7"].ToString());
				this.MACRE_NUM.setValue(dr["MACRE_NUM"].ToString());
				this.MGISPN.setValue(dr["MGISPN"].ToString());
				this.MUSER3.setValue(dr["MUSER3"].ToString());
				this.MUSER4.setValue(dr["MUSER4"].ToString());
				this.MIMADJ.setValue(dr["MIMADJ"].ToString());
				this.MCDRDT.setValue(dr["MCDRDT"].ToString());
				this.MMNUD.setValue(dr["MMNUD"].ToString());
				this.MMNNUD.setValue(dr["MMNNUD"].ToString());
				this.MSS1.setValue(dr["MSS1"].ToString());
				this.MPCODE.setValue(dr["MPCODE"].ToString());
				this.MPBOOK.setValue(dr["MPBOOK"].ToString());
				this.MPPAGE.setValue(dr["MPPAGE"].ToString());
				this.MSS2.setValue(dr["MSS2"].ToString());
				this.MASSM.setValue(dr["MASSM"].ToString());
				this.MFILL9.setValue(dr["MFILL9"].ToString());
				this.MGRNTR.setValue(dr["MGRNTR"].ToString());
				this.MCVMO.setValue(dr["MCVMO"].ToString());
				this.MCVDA.setValue(dr["MCVDA"].ToString());
				this.MCVYR.setValue(dr["MCVYR"].ToString());
				this.MPROUT.setValue(dr["MPROUT"].ToString());
				this.MPERR.setValue(dr["MPERR"].ToString());
				this.MTBIMP.setValue(dr["MTBIMP"].ToString());
				this.MPUSE.setValue(dr["MPUSE"].ToString());
				this.MCVEXP.setValue(dr["MCVEXP"].ToString());
				this.METXYR.setValue(dr["METXYR"].ToString());
				this.MQAPCH.setValue(dr["MQAPCH"].ToString());
				this.MQAFIL.setValue(dr["MQAFIL"].ToString());
				this.MPICT.setValue(dr["MPICT"].ToString());
				this.MEACRE.setValue(dr["MEACRE"].ToString());
				this.MPRCIT.setValue(dr["MPRCIT"].ToString());
				this.MPRSTA.setValue(dr["MPRSTA"].ToString());
				this.MPRZP1.setValue(dr["MPRZP1"].ToString());
				this.MPRZP4.setValue(dr["MPRZP4"].ToString());
				this.MFP_NUM.setValue(dr["MFP_NUM"].ToString());
				this.MSFP_NUM.setValue(dr["MSFP_NUM"].ToString());
				this.MFL_NUM.setValue(dr["MFL_NUM"].ToString());
				this.MSFL_NUM.setValue(dr["MSFL_NUM"].ToString());
				this.MMFL_NUM.setValue(dr["MMFL_NUM"].ToString());
				this.MIOFP_NUM.setValue(dr["MIOFP_NUM"].ToString());
				this.MSTOR_NUM.setValue(dr["MSTOR_NUM"].ToString());
				this.MASCOM.setValue(dr["MASCOM"].ToString());
				this.MHRPH_NUM.setValue(dr["MHRPH_NUM"].ToString());
				this.MHRDAT.setValue(dr["MHRDAT"].ToString());
				this.MHRTIM.setValue(dr["MHRTIM"].ToString());
				this.MHRNAM.setValue(dr["MHRNAM"].ToString());
				this.MHRSES.setValue(dr["MHRSES"].ToString());
				this.MHIDPC.setValue(dr["MHIDPC"].ToString());
				this.MHIDNM.setValue(dr["MHIDNM"].ToString());
				this.MCAMO.setValue(dr["MCAMO"].ToString());
				this.MCADA.setValue(dr["MCADA"].ToString());
				this.MCAYR.setValue(dr["MCAYR"].ToString());
				this.MOLDOC.setValue(dr["MOLDOC"].ToString());

				isOK = true;
			}
			catch (System.Exception ex)
			{
				this.lastException = ex;
				Console.WriteLine(string.Format("Error: {0}", ex.Message));
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
				sb.Append(REMaster.allFieldNamesActual);
				sb.Append(" ) ");
				sb.Append("values( ");
				sb.Append("'" + this.MRECID.Text + "'");
				sb.Append(", ");
				sb.Append(this.MRECNO.ToString());
				sb.Append(", ");
				sb.Append(this.MDWELL.ToString());
				sb.Append(", ");
				sb.Append("'" + this.MMAP.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MLNAM.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MFNAM.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MADD1.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MADD2.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MCITY.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MSTATE.Text + "'");
				sb.Append(", ");
				sb.Append(this.MZIP5.ToString());
				sb.Append(", ");
				sb.Append("'" + this.MZIP4.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MACRE.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MZONE.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MLUSE.Text + "'");
				sb.Append(", ");
				sb.Append(this.MOCCUP.ToString());
				sb.Append(", ");
				sb.Append("'" + this.MSTORY.Text + "'");
				sb.Append(", ");
				sb.Append(this.MAGE.ToString());
				sb.Append(", ");
				sb.Append("'" + this.MCOND.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MCLASS.Text + "'");
				sb.Append(", ");
				sb.Append(this.MFACTR.ToString());
				sb.Append(", ");
				sb.Append(this.MDEPRC.ToString());
				sb.Append(", ");
				sb.Append(this.MFOUND.ToString());
				sb.Append(", ");
				sb.Append(this.MEXWLL.ToString());
				sb.Append(", ");
				sb.Append(this.MROOFT.ToString());
				sb.Append(", ");
				sb.Append(this.MROOFG.ToString());
				sb.Append(", ");
				sb.Append(this.M_NUMDUNT.ToString());
				sb.Append(", ");
				sb.Append(this.M_NUMROOM.ToString());
				sb.Append(", ");
				sb.Append(this.M_NUMBR.ToString());
				sb.Append(", ");
				sb.Append(this.M_NUMFBTH.ToString());
				sb.Append(", ");
				sb.Append(this.M_NUMHBTH.ToString());
				sb.Append(", ");
				sb.Append("'" + this.MFP2.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MLTRCD.Text + "'");
				sb.Append(", ");
				sb.Append(this.MHEAT.ToString());
				sb.Append(", ");
				sb.Append(this.MFUEL.ToString());
				sb.Append(", ");
				sb.Append("'" + this.MAC.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MFP1.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MCDR.Text + "'");
				sb.Append(", ");
				sb.Append(this.MEKIT.ToString());
				sb.Append(", ");
				sb.Append(this.MBASTP.ToString());
				sb.Append(", ");
				sb.Append(this.MPBTOT.ToString());
				sb.Append(", ");
				sb.Append(this.MSBTOT.ToString());
				sb.Append(", ");
				sb.Append(this.MPBFIN.ToString());
				sb.Append(", ");
				sb.Append(this.MSBFIN.ToString());
				sb.Append(", ");
				sb.Append(this.MBRATE.ToString());
				sb.Append(", ");
				sb.Append(this.M_NUMFLUE.ToString());
				sb.Append(", ");
				sb.Append("'" + this.MFLUTP.Text + "'");
				sb.Append(", ");
				sb.Append(this.MGART.ToString());
				sb.Append(", ");
				sb.Append(this.MGAR_NUMC.ToString());
				sb.Append(", ");
				sb.Append(this.MCARPT.ToString());
				sb.Append(", ");
				sb.Append(this.MCAR_NUMC.ToString());
				sb.Append(", ");
				sb.Append(this.MBI_NUMC.ToString());
				sb.Append(", ");
				sb.Append(this.MROW.ToString());
				sb.Append(", ");
				sb.Append(this.MEASE.ToString());
				sb.Append(", ");
				sb.Append(this.MWATER.ToString());
				sb.Append(", ");
				sb.Append(this.MSEWER.ToString());
				sb.Append(", ");
				sb.Append("'" + this.MGAS.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MELEC.Text + "'");
				sb.Append(", ");
				sb.Append(this.MTERRN.ToString());
				sb.Append(", ");
				sb.Append(this.MCHAR.ToString());
				sb.Append(", ");
				sb.Append("'" + this.MOTDES.Text + "'");
				sb.Append(", ");
				sb.Append(this.MGART2.ToString());
				sb.Append(", ");
				sb.Append(this.MGAR_NUM2.ToString());
				sb.Append(", ");
				sb.Append(this.MDATLG.ToString());
				sb.Append(", ");
				sb.Append(this.MDATPR.ToString());
				sb.Append(", ");
				sb.Append("'" + this.MINTYP.Text + "'");
				sb.Append(", ");
				sb.Append(this.MINTYR.ToString());
				sb.Append(", ");
				sb.Append(this.MINNO_NUM.ToString());
				sb.Append(", ");
				sb.Append(this.MINNO2.ToString());
				sb.Append(", ");
				sb.Append("'" + this.MDSUFX.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MWSUFX.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MPSUFX.Text + "'");
				sb.Append(", ");
				sb.Append(this.MIMPRV.ToString());
				sb.Append(", ");
				sb.Append(this.MTOTLD.ToString());
				sb.Append(", ");
				sb.Append(this.MTOTOI.ToString());
				sb.Append(", ");
				sb.Append(this.MTOTPR.ToString());
				sb.Append(", ");
				sb.Append(this.MASSB.ToString());
				sb.Append(", ");
				sb.Append(this.MACPCT.ToString());
				sb.Append(", ");
				sb.Append(this.M1FRNT.ToString());
				sb.Append(", ");
				sb.Append(this.M1DPTH.ToString());
				sb.Append(", ");
				sb.Append(this.M1AREA.ToString());
				sb.Append(", ");
				sb.Append(this.MMCODE.ToString());
				sb.Append(", ");
				sb.Append("'" + this.M0DEPR.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.M1UM.Text + "'");
				sb.Append(", ");
				sb.Append(this.M2FRNT.ToString());
				sb.Append(", ");
				sb.Append(this.M2DPTH.ToString());
				sb.Append(", ");
				sb.Append(this.M2AREA.ToString());
				sb.Append(", ");
				sb.Append(this.MZIPBR.ToString());
				sb.Append(", ");
				sb.Append("'" + this.MDELAY.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.M2UM.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MSTRT.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MDIRCT.Text + "'");
				sb.Append(", ");
				sb.Append(this.MHSE_NUM.ToString());
				sb.Append(", ");
				sb.Append(this.MCDMO.ToString());
				sb.Append(", ");
				sb.Append(this.MCDDA.ToString());
				sb.Append(", ");
				sb.Append(this.MCDYR.ToString());
				sb.Append(", ");
				sb.Append(this.M1DFAC.ToString());
				sb.Append(", ");
				sb.Append("'" + this.MREM1.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MREM2.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MMAGCD.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MATHOM.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MDESC1.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MDESC2.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MDESC3.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MDESC4.Text + "'");
				sb.Append(", ");
				sb.Append(this.MFAIRV.ToString());
				sb.Append(", ");
				sb.Append("'" + this.MLGITY.Text + "'");
				sb.Append(", ");
				sb.Append(this.MLGIYR.ToString());
				sb.Append(", ");
				sb.Append(this.MLGNO_NUM.ToString());
				sb.Append(", ");
				sb.Append(this.MLGNO2.ToString());
				sb.Append(", ");
				sb.Append("'" + this.MSUBDV.Text + "'");
				sb.Append(", ");
				sb.Append(this.MSELLP.ToString());
				sb.Append(", ");
				sb.Append(this.M2DFAC.ToString());
				sb.Append(", ");
				sb.Append("'" + this.MINIT.Text + "'");
				sb.Append(", ");
				sb.Append(this.MINSPD.ToString());
				sb.Append(", ");
				sb.Append(this.MSWL.ToString());
				sb.Append(", ");
				sb.Append(this.MTUTIL.ToString());
				sb.Append(", ");
				sb.Append(this.MNBADJ.ToString());
				sb.Append(", ");
				sb.Append(this.MASSL.ToString());
				sb.Append(", ");
				sb.Append(this.MACSF.ToString());
				sb.Append(", ");
				sb.Append("'" + this.MCOMM1.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MCOMM2.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MCOMM3.Text + "'");
				sb.Append(", ");
				sb.Append(this.MACCT.ToString());
				sb.Append(", ");
				sb.Append(this.MEXWL2.ToString());
				sb.Append(", ");
				sb.Append("'" + this.MCALC.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MFILL4.Text + "'");
				sb.Append(", ");
				sb.Append(this.MTBV.ToString());
				sb.Append(", ");
				sb.Append(this.MTBAS.ToString());
				sb.Append(", ");
				sb.Append(this.MTFBAS.ToString());
				sb.Append(", ");
				sb.Append(this.MTPLUM.ToString());
				sb.Append(", ");
				sb.Append(this.MTHEAT.ToString());
				sb.Append(", ");
				sb.Append(this.MTAC.ToString());
				sb.Append(", ");
				sb.Append(this.MTFP.ToString());
				sb.Append(", ");
				sb.Append(this.MTFL.ToString());
				sb.Append(", ");
				sb.Append(this.MTBI.ToString());
				sb.Append(", ");
				sb.Append(this.MTTADD.ToString());
				sb.Append(", ");
				sb.Append(this.MTSUBT.ToString());
				sb.Append(", ");
				sb.Append(this.MTOTBV.ToString());
				sb.Append(", ");
				sb.Append("'" + this.MUSRID.Text + "'");
				sb.Append(", ");
				sb.Append(this.MBASA.ToString());
				sb.Append(", ");
				sb.Append(this.MTOTA.ToString());
				sb.Append(", ");
				sb.Append(this.MPSF.ToString());
				sb.Append(", ");
				sb.Append("'" + this.MINWLL.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MFLOOR.Text + "'");
				sb.Append(", ");
				sb.Append(this.MYRBLT.ToString());
				sb.Append(", ");
				sb.Append("'" + this.MCNST1.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MCNST2.Text + "'");
				sb.Append(", ");
				sb.Append(this.MASSLU.ToString());
				sb.Append(", ");
				sb.Append(this.MMOSLD.ToString());
				sb.Append(", ");
				sb.Append(this.MDASLD.ToString());
				sb.Append(", ");
				sb.Append(this.MYRSLD.ToString());
				sb.Append(", ");
				sb.Append(this.MTIME.ToString());
				sb.Append(", ");
				sb.Append("'" + this.MHSE_NUM2.Text + "'");
				sb.Append(", ");
				sb.Append(this.M1ADJ.ToString());
				sb.Append(", ");
				sb.Append(this.M2ADJ.ToString());
				sb.Append(", ");
				sb.Append("'" + this.MLGBKC.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MLGBK_NUM.Text + "'");
				sb.Append(", ");
				sb.Append(this.MLGPG_NUM.ToString());
				sb.Append(", ");
				sb.Append(this.MEFFAG.ToString());
				sb.Append(", ");
				sb.Append(this.MPCOMP.ToString());
				sb.Append(", ");
				sb.Append("'" + this.MSTTYP.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MSDIRS.Text + "'");
				sb.Append(", ");
				sb.Append(this.M1RATE.ToString());
				sb.Append(", ");
				sb.Append(this.M2RATE.ToString());
				sb.Append(", ");
				sb.Append(this.MFUNCD.ToString());
				sb.Append(", ");
				sb.Append(this.MECOND.ToString());
				sb.Append(", ");
				sb.Append(this.MNBRHD.ToString());
				sb.Append(", ");
				sb.Append("'" + this.MUSER1.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MUSER2.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MDBOOK.Text + "'");
				sb.Append(", ");
				sb.Append(this.MDPAGE.ToString());
				sb.Append(", ");
				sb.Append("'" + this.MWBOOK.Text + "'");
				sb.Append(", ");
				sb.Append(this.MWPAGE.ToString());
				sb.Append(", ");
				sb.Append("'" + this.MDCODE.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MWCODE.Text + "'");
				sb.Append(", ");
				sb.Append(this.MMORTC.ToString());
				sb.Append(", ");
				sb.Append("'" + this.MFILL7.Text + "'");
				sb.Append(", ");
				sb.Append(this.MACRE_NUM.ToString());
				sb.Append(", ");
				sb.Append("'" + this.MGISPN.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MUSER3.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MUSER4.Text + "'");
				sb.Append(", ");
				sb.Append(this.MIMADJ.ToString());
				sb.Append(", ");
				sb.Append(this.MCDRDT.ToString());
				sb.Append(", ");
				sb.Append(this.MMNUD.ToString());
				sb.Append(", ");
				sb.Append(this.MMNNUD.ToString());
				sb.Append(", ");
				sb.Append(this.MSS1.ToString());
				sb.Append(", ");
				sb.Append("'" + this.MPCODE.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MPBOOK.Text + "'");
				sb.Append(", ");
				sb.Append(this.MPPAGE.ToString());
				sb.Append(", ");
				sb.Append(this.MSS2.ToString());
				sb.Append(", ");
				sb.Append(this.MASSM.ToString());
				sb.Append(", ");
				sb.Append("'" + this.MFILL9.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MGRNTR.Text + "'");
				sb.Append(", ");
				sb.Append(this.MCVMO.ToString());
				sb.Append(", ");
				sb.Append(this.MCVDA.ToString());
				sb.Append(", ");
				sb.Append(this.MCVYR.ToString());
				sb.Append(", ");
				sb.Append("'" + this.MPROUT.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MPERR.Text + "'");
				sb.Append(", ");
				sb.Append(this.MTBIMP.ToString());
				sb.Append(", ");
				sb.Append(this.MPUSE.ToString());
				sb.Append(", ");
				sb.Append("'" + this.MCVEXP.Text + "'");
				sb.Append(", ");
				sb.Append(this.METXYR.ToString());
				sb.Append(", ");
				sb.Append(this.MQAPCH.ToString());
				sb.Append(", ");
				sb.Append("'" + this.MQAFIL.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MPICT.Text + "'");
				sb.Append(", ");
				sb.Append(this.MEACRE.ToString());
				sb.Append(", ");
				sb.Append("'" + this.MPRCIT.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MPRSTA.Text + "'");
				sb.Append(", ");
				sb.Append(this.MPRZP1.ToString());
				sb.Append(", ");
				sb.Append("'" + this.MPRZP4.Text + "'");
				sb.Append(", ");
				sb.Append(this.MFP_NUM.ToString());
				sb.Append(", ");
				sb.Append(this.MSFP_NUM.ToString());
				sb.Append(", ");
				sb.Append(this.MFL_NUM.ToString());
				sb.Append(", ");
				sb.Append(this.MSFL_NUM.ToString());
				sb.Append(", ");
				sb.Append(this.MMFL_NUM.ToString());
				sb.Append(", ");
				sb.Append(this.MIOFP_NUM.ToString());
				sb.Append(", ");
				sb.Append(this.MSTOR_NUM.ToString());
				sb.Append(", ");
				sb.Append("'" + this.MASCOM.Text + "'");
				sb.Append(", ");
				sb.Append(this.MHRPH_NUM.ToString());
				sb.Append(", ");
				sb.Append(this.MHRDAT.ToString());
				sb.Append(", ");
				sb.Append(this.MHRTIM.ToString());
				sb.Append(", ");
				sb.Append("'" + this.MHRNAM.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MHRSES.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MHIDPC.Text + "'");
				sb.Append(", ");
				sb.Append("'" + this.MHIDNM.Text + "'");
				sb.Append(", ");
				sb.Append(this.MCAMO.ToString());
				sb.Append(", ");
				sb.Append(this.MCADA.ToString());
				sb.Append(", ");
				sb.Append(this.MCAYR.ToString());
				sb.Append(", ");
				sb.Append(this.MOLDOC.ToString());

				sb.Append(" )");

				string cmd = sb.ToString();
				rowCount = this.db.ExecuteNonSelectStatement(cmd);
			}
			catch (System.Exception ex)
			{
				this.lastException = ex;
				Console.WriteLine(string.Format("Error: {0}", ex.Message));
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
				sb.Append("MRECID = '" + this.MRECID.Text + "'");
				sb.Append(", ");
				sb.Append("MRECNO = " + this.MRECNO.ToString());
				sb.Append(", ");
				sb.Append("MDWELL = " + this.MDWELL.ToString());
				sb.Append(", ");
				sb.Append("MMAP = '" + this.MMAP.Text + "'");
				sb.Append(", ");
				sb.Append("MLNAM = '" + this.MLNAM.Text + "'");
				sb.Append(", ");
				sb.Append("MFNAM = '" + this.MFNAM.Text + "'");
				sb.Append(", ");
				sb.Append("MADD1 = '" + this.MADD1.Text + "'");
				sb.Append(", ");
				sb.Append("MADD2 = '" + this.MADD2.Text + "'");
				sb.Append(", ");
				sb.Append("MCITY = '" + this.MCITY.Text + "'");
				sb.Append(", ");
				sb.Append("MSTATE = '" + this.MSTATE.Text + "'");
				sb.Append(", ");
				sb.Append("MZIP5 = " + this.MZIP5.ToString());
				sb.Append(", ");
				sb.Append("MZIP4 = '" + this.MZIP4.Text + "'");
				sb.Append(", ");
				sb.Append("MACRE = '" + this.MACRE.Text + "'");
				sb.Append(", ");
				sb.Append("MZONE = '" + this.MZONE.Text + "'");
				sb.Append(", ");
				sb.Append("MLUSE = '" + this.MLUSE.Text + "'");
				sb.Append(", ");
				sb.Append("MOCCUP = " + this.MOCCUP.ToString());
				sb.Append(", ");
				sb.Append("MSTORY = '" + this.MSTORY.Text + "'");
				sb.Append(", ");
				sb.Append("MAGE = " + this.MAGE.ToString());
				sb.Append(", ");
				sb.Append("MCOND = '" + this.MCOND.Text + "'");
				sb.Append(", ");
				sb.Append("MCLASS = '" + this.MCLASS.Text + "'");
				sb.Append(", ");
				sb.Append("MFACTR = " + this.MFACTR.ToString());
				sb.Append(", ");
				sb.Append("MDEPRC = " + this.MDEPRC.ToString());
				sb.Append(", ");
				sb.Append("MFOUND = " + this.MFOUND.ToString());
				sb.Append(", ");
				sb.Append("MEXWLL = " + this.MEXWLL.ToString());
				sb.Append(", ");
				sb.Append("MROOFT = " + this.MROOFT.ToString());
				sb.Append(", ");
				sb.Append("MROOFG = " + this.MROOFG.ToString());
				sb.Append(", ");
				sb.Append("M#DUNT = " + this.M_NUMDUNT.ToString());
				sb.Append(", ");
				sb.Append("M#ROOM = " + this.M_NUMROOM.ToString());
				sb.Append(", ");
				sb.Append("M#BR = " + this.M_NUMBR.ToString());
				sb.Append(", ");
				sb.Append("M#FBTH = " + this.M_NUMFBTH.ToString());
				sb.Append(", ");
				sb.Append("M#HBTH = " + this.M_NUMHBTH.ToString());
				sb.Append(", ");
				sb.Append("MFP2 = '" + this.MFP2.Text + "'");
				sb.Append(", ");
				sb.Append("MLTRCD = '" + this.MLTRCD.Text + "'");
				sb.Append(", ");
				sb.Append("MHEAT = " + this.MHEAT.ToString());
				sb.Append(", ");
				sb.Append("MFUEL = " + this.MFUEL.ToString());
				sb.Append(", ");
				sb.Append("MAC = '" + this.MAC.Text + "'");
				sb.Append(", ");
				sb.Append("MFP1 = '" + this.MFP1.Text + "'");
				sb.Append(", ");
				sb.Append("MCDR = '" + this.MCDR.Text + "'");
				sb.Append(", ");
				sb.Append("MEKIT = " + this.MEKIT.ToString());
				sb.Append(", ");
				sb.Append("MBASTP = " + this.MBASTP.ToString());
				sb.Append(", ");
				sb.Append("MPBTOT = " + this.MPBTOT.ToString());
				sb.Append(", ");
				sb.Append("MSBTOT = " + this.MSBTOT.ToString());
				sb.Append(", ");
				sb.Append("MPBFIN = " + this.MPBFIN.ToString());
				sb.Append(", ");
				sb.Append("MSBFIN = " + this.MSBFIN.ToString());
				sb.Append(", ");
				sb.Append("MBRATE = " + this.MBRATE.ToString());
				sb.Append(", ");
				sb.Append("M#FLUE = " + this.M_NUMFLUE.ToString());
				sb.Append(", ");
				sb.Append("MFLUTP = '" + this.MFLUTP.Text + "'");
				sb.Append(", ");
				sb.Append("MGART = " + this.MGART.ToString());
				sb.Append(", ");
				sb.Append("MGAR#C = " + this.MGAR_NUMC.ToString());
				sb.Append(", ");
				sb.Append("MCARPT = " + this.MCARPT.ToString());
				sb.Append(", ");
				sb.Append("MCAR#C = " + this.MCAR_NUMC.ToString());
				sb.Append(", ");
				sb.Append("MBI#C = " + this.MBI_NUMC.ToString());
				sb.Append(", ");
				sb.Append("MROW = " + this.MROW.ToString());
				sb.Append(", ");
				sb.Append("MEASE = " + this.MEASE.ToString());
				sb.Append(", ");
				sb.Append("MWATER = " + this.MWATER.ToString());
				sb.Append(", ");
				sb.Append("MSEWER = " + this.MSEWER.ToString());
				sb.Append(", ");
				sb.Append("MGAS = '" + this.MGAS.Text + "'");
				sb.Append(", ");
				sb.Append("MELEC = '" + this.MELEC.Text + "'");
				sb.Append(", ");
				sb.Append("MTERRN = " + this.MTERRN.ToString());
				sb.Append(", ");
				sb.Append("MCHAR = " + this.MCHAR.ToString());
				sb.Append(", ");
				sb.Append("MOTDES = '" + this.MOTDES.Text + "'");
				sb.Append(", ");
				sb.Append("MGART2 = " + this.MGART2.ToString());
				sb.Append(", ");
				sb.Append("MGAR#2 = " + this.MGAR_NUM2.ToString());
				sb.Append(", ");
				sb.Append("MDATLG = " + this.MDATLG.ToString());
				sb.Append(", ");
				sb.Append("MDATPR = " + this.MDATPR.ToString());
				sb.Append(", ");
				sb.Append("MINTYP = '" + this.MINTYP.Text + "'");
				sb.Append(", ");
				sb.Append("MINTYR = " + this.MINTYR.ToString());
				sb.Append(", ");
				sb.Append("MINNO# = " + this.MINNO_NUM.ToString());
				sb.Append(", ");
				sb.Append("MINNO2 = " + this.MINNO2.ToString());
				sb.Append(", ");
				sb.Append("MDSUFX = '" + this.MDSUFX.Text + "'");
				sb.Append(", ");
				sb.Append("MWSUFX = '" + this.MWSUFX.Text + "'");
				sb.Append(", ");
				sb.Append("MPSUFX = '" + this.MPSUFX.Text + "'");
				sb.Append(", ");
				sb.Append("MIMPRV = " + this.MIMPRV.ToString());
				sb.Append(", ");
				sb.Append("MTOTLD = " + this.MTOTLD.ToString());
				sb.Append(", ");
				sb.Append("MTOTOI = " + this.MTOTOI.ToString());
				sb.Append(", ");
				sb.Append("MTOTPR = " + this.MTOTPR.ToString());
				sb.Append(", ");
				sb.Append("MASSB = " + this.MASSB.ToString());
				sb.Append(", ");
				sb.Append("MACPCT = " + this.MACPCT.ToString());
				sb.Append(", ");
				sb.Append("M1FRNT = " + this.M1FRNT.ToString());
				sb.Append(", ");
				sb.Append("M1DPTH = " + this.M1DPTH.ToString());
				sb.Append(", ");
				sb.Append("M1AREA = " + this.M1AREA.ToString());
				sb.Append(", ");
				sb.Append("MMCODE = " + this.MMCODE.ToString());
				sb.Append(", ");
				sb.Append("M0DEPR = '" + this.M0DEPR.Text + "'");
				sb.Append(", ");
				sb.Append("M1UM = '" + this.M1UM.Text + "'");
				sb.Append(", ");
				sb.Append("M2FRNT = " + this.M2FRNT.ToString());
				sb.Append(", ");
				sb.Append("M2DPTH = " + this.M2DPTH.ToString());
				sb.Append(", ");
				sb.Append("M2AREA = " + this.M2AREA.ToString());
				sb.Append(", ");
				sb.Append("MZIPBR = " + this.MZIPBR.ToString());
				sb.Append(", ");
				sb.Append("MDELAY = '" + this.MDELAY.Text + "'");
				sb.Append(", ");
				sb.Append("M2UM = '" + this.M2UM.Text + "'");
				sb.Append(", ");
				sb.Append("MSTRT = '" + this.MSTRT.Text + "'");
				sb.Append(", ");
				sb.Append("MDIRCT = '" + this.MDIRCT.Text + "'");
				sb.Append(", ");
				sb.Append("MHSE# = " + this.MHSE_NUM.ToString());
				sb.Append(", ");
				sb.Append("MCDMO = " + this.MCDMO.ToString());
				sb.Append(", ");
				sb.Append("MCDDA = " + this.MCDDA.ToString());
				sb.Append(", ");
				sb.Append("MCDYR = " + this.MCDYR.ToString());
				sb.Append(", ");
				sb.Append("M1DFAC = " + this.M1DFAC.ToString());
				sb.Append(", ");
				sb.Append("MREM1 = '" + this.MREM1.Text + "'");
				sb.Append(", ");
				sb.Append("MREM2 = '" + this.MREM2.Text + "'");
				sb.Append(", ");
				sb.Append("MMAGCD = '" + this.MMAGCD.Text + "'");
				sb.Append(", ");
				sb.Append("MATHOM = '" + this.MATHOM.Text + "'");
				sb.Append(", ");
				sb.Append("MDESC1 = '" + this.MDESC1.Text + "'");
				sb.Append(", ");
				sb.Append("MDESC2 = '" + this.MDESC2.Text + "'");
				sb.Append(", ");
				sb.Append("MDESC3 = '" + this.MDESC3.Text + "'");
				sb.Append(", ");
				sb.Append("MDESC4 = '" + this.MDESC4.Text + "'");
				sb.Append(", ");
				sb.Append("MFAIRV = " + this.MFAIRV.ToString());
				sb.Append(", ");
				sb.Append("MLGITY = '" + this.MLGITY.Text + "'");
				sb.Append(", ");
				sb.Append("MLGIYR = " + this.MLGIYR.ToString());
				sb.Append(", ");
				sb.Append("MLGNO# = " + this.MLGNO_NUM.ToString());
				sb.Append(", ");
				sb.Append("MLGNO2 = " + this.MLGNO2.ToString());
				sb.Append(", ");
				sb.Append("MSUBDV = '" + this.MSUBDV.Text + "'");
				sb.Append(", ");
				sb.Append("MSELLP = " + this.MSELLP.ToString());
				sb.Append(", ");
				sb.Append("M2DFAC = " + this.M2DFAC.ToString());
				sb.Append(", ");
				sb.Append("MINIT = '" + this.MINIT.Text + "'");
				sb.Append(", ");
				sb.Append("MINSPD = " + this.MINSPD.ToString());
				sb.Append(", ");
				sb.Append("MSWL = " + this.MSWL.ToString());
				sb.Append(", ");
				sb.Append("MTUTIL = " + this.MTUTIL.ToString());
				sb.Append(", ");
				sb.Append("MNBADJ = " + this.MNBADJ.ToString());
				sb.Append(", ");
				sb.Append("MASSL = " + this.MASSL.ToString());
				sb.Append(", ");
				sb.Append("MACSF = " + this.MACSF.ToString());
				sb.Append(", ");
				sb.Append("MCOMM1 = '" + this.MCOMM1.Text + "'");
				sb.Append(", ");
				sb.Append("MCOMM2 = '" + this.MCOMM2.Text + "'");
				sb.Append(", ");
				sb.Append("MCOMM3 = '" + this.MCOMM3.Text + "'");
				sb.Append(", ");
				sb.Append("MACCT = " + this.MACCT.ToString());
				sb.Append(", ");
				sb.Append("MEXWL2 = " + this.MEXWL2.ToString());
				sb.Append(", ");
				sb.Append("MCALC = '" + this.MCALC.Text + "'");
				sb.Append(", ");
				sb.Append("MFILL4 = '" + this.MFILL4.Text + "'");
				sb.Append(", ");
				sb.Append("MTBV = " + this.MTBV.ToString());
				sb.Append(", ");
				sb.Append("MTBAS = " + this.MTBAS.ToString());
				sb.Append(", ");
				sb.Append("MTFBAS = " + this.MTFBAS.ToString());
				sb.Append(", ");
				sb.Append("MTPLUM = " + this.MTPLUM.ToString());
				sb.Append(", ");
				sb.Append("MTHEAT = " + this.MTHEAT.ToString());
				sb.Append(", ");
				sb.Append("MTAC = " + this.MTAC.ToString());
				sb.Append(", ");
				sb.Append("MTFP = " + this.MTFP.ToString());
				sb.Append(", ");
				sb.Append("MTFL = " + this.MTFL.ToString());
				sb.Append(", ");
				sb.Append("MTBI = " + this.MTBI.ToString());
				sb.Append(", ");
				sb.Append("MTTADD = " + this.MTTADD.ToString());
				sb.Append(", ");
				sb.Append("MTSUBT = " + this.MTSUBT.ToString());
				sb.Append(", ");
				sb.Append("MTOTBV = " + this.MTOTBV.ToString());
				sb.Append(", ");
				sb.Append("MUSRID = '" + this.MUSRID.Text + "'");
				sb.Append(", ");
				sb.Append("MBASA = " + this.MBASA.ToString());
				sb.Append(", ");
				sb.Append("MTOTA = " + this.MTOTA.ToString());
				sb.Append(", ");
				sb.Append("MPSF = " + this.MPSF.ToString());
				sb.Append(", ");
				sb.Append("MINWLL = '" + this.MINWLL.Text + "'");
				sb.Append(", ");
				sb.Append("MFLOOR = '" + this.MFLOOR.Text + "'");
				sb.Append(", ");
				sb.Append("MYRBLT = " + this.MYRBLT.ToString());
				sb.Append(", ");
				sb.Append("MCNST1 = '" + this.MCNST1.Text + "'");
				sb.Append(", ");
				sb.Append("MCNST2 = '" + this.MCNST2.Text + "'");
				sb.Append(", ");
				sb.Append("MASSLU = " + this.MASSLU.ToString());
				sb.Append(", ");
				sb.Append("MMOSLD = " + this.MMOSLD.ToString());
				sb.Append(", ");
				sb.Append("MDASLD = " + this.MDASLD.ToString());
				sb.Append(", ");
				sb.Append("MYRSLD = " + this.MYRSLD.ToString());
				sb.Append(", ");
				sb.Append("MTIME = " + this.MTIME.ToString());
				sb.Append(", ");
				sb.Append("MHSE#2 = '" + this.MHSE_NUM2.Text + "'");
				sb.Append(", ");
				sb.Append("M1ADJ = " + this.M1ADJ.ToString());
				sb.Append(", ");
				sb.Append("M2ADJ = " + this.M2ADJ.ToString());
				sb.Append(", ");
				sb.Append("MLGBKC = '" + this.MLGBKC.Text + "'");
				sb.Append(", ");
				sb.Append("MLGBK# = '" + this.MLGBK_NUM.Text + "'");
				sb.Append(", ");
				sb.Append("MLGPG# = " + this.MLGPG_NUM.ToString());
				sb.Append(", ");
				sb.Append("MEFFAG = " + this.MEFFAG.ToString());
				sb.Append(", ");
				sb.Append("MPCOMP = " + this.MPCOMP.ToString());
				sb.Append(", ");
				sb.Append("MSTTYP = '" + this.MSTTYP.Text + "'");
				sb.Append(", ");
				sb.Append("MSDIRS = '" + this.MSDIRS.Text + "'");
				sb.Append(", ");
				sb.Append("M1RATE = " + this.M1RATE.ToString());
				sb.Append(", ");
				sb.Append("M2RATE = " + this.M2RATE.ToString());
				sb.Append(", ");
				sb.Append("MFUNCD = " + this.MFUNCD.ToString());
				sb.Append(", ");
				sb.Append("MECOND = " + this.MECOND.ToString());
				sb.Append(", ");
				sb.Append("MNBRHD = " + this.MNBRHD.ToString());
				sb.Append(", ");
				sb.Append("MUSER1 = '" + this.MUSER1.Text + "'");
				sb.Append(", ");
				sb.Append("MUSER2 = '" + this.MUSER2.Text + "'");
				sb.Append(", ");
				sb.Append("MDBOOK = '" + this.MDBOOK.Text + "'");
				sb.Append(", ");
				sb.Append("MDPAGE = " + this.MDPAGE.ToString());
				sb.Append(", ");
				sb.Append("MWBOOK = '" + this.MWBOOK.Text + "'");
				sb.Append(", ");
				sb.Append("MWPAGE = " + this.MWPAGE.ToString());
				sb.Append(", ");
				sb.Append("MDCODE = '" + this.MDCODE.Text + "'");
				sb.Append(", ");
				sb.Append("MWCODE = '" + this.MWCODE.Text + "'");
				sb.Append(", ");
				sb.Append("MMORTC = " + this.MMORTC.ToString());
				sb.Append(", ");
				sb.Append("MFILL7 = '" + this.MFILL7.Text + "'");
				sb.Append(", ");
				sb.Append("MACRE# = " + this.MACRE_NUM.ToString());
				sb.Append(", ");
				sb.Append("MGISPN = '" + this.MGISPN.Text + "'");
				sb.Append(", ");
				sb.Append("MUSER3 = '" + this.MUSER3.Text + "'");
				sb.Append(", ");
				sb.Append("MUSER4 = '" + this.MUSER4.Text + "'");
				sb.Append(", ");
				sb.Append("MIMADJ = " + this.MIMADJ.ToString());
				sb.Append(", ");
				sb.Append("MCDRDT = " + this.MCDRDT.ToString());
				sb.Append(", ");
				sb.Append("MMNUD = " + this.MMNUD.ToString());
				sb.Append(", ");
				sb.Append("MMNNUD = " + this.MMNNUD.ToString());
				sb.Append(", ");
				sb.Append("MSS1 = " + this.MSS1.ToString());
				sb.Append(", ");
				sb.Append("MPCODE = '" + this.MPCODE.Text + "'");
				sb.Append(", ");
				sb.Append("MPBOOK = '" + this.MPBOOK.Text + "'");
				sb.Append(", ");
				sb.Append("MPPAGE = " + this.MPPAGE.ToString());
				sb.Append(", ");
				sb.Append("MSS2 = " + this.MSS2.ToString());
				sb.Append(", ");
				sb.Append("MASSM = " + this.MASSM.ToString());
				sb.Append(", ");
				sb.Append("MFILL9 = '" + this.MFILL9.Text + "'");
				sb.Append(", ");
				sb.Append("MGRNTR = '" + this.MGRNTR.Text + "'");
				sb.Append(", ");
				sb.Append("MCVMO = " + this.MCVMO.ToString());
				sb.Append(", ");
				sb.Append("MCVDA = " + this.MCVDA.ToString());
				sb.Append(", ");
				sb.Append("MCVYR = " + this.MCVYR.ToString());
				sb.Append(", ");
				sb.Append("MPROUT = '" + this.MPROUT.Text + "'");
				sb.Append(", ");
				sb.Append("MPERR = '" + this.MPERR.Text + "'");
				sb.Append(", ");
				sb.Append("MTBIMP = " + this.MTBIMP.ToString());
				sb.Append(", ");
				sb.Append("MPUSE = " + this.MPUSE.ToString());
				sb.Append(", ");
				sb.Append("MCVEXP = '" + this.MCVEXP.Text + "'");
				sb.Append(", ");
				sb.Append("METXYR = " + this.METXYR.ToString());
				sb.Append(", ");
				sb.Append("MQAPCH = " + this.MQAPCH.ToString());
				sb.Append(", ");
				sb.Append("MQAFIL = '" + this.MQAFIL.Text + "'");
				sb.Append(", ");
				sb.Append("MPICT = '" + this.MPICT.Text + "'");
				sb.Append(", ");
				sb.Append("MEACRE = " + this.MEACRE.ToString());
				sb.Append(", ");
				sb.Append("MPRCIT = '" + this.MPRCIT.Text + "'");
				sb.Append(", ");
				sb.Append("MPRSTA = '" + this.MPRSTA.Text + "'");
				sb.Append(", ");
				sb.Append("MPRZP1 = " + this.MPRZP1.ToString());
				sb.Append(", ");
				sb.Append("MPRZP4 = '" + this.MPRZP4.Text + "'");
				sb.Append(", ");
				sb.Append("MFP# = " + this.MFP_NUM.ToString());
				sb.Append(", ");
				sb.Append("MSFP# = " + this.MSFP_NUM.ToString());
				sb.Append(", ");
				sb.Append("MFL# = " + this.MFL_NUM.ToString());
				sb.Append(", ");
				sb.Append("MSFL# = " + this.MSFL_NUM.ToString());
				sb.Append(", ");
				sb.Append("MMFL# = " + this.MMFL_NUM.ToString());
				sb.Append(", ");
				sb.Append("MIOFP# = " + this.MIOFP_NUM.ToString());
				sb.Append(", ");
				sb.Append("MSTOR# = " + this.MSTOR_NUM.ToString());
				sb.Append(", ");
				sb.Append("MASCOM = '" + this.MASCOM.Text + "'");
				sb.Append(", ");
				sb.Append("MHRPH# = " + this.MHRPH_NUM.ToString());
				sb.Append(", ");
				sb.Append("MHRDAT = " + this.MHRDAT.ToString());
				sb.Append(", ");
				sb.Append("MHRTIM = " + this.MHRTIM.ToString());
				sb.Append(", ");
				sb.Append("MHRNAM = '" + this.MHRNAM.Text + "'");
				sb.Append(", ");
				sb.Append("MHRSES = '" + this.MHRSES.Text + "'");
				sb.Append(", ");
				sb.Append("MHIDPC = '" + this.MHIDPC.Text + "'");
				sb.Append(", ");
				sb.Append("MHIDNM = '" + this.MHIDNM.Text + "'");
				sb.Append(", ");
				sb.Append("MCAMO = " + this.MCAMO.ToString());
				sb.Append(", ");
				sb.Append("MCADA = " + this.MCADA.ToString());
				sb.Append(", ");
				sb.Append("MCAYR = " + this.MCAYR.ToString());
				sb.Append(", ");
				sb.Append("MOLDOC = " + this.MOLDOC.ToString());

				sb.Append(this.WhereClause);

				string cmd = sb.ToString();
				rowCount = this.db.ExecuteNonSelectStatement(cmd);
			}
			catch (System.Exception ex)
			{
				this.lastException = ex;
				Console.WriteLine(string.Format("Error: {0}", ex.Message));
			}
			return rowCount;
		}

		/// <summary>
		/// Sets Occupancy = 30 for all records
		/// with the current key settings.
		/// </summary>
		///<returns>The number of rows deleted.</returns>
		public int delete()
		{
			this.MOCCUP.setValue(30);
			return this.update();
		}

		/// <summary>
		/// Deletes from the database table all records
		/// with the current key settings.
		/// </summary>
		///<returns>The number of rows deleted.</returns>
		public int deleteForReal()
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
				Console.WriteLine(string.Format("Error: {0}", ex.Message));
			}
			return rowCount;
		}

		#endregion Public Methods

		#region Private Methods

		#endregion Private Methods
	}
}