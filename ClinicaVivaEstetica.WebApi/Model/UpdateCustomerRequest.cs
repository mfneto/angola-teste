using System;

namespace ClinicaVivaEstetica.WebApi.Model
{
    public class UpdateCustomerRequest
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Celphone { get; set; }
        public string Address { get; set; }
    }
}