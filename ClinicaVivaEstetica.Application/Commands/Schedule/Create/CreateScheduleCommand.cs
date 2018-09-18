using System;

namespace ClinicaVivaEstetica.Application.Commands.Schedule.Create
{
    public class CreateScheduleCommand
    {
        public DateTime Day { get; private set; }
        public TimeSpan Hour { get; private set; }
        public Guid CustomerId { get; private set; }
        public Guid ServiceId { get; private set; }

        public CreateScheduleCommand(DateTime day, TimeSpan hour, Guid customerId, Guid serviceId)
        {
            Day = day;
            Hour = hour;
            CustomerId = customerId;
            ServiceId = serviceId;
        }
    }
}
