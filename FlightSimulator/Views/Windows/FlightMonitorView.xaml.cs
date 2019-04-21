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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlightSimulator.Views.Windows
{
	/// <summary>
	/// Interaction logic for UserControl1.xaml
	/// </summary>
	public partial class FlightMonitorView: UserControl
	{
		public FlightMonitorView()
		{
			InitializeComponent();
		}

		private void SettingsButton_Click(object sender, RoutedEventArgs e)
		{
			SettingsWindow sw = new SettingsWindow();
			sw.Show();
		}
	}
}
