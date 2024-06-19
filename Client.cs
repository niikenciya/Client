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
        public IPAddress Ip;
        private TcpClient client;
        public ushort Port;
        // private TcpClient tcpClient;
        private Stream stream;
        public bool Connected;
        private Action enterAuth;
        private Action enterChat;
        private Action<string> addText;
        private Action<M.NewMessageMsg> addMessage;
        public string UserName;

        public Client(string ip, string port, Action enterAuth, Action enterChat, Action<string> addText, Action<M.NewMessageMsg> addMessage)
        {
            this.Ip = IPAddress.Parse(ip);
            this.Port = ushort.Parse(port);
            this.enterAuth = enterAuth;
            this.enterChat = enterChat;
            this.addText = addText;
            this.addMessage = addMessage;
        }

        public int Connect(string userName)
        {
            // var ipEndPoint = new IPEndPoint(ip,port);
            try
            {
                client = new TcpClient();
                client.Connect(Ip, Port);
                Connected = true;
                stream = client.GetStream();
                // Send AuthMessage
                SendMsg(new M.AuthMsg(
                    userName
                    ));
                UserName = userName;
                listener = new Thread(listen);
                listener.Start();
                return 0;

            }
            catch (Exception ex)
            {
                Console.WriteLine("error in Connect");
                Console.WriteLine(ex);
                Console.WriteLine(ex.Message);
                return -1;
            }

        }

        public void Disconnect()
        {
            if (Connected)
            {
                stream.Close();
                Connected = false;
            }
        }

        public void SendMsg(M.Msg msg)
        {
            var bytes = msg.Serialize();
            Thread sendThr = new Thread(() => { stream.Write(bytes, 0, bytes.Count()); });
            sendThr.Start();
        }

        private byte[] readForFlag(byte flag = 0x00)
        {
            var buf = new List<byte>();
            try
            {
                while (Connected)
                {

                    var bt = (byte)stream.ReadByte();
                    buf.Add(bt);
                    if (bt == flag)
                    {
                        break;
                    }
                }
            }
            catch (IOException ex)
            {
                if (Connected)
                {
                    MessageBox.Show($"Сервер отключился сам или отключил вас", "Сервер закрыл подключение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stream.Close();
                    Connected = false;
                    enterAuth();

                }
            }
            return buf.ToArray();
        }

        private void listen()
        {
            while (Connected)
            {
                var data = readForFlag();
                if (data.Length > 0)
                {
                    switch (data[0])
                    {
                        case 0x02:
                            var authResultMsg = M.AuthResultMsg.Deserialize(data);
                            Console.WriteLine("authResultMsg.ResultCode");
                            Console.WriteLine(authResultMsg.ResultCode);
                            if (authResultMsg.ResultCode != 0x01)
                            {
                                Connected = false;
                                MessageBox.Show($"Error " + authResultMsg.ResultCode + ":" + " " + authResultMsg.ErrorText, "Сервер отказал в подключении", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                enterAuth();
                            }
                            else
                            {
                                enterChat();
                            }

                            break;

                        case 0x03:
                            var serverCaptionMsg = M.ServerCaptionMsg.Deserialize(data);
                            Console.WriteLine("serverCaptionMsg.ServerCaption");
                            Console.WriteLine(serverCaptionMsg.ServerCaption);
                            addText(serverCaptionMsg.ServerCaption);
                            break;

                        case 0x04:
                            var usersMsg = M.UsersMsg.Deserialize(data);
                            addText("\nПользователи на сервере:");

                            foreach (var userName in usersMsg.Users)
                            {
                                addText("\n" + userName);

                            }
                            break;

                        case 0x06:
                            var newMessageMsg = M.NewMessageMsg.Deserialize(data);
                            addMessage(newMessageMsg);
                            break;

                        case 0x07:
                            var userEnterMsg = M.UserEnterMsg.Deserialize(data);
                            addText(userEnterMsg.Time.ToString("\ndd.MM.yy HH:mm Пользователь ") + userEnterMsg.UserName + " присоединился");
                            break;
                        case 0x08:
                            var userLeaveMsg = M.UserLeaveMsg.Deserialize(data);
                            addText(userLeaveMsg.Time.ToString("\ndd.MM.yy HH:mm Пользователь ") + userLeaveMsg.UserName + " вышел");
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    Connected = false;
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
