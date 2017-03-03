using Newtonsoft.Json.Linq;
using System.Linq;

namespace Configuration
{
    public static class JsonParser
    {
        public static T JsonValueByPath<T>(string json, string path)
        {
            JObject obj = JObject.Parse(json);
            JToken token = null;

            var parts = path.Split(':');
            var last = parts.Last();
            foreach (var element in parts)
            {
                if (element == last)
                {
                    token = obj[element];
                }
                else
                {
                    obj = obj[element] as JObject;
                }
            }

            return token.Value<T>();

        }
    }
}
