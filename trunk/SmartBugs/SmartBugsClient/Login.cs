using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace SmartBugsClient
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Login : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblUsername;
		private System.Windows.Forms.Label lblPassword;
		private System.Windows.Forms.TextBox user;
		private System.Windows.Forms.TextBox password;
		private System.Windows.Forms.Button cmdLogin;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Login()
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
			this.user = new System.Windows.Forms.TextBox();
			this.password = new System.Windows.Forms.TextBox();
			this.lblUsername = new System.Windows.Forms.Label();
			this.lblPassword = new System.Windows.Forms.Label();
			this.cmdLogin = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// user
			// 
			this.user.Location = new System.Drawing.Point(80, 16);
			this.user.Name = "user";
			this.user.TabIndex = 0;
			this.user.Text = "";
			// 
			// password
			// 
			this.password.Location = new System.Drawing.Point(80, 48);
			this.password.Name = "password";
			this.password.PasswordChar = '*';
			this.password.TabIndex = 1;
			this.password.Text = "";
			// 
			// lblUsername
			// 
			this.lblUsername.Location = new System.Drawing.Point(16, 16);
			this.lblUsername.Name = "lblUsername";
			this.lblUsername.Size = new System.Drawing.Size(56, 23);
			this.lblUsername.TabIndex = 2;
			this.lblUsername.Text = "&User";
			// 
			// lblPassword
			// 
			this.lblPassword.Location = new System.Drawing.Point(16, 48);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(56, 23);
			this.lblPassword.TabIndex = 2;
			this.lblPassword.Text = "&Password";
			// 
			// cmdLogin
			// 
			this.cmdLogin.Location = new System.Drawing.Point(104, 80);
			this.cmdLogin.Name = "cmdLogin";
			this.cmdLogin.TabIndex = 3;
			this.cmdLogin.Text = "&Login";
			this.cmdLogin.Click += new System.EventHandler(this.cmdLogin_Click);
			// 
			// Login
			// 
			this.AcceptButton = this.cmdLogin;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(200, 117);
			this.Controls.Add(this.cmdLogin);
			this.Controls.Add(this.lblUsername);
			this.Controls.Add(this.password);
			this.Controls.Add(this.user);
			this.Controls.Add(this.lblPassword);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "Login";
			this.Text = "Login";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Login());
		}

		private void cmdLogin_Click(object sender, System.EventArgs e)
		{
			
		}
	}
}
