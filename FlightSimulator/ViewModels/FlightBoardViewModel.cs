using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {

		public FlightBoardModel model;

		public FlightBoardViewModel(FlightBoardModel m) {
			model = m;
		}

        public double Lon
		{
			get
			{
				double l = model.Lon;
				Console.Write("Lon = {0}", l);
				return l;

			}
			
		}

		public double Lat
		{
			get
			{
				double l = model.Lat;
				Console.Write("Lat = {0}", l);
				return l;
			}

		}


	}
}
