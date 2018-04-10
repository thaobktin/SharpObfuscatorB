namespace SharpObfuscator
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Assemblies");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.chkObfuscateProperties = new System.Windows.Forms.CheckBox();
            this.chkObfuscateNamespaces = new System.Windows.Forms.CheckBox();
            this.chkObfuscateMethods = new System.Windows.Forms.CheckBox();
            this.chkObfuscateTypes = new System.Windows.Forms.CheckBox();
            this.btnNETSDKPath = new System.Windows.Forms.Button();
            this.btnNETFrameworkPath = new System.Windows.Forms.Button();
            this.txtNETSDKPath = new System.Windows.Forms.MaskedTextBox();
            this.txtNETFrameworkPath = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPageAssemblies = new System.Windows.Forms.TabPage();
            this.tvAssemblies = new System.Windows.Forms.TreeView();
            this.ilAssemblies = new System.Windows.Forms.ImageList(this.components);
            this.tsAssemblies = new System.Windows.Forms.ToolStrip();
            this.tsbAddAssembly = new System.Windows.Forms.ToolStripButton();
            this.tsbRemoveAssembly = new System.Windows.Forms.ToolStripButton();
            this.tabPageOutput = new System.Windows.Forms.TabPage();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblPhaseValue = new System.Windows.Forms.Label();
            this.pbBuild = new System.Windows.Forms.ProgressBar();
            this.lblPhase = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gridOutputMapping = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnBrowseBuildPath = new System.Windows.Forms.Button();
            this.txtBuildPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkObfuscateFields = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPageAssemblies.SuspendLayout();
            this.tsAssemblies.SuspendLayout();
            this.tabPageOutput.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageSettings);
            this.tabControl1.Controls.Add(this.tabPageAssemblies);
            this.tabControl1.Controls.Add(this.tabPageOutput);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(0, 35);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(649, 323);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 1;
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.Controls.Add(this.groupBox1);
            this.tabPageSettings.Controls.Add(this.btnNETSDKPath);
            this.tabPageSettings.Controls.Add(this.btnNETFrameworkPath);
            this.tabPageSettings.Controls.Add(this.txtNETSDKPath);
            this.tabPageSettings.Controls.Add(this.txtNETFrameworkPath);
            this.tabPageSettings.Controls.Add(this.label3);
            this.tabPageSettings.Controls.Add(this.label2);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSettings.Size = new System.Drawing.Size(641, 297);
            this.tabPageSettings.TabIndex = 3;
            this.tabPageSettings.Text = "Settings";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkObfuscateFields);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.chkObfuscateProperties);
            this.groupBox1.Controls.Add(this.chkObfuscateNamespaces);
            this.groupBox1.Controls.Add(this.chkObfuscateMethods);
            this.groupBox1.Controls.Add(this.chkObfuscateTypes);
            this.groupBox1.Location = new System.Drawing.Point(9, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(624, 165);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generation";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Enabled = false;
            this.checkBox3.Location = new System.Drawing.Point(7, 134);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(140, 17);
            this.checkBox3.TabIndex = 4;
            this.checkBox3.Text = "Obfuscate method code";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // chkObfuscateProperties
            // 
            this.chkObfuscateProperties.AutoSize = true;
            this.chkObfuscateProperties.Checked = true;
            this.chkObfuscateProperties.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkObfuscateProperties.Location = new System.Drawing.Point(8, 88);
            this.chkObfuscateProperties.Name = "chkObfuscateProperties";
            this.chkObfuscateProperties.Size = new System.Drawing.Size(124, 17);
            this.chkObfuscateProperties.TabIndex = 3;
            this.chkObfuscateProperties.Text = "Obfuscate properties";
            this.chkObfuscateProperties.UseVisualStyleBackColor = true;
            // 
            // chkObfuscateNamespaces
            // 
            this.chkObfuscateNamespaces.AutoSize = true;
            this.chkObfuscateNamespaces.Checked = true;
            this.chkObfuscateNamespaces.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkObfuscateNamespaces.Location = new System.Drawing.Point(8, 65);
            this.chkObfuscateNamespaces.Name = "chkObfuscateNamespaces";
            this.chkObfuscateNamespaces.Size = new System.Drawing.Size(138, 17);
            this.chkObfuscateNamespaces.TabIndex = 2;
            this.chkObfuscateNamespaces.Text = "Obfuscate namespaces";
            this.chkObfuscateNamespaces.UseVisualStyleBackColor = true;
            // 
            // chkObfuscateMethods
            // 
            this.chkObfuscateMethods.AutoSize = true;
            this.chkObfuscateMethods.Checked = true;
            this.chkObfuscateMethods.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkObfuscateMethods.Location = new System.Drawing.Point(8, 42);
            this.chkObfuscateMethods.Name = "chkObfuscateMethods";
            this.chkObfuscateMethods.Size = new System.Drawing.Size(118, 17);
            this.chkObfuscateMethods.TabIndex = 1;
            this.chkObfuscateMethods.Text = "Obfuscate methods";
            this.chkObfuscateMethods.UseVisualStyleBackColor = true;
            // 
            // chkObfuscateTypes
            // 
            this.chkObfuscateTypes.AutoSize = true;
            this.chkObfuscateTypes.Checked = true;
            this.chkObfuscateTypes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkObfuscateTypes.Location = new System.Drawing.Point(8, 19);
            this.chkObfuscateTypes.Name = "chkObfuscateTypes";
            this.chkObfuscateTypes.Size = new System.Drawing.Size(270, 17);
            this.chkObfuscateTypes.TabIndex = 0;
            this.chkObfuscateTypes.Text = "Obfuscate types (classes/interfaces/enums/structs)";
            this.chkObfuscateTypes.UseVisualStyleBackColor = true;
            // 
            // btnNETSDKPath
            // 
            this.btnNETSDKPath.Location = new System.Drawing.Point(603, 45);
            this.btnNETSDKPath.Name = "btnNETSDKPath";
            this.btnNETSDKPath.Size = new System.Drawing.Size(27, 23);
            this.btnNETSDKPath.TabIndex = 5;
            this.btnNETSDKPath.Text = "...";
            this.btnNETSDKPath.UseVisualStyleBackColor = true;
            this.btnNETSDKPath.Click += new System.EventHandler(this.btnNETSDKPath_Click);
            // 
            // btnNETFrameworkPath
            // 
            this.btnNETFrameworkPath.Location = new System.Drawing.Point(603, 13);
            this.btnNETFrameworkPath.Name = "btnNETFrameworkPath";
            this.btnNETFrameworkPath.Size = new System.Drawing.Size(27, 23);
            this.btnNETFrameworkPath.TabIndex = 4;
            this.btnNETFrameworkPath.Text = "...";
            this.btnNETFrameworkPath.UseVisualStyleBackColor = true;
            this.btnNETFrameworkPath.Click += new System.EventHandler(this.btnNETFrameworkPath_Click);
            // 
            // txtNETSDKPath
            // 
            this.txtNETSDKPath.Location = new System.Drawing.Point(133, 47);
            this.txtNETSDKPath.Name = "txtNETSDKPath";
            this.txtNETSDKPath.Size = new System.Drawing.Size(464, 20);
            this.txtNETSDKPath.TabIndex = 3;
            // 
            // txtNETFrameworkPath
            // 
            this.txtNETFrameworkPath.Location = new System.Drawing.Point(133, 15);
            this.txtNETFrameworkPath.Name = "txtNETFrameworkPath";
            this.txtNETFrameworkPath.Size = new System.Drawing.Size(464, 20);
            this.txtNETFrameworkPath.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "NET SDK path :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "NET Framework path :";
            // 
            // tabPageAssemblies
            // 
            this.tabPageAssemblies.Controls.Add(this.tvAssemblies);
            this.tabPageAssemblies.Controls.Add(this.tsAssemblies);
            this.tabPageAssemblies.Location = new System.Drawing.Point(4, 22);
            this.tabPageAssemblies.Name = "tabPageAssemblies";
            this.tabPageAssemblies.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAssemblies.Size = new System.Drawing.Size(641, 297);
            this.tabPageAssemblies.TabIndex = 0;
            this.tabPageAssemblies.Text = "Assemblies";
            this.tabPageAssemblies.UseVisualStyleBackColor = true;
            // 
            // tvAssemblies
            // 
            this.tvAssemblies.CheckBoxes = true;
            this.tvAssemblies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvAssemblies.FullRowSelect = true;
            this.tvAssemblies.HotTracking = true;
            this.tvAssemblies.ImageIndex = 0;
            this.tvAssemblies.ImageList = this.ilAssemblies;
            this.tvAssemblies.Location = new System.Drawing.Point(3, 28);
            this.tvAssemblies.Name = "tvAssemblies";
            treeNode1.Checked = true;
            treeNode1.Name = "Node0";
            treeNode1.Text = "Assemblies";
            this.tvAssemblies.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.tvAssemblies.SelectedImageIndex = 0;
            this.tvAssemblies.Size = new System.Drawing.Size(635, 266);
            this.tvAssemblies.TabIndex = 1;
            this.tvAssemblies.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvAssemblies_AfterCheck);
            this.tvAssemblies.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvAssemblies_BeforeCheck);
            this.tvAssemblies.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvAssemblies_AfterSelect);
            // 
            // ilAssemblies
            // 
            this.ilAssemblies.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilAssemblies.ImageStream")));
            this.ilAssemblies.TransparentColor = System.Drawing.Color.Transparent;
            this.ilAssemblies.Images.SetKeyName(0, "SharpObfuscator.png");
            this.ilAssemblies.Images.SetKeyName(1, "assembly.png");
            this.ilAssemblies.Images.SetKeyName(2, "namespace.png");
            this.ilAssemblies.Images.SetKeyName(3, "type.png");
            this.ilAssemblies.Images.SetKeyName(4, "enum.png");
            // 
            // tsAssemblies
            // 
            this.tsAssemblies.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddAssembly,
            this.tsbRemoveAssembly});
            this.tsAssemblies.Location = new System.Drawing.Point(3, 3);
            this.tsAssemblies.Name = "tsAssemblies";
            this.tsAssemblies.Size = new System.Drawing.Size(635, 25);
            this.tsAssemblies.TabIndex = 0;
            this.tsAssemblies.Text = "toolStrip1";
            // 
            // tsbAddAssembly
            // 
            this.tsbAddAssembly.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddAssembly.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddAssembly.Image")));
            this.tsbAddAssembly.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddAssembly.Name = "tsbAddAssembly";
            this.tsbAddAssembly.Size = new System.Drawing.Size(23, 22);
            this.tsbAddAssembly.Text = "+";
            this.tsbAddAssembly.Click += new System.EventHandler(this.tsbAddAssembly_Click);
            // 
            // tsbRemoveAssembly
            // 
            this.tsbRemoveAssembly.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRemoveAssembly.Image = ((System.Drawing.Image)(resources.GetObject("tsbRemoveAssembly.Image")));
            this.tsbRemoveAssembly.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRemoveAssembly.Name = "tsbRemoveAssembly";
            this.tsbRemoveAssembly.Size = new System.Drawing.Size(23, 22);
            this.tsbRemoveAssembly.Text = "-";
            this.tsbRemoveAssembly.Click += new System.EventHandler(this.tsbRemoveAssembly_Click);
            // 
            // tabPageOutput
            // 
            this.tabPageOutput.Controls.Add(this.txtOutput);
            this.tabPageOutput.Controls.Add(this.panel2);
            this.tabPageOutput.Location = new System.Drawing.Point(4, 22);
            this.tabPageOutput.Name = "tabPageOutput";
            this.tabPageOutput.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOutput.Size = new System.Drawing.Size(641, 297);
            this.tabPageOutput.TabIndex = 2;
            this.tabPageOutput.Text = "Output";
            this.tabPageOutput.UseVisualStyleBackColor = true;
            // 
            // txtOutput
            // 
            this.txtOutput.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Location = new System.Drawing.Point(3, 3);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(635, 261);
            this.txtOutput.TabIndex = 0;
            this.txtOutput.WordWrap = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.RosyBrown;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblPhaseValue);
            this.panel2.Controls.Add(this.pbBuild);
            this.panel2.Controls.Add(this.lblPhase);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 264);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(635, 30);
            this.panel2.TabIndex = 1;
            // 
            // lblPhaseValue
            // 
            this.lblPhaseValue.AutoSize = true;
            this.lblPhaseValue.Location = new System.Drawing.Point(60, 9);
            this.lblPhaseValue.Name = "lblPhaseValue";
            this.lblPhaseValue.Size = new System.Drawing.Size(0, 13);
            this.lblPhaseValue.TabIndex = 2;
            // 
            // pbBuild
            // 
            this.pbBuild.Location = new System.Drawing.Point(304, 4);
            this.pbBuild.Name = "pbBuild";
            this.pbBuild.Size = new System.Drawing.Size(322, 23);
            this.pbBuild.TabIndex = 1;
            // 
            // lblPhase
            // 
            this.lblPhase.AutoSize = true;
            this.lblPhase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhase.Location = new System.Drawing.Point(5, 9);
            this.lblPhase.Name = "lblPhase";
            this.lblPhase.Size = new System.Drawing.Size(64, 13);
            this.lblPhase.TabIndex = 0;
            this.lblPhase.Text = "Progress :";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gridOutputMapping);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(641, 297);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Text = "Output mapping";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gridOutputMapping
            // 
            this.gridOutputMapping.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.gridOutputMapping.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.gridOutputMapping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridOutputMapping.FullRowSelect = true;
            this.gridOutputMapping.GridLines = true;
            this.gridOutputMapping.HoverSelection = true;
            this.gridOutputMapping.Location = new System.Drawing.Point(3, 3);
            this.gridOutputMapping.MultiSelect = false;
            this.gridOutputMapping.Name = "gridOutputMapping";
            this.gridOutputMapping.Size = new System.Drawing.Size(635, 291);
            this.gridOutputMapping.TabIndex = 0;
            this.gridOutputMapping.UseCompatibleStateImageBehavior = false;
            this.gridOutputMapping.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Kind";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Initial name";
            this.columnHeader2.Width = 140;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Obfuscated name";
            this.columnHeader3.Width = 110;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Notes";
            this.columnHeader4.Width = 300;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnGenerate);
            this.panel1.Controls.Add(this.btnBrowseBuildPath);
            this.panel1.Controls.Add(this.txtBuildPath);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(649, 35);
            this.panel1.TabIndex = 4;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerate.Image")));
            this.btnGenerate.Location = new System.Drawing.Point(549, 4);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(88, 28);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnBrowseBuildPath
            // 
            this.btnBrowseBuildPath.Location = new System.Drawing.Point(515, 7);
            this.btnBrowseBuildPath.Name = "btnBrowseBuildPath";
            this.btnBrowseBuildPath.Size = new System.Drawing.Size(28, 23);
            this.btnBrowseBuildPath.TabIndex = 2;
            this.btnBrowseBuildPath.Text = "...";
            this.btnBrowseBuildPath.UseVisualStyleBackColor = true;
            this.btnBrowseBuildPath.Click += new System.EventHandler(this.btnBrowseBuildPath_Click);
            // 
            // txtBuildPath
            // 
            this.txtBuildPath.Location = new System.Drawing.Point(70, 9);
            this.txtBuildPath.Name = "txtBuildPath";
            this.txtBuildPath.Size = new System.Drawing.Size(439, 20);
            this.txtBuildPath.TabIndex = 1;
            this.txtBuildPath.Text = "D:\\temp\\_obfuscator";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Build path :";
            // 
            // chkObfuscateFields
            // 
            this.chkObfuscateFields.AutoSize = true;
            this.chkObfuscateFields.Checked = true;
            this.chkObfuscateFields.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkObfuscateFields.Location = new System.Drawing.Point(8, 111);
            this.chkObfuscateFields.Name = "chkObfuscateFields";
            this.chkObfuscateFields.Size = new System.Drawing.Size(102, 17);
            this.chkObfuscateFields.TabIndex = 7;
            this.chkObfuscateFields.Text = "Obfuscate fields";
            this.chkObfuscateFields.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 358);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Sharp Obfuscator";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageSettings.ResumeLayout(false);
            this.tabPageSettings.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPageAssemblies.ResumeLayout(false);
            this.tabPageAssemblies.PerformLayout();
            this.tsAssemblies.ResumeLayout(false);
            this.tsAssemblies.PerformLayout();
            this.tabPageOutput.ResumeLayout(false);
            this.tabPageOutput.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPageAssemblies;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnBrowseBuildPath;
		private System.Windows.Forms.TextBox txtBuildPath;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnGenerate;
		private System.Windows.Forms.TreeView tvAssemblies;
		private System.Windows.Forms.ToolStrip tsAssemblies;
		private System.Windows.Forms.ToolStripButton tsbAddAssembly;
		private System.Windows.Forms.ToolStripButton tsbRemoveAssembly;
		private System.Windows.Forms.TabPage tabPageOutput;
		private System.Windows.Forms.TextBox txtOutput;
		private System.Windows.Forms.TabPage tabPageSettings;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnNETSDKPath;
		private System.Windows.Forms.Button btnNETFrameworkPath;
		private System.Windows.Forms.MaskedTextBox txtNETSDKPath;
		private System.Windows.Forms.MaskedTextBox txtNETFrameworkPath;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox chkObfuscateMethods;
		private System.Windows.Forms.CheckBox chkObfuscateTypes;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.ListView gridOutputMapping;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ProgressBar pbBuild;
		private System.Windows.Forms.Label lblPhase;
		private System.Windows.Forms.Label lblPhaseValue;
		private System.Windows.Forms.ImageList ilAssemblies;
		private System.Windows.Forms.CheckBox chkObfuscateProperties;
		private System.Windows.Forms.CheckBox chkObfuscateNamespaces;
		private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox chkObfuscateFields;
	}
}

