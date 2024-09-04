using AngleSharp.Html.Parser;

using FileTransformv2;

using HtmlAgilityPack;

using LoggerLibrary;

using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Xsl;
namespace FileTransformv2
{

	public partial class MainWindow : Form
	{
		public delegate Task AsyncEventHandler(object sender, EventArgs e);
		static string apiUrl = "https://www.freeformatter.com/xsl-transformer.html";
		/**
		 * 
		 * 
		 * 
		 */
		static string XmlPath;
		static string XsdPath;
		static string XsltPath;
		static string XsltXslPath;
		static string HtmlPath;
		static FileStream xslFile;// xsl for stylesheet
		static FileStream xmlFile;// xml for input
		static FileStream xsdFile;// xml schema 
		static FileStream htmlFile;

		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool AllocConsole();


		public MainWindow()
		{
			InitializeEditors();
			InitializeComponent();
			//AllocConsole();
			XmlTabPage.Controls.Add(Xml_Editor);
			XslTabPage.Controls.Add(Xslt_Editor);
			panel4.Controls.Add(HtmlOutput);
			this.Controls.Add(statusStrip4);
			statusStrip4.Dock = DockStyle.Bottom;

		}

		private void loadXSLT(object sender, EventArgs e)
		{
			try
			{
				var dialog = new OpenFileDialog();
				dialog.Filter = "|*.xsl;*.xslt";
				dialog.InitialDirectory = "./";
				dialog.Multiselect = false;
				dialog.Title = "Html çýktýsý için xsl veya xslt dosyasý seçin";
				DialogResult result = dialog.ShowDialog();
				if (result == DialogResult.OK)
				{
					if (dialog.CheckFileExists)
						XsltPath = dialog.FileName;
					else
						return;
					Xslt_Editor.LoadFile(XsltPath);
					LoadedFilesLayout.SelectTab(1);
				}
			}
			catch (Exception ex)
			{
				LoggerLibrary.WindowPopup.showError(ex);
			}

		}

		private void StartTransform_Click(object sender, EventArgs e)
		{
			// check stylesheets
			if (XmlPath == null || XsltPath == null)
			{
				LoggerLibrary.WindowPopup.showError(new Exception(LoggerLibrary.IMessage.XmlOrXslFileNotLoaded));
				return;
			}
			saveEditorFiles();
			localTransform();
		}

		private void showWhereSaved(string path)
		{
			Structs.Message.path = path;
			new Task(new Action(() =>
				{
					Invoke(() =>
					{
						filePathStatus.Text = Structs.Message.message;
						filePathStatus.Visible = true;
					});
					Thread.Sleep(Structs.StatusTooltipDelay);
					Invoke(() =>
					{
						filePathStatus.Visible = false;
						filePathStatus.Text = string.Empty;
					});
				}
			)).Start();
		}

		private void saveEditorFiles()
		{
			Xml_Editor.SaveFile();
			Xslt_Editor.SaveFile();
		}

		private void localTransform()
		{
			if (XsltPath != null)
			{
				try
				{
					var outputFile = File.Create("./temp" + DateTime.UtcNow.ToFileTimeUtc() + ".html");
					var path = outputFile.Name;
					outputFile.Close();
					var htmlHandler = new XslTransform();
					htmlHandler.Load(XsltPath);
					htmlHandler.Transform(XmlPath, outputFile.Name);
					HtmlOutput.LoadFile(outputFile.Name);
					File.Delete(outputFile.Name);
				}
				catch (XmlException ex)
				{
					WindowPopup.showError(IMessage.XmlFileError + " : " + ex.Message, default);
				}
				catch (Exception ex)
				{
					WindowPopup.showError(ex);
				}
			}
		}

		private void loadXMLData_Click(object sender, EventArgs e)
		{
			try
			{
				OpenFileDialog dialog = new OpenFileDialog();
				dialog.Filter = "|*.xml";
				dialog.DefaultExt = "xml";
				dialog.InitialDirectory = "./";
				dialog.Multiselect = false;
				dialog.Title = "XML Dosyasý seçiniz";
				DialogResult rs = dialog.ShowDialog();

				if (rs == DialogResult.OK)
				{
					if (dialog.CheckFileExists)
						XmlPath = dialog.FileName;
					else
						return;
					Xml_Editor.LoadFile(XmlPath);
					LoadedFilesLayout.SelectTab(0);
				}
			}
			catch (Exception ex)
			{
				LoggerLibrary.WindowPopup.showError(ex);
			}
		}

		private void loadXSLTFile_Click(object sender, EventArgs e)
		{
			try
			{
				Xml_Editor.userControl.textEditor.Text = string.Empty;
				OpenFileDialog dialog = new OpenFileDialog();
				dialog.Filter = "|*.xslt|*.xsl";
				dialog.DefaultExt = "|xsl|xslt";
				dialog.InitialDirectory = "./";
				dialog.Multiselect = false;
				dialog.Title = "XSLT Dosyasý seçniniz";
				DialogResult rs = dialog.ShowDialog();
				if (rs == DialogResult.OK)
				{
					if (dialog.CheckFileExists)
						XsltPath = dialog.FileName;
					else
						return;
					XsltOutput.LoadFile(XsltPath);
				}
			}
			catch (Exception ex)
			{
				LoggerLibrary.WindowPopup.showError(ex);
			}
		}

		public void HtmlOutput_TextChanged(object sender, EventArgs e)
		{
			try
			{
				Action htmlUpdater = delegate
				{
					if (string.IsNullOrEmpty(HtmlOutput.getContent()))
					{
						Task.Delay(2000).ContinueWith(_ =>
						{
							if (string.IsNullOrEmpty(HtmlOutput.getContent()))
							{
								// Ensure UI update happens on the UI thread
								LoggerLibrary.WindowPopup.showError(new Exception(IMessage.HtmlRenderError));
							}
						});
					}
					else
					{
						// Ensure UI update happens on the UI thread
						webBrowser.DocumentText = HtmlOutput.getContent();
						webBrowser.Show();
					}
				};
				htmlUpdater();
			}
			catch (Exception ex)
			{
			}
		}

		public void Editors_TextChanged(object sender, EventArgs e)
		{
			Action htmlUpdater = delegate
			{
				if (string.IsNullOrEmpty(HtmlOutput.getContent()))
				{
					Task.Delay(2000).ContinueWith(_ =>
					{
						if (string.IsNullOrEmpty(HtmlOutput.getContent()))
						{
							LoggerLibrary.WindowPopup.showError(new Exception(IMessage.HtmlRenderError));
						}
					});
				}
				else
				{
					webBrowser.DocumentText = HtmlOutput.getContent();
					webBrowser.Show();
				}
			};
			Action xmlOrXsltChange = delegate
			{
				if (!string.IsNullOrEmpty(Xslt_Editor.getContent()))
				{
					Task.Delay(2000).ContinueWith(_ =>
					{
						if (string.IsNullOrEmpty(Xml_Editor.getContent()))
						{
						}
					});
				}
			};
			xmlOrXsltChange();
			htmlUpdater();
		}

		private void filePathStatus_Click(object sender, EventArgs e)
		{
			System.Windows.Clipboard.SetText(Structs.Message.path);

		}

		private void filePathStatus_MouseHover(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.Hand;
		}

		private void filePathStatus_MouseLeave(object sender, EventArgs e)
		{
			Cursor = System.Windows.Forms.Cursors.Default;
		}
	}
}
