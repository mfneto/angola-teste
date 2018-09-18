using System.Threading.Tasks;
using ClinicaVivaEstetica.Application.Commands.Service.Create;
using ClinicaVivaEstetica.Application.Repositories.Customer;
using ClinicaVivaEstetica.Application.Repositories.Schedule;
using ClinicaVivaEstetica.Application.Repositories.Service;
using ClinicaVivaEstetica.Application.Results;

namespace ClinicaVivaEstetica.Application.Commands.Schedule.Create
{
    public class CreateScheduleService : ICreateScheduleService
    {
        private readonly IScheduleWriteOnlyRepository scheduleWriteOnlyRepository;
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;
        private readonly IServiceReadOnlyRepository serviceReadOnlyRepository;
        private readonly IResultConverter resultConverter;

        public CreateScheduleService(
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

        public async Task<ScheduleResult> Process(CreateScheduleCommand command)
        {
            Domain.Schedule.Schedule schedule = new Domain.Schedule.Schedule(command.Day, command.Hour)
            {
                Customer = await customerReadOnlyRepository.Get(command.CustomerId),
                Service = await serviceReadOnlyRepository.Get(command.ServiceId)
            };

            await scheduleWriteOnlyRepository.Add(schedule);

            ScheduleResult scheduleResult = resultConverter.Map<ScheduleResult>(schedule);

            return scheduleResult;
        }
    }
}
