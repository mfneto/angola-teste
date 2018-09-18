using System.Globalization;
using Newtonsoft.Json;

namespace ClinicaVivaEstetica.WebApp.Utils.Json
{
    public static class JsonConverterUtility
    {
        public static T DeserializeObject<T>(string json)
        {
            CultureInfo cultureInfo = CultureInfo.GetCultureInfo("PT-br");
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
            {
                Culture = cultureInfo,
            };

            return JsonConvert.DeserializeObject<T>(json, jsonSerializerSettings);
        }
    }
    
}
