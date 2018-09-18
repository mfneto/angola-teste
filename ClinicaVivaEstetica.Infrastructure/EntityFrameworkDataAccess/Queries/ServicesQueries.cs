using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicaVivaEstetica.Application;
using ClinicaVivaEstetica.Application.Queries;
using ClinicaVivaEstetica.Application.Results;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVivaEstetica.Infrastructure.EntityFrameworkDataAccess.Queries
{
    public class ServicesQueries : IServicesQueries
    {
        private readonly Context context;
        private readonly IResultConverter resultConverter;

        public ServicesQueries(Context context, IResultConverter resultConverter)
        {
            this.context = context;
            this.resultConverter = resultConverter;
        }

        public async Task<List<ServiceResult>> GetAllServices()
        {
            var services = await context.Services.ToListAsync();

            var servicesResult = resultConverter.Map<List<ServiceResult>>(services);

            return servicesResult;
        }
    }
}