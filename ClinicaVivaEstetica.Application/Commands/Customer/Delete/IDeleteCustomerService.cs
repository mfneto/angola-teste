using System;
using System.Threading.Tasks;

namespace ClinicaVivaEstetica.Application.Commands.Customer.Delete
{
    public interface IDeleteCustomerService
    {
        Task Proccess(Guid id);
    }
}
