using System;
using System.Text;
using System.Text.RegularExpressions;

namespace SWallTech
{
	/// <summary>
	/// NumberFormatter is a class for formatting numeric output as strings.  It includes
	/// standard USA formats such as SSN and PhoneNumber, as well as the IBM list of
	/// EditCodes.
	/// </summary>
	public class NumberFormatter
	{
		/// <summary>
		/// An enumeration representing the standard IBM Edit Codes.
		/// </summary>
		/// <remarks>
		/// <para>For many years, Edit Codes have provided a simple way of formatting numeric strings on IBM's
		/// midrange family of servers (S/36, AS/400, iSeries, i5/OS, etc).  Now edit codes can be applied
		/// in .Net by using the SWallTech.NumberFormatter.IBMEditCodes enumeration.
		/// </para>
		/// </remarks>
		public enum IBMEditCodes
		{
			/// <summary>
			/// Show Commas, Show If Zero, Negative Sign (None)
			/// </summary>
			One,

			/// <summary>
			/// Show Commas, Do Not Show If Zero, Negative Sign (None)
			/// </summary>
			Two,

			/// <summary>
			/// Do Not Show Commas, Show If Zero, Negative Sign (None)
			/// </summary>
			Three,

			/// <summary>
			/// Do Not Show Commas, Do Not Show If Zero, Negative Sign (None)
			/// </summary>
			Four,

			/// <summary>
			/// Show Commas, Show If Zero, Negative Sign (CR)
			/// </summary>
			A,

			/// <summary>
			/// Show Commas, Do Not Show If Zero, Negative Sign (CR)
			/// </summary>
			B,

			/// <summary>
			/// Do Not Show Commas, Show If Zero, Negative Sign (CR)
			/// </summary>
			C,

			/// <summary>
			/// Do Not Show Commas, Do Not Show If Zero, Negative Sign (CR)
			/// </summary>
			D,

			/// <summary>
			/// Show Commas, Show If Zero, Negative Sign (- after)
			/// </summary>
			J,

			/// <summary>
			/// Show Commas, Do Not Show If Zero, Negative Sign (- after)
			/// </summary>
			K,

			/// <summary>
			/// Do Not Show Commas, Show If Zero, Negative Sign (- after)
			/// </summary>
			L,

			/// <summary>
			/// Do Not Show Commas, Do Not Show If Zero, Negative Sign (- after)
			/// </summary>
			M,

			/// <summary>
			/// Show Commas, Show If Zero, Negative Sign (- before)
			/// </summary>
			N,

			/// <summary>
			/// Show Commas, Do Not Show If Zero, Negative Sign (- before)
			/// </summary>
			O,

			/// <summary>
			/// Do Not Show Commas, Show If Zero, Negative Sign (- before)
			/// </summary>
			P,

			/// <summary>
			/// Do Not Show Commas, Do Not Show If Zero, Negative Sign (- before)
			/// </summary>
			Q,

			/// <summary>
			/// Do Not Show Commas, Show If Zero, Negative Sign (None)
			/// </summary>
			X,

			/// <summary>
			/// Do Not Show Commas, Do Not Show If Zero, Negative Sign (None)
			/// </summary>
			Z
		};

		private NumberFormatter()
		{
		}

		/// <summary>
		/// Formats a number as a US Social Security Number string.
		/// </summary>
		/// <remarks>If the length of the number sent is not equal to 9, then no formatting occurs.</remarks>
		/// <param name="num">The number to format.</param>
		/// <returns>The formatted string.</returns>
		public static string SSN(int num)
		{
			string s = num.ToString();
			if (!Regex.IsMatch(s, RegexPatterns.USSocialSecurityNumber))
			{
				throw new FormatException("Number is not a valid US Social Security number.");
			}
			else
			{
				if (s.Length == 7)
				{
					s = "00" + s;
				}
				else if (s.Length == 8)
				{
					s = "0" + s;
				}
				s = num.ToString("###-##-####");
			}
			return s;
		}

		/// <summary>
		/// Formats a number as a US 10 digit Phone Number string.
		/// </summary>
		/// <remarks>If the length of the number sent is not equal to 10, then no formatting occurs.
		/// Do not include the leading "1".</remarks>
		/// <param name="num">The number to format.</param>
		/// <returns>The formatted string.</returns>
		public static string PhoneNumber(long num)
		{
			string s = num.ToString();
			if (!Regex.IsMatch(s, RegexPatterns.USPhoneNumber))
			{
				throw new FormatException("Number is not a valid US Phone number.");
			}
			else
			{
				if (s.Length == 11 && s.Substring(0) == "1")
				{
					s = s.Substring(1);
					long l = Convert.ToInt64(s);
					s = l.ToString("(###)###-####");
				}
				else if (s.Length == 10)
				{
					s = num.ToString("(###)###-####");
				}
				else if (s.Length == 7)
				{
					s = num.ToString("###-####");
				}
				else
				{
					throw new FormatException("Number is not a valid US Social Security number.");
				}
			}
			return s;
		}

		/// <summary>
		/// Formats a number as a US 5 digit zip code string.
		/// </summary>
		/// <remarks>If the length of the number sent is greater than 5, then no formatting occurs.
		/// Should the zip code have a leading zero, then the zero will properly display.</remarks>
		/// <param name="num">The number to format.</param>
		/// <returns>The formatted string.</returns>
		public static string ZipCode(int num)
		{
			string s = num.ToString();
			if (s.Length <= 5)
			{
				while (s.Length < 5)
				{
					s = "0" + s;
				}
			}
			return s;
		}

		/// <summary>
		/// Formats a number as a US 9 digit long zip code string.
		/// </summary>
		/// <remarks>If the length of the number sent is NOT greater than 5, then no formatting occurs.
		/// Should the zip code have a leading zero, then the zero will properly display.
		/// This methods also inserts a hyphen between the Zip Code and the Zip+4.</remarks>
		/// <param name="num">The number to format.</param>
		/// <returns>The formatted string.</returns>
		public static string ZipCodeLong(int num)
		{
			string s = num.ToString();
			if (s.Length > 5)
			{
				while (s.Length < 9)
				{
					s = "0" + s;
				}
				s = s.Insert(5, "-");
			}
			return s;
		}

		/// <summary>
		/// Formats a number as a string based on IBM Edit Codes.
		/// </summary>
		/// <remarks>
		/// <para>For many years, Edit Codes have provided a simple way of formatting numeric strings on IBM's
		/// midrange family of servers (S/36, AS/400, iSeries, i5/OS, etc).  Now edit codes can be applied
		/// in .Net by using the SWallTech.NumberFormatter class and its methods.
		/// </para>
		/// <para>The following Edit Codes are supported:
		/// <list type="table">
		/// <listheader><term>Edit Code</term><description>Implementation Details</description></listheader>
		/// <item><term>'1'</term><description>Show Commas, Show If Zero, Negative Sign (None)</description></item>
		/// <item><term>'2'</term><description>Show Commas, Do Not Show If Zero, Negative Sign (None)</description></item>
		/// <item><term>'3'</term><description>Do Not Show Commas, Show If Zero, Negative Sign (None)</description></item>
		/// <item><term>'4'</term><description>Do Not Show Commas, Do Not Show If Zero, Negative Sign (None)</description></item>
		/// <item><term>'A'</term><description>Show Commas, Show If Zero, Negative Sign (CR)</description></item>
		/// <item><term>'B'</term><description>Show Commas, Do Not Show If Zero, Negative Sign (CR)</description></item>
		/// <item><term>'C'</term><description>Do Not Show Commas, Show If Zero, Negative Sign (CR)</description></item>
		/// <item><term>'D'</term><description>Do Not Show Commas, Do Not Show If Zero, Negative Sign (CR)</description></item>
		/// <item><term>'J'</term><description>Show Commas, Show If Zero, Negative Sign (- after)</description></item>
		/// <item><term>'K'</term><description>Show Commas, Do Not Show If Zero, Negative Sign (- after)</description></item>
		/// <item><term>'L'</term><description>Do Not Show Commas, Show If Zero, Negative Sign (- after)</description></item>
		/// <item><term>'M'</term><description>Do Not Show Commas, Do Not Show If Zero, Negative Sign (- after)</description></item>
		/// <item><term>'N'</term><description>Show Commas, Show If Zero, Negative Sign (- before)</description></item>
		/// <item><term>'O'</term><description>Show Commas, Do Not Show If Zero, Negative Sign (- before)</description></item>
		/// <item><term>'P'</term><description>Do Not Show Commas, Show If Zero, Negative Sign (- before)</description></item>
		/// <item><term>'Q'</term><description>Do Not Show Commas, Do Not Show If Zero, Negative Sign (- before)</description></item>
		/// <item><term>'X'</term><description>Do Not Show Commas, Show If Zero, Negative Sign (None)</description></item>
		/// <item><term>'Z'</term><description>Do Not Show Commas, Do Not Show If Zero, Negative Sign (None)</description></item>
		/// </list>
		/// </para>
		/// <example>
		/// <code>
		/// FixedDecimal myFD = new FixedDecimal( 7,2 );
		/// myFD.setValue( -1234.56 );
		/// string format = NumberFormatter.EditCode( myFD , '1' );
		/// // format now contains "1,234.56"
		/// string format = NumberFormatter.EditCode( myFD , 'A' );
		/// // format now contains "1,234.56CR"
		/// format = NumberFormatter.EditCode( myFD , 'J' );
		/// // format now contains "1,234.56-"
		/// format = NumberFormatter.EditCode( myFD , 'Q' );
		/// // format now contains "-1234.56"
		/// format = NumberFormatter.EditCode( myFD , 'X' );
		/// // format now contains "0123456"
		/// </code>
		/// </example>
		/// <para>A more complete description of Edit Codes is available from IBM.</para>
		/// </remarks>
		/// <param name="num">The number to be formatted.</param>
		/// <param name="code">The IBMEditCode enumeration to apply to the number.</param>
		/// <returns>The formatted string.</returns>
		public static string EditCode(FixedDecimal num, IBMEditCodes code)
		{
			return EditCode(num, GetEditCodeValue(code));
		}

		/// <summary>
		/// Formats a number as a string based on IBM Edit Codes.
		/// </summary>
		/// <remarks>
		/// <para>For many years, Edit Codes have provided a simple way of formatting numeric strings on IBM's
		/// midrange family of servers (S/36, AS/400, iSeries, i5/OS, etc).  Now edit codes can be applied
		/// in .Net by using the SWallTech.FixedDecimal class.
		/// </para>
		/// <para>The following Edit Codes are supported:
		/// <list type="table">
		/// <listheader><term>Edit Code</term><description>Implementation Details</description></listheader>
		/// <item><term>'1'</term><description>Show Commas, Show If Zero, Negative Sign (None)</description></item>
		/// <item><term>'2'</term><description>Show Commas, Do Not Show If Zero, Negative Sign (None)</description></item>
		/// <item><term>'3'</term><description>Do Not Show Commas, Show If Zero, Negative Sign (None)</description></item>
		/// <item><term>'4'</term><description>Do Not Show Commas, Do Not Show If Zero, Negative Sign (None)</description></item>
		/// <item><term>'A'</term><description>Show Commas, Show If Zero, Negative Sign (CR)</description></item>
		/// <item><term>'B'</term><description>Show Commas, Do Not Show If Zero, Negative Sign (CR)</description></item>
		/// <item><term>'C'</term><description>Do Not Show Commas, Show If Zero, Negative Sign (CR)</description></item>
		/// <item><term>'D'</term><description>Do Not Show Commas, Do Not Show If Zero, Negative Sign (CR)</description></item>
		/// <item><term>'J'</term><description>Show Commas, Show If Zero, Negative Sign (- after)</description></item>
		/// <item><term>'K'</term><description>Show Commas, Do Not Show If Zero, Negative Sign (- after)</description></item>
		/// <item><term>'L'</term><description>Do Not Show Commas, Show If Zero, Negative Sign (- after)</description></item>
		/// <item><term>'M'</term><description>Do Not Show Commas, Do Not Show If Zero, Negative Sign (- after)</description></item>
		/// <item><term>'N'</term><description>Show Commas, Show If Zero, Negative Sign (- before)</description></item>
		/// <item><term>'O'</term><description>Show Commas, Do Not Show If Zero, Negative Sign (- before)</description></item>
		/// <item><term>'P'</term><description>Do Not Show Commas, Show If Zero, Negative Sign (- before)</description></item>
		/// <item><term>'Q'</term><description>Do Not Show Commas, Do Not Show If Zero, Negative Sign (- before)</description></item>
		/// <item><term>'X'</term><description>Do Not Show Commas, Show If Zero, Negative Sign (None)</description></item>
		/// <item><term>'Z'</term><description>Do Not Show Commas, Do Not Show If Zero, Negative Sign (None)</description></item>
		/// </list>
		/// </para>
		/// <example>
		/// <code>
		/// FixedDecimal myFD = new FixedDecimal( 7,2 );
		/// myFD.setValue( -1234.56 );
		/// string format = NumberFormatter.EditCode( myFD , '1' );
		/// // format now contains "1,234.56"
		/// string format = NumberFormatter.EditCode( myFD , 'A' );
		/// // format now contains "1,234.56CR"
		/// format = NumberFormatter.EditCode( myFD , 'J' );
		/// // format now contains "1,234.56-"
		/// format = NumberFormatter.EditCode( myFD , 'Q' );
		/// // format now contains "-1234.56"
		/// format = NumberFormatter.EditCode( myFD , 'X' );
		/// // format now contains "0123456"
		/// </code>
		/// </example>
		/// <para>A more complete description of Edit Codes is available from IBM.</para>
		/// </remarks>
		/// <param name="num">The number to be formatted.</param>
		/// <param name="code">The Edit Code to apply to the number.</param>
		/// <returns>The formatted string.</returns>
		public static string EditCode(FixedDecimal num, char code)
		{
			string s;
			string codeS = code.ToString().ToUpper();
			char c = Convert.ToChar(codeS);

			if (c == 'X')
			{
				s = num.toString(true, true);
				if (num.Number < 0)
				{
					s = s.Remove(s.IndexOf("-"), 1);
				}
				int dPos = s.IndexOf(".");
				if (dPos > -1)
				{
					s = s.Remove(dPos, 1);
				}
			}
			else if (c == 'Z')
			{
				if (num.Number == 0)
				{
					s = "";
				}
				else
				{
					s = num.toString(false, true);
					if (num.Number < 0)
					{
						s = s.Remove(s.IndexOf("-"), 1);
					}
					if (num.Value > -1 && num.Value < 1)
					{
						s = s.Substring(1);
					}
					int dPos = s.IndexOf(".");
					if (dPos > -1)
					{
						s = s.Remove(dPos, 1);
					}
				}
			}
			else
			{
				s = num.toString(false, true);
				if (num.Number < 0)
				{
					s = s.Remove(s.IndexOf("-"), 1);
				}

				switch (c)
				{
					case '1':
						s = commaFill(s);
						break;

					case '2':
						if (num.Number == 0)
						{
							s = "";
						}
						else
						{
							s = commaFill(s);
						}
						break;

					case '3':
						break;

					case '4':
						if (num.Number == 0)
						{
							s = "";
						}
						else
						{
						}
						break;

					case 'A':
						s = commaFill(s);
						if (num.Number < 0)
						{
							s += "CR";
						}
						break;

					case 'B':
						if (num.Number == 0)
						{
							s = "";
						}
						else
						{
							s = commaFill(s);
							if (num.Number < 0)
							{
								s += "CR";
							}
						}
						break;

					case 'C':
						if (num.Number < 0)
						{
							s += "CR";
						}
						break;

					case 'D':
						if (num.Number == 0)
						{
							s = "";
						}
						else
						{
							if (num.Number < 0)
							{
								s += "CR";
							}
						}
						break;

					case 'J':
						s = commaFill(s);
						if (num.Number < 0)
						{
							s += "-";
						}
						break;

					case 'K':
						if (num.Number == 0)
						{
							s = "";
						}
						else
						{
							s = commaFill(s);
							if (num.Number < 0)
							{
								s += "-";
							}
						}
						break;

					case 'L':
						if (num.Number < 0)
						{
							s += "-";
						}
						break;

					case 'M':
						if (num.Number == 0)
						{
							s = "";
						}
						else
						{
							if (num.Number < 0)
							{
								s += "-";
							}
						}
						break;

					case 'N':
						s = commaFill(s);
						if (num.Number < 0)
						{
							s = "-" + s;
						}
						break;

					case 'O':
						if (num.Number == 0)
						{
							s = "";
						}
						else
						{
							s = commaFill(s);
							if (num.Number < 0)
							{
								s = "-" + s;
							}
						}
						break;

					case 'P':
						if (num.Number < 0)
						{
							s = "-" + s;
						}
						break;

					case 'Q':
						if (num.Number == 0)
						{
							s = "";
						}
						else
						{
							if (num.Number < 0)
							{
								s = "-" + s;
							}
						}
						break;

					default:
						break;
				}
			}

			return s;
		}

		private static string commaFill(string s2)
		{
			string[] parts = s2.Split(new char[] { '.' });
			string left = parts[0];
			int occ = left.Length / 3;
			if ((left.Length % 3) == 0)
			{
				occ--;
			}
			char[] ca = new char[left.Length + occ];
			int j = 0;
			sbyte b = 0;
			for (int i = left.Length - 1; i >= 0; i--)
			{
				ca[j] = Convert.ToChar(left.Substring(i, 1));
				j++;
				b++;
				if (b == 3 && i > 0)
				{
					ca[j] = ',';
					j++;
					b = 0;
				}
			}

			StringBuilder res = new StringBuilder();
			foreach (char c in ca)
			{
				res.Insert(0, c);
			}
			if (parts.Length == 2)
			{
				res.Append('.');
				res.Append(parts[1]);
			}

			string s3 = res.ToString();
			return s3;
		}

		/// <summary>
		/// Zero fills and right adjusts a number, returning it as a string.
		/// <example>
		/// int i = 1234;
		/// string s = ZeroFill(i, 7);
		/// // value of s is "0001234"
		/// </example>
		/// Throws an InvalidOperationException if the value of Number is not a valid numeric value.
		/// Throws a FormatException is the length is too short for the value of number.
		/// </summary>
		/// <param name="number">The value to adjust.</param>
		/// <param name="length">The length of the adjusted value.</param>
		/// <returns>The zero filled string.</returns>
		public static string ZeroFill(short number, int length)
		{
			return ZeroFill(number.ToString(), length);
		}

		/// <summary>
		/// Zero fills and right adjusts a number, returning it as a string.
		/// <example>
		/// int i = 1234;
		/// string s = ZeroFill(i, 7);
		/// // value of s is "0001234"
		/// </example>
		/// Throws an InvalidOperationException if the value of Number is not a valid numeric value.
		/// Throws a FormatException is the length is too short for the value of number.
		/// </summary>
		/// <param name="number">The value to adjust.</param>
		/// <param name="length">The length of the adjusted value.</param>
		/// <returns>The zero filled string.</returns>
		public static string ZeroFill(int number, int length)
		{
			return ZeroFill(number.ToString(), length);
		}

		/// <summary>
		/// Zero fills and right adjusts a number, returning it as a string.
		/// <example>
		/// int i = 1234;
		/// string s = ZeroFill(i, 7);
		/// // value of s is "0001234"
		/// </example>
		/// Throws an InvalidOperationException if the value of Number is not a valid numeric value.
		/// Throws a FormatException is the length is too short for the value of number.
		/// </summary>
		/// <param name="number">The value to adjust.</param>
		/// <param name="length">The length of the adjusted value.</param>
		/// <returns>The zero filled string.</returns>
		public static string ZeroFill(long number, int length)
		{
			return ZeroFill(number.ToString(), length);
		}

		/// <summary>
		/// Zero fills and right adjusts a number, returning it as a string.
		/// <example>
		/// int i = 1234;
		/// string s = ZeroFill(i, 7);
		/// // value of s is "0001234"
		/// </example>
		/// Throws an InvalidOperationException if the value of Number is not a valid numeric value.
		/// Throws a FormatException is the length is too short for the value of number.
		/// </summary>
		/// <param name="number">The value to adjust.</param>
		/// <param name="length">The length of the adjusted value.</param>
		/// <returns>The zero filled string.</returns>
		public static string ZeroFill(string number, int length)
		{
			string s = number.Trim();
			if (!IsNumeric(s))
			{
				throw new InvalidOperationException("Number is not a valid Numeric Value.");
			}
			else if (s.Length > length)
			{
				throw new FormatException("Number is longer than requested length.");
			}
			else
			{
				while (s.Length < length)
				{
					s = "0" + s;
				}
			}
			return s;
		}

		/// <summary>
		/// Test whether or not the value of the string is a valid numeric value.
		/// </summary>
		/// <param name="s">The string to test.</param>
		/// <returns>True is the value is valid numeric, false if it is not.</returns>
		public static bool IsNumeric(string s)
		{
			decimal dec;
			return Decimal.TryParse(s.Trim(), out dec);
		}

		/// <summary>
		/// Gets the Edit Code character value of the IBMEditCode enumeration.
		/// </summary>
		/// <param name="code"></param>
		/// <returns></returns>
		public static char GetEditCodeValue(IBMEditCodes code)
		{
			char c;
			switch (code)
			{
				case IBMEditCodes.One:
					c = '1';
					break;

				case IBMEditCodes.Two:
					c = '2';
					break;

				case IBMEditCodes.Three:
					c = '3';
					break;

				case IBMEditCodes.Four:
					c = '4';
					break;

				default:
					c = Convert.ToChar(code.ToString());
					break;
			}
			return c;
		}

		public static char GetEditCodeValue(string code)
		{
			Char returnCode;
			switch (code.ToUpper())
			{
				case "ONE":
					returnCode = GetEditCodeValue(IBMEditCodes.One);
					break;

				case "TWO":
					returnCode = GetEditCodeValue(IBMEditCodes.Two);
					break;

				case "THREE":
					returnCode = GetEditCodeValue(IBMEditCodes.Three);
					break;

				case "FOUR":
					returnCode = GetEditCodeValue(IBMEditCodes.Four);
					break;

				case "A":
					returnCode = GetEditCodeValue(IBMEditCodes.A);
					break;

				case "B":
					returnCode = GetEditCodeValue(IBMEditCodes.B);
					break;

				case "C":
					returnCode = GetEditCodeValue(IBMEditCodes.C);
					break;

				case "D":
					returnCode = GetEditCodeValue(IBMEditCodes.D);
					break;

				case "J":
					returnCode = GetEditCodeValue(IBMEditCodes.J);
					break;

				case "K":
					returnCode = GetEditCodeValue(IBMEditCodes.K);
					break;

				case "L":
					returnCode = GetEditCodeValue(IBMEditCodes.L);
					break;

				case "M":
					returnCode = GetEditCodeValue(IBMEditCodes.M);
					break;

				case "N":
					returnCode = GetEditCodeValue(IBMEditCodes.N);
					break;

				case "O":
					returnCode = GetEditCodeValue(IBMEditCodes.O);
					break;

				case "P":
					returnCode = GetEditCodeValue(IBMEditCodes.P);
					break;

				case "Q":
					returnCode = GetEditCodeValue(IBMEditCodes.Q);
					break;

				case "X":
					returnCode = GetEditCodeValue(IBMEditCodes.X);
					break;

				case "Z":
					returnCode = GetEditCodeValue(IBMEditCodes.Z);
					break;

				default:
					throw new InvalidOperationException("Code is not a valid IBMEditCode.");
			}
			return returnCode;
		}
	}
}