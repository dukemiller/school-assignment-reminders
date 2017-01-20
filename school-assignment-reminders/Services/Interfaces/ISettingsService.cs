using System.Collections.ObjectModel;
using school_assignment_reminders.Models;

namespace school_assignment_reminders.Services.Interfaces
{
    public interface ISettingsService
    {
        ObservableCollection<Class> Classes { get; set;  }
        void Save();
    }
}