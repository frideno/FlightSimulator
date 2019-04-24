using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
	public interface IServer
	{
		// the port the server will work on.
		int Port { get; set; }

		// the way the server will handle its clients.
		IClientHandler ClientHandler { get; set; }

		// an event of when the first client connected to the server.
		event Action FirstClientConnected;

		// start the server's data streaming.
		void Start();

		// stop the server's data streaming.
		void Stop();

	}
}
