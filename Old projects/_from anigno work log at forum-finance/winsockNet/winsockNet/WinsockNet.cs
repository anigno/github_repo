using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace winsockNet
{
	public class WinsockNet : System.Windows.Forms.UserControl
	{
		#region Component Designer generated code
		private System.ComponentModel.Container components = null;

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.label1.ForeColor = System.Drawing.Color.Cornsilk;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "WinsockNet";
			// 
			// WinsockNet
			// 
			this.Controls.Add(this.label1);
			this.Name = "WinsockNet";
			this.Size = new System.Drawing.Size(80, 16);
			this.Load += new System.EventHandler(this.winsockNet_Load);
			this.ResumeLayout(false);

		}

		private System.Windows.Forms.Label label1;

		#endregion

		#region Constants
		public const int SOCKET_TYPE_SERVER=0;
		public const int SOCKET_TYPE_CLIENT=1;
		
		public const string EXCEPTION_PORT_NUMBER_VALUE="EXCEPTION_PORT_NUMBER_VALUE";
		public const string EXCEPTION_FAIL_TO_END_RECIEVE="EXCEPTION_FAIL_TO_END_RECIEVE";
		public const string EXCEPTION_CONNECTION_CLOSED="EXCEPTION_CONNECTION_CLOSED";
		public const string EXCEPTION_FAIL_TO_RECIEVE_DATA="EXCEPTION_FAIL_TO_RECIEVE_DATA";
		public const string EXCEPTION_LISTENER_WAS_NOT_OPEN="EXCEPTION_LISTENER_WAS_NOT_OPEN";
		public const string EXCEPTION_CLIENT_NOT_CONNECTED="EXCEPTION_CLIENT_NOT_CONNECTED";
		public const string EXCEPTION_SERVER_NOT_CONNECTED="EXCEPTION_SERVER_NOT_CONNECTED";
		public const string EXCEPTION_CONNECTION_TIMEOUT="EXCEPTION_CONNECTION_TIMEOUT";
		public const string EXCEPTION_CLIENT_NOT_OPEN="EXCEPTION_CLIENT_NOT_OPEN";
		public const string EXCEPTION_ONLY_ONE_LISTENER_ALLOW_PER_SOCKET="EXCEPTION_ONLY_ONE_LISTENER_ALLOW_PER_SOCKET";

		public const string EVENT_CLIENT_CONNECT_REQUEST="EVENT_CLIENT_CONNECT_REQUEST";
		public const string EVENT_CLIENT_CONNECTION_ACCEPTED="EVENT_CLIENT_CONNECTION_ACCEPTED";
		public const string EVENT_DATA_RECIEVED="EVENT_DATA_RECIEVED";
		public const string EVENT_DATA_PROCESSED="EVENT_DATA_PROCESSED";
		public const string EVENT_LISTENER_CLOSED="EVENT_LISTENER_CLOSED";
		public const string EVENT_CLIENT_CLOSED="EVENT_CLIENT_CLOSED";
		public const string EVENT_WAITING_FOR_DATA="EVENT_WAITING_FOR_DATA";
		public const string EVENT_FAIL_TO_RECIEVE_DATA="EVENT_FAIL_TO_RECIEVE_DATA";
		public const string EVENT_SERVER_START_LISTEN="EVENT_SERVER_START_LISTEN";
		public const string EVENT_DATA_SENT="EVENT_DATA_SENT";
		public const string EVENT_CONNECTING_TO_SERVER="EVENT_CONNECTING_TO_SERVER";
		public const string EVENT_CONNECTED_TO_SERVER="EVENT_CONNECTED_TO_SERVER";

		public const string STATE_LISTEN="STATE_LISTEN";
		public const string STATE_CONNECTED="STATE_CONNECTED";
		public const string STATE_IDLE="STATE_IDLE";
		public const string STATE_ERROR="STATE_ERROR";

		#endregion

		#region Members
		Socket _listener;
		Socket _client;
		int _bufferSize=1024;
		byte[] _buffer=new byte[1024];		//recieve buffer
		AsyncCallback _ptfClientConnected;
		AsyncCallback _ptfDataRecieved;
		IPAddress _ipAddress=IPAddress.Parse("127.0.0.1");
		int _portNumber=1000;
		string _state=STATE_IDLE;
		string _recievedString;
		Queue _eventLog=new Queue();

		#endregion

		#region Events
		public delegate void ErrorHandler(string message);
		public delegate void DataRecievedHandler();
		public delegate void ConnectionRequestRecievedHandler();
		public delegate void StateChangedHandler(string State);

		[Category("_winsockAction")]
		[Description("ErrorOccur")]
		public event ErrorHandler OnErrorOccur;
		[Category("_winsockAction")]
		[Description("Data recieved")]
		public event DataRecievedHandler OnDataRecieved;
		[Category("_winsockAction")]
		[Description("Connection request recieved")]
		public event ConnectionRequestRecievedHandler OnConnectionRequestRecieved;
		[Category("_winsockAction")]
		[Description("Connection request recieved")]
		public event StateChangedHandler OnStateChanged;

		#endregion

		#region Properties
		[Category("_winsockProperties")]
		[Description("Gets or Sets the port number of this socket")]
		public int PortNumber
		{
			get
			{
				return _portNumber;
			}
			set
			{
				if( (value>0)&&(value<=65535) )
					_portNumber=value;
				else
					throw new Exception("Port number must be positive and small then 65535!");
			}
		}

		[Category("_winsockProperties")]
		[Description("Gets or Sets the ip address for this socket")]
		public string IpAddress
		{
			get
			{
				return _ipAddress.ToString();
			}
			set
			{
				string s=value;
				_ipAddress=IPAddress.Parse(s);
			}
		}

		[Category("_winsockProperties")]
		[Description("Gets the state of this socket")]
		public string State
		{
			get
			{
				return _state;
			}
		}

		[Category("_winsockProperties")]
		[Description("Gets the string recieved from other sockect, clear the string!")]
		public string RecievedString
		{
			get
			{
				string ret=_recievedString;
				_recievedString="";
				return ret;
			}
		}

		[Category("_winsockProperties")]
		[Description("Gets or Sets the recieve buffer size")]
		public int BufferSize
		{
			get
			{
				return _bufferSize;
			}
			set
			{
				if( (value<4*1024*1024)&&(value>0) )
				{
					_bufferSize=value;
					_buffer=new byte[_bufferSize];
				}
				else
				{
					throw new Exception("Buffer size must be positive and less then 4M!");
				}//if else
			}
		}

		[Category("_winsockProperties")]
		[Description("Dequeue event from event queue")]
		public string Event
		{
			get
			{
				string ret=_eventLog.Dequeue().ToString();
				return ret;
			}
		}

		#endregion

		#region Control private functions
		//constructor
		public WinsockNet()
		{
			InitializeComponent();
			if(_ptfClientConnected==null)_ptfClientConnected=new AsyncCallback(ControlConnectionRequestRecieved);
			if(_ptfDataRecieved==null)_ptfDataRecieved=new AsyncCallback(ControlDataRecieved);
		}//WinsockNet()

		//add message to event log queue
		void addEvent(string message)
		{
			_eventLog.Enqueue(message);
			if(_eventLog.Count>300)_eventLog.Dequeue();
		}//addEvent()

		void ControlOnErrorOccur(string message)
		{
			if(OnErrorOccur!=null)
			{
				OnErrorOccur(message);
			}//if
		}//if

		void ControlStateChanged(string state)
		{
			//check if state had changes from previous state
			if(this._state!=state)
			{
				this._state=state;
				if(OnStateChanged!=null)OnStateChanged(state);
			}//if
		}//ControlStateChanged()

		void ControlConnectionRequestRecieved(IAsyncResult asyncResult)
		{
			addEvent(EVENT_CLIENT_CONNECT_REQUEST);
			try
			{
				//set _client new socket returned from listener.EndAccept()
				_client=_listener.EndAccept(asyncResult);
				addEvent(EVENT_CLIENT_CONNECTION_ACCEPTED);
				if(OnConnectionRequestRecieved!=null)OnConnectionRequestRecieved();
				ControlStateChanged(STATE_CONNECTED);
				WaitForData(_client);
			}
			catch(Exception exception)
			{
				ControlOnErrorOccur(exception.Message);
			}//catch
		}//ControlConnectionRequestRecieved()

		//server
		void ControlDataRecieved(IAsyncResult asyn)
		{
			addEvent(EVENT_DATA_RECIEVED);
			int nBytes=0;	//number of bytes recived
			try
			{
				nBytes=_client.EndReceive(asyn);
				char[] chars=new char[nBytes+1];
				//convert the recieved bytes to chars, put them in char array
				System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder();
				d.GetChars(_buffer,0,nBytes,chars,0);
				//add new string to recievedString
				_recievedString+=new System.String(chars);
				addEvent(EVENT_DATA_PROCESSED);
				if(OnDataRecieved!=null)OnDataRecieved();
				WaitForData(_client);
			}
			catch(Exception exception)
			{
				if(exception.Message=="An existing connection was forcibly closed by the remote host")
				{
					StopListen();
					ControlOnErrorOccur(exception.Message);
				}//if
			}//catch
		}//ControlDataRecieved()

		void WaitForData(System.Net.Sockets.Socket fromSocket)
		{
			addEvent(EVENT_WAITING_FOR_DATA);
			try
			{
				fromSocket.BeginReceive(_buffer,0,_buffer.Length,SocketFlags.None,_ptfDataRecieved,null);
			}
			catch(Exception exception)
			{
				ControlOnErrorOccur(exception.Message);
			}//catch
		}//WaitForData()

		#endregion

		#region Public Memeber fuctions
		public void StartListen()
		{
			addEvent(EVENT_SERVER_START_LISTEN);
			try
			{
				_listener=new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
				//set ip and port
				IPEndPoint ipAndPort = new IPEndPoint ( IPAddress.Any ,_portNumber);
				//bind socket to ip and port
				_listener.Bind(ipAndPort);
				_listener.Listen(0);	//(max listen queue, non blocking)
				_listener.BeginAccept(new AsyncCallback(ControlConnectionRequestRecieved),null);
				ControlStateChanged(STATE_LISTEN);
			}
			catch(Exception exception)
			{
				ControlOnErrorOccur(exception.Message);
				StopListen();
			}//caatch
		}//StartListen()

		public void StopListen()
		{
			if(_listener!=null)
			{
				_listener.Close();
				addEvent(EVENT_LISTENER_CLOSED);
			}//if
			if(_client!=null)
			{
				_client.Close();
				addEvent(EVENT_CLIENT_CLOSED);
			}//if
			ControlStateChanged(STATE_IDLE);
		}//StopListen()

		public void Send(string SendString)
		{
			byte[] buffer=System.Text.Encoding.ASCII.GetBytes(SendString);
			try
			{
				_client.Send(buffer);
				addEvent(EVENT_DATA_SENT);
			}
			catch(Exception exception)
			{
				 ControlOnErrorOccur(exception.Message);
			}//catch
		}//Send()

		public void Connect()
		{
			if(_state==STATE_CONNECTED)return;
			_client=new Socket (AddressFamily.InterNetwork,SocketType.Stream ,ProtocolType.Tcp );
			addEvent(EVENT_CONNECTING_TO_SERVER);
			IPAddress ip=IPAddress.Parse(IpAddress);
			IPEndPoint ipAndPort = new IPEndPoint (ip.Address,PortNumber);
			try
			{
				_client.Connect(ipAndPort);
				addEvent(EVENT_CONNECTED_TO_SERVER);
				WaitForData(_client);
				ControlStateChanged(STATE_CONNECTED);
			}
			catch(Exception exception)
			{
				ControlOnErrorOccur(exception.Message);
			}//catch
		}//Connect()

		public void Disconnect()
		{
			try
			{
				if(_client!=null)
				{
					_client.Close();
					addEvent(EVENT_CLIENT_CLOSED);
					ControlStateChanged(STATE_IDLE);
				}//if
			}
			catch(Exception exception)
			{
				ControlOnErrorOccur(exception.Message);
			}//catch
		}//Disconnect()
		#endregion

		#region Control's form events
		private void winsockNet_Load(object sender, System.EventArgs e)
		{		
		}//winsockNet_Load()
		#endregion



	}//class WinsockNet
}//namespace
