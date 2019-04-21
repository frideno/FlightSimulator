using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model.Interface
{
    public interface IManualControlPanelModel
    {
		// Four basic joystick and sliders controls.
		double Rudder { get; set; }
		double Throttle { get; set; }
		double Elevator { get; set; }
		double Aileron { get; set; }

		// Maybe add more functionallity.
    }
}
