using System;
using System.Xml.Serialization;
using GalaSoft.MvvmLight;

namespace school_assignment_reminders.Models
{
    [Serializable]
    public class Assignment: ObservableObject
    {
        private string _name;
        private string _notes;
        private DateTime _due;

        public Assignment()
        {
            Due = DateTime.Now;
        }

        [XmlAttribute("name")]
        public string Name
        {
            get => _name;
            set => Set(() => Name, ref _name, value);
        }

        [XmlAttribute("notes")]
        public string Notes
        {
            get => _notes;
            set => Set(() => Notes, ref _notes, value);
        }

        [XmlAttribute("due_at")]
        public DateTime Due
        {
            get => _due;
            set => Set(() => Due, ref _due, value);
        }

        [XmlIgnore]
        private int DaysUntilDue => (int) Math.Ceiling((Due - DateTime.Now).TotalHours / 24);

        [XmlIgnore]
        public string DueTime
            => DaysUntilDue > 1
            ? $"{DaysUntilDue} days remaining"
                : DaysUntilDue == 1 ? "Due tomorrow" 
                : DaysUntilDue == 0 
                    ? "Due today" 
                    : "";
    }
}
