using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TxtToXmlParser.Parser.Services
{
    public class TxtParserService
    {
        public IEnumerable<Person> ParseTxtFile(string filename)
        {
            //IEnumerable<int> x = new int[10];  IEnumerable je kolekcija, apstrahiramo listu

            var fileInfo = new FileInfo(filename);
            if(!fileInfo.Exists)
            {
                //jedan ili drugi nacin
                //return new List<Person>();
                throw new FileNotFoundException($"File with path: {filename} does not exist");
            }

            var fileStream  = new FileStream(filename, FileMode.Open);

            var lines = File.ReadAllLines(filename);
            var linesWithoutFirstLine = lines.Skip(1).ToArray();
            //Linq za manipuliranje kolekcijama

            foreach(var line in linesWithoutFirstLine)
            {
                var columnData = line.Split(";");
                var person = GetPerson(columnsData);
                if(person is null){
                    continue;
                }

                persons.Add(person);

                return persons;
            }
        }

        private Person GetPerson(string[] columnsData){
            if(columnsData.Length < 1){
                return null;
            }
            var type = columnsData[0];
            var person = type switch{
                "Student" => new Student(
                    avgGrade: GetAverageGrade(columnsData)
                ),
                "Professor" => new Professor(),
                _ => null,
            }
            return columnsData[1];
        }

        private static float GetAverageGrade(string[] columnsData)
        {
                
        }
        private string GetOIB(string[] columnsData){
            if(columnsData.Length < 2){
                return null;
            }
            return columnsData[1];
        }
    }
}