using Configuration.Configuration.Models;
using Configuration.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace Configuration
{
    public static class Cunfiguration
    {
        const string ConfigurationFolderName = "Configuration";
        const string GlobalConfigurationFile = "GlobalConfiguration.json";
        const string EnvironmentAppSettingsKey = "environment";

        public static WebConfiguration WebConfiguration
        {
            get
            {
                return GetConfigurationFile<WebConfiguration>();
            }
        }

        public static DataConfiguration DataConfiguration
        {
            get
            {
                return GetConfigurationFile<DataConfiguration>();
            }
        }

        public static T GetConfiguration<T>()
        {
            return GetConfigurationFile<T>();
        }
        private static T GetConfigurationFile<T>()
        {
            var basePath = GetExcutionFolder() + $@"\{ConfigurationFolderName}\";

            var environment = GetEnvironment(basePath);
            var fileName = typeof(T).Name + ".json";

            return ReadConfigJson<T>(basePath + $@"{environment}\{fileName}");
        }

        private static string GetExcutionFolder()
        {
            string assemblyFile = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
            return Uri.UnescapeDataString(Path.GetDirectoryName(assemblyFile));
        }

        private static string GetEnvironment(string basePath)
        {
            //see if the enviroment is definet in the web project
            return ConfigurationManager.AppSettings[EnvironmentAppSettingsKey] ?? ReadConfigJson<GlobalConfiguration>(basePath + GlobalConfigurationFile).Environment;
        }
        private static T ReadConfigJson<T>(string path)
        {
            return JObject.Parse(File.ReadAllText(path)).ToObject<T>();
        }
    }
}
