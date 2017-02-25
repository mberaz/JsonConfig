using Configuration.Configuration.Models;
using Configuration.Models.Web;
using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace Configuration
{
    public static class Cunfiguration
    {
        public static WebConfiguration WebConfiguration
        {
            get
            {
                return GetConfigurationFile<WebConfiguration>();
            }
        }

        private static T GetConfigurationFile<T>()
        {
            string assemblyFile = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
            var basePath = Path.GetDirectoryName(assemblyFile).Replace("%20", " ") + @"\Configuration\";

            var environment = ConfigurationManager.AppSettings["environment"];

            if (string.IsNullOrEmpty(environment))
            {
                var globalConfig = ReadConfigJson<GlobalConfiguration>(basePath + "GlobalConfiguration.json");
                environment = globalConfig.Environment;
            }

            return ReadConfigJson<T>(basePath + $@"{environment}\{(typeof(T).Name + ".json")}");
        }
        private static T ReadConfigJson<T>(string path)
        {
            return JObject.Parse(File.ReadAllText(path)).ToObject<T>();
        }
    }
}
