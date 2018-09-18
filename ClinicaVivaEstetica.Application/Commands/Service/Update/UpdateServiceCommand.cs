using System;

namespace ClinicaVivaEstetica.Application.Commands.Service.Update
{
    public class UpdateServiceCommand
    {
        public Guid ServiceId { get; private set; }
        public string Name { get; private set; }
        public bool AllowHalfTime { get; private set; }

        public UpdateServiceCommand(Guid serviceId, string name, bool allowHalfTime)
        {
            this.ServiceId = serviceId;
            this.Name = name;
            this.AllowHalfTime = allowHalfTime;
        }
    }
}
