using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicaVivaEstetica.Application.Queries;
using ClinicaVivaEstetica.Application.Repositories.Customer;
using ClinicaVivaEstetica.Application.Results;

namespace ClinicaVivaEstetica.Application.Commands.Customer.Delete
{
    public class DeleteCustomerService : IDeleteCustomerService
    {
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;

        public DeleteCustomerService(
            ICustomerReadOnlyRepository customerReadOnlyRepository,
            ICustomerWriteOnlyRepository customerWriteOnlyRepository)
        {
            this.customerReadOnlyRepository = customerReadOnlyRepository;
            this.customerWriteOnlyRepository = customerWriteOnlyRepository;
        }

        public async Task Proccess(Guid id)
        {
            var customer = await customerReadOnlyRepository.Get(id);
            await customerWriteOnlyRepository.Delete(customer);
        }
    }
}
