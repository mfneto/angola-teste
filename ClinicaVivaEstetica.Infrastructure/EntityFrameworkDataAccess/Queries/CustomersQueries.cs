using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicaVivaEstetica.Application;
using ClinicaVivaEstetica.Application.Queries;
using ClinicaVivaEstetica.Application.Results;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVivaEstetica.Infrastructure.EntityFrameworkDataAccess.Queries
{
    public class CustomersQueries : ICustomersQueries
    {
        private readonly Context context;
        private readonly IResultConverter resultConverter;

        public CustomersQueries(Context context, IResultConverter resultConverter)
        {
            this.context = context;
            this.resultConverter = resultConverter;
        }

        public async Task<List<CustomerResult>> GetAllCustomers()
        {
            var customers = await context.Customers.ToListAsync();

            var customersResult = resultConverter.Map<List<CustomerResult>>(customers);

            return customersResult;
        }
    }
}
