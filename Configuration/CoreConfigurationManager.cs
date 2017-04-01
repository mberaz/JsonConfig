using Configuration.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Configuration
{
    public static class CoreConfigurationManager
    {
        const string ConfigurationFolderName = "Configuration";
        const string AppSettingsFileName = "appsettings.json";
        const string AppSettingsTemplae = "appsettings.{0].json";
        const string EnvironmentAppSettingsKey = "Environment";

        public static WebConfiguration WebConfiguration
        {
            get
            {
                return GetConfigurationFile<WebConfiguration>();
            }
        }

        public static T GetConfiguration<T>(string environment = null)
        {
            return GetConfigurationFile<T>(environment);
        }

        private static T GetConfigurationFile<T>(string environment = null)
        {
            var excutionFolder = GetExcutionFolder();
            var basePath = excutionFolder + $@"\{ConfigurationFolderName}\";
            var appSettingsBasePath = excutionFolder + $@"\{AppSettingsFileName}\";

            environment = environment ?? GetEnvironment(appSettingsBasePath);
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
            var appSetingsJson = File.ReadAllText(basePath.TrimEnd('\\'));
            return JsonParser.JsonValueByPath<string>(appSetingsJson, EnvironmentAppSettingsKey);
        }
        private static T ReadConfigJson<T>(string path)
        {
            return JObject.Parse(File.ReadAllText(path)).ToObject<T>();
        }
    }
}
