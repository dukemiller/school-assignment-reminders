using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using school_assignment_reminders.Services;
using school_assignment_reminders.Services.Interfaces;
using school_assignment_reminders.ViewModels;

namespace school_assignment_reminders
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<ISettingsService>(new XmlSettingsService().Load);
            SimpleIoc.Default.Register<MainWindowViewModel>();
        }
        
        public MainWindowViewModel Main => ServiceLocator.Current.GetInstance<MainWindowViewModel>();
    }
}
