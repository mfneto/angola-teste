using System;
using System.Threading.Tasks;
using ClinicaVivaEstetica.Application.Commands.Schedule.Get;
using ClinicaVivaEstetica.Application.Queries;
using ClinicaVivaEstetica.Application.Results;
using ClinicaVivaEstetica.WebApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVivaEstetica.WebApi.Controllers.Schedule.Validate
{
    [Route("api/[controller]")]
    public class SchedulesController : Controller
    {
        private readonly ISchedulesQueries schedulesQueries;

        public SchedulesController(ISchedulesQueries schedulesQueries)
        {
            this.schedulesQueries = schedulesQueries;
        }
        
        /// <summary>
        ///Existe agendamento na Data?.
        /// </summary>
        [HttpGet("Validate/{date}/{hour}/{scheduleId?}")]
        public async Task<IActionResult> Validate(DateTime date, TimeSpan hour, Guid? scheduleId)
        {
            var result = await schedulesQueries.HasScheduleInTheDate(date, hour, scheduleId);
            return Ok(new ApiReturnItem<Boolean>{ Item = result, Success = true });
        }
    }
}
