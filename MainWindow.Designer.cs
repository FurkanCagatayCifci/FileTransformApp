namespace FileTransformv2
{
	public partial class MainWindow
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		private void InitializeEditors()
		{
			HtmlOutput = new TextEditComponent() { Dock = DockStyle.Fill };
			Xml_Editor = new TextEditComponent() { Dock = DockStyle.Fill };
			Xslt_Editor = new TextEditComponent() { Dock = DockStyle.Fill };
			HtmlOutput.textChangeEvent += Editors_TextChanged;
			HtmlOutput.savedFilePath += (s, e) =>
			{
				showWhereSaved(e);
			};
			Xml_Editor.savedFilePath += (s, e) =>
			{
				showWhereSaved(e);
			};
			Xslt_Editor.savedFilePath += (s, e) =>
			{
				showWhereSaved(e);
			};

		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			colorDialog1 = new ColorDialog();
			panel1 = new Panel();
			panel2 = new Panel();
			splitContainer3 = new SplitContainer();
			splitContainer1 = new SplitContainer();
			LoadedFilesLayout = new TabControl();
			XmlTabPage = new TabPage();
			XslTabPage = new TabPage();
			splitContainer2 = new SplitContainer();
			statusStrip2 = new StatusStrip();
			toolStripStatusLabel2 = new ToolStripStatusLabel();
			XsltStatus = new ToolStripStatusLabel();
			panel4 = new Panel();
			statusStrip1 = new StatusStrip();
			toolStripStatusLabel1 = new ToolStripStatusLabel();
			webBrowser = new WebBrowser();
			statusStrip3 = new StatusStrip();
			toolStripStatusLabel3 = new ToolStripStatusLabel();
			panel3 = new Panel();
			flowLayoutPanel1 = new FlowLayoutPanel();
			button1 = new Button();
			button2 = new Button();
			button3 = new Button();
			statusStrip4 = new StatusStrip();
			filePathStatus = new ToolStripStatusLabel();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
			splitContainer3.Panel1.SuspendLayout();
			splitContainer3.Panel2.SuspendLayout();
			splitContainer3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			LoadedFilesLayout.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
			splitContainer2.Panel1.SuspendLayout();
			splitContainer2.Panel2.SuspendLayout();
			splitContainer2.SuspendLayout();
			statusStrip2.SuspendLayout();
			statusStrip1.SuspendLayout();
			statusStrip3.SuspendLayout();
			panel3.SuspendLayout();
			flowLayoutPanel1.SuspendLayout();
			statusStrip4.SuspendLayout();
			SuspendLayout();
			// 
			// panel1
			// 
			panel1.AutoSize = true;
			panel1.Controls.Add(panel2);
			panel1.Controls.Add(panel3);
			panel1.Dock = DockStyle.Fill;
			panel1.Location = new Point(5, 5);
			panel1.Name = "panel1";
			panel1.Size = new Size(975, 429);
			panel1.TabIndex = 5;
			// 
			// panel2
			// 
			panel2.Controls.Add(splitContainer3);
			panel2.Dock = DockStyle.Fill;
			panel2.Location = new Point(0, 0);
			panel2.Name = "panel2";
			panel2.Size = new Size(975, 399);
			panel2.TabIndex = 0;
			// 
			// splitContainer3
			// 
			splitContainer3.Dock = DockStyle.Fill;
			splitContainer3.Location = new Point(0, 0);
			splitContainer3.Name = "splitContainer3";
			// 
			// splitContainer3.Panel1
			// 
			splitContainer3.Panel1.Controls.Add(splitContainer1);
			splitContainer3.Panel1MinSize = 500;
			// 
			// splitContainer3.Panel2
			// 
			splitContainer3.Panel2.Controls.Add(webBrowser);
			splitContainer3.Panel2.Controls.Add(statusStrip3);
			splitContainer3.Size = new Size(975, 399);
			splitContainer3.SplitterDistance = 500;
			splitContainer3.SplitterWidth = 20;
			splitContainer3.TabIndex = 1;
			// 
			// splitContainer1
			// 
			splitContainer1.BorderStyle = BorderStyle.Fixed3D;
			splitContainer1.Dock = DockStyle.Fill;
			splitContainer1.Location = new Point(0, 0);
			splitContainer1.Margin = new Padding(10);
			splitContainer1.Name = "splitContainer1";
			splitContainer1.Orientation = Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(LoadedFilesLayout);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(splitContainer2);
			splitContainer1.Size = new Size(500, 399);
			splitContainer1.SplitterDistance = 192;
			splitContainer1.SplitterWidth = 20;
			splitContainer1.TabIndex = 1;
			// 
			// LoadedFilesLayout
			// 
			LoadedFilesLayout.Controls.Add(XmlTabPage);
			LoadedFilesLayout.Controls.Add(XslTabPage);
			LoadedFilesLayout.Dock = DockStyle.Fill;
			LoadedFilesLayout.Location = new Point(0, 0);
			LoadedFilesLayout.MinimumSize = new Size(0, 100);
			LoadedFilesLayout.Name = "LoadedFilesLayout";
			LoadedFilesLayout.SelectedIndex = 0;
			LoadedFilesLayout.Size = new Size(496, 188);
			LoadedFilesLayout.TabIndex = 0;
			// 
			// XmlTabPage
			// 
			XmlTabPage.Location = new Point(4, 24);
			XmlTabPage.Name = "XmlTabPage";
			XmlTabPage.Padding = new Padding(3);
			XmlTabPage.Size = new Size(488, 160);
			XmlTabPage.TabIndex = 0;
			XmlTabPage.Text = "XML";
			XmlTabPage.UseVisualStyleBackColor = true;
			// 
			// XslTabPage
			// 
			XslTabPage.Location = new Point(4, 24);
			XslTabPage.Name = "XslTabPage";
			XslTabPage.Padding = new Padding(3);
			XslTabPage.Size = new Size(488, 160);
			XslTabPage.TabIndex = 1;
			XslTabPage.Text = "XSLT";
			XslTabPage.UseVisualStyleBackColor = true;
			// 
			// splitContainer2
			// 
			splitContainer2.Dock = DockStyle.Fill;
			splitContainer2.Location = new Point(0, 0);
			splitContainer2.Margin = new Padding(5);
			splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			splitContainer2.Panel1.Controls.Add(statusStrip2);
			splitContainer2.Panel1Collapsed = true;
			// 
			// splitContainer2.Panel2
			// 
			splitContainer2.Panel2.Controls.Add(panel4);
			splitContainer2.Panel2.Controls.Add(statusStrip1);
			splitContainer2.Size = new Size(496, 183);
			splitContainer2.SplitterDistance = 228;
			splitContainer2.TabIndex = 0;
			// 
			// statusStrip2
			// 
			statusStrip2.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel2, XsltStatus });
			statusStrip2.Location = new Point(0, 78);
			statusStrip2.Name = "statusStrip2";
			statusStrip2.Size = new Size(228, 22);
			statusStrip2.TabIndex = 2;
			statusStrip2.Text = "statusStrip2";
			// 
			// toolStripStatusLabel2
			// 
			toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			toolStripStatusLabel2.Size = new Size(31, 17);
			toolStripStatusLabel2.Text = "XSLT";
			// 
			// XsltStatus
			// 
			XsltStatus.Enabled = false;
			XsltStatus.Name = "XsltStatus";
			XsltStatus.Size = new Size(48, 17);
			XsltStatus.Text = "Waiting";
			XsltStatus.ToolTipText = "Load File First";
			// 
			// panel4
			// 
			panel4.Dock = DockStyle.Fill;
			panel4.Location = new Point(0, 22);
			panel4.Name = "panel4";
			panel4.Size = new Size(496, 161);
			panel4.TabIndex = 1;
			// 
			// statusStrip1
			// 
			statusStrip1.Dock = DockStyle.Top;
			statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
			statusStrip1.Location = new Point(0, 0);
			statusStrip1.Name = "statusStrip1";
			statusStrip1.Size = new Size(496, 22);
			statusStrip1.TabIndex = 0;
			statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			toolStripStatusLabel1.Size = new Size(74, 17);
			toolStripStatusLabel1.Text = "HTML Çıktısı";
			toolStripStatusLabel1.TextAlign = ContentAlignment.MiddleRight;
			// 
			// webBrowser
			// 
			webBrowser.Dock = DockStyle.Fill;
			webBrowser.Location = new Point(0, 22);
			webBrowser.Name = "webBrowser";
			webBrowser.ScriptErrorsSuppressed = true;
			webBrowser.Size = new Size(455, 377);
			webBrowser.TabIndex = 1;
			// 
			// statusStrip3
			// 
			statusStrip3.Dock = DockStyle.Top;
			statusStrip3.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel3 });
			statusStrip3.Location = new Point(0, 0);
			statusStrip3.Name = "statusStrip3";
			statusStrip3.Size = new Size(455, 22);
			statusStrip3.TabIndex = 0;
			statusStrip3.Text = "statusStrip3";
			// 
			// toolStripStatusLabel3
			// 
			toolStripStatusLabel3.Name = "toolStripStatusLabel3";
			toolStripStatusLabel3.Size = new Size(74, 17);
			toolStripStatusLabel3.Text = "Sayfa Düzeni";
			// 
			// panel3
			// 
			panel3.Controls.Add(flowLayoutPanel1);
			panel3.Dock = DockStyle.Bottom;
			panel3.Location = new Point(0, 399);
			panel3.MaximumSize = new Size(0, 30);
			panel3.Name = "panel3";
			panel3.Size = new Size(975, 30);
			panel3.TabIndex = 6;
			// 
			// flowLayoutPanel1
			// 
			flowLayoutPanel1.AutoSize = true;
			flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			flowLayoutPanel1.Controls.Add(button1);
			flowLayoutPanel1.Controls.Add(button2);
			flowLayoutPanel1.Controls.Add(button3);
			flowLayoutPanel1.Dock = DockStyle.Fill;
			flowLayoutPanel1.Location = new Point(0, 0);
			flowLayoutPanel1.Name = "flowLayoutPanel1";
			flowLayoutPanel1.Size = new Size(975, 30);
			flowLayoutPanel1.TabIndex = 0;
			// 
			// button1
			// 
			button1.AutoSize = true;
			button1.Location = new Point(3, 3);
			button1.Name = "button1";
			button1.Size = new Size(113, 25);
			button1.TabIndex = 0;
			button1.Text = "Xml Dosyası Yükle";
			button1.UseVisualStyleBackColor = true;
			button1.Click += loadXMLData_Click;
			// 
			// button2
			// 
			button2.AutoSize = true;
			button2.Location = new Point(122, 3);
			button2.Name = "button2";
			button2.Size = new Size(113, 25);
			button2.TabIndex = 1;
			button2.Text = "Xslt Dosyası Yükle";
			button2.UseVisualStyleBackColor = true;
			button2.Click += loadXSLT;
			// 
			// button3
			// 
			button3.AutoSize = true;
			button3.Location = new Point(241, 3);
			button3.Name = "button3";
			button3.Size = new Size(75, 25);
			button3.TabIndex = 2;
			button3.Text = "Dönüştür";
			button3.UseVisualStyleBackColor = true;
			button3.Click += StartTransform_Click;
			// 
			// statusStrip4
			// 
			statusStrip4.Items.AddRange(new ToolStripItem[] { filePathStatus });
			statusStrip4.Location = new Point(5, 434);
			statusStrip4.Name = "statusStrip4";
			statusStrip4.RenderMode = ToolStripRenderMode.Professional;
			statusStrip4.Size = new Size(975, 22);
			statusStrip4.TabIndex = 6;
			statusStrip4.Text = "statusStrip4";
			// 
			// filePathStatus
			// 
			filePathStatus.AccessibleRole = AccessibleRole.Link;
			filePathStatus.BackgroundImageLayout = ImageLayout.None;
			filePathStatus.DisplayStyle = ToolStripItemDisplayStyle.Text;
			filePathStatus.DoubleClickEnabled = true;
			filePathStatus.Name = "filePathStatus";
			filePathStatus.Size = new Size(77, 17);
			filePathStatus.Text = "File Saved At ";
			filePathStatus.ToolTipText = "Kopyalamak İçin Tıklayın\r\n";
			filePathStatus.Visible = false;
			filePathStatus.Click += filePathStatus_Click;
			filePathStatus.MouseLeave += filePathStatus_MouseLeave;
			filePathStatus.MouseHover += filePathStatus_MouseHover;
			// 
			// MainWindow
			// 
			AccessibleRole = AccessibleRole.Window;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			AutoSize = true;
			ClientSize = new Size(985, 461);
			Controls.Add(panel1);
			Controls.Add(statusStrip4);
			MinimumSize = new Size(500, 500);
			Name = "MainWindow";
			Padding = new Padding(5);
			Tag = "MaınWındow";
			Text = "FileTransform";
			panel1.ResumeLayout(false);
			panel2.ResumeLayout(false);
			splitContainer3.Panel1.ResumeLayout(false);
			splitContainer3.Panel2.ResumeLayout(false);
			splitContainer3.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
			splitContainer3.ResumeLayout(false);
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			LoadedFilesLayout.ResumeLayout(false);
			splitContainer2.Panel1.ResumeLayout(false);
			splitContainer2.Panel1.PerformLayout();
			splitContainer2.Panel2.ResumeLayout(false);
			splitContainer2.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
			splitContainer2.ResumeLayout(false);
			statusStrip2.ResumeLayout(false);
			statusStrip2.PerformLayout();
			statusStrip1.ResumeLayout(false);
			statusStrip1.PerformLayout();
			statusStrip3.ResumeLayout(false);
			statusStrip3.PerformLayout();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			flowLayoutPanel1.ResumeLayout(false);
			flowLayoutPanel1.PerformLayout();
			statusStrip4.ResumeLayout(false);
			statusStrip4.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private ColorDialog colorDialog1;
		private Panel panel1;
		private FlowLayoutPanel flowLayoutPanel1;
		private Button button1;
		private Button button3;
		private Panel panel3;
		private Panel panel2;
		private SplitContainer splitContainer3;
		private SplitContainer splitContainer1;
		private SplitContainer splitContainer2;
		private FileTransformv2.TextEditComponent Xml_Editor;
		private FileTransformv2.TextEditComponent Xslt_Editor;
		private FileTransformv2.TextEditComponent Xsd_Editor;
		private volatile FileTransformv2.TextEditComponent HtmlOutput;
		private FileTransformv2.TextEditComponent XsltOutput;
		private StatusStrip statusStrip2;
		private ToolStripStatusLabel toolStripStatusLabel2;
		private ToolStripStatusLabel XsltStatus;
		private TabControl LoadedFilesLayout;
		private TabPage XmlTabPage;
		private TabPage XslTabPage;
		private Button button2;
		private Panel panel4;
		private StatusStrip statusStrip1;
		private ToolStripStatusLabel toolStripStatusLabel1;
		private WebBrowser webBrowser;
		private StatusStrip statusStrip3;
		private ToolStripStatusLabel toolStripStatusLabel3;
		private StatusStrip statusStrip4;
		public ToolStripStatusLabel filePathStatus;
	}
}
