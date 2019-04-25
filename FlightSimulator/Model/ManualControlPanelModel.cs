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

			//_dataManager.PropertyChanged += UpdateManual;
		}

		
		public double Rudder
        {
			
            get
			{

				return rudderValue;
			}
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

			get
			{

				return elevatorValue;
			}
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

			get
			{
				return throttleValue;
			}
			set
			{
				throttleValue = value;

				if (_dataManager.Connected)
				{
					string command = "set /controls/engines/engine/throttle " + value + "\r\n";
					_dataManager.CommandChannel.Send(command);
				}
			}
		}
		public double Aileron
		{

			get
			{
				return aileronValue;
			}
			set
			{
				aileronValue = value;

				if (_dataManager.Connected)
				{
					string command = "set /controls/flight/aileron " + value + "\r\n";
					_dataManager.CommandChannel.Send(command);

				}
			}
		}

		 double rudderValue  = 0;
		 double throttleValue  = 0;
		 double elevatorValue  = 0;
		 double aileronValue  = 0;


		//void UpdateManual(object sender, PropertyChangedEventArgs args)
		//{

		//	if (args.PropertyName.Equals("/controls/flight/aileron"))
		//		aileronValue = _dataManager.InfoDataDictionary["/controls/flight/aileron"];

		//	else if (args.PropertyName.Equals("/controls/flight/elevator"))
		//		elevatorValue = _dataManager.InfoDataDictionary["/controls/flight/elevator"];

		//	else if (args.PropertyName.Equals("/controls/flight/rudder"))
		//		rudderValue = _dataManager.InfoDataDictionary["/controls/flight/rudder"];

		//	else if (args.PropertyName.Equals("/controls/engines/current-engine/throttle"))
		//		throttleValue = _dataManager.InfoDataDictionary["/controls/engines/current-engine/throttle"];

		//}

	}
}
