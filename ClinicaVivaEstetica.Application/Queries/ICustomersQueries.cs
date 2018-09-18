using System.Collections.Generic;
using ClinicaVivaEstetica.Application.Results;
using System.Threading.Tasks;

namespace ClinicaVivaEstetica.Application.Queries
{
    public interface ICustomersQueries
    {
        Task<List<CustomerResult>> GetAllCustomers();
    }
}
