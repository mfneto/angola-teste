using System.Threading.Tasks;
using ClinicaVivaEstetica.Application.Results;

namespace ClinicaVivaEstetica.Application.Commands.Customer.Create
{
    public interface ICreateCustomerService
    {
        Task<CustomerResult> Process(CreateCustomerCommand message);
    }
}
