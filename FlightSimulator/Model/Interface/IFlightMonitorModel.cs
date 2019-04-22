using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model.Interface
{
    interface IFlightMonitorModel
    {
		IServer InfoChannel { get; }
		IClient CommandChannel { get; }
		IDictionary<string, double> InfoDataDictionary { get; set; }

		void ConnectToChannels();

		void DisconnectFromChannels();
    }
}
