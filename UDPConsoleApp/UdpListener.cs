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
                air.CO2 = Math.Truncate(air.CO2 * 100) / 100;
                air.Humidity = Math.Truncate(air.Humidity * 100) / 100;
                air.Temperature = Math.Truncate(air.Temperature * 100) / 100;
                Console.WriteLine($"Received: CO2 {air.CO2} ppm, Humidity {air.Humidity}%, Temperature {air.Temperature} C.");
                string json = JsonSerializer.Serialize(air);
                UdpBroadcaster.SendMessage(json);
            }


        }
    }
}
