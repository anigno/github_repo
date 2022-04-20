using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace mailExtractor
{
	public class Form1 : System.Windows.Forms.Form
	{
#region Windows Form Designer generated code
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.ListBox lstEmails;
		private System.Windows.Forms.CheckBox chkAddSemi;
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

		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.lstEmails = new System.Windows.Forms.ListBox();
			this.chkAddSemi = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem4});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem2,
																					  this.menuItem3});
			this.menuItem1.Text = "&File";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "&Open";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Text = "&Save";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 1;
			this.menuItem4.Text = "&Properties";
			// 
			// lstEmails
			// 
			this.lstEmails.ItemHeight = 16;
			this.lstEmails.Location = new System.Drawing.Point(0, 0);
			this.lstEmails.Name = "lstEmails";
			this.lstEmails.Size = new System.Drawing.Size(328, 388);
			this.lstEmails.TabIndex = 0;
			// 
			// chkAddSemi
			// 
			this.chkAddSemi.Location = new System.Drawing.Point(336, 0);
			this.chkAddSemi.Name = "chkAddSemi";
			this.chkAddSemi.Size = new System.Drawing.Size(200, 24);
			this.chkAddSemi.TabIndex = 1;
			this.chkAddSemi.Text = "Add ; between emails";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(632, 484);
			this.Controls.Add(this.chkAddSemi);
			this.Controls.Add(this.lstEmails);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Email extractor V1";
			this.ResumeLayout(false);

		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

#endregion
		String fileNameRead;
		String fileNameSave;
		StreamReader fileReader;
		StreamWriter fileWriter;
		cCollection emailsCollection=new cCollection();
		
		private void runParser()
		{
			fileReader=new StreamReader(fileNameRead);
			char c;
			String lastMail="";
			String LETTERS="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            String WORDS=LETTERS + "_-0123456789";
			String DOT=".";
			String AT="@";
			int state=0;
			while(fileReader.Peek()!=-1)
			{
				c=(char)fileReader.Peek();
				switch(state)
				{
					case 0:
						//one letter at the begining
						lastMail="";
						if(check(LETTERS,c))
						{
							lastMail+=c;
							fileReader.Read();	//move to next char
							state=1;
						}
						else
						{
							fileReader.Read();	//move to next char
						}//if else
						break;
					case 1:
						//WORD
						if(check(WORDS,c))
						{
							lastMail+=c;
							fileReader.Read();	//move to next char
						}
						else
						{
							state=2;
						}//if else
						break;
					case 2:
						//@
						if(check(AT,c))
						{
							lastMail+=c;
							fileReader.Read();	//move to next char
							state=3;
						}
						else
						{
							state=0;
						}//if else
						break;
					case 3:
						//letter only
						if(check(LETTERS,c))
						{
							lastMail+=c;
							fileReader.Read();	//move to next char
							state=4;
						}
						else
						{
							state=0;
						}//if else
						break;
					case 4:
						//WORD
						if(check(WORDS,c))
						{
							lastMail+=c;
							fileReader.Read();	//move to next char
						}
						else
						{
							state=5;
						}//if else
						break;
					case 5:
						//dot
						if(check(DOT,c))
						{
							lastMail+=c;
							fileReader.Read();	//move to next char
							state=6;
						}
						else
						{
							state=0;
						}//if else
						break;
					case 6:
						//letter only
						if(check(LETTERS,c))
						{
							lastMail+=c;
							fileReader.Read();	//move to next char
							state=7;
						}
						else
						{
							state=0;
						}//if else
						break;
					case 7:
						//WORD + "."
						if(check(WORDS+".",c))
						{
							lastMail+=c;
							fileReader.Read();	//move to next char
						}
						else
						{
							state=8;
						}//if else
						break;
					case 8:
						//check if ends with a letter
						String a=lastMail.Substring(lastMail.Length-1);
						if(check(LETTERS,a.ToCharArray()[0]))
						{
							//email is ok check duplicate
							if(checkExist(lastMail)==false)
							{
								//add to collection (if not anigno)
								if(lastMail.IndexOf("anigno")<0)
								{
									emailsCollection.add(lastMail);
								}//if
							}//if
						}//if
						state=0;
						break;
				}//switch
			}//while
			//add emails to listbox
			foreach(String item in emailsCollection)
			{
				lstEmails.Items.Add(item);
				Application.DoEvents();
			}//foreach
			lstEmails.Items.Add(emailsCollection.count());
			fileReader.Close();
		}//runParser()

		bool check(String allow,char c)
		{
			String s=c.ToString();
			//int a=allow.IndexOf(s);
			if(allow.IndexOf(s)>=0)return true;
			return false;
		}//check()

		private bool checkExist(String email)
		{
			foreach(String item in emailsCollection)
			{
				if(email==item)return true;
			}//foreach
			return false;
		}//checkExist()

		//menu file->open
		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog ofd=new OpenFileDialog();
			ofd.Filter="txt files (*.txt)|*.txt|email files (*.eml)|*.eml|All files (*.*)|*.*";
			ofd.ShowDialog(this);
			fileNameRead=ofd.FileName;
			emailsCollection.clear();
			lstEmails.Items.Clear();
			runParser();
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			SaveFileDialog sfd=new SaveFileDialog();
			sfd.Filter="txt files (*.txt)|*.txt|email files (*.eml)|*.eml|All files (*.*)|*.*";
			sfd.ShowDialog(this);
			fileNameSave=sfd.FileName;
			fileWriter=new StreamWriter(fileNameSave);
			foreach(String item in emailsCollection)
			{
				if(chkAddSemi.Checked==true)
				{
					fileWriter.Write(item+";");
				}
				else
				{
					fileWriter.WriteLine(item);
				}//if else
			}//foreach
			if(chkAddSemi.Checked==false)
			{
				fileWriter.WriteLine("");
				fileWriter.WriteLine("Emails count="+emailsCollection.count());
			}//if
			fileWriter.Close();
		}
	}
}
