using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ClinicaVivaEstetica.WebApp.Models
{
    public class ApiReturnList<T> where T : new()
    {
        [JsonProperty("items")]
        public List<T> Items { get; set; }

        [JsonProperty("mensagem")]
        public ApiReturnMessage ApiReturnMessage { get; set; }

        [JsonProperty("sucesso")]
        public Boolean Success { get; set; }

        [JsonProperty("versao")]
        public String Version { get; set; }
    }
}