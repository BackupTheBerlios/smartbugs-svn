using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Diagnostics;
using System.Web;
using System.Web.Services;

namespace SmartBugsServer
{
	/// <summary>
	/// Summary description for Service1.
	/// </summary>
	[WebService(Namespace="http://p16.pub.ro/")]
	public class WebService : System.Web.Services.WebService
	{
		public WebService()
		{
			//CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent();
		}

		private System.Data.Odbc.OdbcDataAdapter odbcDataAdapter;
		private System.Data.Odbc.OdbcCommand odbcSelectCommand1;
		private System.Data.Odbc.OdbcCommand odbcInsertCommand1;
		private System.Data.Odbc.OdbcConnection odbcConnection;

		#region Component Designer generated code
		
		//Required by the Web Services Designer 
		private IContainer components = null;
				
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.odbcDataAdapter = new System.Data.Odbc.OdbcDataAdapter();
			this.odbcSelectCommand1 = new System.Data.Odbc.OdbcCommand();
			this.odbcInsertCommand1 = new System.Data.Odbc.OdbcCommand();
			this.odbcConnection = new System.Data.Odbc.OdbcConnection();
			// 
			// odbcDataAdapter
			// 
			this.odbcDataAdapter.InsertCommand = this.odbcInsertCommand1;
			this.odbcDataAdapter.SelectCommand = this.odbcSelectCommand1;
			this.odbcDataAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "users", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("id", "id"),
																																																			   new System.Data.Common.DataColumnMapping("user", "user"),
																																																			   new System.Data.Common.DataColumnMapping("password", "password")})});
			// 
			// odbcSelectCommand1
			// 
			this.odbcSelectCommand1.CommandText = "SELECT id, `user`, password FROM users";
			this.odbcSelectCommand1.Connection = this.odbcConnection;
			// 
			// odbcInsertCommand1
			// 
			this.odbcInsertCommand1.CommandText = "INSERT INTO users(`user`, password) VALUES (?, ?)";
			this.odbcInsertCommand1.Connection = this.odbcConnection;
			this.odbcInsertCommand1.Parameters.Add(new System.Data.Odbc.OdbcParameter("user", System.Data.Odbc.OdbcType.VarChar, 30, "user"));
			this.odbcInsertCommand1.Parameters.Add(new System.Data.Odbc.OdbcParameter("password", System.Data.Odbc.OdbcType.VarChar, 30, "password"));
			// 
			// odbcConnection
			// 
			this.odbcConnection.ConnectionString = "STMT=;OPTION=3;DSN=test;UID=root;PASSWORD=;DESC=MySQL ODBC 3.51 Driver DSN;DATABA" +
				"SE=test;SERVER=localhost;PORT=3306";

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		[WebMethod]
		public DataSet GetBugInfo()
		{
			DataSet ds = new DataSet();
			odbcDataAdapter.Fill(ds);
			return ds;
		}
	}
}
