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
		private ICommand _okClickCommand;
		public ICommand OkClickCommand
		{
			get
			{
				return _okClickCommand ?? (_okClickCommand = new CommandHandler(() => OnOK()));
			}
		}
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
