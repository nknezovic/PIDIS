using System;
using System.Xml.Serialization;
using TxtToXmlParser.Model.Genders;

namespace TxtToXmlParser.Model.Models
{   
    [XmlInclude(typeof(Student))]
    [XmlInclude(typeof(Professor))]
    public abstract class Person
    {
        protected Person(string oIB, string name, Gender gender, DateTime dateOfBirth)
        {
            OIB = oIB;
            Name = name;
            Gender = gender;
            DateOfBirth = dateOfBirth;
        }

        protected Person()
        {}

        public string OIB { get; }

        public string Name { get; } 
        
        public Gender Gender { get; }

        public DateTime DateOfBirth { get; }
    }
}