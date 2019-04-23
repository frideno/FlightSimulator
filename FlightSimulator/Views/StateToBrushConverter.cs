using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace FlightSimulator.Views
{
	class StateToBrushConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (targetType != typeof(Brush))
				throw new InvalidOperationException("Must convert to a brush!");
			bool isSending = (bool)value;
			return isSending ? Brushes.Tomato : Brushes.White;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (targetType != typeof(bool))
				throw new InvalidOperationException("Must convert to a bool!");
			Brush b = (Brush)value;

			return b.Equals(Brushes.Tomato) ;
		}
	}
}
