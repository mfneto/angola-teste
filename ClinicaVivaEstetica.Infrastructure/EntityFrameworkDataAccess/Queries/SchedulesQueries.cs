using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicaVivaEstetica.Application;
using ClinicaVivaEstetica.Application.Queries;
using ClinicaVivaEstetica.Application.Results;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVivaEstetica.Infrastructure.EntityFrameworkDataAccess.Queries
{
    public class SchedulesQueries : ISchedulesQueries
    {
        private readonly Context context;
        private readonly IResultConverter resultConverter;

        public SchedulesQueries(Context context, IResultConverter resultConverter)
        {
            this.context = context;
            this.resultConverter = resultConverter;
        }

        public async Task<List<ScheduleResult>> GetAllSchedules()
        {
            var schedules = await context.Schedules.ToListAsync();

            var schedulesResult = resultConverter.Map<List<ScheduleResult>>(schedules);

            return schedulesResult;
        }

        public async Task<bool> HasScheduleInTheDate(DateTime Date, TimeSpan hour, Guid? scheduleId = null)
        {
            return await context.Schedules.AnyAsync(a => a.Day.Date == Date.Date && a.Hour == hour && (scheduleId == null || a.Id != scheduleId));
        }
    }
}