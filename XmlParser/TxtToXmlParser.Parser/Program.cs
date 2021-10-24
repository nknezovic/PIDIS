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
            var (txtFilePath, xmlFilePath) = ParseArguments(args);
            var service = new TxtParserService();
            var persons = service.ParseTxtFile(txtFilePath);

            var serializer = new XmlSerializer(typeof(List<Person>));

            var xmlFileStream = new FileStream(xmlFilePath, FileMode.Create);

            serializer.Serialize(xmlFileStream, persons.ToList());

            /* foreach(var person in persons) 
            {
                serializer.Serialize(xmlFileStream, persons.ToList());
            } */

            /* using (var sequenceEnum = persons.GetEnumerator())
            {
                while( sequenceEnum.MoveNext())
                {
                    serializer.Serialize(xmlFileStream, persons.ToList());
                }
            } */
            //C# xml serializer pogledat na googleu
           
            

            /*var xmlFileStream = new FileStream(xmlFilePath, FileMode.Create);
            
            foreach (var person in persons)
            {
                Console.WriteLine(person.OIB);
                Console.WriteLine(person.Name);
                Console.WriteLine(person.DateOfBirth);
            }
            

            serializer.Serialize(xmlFileStream, persons.ToList());*/
            
        }

        private static (string txtFilePath, string xmlFilePath) ParseArguments(string[] args){ /*ovdje ubacit serializer type*/
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

            var xmlFile = args[1];

            var xmlFileDirectory = Path.GetDirectoryName(xmlFile);
            var directoryInfo = new DirectoryInfo(xmlFileDirectory);

            if(!directoryInfo.Exists){
                throw new FileNotFoundException($"File with path: {xmlFile} does not exist");
            }

            return (txtFile, xmlFile);
        }
    }
}
