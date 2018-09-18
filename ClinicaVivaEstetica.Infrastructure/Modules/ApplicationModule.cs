namespace ClinicaVivaEstetica.Infrastructure.Modules
{
    using Autofac;
    using ClinicaVivaEstetica.Application;

    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in ClinicaVivaEstetica.Application
            //
            builder.RegisterAssemblyTypes(typeof(IResultConverter).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
