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

namespace UDPConsoleApp
{
    public class UdpBroadcaster
    {
        public async Task<Air> SendMessage(Air airObject)
        {
            
         
            //byte[] data = Encoding.UTF8.GetBytes(jsonstring);
            //System.Net.Sockets.UdpClient socket = new System.Net.Sockets.UdpClient();
            //socket.Send(data, data.Length, "192.168.104.147:5001/api/Air", 10010);
            using(HttpClient client = new HttpClient())
            {
                JsonContent serializedItem = JsonContent.Create(airObject);
                HttpResponseMessage response = await client.PostAsync("https://192.168.104.147:5001/api/Air", serializedItem);

                return await response.Content.ReadFromJsonAsync<Air>();
            }


            //while (true)
            //{
            //    IPEndPoint from = null;
            //    byte[] recieveData = socket.Receive(ref from);
            //    string recievedString = Encoding.UTF8.GetString(recieveData);
            //    Console.WriteLine(recievedString);
            //}
        }

    }
}
