using System;

namespace ClinicaVivaEstetica.Application.Results
{
    public class ServiceResult
    {
        public Guid ServiceId { get; set; }
        public string Name { get; set; }
        public Boolean AllowHalfTime { get; set; }


        public ServiceResult()
        {

        }

        public ServiceResult(Guid serviceId, string name, bool allowHalfTime) : this()
        {
            ServiceId = serviceId;
            Name = name;
            AllowHalfTime = allowHalfTime;
        }

    }
}