using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using Atalasoft.Imaging;
using Atalasoft.Imaging.ImageProcessing;
using Atalasoft.Imaging.Codec;
using WinDemoHelperMethods;

namespace ThreadedCommandDemo
{
	/// <summary>
	/// Applies threaded image commands and displays the timing results.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private Atalasoft.Imaging.AtalaImage _originalImage;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel statusTime;
		private System.Windows.Forms.StatusBarPanel statusFile;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ComboBox cboCommand;
		private System.Windows.Forms.PropertyGrid propertyGrid1;
		private System.Windows.Forms.Button btnApply;
		private Atalasoft.Imaging.WinControls.WorkspaceViewer workspaceViewer1;
		private System.Windows.Forms.MenuItem menuFile;
		private System.Windows.Forms.MenuItem menuOpen;
		private System.Windows.Forms.MenuItem menuExit;
		private System.Windows.Forms.StatusBarPanel statusNoThread;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.NumericUpDown numSectionHeight;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown numThreads;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown numIterations;
        private System.Windows.Forms.StatusBarPanel statusCpus;
        private MenuItem menuItem1;
        private MenuItem menuItem2;
        private IContainer components;

        static Form1()
        {
            HelperMethods.PopulateDecoders(RegisteredDecoders.Decoders);
        }

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuFile = new System.Windows.Forms.MenuItem();
            this.menuOpen = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuExit = new System.Windows.Forms.MenuItem();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusFile = new System.Windows.Forms.StatusBarPanel();
            this.statusCpus = new System.Windows.Forms.StatusBarPanel();
            this.statusNoThread = new System.Windows.Forms.StatusBarPanel();
            this.statusTime = new System.Windows.Forms.StatusBarPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numIterations = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numSectionHeight = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numThreads = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.cboCommand = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.workspaceViewer1 = new Atalasoft.Imaging.WinControls.WorkspaceViewer();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.statusFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusCpus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusNoThread)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusTime)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numIterations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSectionHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThreads)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuFile,
            this.menuItem1});
            // 
            // menuFile
            // 
            this.menuFile.Index = 0;
            this.menuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuOpen,
            this.menuItem3,
            this.menuExit});
            this.menuFile.Text = "&File";
            // 
            // menuOpen
            // 
            this.menuOpen.Index = 0;
            this.menuOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.menuOpen.Text = "&Open";
            this.menuOpen.Click += new System.EventHandler(this.menuOpen_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.Text = "-";
            // 
            // menuExit
            // 
            this.menuExit.Index = 2;
            this.menuExit.Text = "E&xit";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 467);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusFile,
            this.statusCpus,
            this.statusNoThread,
            this.statusTime});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(808, 22);
            this.statusBar1.TabIndex = 0;
            this.statusBar1.Text = "statusBar1";
            // 
            // statusFile
            // 
            this.statusFile.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusFile.Name = "statusFile";
            this.statusFile.Width = 428;
            // 
            // statusCpus
            // 
            this.statusCpus.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.statusCpus.Name = "statusCpus";
            this.statusCpus.Text = "CPU Count:";
            this.statusCpus.Width = 84;
            // 
            // statusNoThread
            // 
            this.statusNoThread.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.statusNoThread.Name = "statusNoThread";
            this.statusNoThread.ToolTipText = "Previous Processing Time";
            this.statusNoThread.Width = 140;
            // 
            // statusTime
            // 
            this.statusTime.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.statusTime.Name = "statusTime";
            this.statusTime.ToolTipText = "Processing Time";
            this.statusTime.Width = 140;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.propertyGrid1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(592, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(216, 467);
            this.panel1.TabIndex = 1;
            this.panel1.Text = "panel1";
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.LineColor = System.Drawing.SystemColors.ScrollBar;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 224);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.propertyGrid1.Size = new System.Drawing.Size(216, 243);
            this.propertyGrid1.TabIndex = 0;
            this.propertyGrid1.ToolbarVisible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.btnApply);
            this.panel2.Controls.Add(this.cboCommand);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(216, 224);
            this.panel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numIterations);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numSectionHeight);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numThreads);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(16, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(184, 115);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // numIterations
            // 
            this.numIterations.Location = new System.Drawing.Point(96, 80);
            this.numIterations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numIterations.Name = "numIterations";
            this.numIterations.Size = new System.Drawing.Size(72, 20);
            this.numIterations.TabIndex = 5;
            this.numIterations.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numIterations.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Iterations:";
            // 
            // numSectionHeight
            // 
            this.numSectionHeight.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numSectionHeight.Location = new System.Drawing.Point(96, 50);
            this.numSectionHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numSectionHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSectionHeight.Name = "numSectionHeight";
            this.numSectionHeight.Size = new System.Drawing.Size(72, 20);
            this.numSectionHeight.TabIndex = 3;
            this.numSectionHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numSectionHeight.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Section Height:";
            // 
            // numThreads
            // 
            this.numThreads.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numThreads.Location = new System.Drawing.Point(96, 20);
            this.numThreads.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numThreads.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numThreads.Name = "numThreads";
            this.numThreads.Size = new System.Drawing.Size(72, 20);
            this.numThreads.TabIndex = 1;
            this.numThreads.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numThreads.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Threads:";
            // 
            // btnApply
            // 
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnApply.Location = new System.Drawing.Point(16, 186);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(184, 24);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "Apply Command";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // cboCommand
            // 
            this.cboCommand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCommand.Location = new System.Drawing.Point(16, 32);
            this.cboCommand.Name = "cboCommand";
            this.cboCommand.Size = new System.Drawing.Size(184, 21);
            this.cboCommand.TabIndex = 1;
            this.cboCommand.SelectedIndexChanged += new System.EventHandler(this.cboCommand_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Command:";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(586, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(6, 467);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // workspaceViewer1
            // 
            this.workspaceViewer1.AntialiasDisplay = Atalasoft.Imaging.WinControls.AntialiasDisplayMode.ScaleToGray;
            this.workspaceViewer1.AutoDispose = false;
            this.workspaceViewer1.Centered = true;
            this.workspaceViewer1.DisplayProfile = null;
            this.workspaceViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workspaceViewer1.Location = new System.Drawing.Point(0, 0);
            this.workspaceViewer1.Magnifier.BackColor = System.Drawing.Color.White;
            this.workspaceViewer1.Magnifier.BorderColor = System.Drawing.Color.Black;
            this.workspaceViewer1.Magnifier.Size = new System.Drawing.Size(100, 100);
            this.workspaceViewer1.Name = "workspaceViewer1";
            this.workspaceViewer1.OutputProfile = null;
            this.workspaceViewer1.Selection = null;
            this.workspaceViewer1.Size = new System.Drawing.Size(586, 467);
            this.workspaceViewer1.TabIndex = 0;
            this.workspaceViewer1.Text = "workspaceViewer1";
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 1;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2});
            this.menuItem1.Text = "&Help";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.Text = "About ...";
            this.menuItem2.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(808, 489);
            this.Controls.Add(this.workspaceViewer1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.MinimumSize = new System.Drawing.Size(632, 477);
            this.Name = "Form1";
            this.Text = "Atalasoft ThreadedCommand Demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.statusFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusCpus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusNoThread)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusTime)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numIterations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSectionHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThreads)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.EnableVisualStyles();
			Application.DoEvents();
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
            // Load all treaded commands into the combo box.
            // Changed due to deprecation
            //Assembly asm = Assembly.LoadWithPartialName("Atalasoft.dotImage");
            Assembly asm = Assembly.Load("Atalasoft.dotImage");
            if (asm == null) return;

			Type[] types = asm.GetTypes();
			foreach (Type t in types)
			{
				if (t.GetInterface("IThreadableCommand", false) != null)
				{
					this.cboCommand.Items.Add(new ThreadedCommandHolder((ImageCommand)asm.CreateInstance(t.FullName)));
				}
			}

			if (this.cboCommand.Items.Count > 0) this.cboCommand.SelectedIndex = 0;

			string cpuCount = System.Environment.GetEnvironmentVariable("NUMBER_OF_PROCESSORS");
			this.statusCpus.Text = "CPU Count: " + cpuCount;
			
			// For best results use twice the number of threads as CPUs.
			this.numThreads.Value = Int32.Parse(cpuCount) * 2;
		}

		private void cboCommand_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.propertyGrid1.SelectedObject = ((ThreadedCommandHolder)this.cboCommand.SelectedItem).Command;
		}

		private void btnApply_Click(object sender, System.EventArgs e)
		{
			if (this.workspaceViewer1.Image == null)
			{
				MessageBox.Show(this, "An image must be loaded before applying a command.", "No Image", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			ThreadedCommandHolder holder = this.cboCommand.SelectedItem as ThreadedCommandHolder;
			if (holder == null) return;

			this.btnApply.Enabled = false;
			this.cboCommand.Enabled = false;
			this.propertyGrid1.Enabled = false;
			this.menuFile.Enabled = false;
			this.statusTime.Text = "";
			this.statusNoThread.Text = "";
			this.Cursor = Cursors.WaitCursor;

			try
			{
				// Process without threading.
				int time = TestCommand(holder.Command);
				this.statusNoThread.Text = "Non-Threaded: " + time.ToString() + "ms";

				// Process threaded.
                System.Threading.Thread subThread = new System.Threading.Thread(new System.Threading.ThreadStart(delegate() { 
                    ThreadedCommand tc = new ThreadedCommand(holder.Command, Convert.ToInt32(this.numThreads.Value));
                    tc.StripSize = Convert.ToInt32(this.numSectionHeight.Value);
                    System.Diagnostics.Debug.Write(time);

                    time = TestCommand(tc);
                    this.BeginInvoke((MethodInvoker)delegate{ 
                        this.statusTime.Text = "Threaded: " + time.ToString() + "ms"; 
                    });
				}));

                subThread.Start();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				this.Cursor = Cursors.Default;
				this.btnApply.Enabled = true;
				this.cboCommand.Enabled = true;
				this.propertyGrid1.Enabled = true;
				this.menuFile.Enabled = true;
			}
		}

		private int TestCommand(ImageCommand command)
		{
			try
			{
				if (this._originalImage == null) return 0;

				// We don't want to modify the original image.
				AtalaImage image = this._originalImage;
				if (command.InPlaceProcessing) image = (AtalaImage)this._originalImage.Clone();

				int iterations = Convert.ToInt32(this.numIterations.Value);

				int t1 = System.Environment.TickCount;
				ImageResults results = null;
				for (int i = 0; i < iterations; i++)
				{
					if (results != null && !results.IsImageSourceImage && results.Image != null) results.Image.Dispose();
					results = command.Apply(image);
				}
				int t2 = System.Environment.TickCount;

				// Dispose the image being viewed if it's not the original.
				if (this.workspaceViewer1.Image != this._originalImage)
					this.workspaceViewer1.Image.Dispose();

				this.workspaceViewer1.Image = results.Image;

				return (t2 - t1) / iterations;
			}
			catch (Exception ex)
			{
                this.BeginInvoke((MethodInvoker)delegate { 
                    MessageBox.Show(this, ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                });
				
			}

			return 0;
		}

		#region File Menu

		private void menuOpen_Click(object sender, System.EventArgs e)
		{
			using (OpenFileDialog dlg = new OpenFileDialog())
			{
				// try to locate images folder
				string imagesFolder = Application.ExecutablePath;
				// we assume we are running under the DotImage install folder
				int pos = imagesFolder.IndexOf("DotImage ");
				if (pos != -1)
				{
					imagesFolder = imagesFolder.Substring(0,imagesFolder.IndexOf(@"\",pos)) + @"\Images\Documents";
				}

				//use this folder as starting point			
				dlg.InitialDirectory = imagesFolder;

                dlg.Filter = HelperMethods.CreateDialogFilter(true);

				if (dlg.ShowDialog(this) == DialogResult.OK)
				{
					this.Cursor = Cursors.WaitCursor;
					this.btnApply.Enabled = false;
					try
					{
						if (this._originalImage != null) this._originalImage.Dispose();
						this._originalImage = new AtalaImage(dlg.FileName, 0, null);

						this.workspaceViewer1.Image = this._originalImage;

						this.statusFile.Text = dlg.FileName;
						this.statusFile.ToolTipText = dlg.FileName;
						this.statusNoThread.Text = "";
						this.statusTime.Text = "";
					}
					catch (Exception ex)
					{
						MessageBox.Show(this, ex.Message, "Load Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					finally
					{
						this.Cursor = Cursors.Default;
						this.btnApply.Enabled = true;
					}
				}
			}
		}

		private void menuExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		#endregion

        private void menuAbout_Click(object sender, EventArgs e)
        {
            AtalaDemos.AboutBox.About aboutBox = new AtalaDemos.AboutBox.About("About Atalasoft Threaded Command Demo", "Threaded Command Demo");
            aboutBox.Description = "Some of our most CPU-Intensive image processing commands implement an IThreadableCommand interface to allow them to be run multi-threaded." + "\r\n" + "\r\n" +
                                   "This demo allows the user to test our various IThreadableCommand Image processing commands and alter the number of threads and certain other parameters. It can be used to test for optimal performance for a given command/document combination, or the source code can be examined to provide an excellent example of how to properly implement one of our threadable commands.";
            aboutBox.ShowDialog();
        }

	}

	public class ThreadedCommandHolder
	{
		private ImageCommand _command;
		private string _name = "";

		public ThreadedCommandHolder(ImageCommand command)
		{
			_command = command;
			_name = command.GetType().Name;
			if (_command is Atalasoft.Imaging.ImageProcessing.Effects.MotionBlurCommand) 
			{
				((Atalasoft.Imaging.ImageProcessing.Effects.MotionBlurCommand)_command).Angle = 90.0;
			}
		}

		public ImageCommand Command
		{
			get { return this._command; }
		}

		public override string ToString()
		{
			return this._name;
		}

	}
}
