using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model.Interface
{
	interface IAutoPilotModel
	{
		string CommandsTextBox  { set; get; }
		void ExceuteCommands();

		void Clear();
	}
}
