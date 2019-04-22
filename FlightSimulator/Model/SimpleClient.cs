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
		private TcpClient tcpClient;

		public void Connect()
		{
			tcpClient = new TcpClient();
			tcpClient.Connect(IpAndPort);

		}

		public void Send(string str)
		{
			using (NetworkStream stream = tcpClient.GetStream())
			using (BinaryWriter writer = new BinaryWriter(stream))
			{
				writer.Write(str);
			}
		}
	}
}
