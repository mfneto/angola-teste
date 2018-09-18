using System;
using System.Threading.Tasks;
using ClinicaVivaEstetica.Application.Repositories.Schedule;

namespace ClinicaVivaEstetica.Application.Commands.Schedule.Delete
{
    public class DeleteScheduleService : IDeleteScheduleService
    {
        private readonly IScheduleReadOnlyRepository scheduleReadOnlyRepository;
        private readonly IScheduleWriteOnlyRepository scheduleWriteOnlyRepository;
        
        public DeleteScheduleService(
            IScheduleReadOnlyRepository scheduleReadOnlyRepository,
            IScheduleWriteOnlyRepository scheduleWriteOnlyRepository)
        {
            this.scheduleReadOnlyRepository = scheduleReadOnlyRepository;
            this.scheduleWriteOnlyRepository = scheduleWriteOnlyRepository;
        }

        public async Task Proccess(Guid id)
        {
            var customer = await scheduleReadOnlyRepository.Get(id);
            await scheduleWriteOnlyRepository.Delete(customer);
        }
    }
}
