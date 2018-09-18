using System.Threading.Tasks;

namespace ClinicaVivaEstetica.Application.Repositories.Service
{
    public interface IServiceWriteOnlyRepository
    {
        Task Add(Domain.Service.Service service);
        Task Update(Domain.Service.Service service);
        Task Delete(Domain.Service.Service service);
    }
}
