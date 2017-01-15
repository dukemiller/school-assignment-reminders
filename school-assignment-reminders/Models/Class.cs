using System;
using System.Collections.Generic;
using System.Windows.Documents;
using System.Xml.Serialization;
using GalaSoft.MvvmLight;

namespace school_assignment_reminders.Models
{
    [Serializable]
    public class Class: ObservableObject
    {
        /// <summary>
        ///     The title, e.g. SER 423
        /// </summary>
        [XmlAttribute("title")]
        public string Title { get; set; }

        /// <summary>
        ///     The name, e.g. "Mobile Systems"
        /// </summary>
        [XmlAttribute("name")]
        public string Name { get; set; }

        /// <summary>
        ///     The combined title and fullname, e.g. SER 423 - Mobile Systems
        /// </summary>
        [XmlIgnore]
        public string FullName => $"{Title} - {Name}";

        [XmlElement("assignment")]
        public List<Assignment> Assignments { get; set; } = new List<Assignment>();
    }
}