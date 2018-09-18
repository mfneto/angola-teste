namespace ClinicaVivaEstetica.Application.Results
{
    using System;
    using System.Collections.Generic;

    public class CustomerResult
    {
        public Guid CustomerId { get; set; }
        public string Celphone { get; set; }
        public string Document { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public CustomerResult()
        {

        }

        public CustomerResult(Guid customerId, string name, string lastName, string document, string celphone, string address)
        {
            CustomerId = customerId;
            Name = name;
            LastName = lastName;
            Document = document;
            Celphone = celphone;
            Address = address;
        }
    }
}
