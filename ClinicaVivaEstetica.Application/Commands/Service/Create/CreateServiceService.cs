using System.Threading.Tasks;
using ClinicaVivaEstetica.Application.Repositories.Service;
using ClinicaVivaEstetica.Application.Results;

namespace ClinicaVivaEstetica.Application.Commands.Service.Create
{
    public class CreateServiceService : ICreateServiceService
    {
        private readonly IServiceWriteOnlyRepository serviceWriteOnlyRepository;
        private readonly IResultConverter resultConverter;

        public CreateServiceService(
            IServiceWriteOnlyRepository serviceWriteOnlyRepository,
            IResultConverter resultConverter)
        {
            this.serviceWriteOnlyRepository = serviceWriteOnlyRepository;
            this.resultConverter = resultConverter;
        }

        public async Task<ServiceResult> Process(CreateServiceCommand command)
        {
            Domain.Service.Service service = new Domain.Service.Service(command.Name, command.AllowHalfTime);

            await serviceWriteOnlyRepository.Add(service);
            
            ServiceResult serviceResult = resultConverter.Map<ServiceResult>(service);
            
            return serviceResult;
        }
    }
}
