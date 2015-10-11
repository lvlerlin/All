using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using Engine;

namespace Test_Client
{
    public partial class Select_Server_UI : Form
    {
        public Socket clientSocket;
        public string strServerName;

        IniParser CONFIG_FILE;

        public static string[] server;
        public static int[] server_port;
        public Select_Server_UI()
        {
            InitializeComponent();
            txtName.SelectedIndex = 0;

            CONFIG_FILE = new IniParser("Config.ini");
            server = new string[]
            {
                CONFIG_FILE.GetSetting("Servers", "Server1"),
                CONFIG_FILE.GetSetting("Servers", "Server2"),
                CONFIG_FILE.GetSetting("Servers", "Server3")
            };

            server_port = new int[]
                {
                    Convert.ToInt32(CONFIG_FILE.GetSetting("Ports", "Port1")),
                    Convert.ToInt32(CONFIG_FILE.GetSetting("Ports", "Port2")),
                    Convert.ToInt32(CONFIG_FILE.GetSetting("Ports", "Port3"))
                };
            

        }
        IPAddress ipAddress;
        int port;
        private void btnOK_Click(object sender, EventArgs e)
        {
            switch(txtName.SelectedIndex)
            {
                case 0:
                    ipAddress = IPAddress.Parse(server[0]);
                    port = server_port[0];
                    break;
                case 1:
                    ipAddress = IPAddress.Parse(server[1]);
                    port = server_port[1];
                    break;
                case 2:
                    ipAddress = IPAddress.Parse(server[2]);
                    port = server_port[2];
                    break;
                default:
                    return;
            }
            if ((ipAddress == null) ||
                (port == -1))
                return;
            try
            {
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


                //Server is listening on port 1000
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, port);

                //Connect to the server
                clientSocket.BeginConnect(ipEndPoint, new AsyncCallback(OnConnect), null);
            }
            catch
            {
            }
        }

        private void OnSend(IAsyncResult ar)
        {
            try
            {
                clientSocket.EndSend(ar);
                strServerName = "TEST_CLIENT";
                DialogResult = DialogResult.OK;
                Close();
            }
            catch
            {
               
            }
        }

        private void OnConnect(IAsyncResult ar)
        {
            try
            {
                clientSocket.EndConnect(ar);

                //We are connected so we login into the server
                Data msgToSend = new Data ();
                msgToSend.cmdCommand = Command.Login;
                msgToSend.strName = "TEST_CLIENT";
                msgToSend.strMessage = null;

                byte[] b = msgToSend.ToByte ();

                //Send the message to the server
                clientSocket.BeginSend(b, 0, b.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
            }
            catch
            { 

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtServerIP_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}