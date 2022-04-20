using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace testApplication
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnStartListen;
		private System.Windows.Forms.Button btnStopListen;
		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.TextBox txtSend;
		private System.Windows.Forms.TextBox txtRecieved;
		private System.Windows.Forms.ListBox lstEvents;
		private System.Windows.Forms.Label label1;
		private winsockNet.WinsockNet socServer;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
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
				if (components != null) 
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
			this.btnStartListen = new System.Windows.Forms.Button();
			this.btnStopListen = new System.Windows.Forms.Button();
			this.btnSend = new System.Windows.Forms.Button();
			this.txtSend = new System.Windows.Forms.TextBox();
			this.txtRecieved = new System.Windows.Forms.TextBox();
			this.lstEvents = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.socServer = new winsockNet.WinsockNet();
			this.SuspendLayout();
			// 
			// btnStartListen
			// 
			this.btnStartListen.Location = new System.Drawing.Point(0, 0);
			this.btnStartListen.Name = "btnStartListen";
			this.btnStartListen.Size = new System.Drawing.Size(80, 23);
			this.btnStartListen.TabIndex = 0;
			this.btnStartListen.Text = "StartListen";
			this.btnStartListen.Click += new System.EventHandler(this.btnStartListen_Click);
			// 
			// btnStopListen
			// 
			this.btnStopListen.Location = new System.Drawing.Point(0, 24);
			this.btnStopListen.Name = "btnStopListen";
			this.btnStopListen.Size = new System.Drawing.Size(80, 23);
			this.btnStopListen.TabIndex = 1;
			this.btnStopListen.Text = "StopListen";
			this.btnStopListen.Click += new System.EventHandler(this.btnStopListen_Click);
			// 
			// btnSend
			// 
			this.btnSend.Location = new System.Drawing.Point(0, 48);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(80, 23);
			this.btnSend.TabIndex = 2;
			this.btnSend.Text = "Send";
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// txtSend
			// 
			this.txtSend.Location = new System.Drawing.Point(80, 48);
			this.txtSend.Name = "txtSend";
			this.txtSend.Size = new System.Drawing.Size(208, 22);
			this.txtSend.TabIndex = 3;
			this.txtSend.Text = "";
			// 
			// txtRecieved
			// 
			this.txtRecieved.Location = new System.Drawing.Point(0, 72);
			this.txtRecieved.Multiline = true;
			this.txtRecieved.Name = "txtRecieved";
			this.txtRecieved.Size = new System.Drawing.Size(288, 80);
			this.txtRecieved.TabIndex = 4;
			this.txtRecieved.Text = "";
			// 
			// lstEvents
			// 
			this.lstEvents.ItemHeight = 16;
			this.lstEvents.Location = new System.Drawing.Point(0, 152);
			this.lstEvents.Name = "lstEvents";
			this.lstEvents.Size = new System.Drawing.Size(288, 116);
			this.lstEvents.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(112, 0);
			this.label1.Name = "label1";
			this.label1.TabIndex = 6;
			this.label1.Text = "server";
			// 
			// socServer
			// 
			this.socServer.BufferSize = 1024;
			this.socServer.IpAddress = "127.0.0.1";
			this.socServer.Location = new System.Drawing.Point(208, 0);
			this.socServer.Name = "socServer";
			this.socServer.PortNumber = 1000;
			this.socServer.Size = new System.Drawing.Size(80, 16);
			this.socServer.TabIndex = 7;
			this.socServer.OnDataRecieved += new winsockNet.WinsockNet.DataRecievedHandler(this.socServer_OnDataRecieved);
			this.socServer.OnErrorOccur += new winsockNet.WinsockNet.ErrorHandler(this.socServer_OnErrorOccur);
			this.socServer.OnConnectionRequestRecieved += new winsockNet.WinsockNet.ConnectionRequestRecievedHandler(this.socServer_OnConnectionRequestRecieved);
			this.socServer.OnStateChanged += new winsockNet.WinsockNet.StateChangedHandler(this.socServer_OnStateChanged);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(288, 272);
			this.Controls.Add(this.socServer);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lstEvents);
			this.Controls.Add(this.txtRecieved);
			this.Controls.Add(this.txtSend);
			this.Controls.Add(this.btnSend);
			this.Controls.Add(this.btnStopListen);
			this.Controls.Add(this.btnStartListen);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void btnStartListen_Click(object sender, System.EventArgs e)
		{
			socServer.StartListen();
		}

		private void btnStopListen_Click(object sender, System.EventArgs e)
		{
			socServer.StopListen();
		}

		private void btnSend_Click(object sender, System.EventArgs e)
		{
			socServer.Send(txtSend.Text);
		}

		private void socServer_OnConnectionRequestRecieved()
		{
			lstEvents.Items.Insert(0,"connection request");
		}

		private void socServer_OnDataRecieved()
		{
			txtRecieved.Text+=socServer.RecievedString;
		}

		private void socServer_OnErrorOccur(string message)
		{
			
		}

		private void socServer_OnStateChanged(string State)
		{
			lstEvents.Items.Insert(0,State);
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			Form2 f2=new Form2();
			f2.Show();
		}

	}//class
}//namespace
