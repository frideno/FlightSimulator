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
    class FlightMonitorViewModel
    {
		private IFlightMonitorModel model;

		public FlightMonitorViewModel(IFlightMonitorModel m) {
			model = m;
		}

		#region connectCommand
		private ICommand _connectCommand;
		public ICommand ConnectCommand
		{
			
			get
			{
				return _connectCommand ?? (_connectCommand = new CommandHandler(() =>
				{
					Console.WriteLine("pressed");
					model.ConnectToChannels();

				}
				));
			}
		}
		
		#endregion
	}
}
