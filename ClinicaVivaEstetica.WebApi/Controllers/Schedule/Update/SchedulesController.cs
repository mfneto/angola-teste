using System.Threading.Tasks;
using ClinicaVivaEstetica.Application.Commands.Schedule.Update;
using ClinicaVivaEstetica.Application.Commands.Service.Update;
using ClinicaVivaEstetica.Application.Results;
using ClinicaVivaEstetica.WebApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVivaEstetica.WebApi.Controllers.Schedule.Update
{
    [Route("api/[controller]")]
    public class SchedulesController : Controller
    {
        private readonly IUpdateScheduleService updateScheduleService;

        public SchedulesController(IUpdateScheduleService updateScheduleService)
        {
            this.updateScheduleService = updateScheduleService;
        }

        /// <summary>
        /// Atualiza um agendamento.
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]UpdateScheduleRequest request)
        {
            var command = new UpdateScheduleCommand(request.ScheduleId, request.Day, request.Hour, request.CustomerId, request.ServiceId);
            var result = await updateScheduleService.Process(command);

            return Ok(new ApiReturnItem<ScheduleResult>
            {
                Item = result,
                Success = true
            });
        }
    }
}
