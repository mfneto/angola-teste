using System;
using System.Threading.Tasks;

namespace ClinicaVivaEstetica.Application.Repositories.Customer
{
    public interface ICustomerReadOnlyRepository
    {
        Task<Domain.Customers.Customer> Get(Guid id);
    }
}
