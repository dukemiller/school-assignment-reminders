using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;
using school_assignment_reminders.Models;
using school_assignment_reminders.Services.Interfaces;

namespace school_assignment_reminders.Services
{
    [Serializable]
    [XmlRoot("Settings")]
    public class XmlSettingsService: ISettingsService
    {
        private static string ApplicationDirectory => Path.Combine(Environment
                .GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "school_assignment_reminders");

        private static readonly string SettingsPath = Path.Combine(ApplicationDirectory,
            "settings.xml");

        public void Save()
        {
            using (var sw = new StreamWriter(SettingsPath))
            {
                var xmls = new XmlSerializer(typeof(XmlSettingsService));
                xmls.Serialize(sw, this);
            }
        }

        public XmlSettingsService Load()
        {
            if (!Directory.Exists(ApplicationDirectory))
                Directory.CreateDirectory(ApplicationDirectory);

            if (File.Exists(SettingsPath))
                using (var sw = new StreamReader(SettingsPath))
                {
                    var xmls = new XmlSerializer(typeof(XmlSettingsService));
                    var settings = xmls.Deserialize(sw) as XmlSettingsService;
                    Classes = settings?.Classes;
                }
            return this;
        }

        public ObservableCollection<Class> Classes { get; set; } = new ObservableCollection<Class>();
    }
}
