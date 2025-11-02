using AutoMapper;
using Reservation.Application.DTOs.Responses.Comment;
using Reservation.Application.DTOs.Responses.Tag;
using Reservation.Domain.Entities;
using Reservation.Infrastructure.Context;

namespace Reservation.Application.Mappings;

public class CommentMapping : Profile
{
    public CommentMapping()
    {
        CreateMap<CommentDomain, Comment>()
            .ForMember(dest => dest.Comment1, opt => opt.MapFrom(src => src.Comment))
            .ReverseMap()
            .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment1));
        
        CreateMap<Comment, CommentDto>()
            .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment1));
    }
}