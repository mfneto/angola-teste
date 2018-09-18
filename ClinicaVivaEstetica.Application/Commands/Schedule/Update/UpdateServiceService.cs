using System.Threading.Tasks;
using ClinicaVivaEstetica.Application.Commands.Service.Update;
using ClinicaVivaEstetica.Application.Repositories.Customer;
using ClinicaVivaEstetica.Application.Repositories.Schedule;
using ClinicaVivaEstetica.Application.Repositories.Service;
using ClinicaVivaEstetica.Application.Results;

namespace ClinicaVivaEstetica.Application.Commands.Schedule.Update
{
    public class UpdateScheduleService : IUpdateScheduleService
    {
        private readonly IScheduleWriteOnlyRepository scheduleWriteOnlyRepository;
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;
        private readonly IServiceReadOnlyRepository serviceReadOnlyRepository;
        private readonly IResultConverter resultConverter;

        public UpdateScheduleService(
            IScheduleWriteOnlyRepository scheduleWriteOnlyRepository,
            IResultConverter resultConverter,
            ICustomerReadOnlyRepository customerReadOnlyRepository,
            IServiceReadOnlyRepository serviceReadOnlyRepository)
        {
            this.scheduleWriteOnlyRepository = scheduleWriteOnlyRepository;
            this.resultConverter = resultConverter;
            this.customerReadOnlyRepository = customerReadOnlyRepository;
            this.serviceReadOnlyRepository = serviceReadOnlyRepository;
        }

        public async Task<ScheduleResult> Process(UpdateScheduleCommand command)
        {
            Domain.Schedule.Schedule schedule = new Domain.Schedule.Schedule(command.ScheduleId, command.Day, command.Hour)
            {
                Customer = await customerReadOnlyRepository.Get(command.CustomerId),
                Service = await serviceReadOnlyRepository.Get(command.ServiceId)
            };

            await scheduleWriteOnlyRepository.Update(schedule);

            ScheduleResult scheduleResult = resultConverter.Map<ScheduleResult>(schedule);
            
            return scheduleResult;
        }
    }
}
