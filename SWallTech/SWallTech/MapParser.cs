using System;
using System.Collections;
using System.Text;

namespace SWallTech
{
	public class MapParser
	{
		public enum MapSegments
		{
			MAP,
			INSERT,
			DOUBLE_CIRCLE,
			BLOCK,
			LOT,
			SUBLOT
		}

		public static Hashtable ParseMap(MapConfig config, FixedString rawMap)
		{
			if (rawMap.Size != 20)
			{
				throw new ArgumentOutOfRangeException("Raw Map number must be defined as FixedDecimal(20).");
			}

			string map = rawMap.Text.Substring(0, Convert.ToInt32(config.MapLength.Number));

			string insert = "";
			if (config.InsertLength.Number > 0)
			{
				insert = rawMap.Text.Substring(Convert.ToInt32(config.InsertStartPoint.Number) - 1,
					Convert.ToInt32(config.InsertLength.Number));
			}

			string doubleCircle = "";
			if (config.DoubleCircleLength.Number > 0)
			{
				doubleCircle = rawMap.Text.Substring(Convert.ToInt32(config.DoubleCircleStartPoint.Number) - 1,
					Convert.ToInt32(config.DoubleCircleLength.Number));
			}

			string block = "";
			if (config.BlockLength.Number > 0)
			{
				block = rawMap.Text.Substring(Convert.ToInt32(config.BlockStartPoint.Number) - 1,
					Convert.ToInt32(config.BlockLength.Number));
			}

			string lot = "";
			if (config.LotLength.Number > 0)
			{
				lot = rawMap.Text.Substring(Convert.ToInt32(config.LotStartPoint.Number) - 1,
					Convert.ToInt32(config.LotLength.Number));
			}

			string sublot = "";
			if (config.SubLotLength.Number > 0)
			{
				sublot = rawMap.Text.Substring(Convert.ToInt32(config.SubLotStartPoint.Number) - 1,
					Convert.ToInt32(config.SubLotLength.Number));
			}

			Hashtable mapSegments = new Hashtable();
			mapSegments.Add(MapSegments.MAP, map);
			mapSegments.Add(MapSegments.INSERT, insert);
			mapSegments.Add(MapSegments.DOUBLE_CIRCLE, doubleCircle);
			mapSegments.Add(MapSegments.BLOCK, block);
			mapSegments.Add(MapSegments.LOT, lot);
			mapSegments.Add(MapSegments.SUBLOT, sublot);

			return mapSegments;
		}

		public static string BuildMapNumber(MapConfig config, string map)
		{
			return BuildMapNumber(config, map, "", "", "", "", "");
		}

		public static string BuildMapNumber(MapConfig config, string map, string insert)
		{
			return BuildMapNumber(config, map, insert, "", "", "", "");
		}

		public static string BuildMapNumber(MapConfig config, string map, string insert, string double_circle)
		{
			return BuildMapNumber(config, map, insert, double_circle, "", "", "");
		}

		public static string BuildMapNumber(MapConfig config, string map, string insert, string double_circle,
			string block)
		{
			return BuildMapNumber(config, map, insert, double_circle, block, "", "");
		}

		public static string BuildMapNumber(MapConfig config, string map, string insert, string double_circle,
			string block, string lot)
		{
			return BuildMapNumber(config, map, insert, double_circle, block, lot, "");
		}

		public static string BuildMapNumber(MapConfig config, string map, string insert, string double_circle,
			string block, string lot, string sublot)
		{
			if (map.Trim().Equals("") && insert.Trim().Equals("") && double_circle.Trim().Equals("")
				&& block.Trim().Equals("") && lot.Trim().Equals("") && sublot.Trim().Equals(""))
			{
				return "";
			}

			StringBuilder completeMap = new StringBuilder();

			map = AdjustString(map.Trim(), config.MapLength.Number,
				MapConfig.AdjustmentStyles.RIGHT, config.IsMapZeroFilled);
			completeMap.Append(map);

			if (config.MapSeparatorStartPoint.Value > 0)
			{
				completeMap.Insert(Convert.ToInt32(config.MapSeparatorStartPoint.Value - 1),
					config.MapSeparatorCharacter.Text);
			}

			if (config.InsertLength.Number > 0)
			{
				if (insert == null)
				{
					insert = "";
				}
				insert = AdjustString(insert.Trim(), config.InsertLength.Number,
					config.InsertAdjustment, config.IsInsertZeroFilled);
				completeMap.Append(insert);

				// Add Separator logic
			}

			if (config.DoubleCircleLength.Number > 0)
			{
				if (double_circle == null)
				{
					double_circle = "";
				}
				double_circle = AdjustString(double_circle.Trim(), config.DoubleCircleLength.Number,
					config.DoubleCircleAdjustment, config.IsDoubleCircleZeroFilled);
				completeMap.Append(double_circle);

				// Add Separator logic
			}

			if (config.BlockLength.Number > 0)
			{
				if (block == null)
				{
					block = "";
				}
				block = AdjustString(block.Trim(), config.BlockLength.Number,
					config.BlockAdjustment, config.IsBlockZeroFilled);
				completeMap.Append(block);

				// Add Separator logic
			}

			if (config.LotLength.Number > 0)
			{
				if (lot == null)
				{
					lot = "";
				}
				lot = AdjustString(lot.Trim(), config.LotLength.Number,
					config.LotAdjustment, config.IsLotZeroFilled);
				completeMap.Append(lot);

				// Add Separator logic
			}

			if (config.SubLotLength.Number > 0)
			{
				if (sublot == null)
				{
					sublot = "";
				}
				sublot = AdjustString(sublot.Trim(), config.SubLotLength.Number,
					config.SubLotAdjustment, config.IsSubLotZeroFilled);
				completeMap.Append(sublot);

				// Add Separator logic
			}

			return completeMap.ToString();
		}

		private static string AdjustString(string text, int length, MapConfig.AdjustmentStyles adjust, bool zeroFill)
		{
			while (text.Length < length)
			{
				string repChar = " ";
				if (zeroFill)
				{
					repChar = "0";
				}
				if (adjust == MapConfig.AdjustmentStyles.RIGHT)
				{
					text = repChar + text;
				}
				else if (adjust == MapConfig.AdjustmentStyles.LEFT)
				{
					text += repChar;
				}
			}
			return text;
		}

		private static string AdjustString(string text, decimal length, MapConfig.AdjustmentStyles adjust, bool zeroFill)
		{
			return AdjustString(text, Convert.ToInt32(length), adjust, zeroFill);
		}
	}
}