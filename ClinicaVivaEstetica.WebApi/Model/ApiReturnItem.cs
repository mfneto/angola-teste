using System;
using Newtonsoft.Json;

namespace ClinicaVivaEstetica.WebApi.Model
{
    public class ApiReturnItem<T> where T : new()
    {
        [JsonProperty("item")]
        public T Item { get; set; }

        [JsonProperty("mensagem")]
        public ApiReturnMessage ApiReturnMessage { get; set; }

        [JsonProperty("sucesso")]
        public Boolean Success { get; set; }

        [JsonProperty("versao")]
        public String Version { get; set; }
    }
}