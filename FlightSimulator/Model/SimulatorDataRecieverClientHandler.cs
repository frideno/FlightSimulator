using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using FlightSimulator.Model.Interface;
using FlightSimulator.ViewModels;

namespace FlightSimulator.Model
{
	class SimulatorDataRecieverClientHandler : IClientHandler
	{
		// List of all generic_small.xml attributes name by their order:
		public static readonly IList<string> GenericSmallAttributes;

		static SimulatorDataRecieverClientHandler() {
			GenericSmallAttributes = new List<string>(new string[]
				{
					"/position/longitude-deg", "/position/latitude-deg",
					"/instrumentation/airspeed-indicator/indicated-speed-kt","/instrumentation/altimeter/indicated-altitude-ft",
					"/instrumentation/altimeter/pressure-alt-ft","/instrumentation/attitude-indicator/indicated-pitch-deg",
					"/instrumentation/attitude-indicator/indicated-roll-deg","/instrumentation/attitude-indicator/internal-pitch-deg",
					"/instrumentation/attitude-indicator/internal-roll-deg","/instrumentation/encoder/indicated-altitude-ft",
					"/instrumentation/encoder/pressure-alt-ft","/instrumentation/gps/indicated-altitude-ft",
					"/instrumentation/gps/indicated-ground-speed-kt","/instrumentation/gps/indicated-vertical-speed",
					"/instrumentation/heading-indicator/indicated-heading-deg","/instrumentation/magnetic-compass/indicated-heading-deg",
					"/instrumentation/slip-skid-ball/indicated-slip-skid","/instrumentation/turn-indicator/indicated-turn-rate",
					"/instrumentation/vertical-speed-indicator/indicated-speed-fpm","/controls/flight/aileron",
					"/controls/flight/elevator","/controls/flight/rudder",
					"/controls/flight/flaps","/controls/engines/engine/throttle","/engines/engine/rpm"
				});
		}

		public void HandleClient(TcpClient client)
		{
			DataManager.Instance.Connected = true;

			Thread t = new Thread(() =>
			{
				using (NetworkStream stream = client.GetStream())
				using (StreamReader reader = new StreamReader(stream))
				{
					while (true)
					{
						try
						{
							string data = reader.ReadLine();
							DataManager.Instance.InfoDataDictionary = ParseGenericSmall(data);
						}

						// if the client disconnected for example.
						catch {
							Console.WriteLine("Client Disconnected");
							break;
						}
					}
				}
			});
			t.Start();
		}

		//Example:
		//-157.943192,21.325247,6.208333,-205.103104,-203.909668,12.000000,40.000000,0.000000,0.000000,		9
		//-199.999863,-200.000000,22.676603,0.000000,-0.000134,270.009979,101.103622,-0.017824,-2.477949,	9
		//-1583.074097,0.000000,0.000000,0.000000,0.000000

		private IDictionary<string, double> ParseGenericSmall(string data) {

			// splits the data into List<string>
			string[] AttributeValuesString = data.Split(',');

			// converts the string list to a double list.
			List<double> AttributeValuesDouble = new List<double>();

			foreach (string AttributeValueString in AttributeValuesString) {
				AttributeValuesDouble.Add(Double.Parse(AttributeValueString));
			} 

			// makes it into a dictionary.
			IDictionary<string, double> nameToValues =  new Dictionary<string, double>();

			var nameAndValues = GenericSmallAttributes.Zip(AttributeValuesDouble, (n,v) => new { Name = n, Value = v });
			foreach (var nv in nameAndValues) {
				nameToValues[nv.Name] = nv.Value;
			}

			return nameToValues;
		}
	}
}
