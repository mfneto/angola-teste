using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicaVivaEstetica.Application.Results;

namespace ClinicaVivaEstetica.Application.Commands.Service.Get
{
    public interface IGetServiceService
    {
        Task<ServiceResult> Get(Guid id);

        Task<List<ServiceResult>> GetAll();
    }
}
