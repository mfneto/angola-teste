using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicaVivaEstetica.Application.Results;

namespace ClinicaVivaEstetica.Application.Queries
{
    public interface ISchedulesQueries
    {
        Task<List<ScheduleResult>> GetAllSchedules();

        Task<bool> HasScheduleInTheDate(DateTime Date, TimeSpan hour, Guid? scheduleId = null);
    }
}