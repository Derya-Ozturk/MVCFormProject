using AutoMapper;
using Entities.Dtos;
using Entities.Entities;

namespace Business.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(opt => opt.Username))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(opt => opt.Password))
                .ForMember(dest => dest.Forms, opt => opt.MapFrom(opt => opt.Forms));

            CreateMap<Field, FieldDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(opt => opt.Name))
                .ForMember(dest => dest.Required, opt => opt.MapFrom(opt => opt.Required))
                .ForMember(dest => dest.DataType, opt => opt.MapFrom(opt => opt.DataType))
                .ForMember(dest => dest.Form, opt => opt.MapFrom(opt => opt.Form));

            CreateMap<Form, FormDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(opt => opt.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(opt => opt.Name))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(opt => opt.CreatedAt))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(opt => opt.CreatedBy))
                .ForMember(dest => dest.CreatedByNavigation, opt => opt.MapFrom(opt => opt.CreatedByNavigation))
                .ForMember(dest => dest.Fields, opt => opt.MapFrom(opt => opt.Fields));

        }
    }
}
