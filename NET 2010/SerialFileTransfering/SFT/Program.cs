using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SftCommon;

namespace SFT
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Usage: SFT.EXE Send/Receive PortNumber FileName");
                return;
            }
            string sAction = args[0].ToUpper();
            uint portNum = uint.Parse(args[1]);
            string filename = args[2];
            if (args[0].ToUpper() == "SEND") sendFile(portNum, filename);
            if (args[0].ToUpper() == "RECEIVE") receiveFile(portNum, filename);
        }

        private static void receiveFile(uint p_portNum, string p_filename)
        {
            SerialFileTransferPort receiver = new SerialFileTransferPort(p_portNum);
            MemoryStream ms = new MemoryStream();
            receiver.RegisterReceivedDataCallback((p_bytes, p_nReads, p_totalBytes) =>
            {
                Console.WriteLine("Bytes read: {0} {1} : {2}", p_nReads, p_bytes.Length, p_totalBytes);
                ms.Write(p_bytes, 0, p_bytes.Length);
                if (p_bytes.Length >= 2)
                {
                    if (p_bytes[p_bytes.Length - 1] == 0xAA && p_bytes[p_bytes.Length - 2] == 0x55)
                    {
                        MemoryStream msFile = new MemoryStream(ms.ToArray(), 0, (int)(ms.Length - 2));
                        File.WriteAllBytes(p_filename, msFile.ToArray());
                        Console.WriteLine("Writen file: {0} {1} bytes", p_filename, msFile.Length);
                    }
                }
            });
            Console.WriteLine("Waiting");
            Console.ReadKey();
        }

        private static void sendFile(uint p_portNum, string p_filename)
        {
            SerialFileTransferPort sender = new SerialFileTransferPort(p_portNum);
            byte[] fileReadBytes = File.ReadAllBytes(p_filename);
            sender.SendData(fileReadBytes);
            Thread.Sleep(2000);
            sender.SendData(new byte[] { 0x55, 0xAA });
            Console.WriteLine("{0} Sent done", p_filename);
        }
    }

}
