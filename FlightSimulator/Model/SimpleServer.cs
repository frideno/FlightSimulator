using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
	class SimpleServer : IServer
	{
		private TcpListener listener;

		public int Port { get; set; }
		public IClientHandler ClientHandler { get; set; }
		public event Action FirstClientConnected;

		private Thread thread;

		// Start - logic: Binding to the ip of the computer, and the port given, and start listening.
		// for only one first client arrived, handle it with client handler.

		public void Start()
		{
			IPEndPoint ep = new	IPEndPoint(IPAddress.Parse("127.0.0.1"), Port);
			listener = new TcpListener(ep);
			listener.Start();

			// Waiting for connections...

			thread = new Thread(() => {
				try
				{
					TcpClient client = listener.AcceptTcpClient();

					FirstClientConnected();
					// Got new connection
					ClientHandler.HandleClient(client);
				}
				catch (SocketException)
				{
					// do nothing, it shouldn't be happening.
				}

			});
			thread.Start();
		}
		public void Stop()
		{
			listener.Stop();
			thread.Abort();
		}

	}
}
