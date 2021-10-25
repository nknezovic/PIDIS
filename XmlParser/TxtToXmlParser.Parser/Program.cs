using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using TxtToXmlParser.Parser.Services;
using TxtToXmlParser.Model.Models;
using System.Collections.Generic;

namespace TxtToXmlParser.Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            var (txtFilePath, newFilePath) = ParseArguments(args);

            var service = new TxtParserService();
            var persons = service.ParseTxtFile(txtFilePath);

            //var persons1 = TxtParserService.ParseTxtFile(txtFilePath);  --> kad bi mi funckija bila static

            if(newFilePath.EndsWith("xml"))
            {
                var serializer = new MyXmlSerializer();
                serializer.Serialize(newFilePath, persons);
            }
            else if(newFilePath.EndsWith("json"))
            {
                var serializer = new MyJsonSerializer();
                serializer.Serialize(newFilePath, persons);
            }
            else{
                throw new NotImplementedException();
            }
        
        }

        private static (string txtFilePath, string newFilePath) ParseArguments(string[] args){ /*ovdje ubacit serializer type*/
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

            var newFile = args[1];

            var newFileDirectory = Path.GetDirectoryName(newFile);
            var directoryInfo = new DirectoryInfo(newFileDirectory);

            if(!directoryInfo.Exists){
                throw new FileNotFoundException($"File with path: {newFile} does not exist");
            }

            return (txtFile, newFile);
        }
    }
}
