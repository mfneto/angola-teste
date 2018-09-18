using System;
using System.Threading.Tasks;
using ClinicaVivaEstetica.Application.Commands.Schedule.Delete;
using ClinicaVivaEstetica.Application.Commands.Service.Delete;
using ClinicaVivaEstetica.WebApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVivaEstetica.WebApi.Controllers.Schedule.Delete
{
    [Route("api/[controller]")]
    public class SchedulesController : Controller
    {
        private readonly IDeleteScheduleService deleteScheduleService;

        public SchedulesController(IDeleteScheduleService deleteScheduleService)
        {
            this.deleteScheduleService = deleteScheduleService;
        }

        /// <summary>
        /// Deleta um agendamento.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await deleteScheduleService.Proccess(id);
            return Ok(new ApiReturnItem<Boolean> { Item = true, Success = true, ApiReturnMessage = new ApiReturnMessage { Title = "Operação realizada com sucesso!" } });
        }
    }
}
