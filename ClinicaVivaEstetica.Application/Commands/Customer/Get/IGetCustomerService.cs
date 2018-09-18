using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicaVivaEstetica.Application.Results;

namespace ClinicaVivaEstetica.Application.Commands.Customer.Get
{
    public interface IGetCustomerService
    {
        Task<CustomerResult> Get(Guid id);

        Task<List<CustomerResult>> GetAll();
    }
}
