using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model.Interface
{
	interface IClient
	{
		// connect to a server.
		void Connect(IPEndPoint);

		
	}
}
