using System.Threading.Tasks;
using ClinicaVivaEstetica.Application.Repositories.Customer;
using ClinicaVivaEstetica.Application.Results;

namespace ClinicaVivaEstetica.Application.Commands.Customer.Create
{
    public class CreateCustomerService : ICreateCustomerService
    {
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;
        private readonly IResultConverter resultConverter;

        public CreateCustomerService(
            ICustomerWriteOnlyRepository customerWriteOnlyRepository,
            IResultConverter resultConverter)
        {
            this.customerWriteOnlyRepository = customerWriteOnlyRepository;
            this.resultConverter = resultConverter;
        }

        public async Task<CustomerResult> Process(CreateCustomerCommand command)
        {
            Domain.Customers.Customer customer = new Domain.Customers.Customer(command.Name, command.LastName, command.Document, command.Celphone, command.Address);

            await customerWriteOnlyRepository.Add(customer);
            
            CustomerResult customerResult = resultConverter.Map<CustomerResult>(customer);
            
            return customerResult;
        }
    }
}
