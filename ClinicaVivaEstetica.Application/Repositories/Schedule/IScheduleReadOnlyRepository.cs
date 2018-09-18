using System;
using System.Threading.Tasks;

namespace ClinicaVivaEstetica.Application.Repositories.Schedule
{
    public interface IScheduleReadOnlyRepository
    {
        Task<Domain.Schedule.Schedule> Get(Guid id);
    }
}
