using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SmartBugsClient
{
	/// <summary>
	/// Summary description for ListBug.
	/// </summary>
	public class ListBug : System.Windows.Forms.Form
	{
		// We define the labelArray which will contain labels for the fields fetched
		// from the XML and dynamically added to the Form
		private System.Windows.Forms.Label[] labelArray;

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
			// for each label in the labelArray we assign a new System.Windows.Forms
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();

			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Bug Title:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(112, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(144, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "title";
			// 
			// ListBug
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "ListBug";
			this.Text = "ListBug";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
