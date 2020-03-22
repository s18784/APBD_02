using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace APBD_02.Models
{
    [XmlRoot (ElementName = "studies")]
    public class StudiaInfo
    {
        [XmlElement]
        public string Name { get; set; }
        
        [XmlElement]
        public string Type { get; set; }

        public StudiaInfo()
        {

        }
    }
}
