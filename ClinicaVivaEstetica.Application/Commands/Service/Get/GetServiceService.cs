using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicaVivaEstetica.Application.Queries;
using ClinicaVivaEstetica.Application.Repositories.Service;
using ClinicaVivaEstetica.Application.Results;

namespace ClinicaVivaEstetica.Application.Commands.Service.Get
{
    public class GetServiceService : IGetServiceService
    {
        private readonly IServiceReadOnlyRepository serviceReadOnlyRepository;
        private readonly IServicesQueries servicesQueries;

        private readonly IResultConverter resultConverter;

        public GetServiceService(
            IServiceReadOnlyRepository serviceReadOnlyRepository,
            IResultConverter resultConverter,
            IServicesQueries servicesQueries)
        {
            this.serviceReadOnlyRepository = serviceReadOnlyRepository;
            this.resultConverter = resultConverter;
            this.servicesQueries = servicesQueries;
        }

        public async Task<ServiceResult> Get(Guid id)
        {
           
            var service = await serviceReadOnlyRepository.Get(id);
            
            ServiceResult serviceResult = resultConverter.Map<ServiceResult>(service);
            
            return serviceResult;
        }

        public async Task<List<ServiceResult>> GetAll()
        {
            var services = await servicesQueries.GetAllServices();

            List<ServiceResult> serviceResults = resultConverter.Map<List<ServiceResult>>(services);

            return serviceResults?.OrderBy(o => o.Name).ToList();
        }
    }
}
