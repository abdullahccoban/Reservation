using AutoMapper;
using Reservation.Application.DTOs.Responses.Tag;
using Reservation.Domain.Entities;
using Reservation.Infrastructure.Context;

namespace Reservation.Application.Mappings;

public class TagMapping : Profile
{
    public TagMapping()
    {
        CreateMap<TagDomain, Tag>().ReverseMap();
        CreateMap<Tag, TagDto>();
    }
}