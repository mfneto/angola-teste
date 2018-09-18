using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicaVivaEstetica.Application.Queries;
using ClinicaVivaEstetica.Application.Repositories.Customer;
using ClinicaVivaEstetica.Application.Results;

namespace ClinicaVivaEstetica.Application.Commands.Customer.Get
{
    public class GetCustomerService : IGetCustomerService
    {
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;
        private readonly ICustomersQueries customersQueries;

        private readonly IResultConverter resultConverter;

        public GetCustomerService(
            ICustomerReadOnlyRepository customerReadOnlyRepository,
            IResultConverter resultConverter, 
            ICustomersQueries customersQueries)
        {
            this.customerReadOnlyRepository = customerReadOnlyRepository;
            this.resultConverter = resultConverter;
            this.customersQueries = customersQueries;
        }

        public async Task<CustomerResult> Get(Guid id)
        {
           
            var customer = await customerReadOnlyRepository.Get(id);
            
            CustomerResult customerResult = resultConverter.Map<CustomerResult>(customer);
            
            return customerResult;
        }

        public async Task<List<CustomerResult>> GetAll()
        {
            var customer = await customersQueries.GetAllCustomers();

            List<CustomerResult> customersResult = resultConverter.Map<List<CustomerResult>>(customer);

            return customersResult?.OrderBy(o => o.Name).ToList();
        }
    }
}
