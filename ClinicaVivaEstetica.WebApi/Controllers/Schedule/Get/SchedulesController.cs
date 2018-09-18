using System;
using System.Threading.Tasks;
using ClinicaVivaEstetica.Application.Commands.Schedule.Get;
using ClinicaVivaEstetica.Application.Results;
using ClinicaVivaEstetica.WebApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVivaEstetica.WebApi.Controllers.Schedule.Get
{
    [Route("api/[controller]")]
    public class SchedulesController : Controller
    {
        private readonly IGetScheduleService getScheduleService;

        public SchedulesController(IGetScheduleService getScheduleService)
        {
            this.getScheduleService = getScheduleService;
        }
        
        /// <summary>
        /// Obtem um ou vários agendamento(s).
        /// </summary>
        [HttpGet("{id?}")]
        public async Task<IActionResult> Get(Guid? id)
        {
            if (id.HasValue && id != new Guid())
            {
               var result = await getScheduleService.Get(id.Value);
                return Ok(new ApiReturnItem<ScheduleResult> { Item = result, Success = true });
            }
            
            var results = await getScheduleService.GetAll();
            return Ok(new ApiReturnList<ScheduleResult> { Items = results, Success = true });
        }
    }
}
