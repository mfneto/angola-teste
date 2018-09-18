using System;
using System.Threading.Tasks;

namespace ClinicaVivaEstetica.Application.Commands.Schedule.Delete
{
    public interface IDeleteScheduleService
    {
        Task Proccess(Guid id);
    }
}
