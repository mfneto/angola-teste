using System.Threading.Tasks;
using ClinicaVivaEstetica.Application.Commands.Customer.Create;
using ClinicaVivaEstetica.Application.Results;
using ClinicaVivaEstetica.WebApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVivaEstetica.WebApi.Controllers.Customer.Create
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly ICreateCustomerService createCustomerService;

        public CustomersController(ICreateCustomerService createCustomerService)
        {
            this.createCustomerService = createCustomerService;
        }

        /// <summary>
        /// Cria um cliente.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateCustomerRequest request)
        {
            var command = new CreateCustomerCommand(request.Name, request.LastName, request.Document, request.Celphone, request.Address);
            var result = await createCustomerService.Process(command);

            return Ok(new ApiReturnItem<CustomerResult>
            {
                Item = result,
                Success = true
            });
        }
    }
}
