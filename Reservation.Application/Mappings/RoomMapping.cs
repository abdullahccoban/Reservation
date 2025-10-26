using AutoMapper;
using Reservation.Application.DTOs.Responses.Room;
using Reservation.Domain.Entities;
using Reservation.Infrastructure.Context;

namespace Reservation.Application.Mappings;

public class RoomMapping : Profile
{
    public RoomMapping()
    {
        CreateMap<RoomDomain, Room>().ReverseMap();
        CreateMap<Room, RoomDto>();
    }
}