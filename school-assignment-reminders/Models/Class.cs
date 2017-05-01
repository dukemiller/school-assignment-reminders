using System;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using GalaSoft.MvvmLight;

namespace school_assignment_reminders.Models
{
    [Serializable]
    public class Class: ObservableObject
    {
        private string _title;
        private string _name;

        /// <summary>
        ///     The title, e.g. SER 423
        /// </summary>
        [XmlAttribute("title")]
        public string Title
        {
            get => _title;
            set => Set(() => Title, ref _title, value);
        }

        /// <summary>
        ///     The name, e.g. "Mobile Systems"
        /// </summary>
        [XmlAttribute("name")]
        public string Name
        {
            get => _name;
            set => Set(() => Name, ref _name, value);
        }

        /// <summary>
        ///     The combined title and fullname, e.g. SER 423 - Mobile Systems
        /// </summary>
        [XmlIgnore]
        public string FullName => $"{Title} - {Name}";

        [XmlElement("assignment")]
        public ObservableCollection<Assignment> Assignments { get; set; } = new ObservableCollection<Assignment>();
    }
}