using System;

namespace ClinicaVivaEstetica.Application.Commands.Customer.Update
{
    public class UpdateCustomerCommand
    {
        public Guid CustomerId { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Document { get; private set; }
        public string Celphone { get; private set; }
        public string Address { get; private set; }

        public UpdateCustomerCommand(Guid customerId, string name, string lastName, string document, string celphone, string address)
        {
            this.CustomerId = customerId;
            this.Name = name;
            this.LastName = lastName;
            this.Document = document;
            this.Celphone= celphone;
            this.Address = address;
        }
    }
}
