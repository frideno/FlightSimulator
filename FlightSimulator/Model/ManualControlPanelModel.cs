using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    public class ManualControlPanelModel : IManualControlPanelModel
    {
		//server reference.

        #region Singleton
        private static IManualControlPanelModel m_Instance = null;
        public static IManualControlPanelModel Instance
        {
            get
            {
                if(m_Instance == null)
                {
                    m_Instance = new ManualControlPanelModel();
                }
                return m_Instance;
            }
        }

		#endregion
		private double rudder = 0.5;
        public double Rudder
        {
			
            get { return rudder; }
            set { rudder = value; }
		}
		private double elevator;
		public double Elevator
		{

			get { return elevator; }
			set { elevator = value; }
		}
		private double throttle;

		public double Throttle
		{

			get { return throttle; }
			set { throttle = value; }
		}
		private double aileron ;
		public double Aileron
		{

			get { return aileron; }
			set { aileron = value; }
		}
	}
}
