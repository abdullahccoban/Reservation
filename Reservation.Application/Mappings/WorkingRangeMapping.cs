using AutoMapper;
using Reservation.Application.DTOs.Responses.WorkingRange;
using Reservation.Domain.Entities;
using Reservation.Infrastructure.Context;

namespace Reservation.Application.Mappings;

public class WorkingRangeMapping : Profile
{
    public WorkingRangeMapping()
    {
        CreateMap<WorkingRangeDomain, WorkingRange>().ReverseMap();
        CreateMap<WorkingRange, WorkingRangeDto>();
    }
}