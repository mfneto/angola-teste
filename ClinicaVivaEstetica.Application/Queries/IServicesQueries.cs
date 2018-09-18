using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicaVivaEstetica.Application.Results;

namespace ClinicaVivaEstetica.Application.Queries
{
    public interface IServicesQueries
    {
        Task<List<ServiceResult>> GetAllServices();
    }
}