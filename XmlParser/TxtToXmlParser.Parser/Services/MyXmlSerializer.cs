using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using TxtToXmlParser.Model.Models;

namespace TxtToXmlParser.Parser.Services
{
    public class MyXmlSerializer : ISerializer
    {
        public MyXmlSerializer()
        {
        }

        public void Serialize(string filepath, IEnumerable<Person> persons)
        {

            var serializer = new XmlSerializer(typeof(List<Person>));

            var xmlFileStream = new FileStream(filepath, FileMode.Create);

            serializer.Serialize(xmlFileStream, persons.ToList());

            xmlFileStream.Close();
        }
    }
}