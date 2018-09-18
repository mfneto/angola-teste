using System.Threading.Tasks;
using ClinicaVivaEstetica.Application.Results;

namespace ClinicaVivaEstetica.Application.Commands.Schedule.Update
{
    public interface IUpdateScheduleService
    {
        Task<ScheduleResult> Process(UpdateScheduleCommand service);
    }
}