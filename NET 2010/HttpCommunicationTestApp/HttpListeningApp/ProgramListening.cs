using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnignoraCommunication.Http;

namespace HttpListeningApp
{
    class ProgramListening
    {
        private readonly HttpAgent m_agent = new HttpAgent("127.0.0.1", 51111, "Dir1");

        public ProgramListening()
        {
            m_agent.StartListening();
            m_agent.HttpAgentRequestReceived += m_agent_HttpAgentRequestReceived;
        }

        void m_agent_HttpAgentRequestReceived(object p_sender, HttpAgentRequestReceivedEventArgs p_e)
        {
            Console.WriteLine(p_e);
        }
        
        static void Main(string[] args)
        {
            new ProgramListening();
            Console.WriteLine("HttpListeningApp, Enter to exit");
            Console.ReadLine();
        }
    }
}
