using System.Text;
using System.Windows.Forms.Integration;

using LoggerLibrary;

using WpfControlLibrary2;

namespace FileTransformv2
{
	public partial class TextEditComponent : UserControl
	{
		private FileStream? file;
		private FileStream? FileStream
		{
			get { return file; }
			set
			{
				file = value;
				if (value == null)
				{
					FilePath = string.Empty;
				}
				else
				{
					FilePath = value.Name;
				}
			}
		}
		private string filepath;
		public string FilePath
		{
			get { return filepath; }
			set { filepath = value; }
		}// fileName;
		public string FileExtension
		{
			get { return Path.GetExtension(FilePath); }
		}
		public UserControl1 userControl;
		private ElementHost host;

		public TextEditComponent()
		{
			InitializeComponent();
			host = new ElementHost()
			{
				Dock = DockStyle.Fill,
				AutoSize = true,
				AllowDrop = true,
			};
			userControl = new UserControl1();
			host.Child = userControl;
			panel1.Controls.Add(host);
			InitializeEventHandlers();
		}

		public event EventHandler textChangeEvent;
		public event EventHandler<string> saveFileEvent;
		public event EventHandler<string> saveFileAsEvent;
		public event EventHandler<string> savedFilePath;
		public async void informUser(string path)
		{
			new Task(new Action(() =>
			{
				savedFilePath.Invoke(this, path);
				saveStatus.Invoke(() =>
				{
					saveStatus.Visible = true;
				});
				Thread.Sleep(Structs.StatusTooltipDelay);
				saveStatus.Invoke(() =>
				{
					saveStatus.Visible = false;
				});

			}), CancellationToken.None).Start();
		}
		public Stream getStream()
		{
			var stream = new MemoryStream(Encoding.UTF8.GetBytes(userControl.textEditor.Text), true);
			return stream;
		}
		public string getContent()
		{

			return Invoke(() => { return userControl.textEditor.Text; });
		}
		public void setContent(string content)
		{
			userControl.textEditor.Text = content;
		}
		public void LoadFile(string filePath)
		{
			FileStream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite);
			userControl.LoadFile(FileStream);
			FileStream.Close();
		}
		public void SaveFile()
		{
			try
			{
				if (FilePath.Equals(value: string.Empty))
				{
					return;
				}
				var content = getContent();
				File.WriteAllText(FilePath, content);
			}
			catch (Exception ex)
			{
				LoggerLibrary.WindowPopup.showError(ex);
			}
		}
		private void saveFile_EventHandler(object from, string savedAt)
		{
			try
			{
				if (FilePath.Equals(value: string.Empty))
				{
					LoggerLibrary.WindowPopup.showError("Dosya Seçilmedi");
					return;
				}
				var content = getContent();
				File.WriteAllText(FilePath, content);
				informUser(savedAt);
			}
			catch (Exception ex)
			{
				LoggerLibrary.WindowPopup.showError(ex);
			}
		}

		private void saveFileAs_EventHandler(object sender, string savedAt)
		{
			try
			{
				var dialog = new SaveFileDialog() { InitialDirectory = "./" };
				dialog.DefaultExt = FileExtension;
				dialog.Filter = "|*" + FileExtension;
				dialog.ShowDialog();
				var fileName = string.Empty;
				var path = string.Empty;

				if (!dialog.FileName.Equals(string.Empty) && dialog.CheckPathExists & dialog.CheckWriteAccess & !dialog.CheckFileExists)
				{
					path = dialog.FileName;
					Stream stream = dialog.OpenFile();
					var text = getContent();
					stream.Write(Encoding.UTF8.GetBytes(text));
					informUser(path);
				}
			}
			catch (Exception ex)
			{
				LoggerLibrary.WindowPopup.showError(ex);
			}
		}

		private void Clear_Click(object sender, EventArgs e)
		{
			try
			{
				setContent(string.Empty);
				if (FileStream != null)
				{
					FileStream.Close();
					FileStream.Dispose();
					FileStream = null;
					FilePath = string.Empty;
				}
			}
			catch (Exception)
			{

			}
		}
	}

}
