using System.Threading.Tasks;
using ClinicaVivaEstetica.Application.Commands.Schedule.Create;
using ClinicaVivaEstetica.Application.Results;
using ClinicaVivaEstetica.WebApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVivaEstetica.WebApi.Controllers.Schedule.Create
{
    [Route("api/[controller]")]
    public class SchedulesController : Controller
    {
        private readonly ICreateScheduleService createScheduleService;

        public SchedulesController(ICreateScheduleService createScheduleService)
        {
            this.createScheduleService = createScheduleService;
        }

        /// <summary>
        /// Cria um agendamento.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateScheduleRequest request)
        {
            var command = new CreateScheduleCommand(request.Day, request.Hour, request.CustomerId, request.ServiceId);
            var result = await createScheduleService.Process(command);

            return Ok(new ApiReturnItem<ScheduleResult>
            {
                Item = result,
                Success = true
            });
        }
    }
}
