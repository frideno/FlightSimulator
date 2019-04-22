using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
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
        }

		public double Elevator
		{
			get {return model.Elevator;	}
			set
			{
				model.Elevator = value;
				NotifyPropertyChanged("Elevator");
			}
		}

		public double Throttle
		{ 
			get { return model.Throttle; }
			set
			{
				model.Throttle = value;
				NotifyPropertyChanged("Throttle");
			}
		}

		public double Aileron
		{
			get { return model.Aileron; }
			set
			{
				model.Aileron = value;
				NotifyPropertyChanged("Aileron");
			}
		}

		public double Rudder
		{
			get { return model.Rudder; }
			set
			{
				model.Rudder = value;
				NotifyPropertyChanged("Rudder");
			}
		}

	}
}

