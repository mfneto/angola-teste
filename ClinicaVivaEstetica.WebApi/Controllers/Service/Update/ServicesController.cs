using System.Threading.Tasks;
using ClinicaVivaEstetica.Application.Commands.Service.Update;
using ClinicaVivaEstetica.Application.Results;
using ClinicaVivaEstetica.WebApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVivaEstetica.WebApi.Controllers.Service.Update
{
    [Route("api/[controller]")]
    public class ServicesController : Controller
    {
        private readonly IUpdateServiceService updateServiceService;

        public ServicesController(IUpdateServiceService updateServiceService)
        {
            this.updateServiceService = updateServiceService;
        }

        /// <summary>
        /// Atualiza um serviço.
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]UpdateServiceRequest request)
        {
            var command = new UpdateServiceCommand(request.ServiceId, request.Name, request.AllowHalfTime);
            var result = await updateServiceService.Process(command);

            return Ok(new ApiReturnItem<ServiceResult>
            {
                Item = result,
                Success = true
            });
        }
    }
}
