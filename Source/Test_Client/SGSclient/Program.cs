using System;
using System.Windows.Forms;

namespace Test_Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);            

            Select_Server_UI loginForm = new Select_Server_UI();

            Application.Run(loginForm);
            if (loginForm.DialogResult == DialogResult.OK)
            {
                Test_Client do_Login = new Test_Client();
                do_Login.clientSocket = loginForm.clientSocket;
                do_Login.strServerName = loginForm.strServerName;

                do_Login.ShowDialog();
            }

        }
    }
}