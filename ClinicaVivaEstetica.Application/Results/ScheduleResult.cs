using System;

namespace ClinicaVivaEstetica.Application.Results
{
    public class ScheduleResult
    {
        public Guid ScheduleId { get; set; }
        public DateTime Day { get; set; }
        public TimeSpan Hour{ get; set; }
        public CustomerResult Customer { get; set; }
        public ServiceResult Service { get; set; }

        public ScheduleResult()
        {

        }
    }
}