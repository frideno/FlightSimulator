using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
	interface IServer
	{
		// start the server's data streaming.
		void Start();

		// stop the server's data streaming.
		void Stop();

	}
}
