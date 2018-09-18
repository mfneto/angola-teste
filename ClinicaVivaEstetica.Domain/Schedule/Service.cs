using System;
using ClinicaVivaEstetica.Domain.ValueObjects;

namespace ClinicaVivaEstetica.Domain.Schedule
{
    public class Schedule : Entity, IAggregateRoot
    {
        public virtual DateTime Day { get; private set; }
        public virtual TimeSpan Hour { get; private set; }
       
        public Schedule(DateTime day, TimeSpan hour)
            : this()
        {
            Day = day;
            Hour = hour;
        }

        public Schedule(Guid scheduleId, DateTime day, TimeSpan hour)
            : this()
        {
            Id = scheduleId;
            Day = day;
            Hour = hour;
        }

        public Schedule()
        {
        }

        public virtual int Version { get; private set; }

        public virtual Service.Service Service { get; set; }
        public virtual Customers.Customer Customer { get; set; }
    }
}
