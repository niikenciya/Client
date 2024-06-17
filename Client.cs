using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using M = Messages;

namespace Client
{
    internal class Client
    {
        private static string pattern = @"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$";
        private static string portPattern = @"^\d{1,5}$";

        private RichTextBox viwer;
        private IPAddress ip;
        private ushort port;
        // private TcpClient tcpClient;
        private Stream stream;
        private bool connected;
        public Client(string ip, string port, RichTextBox viwer) 
        {
            this.ip = IPAddress.Parse(ip);
            this.port = ushort.Parse(port);
            this.viwer = viwer;
        }

        public int Connect(string userName)
        {
            // var ipEndPoint = new IPEndPoint(ip,port);

            TcpClient client = new TcpClient();
            client.Connect(ip, port);
            stream = client.GetStream();
            // Send AuthMessage
            sendMsg(new M.AuthMessage(
                userName
                ));

            int serverHello = stream.ReadByte();
            if (serverHello == 0)
            {
                connected = true;
                return 0;
            }
            return -1;

        }
        private void updateLog(string message)
        {
            viwer.AppendText(message + "\n");
        }
        private void sendMsg(M.Message msg) {
            var bytes = msg.Serialize();
            stream.Write(bytes, 0, bytes.Count());
        }
        private List<byte> readForFlag(byte flag)
        {
            var buf = new List<byte>();
            while (true)
            {
                var bt = (byte)stream.ReadByte();
                buf.Add(bt);
                if (bt == flag)
                {
                    return buf;
                }
            }
        }


        private void listen()
        {
            while (connected)
            {
                var responseCode = stream.ReadByte();
                switch (responseCode)
                {
                    case 0x02:

                    default:
                        break;
                }
            }
        }

        public static long bytesToUnix(byte[] bytes) // поменять обратно на приват
        {
            return BitConverter.ToInt64(bytes, 0);
        }


        public static bool CheckIp(string ip)
        {
            var matchCount = Regex.Matches(ip, pattern).Count;

            if (matchCount == 1)
            {
                int[] ipBytes = ip.Split('.').Select(int.Parse).ToArray();

                if (ipBytes[0] < 256 && ipBytes[1] < 256 && ipBytes[2] < 256 && ipBytes[3] < 256)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool CheckPort(string strPort) 
        {
            var matchCount = Regex.Matches(strPort, portPattern).Count;
            if (matchCount == 1)
            {
                var intPort = Convert.ToInt32(strPort);

                if (intPort <= ushort.MaxValue)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
