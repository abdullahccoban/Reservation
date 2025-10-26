using AutoMapper;
using Reservation.Application.DTOs.Responses.Photo;
using Reservation.Domain.Entities;
using Reservation.Infrastructure.Context;

namespace Reservation.Application.Mappings;

public class PhotoMapping : Profile
{
    public PhotoMapping()
    {
        CreateMap<PhotoDomain, Photo>().ReverseMap();
        CreateMap<Photo, PhotoDto>();
    }
}