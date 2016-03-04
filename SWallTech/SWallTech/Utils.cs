using System;
using System.Text;

namespace SWallTech
{
	public static class Utils
	{
		/// <summary>
		/// Generates a string representation of an integer that includes leading zeroes.
		/// </summary>
		/// <param name="number">The number to convert to a string.</param>
		/// <param name="length">The final length of the string.</param>
		/// <returns>The string representaiton of the integer complete with leading zeroes.
		/// EX: string s = SWallTech.CF.Utilities.FillLeadingZeroes(45 , 5);
		/// // s now contains "00045"
		/// </returns>
		public static string FillLeadingZeroes(int number, int length)
		{
			string s = number.ToString();
			while (s.Length < length)
			{
				s = "0" + s;
			}
			return s;
		}

		/// <summary>
		/// Replaces singlequotes and double quotes within a given string with SQL acceptable equivelants.
		/// </summary>
		/// <param name="s">The string to operate on.</param>
		/// <returns>The adjusted string.</returns>
		public static string HandleEmbeddedQuotes(string s)
		{
			string data = s.Replace("'", "''");
			data = data.Replace("\"", "\"\"");
			return data;
		}

		/// <summary>
		/// Rounds any long number to the nearest baseValue.
		/// </summary>
		/// <param name="number">The number to round.</param>
		/// <param name="baseValue">The rounding value (nearest 100, 2500, etc.)</param>
		/// <returns>The rounded value.</returns>
		/// <example>
		/// <code>
		/// long roundBase = 2500 ;
		/// long roundedNumber = GeneralMath.RoundToBase( 53900 , roundBase );
		/// // roundedNumber equals 55000
		/// long roundedNumber2 = GeneralMath.RoundToBase( 52347 , roundBase );
		/// // roundedNumber2 equals 52500
		/// </code>
		/// </example>
		/// <remarks>The baseValue can be any positive integer(long) value.  Negative values
		/// may be passed in but will be converted to absolute value.
		/// </remarks>
		public static long RoundToBase(long number, long baseValue)
		{
			baseValue = System.Math.Abs(baseValue);
			decimal num = Convert.ToDecimal(number);
			decimal bas = Convert.ToDecimal(baseValue);
			decimal div = num / bas;
			long multiplier = Convert.ToInt64(System.Math.Round(div, 0));
			long roundedValue = baseValue * multiplier;
			return roundedValue;
		}
	}
}