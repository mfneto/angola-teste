using System;
using System.Threading.Tasks;
using ClinicaVivaEstetica.Application.Commands.Service.Delete;
using ClinicaVivaEstetica.WebApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVivaEstetica.WebApi.Controllers.Service.Delete
{
    [Route("api/[controller]")]
    public class ServicesController : Controller
    {
        private readonly IDeleteServiceService deleteServiceService;

        public ServicesController(IDeleteServiceService deleteServiceService)
        {
            this.deleteServiceService = deleteServiceService;
        }

        /// <summary>
        /// Deleta um serviço.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await deleteServiceService.Proccess(id);
            return Ok(new ApiReturnItem<Boolean> { Item = true, Success = true, ApiReturnMessage = new ApiReturnMessage { Title = "Operação realizada com sucesso!" } });
        }
    }
}
