using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnignoLibrary.Communication.CommunicationBase;
using System.Net;
using System.Net.Sockets;
using AnignoLibrary.DataTypes;
using System.Threading;

namespace AnignoLibrary.Communication.TcpCommunication
{
    public class TcpCommunicator : CommunicatorBase
    {
        public delegate void OnClientIsDisconnectedDelegate();
        public event OnClientIsDisconnectedDelegate OnClientIsDisconnected;
        public delegate void OnMessageSentDelegate(IPEndPoint remoteIPE, byte[] bytes);
        public event OnMessageSentDelegate OnMessageSent;
        public delegate void OnMessageReceivedDelegate(IPEndPoint remoteIPE, byte[] objectBytes);
        public event OnMessageReceivedDelegate OnMessageReceived;

        private TcpClient _client;
        private int _receiveBufferSize;
        private int _sendBufferSize;
        private NetworkStream _netStream;
        private Thread _receivingThread = null;

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="maxMessageSize"></param>
        /// <param name="localIPE"></param>
        public TcpCommunicator(int receiveBufferSize, int sendBufferSize, IPEndPoint localIPE)
            : base(localIPE)
        {
            _receiveBufferSize = receiveBufferSize;
            _sendBufferSize = sendBufferSize;
            _client = new TcpClient(localIPE);
            _client.SendBufferSize = _sendBufferSize;
            _client.ReceiveBufferSize = _receiveBufferSize;
        }

        /// <summary>
        /// CTOR, internal, used by TcpCommunicationListener when accepting a connection request to create new TcpCommunicator
        /// </summary>
        /// <param name="maxMessageSize"></param>
        /// <param name="tcpClient"></param>
        internal TcpCommunicator(int sendBufferSize, int receiveBufferSize, TcpClient tcpClient)
            : base((IPEndPoint)tcpClient.Client.LocalEndPoint)
        {
            _sendBufferSize = sendBufferSize;
            _receiveBufferSize = receiveBufferSize;
            _client = tcpClient;
            _receiveBufferSize = receiveBufferSize;
            _sendBufferSize = sendBufferSize;
            _client.SendBufferSize = _sendBufferSize;
            _client.ReceiveBufferSize = _receiveBufferSize;
            _netStream = _client.GetStream();
        }

        //Connect to TcpCommunicationListener, blocking call
        public void Connect(IPEndPoint remoteIPE)
        {
            _client.Connect(remoteIPE);
            _netStream = _client.GetStream();
        }


        #region CommunicatorBase
        public override void Send(byte[] sendBuffer, IPEndPoint remoteIPE)
        {
            if (_client.Connected)
            {
                byte[] bufferWithHeader = GetTcpLengthHeader(sendBuffer);
                CommunicationMessage message = new CommunicationMessage(LocalIPE, remoteIPE, bufferWithHeader);
                CommunicationBaseSendMessage(message);
            }
            else
            {
                if (OnClientIsDisconnected != null) OnClientIsDisconnected();
            }
        }

        public override void SendCommunicationMessageCallBack(CommunicationMessage message)
        {
            _netStream.Write(message.Buffer, 0, message.Buffer.Length);
        }

        public override void StartReceiving()
        {
            if (_receivingThread == null)
            {
                _receivingThread = new Thread((ThreadStart)ReceiveThreadStart);
                _receivingThread.Start();
            }
        }

        public override void StopReceiving()
        {
            _receivingThread.Abort();
            _receivingThread = null;
        }

        public override void CommunicationMessageSentCallBack(CommunicationMessage message)
        {
            RemoveMessageFromQueue(message);
            DynamicArray<byte> da = new DynamicArray<byte>(message.Buffer.Length);
            da.Append(message.Buffer, 0, message.Buffer.Length);
            if (OnMessageSent != null) OnMessageSent(message.RemoteIPE, da.Cut(4, da.Length - 4));
        }

        #endregion

        private byte[] GetTcpLengthHeader(byte[] buffer)
        {
            byte[] lengthBytes = BitConverter.GetBytes(buffer.Length);
            DynamicArray<byte> da = new DynamicArray<byte>(4 + buffer.Length);
            da.Append(lengthBytes, 0, 4);
            da.Append(buffer, 0, buffer.Length);
            return da.ToArray();
        }

        private void ReceiveThreadStart()
        {
            byte[] receiveBuffer = new byte[_receiveBufferSize];
            DynamicArray<byte> totalReceivedDA = new DynamicArray<byte>(_receiveBufferSize);
            int lastKnownLength = -1;
            while (true)
            {
                int avaliable = _client.Available;
                if (avaliable > 0)
                {
                    _netStream.Read(receiveBuffer, 0, avaliable);
                    totalReceivedDA.Append(receiveBuffer, 0, avaliable);
                    //Checks if there are previous object's parts received already
                    if (lastKnownLength < 0)
                    {
                        //No object parts received, extract next object length
                        byte[] lengthBytes = totalReceivedDA.Cut(0, 4);
                        lastKnownLength = BitConverter.ToInt32(lengthBytes, 0);
                    }
                    //Checks if full object has been received
                    if (totalReceivedDA.Length >= lastKnownLength)
                    {
                        byte[] objectBytes = totalReceivedDA.Cut(0, lastKnownLength);
                        lastKnownLength = -1;
                        if (OnMessageReceived != null) OnMessageReceived((IPEndPoint)_client.Client.RemoteEndPoint, objectBytes);
                    }
                }
                Thread.Sleep(1000);
            }

        }
    }
}