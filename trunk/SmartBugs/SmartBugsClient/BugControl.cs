using System;
using System.Drawing;
using System.Xml;
using System.Windows.Forms;

namespace SmartBugsClient
{
	class InvalidTypeException : Exception {};

	interface IBugControl
	{
		Control Control { get; }
		int GetIntValue();
		string GetStringValue();
		void SetValue(int val);
		void SetValue(string val);
	}

	class StringControl : IBugControl
	{
		private TextBox textBox;

		public StringControl(XmlNode node, string val, Point p) 
		{
			textBox = new TextBox();
			textBox.Size = new System.Drawing.Size(120, 20);
			textBox.Text = val;
			textBox.Location = p;
			if (node.Attributes["length"] != null)
				textBox.MaxLength = int.Parse(node.Attributes["length"].Value);
			else
				textBox.MaxLength = 255;
		}

		public Control Control { get { return textBox; } }
		public int GetIntValue() { throw new InvalidTypeException(); }
		public string GetStringValue() { return textBox.Text; }
		public void SetValue(int val) { throw new InvalidTypeException(); }
		public void SetValue(string val) { textBox.Text = val; }
	}

	class BugControlFactory
	{
		public static IBugControl createControl(XmlNode node, string val, Point p)
		{
			if (node.Attributes["type"].Value == "string")
				return new StringControl(node, val, p);
			return null;
			//throw new Exception("Invalid Control Type Specified");
		}
	}
}
