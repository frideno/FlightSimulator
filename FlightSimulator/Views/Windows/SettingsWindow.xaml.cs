using FlightSimulator.ViewModels.Windows;
using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FlightSimulator.Views.Windows
{
	/// <summary>
	/// Interaction logic for SettingsWindow.xaml
	/// </summary>
	public partial class SettingsWindow : Window
	{
		SettingsWindowViewModel vm;

		public SettingsWindow()
		{
			InitializeComponent();
			vm = new SettingsWindowViewModel(new ApplicationSettingsModel());
			this.DataContext = vm;
		}

		public void SwitchToMainScreen(object sender, RoutedEventArgs args)
		{
			MainWindow window = (MainWindow)Application.Current.MainWindow;
			window.Show();
			this.Close();
		}

	}
}
