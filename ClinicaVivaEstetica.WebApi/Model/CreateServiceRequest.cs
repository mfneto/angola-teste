using System;

namespace ClinicaVivaEstetica.WebApi.Model
{
    public class CreateServiceRequest
    {
        public string Name { get; set; }
        public Boolean AllowHalfTime { get; set; }
    }
}