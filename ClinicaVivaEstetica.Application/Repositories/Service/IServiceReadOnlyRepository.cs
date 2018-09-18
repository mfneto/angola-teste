using System;
using System.Threading.Tasks;

namespace ClinicaVivaEstetica.Application.Repositories.Service
{
    public interface IServiceReadOnlyRepository
    {
        Task<Domain.Service.Service> Get(Guid id);
    }
}
