using System;

namespace ClinicaVivaEstetica.Application.Commands.Schedule.Update
{
    public class UpdateScheduleCommand
    {
        public Guid ScheduleId { get; private set; }
        public DateTime Day { get; private set; }
        public TimeSpan Hour { get; private set; }
        public Guid CustomerId { get; private set; }
        public Guid ServiceId { get; private set; }

        public UpdateScheduleCommand(Guid scheduleId, DateTime day, TimeSpan hour, Guid customerId, Guid serviceId)
        {
            ScheduleId = scheduleId;
            Day = day;
            Hour = hour;
            CustomerId = customerId;
            ServiceId = serviceId;
            this.ServiceId = serviceId;
        }
    }
}
