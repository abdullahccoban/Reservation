using AutoMapper;
using Reservation.Application.DTOs.Responses.Comment;
using Reservation.Application.DTOs.Responses.Qa;
using Reservation.Application.DTOs.Responses.Tag;
using Reservation.Domain.Entities;
using Reservation.Infrastructure.Context;

namespace Reservation.Application.Mappings;

public class QaMapping : Profile
{
    public QaMapping()
    {
        CreateMap<QaDomain, Qa>()
            .ReverseMap();

        CreateMap<Qa, QaDto>();
    }
}