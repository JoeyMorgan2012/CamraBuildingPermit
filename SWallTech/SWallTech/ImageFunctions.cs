using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace SWallTech
{
	public enum SizeTypes
	{
		KiloBytes = 1,
		MegaBytes,
		GigaBytes,
		TeraBytes,
		PetaBytes
	}

	public static class ImageFunctions
	{
		public static string CalculatePDirectory(int record)
		{
			string s = record.ToString().PadLeft(7, '0');
			return String.Format("P{0}", s.Substring(1, 3));
		}

		public static string GetPDirectory(string fileName)
		{
			return String.Format("P{0}", fileName.Substring(1, 3));
		}

		#region FileSize Stuff

		public static SizeTypes CalculateSizeType(long length)
		{
			if (length > FileTypeSize(SizeTypes.PetaBytes))
				return SizeTypes.PetaBytes;
			if (length > FileTypeSize(SizeTypes.TeraBytes))
				return SizeTypes.TeraBytes;
			if (length > FileTypeSize(SizeTypes.GigaBytes))
				return SizeTypes.GigaBytes;
			if (length > FileTypeSize(SizeTypes.MegaBytes))
				return SizeTypes.MegaBytes;
			else
				return SizeTypes.KiloBytes;
		}

		public static string FileSizeAsString(FileInfo file, SizeTypes st)
		{
			return FileSizeAsString(file, st, 2);
		}

		public static string FileSizeAsString(FileInfo file, SizeTypes st, int decimalPositions)
		{
			return FileSizeAsString(file.Length, st, decimalPositions);
		}

		public static string FileSizeAsString(long fileLength, SizeTypes st, int decimalPositions)
		{
			decimal fileSize = Convert.ToDecimal(fileLength) /
				Convert.ToDecimal(FileTypeSize(st));

			return String.Format("{0} {1}",
				Decimal.Round(fileSize, decimalPositions),
				FileTypeAbbreviation(st));
		}

		public static string FileSizeAsString(long fileLength, int decimalPositions)
		{
			var st = CalculateSizeType(fileLength);
			decimal fileSize = Convert.ToDecimal(fileLength) /
				Convert.ToDecimal(FileTypeSize(st));

			return String.Format("{0} {1}",
				Decimal.Round(fileSize, decimalPositions),
				FileTypeAbbreviation(st));
		}

		public static string FileTypeAbbreviation(SizeTypes st)
		{
			string abb = String.Empty;
			switch (st)
			{
				case SizeTypes.KiloBytes:
					abb = "KB";
					break;

				case SizeTypes.MegaBytes:
					abb = "MB";
					break;

				case SizeTypes.GigaBytes:
					abb = "GB";
					break;

				case SizeTypes.TeraBytes:
					abb = "TB";
					break;

				case SizeTypes.PetaBytes:
					abb = "PB";
					break;
			}

			return abb;
		}

		public static long FileTypeSize(SizeTypes st)
		{
			return Convert.ToInt64(Math.Pow(1024d, Convert.ToDouble((int)st)));
		}

		#endregion FileSize Stuff

		#region GetImageList

		public static List<FileInfo> GetImageList(string directoryPath)
		{
			return GetImageList(directoryPath, "*.*");
		}

		public static List<FileInfo> GetImageList(DirectoryInfo dir)
		{
			return GetImageList(dir, "*.*", false);
		}

		public static List<FileInfo> GetImageList(string directoryPath, string pattern)
		{
			return GetImageList(new DirectoryInfo(directoryPath), pattern, false);
		}

		public static List<FileInfo> GetImageList(DirectoryInfo dir, string pattern, bool includeSubdirectories)
		{
			List<FileInfo> list = new List<FileInfo>();
			if (includeSubdirectories)
			{
				list.AddRange(dir.GetFiles(pattern, SearchOption.AllDirectories));
			}
			else
			{
				list.AddRange(dir.GetFiles(pattern, SearchOption.TopDirectoryOnly));
			}
			return list;
		}

		#endregion GetImageList

		#region ResizeImages

		public static event EventHandler<ImageResizedEventArgs> ImageResized;

		public static event EventHandler<EventArgs> ResizeImagesBeginning;

		public static event EventHandler<ResizeImagesCompleteEventArgs> ResizeImagesComplete;

		public static event EventHandler<ErrorEncounteredEventArgs> ResizeImagesEncounteredError;

		public static event EventHandler<EventArgs> RetrieveImageListBeginning;

		// Found on the web
		public static Image ResizeImage(Image imgPhoto, int Width, int Height)
		{
			int sourceWidth = imgPhoto.Width;
			int sourceHeight = imgPhoto.Height;

			if (sourceWidth <= Width || sourceHeight <= Height)
			{
				var ex = new ArgumentOutOfRangeException("Cannot resize to larger than original image size.");
				throw ex;
			}

			int sourceX = 0;
			int sourceY = 0;
			int destX = 0;
			int destY = 0;

			float nPercent = 0;
			float nPercentW = 0;
			float nPercentH = 0;

			nPercentW = ((float)Width / (float)sourceWidth);
			nPercentH = ((float)Height / (float)sourceHeight);
			if (nPercentH < nPercentW)
			{
				nPercent = nPercentH;

				//destX = System.Convert.ToInt16((Width -
				//              (sourceWidth * nPercent)) / 2);
			}
			else
			{
				nPercent = nPercentW;

				//destY = System.Convert.ToInt16((Height -
				//              (sourceHeight * nPercent)) / 2);
			}

			int destWidth = (int)(sourceWidth * nPercent);
			int destHeight = (int)(sourceHeight * nPercent);

			//Bitmap bmPhoto = new Bitmap(Width, Height,
			Bitmap bmPhoto = new Bitmap(destWidth, destHeight,
							  PixelFormat.Format24bppRgb);
			bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
							 imgPhoto.VerticalResolution);

			Graphics grPhoto = Graphics.FromImage(bmPhoto);
			grPhoto.Clear(Color.Black);
			grPhoto.InterpolationMode =
					InterpolationMode.HighQualityBicubic;

			grPhoto.DrawImage(imgPhoto,
				new Rectangle(destX, destY, destWidth, destHeight),
				new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
				GraphicsUnit.Pixel);

			grPhoto.Dispose();
			return bmPhoto;
		}

		public static int ResizeImages(DirectoryInfo sourceImageDirectory,
					DirectoryInfo targetDirectory,
			int width,
			int height,
			string extension,
			bool includeSubfolders)
		{
			return ResizeImages(sourceImageDirectory, targetDirectory, width, height, extension, includeSubfolders, false);
		}

		public static int ResizeImages(DirectoryInfo sourceImageDirectory,
			DirectoryInfo targetDirectory,
			int width,
			int height,
			string extension,
			bool includeSubfolders,
			bool forceFileNameToLowerCase)
		{
			if (ResizeImagesBeginning != null)
				ResizeImagesBeginning(null, new EventArgs());

			int imageCount = 0;

			if (!extension.StartsWith("."))
			{
				extension = String.Format(".{0}", extension);
			}
			string pattern = String.Format("*{0}", extension);

			if (RetrieveImageListBeginning != null)
				RetrieveImageListBeginning(null, new EventArgs());

			var images = from f in GetImageList(sourceImageDirectory, pattern, includeSubfolders)
						 where f.Extension.Equals(extension, StringComparison.InvariantCultureIgnoreCase)
						 select f;

			foreach (var file in images)
			{
				if (extension.Equals(file.Extension, StringComparison.InvariantCultureIgnoreCase))
				{
					try
					{
						using (Image img = new Bitmap(file.FullName))
						{
							string name = String.Empty;

							if (includeSubfolders)
							{
								string newPath = String.Format(@"{0}\{1}", targetDirectory, file.Directory.Name);
								if (!Directory.Exists(newPath))
								{
									Directory.CreateDirectory(newPath);
								}
								name = String.Format(@"{0}\{1}",
									newPath,
									forceFileNameToLowerCase ? file.Name.ToLower() : file.Name);
							}
							else
							{
								name = String.Format(@"{0}\{1}",
									targetDirectory.FullName,
									forceFileNameToLowerCase ? file.Name.ToLower() : file.Name);
							}

							try
							{
								using (Image resizedImg = ResizeImage(img, width, height))
								{
									resizedImg.Save(name, ImageFormat.Jpeg);
								}
							}
							catch (System.ArgumentOutOfRangeException aex)
							{
								Console.WriteLine(string.Format("{0}", aex.Message));
								img.Save(name, ImageFormat.Jpeg);
							}
							finally
							{
								if (ImageResized != null)
									ImageResized(null, new ImageResizedEventArgs() { Name = name });

								imageCount++;
							}
						}
					}
					catch (Exception ex)
					{
						string exceptionsDir = String.Format(@"{0}\Exceptions", targetDirectory.FullName);
						if (!Directory.Exists(exceptionsDir))
						{
							Directory.CreateDirectory(exceptionsDir);
						}
						file.CopyTo(String.Format(@"{0}\{1}", exceptionsDir, file.Name));

						if (ResizeImagesEncounteredError != null)
							ResizeImagesEncounteredError(null, new ErrorEncounteredEventArgs() { Exception = ex, Message = ex.Message });
					}
				}
			}

			if (ResizeImagesComplete != null)
				ResizeImagesComplete(null, new ResizeImagesCompleteEventArgs() { ImagesResizedCount = imageCount });

			return imageCount;
		}

		#endregion ResizeImages

		#region Find Duplicates

		public static bool HasMultiplePictures(string picturePath,
			int record, int card)
		{
			string pattern = String.Format("{0}_{1}_*.jpg",
				record.ToString().PadLeft(7, '0'),
				card.ToString().PadLeft(2, '0'));

			string folderPath = String.Format("{0}\\{1}",
				picturePath,
				GetPDirectory(pattern));

			return ImageFunctions.GetImageList(folderPath, pattern).Count() > 1;
		}

		public static List<FileInfo> MultipleImages(string picturePath)
		{
			var allImages = GetImageList(picturePath, "*_01.jpg");
			List<FileInfo> multiples = new List<FileInfo>();
			allImages.ForEach(f =>
				{
					CamraImageName name = CamraImageName.GetCamraImagename(f);
					if (HasMultiplePictures(picturePath, name.Record, name.Card))
					{
						multiples.Add(f);
					}
				});
			return multiples;
		}

		#endregion Find Duplicates
	}

	public class CamraImageName
	{
		public int Card
		{
			get; set;
		}

		public int Record
		{
			get; set;
		}

		public int Sequence
		{
			get; set;
		}

		public static CamraImageName GetCamraImagename(FileInfo file)
		{
			string[] parts = file.Name.Split(new char[] { '_' });
			CamraImageName nm = new CamraImageName()
			{
				Record = Convert.ToInt32(parts[0]),
				Card = Convert.ToInt32(parts[1]),
				Sequence = Convert.ToInt32(parts[2].Split(new char[] { '.' })[0])
			};

			return nm;
		}

		private CamraImageName()
		{
		}
	}
}