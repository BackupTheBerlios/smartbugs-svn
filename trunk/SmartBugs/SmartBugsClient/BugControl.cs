using System;
using System.Drawing;
using System.Xml;
using System.Windows.Forms;

namespace SmartBugsClient
{
	interface IBugControl
	{
		Control Control { get; }
		string GetValue();
		void SetValue(string val);
	}

	class StringControl : IBugControl
	{
		private TextBox textBox;

		public StringControl(XmlNode node, string val, Point p) 
		{
			textBox = new TextBox();
			textBox.Size = new System.Drawing.Size(300, 20);
			textBox.Text = val;
			textBox.Location = p;
			if (node.Attributes["length"] != null)
				textBox.MaxLength = int.Parse(node.Attributes["length"].Value);
			else
				textBox.MaxLength = 255;
		}

		public Control Control { get { return textBox; } }
		public string GetValue() { return textBox.Text; }
		public void SetValue(string val) { textBox.Text = val; }
	}

	class BugIDControl : IBugControl
	{
		private NumericUpDown numericUpDown;

		public BugIDControl(XmlNode node, string val, Point p) 
		{
			numericUpDown = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(numericUpDown)).BeginInit();
			numericUpDown.Maximum = new System.Decimal(new int[] {1000000, 0, 0, 0});
			numericUpDown.Location = p;
			numericUpDown.Value = int.Parse(val);
			((System.ComponentModel.ISupportInitialize)(numericUpDown)).EndInit();
		}

		public Control Control { get { return numericUpDown; } }
		public string GetValue() { return numericUpDown.Value.ToString(); }
		public void SetValue(string val) { numericUpDown.Value = decimal.Parse(val); }
	}

	class ComboControl : IBugControl
	{
		private ComboBox combo;

		public ComboControl(XmlNode node, string val, Point p)
		{
			combo = new System.Windows.Forms.ComboBox();
			combo.Size = new System.Drawing.Size(300, 20);
			combo.Location = p;
		}

		public Control Control { get { return combo; } } 
		public string GetValue() { return combo.Items[combo.SelectedIndex].ToString(); }
		public void SetValue(string val) { combo.SelectedIndex = combo.Items.IndexOf(val); }
	}

	class BugControlFactory
	{
		public static IBugControl createControl(XmlNode node, string val, Point p)
		{
			if (node.Attributes["type"].Value == "string")
				return new StringControl(node, val, p);
			else if (node.Attributes["type"].Value == "id")
				return new BugIDControl(node, val, p);
			else if (node.Attributes["type"].Value == "choice")
				return new ComboControl(node, val, p);
			return null;
			//throw new Exception("Invalid Control Type Specified");
		}
	}
}
