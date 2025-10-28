using AutoMapper;
using Reservation.Application.DTOs.Responses.Tag;
using Reservation.Domain.Entities;
using Reservation.Infrastructure.Context;

namespace Reservation.Application.Mappings;

public class TagMapping : Profile
{
    public TagMapping()
    {
        CreateMap<TagDomain, Tag>()
            .ForMember(dest => dest.Tag1, opt => opt.MapFrom(src => src.Tag))
            .ReverseMap()
            .ForMember(dest => dest.Tag, opt => opt.MapFrom(src => src.Tag1));
        
        CreateMap<Tag, TagDto>()
            .ForMember(dest => dest.Tag, opt => opt.MapFrom(src => src.Tag1));
    }
}