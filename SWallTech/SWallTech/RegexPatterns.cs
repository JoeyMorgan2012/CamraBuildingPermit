using System;
using System.Text;

namespace SWallTech
{
	public static class RegexPatterns
	{
		/// <summary>
		/// A pattern for IP Addresses.
		/// </summary>
		//public static readonly string IPAddressRegexPattern = @"((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)" ;
		public static readonly string IPAddressRegexPattern = @"\b(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b";

		public static readonly string SimpleIPAddress = @"(\d{3}.){3}(\d{3})";

		/// <summary>
		/// A pattern for US Telephone Numbers.
		/// </summary>
		public static readonly string USPhoneNumber = @"^(?:1[- .]?)?\(?\d{3}\)?[- .]?\d{3}[- .]?\d{4}$";

		/// <summary>
		/// A pattern for US Currency requiring the leading dollar sign. Allows 0 or 1 space between the dollar sign and the value.
		/// Example: either "$123.45" or "$ 123.45" will validate.
		/// </summary>
		public static readonly string USCurrencyDollarSignRequired = @"^\$[ ]?\d+\.\d\d$";

		/// <summary>
		/// A pattern for US Currency with an optional leading dollar sign. Allows 0 or 1 space between the dollar sign and the value.
		/// Example: either "$123.45", "$ 123.45", or "123.45" will validate.
		/// </summary>
		public static readonly string USCurrencyDollarSignOptional = @"^\$?[ ]?\d+\.\d\d$";

		/// <summary>
		/// A pattern for US Currency without the leading dollar sign.
		/// Example: "123.45" will validate.
		/// </summary>
		public static readonly string USCurrencyNoDollarSign = @"^\d+\.\d\d$";

		/// <summary>
		/// A pattern for US Social Security Numbers. Ensures validity as well as format (999-99-9999 is well formed, but not valid).
		/// </summary>
		public static readonly string USSocialSecurityNumber = @"^(00[1-9]|0[1-9]\d|[1-5]\d{2}|6[0-5]\d|66[0-5]|66[7-9]|6[7-8]\d|690|7[0-2]\d|73[0-3]|750|76[4-9]|77[0-2])-(?!00)\d{2}-(?!0000)\d{4}$";

		/// <summary>
		/// A pattern for EMail Addresses.  Pretty good RFC 2822 support.  Original source: http://regexlib.com/REDetails.aspx?regexp_id=711
		/// </summary>
		public static readonly string EMailAddress = @"^((?>[a-zA-Z\d!#$%&'*+\-/=?^_`{|}~]+\x20*|""((?=[\x01-\x7f])[^""\\]|\\[\x01-\x7f])*""\x20*)*(?<angle><))?((?!\.)(?>\.?[a-zA-Z\d!#$%&'*+\-/=?^_`{|}~]+)+|""((?=[\x01-\x7f])[^""\\]|\\[\x01-\x7f])*"")@(((?!-)[a-zA-Z\d\-]+(?<!-)\.)+[a-zA-Z]{2,}|\[(((?(?<!\[)\.)(25[0-5]|2[0-4]\d|[01]?\d?\d)){4}|[a-zA-Z\d\-]*[a-zA-Z\d]:((?=[\x01-\x7f])[^\\\[\]]|\\[\x01-\x7f])+)\])(?(angle)>)$";

		/// <summary>
		/// A pattern for Uniform Resource Locaters, requires protocol. Supports http, https, ftp, file, gopher, news, nntp, telnet, ftps, and sftp protocols.
		/// </summary>
		public static readonly string UrlRequiresProtocol = @"^(?:(?:file|gopher|news|nntp|telnet|http|ftp|https|ftps|sftp|File|Gopher|News|Nntp|Telnet|Http|Ftp|Https|Ftps|Sftp|FILE|GOPHER|NEWS|NNTP|TELNET|HTTP|FTP|HTTPS|FTPS|SFTP)s?):\/\/(?:[A-z0-9][A-z0-9]+\.)+[A-z]{2,4}$";

		/// <summary>
		/// A pattern for Uniform Resource Locaters, optional protocol. Supports http, https, ftp, file, gopher, news, nntp, telnet, ftps, and sftp protocols.
		/// </summary>
		public static readonly string UrlOptionalProtocol = @"^(?:(?:(?:file|gopher|news|nntp|telnet|http|ftp|https|ftps|sftp|File|Gopher|News|Nntp|Telnet|Http|Ftp|Https|Ftps|Sftp|FILE|GOPHER|NEWS|NNTP|TELNET|HTTP|FTP|HTTPS|FTPS|SFTP)s?):\/\/)?(?:[A-z0-9][A-z0-9]+\.)+[A-z]{2,4}$";

		/// <summary>
		/// A pattern for Uniform Resource Locaters, no protocol.
		/// </summary>
		public static readonly string UrlNoProtocol = @"^(?:[A-z0-9][A-z0-9]+\.)+[A-z]{2,4}$";

		/// <summary>
		/// A pattern for positive integers only
		/// </summary>
		public static readonly string NonNegativeInteger = @"^\d+$";

		/// <summary>
		/// A pattern for positive or negative integers
		/// </summary>
		public static readonly string AllowNegativeInteger = @"^-?\d+$";

		/// <summary>
		/// A pattern for negative integers only
		/// </summary>
		public static readonly string ForceNegativeInteger = @"^-\d+$";

		/// <summary>
		/// A pattern for positive decimal entry requiring the decimal and at least one digit after
		/// </summary>
		public static readonly string NonNegativeDecimalRequired = @"^\d*[.]\d+$";

		/// <summary>
		/// A pattern for positive or negative decimal entry requiring the decimal and at least one digit after
		/// </summary>
		public static readonly string AllowNegativeDecimalRequired = @"^-?\d*[.]\d+$";

		/// <summary>
		/// A pattern for negative decimal entry requiring the decimal and at least one digit after
		/// </summary>
		public static readonly string ForceNegativeDecimalRequired = @"^-\d*[.]\d+$";

		/// <summary>
		/// A pattern for positive decimal entry that does not require the decimal point
		/// </summary>
		public static readonly string NonNegativeDecimalOptional = @"^[0-9]*\.?[0-9]*$";

		/// <summary>
		/// A pattern for positive or negative decimal entry that does not require the decimal point
		/// </summary>
		public static readonly string AllowNegativeDecimalOptional = @"^-?[0-9]*\.?[0-9]*$";

		/// <summary>
		/// A pattern for negative decimal entry that does not require the decimal point
		/// </summary>
		public static readonly string ForceNegativeDecimalOptional = @"^-[0-9]*\.?[0-9]*$";
	}
}