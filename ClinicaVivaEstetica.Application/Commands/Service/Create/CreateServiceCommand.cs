namespace ClinicaVivaEstetica.Application.Commands.Service.Create
{
    public class CreateServiceCommand
    {
        public string Name { get; private set; }
        public bool AllowHalfTime { get; private set; }
        
        public CreateServiceCommand(string name, bool allowHalfTime)
        {
            this.Name = name;
            this.AllowHalfTime = allowHalfTime;
        }
    }
}
