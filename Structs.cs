namespace FileTransformv2
{
	public struct Structs
	{
		public struct Message
		{

			public static string path { get; set; }

			public static string message { get { return String.Format("Dosya Şurada Kaydedildi : {0}, Kopyalamak İçin Tıklayın", path); } }
		}


		public static int StatusTooltipDelay = 5000;


		public static string WhereFileSaved(string path)
		{
			return Message.path = path;
		}
	}
}
