using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FandiApi.Extensoes
{
    public static class ExtensaoObjeto
    {
        public static Dictionary<string, string> ParaDicionarioString(this object obj)
        {
            try
            {
                var jsonSerializerSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    Converters = new List<Newtonsoft.Json.JsonConverter>() { new Newtonsoft.Json.Converters.StringEnumConverter() }
                };
                var json = JsonConvert.SerializeObject(obj, jsonSerializerSettings);
                return JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            }
            catch
            {
                return null;
            }
        }

    }
}
