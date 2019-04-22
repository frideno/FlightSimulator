using FlightSimulator.Model.Interface;
using FlightSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    public class ManualControlPanelModel : IManualControlPanelModel
    {
		public ManualControlPanelModel() {
			DataManager.Instance.InfoDataDictionary["/controls/flight/rudder"] = 0;
			DataManager.Instance.InfoDataDictionary["/controls/flight/elevator"] = 0;
			DataManager.Instance.InfoDataDictionary["/controls/engines/current-engine/throttle"] = 0;
			DataManager.Instance.InfoDataDictionary["/controls/flight/aileron"] = 0;
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
				string command = "set /controls/flight/rudder " + value + "\r\n";
				DataManager.Instance.CommandChannel.Send(command);
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
				if (DataManager.Instance.Connected)
				{
					string command = "set /controls/flight/elevator " + value + "\r\n";
					DataManager.Instance.CommandChannel.Send(command);
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

				if (DataManager.Instance.Connected)
				{
					string command = "set /controls/engines/current-engine/throttle " + value + "\r\n";
					Console.Write(command);
					DataManager.Instance.CommandChannel.Send(command);
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

				if (DataManager.Instance.Connected)
				{
					string command = "set /controls/flight/aileron " + value + "\r\n";
					DataManager.Instance.CommandChannel.Send(command);

				}
			}
		}

		 double rudderValue  = 0;
		 double throttleValue  = 0;
		 double elevatorValue  = 0;
		 double aileronValue  = 0;


	}
}
