using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SWallTech
{
	/// <summary>
	/// Represents a variety of Date String Formats:
	///    USDate: MM/DD/YYYY
	///    CanadianDate: DD/MM/YYYY
	///    IsoDate: YYYY-MM-DD
	///    YMD: YY/MM/DD
	///    MDY: MM/DD/YY
	///    DMY: DD/MM/YY
	/// </summary>
	public enum DateTimeFormat
	{
		USDate,
		CanadianDate,
		IsoDate,
		YMD,
		MDY,
		DMY
	}

	// The class name is largely irrelevant for Extension Methods
	public static class ExtensionMethods
	{
		/* Extension method rules:
         * 1) Extension methods must be static
         * 2) Must be in proper scope (generally public)
         * 3) The first parameter is marked with "this" to indicate it is an extension
         * 4) When the method is called, the first parameter is not passed
         */

		#region IEnumerable<T>

		/*

        /// <summary>
        /// Extends IEnumerable<T> to perform a specific Action against all members of the Sequence.
        /// </summary>
        /// <remarks>
        /// Richard Hale Shaw presented this method at VSLive! Austin 2007.
        /// </remarks>
        /// <code>
        /// </code>
        /// <typeparam name="T">Whatever Type is in the Sequence</typeparam>
        /// <param name="sequence">Extension Method Parameter:: this is an Extension reference to the actionable object.</param>
        /// <param name="action">The Action to perform on each item in the Sequence.</param>
         */

		public static void ForEach<T>(this IEnumerable<T> sequence, Action<T> action)
		{
			if (sequence == null)
			{
				throw new ArgumentNullException("sequence");
			}
			if (action == null)
			{
				throw new ArgumentNullException("action");
			}

			foreach (var item in sequence)
			{
				action(item);
			}
		}

		/*

        /// <summary>
        /// Extends IEnumerable<T> to return members of the sequence that match the requirements of the
        /// included Predicate<T>.
        /// </summary>
        /// <remarks>
        /// Richard Hale Shaw presented this method at VSLive! Austin 2007.
        /// </remarks>
        /// <typeparam name="T">Whatever Type is in the Sequence</typeparam>
        /// <param name="sequence">Extension Method Parameter:: this is an Extension reference to the actionable object.</param>
        /// <returns>An IEnumerable<T> in Iterator mode.</returns>
         */

		public static IEnumerable<T> Filter<T>(this IEnumerable<T> sequence, Predicate<T> predicate)
		{
			if (sequence == null)
			{
				throw new ArgumentNullException("sequence");
			}
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}

			foreach (var item in sequence)
			{
				if (predicate(item))
				{
					// Yield makes this perform like a Custom Iterator
					// Returns control after each item
					// Retains its position in the sequence
					yield return item;
				}
			}
		}

		/*

        /// <summary>
        ///
        /// </summary>
        /// <remarks>
        /// Richard Hale Shaw presented this method at VSLive! Austin 2007.
        /// </remarks>
        /// <typeparam name="T">Whatever Type is in the Sequence</typeparam>
        /// <param name="sequence">Extension Method Parameter:: this is an Extension reference to the actionable object.</param>
        /// <param name="comparison">Comparison<T> used to sort the sequence."/></param>
        /// <returns>An IEnumerable<T> in Iterator mode.</returns>
         */

		public static IEnumerable<T> Sort<T>(this IEnumerable<T> sequence, Comparison<T> comparison)
		{
			if (sequence == null)
			{
				throw new ArgumentNullException("sequence");
			}
			if (comparison == null)
			{
				throw new ArgumentNullException("comparison");
			}

			var list = new List<T>(sequence);
			list.Sort(comparison);
			foreach (var item in list)
			{
				// Yield makes this perform like a Custom Iterator
				// Returns control after each item
				// Retains its position in the sequence
				yield return item;
			}
		}

		#endregion IEnumerable<T>

		#region IDictionary

		/// <summary>
		/// Executes the specified Action on all Value elements of the IDictionary.
		/// </summary>
		/// <typeparam name="K">The IDictionary Key Type.</typeparam>
		/// <typeparam name="V">The IDictionary Value Type.</typeparam>
		/// <param name="sequence">Extension Method Parameter:: this is an Extension reference to the actionable object.</param>
		/// <param name="action">The Action to perform on each Value in the IDictionary Sequence.</param>
		public static void ExecuteOnValues<K, V>(this IDictionary<K, V> sequence, Action<V> action)
		{
			if (sequence == null)
			{
				throw new ArgumentNullException("sequence");
			}

			foreach (var item in sequence.Values)
			{
				action(item);
			}
		}

		#endregion IDictionary

		#region Collections

		public static List<T> ToList<T>(this ArrayList array)
		{
			List<T> list = new List<T>();
			foreach (object item in array)
			{
				if (item.GetType() == typeof(T))
				{
					list.Add((T)item);
				}
			}

			return list;
		}

		#endregion Collections

		#region String Extensions

		/// <summary>
		/// Extends String to escape embedded single and double quotes.
		/// </summary>
		/// <param name="s">Extension Method Parameter:: this is an Extension reference to the actionable string.</param>
		/// <returns>The properly escaped string.</returns>
		public static string EscapeEmbeddedQuotes(this string s)
		{
			s = s.Replace("\"", "\"\"");
			s = s.Replace("\'", "\'\'");

			return s;
		}

		/// <summary>
		/// Extends String to right adjust to the specified length, padding leading characters with the specified FillCharacter.
		/// </summary>
		/// <code>
		/// string s = "1234";
		/// string x = s.RightAdjust(10, '0');
		/// // s now contains "0000001234"
		/// </code>
		/// <param name="s">Extension Method Parameter:: this is an Extension reference to the actionable string.</param>
		/// <param name="Size">The final size of the string</param>
		/// <param name="FillCharacter">The character used to fill the leading string positions.</param>
		/// <returns>The adjusted string.</returns>
		public static string RightAdjust(this string s, int Size, char FillCharacter)
		{
			string ch = FillCharacter.ToString();

			if (s.Length > Size)
			{
				throw new ArgumentException("Size of Value larger than Requested Size.");
			}

			while (s.Length < Size)
			{
				s = ch + s;
			}

			return s;
		}

		/// <summary>
		/// Extends String to right adjust to the specified length, padding leading characters with blanks.
		/// </summary>
		/// <code>
		/// string s = "C# ROCKS";
		/// string x = s.RightAdjust(10);
		/// // s now contains "  C# ROCKS"
		/// </code>
		/// <param name="s">Extension Method Parameter:: this is an Extension reference to the actionable string.</param>
		/// <param name="Size">The final size of the string</param>
		/// <returns>The adjusted string.</returns>
		public static string RightAdjust(this string s, int Size)
		{
			return s.RightAdjust(Size, ' ');
		}

		/// <summary>
		/// Extends String to reverse the contents of the string.
		/// </summary>
		/// <param name="s">Extension Method Parameter:: this is an Extension reference to the actionable string.</param>
		/// <returns>The string contents in reversed order.</returns>
		public static string Reverse(this string s)
		{
			char[] chars = s.ToCharArray();
			StringBuilder b = new StringBuilder();
			for (int i = chars.Count() - 1; i >= 0; i--)
			{
				b.Append(chars[i]);
			}
			return b.ToString();
		}

		/// <summary>
		/// Extends String to determine if the string matches a Regular Expression.
		/// </summary>
		/// <code>
		/// if (s.IsRegexMatch("\r\n", RegexOptions.Explicit))
		/// </code>
		/// <param name="s">Extension Method Parameter:: this is an Extension reference to the actionable string.</param>
		/// <param name="pattern">The Regular Expression Pattern to match.</param>
		/// <param name="options">The Regular Expression Options for the Match determination.</param>
		/// <returns>True if the string matches the pattern, false otherwise.</returns>
		public static bool IsRegexMatch(this string s, string pattern, RegexOptions options)
		{
			return Regex.IsMatch(s, pattern, options);
		}

		/// <summary>
		/// Extends String to determine if the string matches a Regular Expression using "RegexOptions.None".
		/// </summary>
		/// <code>
		/// if (s.IsRegexMatch("\r\n"))
		/// </code>
		/// <param name="s">Extension Method Parameter:: this is an Extension reference to the actionable string.</param>
		/// <param name="pattern">The Regular Expression Pattern to match.</param>
		/// <param name="options">The Regular Expression Options for the Match determination.</param>
		/// <returns>True if the string matches the pattern, false otherwise.</returns>
		public static bool IsRegexMatch(this string s, string pattern)
		{
			return s.IsRegexMatch(pattern, RegexOptions.None);
		}

		public static string StripCharacters(this string s)
		{
			StringBuilder rem = new StringBuilder();
			var q = (from c in s.ToCharArray()
					 where char.IsNumber(c)
					 select c).ToList();
			q.ForEach(f => rem.Append(f));

			//s.ToCharArray().ForEach<char>(str =>
			//    {
			//        if (Regex.IsMatch(str.ToString(), @"[\d]"))
			//        {
			//            rem.Append(str);
			//        }
			//    });
			return rem.ToString();
		}

		/// <summary>
		/// Converts a string to a Byte Array.
		/// </summary>
		/// <param name="s">The string to convert.</param>
		/// <returns>The converted Byte Array.</returns>
		public static byte[] ToByteArray(this string s)
		{
			System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
			return encoding.GetBytes(s);
		}

		/// <summary>
		/// Converts a Byte Array to a string.
		/// </summary>
		/// <param name="bytes">The Byte Array to convert.</param>
		/// <returns>The converted string.</returns>
		public static string ConvertToString(this byte[] bytes)
		{
			System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
			return enc.GetString(bytes);
		}

		public static bool IsNullOrEmpty(this string s)
		{
			return String.IsNullOrEmpty(s);
		}

		#endregion String Extensions

		#region Char Extenstions

		public static bool IsDigit(this char c)
		{
			return Char.IsDigit(c);
		}

		#endregion Char Extenstions

		#region Numeric Extensions

		/// <summary>
		/// Rounds any long number to the nearest baseValue.
		/// </summary>
		/// <param name="number">Extension Method Parameter:: this is an Extension reference to the actionable number.</param>
		/// <param name="baseValue">The rounding value (nearest 100, 2500, etc.)</param>
		/// <returns>The rounded value.</returns>
		/// <example>
		/// <code>
		/// long roundingBase = 2500 ;
		/// long number = 53900;
		/// long roundedNumber = number.RoundToBase( roundingBase );
		/// // roundedNumber equals 55000
		/// number = 52347;
		/// long roundedNumber2 = number.RoundToBase( 100 );
		/// // roundedNumber2 equals 52300
		/// </code>
		/// </example>
		/// <remarks>The baseValue can be any positive long value.  Negative values
		/// may be passed in but will be converted to absolute value.
		/// </remarks>
		public static long RoundToBase(this long number, long baseValue)
		{
			baseValue = System.Math.Abs(baseValue);
			decimal num = Convert.ToDecimal(number);
			decimal bas = Convert.ToDecimal(baseValue);
			decimal div = num / bas;
			long multiplier = Convert.ToInt64(System.Math.Round(div, 0));
			long roundedValue = baseValue * multiplier;
			return roundedValue;
		}

		/// <summary>
		/// Rounds any int number to the nearest baseValue.
		/// </summary>
		/// <param name="number">Extension Method Parameter:: this is an Extension reference to the actionable number.</param>
		/// <param name="baseValue">The rounding value (nearest 100, 2500, etc.)</param>
		/// <returns>The rounded value.</returns>
		/// <example>
		/// <code>
		/// int roundingBase = 2500 ;
		/// int number = 53900;
		/// int roundedNumber = number.RoundToBase( roundingBase );
		/// // roundedNumber equals 55000
		/// number = 52347;
		/// int roundedNumber2 = number.RoundToBase( 100 );
		/// // roundedNumber2 equals 52300
		/// </code>
		/// </example>
		/// <remarks>The baseValue can be any positive int value.  Negative values
		/// may be passed in but will be converted to absolute value.
		/// </remarks>
		public static int RoundToBase(this int number, int baseValue)
		{
			long l = number;
			long lbase = baseValue;
			return Convert.ToInt32(l.RoundToBase(lbase));
		}

		/// <summary>
		/// Converts a decimal to a decimal with only two decimal places, suitable for Monetary uses.
		/// </summary>
		/// <param name="number">Extension Method Parameter:: this is an Extension reference to the actionable number.</param>
		/// <param name="useRounding">If TRUE, the decimal numbers are rounded.  If FALSE they are simply truncated.</param>
		/// <returns>A decimal with only two decimal places, suitable for Monetary uses.</returns>
		public static decimal ConvertToMoney(this decimal number, bool useRounding)
		{
			decimal d = number;
			if (useRounding)
			{
				d = Decimal.Round(number, 2);
			}
			else
			{
				string s = d.ToString();
				string[] parts = s.Split(new char[] { '.' });
				string decs = "00";
				if (parts.Length == 2)
				{
					if (parts[1].Length > 2)
					{
						decs = parts[1].Substring(0, 2);
					}
					else
					{
						decs = parts[1].Substring(0);
					}
				}

				d = Decimal.Parse(parts[0] + "." + decs);
			}

			return d;
		}

		/// <summary>
		/// Converts a decimal to a decimal with only two decimal places, suitable for Monetary uses, without any
		/// Rounding behavior.
		/// </summary>
		/// <param name="number">Extension Method Parameter:: this is an Extension reference to the actionable number.</param>
		/// <returns>A decimal with only two decimal places, suitable for Monetary uses. Decimal
		/// value is truncated to the first two digits - no rounding occurs.</returns>
		public static decimal ConvertToMoney(this decimal number)
		{
			return number.ConvertToMoney(false);
		}

		/// <summary>
		/// Converts a decimal to a String with commas representing money.
		/// </summary>
		/// <param name="number">Extension Method Parameter:: this is an Extension reference to the actionable number.</param>
		/// <param name="useRounding">If TRUE, the decimal places are rounded. If FALSE they are merely truncated.</param>
		/// <param name="includeMoneySign">If TRUE, the character in the next variable followed by a single ' ' is placed in front
		/// of the decimal.</param>
		/// <param name="moneySign">The char used if parameter "includeMoneySign" is TRUE. Ignored if parameter "includeMoneySign" is FALSE.</param>
		/// <returns>A String with commas representing money.</returns>
		public static string GetMoneyString(this decimal number, bool useRounding, bool includeMoneySign, char moneySign, bool hideDecimals)
		{
			bool isNegative = number < 0;
			decimal money = Math.Abs(number.ConvertToMoney(useRounding));
			if (hideDecimals)
			{
				money = Decimal.Round(money, 0);
			}

			int billions = (int)(money / 1000000000);
			int millions = (int)((money / 1000000) % 1000);
			int thousands = (int)((money / 1000) % 1000);
			int hundreds = (int)(money % 1000);
			string decimals = String.Empty;
			if (!money.ToString().Contains('.'))
			{
				decimals = "0";
			}
			else
			{
				decimals = money.ToString().Substring(money.ToString().IndexOf('.') + 1);
			}
			StringBuilder s = new StringBuilder();
			if (includeMoneySign)
			{
				s.Append(moneySign);
				s.Append(" ");
			}
			if (isNegative)
			{
				s.Append("-");
			}
			if (billions != 0)
			{
				s.Append(billions.ToString());
				s.Append(',');
				s.Append(millions.ToString().RightAdjust(3, '0'));
				s.Append(',');
				s.Append(thousands.ToString().RightAdjust(3, '0'));
				s.Append(',');
				s.Append(hundreds.ToString().RightAdjust(3, '0'));
			}
			else if (millions != 0)
			{
				s.Append(millions.ToString());
				s.Append(',');
				s.Append(thousands.ToString().RightAdjust(3, '0'));
				s.Append(',');
				s.Append(hundreds.ToString().RightAdjust(3, '0'));
			}
			else if (thousands != 0)
			{
				s.Append(thousands.ToString());
				s.Append(',');
				s.Append(hundreds.ToString().RightAdjust(3, '0'));
			}
			else if (hundreds != 0)
			{
				s.Append(hundreds.ToString());
			}

			if (!hideDecimals)
			{
				s.Append('.');
				s.Append(decimals.ToString().PadRight(2, '0'));
			}

			return s.ToString();
		}

		/// <summary>
		/// Converts a decimal to a String with commas representing money.
		/// </summary>
		/// <param name="number">Extension Method Parameter:: this is an Extension reference to the actionable number.</param>
		/// <param name="useRounding">If TRUE, the decimal places are rounded. If FALSE they are merely truncated.</param>
		/// <param name="includeDollarSign">If TRUE, the "$ " is placed in front of the decimal.</param>
		/// <returns>A String with commas representing US Dollares.</returns>
		public static string GetUSMoneyString(this decimal number, bool useRounding, bool includeDollarSign)
		{
			return number.GetMoneyString(useRounding, includeDollarSign, '$', false);
		}

		/// <summary>
		/// Converts a decimal to a String with commas representing money.
		/// </summary>
		/// <param name="number">Extension Method Parameter:: this is an Extension reference to the actionable number.</param>
		/// <param name="useRounding">If TRUE, the decimal places are rounded. If FALSE they are merely truncated.</param>
		/// <param name="includeDollarSign">If TRUE, the "$ " is placed in front of the decimal.</param>
		/// <returns>A String with commas representing US Dollares.</returns>
		public static string GetUSMoneyString(this decimal number, bool useRounding, bool includeDollarSign, bool hideDecimals)
		{
			return number.GetMoneyString(useRounding, includeDollarSign, '$', hideDecimals);
		}

		/// <summary>
		/// Converts a decimal to a String with commas representing US Dollars.  Includes the "$" sign.
		/// </summary>
		/// <param name="number">Extension Method Parameter:: this is an Extension reference to the actionable number.</param>
		/// <param name="useRounding">If TRUE, the decimal places are rounded. If FALSE they are merely truncated.</param>
		/// <returns>A String with commas representing US Dollares including the "$" sign.</returns>
		public static string GetUSMoneyString(this decimal number, bool useRounding)
		{
			return number.GetMoneyString(useRounding, true, '$', false);
		}

		/// <summary>
		/// Converts a decimal to a String with commas representing US Dollars.  Includes the "$" sign. Decimal
		/// digits are truncated.
		/// </summary>
		/// <param name="number">Extension Method Parameter:: this is an Extension reference to the actionable number.</param>
		/// <returns>A String with commas representing US Dollares including the "$" sign.</returns>
		public static string GetUSMoneyString(this decimal number)
		{
			return number.GetUSMoneyString(false);
		}

		/// <summary>
		/// Converts a decimal to a String with commas representing US Dollars.  Includes the "$" sign. Decimal
		/// digits are truncated.
		/// </summary>
		/// <param name="number">Extension Method Parameter:: this is an Extension reference to the actionable number.</param>
		/// <returns>A String with commas representing US Dollares including the "$" sign.</returns>
		public static string GetUSMoneyNoDecimalString(this decimal number)
		{
			return number.GetUSMoneyString(false, true, true);
		}

		public static string ConvertToWords(this long number)
		{
			// define word arrays
			string[] wordOnes =
			{
				"Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven",
				"Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen",
				"Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"
			};

			string[] wordTens =
			{
				null, "teen", "Twenty", "Thirty", "Forty", "Fifty", "Sixty",
				"Seventy", "Eighty", "Ninety"
			};

			Func<string, string, string> GetWords =
			delegate (string h, string sizeWord)
			{
				if ("".Equals(h))
				{
					h = "0";
				}
				int smallValue = int.Parse(h);
				int hunsValue = smallValue / 100; //ex: 123 = 1
				int tensValue = smallValue % 100; //ex: 123 = 23
				int onesValue = smallValue % 10;  //ex: 123 = 3

				StringBuilder words = new StringBuilder();
				if (hunsValue > 0)
				{
					words.Append(wordOnes[hunsValue]);
					words.Append(" Hundred ");
				}
				if (tensValue > 0)
				{
					if (tensValue <= 19) // "one word" cases
					{
						words.Append(wordOnes[tensValue]);
					}
					else // tensValue MUST be at least 20, so include the "tens" word
					{
						words.Append(wordTens[(tensValue / 10)]);
						if (onesValue > 0)
						{
							words.Append("-");
							words.Append(wordOnes[onesValue]);
						}
					}
				}
				if (smallValue > 0)
				{
					words.Append(sizeWord);
				}

				return words.ToString();
			};

			string money = Convert.ToDecimal(number).GetMoneyString(false, false, ' ', false);
			money = money.Remove(money.IndexOf('.'));
			string[] parts = money.Split(new char[] { ',' });

			StringBuilder w = new StringBuilder();
			switch (parts.Length)
			{
				case 1:
					w.Append(GetWords(parts[0], "")); // Hundreds
					break;

				case 2:
					w.Append(GetWords(parts[0], " Thousand "));
					w.Append(GetWords(parts[1], "")); // Hundreds
					break;

				case 3:
					w.Append(GetWords(parts[0], " Million "));
					w.Append(GetWords(parts[1], " Thousand "));
					w.Append(GetWords(parts[2], "")); // Hundreds
					break;

				case 4:
					w.Append(GetWords(parts[0], " Billion "));
					w.Append(GetWords(parts[1], " Million "));
					w.Append(GetWords(parts[2], " Thousand "));
					w.Append(GetWords(parts[3], "")); // Hundreds
					break;

				default:
					w.Append("Zero"); // No value passed
					break;
			}

			return w.ToString();
		}

		/// <summary>
		/// Evaluates just the portion of the value to the right of the decimal place and returns it as an int.
		/// Returns 0 if the value is a whole number.
		/// </summary>
		/// <param name="number">Extension Method Parameter:: this is an Extension reference to the actionable number.</param>
		/// <returns>The value to the right of the decimal place. Returns 0 if the value is a whole number.</returns>
		public static decimal GetDecimalNumbers(this decimal number)
		{
			//string s = number.ToString();
			//string[] parts = s.Split(new char[] { '.' });
			//string decs = "0";
			//if (parts.Length == 2)
			//{
			//    decs = parts[1].Substring(0);
			//}

			//return int.Parse(decs);

			int divint = Convert.ToInt32(Decimal.Floor(number));
			decimal decValue = number - divint;

			return decValue;
		}

		#endregion Numeric Extensions

		#region Conversion Methods

		/// <summary>
		/// Converts a float to an Int32.
		/// </summary>
		/// <param name="x">Extension Method Parameter:: this is an Extension reference to the actionable number.</param>
		/// <returns>The Integer representation.</returns>
		public static int ToInt32(this float x)
		{
			return Convert.ToInt32(x);
		}

		/// <summary>
		/// Converts a decimal to an Int32.
		/// </summary>
		/// <param name="x">Extension Method Parameter:: this is an Extension reference to the actionable number.</param>
		/// <returns>The Integer representation.</returns>
		public static int ToInt32(this decimal x)
		{
			return Convert.ToInt32(x);
		}

		/// <summary>
		/// Converts a double to an Int32.
		/// </summary>
		/// <param name="x">Extension Method Parameter:: this is an Extension reference to the actionable number.</param>
		/// <returns>The Integer representation.</returns>
		public static int ToInt32(this double x)
		{
			return Convert.ToInt32(x);
		}

		#endregion Conversion Methods

		#region DateTime Extensions

		/// <summary>
		/// Converts a DateTime to a properly formatted date as a string. Includes proper default separator.
		/// </summary>
		/// <param name="dt">Extension Method Parameter:: this is an Extension reference to the actionable number.</param>
		/// <param name="format">The format of the returned date string.</param>
		/// <returns>The string representation of the DateTime in requested Date Format.</returns>
		public static string GetDateString(this DateTime dt, DateTimeFormat format)
		{
			return dt.GetDateString(format, true);
		}

		/// <summary>
		/// Converts a DateTime to a properly formatted date as a string.
		/// </summary>
		/// <param name="dt">Extension Method Parameter:: this is an Extension reference to the actionable number.</param>
		/// <param name="format">The format of the returned date string.</param>
		/// <param name="includeSeparator">If TRUE, the proper separator character for the DateTimeFormat will be used
		/// (such as MM/DD/YYYY). If FALSE, then no separator character will be used (such as MMDDYYYY).</param>
		/// <returns>The string representation of the DateTime in requested Date Format.</returns>
		public static string GetDateString(this DateTime dt, DateTimeFormat format, bool includeSeparator)
		{
			char sep = '/';

			switch (format)
			{
				case DateTimeFormat.IsoDate:
					sep = '-';
					break;

				default:
					break;
			}

			return dt.GetDateString(format, includeSeparator, sep);
		}

		/// <summary>
		/// Converts a DateTime to a properly formatted date as a string.
		/// </summary>
		/// <param name="dt">Extension Method Parameter:: this is an Extension reference to the actionable number.</param>
		/// <param name="format">The format of the returned date string.</param>
		/// <param name="includeSeparator">If TRUE, then the separator character in Param "separator" will be used
		/// (such as MM/DD/YYYY). If FALSE, then no separator character will be used (such as MMDDYYYY).</param>
		/// <param name="separator">The separator character to use if Param "includeSeparator" is TRUE.
		/// Ignored if FALSE.</param>
		/// <returns>The string representation of the DateTime in requested Date Format.</returns>
		public static string GetDateString(this DateTime dt, DateTimeFormat format, bool includeSeparator, char separator)
		{
			string dateString = String.Empty;

			if (dt == null)
			{
				dt = DateTime.Now;
			}

			switch (format)
			{
				case DateTimeFormat.USDate:
					if (includeSeparator)
					{
						dateString = String.Format("{0}{1}{2}{3}{4}",
							dt.Month.ToString().PadLeft(2, '0'),
							separator,
							dt.Day.ToString().PadLeft(2, '0'),
							separator,
							dt.Year.ToString().PadLeft(4, '0'));
					}
					else
					{
						dateString = String.Format("{0}{1}{2}",
							dt.Month.ToString().PadLeft(2, '0'),
							dt.Day.ToString().PadLeft(2, '0'),
							dt.Year.ToString().PadLeft(4, '0'));
					}
					break;

				case DateTimeFormat.CanadianDate:
					if (includeSeparator)
					{
						dateString = String.Format("{0}{1}{2}{3}{4}",
							dt.Day.ToString().PadLeft(2, '0'),
							separator,
							dt.Month.ToString().PadLeft(2, '0'),
							separator,
							dt.Year.ToString().PadLeft(4, '0'));
					}
					else
					{
						dateString = String.Format("{0}{1}{2}",
							dt.Day.ToString().PadLeft(2, '0'),
							dt.Month.ToString().PadLeft(2, '0'),
							dt.Year.ToString().PadLeft(4, '0'));
					}
					break;

				case DateTimeFormat.IsoDate:
					if (includeSeparator)
					{
						dateString = String.Format("{0}{1}{2}{3}{4}",
							dt.Year.ToString().PadLeft(4, '0'),
							separator,
							dt.Month.ToString().PadLeft(2, '0'),
							separator,
							dt.Day.ToString().PadLeft(2, '0'));
					}
					else
					{
						dateString = String.Format("{0}{1}{2}",
							dt.Year.ToString().PadLeft(4, '0'),
							dt.Month.ToString().PadLeft(2, '0'),
							dt.Day.ToString().PadLeft(2, '0'));
					}
					break;

				case DateTimeFormat.MDY:
					if (includeSeparator)
					{
						dateString = String.Format("{0}{1}{2}{3}{4}",
							dt.Month.ToString().PadLeft(2, '0'),
							separator,
							dt.Day.ToString().PadLeft(2, '0'),
							separator,
							dt.TwoDigitYear().ToString().PadLeft(2, '0'));
					}
					else
					{
						dateString = String.Format("{0}{1}{2}",
							dt.Month.ToString().PadLeft(2, '0'),
							dt.Day.ToString().PadLeft(2, '0'),
							dt.TwoDigitYear().ToString().PadLeft(2, '0'));
					}
					break;

				case DateTimeFormat.DMY:
					if (includeSeparator)
					{
						dateString = String.Format("{0}{1}{2}{3}{4}",
							dt.Day.ToString().PadLeft(2, '0'),
							separator,
							dt.Month.ToString().PadLeft(2, '0'),
							separator,
							dt.TwoDigitYear().ToString().PadLeft(2, '0'));
					}
					else
					{
						dateString = String.Format("{0}{1}{2}",
							dt.Day.ToString().PadLeft(2, '0'),
							dt.Month.ToString().PadLeft(2, '0'),
							dt.TwoDigitYear().ToString().PadLeft(2, '0'));
					}
					break;

				case DateTimeFormat.YMD:
					if (includeSeparator)
					{
						dateString = String.Format("{0}{1}{2}{3}{4}",
							dt.TwoDigitYear().ToString().PadLeft(2, '0'),
							separator,
							dt.Month.ToString().PadLeft(2, '0'),
							separator,
							dt.Day.ToString().PadLeft(2, '0'));
					}
					else
					{
						dateString = String.Format("{0}{1}{2}",
							dt.TwoDigitYear().ToString().PadLeft(2, '0'),
							dt.Month.ToString().PadLeft(2, '0'),
							dt.Day.ToString().PadLeft(2, '0'));
					}
					break;

				default:
					break;
			}

			return dateString;
		}

		/// <summary>
		/// Retrieves the Year of a DateTime in 2 digit format.
		/// </summary>
		/// <param name="dt">Extension Method Parameter:: this is an Extension reference to the actionable number.</param>
		/// <returns>The two digit year of the DateTime.</returns>
		public static int TwoDigitYear(this DateTime dt)
		{
			if (dt == null)
			{
				dt = DateTime.Now;
			}

			return int.Parse(dt.Year.ToString().Substring(2));
		}

		/// <summary>
		/// 2008-03-31-14.30.05.473000
		/// yyyy-mm-dd-hh.mm.ss.mmmmmm
		/// </summary>
		/// <param name="dt"></param>
		/// <returns></returns>
		public static string IDB2TimestampString(this DateTime dt)
		{
			return dt.IDB2TimestampString(false);
		}

		public static string IDB2TimestampString(this DateTime dt, bool SetToEndOfDay)
		{
			if (dt == null)
			{
				dt = DateTime.Now;
			}

			if (SetToEndOfDay)
			{
				return String.Format("{0}-{1}-{2}-23.59.59.999999",
					dt.Year,
					dt.Month.ToString().PadLeft(2, '0'),
					dt.Day.ToString().PadLeft(2, '0'));
			}
			else
			{
				return String.Format("{0}-{1}-{2}-{3}.{4}.{5}.{6}",
					dt.Year,
					dt.Month.ToString().PadLeft(2, '0'),
					dt.Day.ToString().PadLeft(2, '0'),
					dt.Hour.ToString().PadLeft(2, '0'),
					dt.Minute.ToString().PadLeft(2, '0'),
					dt.Second.ToString().PadLeft(2, '0'),
					dt.Millisecond.ToString().PadRight(6, '9'));
			}
		}

		#endregion DateTime Extensions

		#region Miscellaneous

		/// <summary>
		/// Clears all Text from a StringBuilder.
		/// </summary>
		/// <param name="s">Extension Method Parameter:: the StringBuilder to clear.</param>
		public static void Clear(this StringBuilder s)
		{
			s.Length = 0;
		}

		#endregion Miscellaneous

		#region IO

		public static bool IsEmpty(this DirectoryInfo dir)
		{
			return (dir.GetFiles().Count() == 0 && dir.GetDirectories().Count() == 0);
		}

		#endregion IO
	}
}