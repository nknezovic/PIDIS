using System;
using System.Collections.Generic;
using TxtToXmlParser.Model.Models;
using TxtToXmlParser.Parser.Services;

interface ISerializer{

    //interface je promise da object moze performat metode zapisane u interfacu
    //therefore ne mozemo koristiti static metode
    public void Serialize (string filepath, IEnumerable<Person> persons);
}