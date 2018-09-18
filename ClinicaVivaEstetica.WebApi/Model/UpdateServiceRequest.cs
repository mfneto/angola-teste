using System;

namespace ClinicaVivaEstetica.WebApi.Model
{
    public class UpdateServiceRequest
    {
        public Guid ServiceId { get; set; }
        public string Name { get; set; }
        public Boolean AllowHalfTime { get; set; }
    }
}