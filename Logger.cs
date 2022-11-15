using System;
using System.IO;
using System.Text;

namespace Console_Application
{
    public static class Logger
    {
        public static void WriteLog(String msg)
        {
            try
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"./log.log", true))
                    {
                        file.WriteLine($"{DateTime.Now}: {msg}");
                    }
                    
                }
            catch (Exception ex)
                {
                    
                    throw new ApplicationException("Fail to Write to log!", ex);
                }
        }
    }
}