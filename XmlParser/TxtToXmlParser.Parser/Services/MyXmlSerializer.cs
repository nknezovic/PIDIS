using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using TxtToXmlParser.Model.Models;

namespace TxtToXmlParser.Parser.Services
{
    public class MyXmlSerializer
    {
        public MyXmlSerializer()
        {
        }

        /* public void Serialize(List<Person> persons, string filepath)
        {
            var formatter = new XmlSerializer(typeof(List<Person>));
            var stream = new FileStream(filepath, FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, persons, "TxtToXmlParser.Model.Models");
            stream.Close();
        } */
    }
}