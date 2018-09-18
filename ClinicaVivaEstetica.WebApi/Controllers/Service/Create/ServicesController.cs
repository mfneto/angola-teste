using System.Threading.Tasks;
using ClinicaVivaEstetica.Application.Commands.Service.Create;
using ClinicaVivaEstetica.Application.Results;
using ClinicaVivaEstetica.WebApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVivaEstetica.WebApi.Controllers.Service.Create
{
    [Route("api/[controller]")]
    public class ServicesController : Controller
    {
        private readonly ICreateServiceService createServiceService;

        public ServicesController(ICreateServiceService createServiceService)
        {
            this.createServiceService = createServiceService;
        }

        /// <summary>
        /// Cria um serviço.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateServiceRequest request)
        {
            var command = new CreateServiceCommand(request.Name, request.AllowHalfTime);
            var result = await createServiceService.Process(command);

            return Ok(new ApiReturnItem<ServiceResult>
            {
                Item = result,
                Success = true
            });
        }
    }
}
