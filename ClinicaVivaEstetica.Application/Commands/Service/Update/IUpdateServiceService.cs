using System.Threading.Tasks;
using ClinicaVivaEstetica.Application.Results;

namespace ClinicaVivaEstetica.Application.Commands.Service.Update
{
    public interface IUpdateServiceService
    {
        Task<ServiceResult> Process(UpdateServiceCommand service);
    }
}
