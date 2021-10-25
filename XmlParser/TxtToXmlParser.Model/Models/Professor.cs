using System;
using TxtToXmlParser.Model.Genders;

namespace TxtToXmlParser.Model.Models
{
    public class Professor : Person
    {
        public Professor(decimal paycheck, string oIB, string name, Gender gender, DateTime dateOfBirth) : base(oIB, name, gender, dateOfBirth)
        {
            Paycheck = paycheck;
        }

        public Professor()
        {  
        }
        public decimal Paycheck { get; set; } 
    }
}