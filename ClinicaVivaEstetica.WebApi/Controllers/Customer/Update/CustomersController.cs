using System.Threading.Tasks;
using ClinicaVivaEstetica.Application.Commands.Customer.Create;
using ClinicaVivaEstetica.Application.Commands.Customer.Update;
using ClinicaVivaEstetica.Application.Results;
using ClinicaVivaEstetica.WebApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVivaEstetica.WebApi.Controllers.Customer.Update
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly IUpdateCustomerService updateCustomerService;

        public CustomersController(IUpdateCustomerService updateCustomerService)
        {
            this.updateCustomerService = updateCustomerService;
        }

        /// <summary>
        /// Atualiza um cliente.
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]UpdateCustomerRequest request)
        {
            var command = new UpdateCustomerCommand(request.CustomerId, request.Name, request.LastName, request.Document, request.Celphone, request.Address);
            var result = await updateCustomerService.Process(command);

            return Ok(new ApiReturnItem<CustomerResult>
            {
                Item = result,
                Success = true
            });
        }
    }
}
