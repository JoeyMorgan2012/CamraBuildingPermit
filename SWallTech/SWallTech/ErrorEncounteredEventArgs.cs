using System;
using System.Text;

namespace SWallTech
{
	public class ErrorEncounteredEventArgs : EventArgs
	{
		public Exception Exception
		{
			get; set;
		}

		public string Message
		{
			get; set;
		}
	}
}