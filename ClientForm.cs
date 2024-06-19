using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using M = Messages;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.CompilerServices;

namespace Client
{
    public partial class ClientForm : Form
    {
        Client client;

        public ClientForm()
        {
            InitializeComponent();
        }

        private void enterAuth()
        {
            Invoke((Action)(() =>
            {
                ipTxt.Visible = true;
                portTxt.Visible = true;
                userNameTxt.Visible = true;
                ipLabel.Visible = true;
                portLabel.Visible = true;
                userNameLabel.Visible = true;
                loaderImg.Visible = false;
                connectButton.Visible = true;

                ipLabel.Enabled = true;
                portLabel.Enabled = true;
                userNameLabel.Enabled = true;
                ipTxt.Enabled = true;
                portTxt.Enabled = true;
                userNameTxt.Enabled = true;
                loaderImg.Enabled = false;
                connectButton.Enabled = true;

                messageTxt.Visible = false;
                messageTxt.Enabled = false;

                chatViwer.Visible = false;
                chatViwer.Enabled = false;

                sendButton.Visible = false;
                sendButton.Enabled = false;

                chatViwer.Text = "";
                messageTxt.Text = "";

                Size = new Size(MinimumSize.Width, MaximumSize.Height);

                AcceptButton = connectButton;
                Text = "Клиент";

            }));
        }

        private void addMessage(M.NewMessageMsg msg)
        {
            Invoke((Action)(() =>
            {
                chatViwer.SelectionColor = Color.LightSkyBlue;
                chatViwer.AppendText("\n" + msg.Time.ToString("dd.MM.yy HH:mm "));
                if (client.UserName != msg.UserName)
                {
                    chatViwer.SelectionColor = Color.HotPink;
                }
                else
                {
                    chatViwer.SelectionColor = Color.Orange;

                }
                chatViwer.AppendText(msg.UserName + ": ");
                chatViwer.SelectionColor = Color.White;
                chatViwer.AppendText(msg.Text);
                chatViwer.SelectionColor = Color.LightSkyBlue;



                // прокрутка вниз
                chatViwer.SelectionStart = chatViwer.TextLength;
                chatViwer.ScrollToCaret();

            }));
        }

        private void addText(string message)
        {
            Invoke((Action)(() =>
            {
                chatViwer.SelectionColor = Color.FromArgb(67, 178, 160);
                chatViwer.AppendText(message);
                chatViwer.SelectionColor = Color.LightSkyBlue;

            }));
        }

        private void enterChat()
        {
            Invoke((Action)(() =>
            {
                loaderImg.Visible = false;
                ipTxt.Visible = false;
                portTxt.Visible = false;
                userNameTxt.Visible = false;
                ipLabel.Visible = false;
                portLabel.Visible = false;
                userNameLabel.Visible = false;
                connectButton.Visible = false;

                loaderImg.Enabled = false;
                ipLabel.Enabled = false;
                portLabel.Enabled = false;
                userNameLabel.Enabled = false;
                ipTxt.Enabled = false;
                portTxt.Enabled = false;
                userNameTxt.Enabled = false;
                connectButton.Enabled = false;


                messageTxt.Visible = true;
                messageTxt.Enabled = true;

                chatViwer.Visible = true;
                chatViwer.Enabled = true;

                sendButton.Visible = true;
                sendButton.Enabled = true;

                Size = new Size(350, 425);

                AcceptButton = sendButton;
                Text = $"{client.UserName}: {client.Ip.ToString()}:{client.Port}";
            }));
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            string ip = ipTxt.Text;
            string port = portTxt.Text;
            string userName = userNameTxt.Text;
            if (!Client.CheckIp(ip))
            {
                MessageBox.Show("Введен некорректный ip сервера", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Client.CheckPort(port))
            {
                MessageBox.Show("Введен некорректный порт", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            client = new Client(ip, port, enterAuth, enterChat, addText, addMessage);

            loaderImg.Visible = true;
            loaderImg.Enabled = true;
            Thread connectThr = new Thread(() =>
            {
                var res = client.Connect(userName);
                Console.WriteLine("Connect result");
                Console.WriteLine(res);
                if (res != 0)
                {
                    MessageBox.Show("Не удалось подключиться к серверу", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    enterAuth();
                }
                //else
                //{
                //    //Console.WriteLine("enterChat");
                //    //enterChat();

                //}
            });
            connectThr.Start();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (messageTxt.Text.Trim() != "")
            {
                client.SendMsg(new M.SendChatMessageMsg(
                    messageTxt.Text.Trim()
                        ));
                messageTxt.Text = "";
                messageTxt.Select();
            }

        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (client == null)
            {
                Application.Exit();
            }
            else if (client.Connected)
            {
                client.Disconnect();
                enterAuth();
                e.Cancel = true;
            }

        }
    }
}
