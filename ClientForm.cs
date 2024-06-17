using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

            client = new Client(ip, port, chatViwer);
            client.Connect(userName);
        }
    }
}
