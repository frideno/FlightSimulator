using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels.Windows
{
	public class AutoPilotViewModel: BaseNotify
	{
		private IAutoPilotModel model;

		public AutoPilotViewModel(AutoPilotModel m)
		{
			model = m;
		}

		// the textbox which into you enters commands in view. binded to it.
		public string CommandsTextBox
		{
			set
			{
				model.CommandsTextBox = value;
				NotifyPropertyChanged("CommandsTextBox");
			}
			get
			{
				return model.CommandsTextBox;
			}
		}

		// local bool which symbolize if the commands in textbox are currently executing, which 
		// helps for converter from this to brush - background of the textbox in view.

		private bool isExecuting;
		public bool IsExecuting
		{
			get { return isExecuting; }
			set
			{
				isExecuting = value;
				NotifyPropertyChanged("IsExecuting");
			}
		}


		#region Commands
		#region ClickCommand

		// ok click command - when OK clicked in view:

		private ICommand _okClickCommand;
		public ICommand OkClickCommand
		{
			get
			{
				return _okClickCommand ?? (_okClickCommand = new CommandHandler(() => OnOK()));
			}
		}

		// on pressed OK, a new task is started (if there is a connection), which tells the model to execute and 
		// sign isExecute bool to true, and in the end to false so the converter will work.

		private void OnOK()
		{
			if (DataManager.Instance.Connected)
			{
				IsExecuting = true;
				Task t = new Task(() =>
				{
					model.ExceuteCommands();
					IsExecuting = false;
				});
				t.Start();
			}
			
		}
		#endregion

		// cancel click command - when Cancel clicked in view:

		#region ClickCommand
		private ICommand _clearCommand;
		public ICommand ClearCommand
		{
			get
			{
				return _clearCommand ?? (_clearCommand = new CommandHandler(() => OnClear()));
			}
		}
		private void OnClear()
		{
			model.Clear();
			NotifyPropertyChanged("CommandsTextBox");

		}
		#endregion
		#endregion
	}
}
