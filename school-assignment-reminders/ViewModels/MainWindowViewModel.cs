using System.Collections.ObjectModel;
using System.Timers;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MaterialDesignThemes.Wpf;
using school_assignment_reminders.Models;
using school_assignment_reminders.Services.Interfaces;
using school_assignment_reminders.Views.Dialogs;

namespace school_assignment_reminders.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<Class> _classes;
        private Assignment _selectedAssignment;
        private Class _selectedClass;
        private readonly Timer _timer;
        private readonly ISettingsService _settings;

        // 

        public MainWindowViewModel(ISettingsService settings)
        {
            _settings = settings;
            Classes = _settings.Classes;

            // refresh the assignment dates every hour
            _timer = new Timer {Interval = 1000 * 60 * 60};
            _timer.Elapsed += (sender, args) => 
            {
                foreach (var @class in Classes)
                    foreach (var assignment in @class.Assignments)
                    {
                        assignment.RaisePropertyChanged("DueTime");
                        assignment.RaisePropertyChanged("DaysUntilDue");
                    }
            };
            _timer.Enabled = true;

            // 

            AddAssignmentCommand = new RelayCommand(AddAssignment);
            AddClassCommand = new RelayCommand(AddClass);
            RemoveClassCommand = new RelayCommand(RemoveClass);
            RemoveAssignmentCommand = new RelayCommand(RemoveAssignment);
        }
        

        // 

        public Class SelectedClass
        {
            get => _selectedClass;
            set => Set(() => SelectedClass, ref _selectedClass, value);
        }

        public Assignment SelectedAssignment
        {
            get => _selectedAssignment;
            set => Set(() => SelectedAssignment, ref _selectedAssignment, value);
        }
        
        public ObservableCollection<Class> Classes
        {
            get => _classes;
            set => Set(() => Classes, ref _classes, value);
        }

        // 

        public RelayCommand AddAssignmentCommand { get; set; }

        public RelayCommand AddClassCommand { get; set; }

        public RelayCommand RemoveClassCommand { get; set; }

        public RelayCommand RemoveAssignmentCommand { get; set; }

        // 
        
        private async void AddAssignment()
        {
            var selected = SelectedClass;
            var view = new AddAssignment
            {
                DataContext = selected
            };
            var result = await DialogHost.Show(view) as Assignment;
            if (result != null)
            {
                selected.Assignments.Add(result);
                _settings.Save();
            }
        }

        private async void AddClass()
        {
            var view = new AddClass();
            var result = await DialogHost.Show(view) as Class;
            if (result != null)
            {
                Classes.Add(result);
                _settings.Save();
            }
        }

        private async void RemoveClass()
        {
            var selected = SelectedClass;
            var view = new RemoveClass();
            var result = await DialogHost.Show(view) as bool?;
            if (result ?? false)
            {
                Classes.Remove(selected);
                _settings.Save();
            }
        }

        private void RemoveAssignment()
        {
            SelectedClass.Assignments.Remove(SelectedAssignment);
            _settings.Save();
        }
    }
}