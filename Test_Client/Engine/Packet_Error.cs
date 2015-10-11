using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engine
{
    public class Packet_Error
    {
        Test_Client_Logger logger;
        TextBox debug;

        public Packet_Error(Test_Client_Logger loggin, TextBox _clDebuger)
        {
            logger = loggin;
            debug = _clDebuger;
        }

        public void ERROR(int which)
        {
            string tempErrorString = "ERROR";
            switch(which)
            {
                case 0:
                    tempErrorString = "Password and/or Username length is not long enough";
                    break;
                case 1:
                    tempErrorString = "Indexes do not match";
                    break;
                case 2:
                    tempErrorString = "Login command is incorrect";
                    break;
                case 3:
                    tempErrorString = "Unknown Command";
                    break;
                case 4:
                    tempErrorString = "Login details are in correct";
                    break;
                case 5:
                    tempErrorString = "";
                    break;
                default:
                    tempErrorString = "Unknown Error";
                    break;
            }
            logger.Logging(string.Format("{0}", tempErrorString));
            debug.Text += string.Format("{0}", tempErrorString);
        }
    }
}
