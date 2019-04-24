using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;
using FlightSimulator.Model.Interface;
using FlightSimulator.ViewModels;

namespace FlightSimulator.Model
{
	class SimulatorDataRecieverClientHandler : IClientHandler
	{

		public void HandleClient(TcpClient client)
		{

			using (NetworkStream stream = client.GetStream())
			using (StreamReader reader = new StreamReader(stream))
			{
				while (true)
				{
					IDictionary<string, double> tmp;
					try
					{
						string data = reader.ReadLine();
						 tmp = ParseGenericSmall(data);
					}

					// if the client disconnected for example.
					catch (Exception) {
						break;
					}
					DataManager.Instance.InfoDataDictionary = tmp;
				}
			}

		}

		//Example:
		//-157.943192,21.325247,6.208333,-205.103104,-203.909668,12.000000,40.000000,0.000000,0.000000,
		//-199.999863,-200.000000,22.676603,0.000000,-0.000134,270.009979,101.103622,-0.017824,-2.477949,
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

			var nameAndValues = DataManager.GenericSmallAttributes.Zip(AttributeValuesDouble, (n,v) => new { Name = n, Value = v });
			foreach (var nv in nameAndValues) {
				nameToValues[nv.Name] = nv.Value;
			}

			return nameToValues;
		}
	}
}
