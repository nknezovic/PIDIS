using System.Collections.Generic;
using TxtToXmlParser.Model.Models;

interface ISerializer{
    public void Serialize (IEnumerable<Person> persons, string filepath);
}