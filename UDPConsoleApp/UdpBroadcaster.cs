using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UDPConsoleApp
{
    public class UdpBroadcaster
    {
        public static void SendMessage(string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            System.Net.Sockets.UdpClient socket = new System.Net.Sockets.UdpClient();
            socket.Send(data, data.Length, "255.255.255.255", 10010);
            while (true)
            {
                IPEndPoint from = null;
                byte[] recieveData = socket.Receive(ref from);
                string recievedString = Encoding.UTF8.GetString(recieveData);
                Console.WriteLine(recievedString);
            }
        }
    }
}
