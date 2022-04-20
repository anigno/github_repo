using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using AnignoLibrary.Communication.CommunicationBase;

namespace AnignoLibrary.Communication.TcpCommunication
{
    /// <summary>
    /// Listen to connection requests and produces TcpCommunicators
    /// </summary>
    public class TcpCommunicationListener
    {
        public delegate void OnClientConnectionAcceptedDelegate(TcpCommunicator worker);
        public event OnClientConnectionAcceptedDelegate OnClientConnectionAccepted;
        TcpListener _listener;
        private int _receiveBufferSize;
        private int _sendBufferSize;

        public TcpCommunicationListener(int receiveBufferSize,int sendBufferSize,IPEndPoint localIPE)
        {
            _listener = new TcpListener(localIPE);
            _receiveBufferSize = receiveBufferSize;
            _sendBufferSize = sendBufferSize;

        }

        public void StartListening()
        {
            _listener.Start();
            _listener.BeginAcceptTcpClient(BeginAcceptCallBack, _listener);
        }

        public void StopListening()
        {
            _listener.Stop();
        }

        private void BeginAcceptCallBack(IAsyncResult asyncRes)
        {
            TcpClient workerTcpClient = _listener.EndAcceptTcpClient(asyncRes);
            TcpCommunicator tcpCommunicator = new TcpCommunicator(_receiveBufferSize, _sendBufferSize, workerTcpClient);
            if (OnClientConnectionAccepted != null) OnClientConnectionAccepted(tcpCommunicator);
            _listener.BeginAcceptTcpClient(BeginAcceptCallBack, _listener);
        }


    }
}
