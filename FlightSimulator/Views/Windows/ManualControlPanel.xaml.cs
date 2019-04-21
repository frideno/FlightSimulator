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
    /// Interaction logic for ManualControlPanel.xaml
    /// </summary>
    public partial class ManualControlPanel : UserControl
    {
        public ManualControlPanel()
        {
            InitializeComponent();
			this.DataContext = new ViewModels.Windows.ManualControlPanelViewModel(new Model.ManualControlPanelModel());
        }
    }
}
