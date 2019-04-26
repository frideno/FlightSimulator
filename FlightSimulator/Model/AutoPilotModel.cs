using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FlightSimulator.ViewModels;

namespace FlightSimulator.Model
{
	public class AutoPilotModel : IAutoPilotModel
	{
		public string CommandsTextBox { get; set; }

		char[] newLine;

		public AutoPilotModel()
		{
			newLine = new char[2];
			newLine[0] = '\r';
			newLine[1] = '\n';
			CommandsTextBox = "";

		}

		// Clears CommandsTextBox - logic behind: initilize it to empty string.

		public void Clear()
		{
			CommandsTextBox = "";
		}

		// Execute Commands - logic behind: splilt the command textbox by line, and iterate each line, and 
		// sends to the command channel the line, and sleeps for 2 seconds (2000 ms).

		public void ExceuteCommands()
		{
			IList<string> commands = new List<string>(CommandsTextBox.Split(newLine));

			foreach (string command in commands)
			{
				if (!command.Equals(""))
				{
					DataManager.Instance.CommandChannel.Send(command + "\r\n");
					Thread.Sleep(2000);
				}
			}

		}
	}
}
