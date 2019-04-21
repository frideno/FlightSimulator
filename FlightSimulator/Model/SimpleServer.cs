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
		private int port;
		private TcpListener listener;
		private IClientHandler ch;
		public SimpleServer(int port, IClientHandler ch)
		{
			this.port = port;
			this.ch = ch;
		}
		public void Start()
		{
			IPEndPoint ep = new
			IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
			listener = new TcpListener(ep);
			listener.Start();

			// Waiting for connections...

			Thread thread = new Thread(() => {
				try
				{
					TcpClient client = listener.AcceptTcpClient();

					// Got new connection
					ch.HandleClient(client);
				}
				catch (SocketException)
				{
					
				}

			});
			thread.Start();
		}
		public void Stop()
		{
			listener.Stop();
		}
	}
}
