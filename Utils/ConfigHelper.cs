using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using MyUpdate.Entity;
using System.Configuration;

namespace MyUpdate.Utils
{
    public class ConfigHelper
    {
        public static List<FileENT> GetUpdateList()
        {
            List<FileENT> list = new List<FileENT>();

            XmlDocument xml = new XmlDocument();
            xml.Load(AppParameter.LocalUPdateConfig);

            XmlNodeList nodeList = xml.SelectNodes("/updateFiles/file[@version>" + AppParameter.Version + "]");

            FileENT ent = null;
            foreach (XmlNode node in nodeList)
            {
                ent = new FileENT();

                ent.FileFullName = node.Attributes["name"].Value;
                ent.Src = node.Attributes["src"].Value;
                ent.Version = node.Attributes["version"].Value;
                ent.Size =Convert.ToInt32( node.Attributes["size"].Value);
                ent.Option = (UpdateOption)Enum.Parse(typeof(UpdateOption), node.Attributes["option"].Value);


                list.Add(ent);
            }

            return list;
        }

        public static void UpdateAppConfig(string key,string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[key].Value = value;
            config.Save(ConfigurationSaveMode.Full);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
