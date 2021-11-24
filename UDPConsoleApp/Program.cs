using System;
using System.Text.Json;
using System.Threading.Tasks;
using AirLibrary;

namespace UDPConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");

            Air mockAir = new Air();
            mockAir.CO2 = "200";
            mockAir.Humidity = "very moist";
            mockAir.Temperature = "hot af";
            mockAir.ID = 0;

            string jsonString = JsonSerializer.Serialize(mockAir);
            Console.WriteLine(jsonString);

            Task.Run(() => { UdpListener.StartListener(); }) ;
            Console.ReadKey();

        }
    }
}
