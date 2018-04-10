using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

using SharpObfuscator.Obfuscation2;

namespace SharpObfuscator
{
	public partial class MainForm : Form
	{

		#region Constructor

		public MainForm()
		{
			InitializeComponent();
			System.Windows.Forms.Form.CheckForIllegalCrossThreadCalls = false;
		}

		#endregion

		#region Browse build path

		private void btnBrowseBuildPath_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			DialogResult result = dialog.ShowDialog(this);

			if (result != DialogResult.OK)
				return;

			txtBuildPath.Text = dialog.SelectedPath;
		}

		#endregion

		#region Browse NET Framework folders

		private void btnNETFrameworkPath_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			dialog.SelectedPath = txtNETFrameworkPath.Text;
			DialogResult result = dialog.ShowDialog(this);
			if (result != DialogResult.OK)
				return;

			btnNETFrameworkPath.Text = dialog.SelectedPath;
		}

		private void btnNETSDKPath_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog dialog = new FolderBrowserDialog();
			dialog.SelectedPath = txtNETSDKPath.Text;
			DialogResult result = dialog.ShowDialog(this);
			if (result != DialogResult.OK)
				return;

			btnNETSDKPath.Text = dialog.SelectedPath;
		}

		#endregion

		#region Add Assembly

		private void tsbAddAssembly_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.InitialDirectory = Application.StartupPath;
			dialog.Multiselect = true;
			DialogResult result = dialog.ShowDialog(this);

			if (result != DialogResult.OK)
				return;

			foreach (string file in dialog.FileNames)
				AddAssembly(file);

			//--- Epand
			tvAssemblies.Nodes[0].Expand();
		}

		private void AddAssembly(string file)
		{
			// Assembly
			Assembly assembly = Assembly.LoadFrom(file);
			TreeNode assemblyNode = tvAssemblies.Nodes[0].Nodes.Add(file);
			assemblyNode.Tag = assembly;
			assemblyNode.Checked = true;
			assemblyNode.ImageIndex = assemblyNode.SelectedImageIndex = 1;

			try
			{
				foreach (Type type in assembly.GetTypes())
				{
					if (type.FullName.StartsWith("<PrivateImplementationDetails>"))
						continue;

					if (type.FullName.Contains("+") && type.FullName.IndexOf("__", type.FullName.IndexOf("+")) > -1)
						continue;

					TreeNode typeNode = assemblyNode.Nodes.Add(type.FullName);
					typeNode.Tag = type;
					typeNode.Checked = true;

					if (type.IsEnum)
						typeNode.ImageIndex = typeNode.SelectedImageIndex = 4;
					else
						typeNode.ImageIndex = typeNode.SelectedImageIndex = 3;
				}
			}
			catch (ReflectionTypeLoadException exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		#endregion

		#region Remove Assembly

		private void tsbRemoveAssembly_Click(object sender, EventArgs e)
		{
			tvAssemblies.SelectedNode.Parent.Nodes.Remove(tvAssemblies.SelectedNode);
		}

		#endregion

		#region Generate

		private void btnGenerate_Click(object sender, EventArgs e)
		{
			SharpObfuscatorSettings.NETFrameworkPath = txtNETFrameworkPath.Text;
			SharpObfuscatorSettings.NETSDKPath = txtNETSDKPath.Text;

			Obfuscator obfuscator = new Obfuscator(txtBuildPath.Text,
													chkObfuscateTypes.Checked,
													chkObfuscateMethods.Checked,
													chkObfuscateNamespaces.Checked,
                                                    chkObfuscateProperties.Checked,
                                                    chkObfuscateFields.Checked);

			// Add assemblies
			foreach (TreeNode node in tvAssemblies.Nodes[0].Nodes)
			{
				obfuscator.AddAssembly(node.Text, node.Checked);

				// Exclusions
				foreach (TreeNode typeNode in node.Nodes)
					if (!typeNode.Checked)
						obfuscator.ExcludeType(((Type)typeNode.Tag).FullName);
			}

			obfuscator.OutputEvent += new ObfuscatorOutputEvent(obfuscator_OutputEvent);
			obfuscator.RequestReferencedAssemblyPath += new ObfuscatorRequestReferencedAssemblyPath(obfuscator_RequestReferencedAssemblyPath);
			obfuscator.NameObfuscated += new ObfuscatorNameObfuscated(obfuscator_NameObfuscated);
			obfuscator.Progress += new ObfuscatorProgress(obfuscator_Progress);

			obfuscator.StartObfuscation();

			tabControl1.SelectedIndex = 2;
		}

		#endregion

		#region Generation events

		void obfuscator_OutputEvent(StreamReader standardOutput, StreamReader standardError)
		{
			string output;

			while ((output = standardOutput.ReadLine()) != null)
				txtOutput.Text += output + System.Environment.NewLine;

			while ((output = standardError.ReadLine()) != null)
				txtOutput.Text += output + System.Environment.NewLine;
		}

		string obfuscator_RequestReferencedAssemblyPath(string typeToLoad, string initialAssemblyPath)
		{
			AssemblyPathDialog dialog = new AssemblyPathDialog(typeToLoad, initialAssemblyPath);
			dialog.ShowDialog(this);

			return dialog.AssemblyPath;
		}

		void obfuscator_NameObfuscated(SharpObfuscator.Obfuscation2.ObfuscationItem item, string initialName, string obfuscatedName, string notes)
		{
			ListViewItem lvItem = gridOutputMapping.Items.Add(item.ToString());
			lvItem.SubItems.Add(initialName);
			lvItem.SubItems.Add(obfuscatedName);
			lvItem.SubItems.Add(notes);
		}

		void obfuscator_Progress(string phaseName, int percents)
		{
			lblPhaseValue.Text = phaseName;
			pbBuild.Value = percents;
		}

		#endregion

		#region Load

		private void MainForm_Load(object sender, EventArgs e)
		{
			txtNETFrameworkPath.Text = SharpObfuscatorSettings.NETFrameworkPath;
			txtNETSDKPath.Text = SharpObfuscatorSettings.NETSDKPath;
			tabControl1.SelectTab(1);
		}

		#endregion

		#region Tree view events

		private void tvAssemblies_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (e.Node != null && e.Node.Tag is Assembly)
				tsbRemoveAssembly.Enabled = true;
			else
				tsbRemoveAssembly.Enabled = false;
		}

		private void tvAssemblies_BeforeCheck(object sender, TreeViewCancelEventArgs e)
		{
			if (e.Node.Parent == null)
			{
				e.Cancel = true;
				return;
			}
		}

		private void tvAssemblies_AfterCheck(object sender, TreeViewEventArgs e)
		{
			if (e.Node.Parent != null)
				UpdateChildNodes(e.Node);
		}

		private void UpdateChildNodes(TreeNode node)
		{
			foreach (TreeNode child in node.Nodes)
			{
				child.Checked = node.Checked;
				UpdateChildNodes(child);
			}
		}

		#endregion

	}
}