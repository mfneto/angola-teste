using System.Threading.Tasks;

namespace ClinicaVivaEstetica.Application.Repositories.Customer
{
    public interface ICustomerWriteOnlyRepository
    {
        Task Add(Domain.Customers.Customer customer);
        Task Update(Domain.Customers.Customer customer);
        Task Delete(Domain.Customers.Customer customer);
    }
}
