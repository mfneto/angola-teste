using System;
using System.Collections.Generic;
using ClinicaVivaEstetica.Domain.ValueObjects;

namespace ClinicaVivaEstetica.Domain.Service
{
    public class Service : Entity, IAggregateRoot
    {
        public virtual Name Name { get; protected set; }
        public virtual Boolean AllowHalfTime { get; protected set; }
       
        public Service(Name name, Boolean allowHalfTime)
            : this()
        {
            Name = name;
            AllowHalfTime = allowHalfTime;
        }

        public Service(Guid serviceId, Name name, Boolean allowHalfTime)
            : this()
        {
            Id = serviceId;
            Name = name;
            AllowHalfTime = allowHalfTime;
        }

        public Service()
        {
        }

        public virtual int Version { get; protected set; }

        public virtual ICollection<Schedule.Schedule> Schedules { get; set; }
    }
}
