using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using FlightSimulator.Model.Interface;
using System.Threading;

namespace FlightSimulator.Model
{
	class FlightMonitorModel: IFlightMonitorModel
	{
		#region Singleton
		private static IFlightMonitorModel m_Instance = null;
		public static IFlightMonitorModel Instance
		{
			get
			{
				if (m_Instance == null)
				{
					m_Instance = new FlightMonitorModel();
				}
				return m_Instance;
			}
		}
		#endregion

		public IServer InfoChannel { get; }
		public IClient CommandChannel { get; }

		public IDictionary<string, double> InfoDataDictionary { get; set; }
		
		public FlightMonitorModel() {

			InfoChannel = new SimpleServer();
			InfoChannel.ClientHandler = new SimulatorDataRecieverClientHandler();


			CommandChannel = new SimpleClient();
		
			InfoDataDictionary = new Dictionary<string, double>();
		}


		public void ConnectToChannels()
		{
			// opens the server so the simulator connects us a a client.
			InfoChannel.Port = ApplicationSettingsModel.Instance.FlightInfoPort;
			InfoChannel.Start();
			Console.WriteLine("opened our server");

			//// start recieving data, 
			//Thread.Sleep(22000);

			//// connects to the simulator's server as a client.
			//CommandChannel.IpAndPort = new IPEndPoint(IPAddress.Parse(ApplicationSettingsModel.Instance.FlightServerIP),
			//												ApplicationSettingsModel.Instance.FlightCommandPort);
			//CommandChannel.Connect();
			//Console.WriteLine("connected to a server");

		}

		public void DisconnectFromChannels()
		{
			InfoChannel.Stop();
		}
	}
}