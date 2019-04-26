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
	public class FlightMonitorModel : IFlightMonitorModel
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

		public string ConnectionRequestDescription { get; set; }
		string connectMessage, disconnectMessage;

		public FlightMonitorModel() {
			connectMessage = "Connect";
			disconnectMessage = "Disconnect";
			ConnectionRequestDescription = connectMessage;
		}

		// Connect To Channels - logic: 

		public void ConnectToChannels()
		{
			IDataManager dataManager = DataManager.Instance;

			// Set the port and ip setting to be the ones in setting
			// opens the server so the simulator connects us a a client.
			dataManager.InfoChannel.Port = ApplicationSettingsModel.Instance.FlightInfoPort;
			dataManager.InfoChannel.Start();


			// connects to the simulator's server as a client.
			dataManager.CommandChannel.IpAndPort = new IPEndPoint(IPAddress.Parse(ApplicationSettingsModel.Instance.FlightServerIP),
															ApplicationSettingsModel.Instance.FlightCommandPort);

			// sets the connection request description to be "disconnect"; 

			ConnectionRequestDescription = disconnectMessage;

			//. add a client connection event handler to the event of first data arrives to us to create user - simulator cordination.

			dataManager.InfoChannel.FirstClientConnected += dataManager.CommandChannel.Connect;
			dataManager.InfoChannel.FirstClientConnected += (() => { dataManager.Connected = true; });

		}


		// Disconnection from channels - logic:

		public void DisconnectFromChannels()
		{

			// stops our server connections, and stops the client connection to the simulator.
			// sets the connected bool to false, and the connect message to be "connect"

			DataManager.Instance.InfoChannel.Stop();
			DataManager.Instance.CommandChannel.Disconnect();
			DataManager.Instance.Connected = false;
			ConnectionRequestDescription = connectMessage;
		}
	}
}