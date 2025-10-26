using AutoMapper;
using Reservation.Application.DTOs.Responses.HotelInformation;
using Reservation.Domain.Entities;
using Reservation.Infrastructure.Context;

namespace Reservation.Application.Mappings;

public class HotelInformationMapping : Profile
{
    public HotelInformationMapping()
    {
        CreateMap<HotelInformationDomain, HotelInformation>().ReverseMap();
        CreateMap<HotelInformation, HotelInformationDto>();
    }
    
}