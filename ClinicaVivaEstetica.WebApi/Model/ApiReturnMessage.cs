﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ClinicaVivaEstetica.WebApi.Model
{
    public class ApiReturnMessage
    {
        [JsonProperty("titulo")]
        public String Title { get; set; }

        [JsonProperty("detalhes")]
        public List<String> Details { get; set; }
    }
}