using AutoMapper;
using ClinicaVivaEstetica.Application.Results;
using ClinicaVivaEstetica.Domain.Schedule;

namespace ClinicaVivaEstetica.Infrastructure.Mappings
{
    public class SchedulesProfile : Profile
    {
        public SchedulesProfile()
        {
            CreateMap<Schedule, ScheduleResult>()
                .ForMember(dest => dest.ScheduleId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Day, opt => opt.MapFrom(src => src.Day))
                .ForMember(dest => dest.Hour, opt => opt.MapFrom(src => src.Hour))
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
                .ForMember(dest => dest.Service, opt => opt.MapFrom(src => src.Service));
        }
    }
}