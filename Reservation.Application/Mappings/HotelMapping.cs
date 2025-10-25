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
    }
}