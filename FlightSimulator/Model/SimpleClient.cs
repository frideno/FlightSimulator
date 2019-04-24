using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
	class SimpleClient : IClient
	{
		public IPEndPoint IpAndPort { get; set; }


		// send to the server by opening new connection for each message.
		public void Send(string str)
		{
			try
			{
				TcpClient tcpClient = new TcpClient();
				tcpClient.Connect(IpAndPort);

				using (NetworkStream stream = tcpClient.GetStream())
				using (BinaryWriter writer = new BinaryWriter(stream))
				{
					var message = System.Text.Encoding.ASCII.GetBytes(str);
					writer.Write(message, 0, message.Length);
				}
			}
			catch (Exception e)
			{
				return;
			}
		}

		public void Connect() {


		}
	}
}
