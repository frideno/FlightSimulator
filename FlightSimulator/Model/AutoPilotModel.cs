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
		public void Clear()
		{
			CommandsTextBox = "";
		}

		public void ExceuteCommands()
		{
			IList<string> commands = new List<string>(CommandsTextBox.Split(newLine));
			// send each line to server, and wait 2 seconds. all in new thread.

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
