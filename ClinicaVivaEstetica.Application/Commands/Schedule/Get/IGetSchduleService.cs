using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicaVivaEstetica.Application.Results;

namespace ClinicaVivaEstetica.Application.Commands.Schedule.Get
{
    public interface IGetScheduleService
    {
        Task<ScheduleResult> Get(Guid id);

        Task<List<ScheduleResult>> GetAll();
    }
}
