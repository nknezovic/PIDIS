using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Xml.Serialization;
using TxtToXmlParser.Model.Models;

namespace TxtToXmlParser.Parser.Services
{
    public class MyJsonSerializer : ISerializer
    {
        public MyJsonSerializer()
        {
        }

        public void Serialize(string filepath, IEnumerable<Person> persons)
        {

            var serializer = JsonSerializer.Serialize(persons);

            //var jsonFileStream = new FileStream(filepath, FileMode.Create);

            File.WriteAllText(filepath, serializer);

            //jsonFileStream.Close();
        }
    }
}