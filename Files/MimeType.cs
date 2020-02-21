using System;
using System.Collections.Generic;
using System.Text;

namespace NgUtil.Files {
    public sealed class MimeType {

        public string Name { get; }

        public string Extension { get; }


        public MimeType(string name, string extension) {
            Name = name;
            Extension = extension;
        }

		public static readonly MimeType Aac = new MimeType("audio/aac", ".aac");
		public static readonly MimeType Avi = new MimeType("video/x-msvideo", ".avi");
		public static readonly MimeType Binary = new MimeType("application/octet-stream", ".bin");
		public static readonly MimeType Bmp = new MimeType("image/bmp", ".bmp");
		public static readonly MimeType Bzip = new MimeType("application/x-bzip", ".bz");
		public static readonly MimeType Bzip2 = new MimeType("application/x-bzip2", ".bz2");
		public static readonly MimeType Css = new MimeType("text/css", ".css");
		public static readonly MimeType Csv = new MimeType("text/csv", ".csv");
		public static readonly MimeType Gif = new MimeType("image/gif", ".gif");
		public static readonly MimeType Html = new MimeType("text/html", ".html");
		public static readonly MimeType Ico = new MimeType("image/x-icon", ".ico");
		public static readonly MimeType Jar = new MimeType("application/java-archive", ".jar");
		public static readonly MimeType Jpg = new MimeType("image/jpeg", ".jpg");
		public static readonly MimeType Jpeg = new MimeType("image/jpeg", ".jpeg");
		public static readonly MimeType Js = new MimeType("text/javascript", ".js");
		public static readonly MimeType Json = new MimeType("application/json", ".json");
		public static readonly MimeType Mp3 = new MimeType("audio/mpeg", ".mp3");
		public static readonly MimeType Mpeg = new MimeType("video/mpeg", ".mpeg");
		public static readonly MimeType Oga = new MimeType("audio/ogg", ".oga");
		public static readonly MimeType Ogv = new MimeType("video/ogg", ".ogv");
		public static readonly MimeType Ogg = new MimeType("video/ogg", ".ogg");
		public static readonly MimeType Png = new MimeType("image/png", ".png");
		public static readonly MimeType Pdf = new MimeType("application/pdf", ".pdf");
		public static readonly MimeType Rar = new MimeType("application/x-rar-compressed", ".rar");
		public static readonly MimeType Rtf = new MimeType("application/rtf", ".rtf");
		public static readonly MimeType Svg = new MimeType("image/svg+xml", ".svg");
		public static readonly MimeType Swf = new MimeType("application/x-shockwave-flash", ".swf");
		public static readonly MimeType Tar = new MimeType("application/x-tar", ".tar");
		public static readonly MimeType Tif = new MimeType("image/tiff", ".tif");
		public static readonly MimeType Tiff = new MimeType("image/tiff", ".tiff");
		public static readonly MimeType Txt = new MimeType("text/plain", ".txt");
		public static readonly MimeType Wav = new MimeType("audio/wav", ".wav");
		public static readonly MimeType Weba = new MimeType("audio/webm", ".weba");
		public static readonly MimeType Webm = new MimeType("video/webm", ".webm");
		public static readonly MimeType Webp = new MimeType("image/webp", ".webp");
		public static readonly MimeType Xml = new MimeType("application/xml", ".xml");
		public static readonly MimeType Zip = new MimeType("application/zip", ".zip");
		public static readonly MimeType Mp4 = new MimeType("video/mp4", ".mp4");
		public static readonly MimeType Mov = new MimeType("video/quicktime", ".mov");
		public static readonly MimeType Unknown = new MimeType("unknown", "");

	}
}
