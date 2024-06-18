using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Invoke((Action)(() => {
                ipTxt.Visible = true;
                portTxt.Visible = true;
                userNameTxt.Visible = true;
                ipLabel.Visible = true;
                portLabel.Visible = true;
                userNameLabel.Visible = true;
                loaderImg.Visible = false;

                ipLabel.Enabled = true;
                portLabel.Enabled = true;
                userNameLabel.Enabled = true;
                ipTxt.Enabled = true;
                portTxt.Enabled = true;
                userNameTxt.Enabled = true;
                loaderImg.Enabled = false;
            }));
        }


        private void addText(string message)
        {
            Invoke((Action)(() => { 
                chatViwer.AppendText(message + "\n");
            }));
        }
        private void enterChat()
        {
            Invoke((Action)(() => {
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

            client = new Client(ip, port, /*chatViwer,*/ enterAuth, enterChat, addText);

            loaderImg.Visible = true;
            loaderImg.Enabled = true;
            var res = client.Connect(userName); // todo подключаться в второстепенном потоке
            Console.WriteLine("Connect result");
            Console.WriteLine(res);
            if (res != 0) 
            {
                MessageBox.Show("Не удалось подключиться к серверу", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 
            else 
            {
                Console.WriteLine("enterChat");
                enterChat();
            }
        }
    }
}
