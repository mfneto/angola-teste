using System;
using System.Threading.Tasks;
using ClinicaVivaEstetica.Application.Commands.Service.Get;
using ClinicaVivaEstetica.Application.Results;
using ClinicaVivaEstetica.WebApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVivaEstetica.WebApi.Controllers.Service.Get
{
    [Route("api/[controller]")]
    public class ServicesController : Controller
    {
        private readonly IGetServiceService getServiceService;

        public ServicesController(IGetServiceService getServiceService)
        {
            this.getServiceService = getServiceService;
        }
        
        /// <summary>
        /// Obtem um ou vários serviço(s).
        /// </summary>
        [HttpGet("{id?}")]
        public async Task<IActionResult> Get(Guid? id)
        {
            if (id.HasValue && id != new Guid())
            {
               var result = await getServiceService.Get(id.Value);
                return Ok(new ApiReturnItem<ServiceResult> { Item = result, Success = true });
            }
            
            var results = await getServiceService.GetAll();
            return Ok(new ApiReturnList<ServiceResult> { Items = results, Success = true });
        }
    }
}
