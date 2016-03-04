using System;
using System.Text;

namespace SWallTech
{
	/// <summary>FixedDecimal is a wrapper class for the decimal data type.</summary>
	/// <remarks>
	/// <para>FixedDecimal is a wrapper class for the decimal data type.  While the decimal data type provides better
	/// support for fixed precision operations than float or double, it does not adequately allow you to actively limit the
	/// total length of a variable or the number of decimal positions a variable may have.
	/// </para>
	/// <para>
	/// In contrast, the FixedDecimal class specifically manages these elemental sizes.  For example, if you have
	/// a column in a database table that is defined as "numeric(5,3)" you can mimic the mathematical
	/// behavior of that field with a FixedDecimal object:
	/// <code>
	/// FixedDecimal myNumber = new FixedDecimal(5,3);
	/// </code>
	/// Doing so ensures that the data represented by the variable will always remain within the confines of the
	/// assigned definition.  The Length property includes the decimal positions, so in the case of (5,3), the
	/// format of the variable will be xx.xxx - five total positions, 3 of which are decimals.
	/// Maximum and Minimum values will be based on filling the position markers with 9's. Once created, a
	/// FixedDecimal variable's length and decimal position properties are immutable.
	/// </para>
	/// <para>
	/// <code>
	/// FixedDecimal myNumber = new FixedDecimal(5,3);
	/// decimal max = myNumber.MaxValue ;
	/// // value of max is 99.999
	/// decimal min = myNumber.MinValue ;
	/// // value of min is -99.999
	/// </code>
	///
	/// A FixedDecimal can be limited to positive values by setting the AllowNegatives Property to false:
	///
	/// <code>
	/// FixedDecimal myNumber = new FixedDecimal(5,3,false);
	/// // Same as:
	/// //  FixedDecimal myNumber = new FixedDecimal(5,3);
	/// //  myNumber.AllowNegatives = false ;
	///
	/// decimal max = myNumber.MaxValue ;
	/// // value of max is 99.999
	/// decimal min = myNumber.MinValue ;
	/// // value of min is 00.000
	/// </code>
	/// </para>
	///
	/// <para>
	/// To create specific variable types, you could extend this class and initialize it
	/// with specific sizes for that variable type.  For instance, a social security number is always a
	/// positive 9,0 so you could extend this class and include a base instantiation of base(9,0).
	/// </para>
	/// <para>
	/// A FixedDecimal cannot have a length greater than 28.  If a length parameter is specified that is
	/// greater than 28, then the length wil be truncated to 28.</para>
	/// </remarks>
	[Serializable]
	public class FixedDecimal
	{
		#region Instance Variables

		private decimal number;
		private int length;
		private int decPos;
		private long integer;
		private string decimals;
		private bool allowNegatives;

		#endregion Instance Variables

		#region Constructors

		private FixedDecimal()
		{
		}

		/// <summary>
		/// Creates a new FixedDecimal object with the specified total length and number of decimal positions
		/// that allows negative numbers.
		/// </summary>
		/// <remarks>If the number of decimal positions is greater than 28, the decimal
		/// positions value will be truncated to 28.</remarks>
		/// <param name="length">The total length of the variable.</param>
		/// <param name="decPos">The number of decimal positions of the variable.</param>
		public FixedDecimal(int length, int decPos)
		{
			if (length > 28)
			{
				this.length = 28;
			}
			else
			{
				this.length = length;
			}
			this.decPos = decPos;
			this.allowNegatives = true;
		}

		/// <summary>
		/// Creates a new FixedDecimal object with the specified total length and number of decimal positions.
		/// Negative number support is determined by the allowNegatives parameter.
		/// </summary>
		/// <remarks>
		/// If the number of decimal positions is greater than 28, the decimal positions value will be truncated
		/// to 28.
		/// </remarks>
		/// <param name="length">The total length of the variable.</param>
		/// <param name="decPos">The number of decimal positions of the variable.</param>
		/// <param name="allowNegatives">Determines whether or not this instance supports negative numbers.
		/// TRUE indicates negatives are allowed, FALSE indicates that negatives are not allowed.</param>
		public FixedDecimal(int length, int decPos, bool allowNegatives)
		{
			if (length > 28)
			{
				this.length = 28;
			}
			else
			{
				this.length = length;
			}
			this.decPos = decPos;
			this.allowNegatives = allowNegatives;
		}

		/// <summary>
		/// Creates a new FixedDecimal object whose total length and number of decimal positions
		/// are based on the passed decimal value.  The initial value of the FixedDecimal instance
		/// will be set to the value of the passed decimal.
		/// </summary>
		/// <remarks>If the number of decimal positions is greater than 28, the decimal
		/// positions value will be truncated to 28.
		/// <para>If the value of the decimal positions passed in is 0, then the FixedDecimal
		/// object will have zero decimal positions.</para>
		/// <para>Always allows negative values.</para>
		/// </remarks>
		/// <param name="dec">The decimal value on which to base this instance.</param>
		public FixedDecimal(decimal dec)
			: this(dec, false)
		{
		}

		/// <summary>
		/// Creates a new FixedDecimal object whose total length and number of decimal positions
		/// are based on the decimal conversion of the passed string value.
		/// The initial value of the FixedDecimal instance
		/// will be set to the value of the passed decimal.
		/// </summary>
		/// <remarks>If the number of decimal positions is greater than 28, the decimal
		/// positions value will be truncated to 28.
		/// <para>If the value of the decimal positions passed in is 0, then the FixedDecimal
		/// object will have zero decimal positions.</para>
		/// <para>Always allows negative values.</para>
		/// </remarks>
		/// <param name="dec">The decimal value on which to base this instance.</param>
		public FixedDecimal(string dec)
			: this(Convert.ToDecimal(dec), false)
		{
		}

		/// <summary>
		/// Creates a new FixedDecimal object whose total length and number of decimal positions
		/// are based on the passed decimal value.  The initial value of the FixedDecimal instance
		/// will be set to the value of the passed decimal.
		/// </summary>
		/// <remarks>If the number of decimal positions is greater than 28, the decimal
		/// positions value will be truncated to 28.
		/// <para>The second parameter "forceDecimalPositions" will force the decimal position size to
		/// the number of positions in the passed value regardless of the value. A decimal that was
		/// created from an integer will have 1 decimal position:
		/// <example>
		/// int myInt = 20 ;
		/// decimal myDec = Convert.ToDecimal( myInt );
		/// // value of myDec is now "20.0"
		/// </example>
		/// If this decimal is used to create a FixedDecimal, a true representation would be length = 3 and
		/// decimalPositions = 1.  If "forceDecimalPositions" is true, this is the result you will get.  However,
		/// if "forceDecimalPositions" is false, then the Constructor will evaluate the value of the number of
		/// decimal positions and if the value is 0, then it will create an instance with length = 2 and
		/// decimalPositions = 0.
		/// </para>
		/// <para>Always allows negative values.</para>
		/// </remarks>
		/// <param name="dec">The decimal value on which to base this instance.</param>
		/// <param name="forceDecimalPositions">Determines whether or not the number of decimal
		/// positions is forced to the length of the decimals.</param>
		public FixedDecimal(decimal dec, bool forceDecimalPositions)
		{
			string s = dec.ToString();
			string[] parts = s.Split(new char[] { '.' });
			int left = Convert.ToInt32(parts[0]);
			int right = 0;
			if (parts.Length > 1)
			{
				right = Convert.ToInt32(parts[1]);
			}
			this.length = parts[0].Length;

			if (forceDecimalPositions)
			{
				if (parts.Length > 1)
				{
					this.decPos = parts[1].Length;
				}
				else
				{
					this.decPos = 0;
				}
				this.length += this.decPos;
			}
			else
			{
				if (right == 0)
				{
					this.decPos = 0;
				}
				else
				{
					this.decPos = parts[1].Length;
					this.length += this.decPos;
				}
			}

			this.allowNegatives = true;
			this.setValue(dec);
		}

		#endregion Constructors

		#region Properties

		/// <summary>
		/// The current decimal value of this FixedDecimal instance. (Read-only)
		/// </summary>
		public decimal Number
		{
			get
			{
				return this.number;
			}
		}

		/// <summary>
		/// The current decimal value of this FixedDecimal instance. (Read-only)
		/// </summary>
		public decimal Value
		{
			get
			{
				return this.number;
			}
		}

		/// <summary>
		/// The total length of this FixedDecimal instance. (Read-only)
		/// </summary>
		public int Length
		{
			get
			{
				return this.length;
			}
		}

		/// <summary>
		/// The number of decimal positions for this FixedDecimal instance. (Read-only)
		/// </summary>
		public int DecimalPositions
		{
			get
			{
				return this.decPos;
			}
		}

		/// <summary>
		/// The current value of this instance left of the decimal place. (Read-only)
		/// </summary>
		public long IntegerPortion
		{
			get
			{
				return this.integer;
			}
		}

		/// <summary>
		/// The current value of this instance right of the decimal place. (Read-only)
		/// This value is returned as a string to preserve leading zeros.
		/// </summary>
		public string DecimalPortion
		{
			get
			{
				return this.decimals;
			}
		}

		/// <summary>
		/// Gets or Sets the value of the allowNegatives behavior of this FixedDecimal instance.
		/// </summary>
		public bool AllowNegatives
		{
			get
			{
				return this.allowNegatives;
			}

			set
			{
				this.allowNegatives = value;
			}
		}

		/// <summary>
		/// Gets the maximum possible value for this FixedDecimal instance. (Read-only)
		/// </summary>
		public decimal MaxValue
		{
			get
			{
				StringBuilder s = new StringBuilder("");
				while (s.Length < (this.length - this.decPos))
				{
					s.Append("9");
				}
				if (this.decPos > 0)
				{
					s.Append(".");
					for (int i = 0; i < decPos; i++)
					{
						s.Append("9");
					}
				}
				return Convert.ToDecimal(s.ToString());
			}
		}

		/// <summary>
		/// Gets the minimum possible value for this FixedDecimal instance. (Read-only)
		/// This property will change based on the current value of AllowNegatives.
		/// </summary>
		public decimal MinValue
		{
			get
			{
				//StringBuilder s = new StringBuilder( "" );
				decimal d = 0;
				if (this.allowNegatives)
				{
					d = this.MaxValue * -1;
				}
				return d;
				/*					s.Append( "-" + this.MaxValue );
									while ( s.Length < ( this.length - this.decPos ) )
									{
										s.Append( "9" );
									}
									if ( this.decPos > 0 )
									{
										s.Append( "." );
										for ( int i=0 ; i < decPos ; i++ )
										{
											s.Append( "9" );
										}
									}
								}
								else
								{
									s.Append( this.zeroFill( s.ToString() , this.length - this.decPos , true ) );
									s.Append( "." );
									s.Append( this.zeroFill( "" , this.decPos , true ) );
								}
								return Convert.ToDecimal( s.ToString() );
				 */
			}
		}

		#endregion Properties

		#region Public Methods

		/// <summary>
		/// Sets the numeric value of this FixedDecimal instance.
		///
		/// Throws an ArgumentOutOfRangeException if the value is less than the current MinValue or
		/// greater than the current MaxValue.
		/// </summary>
		/// <param name="dec">The decimal used to set the instance value.</param>
		public void setValue(FixedDecimal dec)
		{
			if (!this.checkValue(dec.Number))
			{
				throw new ArgumentOutOfRangeException("dec", dec,
					"Decimal value is either greater than the current MaxValue " +
					"or less then the current MinValue of this instance.");
			}
			else
			{
				this.setValue(dec.ToString());
			}
		}

		/// <summary>
		/// Sets the numeric value of this FixedDecimal instance.
		///
		/// Throws an ArgumentOutOfRangeException if the value is less than the current MinValue or
		/// greater than the current MaxValue.
		/// </summary>
		/// <param name="dec">The decimal used to set the instance value.</param>
		public void setValue(decimal dec)
		{
			if (!this.checkValue(dec))
			{
				throw new ArgumentOutOfRangeException("dec", dec,
					"Decimal value is either greater than the current MaxValue " +
					"or less then the current MinValue of this instance.");
			}
			else
			{
				this.setValue(dec.ToString());
			}
		}

		/// <summary>
		/// Sets the numeric value of this FixedDecimal instance.
		///
		/// Throws an ArgumentOutOfRangeException if the value is less than the current MinValue or
		/// greater than the current MaxValue.
		/// </summary>
		/// <param name="i">The integer used to set the instance value.</param>
		public void setValue(int i)
		{
			if (i > this.MaxValue || i < this.MinValue)
			{
				throw new ArgumentOutOfRangeException("i", i,
					"Integer value is either greater than the current MaxValue " +
					"or less then the current MinValue of this instance.");
			}
			else
			{
				this.setValue(i.ToString());
			}
		}

		/// <summary>
		/// Sets the numeric value of this FixedDecimal instance.
		///
		/// Throws an ArgumentOutOfRangeException if the value is less than the current MinValue or
		/// greater than the current MaxValue.
		/// </summary>
		/// <param name="l">The integer used to set the instance value.</param>
		public void setValue(long l)
		{
			if (l > this.MaxValue || l < this.MinValue)
			{
				throw new ArgumentOutOfRangeException("l", l,
					"Long value is either greater than the current MaxValue " +
					"or less then the current MinValue of this instance.");
			}
			else
			{
				this.setValue(l.ToString());
			}
		}

		/// <summary>
		/// Sets the numeric value of this FixedDecimal instance.
		///
		/// Throws an ArgumentOutOfRangeException if the value is less than the current MinValue or
		/// greater than the current MaxValue.
		/// </summary>
		/// <param name="f">The float used to set the instance value.  The decimals are rounded and
		/// truncated to fit the current size of this instance.</param>
		public void setValue(float f)
		{
			if (!this.checkValue(Convert.ToDecimal(f)))
			{
				throw new ArgumentOutOfRangeException("f", f,
					"Float value is either greater than the current MaxValue " +
					"or less then the current MinValue of this instance.");
			}
			else
			{
				this.setValue(f.ToString());
			}
		}

		/// <summary>
		/// Sets the numeric value of this FixedDecimal instance.
		///
		/// Throws an ArgumentOutOfRangeException if the value is less than the current MinValue or
		/// greater than the current MaxValue.
		/// </summary>
		/// <param name="d">The double used to set the instance value.  The decimals are rounded and
		/// truncated to fit the current size of this instance.</param>
		public void setValue(double d)
		{
			if (!this.checkValue(Convert.ToDecimal(d)))
			{
				throw new ArgumentOutOfRangeException("d", d,
					"Double value is either greater than the current MaxValue " +
					"or less then the current MinValue of this instance.");
			}
			else
			{
				this.setValue(d.ToString());
			}
		}

		/// <summary>
		/// Sets the numeric value of this FixedDecimal instance.
		///
		/// Throws an ArgumentOutOfRangeException if the value is less than the current MinValue or
		/// greater than the current MaxValue.
		///
		/// Throws a FormatException if the string does not contain valid numeric data.
		///
		/// Throws an ArgumentException if the string is blank or null.
		/// </summary>
		/// <param name="s">The string used to set the instance value.  The decimals are rounded and
		/// truncated to fit the current size of this instance.</param>
		public void setValue(string s)
		{
			s = s.Trim();

			double d;
			try
			{
				if ("".Equals(s))
				{
					d = 0;
					s = "0";
				}
				else
				{
					d = Convert.ToDouble(s);
				}
			}
			catch (FormatException fe)
			{
				throw fe;
			}

			if (!this.checkValue(Convert.ToDecimal(d)))
			{
				throw new ArgumentOutOfRangeException("d", d,
					"String resolves to a value that is either greater than the current MaxValue " +
					"or less then the current MinValue of this instance.");
			}
			else
			{
				string num;
				string[] parts = s.Split(new char[] { '.' });
				if (parts.Length == 0 || parts.Length > 2)
				{
					throw new ArgumentException("String not usable as a numeric value.");
				}
				else
				{
					decimal dec = Decimal.Parse(s);
					dec = Decimal.Round(dec, this.decPos);

					string decStr = dec.ToString();
					parts = decStr.Split(new char[] { '.' });

					num = parts[0];
					this.integer = Convert.ToInt64(num);

					if (parts.Length == 1)
					{
						// this.decimals = 0 ;
						this.decimals = this.zeroFill("0", this.decPos, true);
					}
					else if (parts.Length == 2)
					{
						if (parts[1].Length < this.decPos)
						{
							//this.decimals = Convert.ToInt32( this.zeroFill( parts[1] , this.decPos , true ) );
							this.decimals = this.zeroFill(parts[1], this.decPos, true);
						}
						else if (parts[1].Length == this.decPos)
						{
							this.decimals = parts[1];
						}
						else
						{
							this.decimals = parts[1].Substring(0, this.decPos);
						}
						num += "." + this.decimals.ToString();
					}
					this.number = decimal.Parse(num);
				}
			}
		}

		/// <summary>
		/// Check the decimal value to see if it fits within the current instance parameters.
		/// Includes rounding if necessary.
		/// </summary>
		/// <param name="dec">The decimal value to check.</param>
		/// <returns>A boolean value: TRUE means the value fits within current parameters and
		/// FALSE when it falls outside the range.</returns>
		public bool checkValue(decimal dec)
		{
			bool isOK = true;
			dec = Decimal.Round(dec, this.decPos);

			if (dec > this.MaxValue || dec < this.MinValue)
			{
				isOK = false;
			}
			return isOK;
		}

		/// <summary>
		/// Check the FixedDecimal value to see if it fits within the current instance parameters.
		/// Includes rounding if necessary.
		/// </summary>
		/// <param name="fd">The FixedDecimal value to check.</param>
		/// <returns>A boolean value: TRUE means the value fits within current parameters and
		/// FALSE when it falls outside the range.</returns>
		public bool checkValue(FixedDecimal fd)
		{
			return this.checkValue(fd.Number);
		}

		/// <summary>
		/// Check the integer value to see if it fits within the current instance parameters.
		/// Includes rounding if necessary.
		/// </summary>
		/// <param name="i">The integer value to check.</param>
		/// <returns>A boolean value: TRUE means the value fits within current parameters and
		/// FALSE when it falls outside the range.</returns>
		public bool checkValue(int i)
		{
			return this.checkValue(Convert.ToDecimal(i));
		}

		/// <summary>
		/// Check the long value to see if it fits within the current instance parameters.
		/// Includes rounding if necessary.
		/// </summary>
		/// <param name="l">The long value to check.</param>
		/// <returns>A boolean value: TRUE means the value fits within current parameters and
		/// FALSE when it falls outside the range.</returns>
		public bool checkValue(long l)
		{
			return this.checkValue(Convert.ToDecimal(l));
		}

		/// <summary>
		/// Check the float value to see if it fits within the current instance parameters.
		/// Includes rounding if necessary.
		/// </summary>
		/// <param name="f">The float value to check.</param>
		/// <returns>A boolean value: TRUE means the value fits within current parameters and
		/// FALSE when it falls outside the range.</returns>
		public bool checkValue(float f)
		{
			return this.checkValue(Convert.ToDecimal(f));
		}

		/// <summary>
		/// Check the double value to see if it fits within the current instance parameters.
		/// Includes rounding if necessary.
		/// </summary>
		/// <param name="d">The double value to check.</param>
		/// <returns>A boolean value: TRUE means the value fits within current parameters and
		/// FALSE when it falls outside the range.</returns>
		public bool checkValue(double d)
		{
			return this.checkValue(Convert.ToDecimal(d));
		}

		/// <summary>
		/// Check the string value to see if it fits within the current instance parameters.
		/// Includes rounding if necessary.
		/// </summary>
		/// <param name="s">The string value to check.</param>
		/// <returns>A boolean value: TRUE means the value fits within current parameters and
		/// FALSE when it falls outside the range, or the string is blank or null.</returns>
		public bool checkValue(string s)
		{
			bool isOK = false;
			double d;
			try
			{
				d = Convert.ToDouble(s);
				isOK = this.checkValue(d);
			}
			catch (FormatException fe)
			{
				Console.WriteLine(string.Format("{0}", fe.Message));
			}
			return isOK;
		}

		/// <summary>
		/// Adds the passed value to the current value.
		///
		/// Throws an OverflowException if the resulting value would be outside the bounds
		/// of the instance's current configurtation.
		/// </summary>
		/// <param name="dec">The value to add to this value.</param>
		/// <returns>The adjusted decimal value.</returns>
		public decimal add(decimal dec)
		{
			if (!this.checkValue(Decimal.Add(this.number, dec)))
			{
				throw new OverflowException("Resulting decimal would overflow the bounds of the current " +
					"FixedDecimal configuration.");
			}
			else
			{
				this.setValue(Decimal.Add(this.number, dec));
			}
			return this.Number;
		}

		/// <summary>
		/// Adds the passed value to the current value.
		///
		/// Throws an OverflowException if the resulting value would be outside the bounds
		/// of the instance's current configurtation.
		/// </summary>
		/// <param name="dec">The int to add to this value.</param>
		/// <returns>The adjusted decimal value.</returns>
		public decimal add(int i)
		{
			return this.add(Convert.ToDecimal(i));
		}

		/// <summary>
		/// Adds the passed value to the current value.
		///
		/// Throws an OverflowException if the resulting value would be outside the bounds
		/// of the instance's current configurtation.
		/// </summary>
		/// <param name="dec">The int to add to this value.</param>
		/// <returns>The adjusted decimal value.</returns>
		public decimal add(long l)
		{
			return this.add(Convert.ToDecimal(l));
		}

		/// <summary>
		/// Adds the passed value to the current value.
		///
		/// Throws an OverflowException if the resulting value would be outside the bounds
		/// of the instance's current configurtation.
		/// </summary>
		/// <param name="dec">The int to add to this value.</param>
		/// <returns>The adjusted decimal value.</returns>
		public decimal add(float f)
		{
			return this.add(Convert.ToDecimal(f));
		}

		/// <summary>
		/// Adds the passed value to the current value.
		///
		/// Throws an OverflowException if the resulting value would be outside the bounds
		/// of the instance's current configurtation.
		/// </summary>
		/// <param name="dec">The int to add to this value.</param>
		/// <returns>The adjusted decimal value.</returns>
		public decimal add(double d)
		{
			return this.add(Convert.ToDecimal(d));
		}

		/// <summary>
		/// Adds the passed value to the current value.
		///
		/// Throws an OverflowException if the resulting value would be outside the bounds
		/// of the instance's current configurtation.
		/// </summary>
		/// <param name="dec">The int to add to this value.</param>
		/// <returns>The adjusted decimal value.</returns>
		public decimal add(FixedDecimal fd)
		{
			return this.add(fd.Number);
		}

		/// <summary>
		/// Adds the passed value to the current value.
		///
		/// Throws an OverflowException if the resulting value would be outside the bounds
		/// of the instance's current configurtation.
		/// </summary>
		/// <param name="dec">The int to add to this value.</param>
		/// <returns>The adjusted decimal value.</returns>
		public decimal add(string s)
		{
			return this.add(Convert.ToDecimal(s));
		}

		/// <summary>
		/// Subtracts the passed value from the current value.
		///
		/// Throws an OverflowException if the resulting value would be outside the bounds
		/// of the instance's current configurtation.
		/// </summary>
		/// <param name="dec">The value to subtract from this value.</param>
		/// <returns>The adjusted decimal value.</returns>
		public decimal subtract(decimal dec)
		{
			if (!this.checkValue(Decimal.Subtract(this.number, dec)))
			{
				throw new OverflowException("Resulting decimal would overflow the bounds of the current " +
					"FixedDecimal configuration.");
			}
			else
			{
				this.setValue(Decimal.Subtract(this.number, dec));
			}
			return this.Number;
		}

		/// <summary>
		/// Subtracts the passed value from the current value.
		///
		/// Throws an OverflowException if the resulting value would be outside the bounds
		/// of the instance's current configurtation.
		/// </summary>
		/// <param name="dec">The value to subtract from this value.</param>
		/// <returns>The adjusted decimal value.</returns>
		public decimal subtract(int i)
		{
			return this.subtract(Convert.ToDecimal(i));
		}

		/// <summary>
		/// Subtracts the passed value from the current value.
		///
		/// Throws an OverflowException if the resulting value would be outside the bounds
		/// of the instance's current configurtation.
		/// </summary>
		/// <param name="dec">The value to subtract from this value.</param>
		/// <returns>The adjusted decimal value.</returns>
		public decimal subtract(long l)
		{
			return this.subtract(Convert.ToDecimal(l));
		}

		/// <summary>
		/// Subtracts the passed value from the current value.
		///
		/// Throws an OverflowException if the resulting value would be outside the bounds
		/// of the instance's current configurtation.
		/// </summary>
		/// <param name="dec">The value to subtract from this value.</param>
		/// <returns>The adjusted decimal value.</returns>
		public decimal subtract(float f)
		{
			return this.subtract(Convert.ToDecimal(f));
		}

		/// <summary>
		/// Subtracts the passed value from the current value.
		///
		/// Throws an OverflowException if the resulting value would be outside the bounds
		/// of the instance's current configurtation.
		/// </summary>
		/// <param name="dec">The value to subtract from this value.</param>
		/// <returns>The adjusted decimal value.</returns>
		public decimal subtract(double d)
		{
			return this.subtract(Convert.ToDecimal(d));
		}

		/// <summary>
		/// Subtracts the passed value from the current value.
		///
		/// Throws an OverflowException if the resulting value would be outside the bounds
		/// of the instance's current configurtation.
		/// </summary>
		/// <param name="dec">The value to subtract from this value.</param>
		/// <returns>The adjusted decimal value.</returns>
		public decimal subtract(string s)
		{
			return this.subtract(Convert.ToDecimal(s));
		}

		/// <summary>
		/// Subtracts the passed value from the current value.
		///
		/// Throws an OverflowException if the resulting value would be outside the bounds
		/// of the instance's current configurtation.
		/// </summary>
		/// <param name="dec">The value to subtract from this value.</param>
		/// <returns>The adjusted decimal value.</returns>
		public decimal subtract(FixedDecimal fd)
		{
			return this.subtract(fd.Number);
		}

		/// <summary>
		/// Multiplies the passed value with the current value.
		///
		/// Throws an OverflowException if the resulting value would be outside the bounds
		/// of the instance's current configurtation.
		/// </summary>
		/// <param name="dec">The value to multiply with this value.</param>
		/// <returns>The adjusted decimal value.</returns>
		public decimal multiply(decimal dec)
		{
			if (!this.checkValue(Decimal.Multiply(this.number, dec)))
			{
				throw new OverflowException("Resulting decimal would overflow the bounds of the current " +
					"FixedDecimal configuration.");
			}
			else
			{
				this.setValue(Decimal.Multiply(this.number, dec));
			}
			return this.Number;
		}

		/// <summary>
		/// Multiplies the passed value with the current value.
		///
		/// Throws an OverflowException if the resulting value would be outside the bounds
		/// of the instance's current configurtation.
		/// </summary>
		/// <param name="dec">The value to multiply with this value.</param>
		/// <returns>The adjusted decimal value.</returns>
		public decimal multiply(int i)
		{
			return this.multiply(Convert.ToDecimal(i));
		}

		/// <summary>
		/// Multiplies the passed value with the current value.
		///
		/// Throws an OverflowException if the resulting value would be outside the bounds
		/// of the instance's current configurtation.
		/// </summary>
		/// <param name="dec">The value to multiply with this value.</param>
		/// <returns>The adjusted decimal value.</returns>
		public decimal multiply(long l)
		{
			return this.multiply(Convert.ToDecimal(l));
		}

		/// <summary>
		/// Multiplies the passed value with the current value.
		///
		/// Throws an OverflowException if the resulting value would be outside the bounds
		/// of the instance's current configurtation.
		/// </summary>
		/// <param name="dec">The value to multiply with this value.</param>
		/// <returns>The adjusted decimal value.</returns>
		public decimal multiply(float f)
		{
			return this.multiply(Convert.ToDecimal(f));
		}

		/// <summary>
		/// Multiplies the passed value with the current value.
		///
		/// Throws an OverflowException if the resulting value would be outside the bounds
		/// of the instance's current configurtation.
		/// </summary>
		/// <param name="dec">The value to multiply with this value.</param>
		/// <returns>The adjusted decimal value.</returns>
		public decimal multiply(double d)
		{
			return this.multiply(Convert.ToDecimal(d));
		}

		/// <summary>
		/// Multiplies the passed value with the current value.
		///
		/// Throws an OverflowException if the resulting value would be outside the bounds
		/// of the instance's current configurtation.
		/// </summary>
		/// <param name="dec">The value to multiply with this value.</param>
		/// <returns>The adjusted decimal value.</returns>
		public decimal multiply(string s)
		{
			return this.multiply(Convert.ToDecimal(s));
		}

		/// <summary>
		/// Multiplies the passed value with the current value.
		///
		/// Throws an OverflowException if the resulting value would be outside the bounds
		/// of the instance's current configurtation.
		/// </summary>
		/// <param name="dec">The value to multiply with this value.</param>
		/// <returns>The adjusted decimal value.</returns>
		public decimal multiply(FixedDecimal fd)
		{
			return this.multiply(fd.Number);
		}

		/// <summary>
		/// Divides the current value by the passed value.
		///
		/// Throws an OverflowException if the resulting value would be outside the bounds
		/// of the instance's current configuration.
		/// </summary>
		/// <param name="dec">The value by which to divide this value.</param>
		/// <returns>The adjusted decimal value.</returns>
		public decimal divide(decimal dec)
		{
			if (!this.checkValue(Decimal.Divide(this.number, dec)))
			{
				throw new OverflowException("Resulting decimal would overflow the bounds of the current " +
					"FixedDecimal configuration.");
			}
			else
			{
				this.setValue(Decimal.Divide(this.number, dec));
			}
			return this.Number;
		}

		/// <summary>
		/// Divides the current value by the passed value.
		///
		/// Throws an OverflowException if the resulting value would be outside the bounds
		/// of the instance's current configuration.
		/// </summary>
		/// <param name="dec">The value by which to divide this value.</param>
		/// <returns>The adjusted decimal value.</returns>
		public decimal divide(int i)
		{
			return this.divide(Convert.ToDecimal(i));
		}

		/// <summary>
		/// Divides the current value by the passed value.
		///
		/// Throws an OverflowException if the resulting value would be outside the bounds
		/// of the instance's current configuration.
		/// </summary>
		/// <param name="dec">The value by which to divide this value.</param>
		/// <returns>The adjusted decimal value.</returns>
		public decimal divide(long l)
		{
			return this.divide(Convert.ToDecimal(l));
		}

		/// <summary>
		/// Divides the current value by the passed value.
		///
		/// Throws an OverflowException if the resulting value would be outside the bounds
		/// of the instance's current configuration.
		/// </summary>
		/// <param name="dec">The value by which to divide this value.</param>
		/// <returns>The adjusted decimal value.</returns>
		public decimal divide(float f)
		{
			return this.divide(Convert.ToDecimal(f));
		}

		/// <summary>
		/// Divides the current value by the passed value.
		///
		/// Throws an OverflowException if the resulting value would be outside the bounds
		/// of the instance's current configuration.
		/// </summary>
		/// <param name="dec">The value by which to divide this value.</param>
		/// <returns>The adjusted decimal value.</returns>
		public decimal divide(double d)
		{
			return this.divide(Convert.ToDecimal(d));
		}

		/// <summary>
		/// Divides the current value by the passed value.
		///
		/// Throws an OverflowException if the resulting value would be outside the bounds
		/// of the instance's current configuration.
		/// </summary>
		/// <param name="dec">The value by which to divide this value.</param>
		/// <returns>The adjusted decimal value.</returns>
		public decimal divide(string s)
		{
			return this.divide(Convert.ToDecimal(s));
		}

		/// <summary>
		/// Divides the current value by the passed value.
		///
		/// Throws an OverflowException if the resulting value would be outside the bounds
		/// of the instance's current configuration.
		/// </summary>
		/// <param name="dec">The value by which to divide this value.</param>
		/// <returns>The adjusted decimal value.</returns>
		public decimal divide(FixedDecimal fd)
		{
			return this.divide(fd.Number);
		}

		/// <summary>
		/// Gets the string representation of the FixedDecimal with no zero padding.
		///
		/// <code>
		/// FixedDecimal fd = new FixedDecimal(5,3);
		/// fd.setValue( "3.45" );
		/// string s = fd.ToString(); // s = "3.45"
		/// </code>
		///
		/// Equivelant to toString( false , false );
		/// </summary>
		/// <returns>The string representation of the FixedDecimal.</returns>
		public override string ToString()
		{
			return this.toString(false, false);
		}

		/// <summary>
		/// Gets the string representation of the FixedDecimal.  Applies padding to the integer portion
		/// and/or the decimal portion of the string.
		///
		/// <code>
		/// FixedDecimal fd = new FixedDecimal(5,3);
		/// fd.setValue( "32.45" );
		/// string s ;
		/// s = fd.toString( false , false ); // s = "3.45"
		/// s = fd.toString( false , true ); // s = "3.450"
		/// s = fd.toString( true , false ); // s = "03.45"
		/// s = fd.toString( true , true ); // s = "03.450"
		/// </code>
		/// </summary>
		/// <param name="padInteger">Indicates whether or not to pad the integer portion of the
		/// FixedDecimal with zeros.</param>
		/// <param name="padDecimals">Indicates whether or not to pad the decimal portion of the
		/// FixedDecimal with zeros.</param>
		/// <returns>The string representation of the FixedDecimal.</returns>
		public string toString(bool padInteger, bool padDecimals)
		{
			StringBuilder num = new StringBuilder();
			if (this.number < 0)
			{
				num.Append("-");
			}
			if (padInteger)
			{
				num.Append(this.zeroFill(this.integer.ToString(), this.length - this.decPos, false));
			}
			else
			{
				num.Append(this.integer);
			}
			if (decPos > 0)
			{
				num.Append(".");
				if (padDecimals)
				{
					num.Append(this.zeroFill(this.decimals.ToString(), this.decPos, true));
				}
				else
				{
					num.Append(this.decimals);
				}
			}
			return num.ToString();
		}

		#endregion Public Methods

		#region Private Methods

		private string zeroFill(string str, int size, bool end)
		{
			StringBuilder s = new StringBuilder(str);
			if (end)
			{
				while (s.ToString().Length < size)
				{
					s.Append("0");
				}
			}
			else
			{
				while (s.ToString().Length < size)
				{
					if (this.number < 0)
					{
						s.Insert(1, "0");
					}
					else
					{
						s.Insert(0, "0");
					}
				}
			}
			return s.ToString();
		}

		#endregion Private Methods
	}
}