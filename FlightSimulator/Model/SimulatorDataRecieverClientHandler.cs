using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using FlightSimulator.Model.Interface;

namespace FlightSimulator.Model
{
	class SimulatorDataRecieverClientHandler : IClientHandler
	{
		public void HandleClient(TcpClient client)
		{
			Thread t = new Thread(() =>
			{
				using (NetworkStream stream = client.GetStream())
				using (StreamReader reader = new StreamReader(stream))
				{
					while (true)
					{
						Console.WriteLine("got:");
						string data = reader.ReadLine();
						//FlightMonitorModel.Instance.InfoDataDictionary = Parse(data);
						Console.WriteLine(data);
					}
				}
			});
			t.Start();
		}
		private IDictionary<string, double> Parse(string data) {
			return new Dictionary<string, double>();
		}
	}
}
