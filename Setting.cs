using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Microsoft.Win32;

namespace ClipNote
{
    [XmlRoot(ElementName = "ClipNoteConfig")]
    public class Setting
    {
        [XmlElement(ElementName = "AccessToken")]
        public string AccessToken;

        [XmlElement(ElementName = "AccessTokenSecret")]
        public string AccessTokenSecret;

        [XmlElement(ElementName = "PageUrl")]
        public string pageUrl;

        [XmlElement(ElementName = "NoteName")]
        public string noteName;

        [XmlElement(ElementName = "PageId")]
        public string pageId;

        private Springnote.Consumer consumer;
        private string FilePath { get; set; }

        Setting()
        {
        }

        public void Initialize(string path)
        {
            OAuth.OAuthToken consumerToken = new OAuth.OAuthToken("LDlaQSUySTwDAuyNG7dUQ", "rOEqilylc2zYqBoRjmJjx61GgeLitb6Kf35dePbE");
            OAuth.OAuthToken accessToken = IsLoggedIn() ? new OAuth.OAuthToken(AccessToken, AccessTokenSecret) : null;

            this.consumer = new Springnote.Consumer(consumerToken, accessToken);
            FilePath = path;
        }

        public static Setting Load(string root)
        {
            string path = root + "\\clipnote.config.xml";
            Setting ret;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Setting));
                FileStream stream = new FileStream(path, FileMode.Open);

                ret = (Setting)serializer.Deserialize(stream);
                stream.Close();
            }
            catch(IOException)
            {
                ret = new Setting();
            }
            ret.Initialize(path);
            return ret;
        }

        public void ClearSession()
        {
            this.AccessToken = String.Empty;
            this.AccessTokenSecret = String.Empty;
            this.pageId = String.Empty;
            this.pageUrl = String.Empty;
            this.pageId = String.Empty;
            Save();
        }

        public Springnote.Consumer GetConsumer()
        {
            return consumer;
        }

        public Springnote.Note GetNote()
        {
            return new Springnote.Note(noteName, GetConsumer());
        }

        public Springnote.Page GetPage()
        {
            return GetNote().FindPage(pageId);
        }

        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(this.GetType());

            XmlWriter writer = new XmlTextWriter(FilePath, Encoding.UTF8);
            serializer.Serialize(writer, this);
            writer.Close();
        }

        public Boolean IsLoggedIn()
        {
            return this.AccessToken != null && this.AccessToken.Length > 0 && this.AccessTokenSecret != null && this.AccessTokenSecret.Length > 0;
        }

        public void Authorize()
        {            
            consumer.GetRequestToken();
            consumer.Authorize(null);
        }

        public Boolean GetAccessToken()
        {
            consumer.GetAccessToken();
            AccessToken = consumer.accessToken.TokenKey;
            AccessTokenSecret = consumer.accessToken.TokenSecret;

            Save();
            return true;
        }

        public void SetAutorun(string path)
        {
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            rkApp.SetValue("ClipNote", "\"" + path + "\" /minimize");
        }

        public void ClearAutorun()
        {
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            rkApp.DeleteValue("ClipNote", false);
        }
    }
}
