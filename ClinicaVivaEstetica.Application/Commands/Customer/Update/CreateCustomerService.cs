using System.Threading.Tasks;
using ClinicaVivaEstetica.Application.Commands.Customer.Create;
using ClinicaVivaEstetica.Application.Repositories.Customer;
using ClinicaVivaEstetica.Application.Results;

namespace ClinicaVivaEstetica.Application.Commands.Customer.Update
{
    public class UpdateCustomerService : IUpdateCustomerService
    {
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;
        private readonly IResultConverter resultConverter;

        public UpdateCustomerService(
            ICustomerWriteOnlyRepository customerWriteOnlyRepository,
            IResultConverter resultConverter)
        {
            this.customerWriteOnlyRepository = customerWriteOnlyRepository;
            this.resultConverter = resultConverter;
        }

        public async Task<CustomerResult> Process(UpdateCustomerCommand command)
        {
            Domain.Customers.Customer customer = new Domain.Customers.Customer(command.CustomerId, command.Name, command.LastName, command.Document, command.Celphone, command.Address);

            await customerWriteOnlyRepository.Update(customer);
            
            CustomerResult customerResult = resultConverter.Map<CustomerResult>(customer);
            
            return customerResult;
        }
    }
}
