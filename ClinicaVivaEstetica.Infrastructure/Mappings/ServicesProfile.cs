using AutoMapper;
using ClinicaVivaEstetica.Application.Results;
using ClinicaVivaEstetica.Domain.Service;

namespace ClinicaVivaEstetica.Infrastructure.Mappings
{
    public class ServicesProfile : Profile
    {
        public ServicesProfile()
        {
            CreateMap<Service, ServiceResult>()
                .ForMember(dest => dest.ServiceId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Text))
                .ForMember(dest => dest.AllowHalfTime, opt => opt.MapFrom(src => src.AllowHalfTime));
        }
    }
}