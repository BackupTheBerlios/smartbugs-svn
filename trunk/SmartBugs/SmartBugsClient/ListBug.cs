using System;
using System.Net;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;

namespace SmartBugsClient
{
	/// <summary>
	/// Summary description for ListBug.
	/// </summary>
	public class ListBug : System.Windows.Forms.Form
	{
		private string configString;
		private XmlDocument config;
		private ArrayList labels = new ArrayList();
		private ArrayList constrols = new ArrayList();
		private System.Windows.Forms.Button getConfig;
		private System.Windows.Forms.Panel bugControls;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ListBug()
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
			this.getConfig = new System.Windows.Forms.Button();
			this.bugControls = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// getConfig
			// 
			this.getConfig.Location = new System.Drawing.Point(8, 8);
			this.getConfig.Name = "getConfig";
			this.getConfig.TabIndex = 2;
			this.getConfig.Text = "Get Config";
			this.getConfig.Click += new System.EventHandler(this.getConfig_Click);
			// 
			// bugControls
			// 
			this.bugControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.bugControls.AutoScroll = true;
			this.bugControls.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.bugControls.Location = new System.Drawing.Point(8, 40);
			this.bugControls.Name = "bugControls";
			this.bugControls.Size = new System.Drawing.Size(520, 328);
			this.bugControls.TabIndex = 3;
			// 
			// ListBug
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(536, 373);
			this.Controls.Add(this.bugControls);
			this.Controls.Add(this.getConfig);
			this.Name = "ListBug";
			this.Text = "ListBug";
			this.ResumeLayout(false);

		}
		#endregion

		public static void Main()
		{
			Application.Run(new ListBug());
		}

		private void getConfig_Click(object sender, System.EventArgs e)
		{
			HttpWebRequest request = (HttpWebRequest) 
				WebRequest.Create("http://localhost/SmartBugsServer/Bug.xml");
			request.Method = "GET";
			WebResponse response = request.GetResponse();
			StreamReader sr = new StreamReader(response.GetResponseStream());
			configString = sr.ReadToEnd();
			config = new XmlDocument();
			config.LoadXml(configString);
			addEditControls(config.FirstChild.NextSibling);
			sr.Close();
		}

		private void addEditControls(XmlNode node)
		{
			int y = 10;
			for (XmlNode field = node.FirstChild; field != null; field = field.NextSibling) 
			{
				if (field.Name == "field")
				{
					Label label = new Label();
					label.Location = new System.Drawing.Point(10, y);
					label.Size = new System.Drawing.Size(150, 16);
					label.Text = field.Attributes["title"].Value;
					bugControls.Controls.Add(label);

					IBugControl control = BugControlFactory.createControl(field, "234", new Point(160, y));
					if (control != null) 
					{
						bugControls.Controls.Add(control.Control);
					}
					y += 22;
				}
				else 
				{
					Label label = new Label();
					label.Location = new System.Drawing.Point(10, y);
					label.Size = new System.Drawing.Size(380, 16);
					label.Text = field.Attributes["title"].Value;
					bugControls.Controls.Add(label);
					//this.label1.Name = "label1";
					//this.label1.TabIndex = 0;
					y += 22;

					Panel group = new Panel();
					group.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
						| System.Windows.Forms.AnchorStyles.Left) 
						| System.Windows.Forms.AnchorStyles.Right)));					
					group.AutoScroll = true;
					group.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
					group.Location = new System.Drawing.Point(5, y);
					//this.bugControls.Name = "bugControls";
					group.Size = new System.Drawing.Size(510, 296);
					bugControls.Controls.Add(group);
					y += 296 + 6;
				}
			}
			this.ResumeLayout(false);
		}
	}
}
