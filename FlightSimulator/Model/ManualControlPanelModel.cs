using FlightSimulator.Model.Interface;
using FlightSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    public class ManualControlPanelModel : IManualControlPanelModel
    {
		private DataManager _dataManager;

		public ManualControlPanelModel() {
			_dataManager = DataManager.Instance;
		}


		double rudderValue = 0;
		double throttleValue = 0;
		double elevatorValue = 0;
		double aileronValue = 0;

		// Rudder value. 

		public double Rudder
        {
			// return the matching private local var.
			
            get
			{
				return rudderValue;
			}

			// setting the matching private local var to the value setted, and sending to the server a set request, only if connected to it.

			set
			{
				rudderValue = value;
				if (_dataManager.Connected)
				{
					string command = "set /controls/flight/rudder " + value + "\r\n";
					_dataManager.CommandChannel.Send(command);
				}
			}
		}
		public double Elevator
		{
			// return the matching private local var.

			get
			{
				return elevatorValue;
			}

			// setting the matching private local var to the value setted, and sending to the server a set request, only if connected to it.

			set
			{
				elevatorValue = value;
				if (_dataManager.Connected)
				{
					string command = "set /controls/flight/elevator " + value + "\r\n";
					_dataManager.CommandChannel.Send(command);
				}
			}
		}

		public double Throttle
		{
			// return the matching private local var.

			get
			{
				return throttleValue;
			}

			// setting the matching private local var to the value setted, and sending to the server a set request, only if connected to it.

			set
			{
				throttleValue = value;

				if (_dataManager.Connected)
				{
					string command = "set /controls/engines/current-engine/throttle " + value + "\r\n";
					_dataManager.CommandChannel.Send(command);
				}
			}
		}
		public double Aileron
		{
			// return the matching private local var.

			get
			{
				return aileronValue;
			}
			set

			// setting the matching private local var to the value setted, and sending to the server a set request, only if connected to it.

			{
				aileronValue = value;

				if (_dataManager.Connected)
				{
					string command = "set /controls/flight/aileron " + value + "\r\n";
					_dataManager.CommandChannel.Send(command);

				}
			}
		}




	}
}
