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
	class DataManager : BaseNotify, IDataManager
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

		private DataManager()
		{
			InfoChannel = new SimpleServer();
			InfoChannel.ClientHandler = new SimulatorDataRecieverClientHandler();

			CommandChannel = new SimpleClient();

			infoDataDictionary = new Dictionary<string, double>();
			Connected = false;

			foreach (string attr in GenericSmallAttributes)
			{
				infoDataDictionary.Add(attr, 0);
			}
		}
		static DataManager()
		{

			// Initialize the generic small attribute to ask the server .

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
		#endregion
		// List of all generic_small.xml attributes name by their order:
		public static readonly IList<string> GenericSmallAttributes;


		private IDictionary<string, double> infoDataDictionary;
		public IDictionary<string, double> InfoDataDictionary
		{
			get { return infoDataDictionary; }
			set
			{
				// setting LON first, without notifying it, so LON and LAT will notify as a couple.

				infoDataDictionary["/position/longitude-deg"] = value["/position/longitude-deg"];
				value.Remove("/position/longitude-deg");

				// iterate the key and values in value setted, and for each:
				foreach (KeyValuePair<string, double> entry in value)
				{

					// change the value and notify property changed and save it if and only if the property changed.

					if (! infoDataDictionary[entry.Key].Equals(entry.Value))
					{
						infoDataDictionary[entry.Key] = entry.Value;
						NotifyPropertyChanged(entry.Key);
					}
				}

			}
		}

		public IServer InfoChannel { get; }

		public IClient CommandChannel { get; }
		public bool Connected { get; set; }

	}
}