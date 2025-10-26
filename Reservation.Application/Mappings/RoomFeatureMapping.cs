using AutoMapper;
using Reservation.Application.DTOs.Responses.RoomFeature;
using Reservation.Domain.Entities;
using Reservation.Infrastructure.Context;

namespace Reservation.Application.Mappings;

public class RoomFeatureMapping : Profile
{
    public RoomFeatureMapping()
    {
        CreateMap<RoomFeatureDomain, RoomFeature>().ReverseMap();
        CreateMap<RoomFeature, RoomFeatureDto>();
    }
}