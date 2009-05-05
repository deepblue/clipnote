using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ClipNote
{
    public class ClipboardSender
    {
        private IntPtr handle;
        private Setting setting;

        public ClipboardSender(IntPtr handle, Setting setting)
        {
            this.handle = handle;
            this.setting = setting;
        }
        
        public void Execute()
        {
            if (Clipboard.ContainsImage())
                SendClipboardImage();
            else if (Clipboard.ContainsText())
                SendText(GetClipboardText());
            else if (Clipboard.ContainsFileDropList())
                SendClipboardFiles();
            else
                throw new Exception("먼저 저장할 텍스트를 클립보드에 저장하세요.");
        }


        public void SendText(string text)
        {
            setting.GetPage().AppendSource(AppendTitle(text), "top");
        }

        public void SendImage(string path)
        {
            Springnote.Page page = setting.GetPage();
            string html = "<p>" + SendFile(page, path) + "</p>";
            page.AppendSource(AppendTitle(html), "top");
        }

        public void SendClipboardFiles()
        {
            Springnote.Page page = setting.GetPage();
            string html = "<ul>";
            foreach (string path in Clipboard.GetFileDropList())
                html += "<li>" + SendFile(page, path) + "</li>";
            html += "</ul>";
            page.AppendSource(AppendTitle(html), "top");
        }

        public string SendFile(Springnote.Page page, string path)
        {
            Springnote.Attachment newAttachment = page.CreateAttachment(path, false);

            if(IsImageFile(path)) 
                return "<img src=\"/pages/" + page.Identifier + "/attachments/" + newAttachment.Identifier + "\" />";
            else
                return "<a href=\"/pages/" + page.Identifier + "/attachments/" + newAttachment.Identifier + "\">" + newAttachment.Title + "</a>";
        }

        private bool IsImageFile(string path)
        {
            string ext = System.IO.Path.GetExtension(path).ToLower();
            return ext == ".png" || ext == ".jpg" || ext == ".gif" || ext == ".jpeg";
        }


        public void SendClipboardImage()
        {
            string path = System.IO.Path.GetTempPath() + "\\Clipboard.png";
            Clipboard.GetImage().Save(path, System.Drawing.Imaging.ImageFormat.Png);
            SendImage(path);
        }

        private string GetClipboardText()
        {
            String text = MyClipboard.GetHtml(handle);

            if (text == String.Empty)
                return WrapAsHtml(Clipboard.GetText(TextDataFormat.UnicodeText).Replace("\r", ""));

            return ExtractHtml(text.Replace("\r", ""));
        }

        private String WrapAsHtml(String text)
        {
            text = text.Replace("<", "&lt;").Replace(">", "&gt;");
            text = "<blockquoute>" + text + "</blockquote>";
            return "<p>" + text.Replace("\n", "</p><p>") + "</p>";
        }

        private String ExtractHtml(String text)
        {
            string url = UrlFromClipboard(text);

            Regex re1 = new Regex("<!--.*?-->");
            text = re1.Replace(text, "");

            Regex re2 = new Regex("<BODY.*?>(.*?)</BODY>", RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline);

            Match match = re2.Match(text);

            if (match == Match.Empty)
                return text;

            text = match.Groups[1].ToString();

            if (url != String.Empty)
                text = ConvertPath(url, text);

            return text;
        }

        private string UrlFromClipboard(string text)
        {
            Regex re = new Regex("SourceURL:(.*)");
            Match match = re.Match(text);

            if(match == Match.Empty) 
                return String.Empty;
            else 
                return match.Groups[1].ToString();
        }

        private string ConvertPath(string absoluteUrl, string text)
        {
            Uri uri = new Uri(absoluteUrl);
            return Regex.Replace(text,
                "(^|<.*?)(src|href)=\"(?!http)(.*?)\"(.*?)>",
                m => m.Groups[1].ToString() + m.Groups[2].ToString() + "=\"" + ConvertOnePath(uri, m.Groups[3].ToString()) + "\"" + m.Groups[4].ToString(),
                RegexOptions.IgnoreCase | RegexOptions.Multiline);
        }

        private string ConvertOnePath(Uri uri, string url)
        {
            Uri ret;
            if (Uri.TryCreate(uri, url, out ret))
                return ret.AbsoluteUri;
            return url;
        }

        private String AppendTitle(String text)
        {
            return "<h3><img class=\"attachment emoticon\" src=\"http://static.springnote.com/images/icon/emoticon11.gif\" />  " + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "</h3>" +
                text +
                "<p>&nbsp;</p>";
        }
    }
}
