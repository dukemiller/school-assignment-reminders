using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using school_assignment_reminders.Models;

namespace school_assignment_reminders.ViewModels
{
    public class MainWindowViewModel: ViewModelBase
    {
        public MainWindowViewModel()
        {
            Classes = new ObservableCollection<Class>
            {
                new Class {Title = "IFT 383", Name = "Shell and Script Program/UNIX"},
                new Class {Title = "SER 402", Name = "Computing Capstone II"},
                new Class {Title = "SER 416", Name = "Software Enterprise: Proj & Proc"},
                new Class {Title = "SER 423", Name = "Mobile Systems"}
            };

            NewCommand = new RelayCommand<Class>(_ => MessageBox.Show(_.Name));
        }

        private ObservableCollection<Class> _classes;

        public ObservableCollection<Class> Classes
        {
            get { return _classes; }
            set { Set(() => Classes, ref _classes, value); }
        }

        public RelayCommand<Class> NewCommand { get; set; }
    }
}