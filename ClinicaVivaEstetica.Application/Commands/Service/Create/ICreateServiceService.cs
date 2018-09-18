using System.Threading.Tasks;
using ClinicaVivaEstetica.Application.Results;

namespace ClinicaVivaEstetica.Application.Commands.Service.Create
{
    public interface ICreateServiceService
    {
        Task<ServiceResult> Process(CreateServiceCommand message);
    }
}
