using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using AnignoraCommunication.Communicators;

namespace msmqSender
{
    class Program
    {
        public Program()
        {
            MsmQueueCommunicator communicator = new MsmQueueCommunicator("anignora-laptop", 100, 100);
            communicator.OnMessageReceived += new CommunicatorHandler(communicator_OnMessageReceived);
            while (true)
            {
                Console.WriteLine("Message sent");
                communicator.SendMessage(new CommunicatorMessage());
                Thread.Sleep(1000);
            }
        }
        static void Main(string[] args)
        {
            new Program();
        }
        
        void communicator_OnMessageReceived(CommunicatorMessage p_communicatorMessage)
        {
            Console.WriteLine("M={0} SI={1} ID={2}",
                p_communicatorMessage.SenderMachineName,
                p_communicatorMessage.SenderQueueIndex,
                p_communicatorMessage.Id);
        }
    }
}
