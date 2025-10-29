using AutoMapper;
using Reservation.Application.DTOs.Responses.HotelAdmin;
using Reservation.Domain.Entities;
using Reservation.Infrastructure.Context;

namespace Reservation.Application.Mappings;

public class HotelAdminMapping : Profile
{
    public HotelAdminMapping()
    {
        CreateMap<HotelAdminDomain, HotelAdmin>().ReverseMap();
        CreateMap<HotelAdmin, HotelAdminDto>();
    }
    
}