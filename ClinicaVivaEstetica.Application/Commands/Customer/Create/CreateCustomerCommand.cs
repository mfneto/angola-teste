namespace ClinicaVivaEstetica.Application.Commands.Customer.Create
{
    public class CreateCustomerCommand
    {
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Document { get; private set; }
        public string Celphone { get; private set; }
        public string Address { get; private set; }

        public CreateCustomerCommand(string name, string lastName, string document, string celphone, string address)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Document = document;
            this.Celphone= celphone;
            this.Address = address;
        }
    }
}
