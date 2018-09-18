using System;

namespace ClinicaVivaEstetica.WebApi.Model
{
    public class UpdateScheduleRequest
    {
        public Guid ScheduleId { get; set; }
        public DateTime Day { get; set; }
        public TimeSpan Hour { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ServiceId { get; set; }
    }
}