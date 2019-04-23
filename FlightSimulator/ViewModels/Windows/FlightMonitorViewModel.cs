using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
	public class FlightMonitorViewModel: BaseNotify
	{
	
		private FlightMonitorModel model;
		private bool connectionButtonPressed;	

		public FlightMonitorViewModel(FlightMonitorModel m) {
			model = m;
			connectionButtonPressed = false;
		}

		public string ConnectionRequestDescription
		{
			get { return model.ConnectionRequestDescription; }
		}		
		#region connectCommand
		private ICommand _connectCommand;
		public ICommand ConnectCommand
		{
			
			get
			{
				return _connectCommand ?? (_connectCommand = new CommandHandler(() =>
				{
					if (!connectionButtonPressed)
						model.ConnectToChannels();
					else
						model.DisconnectFromChannels();

					connectionButtonPressed = !connectionButtonPressed;
					NotifyPropertyChanged("ConnectionRequestDescription");
				}
				));
			}
		}

		#endregion
	}
}
