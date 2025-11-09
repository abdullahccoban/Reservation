using AutoMapper;
using Reservation.Application.DTOs.Responses.Comment;
using Reservation.Application.DTOs.Responses.Favorite;
using Reservation.Application.DTOs.Responses.Qa;
using Reservation.Application.DTOs.Responses.Tag;
using Reservation.Domain.Entities;
using Reservation.Infrastructure.Context;

namespace Reservation.Application.Mappings;

public class FavoriteMapping : Profile
{
    public FavoriteMapping()
    {
        CreateMap<FavoriteDomain, Favorite>()
            .ReverseMap();

        CreateMap<Favorite, FavoritesResponseDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Hotel.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Hotel.Description))
            .ForMember(dest => dest.StarCount, opt => opt.MapFrom(src => src.Hotel.StarCount));
    }
}