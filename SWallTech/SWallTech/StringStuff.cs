using System;
using System.Text;

namespace SWallTech
{
	public static class StringStuff
	{
		/// <summary>
		/// Right adjusts a string to the specified length, padding leading characters with the specified FillCharacter.
		/// </summary>
		/// <param name="ValueToAdjust">The string to right adjust.</param>
		/// <param name="Size">The final size of the string</param>
		/// <param name="FillCharacter">The character used to fill the leading string positions.</param>
		/// <returns>The adjusted string.</returns>
		public static string RightAdjustString(string ValueToAdjust, int Size, char FillCharacter)
		{
			string s = ValueToAdjust;
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
		/// Right adjusts a string to the specified length, padded with leading blanks.
		/// </summary>
		/// <param name="ValueToAdjust">The string to right adjust.</param>
		/// <param name="Size">The final size of the string</param>
		/// <returns>The adjusted string.</returns>
		public static string RightAdjustString(string ValueToAdjust, int Size)
		{
			return RightAdjustString(ValueToAdjust, Size, ' ');
		}

		/// <summary>
		/// Right Adjusts an integer to a string representation with its leading zeroes.
		/// </summary>
		/// <example>
		/// int i = 17;
		/// string s = RightAdjustInt32(i, 5);
		/// // s now = "00017"
		/// </example>
		/// <param name="NumberToAdjust">The value to represent.</param>
		/// <param name="Size">The length of the final string.</param>
		/// <returns>The right adjusted, zero filled string representation of the value.</returns>
		public static string RightAdjustInt32(int ValueToAdjust, int Size)
		{
			return RightAdjustInt32(ValueToAdjust, Size, '0');
		}

		/// <summary>
		/// Right Adjusts an integer to a string representation, leading characters padded with supplied character.
		/// </summary>
		/// <example>
		/// int i = 17;
		/// string s = RightAdjustInt32(i, 5, '*');
		/// // s now = "***17"
		/// </example>
		/// <param name="NumberToAdjust">The value to represent.</param>
		/// <param name="Size">The length of the final string.</param>
		/// <param name="FillCharacter">The leading character fill value.</param>
		/// <returns>The right adjusted string representation of the value, leading padded with the supplied character.</returns>
		public static string RightAdjustInt32(int ValueToAdjust, int Size, char FillCharacter)
		{
			string s = ValueToAdjust.ToString();
			return RightAdjustString(s, Size, FillCharacter);
		}

		/// <summary>
		/// Right Adjusts a long integer to a string representation with its leading zeroes.
		/// </summary>
		/// <example>
		/// long l = 17;
		/// string s = RightAdjustInt64(l, 5);
		/// // s now = "00017"
		/// </example>
		/// <param name="NumberToAdjust">The value to represent.</param>
		/// <param name="Size">The length of the final string.</param>
		/// <returns>The right adjusted, zero filled string representation of the value.</returns>
		public static string RightAdjustInt64(long ValueToAdjust, int Size)
		{
			return RightAdjustInt64(ValueToAdjust, Size, '0');
		}

		/// <summary>
		/// Right Adjusts a long integer to a string representation, leading characters padded with supplied character.
		/// </summary>
		/// <example>
		/// long l = 17;
		/// string s = RightAdjustInt64(l, 5, '*');
		/// // s now = "***17"
		/// </example>
		/// <param name="NumberToAdjust">The value to represent.</param>
		/// <param name="Size">The length of the final string.</param>
		/// <param name="FillCharacter">The leading character fill value.</param>
		/// <returns>The right adjusted string representation of the value, leading padded with the supplied character.</returns>
		public static string RightAdjustInt64(long ValueToAdjust, int Size, char FillCharacter)
		{
			string s = ValueToAdjust.ToString();
			return RightAdjustString(s, Size, FillCharacter);
		}

		/// <summary>
		/// Right Adjusts a float to a string representation with its leading zeroes.
		/// </summary>
		/// <example>
		/// float f = 17.3f;
		/// string s = RightAdjustSingle(f, 7);
		/// // s now = "00017.3"
		/// </example>
		/// <param name="NumberToAdjust">The value to represent.</param>
		/// <param name="Size">The length of the final string.</param>
		/// <returns>The right adjusted, zero filled string representation of the value.</returns>
		public static string RightAdjustSingle(float ValueToAdjust, int Size)
		{
			return RightAdjustSingle(ValueToAdjust, Size, '0');
		}

		/// <summary>
		/// Right Adjusts a float to a string representation, leading characters padded with supplied character.
		/// </summary>
		/// <example>
		/// float f = 17.3f;
		/// string s = RightAdjustSingle(f, 7, '*');
		/// // s now = "***17.3"
		/// </example>
		/// <param name="NumberToAdjust">The value to represent.</param>
		/// <param name="Size">The length of the final string.</param>
		/// <param name="FillCharacter">The leading character fill value.</param>
		/// <returns>The right adjusted string representation of the value, leading padded with the supplied character.</returns>
		public static string RightAdjustSingle(float ValueToAdjust, int Size, char FillCharacter)
		{
			string s = ValueToAdjust.ToString();
			return RightAdjustString(s, Size, FillCharacter);
		}

		/// <summary>
		/// Right Adjusts a double to a string representation with its leading zeroes.
		/// </summary>
		/// <example>
		/// double d = 17.3d;
		/// string s = RightAdjustDouble(d, 7);
		/// // s now = "00017.3"
		/// </example>
		/// <param name="NumberToAdjust">The value to represent.</param>
		/// <param name="Size">The length of the final string.</param>
		/// <returns>The right adjusted, zero filled string representation of the value.</returns>
		public static string RightAdjustDouble(double ValueToAdjust, int Size)
		{
			return RightAdjustDouble(ValueToAdjust, Size, '0');
		}

		/// <summary>
		/// Right Adjusts a double to a string representation, leading characters padded with supplied character.
		/// </summary>
		/// <example>
		/// double d = 17.3d;
		/// string s = RightAdjustDouble(d, 7, '*');
		/// // s now = "***17.3"
		/// </example>
		/// <param name="NumberToAdjust">The value to represent.</param>
		/// <param name="Size">The length of the final string.</param>
		/// <param name="FillCharacter">The leading character fill value.</param>
		/// <returns>The right adjusted string representation of the value, leading padded with the supplied character.</returns>
		public static string RightAdjustDouble(double ValueToAdjust, int Size, char FillCharacter)
		{
			string s = ValueToAdjust.ToString();
			return RightAdjustString(s, Size, FillCharacter);
		}

		/// <summary>
		/// Right Adjusts a decimal to a string representation with its leading zeroes.
		/// </summary>
		/// <example>
		/// decimal d = 17.3M;
		/// string s = RightAdjustDecimal(d, 7);
		/// // s now = "00017.3"
		/// </example>
		/// <param name="NumberToAdjust">The value to represent.</param>
		/// <param name="Size">The length of the final string.</param>
		/// <returns>The right adjusted, zero filled string representation of the value.</returns>
		public static string RightAdjustDecimal(decimal ValueToAdjust, int Size)
		{
			return RightAdjustDecimal(ValueToAdjust, Size, '0');
		}

		/// <summary>
		/// Right Adjusts a decimal to a string representation, leading characters padded with supplied character.
		/// </summary>
		/// <example>
		/// decimal d = 17.3M;
		/// string s = RightAdjustDecimal(d, 7, '*');
		/// // s now = "***17.3"
		/// </example>
		/// <param name="NumberToAdjust">The value to represent.</param>
		/// <param name="Size">The length of the final string.</param>
		/// <param name="FillCharacter">The leading character fill value.</param>
		/// <returns>The right adjusted string representation of the value, leading padded with the supplied character.</returns>
		public static string RightAdjustDecimal(decimal ValueToAdjust, int Size, char FillCharacter)
		{
			string s = ValueToAdjust.ToString();
			return RightAdjustString(s, Size, FillCharacter);
		}

		public static string HandleEmbeddedQuotes(string s)
		{
			s = s.Replace("\"", "\"\"");
			s = s.Replace("\'", "\'\'");

			return s;
		}
	}
}