using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeWasted.Components
{
	public class Startup
	{
		private DateTime timeStart;
		private bool isOn;

		public Startup()
		{
			if (!isOn)
			StartupPC();
		}

		private bool StartupPC()
		{
			timeStart = DateTime.Now;
			return isOn = true;
		}

		public DateTime Time { get => timeStart; }
	}
}
