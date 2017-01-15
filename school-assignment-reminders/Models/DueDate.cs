using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace school_assignment_reminders.Models
{
    [Serializable]
    public class DueDate
    {
        [XmlAttribute("due_at")]
        public DateTime Due { get; set; }

        [XmlIgnore]
        public int DaysUntilDue => Due.Day - DateTime.Now.Day;

        [XmlIgnore]
        public int HoursUntilDue => Due.Hour - DateTime.Now.Hour;
    }
}
