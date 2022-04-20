using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace AnignoLibrary.Communication.TcpCommunication.AnignoTcpClientServerB
{
    /// <summary>
    /// Tcp listener for AnignoTcpCommunicator
    /// </summary>
    public class AnignoTcpListener
    {
		#region (------------  Fields  ------------)
        private readonly TcpListener _listener;
        private Thread _acceptThread;
		#endregion (------------  Fields  ------------)


		#region (------------  Constructors  ------------)
        public AnignoTcpListener(string ipString, int port)
        {
            IPAddress ipa = IPAddress.Parse(ipString);
            _listener = new TcpListener(ipa, port);
        }
		#endregion (------------  Constructors  ------------)


		#region (------------  Events  ------------)
        public event ConnectionAcceptedHandler ConnectionAccepted;
		#endregion (------------  Events  ------------)


		#region (------------  Delegates  ------------)
        public delegate void ConnectionAcceptedHandler(AnignoTcpCommunicator communicator);
		#endregion (------------  Delegates  ------------)


		#region (------------  Private Methods  ------------)
        private void AcceptThreadStart()
        {
            _listener.Start();
            while (true)
            {
                try
                {
                    TcpClient tcpClient = _listener.AcceptTcpClient();
                    AnignoTcpCommunicator communicator = new AnignoTcpCommunicator(tcpClient);
                    if (ConnectionAccepted != null) ConnectionAccepted(communicator);
                }
                catch (SocketException)
                {
                }
            }
        }
		#endregion (------------  Private Methods  ------------)


		#region (------------  Public Methods  ------------)
        public void Start()
        {
            _acceptThread = new Thread(AcceptThreadStart);
            _acceptThread.Start();
        }

        public void Stop()
        {
            _listener.Stop();
            _acceptThread.Abort();
        }
		#endregion (------------  Public Methods  ------------)
    }
}