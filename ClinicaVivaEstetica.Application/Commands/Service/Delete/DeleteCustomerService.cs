using System;
using System.Threading.Tasks;
using ClinicaVivaEstetica.Application.Repositories.Service;

namespace ClinicaVivaEstetica.Application.Commands.Service.Delete
{
    public class DeleteServiceService : IDeleteServiceService
    {
        private readonly IServiceReadOnlyRepository serviceReadOnlyRepository;
        private readonly IServiceWriteOnlyRepository serviceWriteOnlyRepository;
        
        public DeleteServiceService(
            IServiceReadOnlyRepository serviceReadOnlyRepository,
            IServiceWriteOnlyRepository serviceWriteOnlyRepository)
        {
            this.serviceReadOnlyRepository = serviceReadOnlyRepository;
            this.serviceWriteOnlyRepository = serviceWriteOnlyRepository;
        }

        public async Task Proccess(Guid id)
        {
            var customer = await serviceReadOnlyRepository.Get(id);
            await serviceWriteOnlyRepository.Delete(customer);
        }
    }
}
