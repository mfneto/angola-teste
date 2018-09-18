using System.Threading.Tasks;

namespace ClinicaVivaEstetica.Application.Repositories.Schedule
{
    public interface IScheduleWriteOnlyRepository
    {
        Task Add(Domain.Schedule.Schedule schedule);
        Task Update(Domain.Schedule.Schedule schedule);
        Task Delete(Domain.Schedule.Schedule schedule);
    }
}
