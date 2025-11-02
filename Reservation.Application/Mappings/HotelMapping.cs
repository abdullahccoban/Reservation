using AutoMapper;
using Reservation.Application.DTOs.Responses.Hotels;
using Reservation.Domain.Entities;
using Reservation.Infrastructure.Context;

namespace Reservation.Application.Mappings;

public class HotelMapping : Profile
{
    public HotelMapping()
    {
        CreateMap<HotelDomain, Hotel>().ReverseMap();
        CreateMap<Hotel, HotelDto>();
        
        CreateMap<Hotel, HotelDetailDto>()
            .ForMember(dest => dest.AverageScore,
                opt => opt.MapFrom(src => src.Comments.Average(c => (double?)c.Point) ?? 0))
            .ForMember(dest => dest.CommentCount,
                opt => opt.MapFrom(src => src.Comments.Count()));
    }
}