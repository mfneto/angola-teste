using System;
using System.Threading.Tasks;

namespace ClinicaVivaEstetica.Application.Commands.Service.Delete
{
    public interface IDeleteServiceService
    {
        Task Proccess(Guid id);
    }
}
