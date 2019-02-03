using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using ZbW.Testing.Dms.Client.Model;

namespace ZbW.Testing.Dms.Client.Services
{
    class XmlService
    {
        public String SeralizeMetadataItem(MetadataItem metadataItem)
        {
            XmlSerializer xmlserializer = new XmlSerializer(typeof(MetadataItem));
            StringWriter stringWriter = new StringWriter();
            XmlWriter writer = XmlWriter.Create(stringWriter);

            xmlserializer.Serialize(writer, metadataItem);
            var serializeXml = stringWriter.ToString();
            writer.Close();
            return serializeXml;
        }

        public MetadataItem DeseralizeMetadataItem(String path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(MetadataItem));
            StreamReader reader = new StreamReader(path);
            var metadataItem = (MetadataItem) serializer.Deserialize(reader);
            reader.Close();

            return metadataItem;
        }

        public void SaveXml(String serializeXml, String path)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(serializeXml);
            xdoc.Save(path);
        }
    }
}