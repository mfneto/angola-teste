namespace ClinicaVivaEstetica.Domain
{
    public class DomainException : ClinicaVivaEsteticaException
    {
        public string BusinessMessage { get; private set; }

        public DomainException(string businessMessage)
        {
            BusinessMessage = businessMessage;
        }
    }
}
