using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;




namespace FlightSimulator.ViewModels
{
    class DataManager: BaseNotify, IDataManager
    {
		#region Singleton
		private static DataManager m_Instance = null;
		public static DataManager Instance
		{
			get
			{
				if (m_Instance == null)
				{
					m_Instance = new DataManager();
				}
				return m_Instance;
			}
		}

		private DataManager() {
			InfoChannel = new SimpleServer();
			InfoChannel.ClientHandler = new SimulatorDataRecieverClientHandler();


			CommandChannel = new SimpleClient();

			infoDataDictionary = new Dictionary<string, double>();
		}
		#endregion

		private IDictionary<string, double> infoDataDictionary;
		private bool firstSet = true;
		public IDictionary<string, double> InfoDataDictionary
		{
			get { return infoDataDictionary; }
			set
			{
				if (firstSet)
				{
					foreach (KeyValuePair<string, double> entry in value)
					{
						infoDataDictionary.Add(entry);

					}
					firstSet = false;
				}
				else
				{
					foreach (KeyValuePair<string, double> entry in value)
					{

						if (!firstSet && !entry.Value.Equals(infoDataDictionary[entry.Key]))
						{
							infoDataDictionary[entry.Key] = entry.Value;
							NotifyPropertyChanged(entry.Key);
						}
					}
				}

			}
		}

		public IServer InfoChannel { get; }

		public IClient CommandChannel { get; }
	}
}
