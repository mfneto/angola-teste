namespace ClinicaVivaEstetica.Infrastructure.Mappings
{
    using ClinicaVivaEstetica.Application;
    using AutoMapper;

    public class ResultConverter : IResultConverter
    {
        private readonly IMapper mapper;

        public ResultConverter()
        {
            mapper = new MapperConfiguration(cfg => {
                cfg.AddProfile<CustomersProfile>();
                cfg.AddProfile<ServicesProfile>();
                cfg.AddProfile<SchedulesProfile>();
            }).CreateMapper();
        }

        public T Map<T>(object source)
        {
            T model = mapper.Map<T>(source);
            return model;
        }
    }
}
