using AutoMapper;
using Reservation.Application.DTOs.Responses.RoomPrice;
using Reservation.Domain.Entities;
using Reservation.Infrastructure.Context;

namespace Reservation.Application.Mappings;

public class RoomPriceMapping : Profile
{
    public RoomPriceMapping()
    {
        CreateMap<RoomPriceDomain, RoomPrice>().ReverseMap();
        CreateMap<RoomPrice, RoomPriceDto>();
    }
}