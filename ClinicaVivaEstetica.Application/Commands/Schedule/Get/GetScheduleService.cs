using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicaVivaEstetica.Application.Queries;
using ClinicaVivaEstetica.Application.Repositories.Schedule;
using ClinicaVivaEstetica.Application.Results;

namespace ClinicaVivaEstetica.Application.Commands.Schedule.Get
{
    public class GetScheduleService : IGetScheduleService
    {
        private readonly IScheduleReadOnlyRepository scheduleReadOnlyRepository;
        private readonly ISchedulesQueries schedulesQueries;

        private readonly IResultConverter resultConverter;

        public GetScheduleService(
            IScheduleReadOnlyRepository scheduleReadOnlyRepository,
            IResultConverter resultConverter,
            ISchedulesQueries schedulesQueries)
        {
            this.scheduleReadOnlyRepository = scheduleReadOnlyRepository;
            this.resultConverter = resultConverter;
            this.schedulesQueries = schedulesQueries;
        }

        public async Task<ScheduleResult> Get(Guid id)
        {
           
            var customer = await scheduleReadOnlyRepository.Get(id);

            ScheduleResult scheduleResult = resultConverter.Map<ScheduleResult>(customer);
            
            return scheduleResult;
        }

        public async Task<List<ScheduleResult>> GetAll()
        {
            var schedules = await schedulesQueries.GetAllSchedules();

            List<ScheduleResult> schedulesResult = resultConverter.Map<List<ScheduleResult>>(schedules);

            return schedulesResult?.OrderBy(o => o.Day).ThenBy(t => t.Hour).ToList();
        }
    }
}
