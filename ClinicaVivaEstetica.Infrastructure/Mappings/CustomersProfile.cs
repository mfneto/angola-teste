using AutoMapper;
using ClinicaVivaEstetica.Application.Results;
using ClinicaVivaEstetica.Domain.Customers;

namespace ClinicaVivaEstetica.Infrastructure.Mappings
{
    public class CustomersProfile : Profile
    {
        public CustomersProfile()
        {
            CreateMap<Customer, CustomerResult>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Text))
                .ForMember(dest => dest.Celphone, opt => opt.MapFrom(src => src.Celphone.Text))
                .ForMember(dest => dest.Document, opt => opt.MapFrom(src => src.Document.Text))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));
        }
    }
}
