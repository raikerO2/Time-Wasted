using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using TimeWasted.Components;

namespace TimeWasted
{
	public partial class Form1 : Form
	{
		static string time = "";
		bool isPassed = false;
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//foreach (var x in Processes.ClosedProcesses())
			//{
			//	textBox1.Text += x.Key;
			//	textBox2.Text += x.Value;
			//}
			if (isPassed)
				textBox1.Text = time;

			if (!isPassed)
			{
				System.Diagnostics.Process process = new System.Diagnostics.Process();
				process.StartInfo.FileName = @"D:\Games\WOW\Wow.exe";
				process.EnableRaisingEvents = true;
				process.Exited += new EventHandler(myProcess_Exited);
				process.Start();
			}
		}

		//TO:DO / buggy.
		private void myProcess_Exited(object sender, EventArgs e)
		{
			time = DateTime.Now.ToString();
			isPassed = true;
			button1_Click(sender, e);
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
