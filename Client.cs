using Messages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using M = Messages;

namespace Client
{
    internal class Client
    {
        private static string pattern = @"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$";
        private static string portPattern = @"^\d{1,5}$";

        // private RichTextBox viwer;
        private Thread listener;
        private IPAddress ip;
        private TcpClient client;
        private ushort port;
        // private TcpClient tcpClient;
        private Stream stream;
        private bool connected;
        private Action enterAuth;
        private Action enterChat;
        private Action<string> addText;
        public Client(string ip, string port, /*RichTextBox viwer,*/ Action enterAuth, Action enterChat, Action<string> addText) 
        {
            this.ip = IPAddress.Parse(ip);
            this.port = ushort.Parse(port);
            // this.viwer = viwer;
            this.enterAuth = enterAuth;
            this.enterChat = enterChat;
            this.addText = addText;
        }

        public int Connect(string userName)
        {
            // var ipEndPoint = new IPEndPoint(ip,port);
            try
            {
                client = new TcpClient();
                client.Connect(ip, port);
                connected = true;
                stream = client.GetStream();
                // Send AuthMessage
                sendMsg(new M.AuthMsg(
                    userName
                    ));
                listener = new Thread(listen);
                listener.Start();
                return 0;

            }
            catch (Exception ex) {
                Console.WriteLine("error in Connect");
                Console.WriteLine(ex);
                Console.WriteLine(ex.Message);
                return -1;
            }
            
        }
        private void sendMsg(M.Msg msg) {
            var bytes = msg.Serialize();
            stream.Write(bytes, 0, bytes.Count());
        }
        private byte[] readForFlag(byte flag = 0x00)
        {
            var buf = new List<byte>();
            while (true)
            {
                try
                {
                    var bt = (byte)stream.ReadByte();
                    buf.Add(bt);
                    if (bt == flag)
                    {
                        return buf.ToArray();
                    }
                }
                catch (IOException ex) {
                    // todo сообщить о том что сервер нас отключил
                    MessageBox.Show($"Сервер отключился сам или отключил вас", "Сервер закрыл подключение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    enterAuth();
                }
            }
        }


        private void listen()
        {
            while (connected)
            {
                var data = readForFlag();
                switch (data[0])
                {
                    case 0x02:
                        var authResultMsg = M.AuthResultMsg.Deserialize(data);
                        Console.WriteLine("authResultMsg.ResultCode");
                        Console.WriteLine(authResultMsg.ResultCode);
                        if (authResultMsg.ResultCode != 0x01)
                        {
                            connected = false;
                            MessageBox.Show($"Error " + authResultMsg.ResultCode + ":" + " " + authResultMsg.ErrorText, "Сервер отказал в подключении", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            enterAuth();
                        }
                        break;

                    case 0x03:
                        var serverCaptionMsg = M.ServerCaptionMsg.Deserialize(data);
                        Console.WriteLine("serverCaptionMsg.ServerCaption");
                        Console.WriteLine(serverCaptionMsg.ServerCaption);
                        addText(serverCaptionMsg.ServerCaption);
                        break;

                    default:
                        break;
                }
            }
            stream.Close();
            client.Close();
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
