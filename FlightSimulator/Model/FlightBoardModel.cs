using FlightSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
	public class FlightBoardModel
	{
		public double Lon
		{
			get {
				return DataManager.Instance.InfoDataDictionary["/position/longitude-deg"];
			}
			
		}
		public double Lat {
			get {
				return DataManager.Instance.InfoDataDictionary["/position/latitude-deg"];
			}
		}
	}
}
