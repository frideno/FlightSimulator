using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FlightSimulator.ViewModels.Windows
{
    public class ManualControlPanelViewModel : BaseNotify
    {

        private IManualControlPanelModel model;

        public ManualControlPanelViewModel(IManualControlPanelModel m)
        {
            this.model = m;
			DataManager.Instance.PropertyChanged += new PropertyChangedEventHandler(UpdateManualdWhenChanged);
        }

		// An Elevator variable - a symbol of the plane controller.
		
		public double Elevator
		{
			get {return model.Elevator;	}
			set
			{
				model.Elevator = value;
				NotifyPropertyChanged("Elevator");
			}
		}

		// A Throttle variable - a symbol of the plane controller.

		public double Throttle
		{ 
			get { return model.Throttle; }
			set
			{
				model.Throttle = value;
				NotifyPropertyChanged("Throttle");
			}
		}

		// An Aileron variable - a symbol of the plane controller.

		public double Aileron
		{
			get { return model.Aileron; }
			set
			{
				model.Aileron = value;
				NotifyPropertyChanged("Aileron");
			}
		}

		// A Rudder variable - a symbol of the plane controller.

		public double Rudder
		{
			get { return model.Rudder; }
			set
			{
				model.Rudder = value;
				NotifyPropertyChanged("Rudder");
			}
		}


		// A function that subscribed to the event of main DataManager when new data comes from the server:
		// What it does is to update accordinly alieron/elevator/rudder/throttle - makes the binding two sided.

		void UpdateManualdWhenChanged(object sender, PropertyChangedEventArgs args)
		{

			if (args.PropertyName.Equals("/controls/flight/aileron"))
				Aileron = DataManager.Instance.InfoDataDictionary["/controls/flight/aileron"];

			else if (args.PropertyName.Equals("/controls/flight/elevator"))
				Elevator = DataManager.Instance.InfoDataDictionary["/controls/flight/elevator"];

			else if (args.PropertyName.Equals("/controls/flight/rudder"))
				Rudder = DataManager.Instance.InfoDataDictionary["/controls/flight/rudder"];

			else if (args.PropertyName.Equals("/controls/engines/engine/throttle"))
				Throttle = DataManager.Instance.InfoDataDictionary["/controls/engines/engine/throttle"];

		}

	}
}

