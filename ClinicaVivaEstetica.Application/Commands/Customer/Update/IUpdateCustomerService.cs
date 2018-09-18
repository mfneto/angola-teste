using System.Threading.Tasks;
using ClinicaVivaEstetica.Application.Results;

namespace ClinicaVivaEstetica.Application.Commands.Customer.Update
{
    public interface IUpdateCustomerService
    {
        Task<CustomerResult> Process(UpdateCustomerCommand customer);
    }
}
