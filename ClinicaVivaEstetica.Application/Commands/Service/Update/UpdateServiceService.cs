using System.Threading.Tasks;
using ClinicaVivaEstetica.Application.Repositories.Customer;
using ClinicaVivaEstetica.Application.Repositories.Service;
using ClinicaVivaEstetica.Application.Results;

namespace ClinicaVivaEstetica.Application.Commands.Service.Update
{
    public class UpdateServiceService : IUpdateServiceService
    {
        private readonly IServiceWriteOnlyRepository serviceWriteOnlyRepository;
        private readonly IResultConverter resultConverter;

        public UpdateServiceService(
            IServiceWriteOnlyRepository serviceWriteOnlyRepository,
            IResultConverter resultConverter)
        {
            this.serviceWriteOnlyRepository = serviceWriteOnlyRepository;
            this.resultConverter = resultConverter;
        }

        public async Task<ServiceResult> Process(UpdateServiceCommand command)
        {
            Domain.Service.Service service = new Domain.Service.Service(command.ServiceId, command.Name, command.AllowHalfTime);

            await serviceWriteOnlyRepository.Update(service);
            
            ServiceResult serviceResult = resultConverter.Map<ServiceResult>(service);
            
            return serviceResult;
        }
    }
}
