using System;

namespace ClinicaVivaEstetica.WebApi.Model
{
    public class CreateScheduleRequest
    {
        public DateTime Day { get; set; }
        public TimeSpan Hour{ get; set; }
        public Guid CustomerId { get; set; }
        public Guid ServiceId { get; set; }
    }
}