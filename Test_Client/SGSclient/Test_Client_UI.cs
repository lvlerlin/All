using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using Engine;

namespace Test_Client
{
    //The commands for interaction between the server and the client
    enum Command
    {
        Login,      //Log into the server
        Logout,     //Logout of the server
        Message,    //Send a text message to all the chat clients
        List,       //Get a list of users in the chat room from the server
        Command,    //Game Command
        PrivateMessage,
        Pulse,
        NewLogin,
        Null        //No command
    }

    public partial class Test_Client : Form
    {
        public Socket clientSocket; //The main client socket
        public string strServerName;      //Name by which the user logs into the room
        public int user_index;
        private byte[] byteData = new byte[1024];

        //Game Logger (Game Logs ##-##-####.txt)
        Test_Client_Logger logging;
        //Error parser
        Packet_Error error;

        public Test_Client()
        {
            InitializeComponent();
            logging = new Test_Client_Logger();
            error = new Packet_Error(logging, txtChatBox);
            timer1.Start();
        }

        private void OnSend(IAsyncResult ar)
        {
            try
            {
                clientSocket.EndSend(ar);
            }
            catch
            {
                
            }
        }

        string[] char_Info = new string[]
            {
                "Character Slot : ",    //0
                "Character Name : ",    //1
                "Character Level : ",   //2
                "Character EXP : ",     //3
                "Character Gold : ",    //4
                "Character Vit : ",     //5
                "Character Str : ",     //6
                "Character Int : ",     //7
                "Character Wis : ",     //8
                "Character Dex : ",     //9
                "Character Char : "     //10
            };

        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                clientSocket.EndReceive(ar);

                Data msgReceived = new Data(byteData);
                
                //Accordingly process the message received
                switch (msgReceived.cmdCommand)
                {
                    case Command.Login:     
                        lstChatters.Items.Add(msgReceived.strName);
                        break;

                    case Command.Logout:
                        lstChatters.Items.Remove(msgReceived.strName);
                        break;

                    case Command.Message:
                        break;
                    case Command.Command:
                        if (msgReceived.strMessage.Contains("@ERROR"))
                        {
                            string[] words = msgReceived.strMessage.Split('\t');
                                logging.Logging(string.Format("word 1 = {0} word 2 = {1}",
                                    words[0],
                                    words[1]));
                                error.ERROR(Convert.ToInt32(words[1]));                                
                        }
                        else if (msgReceived.strMessage.Contains("@load_Char"))
                        {
                            logging.Logging(string.Format("From Server {0}", msgReceived.strMessage));
                            string[] words = msgReceived.strMessage.Split('=', ' ');
                            
                            int logThismany = words.Length;
                            logging.Logging(string.Format("DEBUG :  parma count : {0}", words.Length));
                            if (logThismany < 22)
                                break;
                            for(int i = 0; i < logThismany; i++)
                            {
                                #region DULL
                                switch (i)
                                {
                                    case 2:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[0],
                                            words[i]));
                                        break;
                                    case 4:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[1],
                                            words[i]));
                                        break;
                                    case 6:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[2],
                                            words[i]));
                                        break;
                                    case 8:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[3],
                                            words[i]));
                                        break;
                                    case 10:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[4],
                                            words[i]));
                                        break;
                                    case 12:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[5],
                                            words[i]));
                                        break;
                                    case 14:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[6],
                                            words[i]));
                                        break;
                                    case 16:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[7],
                                            words[i]));
                                        break;
                                    case 18:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[8],
                                            words[i]));
                                        break;
                                    case 20:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[9],
                                            words[i]));
                                        break;
                                    case 22:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[10],
                                            words[i]));
                                        break;
                                    case 24:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[0],
                                            words[i]));
                                        break;
                                    case 26:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[1],
                                            words[i]));
                                        break;
                                    case 28:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[2],
                                            words[i]));
                                        break;
                                    case 30:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[3],
                                            words[i]));
                                        break;
                                    case 32:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[4],
                                            words[i]));
                                        break;
                                    case 34:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[5],
                                            words[i]));
                                        break;
                                    case 36:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[6],
                                            words[i]));
                                        break;
                                    case 38:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[7],
                                            words[i]));
                                        break;
                                    case 40:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[8],
                                            words[i]));
                                        break;
                                    case 42:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[9],
                                            words[i]));
                                        break;
                                    case 44:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[10],
                                            words[i]));
                                        break;
                                    case 46:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[0],
                                            words[i]));
                                        break;
                                    case 48:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[1],
                                            words[i]));
                                        break;
                                    case 50:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[2],
                                            words[i]));
                                        break;
                                    case 52:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[3],
                                            words[i]));
                                        break;
                                    case 54:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[4],
                                            words[i]));
                                        break;
                                    case 56:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[5],
                                            words[i]));
                                        break;
                                    case 58:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[6],
                                            words[i]));
                                        break;
                                    case 60:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[7],
                                            words[i]));
                                        break;
                                    case 62:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[8],
                                            words[i]));
                                        break;
                                    case 64:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[9],
                                            words[i]));
                                        break;
                                    case 66:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[10],
                                            words[i]));
                                        break;
                                    case 68:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[0],
                                            words[i]));
                                        break;
                                    case 70:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[1],
                                            words[i]));
                                        break;
                                    case 72:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[2],
                                            words[i]));
                                        break;
                                    case 74:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[3],
                                            words[i]));
                                        break;
                                    case 76:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[4],
                                            words[i]));
                                        break;
                                    case 78:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[5],
                                            words[i]));
                                        break;
                                    case 80:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[6],
                                            words[i]));
                                        break;
                                    case 82:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[7],
                                            words[i]));
                                        break;
                                    case 84:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[8],
                                            words[i]));
                                        break;
                                    case 86:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[9],
                                            words[i]));
                                        break;
                                    case 88:
                                        logging.Logging(string.Format("{0}{1}",
                                            char_Info[10],
                                            words[i]));
                                        break;
                                    default:
                                        break;
                                }
                                #endregion
                            }
                        }
                        else
                            logging.Logging(string.Format("From Server {0}", msgReceived.strMessage));
                        break;
                    case Command.List:
                        lstChatters.Items.AddRange(msgReceived.strMessage.Split('*'));
                        lstChatters.Items.RemoveAt(lstChatters.Items.Count - 1);
                        txtChatBox.Text += strServerName + " connected\r\n";
                        break;                    
                }

                if (msgReceived.strMessage != null && msgReceived.cmdCommand != Command.List && msgReceived.cmdCommand != Command.Command)
                    txtChatBox.Text += msgReceived.strMessage + "\r\n";

                byteData = new byte[1024];

                clientSocket.BeginReceive(byteData,
                                          0, 
                                          byteData.Length,
                                          SocketFlags.None,
                                          new AsyncCallback(OnReceive),
                                          null);
                 
            }
            catch (ObjectDisposedException)
            { }
            catch
            {
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.Text = "Test Client: " + strServerName;
            
            //The user has logged into the system so we now request the server to send
            //the names of all users who are in the chat room
            Data msgToSend = new Data ();
            msgToSend.cmdCommand = Command.List;
            msgToSend.strName = strServerName;
            msgToSend.strMessage = null;
            
            byteData = msgToSend.ToByte();

            clientSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
            
            byteData = new byte[1024];
            //Start listening to the data asynchronously
            clientSocket.BeginReceive(byteData,
                                       0, 
                                       byteData.Length,
                                       SocketFlags.None,
                                       new AsyncCallback(OnReceive),
                                       null);

        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            if (txtMessage.Text.Length == 0)
                btnSend.Enabled = false;
            else
                btnSend.Enabled = true;
        }

        private void Test_Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to leave the chat room?", "Test Client: " + strServerName,
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            try
            {
                //Send a message to logout of the server
                Data msgToSend = new Data ();
                msgToSend.cmdCommand = Command.Logout;
                msgToSend.strName = strServerName;
                msgToSend.strMessage = null;

                byte[] b = msgToSend.ToByte ();
                clientSocket.Send(b, 0, b.Length, SocketFlags.None);
                clientSocket.Close();
            }
            catch (ObjectDisposedException)
            { }
            catch 
            {

            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if ((usernameBox.Text.Length < 3) ||
                (passwordBox.Text.Length < 3))
                return;
            else
            {
                LoginData msgToSend = new LoginData();

                msgToSend.strUsername = usernameBox.Text;
                msgToSend.strPassword = passwordBox.Text;
                msgToSend.cmdCommand = Command.NewLogin;
                byte[] byteData = msgToSend.ToByte();

                clientSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
                txtMessage.Text = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void cAccountButton_Click(object sender, EventArgs e)
        {

        }

        private void btnSend_Click_1(object sender, EventArgs e)
        {
            if (txtMessage.Text.Contains("@"))
            {
                try
                {
                    Data msgToSend = new Data();
                    msgToSend.strName = "TEST_CLIENT";
                    msgToSend.strMessage = txtMessage.Text;
                    msgToSend.cmdCommand = Command.Command;
                    logging.Logging(string.Format("To Server : {0}\r\nPacket Type : Command\r\nServer : {1}",
                        msgToSend.strMessage,
                        msgToSend.strName));
                    byte[] byteData = msgToSend.ToByte();

                    clientSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
                    txtMessage.Text = null;
                }
                catch
                {

                }
            }
            else if (txtMessage.Text.Contains("/"))
            {
                try
                {
                    string[] temp = new string[65535];
                    Data msgToSend = new Data();
                    msgToSend.strName = "TEST_CLIENT";
                    if (txtMessage.Text.Contains(" "))
                    {
                        txtMessage.Text.Replace('/', ' ');
                        temp = txtMessage.Text.Split(' ');
                    }
                    msgToSend.strToUser = temp[0];
                    for (int i =1; i<temp.Length; i++)
                    {
                        msgToSend.strMessage += temp[i] + " ";
                    }
                    if (msgToSend.strMessage.Length <= 0)
                        return;
                    msgToSend.cmdCommand = Command.PrivateMessage;

                    byte[] byteData = msgToSend.ToByte();

                    clientSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
                    txtMessage.Text = null;                    
                }
                catch
                {

                }
            }
            else
            {
                try
                {
                    //Fill the info for the message to be send
                    Data msgToSend = new Data();
                    msgToSend.strName = "TEST_CLIENT";
                    msgToSend.strMessage = txtMessage.Text;
                    msgToSend.cmdCommand = Command.Message;
                    logging.Logging(string.Format("To Server : {0}\r\nPacket Type : Message\r\nServer : {1}",
                        msgToSend.strMessage,
                        msgToSend.strName));
                    byte[] byteData = msgToSend.ToByte();

                    //Send it to the server
                    clientSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnSend), null);

                    txtMessage.Text = null;
                }
                catch
                {

                }
            }
        }

        private void txtMessage_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSend_Click_1(sender, null);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Data msgToSend = new Data();
                msgToSend.cmdCommand = Command.Pulse;
                msgToSend.strName = "TEST_CLIENT";
                msgToSend.strMessage = "TESTING";
                byte[] message;
                message = msgToSend.ToByte();
                clientSocket.BeginSend(message, 0, message.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
            }
            catch
            {

            }
        }
    }

    //The data structure by which the server and the client interact with 
    //each other
    class LoginData
    {
        public string strUsername;      //Name by which the client logs into the room
        public string strPassword;   //Message text
        public Command cmdCommand;
        public LoginData()
        {
            this.cmdCommand = Command.Null;
            this.strUsername = null;
            this.strPassword = null;
        }

        public LoginData(byte[] data)
        {
            this.cmdCommand = (Command)BitConverter.ToInt32(data, 0);
            int userNameLen = BitConverter.ToInt32(data, 4);
            int passwordLen = BitConverter.ToInt32(data, 8);

            if (userNameLen > 0)
                this.strUsername = Encoding.UTF8.GetString(data, 12, userNameLen);
            else
                this.strUsername = null;

            if (passwordLen > 0)
                this.strPassword = Encoding.UTF8.GetString(data, 8, passwordLen);
            else
                this.strPassword = null;
        }

        public byte[] ToByte()
        {
            List<byte> result = new List<byte>();
            result.AddRange(BitConverter.GetBytes((int)cmdCommand));

            if (strUsername != null)
                result.AddRange(BitConverter.GetBytes(strUsername.Length));
            else
                result.AddRange(BitConverter.GetBytes(0));

            if (strPassword != null)
                result.AddRange(BitConverter.GetBytes(strPassword.Length));
            else
                result.AddRange(BitConverter.GetBytes(0));

            if (strUsername != null)
                result.AddRange(Encoding.UTF8.GetBytes(strUsername));

            if (strPassword != null)
                result.AddRange(Encoding.UTF8.GetBytes(strPassword));

            return result.ToArray();
        }
    }
    class Data
    {
        //Default constructor
        public Data()
        {
            this.cmdCommand = Command.Null;
            this.strMessage = null;
            this.strToUser = null;
            this.strName = null;
        }

        //Converts the bytes into an object of type Data
        public Data(byte[] data)
        {
            //The first four bytes are for the Command
            this.cmdCommand = (Command)BitConverter.ToInt32(data, 0);

            //The next four store the length of the name
            int nameLen = BitConverter.ToInt32(data, 4);

            //The next four store the length of the message
            int msgLen = BitConverter.ToInt32(data, 8);

            int toUserLen = BitConverter.ToInt32(data, 12);

            //This check makes sure that strName has been passed in the array of bytes
            if (nameLen > 0)
                this.strName = Encoding.UTF8.GetString(data, 16, nameLen);
            else
                this.strName = null;

            //This checks for a null message field
            if (msgLen > 0)
                this.strMessage = Encoding.UTF8.GetString(data, 16 + nameLen, msgLen);
            else
                this.strMessage = null;

            if (toUserLen > 0)
                this.strToUser = Encoding.UTF8.GetString(data, 16 + nameLen + toUserLen, msgLen);
            else
                this.strToUser = null;
        }

        //Converts the Data structure into an array of bytes
        public byte[] ToByte()
        {
            List<byte> result = new List<byte>();

            //First four are for the Command
            result.AddRange(BitConverter.GetBytes((int)cmdCommand));

            //Add the length of the name
            if (strName != null)
                result.AddRange(BitConverter.GetBytes(strName.Length));
            else
                result.AddRange(BitConverter.GetBytes(0));

            //Length of the message
            if (strMessage != null)
                result.AddRange(BitConverter.GetBytes(strMessage.Length));
            else
                result.AddRange(BitConverter.GetBytes(0));

            if (strToUser != null)
                result.AddRange(BitConverter.GetBytes(strToUser.Length));
            else
                result.AddRange(BitConverter.GetBytes(0));

            //Add the name
            if (strName != null)
                result.AddRange(Encoding.UTF8.GetBytes(strName));

            //And, lastly we add the message text to our array of bytes
            if (strMessage != null)
                result.AddRange(Encoding.UTF8.GetBytes(strMessage));

            if (strToUser != null)
                result.AddRange(Encoding.UTF8.GetBytes(strToUser));

            return result.ToArray();
        }

        public string strName;      //Name by which the client logs into the room
        public string strMessage;   //Message text
        public string strToUser;
        public Command cmdCommand;  //Command type (login, logout, send message, etcetera)
    }
}