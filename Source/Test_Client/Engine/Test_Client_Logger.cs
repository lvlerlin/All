using System;
using System.IO;
using System.Linq;

namespace Engine
{
    public class Test_Client_Logger
    {
        public Test_Client_Logger()
        {

        }

        public void Logging(string input)
        {
            string dateTime_Now = DateTime.Now.ToString("dd.MM.yyyy");
            if (dateTime_Now.Contains('.'))
                dateTime_Now = dateTime_Now.Replace(".", "-");
            if (dateTime_Now.Contains(':'))
                dateTime_Now = dateTime_Now.Replace(":", "-");
            File.AppendAllText(string.Format("Game Logs - {0}.txt", 
                dateTime_Now), 
                string.Format("{0}\t{1}\r\n", 
                DateTime.Now.ToString(),
                input));
        }
    }
}
