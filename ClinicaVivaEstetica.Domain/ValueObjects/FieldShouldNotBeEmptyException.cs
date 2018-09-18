namespace ClinicaVivaEstetica.Domain.ValueObjects
{
    public class FieldShouldNotBeEmptyException : DomainException
    {
        internal FieldShouldNotBeEmptyException(string message)
            : base(message)
        { }
    }
}
