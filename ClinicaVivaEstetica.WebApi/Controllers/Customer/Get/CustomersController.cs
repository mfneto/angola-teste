using System;
using System.Threading.Tasks;
using ClinicaVivaEstetica.Application.Commands.Customer.Get;
using ClinicaVivaEstetica.Application.Results;
using ClinicaVivaEstetica.WebApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVivaEstetica.WebApi.Controllers.Customer.Get
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly IGetCustomerService getCustomerService;

        public CustomersController(IGetCustomerService getCustomerService)
        {
            this.getCustomerService = getCustomerService;
        }
        
        /// <summary>
        /// Obtem um ou vários cliente(s).
        /// </summary>
        [HttpGet("{id?}")]
        public async Task<IActionResult> Get(Guid? id)
        {
            if (id.HasValue && id != new Guid())
            {
               var result = await getCustomerService.Get(id.Value);
                return Ok(new ApiReturnItem<CustomerResult> { Item = result, Success = true });
            }
            
            var results = await getCustomerService.GetAll();
            return Ok(new ApiReturnList<CustomerResult> { Items = results, Success = true });
        }
    }
}
