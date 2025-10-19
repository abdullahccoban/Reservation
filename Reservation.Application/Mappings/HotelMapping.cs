using AutoMapper;
using Reservation.Domain.Entities;
using Reservation.Infrastructure.Context;

namespace Reservation.Application.Mappings;

public class HotelMapping : Profile
{
    public HotelMapping()
    {
        CreateMap<HotelDomain, Hotel>().ReverseMap();
    }
}