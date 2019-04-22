using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model.Interface
{
    public interface IFlightMonitorModel
    {

		void ConnectToChannels();

		void DisconnectFromChannels();
    }
}
