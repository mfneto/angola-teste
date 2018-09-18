using System.Threading.Tasks;
using ClinicaVivaEstetica.Application.Results;

namespace ClinicaVivaEstetica.Application.Commands.Schedule.Create
{
    public interface ICreateScheduleService
    {
        Task<ScheduleResult> Process(CreateScheduleCommand message);
    }
}
