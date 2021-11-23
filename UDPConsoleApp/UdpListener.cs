using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using AirLibrary;

namespace UDPConsoleApp
{
    public class UdpListener
    {
        public static void StartListener()
        {
            UdpClient socket = new UdpClient();
            socket.Client.Bind(new IPEndPoint(IPAddress.Any, 10010));

            while (true)
            {
                IPEndPoint from = null;
                byte[] data = socket.Receive(ref from);
                string received = Encoding.UTF8.GetString(data);
                Console.WriteLine($"{received}");

            }


        }
    }
}
