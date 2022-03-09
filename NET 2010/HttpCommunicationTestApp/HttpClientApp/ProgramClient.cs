using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using AnignoraCommunication.Http;

namespace HttpClientApp
{
    class ProgramClient
    {
        private readonly HttpAgent m_agent = new HttpAgent("127.0.0.1", 51111, "Dir1");

        public ProgramClient()
        {
            for (int a = 100; a > 1; a -= 1)
            {
                try
                {
                    string sTime = DateTime.Now.ToString("hh:mm:ss.fff");
                    m_agent.Send(sTime);
                    Console.WriteLine(sTime);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Thread.Sleep(a);
            }
            return;
            string text;
            do
            {
                text = Console.ReadLine();
                m_agent.Send(text);
            } while (text != "");
        }

        static void Main(string[] args)
        {
            new ProgramClient();
            Console.WriteLine("HttpClientApp, Enter to exit");
            Console.ReadLine();
        }
    }
}
