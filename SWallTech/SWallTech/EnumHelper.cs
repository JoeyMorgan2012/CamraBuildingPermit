using System;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace SWallTech
{
	public static class EnumHelper
	{
		public static String GetEnumDescription(Enum e)
		{
			FieldInfo EnumInfo = e.GetType().GetField(e.ToString());
			DescriptionAttribute[] EnumAttributes = (DescriptionAttribute[])EnumInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
			if (EnumAttributes.Length > 0)
			{
				return EnumAttributes[0].Description;
			}
			return e.ToString();
		}
	}

	public class InvalidEnumException : ApplicationException
	{
		private int enumValue;
		private Type enumType;

		public InvalidEnumException() : base("The referenced Enumerator value is Invalid.")
		{
		}

		public InvalidEnumException(string message) : base(message)
		{
		}

		public InvalidEnumException(int enumValue, Type enumType) : this("The referenced Enumerator value is Invalid. The referenced value is " + enumValue.ToString() +
				" the referenced Enum Type is " + enumType.ToString() + ".")
		{
			this.enumValue = enumValue;
			this.enumType = enumType;
		}

		public InvalidEnumException(string message, int enumValue, Type enumType) : this(message)
		{
			this.enumValue = enumValue;
			this.enumType = enumType;
		}

		public int EnumValue
		{
			get
			{
				return this.enumValue;
			}
		}

		public Type EnumType
		{
			get
			{
				return this.enumType;
			}
		}
	}
}