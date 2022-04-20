using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace testApplication
{
	/// <summary>
	/// Summary description for Form2.
	/// </summary>
	public class Form2 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListBox lstEvents;
		private System.Windows.Forms.TextBox txtRecieved;
		private System.Windows.Forms.TextBox txtSend;
		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.Label label1;
		private winsockNet.WinsockNet socClient;
		private System.Windows.Forms.Button btnDisconnect;
		private System.Windows.Forms.Button btnConnect;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form2()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lstEvents = new System.Windows.Forms.ListBox();
			this.txtRecieved = new System.Windows.Forms.TextBox();
			this.txtSend = new System.Windows.Forms.TextBox();
			this.btnSend = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.socClient = new winsockNet.WinsockNet();
			this.btnDisconnect = new System.Windows.Forms.Button();
			this.btnConnect = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lstEvents
			// 
			this.lstEvents.ItemHeight = 16;
			this.lstEvents.Location = new System.Drawing.Point(2, 154);
			this.lstEvents.Name = "lstEvents";
			this.lstEvents.Size = new System.Drawing.Size(288, 116);
			this.lstEvents.TabIndex = 11;
			// 
			// txtRecieved
			// 
			this.txtRecieved.Location = new System.Drawing.Point(2, 74);
			this.txtRecieved.Multiline = true;
			this.txtRecieved.Name = "txtRecieved";
			this.txtRecieved.Size = new System.Drawing.Size(288, 80);
			this.txtRecieved.TabIndex = 10;
			this.txtRecieved.Text = "";
			// 
			// txtSend
			// 
			this.txtSend.Location = new System.Drawing.Point(82, 50);
			this.txtSend.Name = "txtSend";
			this.txtSend.Size = new System.Drawing.Size(208, 22);
			this.txtSend.TabIndex = 9;
			this.txtSend.Text = "";
			// 
			// btnSend
			// 
			this.btnSend.Location = new System.Drawing.Point(2, 50);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(80, 23);
			this.btnSend.TabIndex = 8;
			this.btnSend.Text = "Send";
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(104, 0);
			this.label1.Name = "label1";
			this.label1.TabIndex = 12;
			this.label1.Text = "client";
			// 
			// socClient
			// 
			this.socClient.BufferSize = 1024;
			this.socClient.IpAddress = "127.0.0.1";
			this.socClient.Location = new System.Drawing.Point(208, 0);
			this.socClient.Name = "socClient";
			this.socClient.PortNumber = 1000;
			this.socClient.Size = new System.Drawing.Size(80, 16);
			this.socClient.TabIndex = 13;
			this.socClient.OnDataRecieved += new winsockNet.WinsockNet.DataRecievedHandler(this.socClient_OnDataRecieved);
			this.socClient.OnErrorOccur += new winsockNet.WinsockNet.ErrorHandler(this.socClient_OnErrorOccur);
			this.socClient.OnConnectionRequestRecieved += new winsockNet.WinsockNet.ConnectionRequestRecievedHandler(this.socClient_OnConnectionRequestRecieved);
			this.socClient.OnStateChanged += new winsockNet.WinsockNet.StateChangedHandler(this.socClient_OnStateChanged);
			// 
			// btnDisconnect
			// 
			this.btnDisconnect.Location = new System.Drawing.Point(0, 24);
			this.btnDisconnect.Name = "btnDisconnect";
			this.btnDisconnect.Size = new System.Drawing.Size(80, 23);
			this.btnDisconnect.TabIndex = 14;
			this.btnDisconnect.Text = "Disconnect";
			this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
			// 
			// btnConnect
			// 
			this.btnConnect.Location = new System.Drawing.Point(0, 0);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(80, 23);
			this.btnConnect.TabIndex = 15;
			this.btnConnect.Text = "Connect";
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// Form2
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(292, 272);
			this.Controls.Add(this.btnConnect);
			this.Controls.Add(this.btnDisconnect);
			this.Controls.Add(this.socClient);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lstEvents);
			this.Controls.Add(this.txtRecieved);
			this.Controls.Add(this.txtSend);
			this.Controls.Add(this.btnSend);
			this.Name = "Form2";
			this.Text = "Form2";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnConnect_Click(object sender, System.EventArgs e)
		{
			socClient.Connect();
		}

		private void btnDisconnect_Click(object sender, System.EventArgs e)
		{
			socClient.Disconnect();
		}

		private void btnSend_Click(object sender, System.EventArgs e)
		{
			socClient.Send(txtSend.Text);
		}

		private void socClient_OnConnectionRequestRecieved()
		{
			lstEvents.Items.Insert(0,"connection request");
		}

		private void socClient_OnDataRecieved()
		{
			txtRecieved.Text+=socClient.RecievedString;
		}

		private void socClient_OnErrorOccur(string message)
		{
		
		}

		private void socClient_OnStateChanged(string State)
		{
			lstEvents.Items.Insert(0,State);
		}

	}//class
}//namespace
