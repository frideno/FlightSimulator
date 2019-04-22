using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using FlightSimulator.Model.Interface;
using System.Threading;
using FlightSimulator.ViewModels;

namespace FlightSimulator.Model
{
	public class FlightMonitorModel: IFlightMonitorModel
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

			
		}


		public void ConnectToChannels()
		{
			IDataManager dataManager = DataManager.Instance;

			// opens the server so the simulator connects us a a client.
			dataManager.InfoChannel.Port = ApplicationSettingsModel.Instance.FlightInfoPort;
			dataManager.InfoChannel.Start();


			// connects to the simulator's server as a client.
			dataManager.CommandChannel.IpAndPort = new IPEndPoint(IPAddress.Parse(ApplicationSettingsModel.Instance.FlightServerIP),
															ApplicationSettingsModel.Instance.FlightCommandPort);
			dataManager.CommandChannel.Connect();

		}

		public void DisconnectFromChannels()
		{
			DataManager.Instance.InfoChannel.Stop();
		}
	}
}