using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using TxtToXmlParser.Parser.Services;

namespace TxtToXmlParser.Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            var (txtFilePath, xmlFilePath) = ParseArguments(args);
            var service = new TxtParserService();
            var persons = service.ParseTxtFile(txtFilePath);

            //C# xml serializer pogledat na googleu

            var serializer = new XmlSerializer(typeof(List<Person>));

            var xmlFileStream = new FileStream(xmlFilePath, FileMode.Create);
            serializer.Serialize(xmlFileStream, persons.ToList());
            
        }

        private static (string txtFilePath, string xmlFilePath /*ovdje ubacit serializer type*/) ParseArguments(string[] args){
            if(args.Length != 2){
                throw new System.Exception("Number of arguments is invalid. Must be 2");
            }

            var txtFile = args[0];
            var fileInfo = new FileInfo(txtFile);
            if(!fileInfo.Exists)
            {
                //jedan ili drugi nacin
                //return new List<Person>();
                throw new FileNotFoundException($"File with path: {txtFile} does not exist");
            }

            var xmlFilePath = args[1];

            var xmlFileDirectory = Path.GetDirectoryName(xmlFilePath);
            var directoryInfo = new DirectoryInfo(xmlFileDirectory);

            if(!directoryInfo.Exists){
                throw new FileNotFoundException($"File with path: {txtFile} does not exist");
            }
        }
    }
}
