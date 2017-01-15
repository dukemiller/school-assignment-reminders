using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using GalaSoft.MvvmLight;

namespace school_assignment_reminders.Models
{
    [Serializable]
    public class Assignment: ObservableObject
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("notes")]
        public string Notes { get; set; }

        [XmlAttribute("position")]
        public int Position { get; set; }

        [XmlAttribute("completed")]
        public bool Completed { get; set; }

        [XmlElement("duedate")]
        public DueDate DueDate { get; set; }
    }
}
