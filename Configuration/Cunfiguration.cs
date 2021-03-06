﻿using Configuration.Configuration.Models;
using Configuration.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace Configuration
{
    public static class Cunfiguration
    {
        const string ConfigurationFolderName = "Configuration";
        const string GlobalConfigurationFile = "GlobalConfiguration.json";
        const string EnvironmentAppSettingsKey = "environment";

        public static T GetConfiguration<T>(string environment = null)
        {
            return GetConfigurationFile<T>(environment);
        }

        private static T GetConfigurationFile<T>(string environment = null)
        {
            var basePath = GetExcutionFolder() + $@"\{ConfigurationFolderName}\";
            environment = environment ?? GetEnvironment(basePath);
            var fileName = typeof(T).Name + ".json";

            return ReadConfigJson<T>(basePath + $@"{environment}\{fileName}");
        }

        private static T GetXmlConfigurationFile<T>(string environment = null)
        {
            var basePath = GetExcutionFolder() + $@"\{ConfigurationFolderName}\";
            environment = environment ?? GetEnvironment(basePath);
            var fileName = typeof(T).Name + ".xml";

            return ReadConfigXml<T>(basePath + $@"{environment}\{fileName}");
        }

        private static string GetExcutionFolder()
        {
            string assemblyFile = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
            return Uri.UnescapeDataString(Path.GetDirectoryName(assemblyFile));
        }

        private static string GetEnvironment(string basePath)
        {
            //see if the enviroment is definet in the web project
            var test = ConfigurationManager.AppSettings[EnvironmentAppSettingsKey];
            return ConfigurationManager.AppSettings[EnvironmentAppSettingsKey] ?? ReadConfigJson<GlobalConfiguration>(basePath + GlobalConfigurationFile).Environment;
        }
        private static T ReadConfigJson<T>(string path)
        {
            return JObject.Parse(File.ReadAllText(path)).ToObject<T>();
        }

        public static T ReadConfigXml<T>(string path)
        {
            var reader = new XmlSerializer(typeof(T));
            return (T)reader.Deserialize(new StreamReader(path));
        }
    }
}
