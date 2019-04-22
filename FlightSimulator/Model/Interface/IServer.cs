using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
	interface IServer
	{
		// the port the server will work on.
		int Port { get; set; }

		// the way the server will handle its clients.
		IClientHandler ClientHandler { get; set; }

		// start the server's data streaming.
		void Start();

		// stop the server's data streaming.
		void Stop();

	}
}
