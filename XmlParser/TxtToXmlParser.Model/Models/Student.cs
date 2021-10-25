using System;
using TxtToXmlParser.Model.Genders;

namespace TxtToXmlParser.Model.Models
{
    public class Student : Person
    {
        public Student(float avgGrade,string oIB, string name, Gender gender, DateTime dateOfBirth) 
            : base(oIB, name, gender, dateOfBirth)
        {
            this.AvgGrade = avgGrade;            
        }

        public Student()
        {  
        }
        public float AvgGrade { get; set; }
    }
}