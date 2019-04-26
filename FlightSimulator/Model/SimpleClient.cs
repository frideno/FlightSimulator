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

		// keep private tcpClient, and binary writer so the send function can use them.

		private TcpClient tcpClient;

		private StreamWriter connectionWriter = null;


		// send to the server by opening new connection for each message.

		public void Send(string message)
		{
			// varify they connect function called before send.

			if (connectionWriter == null) return;

			try
			{			
				connectionWriter.WriteLine(message);
				
			}
			catch (Exception)
			{
				return;
			}
		}

		// Connect - simple tcp connection to the IpAndPort.

		public void Connect()
		{
			tcpClient = new TcpClient();
			tcpClient.Connect(IpAndPort);

			connectionWriter = new StreamWriter(tcpClient.GetStream());
		}

		// Disconnect - simple disconnection.

		public void Disconnect()
		{
			if (tcpClient != null)
			{
				tcpClient.Close();
				tcpClient = null;
			}
		}
	}
}
