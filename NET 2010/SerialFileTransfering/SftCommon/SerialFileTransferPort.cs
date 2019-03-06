using System;
using System.IO;
using System.IO.Ports;

namespace SftCommon
{
    public class SerialFileTransferPort
    {
		#region Fields (5) 

        private readonly MemoryStream m_memoryStream = new MemoryStream();
        private int m_nReads;
        private readonly SerialPort m_port;
        private Action<byte[], int, int> m_receivedDataCallback;
        private int m_totalBytes;

		#endregion Fields 

		#region Constructors (1) 

        public SerialFileTransferPort(uint p_portNumber)
        {
            m_port = new SerialPort("COM" + p_portNumber, 115200, Parity.Odd, 8);
            m_port.Handshake = Handshake.None;
            m_port.DataReceived += onDataReceived;
            m_port.Open();
        }

		#endregion Constructors 

		#region Methods (4) 

		// Public Methods (3) 

        public void Close()
        {
            m_port.Close();
        }

        public void RegisterReceivedDataCallback(Action<byte[], int, int> p_receivedDataCallback)
        {
            m_receivedDataCallback = p_receivedDataCallback;
        }

        public void SendData(byte[] p_buffer)
        {
            m_port.Write(p_buffer,0,p_buffer.Length);
        }
		// Private Methods (1) 

        void onDataReceived(object p_sender, SerialDataReceivedEventArgs p_e)
        {
            byte[] bytes=new byte[m_port.BytesToRead];
            int nBytes = m_port.Read(bytes, 0, bytes.Length);
            m_memoryStream.Write(bytes,0,bytes.Length);
            m_totalBytes += nBytes;
            m_nReads++;
            if (m_receivedDataCallback != null) m_receivedDataCallback(bytes, m_nReads, m_totalBytes);
        }

		#endregion Methods 
    }
}
