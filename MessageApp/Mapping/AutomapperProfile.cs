using AutoMapper;
using MessageApp.DTOs;
using MessageApp.Enetities;

namespace MessageApp.Mapping
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Message, MessageDTO>()
                .ForMember(
                dest => dest.Nombre,
                opt => opt.MapFrom(src => src.Student!.Nombre)
            );

            CreateMap<MessageDTO, Message>();

            CreateMap<StudentDTO, Student>().ReverseMap();
        }
    }
}
