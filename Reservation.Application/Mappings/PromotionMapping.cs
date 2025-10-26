using AutoMapper;
using Reservation.Application.DTOs.Responses.Promotion;
using Reservation.Domain.Entities;
using Reservation.Infrastructure.Context;

namespace Reservation.Application.Mappings;

public class PromotionMapping : Profile
{
    public PromotionMapping()
    {
        CreateMap<PromotionDomain, Promotion>().ReverseMap();
        CreateMap<Promotion, PromotionDto>();
    }
}