using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace APBD_02.Models
{
    public class Uczelnia
    {
        public Uczelnia()
        {
            DateOfCreation = DateTime.Now.ToString("YY-MM-DD");
            Students = new HashSet<Student>();
        }
        

        [XmlAttribute]
        public string Author { get; set; }
        [XmlAttribute(AttributeName = "CreatedAt")]
        public string DateOfCreation { get; set; }

        
        public HashSet<Student> Students { get; set; }
    }
}
