using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model.Interface
{
	public interface IClient
	{
		// the port + ip the client will talk to .
		IPEndPoint IpAndPort { get; set; }

		void Connect();

		// send data to the server.
		void Send(string str);

	}
}
