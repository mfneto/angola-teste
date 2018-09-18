using System;
using System.Threading.Tasks;
using ClinicaVivaEstetica.Application.Commands.Customer.Delete;
using ClinicaVivaEstetica.WebApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVivaEstetica.WebApi.Controllers.Customer.Delete
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly IDeleteCustomerService deleteCustomerService;

        public CustomersController(IDeleteCustomerService deleteCustomerService)
        {
            this.deleteCustomerService = deleteCustomerService;
        }

        /// <summary>
        /// Deleta um cliente.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await deleteCustomerService.Proccess(id);
            return Ok(new ApiReturnItem<Boolean> { Item = true, Success = true, ApiReturnMessage = new ApiReturnMessage { Title = "Operação realizada com sucesso!" } });
        }
    }
}
