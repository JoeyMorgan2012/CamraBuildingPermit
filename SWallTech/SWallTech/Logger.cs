using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SWallTech
{
	public static class Logger
	{
		public static int lineNo = 1;

		public static void Error(string message, string module)
		{
			WriteEntry(message, "error", module);
		}

		public static void Error(Exception ex, string module)
		{
			string message = string.Format("Exception of type {0} occurred in {1}: {2}", ex.GetType().ToString(), module, ex.Message);
			WriteEntry(ex.Message, "error", module);
		}

		public static void Info(string message, string module)
		{
			WriteEntry(message, "info", module);
		}

		public static void Info(string logRecord)
		{
			Trace.WriteLine(
				   string.Format("{0}: {1}",
								 DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
								 logRecord));
		}

		public static void Info(StringBuilder logRecordBuilder)
		{
			Trace.WriteLine(
				   string.Format("{0}: {1}",
								 DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
								 logRecordBuilder.ToString()));
		}

		public static void TraceMessage(string message,
		[System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
		[System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
		[System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0,
		bool showMessage = false)
		{
			StringBuilder traceOut = new StringBuilder();
			traceOut.AppendLine(string.Format("{0}", ""));
			traceOut.AppendLine(string.Format("Member: {0} - Line: {1}", memberName, sourceLineNumber));

			traceOut.AppendLine(string.Format("Message: ", message));
			Trace.WriteLine(traceOut.ToString());
			if (showMessage)
			{
				MessageBox.Show(traceOut.ToString());
			}
		}

		public static void Warning(string message, string module)
		{
			WriteEntry(message, "warning", module);
		}

		public static void WriteFullTraceToLogWithLineNumbers(StackFrame[] fullStack)
		{
			StackFrame[] myFrames = fullStack.Where(f => f.GetFileLineNumber() > 0).ToArray<StackFrame>();
			StringBuilder traceOut = new StringBuilder();
			string callerCallee = string.Empty;
			int j = 0;
			int lineNo = 1;
			int loopCounter = myFrames.Length - 1 >= 20 ? 20 : myFrames.Length - 1;
			for (int i = loopCounter; i >= 0; i--)
			{
				var frame = myFrames[i];
				j = (i == myFrames.Length - 1 ? i : i + 1);

				var priorFrame = myFrames[j];

				callerCallee = string.Format("{0} Line {1} called by {2}", frame.GetMethod(), frame.GetFileLineNumber(), priorFrame.GetMethod());

				traceOut.AppendLine(string.Format("• {0} {1}", lineNo, callerCallee));
				lineNo++;
			}
			Trace.WriteLine(traceOut.ToString());
			Trace.Flush();
		}

		private static void WriteEntry(string message, string type, string module)
		{
			Trace.WriteLine(
					string.Format("{0},{1},{2},{3}",
								  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
								  type,
								  module,
								  message));
		}
	}
}