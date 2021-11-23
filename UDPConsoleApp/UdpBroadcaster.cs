using AirLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace UDPConsoleApp
{
    public class UdpBroadcaster
    {
        public void SendMessage(string message)
        {
            using (HttpClient client = new HttpClient())
            {
                //client.PostAsync("http://localhost:51141/api/Sensor", JsonContent.Create(message));
                var data = new StringContent(message, Encoding.UTF8, "application/json");
                var response = client.PostAsync("https://192.168.104.147:5001/api/Air", data).Result;
            }
            Console.WriteLine("Sent: " + message);
        }

       

    }
}
