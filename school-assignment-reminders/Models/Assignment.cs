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
        private string _name;
        private string _notes;
        private bool _completed;
        private DateTime _due;

        public Assignment()
        {
            Due = DateTime.Now;
        }

        [XmlAttribute("name")]
        public string Name
        {
            get { return _name; }
            set { Set(() => Name, ref _name, value); }
        }

        [XmlAttribute("notes")]
        public string Notes
        {
            get { return _notes; }
            set { Set(() => Notes, ref _notes, value); }
        }
        
        [XmlAttribute("completed")]
        public bool Completed
        {
            get { return _completed; }
            set { Set(() => Completed, ref _completed, value); }
        }

        [XmlAttribute("due_at")]
        public DateTime Due
        {
            get { return _due; }
            set { Set(() => Due, ref _due, value); }
        }

        [XmlIgnore]
        private int DaysUntilDue => (Due - DateTime.Now).Days;

        [XmlIgnore]
        public string DueTime
            => DaysUntilDue > 1
            ? $"{DaysUntilDue} days remaining"
                : DaysUntilDue == 1 ? $"{DaysUntilDue} day remaining" 
                : DaysUntilDue == 0 
                    ? "Due today" 
                    : "";
    }
}
