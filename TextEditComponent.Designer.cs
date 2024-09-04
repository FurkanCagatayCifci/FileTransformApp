using System.Windows.Forms.Integration;

using WpfControlLibrary2;

namespace FileTransformv2
{
	partial class TextEditComponent
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		private void InitializeEventHandlers()
		{
			userControl.textEditor.TextChanged += (s, e) => { textChangeEvent?.Invoke(s, e); };
			userControl.saveFileGesture += (s, e) => { saveFileEvent?.Invoke(s, this.filepath); };
			userControl.saveAsGesture += (s, e) => { saveFileAsEvent.Invoke(s, this.filepath); };
			saveFile_Button.Click += (s, e) => { saveFileEvent?.Invoke(s, this.filepath); };
			saveAs_Button.Click += (s, e) => { saveFileAsEvent?.Invoke(s, this.filepath); };
			saveFileEvent += (s, e) =>
			{
				if (filepath != null)
					saveFile_EventHandler(s, e);
				else
					saveFileAs_EventHandler(s, e);
			};
			saveFileAsEvent += (s, e) =>
			{
				saveFileAs_EventHandler(s, e);
			};

		}
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}


		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			saveStatus = new Label();
			flowLayoutPanel2 = new FlowLayoutPanel();
			saveFile_Button = new Button();
			saveAs_Button = new Button();
			panel1 = new Panel();
			Clear_Button = new Button();
			flowLayoutPanel2.SuspendLayout();
			SuspendLayout();
			// 
			// saveStatus
			// 
			saveStatus.AccessibleRole = AccessibleRole.None;
			saveStatus.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			saveStatus.AutoSize = true;
			saveStatus.Enabled = false;
			saveStatus.FlatStyle = FlatStyle.Flat;
			flowLayoutPanel2.SetFlowBreak(saveStatus, true);
			saveStatus.Location = new Point(312, 0);
			saveStatus.Name = "saveStatus";
			saveStatus.Size = new Size(61, 31);
			saveStatus.TabIndex = 2;
			saveStatus.Text = "Kaydedildi";
			saveStatus.TextAlign = ContentAlignment.MiddleCenter;
			saveStatus.UseCompatibleTextRendering = true;
			saveStatus.UseMnemonic = false;
			saveStatus.Visible = false;
			// 
			// flowLayoutPanel2
			// 
			flowLayoutPanel2.AutoSize = true;
			flowLayoutPanel2.Controls.Add(saveFile_Button);
			flowLayoutPanel2.Controls.Add(saveAs_Button);
			flowLayoutPanel2.Controls.Add(Clear_Button);
			flowLayoutPanel2.Controls.Add(saveStatus);
			flowLayoutPanel2.Dock = DockStyle.Bottom;
			flowLayoutPanel2.Location = new Point(0, 119);
			flowLayoutPanel2.MinimumSize = new Size(0, 20);
			flowLayoutPanel2.Name = "flowLayoutPanel2";
			flowLayoutPanel2.Size = new Size(397, 31);
			flowLayoutPanel2.TabIndex = 3;
			flowLayoutPanel2.WrapContents = false;
			// 
			// saveFile_Button
			// 
			saveFile_Button.AutoSize = true;
			saveFile_Button.Location = new Point(3, 3);
			saveFile_Button.Name = "saveFile_Button";
			saveFile_Button.Size = new Size(97, 25);
			saveFile_Button.TabIndex = 0;
			saveFile_Button.Text = "Kaydet";
			saveFile_Button.UseVisualStyleBackColor = true;
			// 
			// saveAs_Button
			// 
			saveAs_Button.AutoSize = true;
			saveAs_Button.Location = new Point(106, 3);
			saveAs_Button.Name = "saveAs_Button";
			saveAs_Button.Size = new Size(97, 25);
			saveAs_Button.TabIndex = 1;
			saveAs_Button.Text = "Farklı Kaydet";
			saveAs_Button.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			panel1.Dock = DockStyle.Fill;
			panel1.Location = new Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new Size(397, 119);
			panel1.TabIndex = 4;
			// 
			// Clear_Button
			// 
			Clear_Button.AutoSize = true;
			Clear_Button.Location = new Point(209, 3);
			Clear_Button.Name = "Clear_Button";
			Clear_Button.Size = new Size(97, 25);
			Clear_Button.TabIndex = 3;
			Clear_Button.Text = "Temizle";
			Clear_Button.UseVisualStyleBackColor = true;
			Clear_Button.Click += Clear_Click;
			// 
			// TextEditComponent
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(panel1);
			Controls.Add(flowLayoutPanel2);
			Name = "TextEditComponent";
			Size = new Size(397, 150);
			flowLayoutPanel2.ResumeLayout(false);
			flowLayoutPanel2.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		public FlowLayoutPanel flowLayoutPanel2;
		public Button saveFile_Button;
		private Panel panel1;
		public Button saveAs_Button;
		public volatile Label saveStatus;
		public Button Clear_Button;
	}
}
