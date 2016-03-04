using System;
using System.Text;

namespace SWallTech
{
	/// <summary>
	/// A simple wrapper for the StringBuilder class.
	/// </summary>
	/// <remarks>The StringBuilder class allows the user to set capacity and max capacity,
	/// but also permits those values to change.  The capacity sizes of FixedString are immutable.
	/// Additionally, ever variable string coming in is checked for strict adherence to the
	/// FixedString size.  No hidden truncating occurs: an error is thrown if the resulting size
	/// is too great.  While this requires more error checking, it guarantees that data will not
	/// be inadvertently lost.</remarks>
	[Serializable]
	public class FixedString
	{
		private static char[] blanks = new char[] { ' ' };

		#region Instance Variables

		private int size;
		private StringBuilder sb;

		#endregion Instance Variables

		#region Constructors

		private FixedString()
		{
		}

		/// <summary>
		/// Creates a new FixedString object with the specified size.
		/// </summary>
		/// <param name="size">The immutable size of the FixedString.</param>
		public FixedString(int size)
		{
			this.size = size;
			this.sb = new StringBuilder(size, size);
		}

		/// <summary>
		/// Creates a new FixedString object with the specified size and
		/// initialized to this string.
		/// </summary>
		/// <param name="size">The immutable size of the FixedString.</param>
		/// <param name="initialValue">The initial string value of the object.</param>
		public FixedString(int size, string initialText)
			: this(size)
		{
			this.append(initialText);
		}

		#endregion Constructors

		#region Properites

		/// <summary>
		/// Gets the size of the FixedString object. (Read-only)
		/// </summary>
		public int Size
		{
			get
			{
				return this.size;
			}
		}

		/// <summary>
		/// Gets or sets the text value of the current FixedString object.
		///
		/// Throws an OverflowException if the resulting value would be outside the bounds
		/// of the instance's current configuration.
		/// </summary>
		public string Text
		{
			get
			{
				return this.sb.ToString();
			}

			set
			{
				if (!this.checkValue(value))
				{
					throw new OverflowException("Size of value is larger than specified string size.");
				}
				else
				{
					this.clear();
					this.sb.Append(value);
				}
			}
		}

		/// <summary>
		/// Gets the text value of the current FixedString object.
		/// </summary>
		public string Value
		{
			get
			{
				return this.sb.ToString().TrimEnd(blanks);
			}
		}

		#endregion Properites

		#region public methods

		/// <summary>
		/// Check to see if the string value fits inside the current bounds of this FixedString
		/// object.
		/// </summary>
		/// <param name="s">The string to check.</param>
		/// <returns>A boolean value: TRUE means the value fits within current parameters and
		/// FALSE when it falls outside the range.</returns>
		public bool checkValue(string s)
		{
			bool isOK = true;
			if (s.Length > this.size)
			{
				isOK = false;
			}

			//			else if ( ( s.Length + this.sb.Length ) > this.size )
			//			{
			//				isOK = false ;
			//			}
			return isOK;
		}

		/// <summary>
		/// Check to see if the FixedString value fits inside the current bounds of this FixedString
		/// object.
		/// </summary>
		/// <param name="s">The FixedString to check.</param>
		/// <returns>A boolean value: TRUE means the value fits within current parameters and
		/// FALSE when it falls outside the range.</returns>
		public bool checkValue(FixedString fs)
		{
			return this.checkValue(fs.Text);
		}

		/// <summary>
		/// Sets the text value of the current FixedString object.
		///
		/// Throws an OverflowException if the resulting value would be outside the bounds
		/// of the instance's current configurtation.
		/// </summary>
		/// <param name="s">The string to set this instance value.</param>
		public void setValue(string s)
		{
			this.Text = s;
		}

		/// <summary>
		/// Sets the text value of the current FixedString object.
		///
		/// Throws an OverflowException if the resulting value would be outside the bounds
		/// of the instance's current configurtation.
		/// </summary>
		/// <param name="fs">The FixedString to set this instance value.</param>
		public void setValue(FixedString fs)
		{
			this.Text = fs.Text;
		}

		/// <summary>
		/// Clears the text from the current FixedString object.
		/// </summary>
		public void clear()
		{
			sb.Length = 0;
		}

		/// <summary>
		/// Appends the current Text with the string parameter.
		///
		/// Throws an OverflowException if the resulting value would be outside the bounds
		/// of the instance's current configurtation.
		/// </summary>
		/// <param name="s">The text to append.</param>
		public void append(string s)
		{
			if (!this.checkValue(s))
			{
				throw new OverflowException("Size of value is larger than specified string size.");
			}
			this.sb.Append(s);
		}

		/// <summary>
		/// Creates a copy of the current FixedString object with the same size and Text.
		/// </summary>
		/// <returns>A FixedString object representing a copy of the current object.</returns>
		public FixedString copy()
		{
			return new FixedString(this.size, this.Text);
		}

		#endregion public methods
	}
}