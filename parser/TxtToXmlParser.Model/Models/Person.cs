using System;
using TxtToXmlParser.Model.Genders;

namespace TxtToXmlParser.Model.Models
{
    public abstract class Person
    {
        protected Person(string oIB, string name, Gender gender, DateTime dateOfBirth)
        {
            OIB = oIB;
            Name = name;
            Gender = gender;
            DateOfBirth = dateOfBirth;
        }

        public string OIB { get; }

        public string Name { get; } 
        
        public Gender Gender { get; }

        public DateTime DateOfBirth { get; }
    }
}