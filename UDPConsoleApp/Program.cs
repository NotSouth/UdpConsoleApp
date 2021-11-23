using System;
using AirLibrary;

namespace UDPConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Air mockAir = new Air();
            mockAir.CO2 = "200";
            mockAir.Humidity = "very moist";
            mockAir.Temperature = "hot af";
            

            UdpBroadcaster udp = new UdpBroadcaster();
            udp.SendMessage(mockAir);

        }
    }
}
