using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace APBD_02.Models
{ 
    [XmlRoot(ElementName = "student")]
    public class Student
    {
        [XmlAttribute]
        public string Index { get; set; }

        [XmlElement(ElementName = "fname")]
        public string Imie { get; set; }

        [XmlElement(ElementName = "lname")]
        public string Nazwisko{ get; set; }
 
        [XmlElement(ElementName = "birthdate")]
        public string DataUrodzin { get; set; }

        [XmlElement(ElementName = "email")]
        public string Email { get; set; }

        [XmlElement(ElementName = "fathersName")]
        public string ImieMatki { get; set; }

        [XmlElement(ElementName = "mothersName")]
        public string ImieOjca { get; set; }

        [XmlElement(ElementName = "studies")]
        public StudiaInfo Studia { get; set; }

    }
}
