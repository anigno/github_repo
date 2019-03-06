using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using AnignoraCommunication.Communicators;

namespace Test
{
    class Program
    {

        public Program(string[] args)
        {
            string dnsName = Dns.GetHostName();
            Console.WriteLine(dnsName);
            MsmQueueCommunicator communicator = new MsmQueueCommunicator(args[0],int.Parse(args[1]),int.Parse(args[2]));
            communicator.OnMessageReceived += new CommunicatorHandler(communicator_OnMessageReceived);
            while (true)
            {
                Console.WriteLine("Message sent");
                communicator.SendMessage(new CommunicatorMessage());
                Thread.Sleep(1000);
            }

        }

        void communicator_OnMessageReceived(CommunicatorMessage p_communicatorMessage)
        {
            Console.WriteLine("M={0} SI={1} ID={2}",
                p_communicatorMessage.SenderMachineName,
                p_communicatorMessage.SenderQueueIndex,
                p_communicatorMessage.Id);
        }

        static void Main(string[] args)
        {
            new Program(args);
            Console.WriteLine("\n--- Enter to exit ---");

            Console.ReadLine();
        }

   
    }
}
