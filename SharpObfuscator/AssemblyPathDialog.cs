using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SharpObfuscator
{
	public partial class AssemblyPathDialog : Form
	{
		public AssemblyPathDialog(string typeToLoad, string initialAssemblyPath)
		{
			InitializeComponent();

			txtType.Text = typeToLoad;
			txtAssemblyPath.Text = initialAssemblyPath;
		}

		private void btnBrowse_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "EXE files (*.exe)|*.exe|DLL files (*.dll)|*.dll|All files (*.*)|*.*";
			dialog.FilterIndex = 2;
			dialog.RestoreDirectory = true;
			dialog.InitialDirectory = SharpObfuscatorSettings.NETFrameworkPath;
			DialogResult result = dialog.ShowDialog(this);
			if (result != DialogResult.OK)
				return;

			txtAssemblyPath.Text = dialog.FileName;
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			if (AssemblyPath == "")
			{
				MessageBox.Show("Please select an assembly", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			this.Close();
		}

		public string AssemblyPath
		{
			get
			{
				return txtAssemblyPath.Text.Trim(); ;
			}
		}
	}
}