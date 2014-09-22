using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// references to configuration namespaces (required in all examples)
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Unity;
using Microsoft.Practices.Unity;

// references to application block namespace(s) for these examples
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.Database;
using Microsoft.Practices.EnterpriseLibrary.Logging.Filters;
using Microsoft.Practices.EnterpriseLibrary.Logging.ExtraInformation;

namespace LoggingExample
{
	public class TracerDemo
	{
		public void CreateTracedLogEntries()
		{
			LogWriter theWriter = EnterpriseLibraryContainer.Current.GetInstance<LogWriter>();
			TraceManager traceMgr = EnterpriseLibraryContainer.Current.GetInstance<TraceManager>();
			using (traceMgr.StartTrace("DiskFiles"))
			{
				// Create and write a log entry with another category - it will be assigned to both.
				theWriter.Write("LogEntry with category 'General' created within context of 'DiskFiles' category TraceManager.", "General");
				Console.WriteLine("Written LogEntry with category 'General' created within context of 'DiskFiles' category TraceManager.");
				Console.WriteLine();
				// Start tracing for the category 'Database' within the context of the 'General' TraceManager.
				using (traceMgr.StartTrace("Database"))
				//using (traceMgr.StartTrace("Database", new Guid("{12345678-1234-1234-1234-123456789AAA}")))
				{
					// Create and write a log entry with another category - it will be assigned to all three.
					theWriter.Write("LogEntry with category 'Important' created within context of nested 'Database' category TraceManager.", "Important");
					Console.WriteLine("Written LogEntry with category 'Important' created within context of 'Database' category TraceManager nested within 'DiskFiles' category TraceManager.");
					Console.WriteLine();
				}
			}
		}
	}
}
