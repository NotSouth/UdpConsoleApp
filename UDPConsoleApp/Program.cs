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

            Task.Run(() => { UdpListener.StartListener(); }) ;
            Console.ReadKey();

        }
    }
}
