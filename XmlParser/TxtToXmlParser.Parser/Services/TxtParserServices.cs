using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TxtToXmlParser.Model.Models;
using TxtToXmlParser.Model.Genders;

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

            var fileStream  = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);

            var lines = File.ReadAllLines(filename);
            var linesWithoutFirstLine = lines.Skip(1).ToArray();
            //Linq za manipuliranje kolekcijama

            List<Person> persons = new List<Person>();

            foreach(var line in linesWithoutFirstLine)
            {
                var columnData = line.Split(";");
                //Console.WriteLine(string.Join("; ", columnData));
                var person = GetPerson(columnData);

                if(person is null){
                    continue;
                }

                persons.Add(person);
            }

            return persons;
        }

        private Person GetPerson(string[] columnsData){
            //ako nema nikakvih podataka
            if(columnsData.Length < 1){
                return null;
            }

            Console.WriteLine(columnsData.Length);

            var type = columnsData[0];
            Person person = type switch{
                "Student" => new Student(
                    avgGrade: GetAverageGrade(columnsData),
                    oIB: GetOIB(columnsData),
                    name: GetName(columnsData),
                    gender: GetGender(columnsData),
                    dateOfBirth: DateTime.Parse(GetDateOfBirth(columnsData))
                ),
                "Professor" => new Professor(
                    paycheck: GetPaycheck(columnsData),
                    oIB:GetOIB(columnsData),
                    name:GetName(columnsData),
                    gender: GetGender(columnsData),
                    dateOfBirth: DateTime.Parse(GetDateOfBirth(columnsData))
                ),
                _ => throw new NotImplementedException()
            };

            return person;
        }

        private static float GetAverageGrade(string[] columnsData)
        {
            float avgGrade = float.Parse(columnsData[5]);
            return avgGrade;                
        }

        private static decimal GetPaycheck(string[] columnsData)
        {
            decimal paycheck = decimal.Parse(columnsData[6]);
            return paycheck;  
        }
        private string GetOIB(string[] columnsData){
            if(columnsData.Length < 1){
                return null;
            }
            return columnsData[1];
        }

        private string GetName(string[] columnsData){
            if(columnsData.Length < 2){
                return null;
            }
            return columnsData[2];
        }

        private Gender GetGender(string[] columnsData){
            if(columnsData.Length < 3){
                return Gender.Undefined;
            }
            Gender gender = (Gender) Enum.Parse(typeof(Gender), columnsData[3]);
            return gender;
        }

        private string GetDateOfBirth(string[] columnsData){
            if(columnsData.Length < 4){
                return null;
            }
            return columnsData[4];
        }
    }
}