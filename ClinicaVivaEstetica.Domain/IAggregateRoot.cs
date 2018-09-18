namespace ClinicaVivaEstetica.Domain
{
    public interface IAggregateRoot : IEntity
    {
        int Version { get; }
    }
}