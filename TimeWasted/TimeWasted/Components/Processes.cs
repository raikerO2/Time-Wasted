using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TimeWasted.Components
{
	public static class Processes
	{
		private static DateTime processStartup;

		public static int Count { get => ProcessesCount(); }

		public static List<string> ProcessNames = new List<string>
		{
			"wow",
			"chrome",
			"slack",
			"discord",
			"skype",
			"sourcetree"
		};

		private static List<Process> Active = new List<Process>();

		public static Process GetProcess(string name)
		{
			var process = Process.GetProcessesByName(name).FirstOrDefault();
			if (process == null)
				return null;

			return process;
		}

		private static int ProcessesCount()
		{
			var activeProcesses = new List<Process>();
			int count = 0;

			if(Active.Count == 0)
			activeProcesses = ActiveProcesses();

			activeProcesses = Active;
			foreach (var process in activeProcesses)
			{
				count++;
			}
			return count;
		}

		public static List<Process> ActiveProcesses()
		{
			foreach (var name in ProcessNames)
			{
				if(!(GetProcess(name) == null))
				Active.Add(GetProcess(name));
			}
			return Active;
		}

		public static Dictionary<string,DateTime> ClosedProcesses()
		{
			Dictionary<string, DateTime> Closed = new Dictionary<string, DateTime>();
			var activeProcesses = ActiveProcesses();

			foreach (var process in activeProcesses)
			{
				Closed.Add(process.ProcessName, process.ExitTime);
			}

			return Closed;
		}

	}
}
