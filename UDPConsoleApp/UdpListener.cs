using AirLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace UDPConsoleApp
{
    public class UdpListener
    {
        public static void StartListener()
        {
            UdpClient socket = new UdpClient();
            socket.Client.Bind(new IPEndPoint(IPAddress.Any, 10010));
            Console.WriteLine("Listener active...");
            while (true)
            {
                IPEndPoint from = null;
                byte[] data = socket.Receive(ref from);
                string received = Encoding.UTF8.GetString(data);
                Air air = JsonSerializer.Deserialize<Air>(received);
                Console.WriteLine($"Received: {air.CO2}, {air.Humidity}, {air.Temperature}.");
                string json = JsonSerializer.Serialize(air);
                UdpBroadcaster.SendMessage(json);
            }


        }
    }
}
