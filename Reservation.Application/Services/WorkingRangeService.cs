using AutoMapper;
using GenericInfra.Core;
using Reservation.Application.DTOs.Requests.WorkingRange;
using Reservation.Application.DTOs.Responses.WorkingRange;
using Reservation.Application.Interfaces;
using Reservation.Domain.Entities;
using Reservation.Infrastructure.Context;
using Reservation.Infrastructure.Interfaces;

namespace Reservation.Application.Services;

public class WorkingRangeService : IWorkingRangeService
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IWorkingRangeRepository _repo;

    public WorkingRangeService(IUnitOfWork uow, IMapper mapper, IWorkingRangeRepository repo)
    {
        _uow = uow;
        _mapper = mapper;
        _repo = repo;
    }
    
    public async Task CreateWorkingRangeAsync(CreateWorkingRangeRequestDto request)
    {
        var room = new WorkingRangeDomain(request.HotelId, request.Year, request.OpeningDate, request.ClosingDate);
        await _uow.GetRepository<WorkingRange>().AddAsync(_mapper.Map<WorkingRange>(room));
        await _uow.SaveChangesAsync();
    }

    public async Task UpdateWorkingRangeAsync(UpdateWorkingRangeRequestDto request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        
        var existingWorkingRange = await _uow.GetRepository<WorkingRange>().GetByIdAsync(request.Id);
        if (existingWorkingRange == null) throw new KeyNotFoundException();
        
        var domain = _mapper.Map<WorkingRangeDomain>(existingWorkingRange);
        domain.Update(request.Year, request.OpeningDate, request.ClosingDate);

        _mapper.Map(domain, existingWorkingRange);
        _uow.GetRepository<WorkingRange>().Update(existingWorkingRange);
        
        await _uow.SaveChangesAsync();
    }

    public async Task RemoveWorkingRangeAsync(int id)
    {
        var existingWorkingRange = await _uow.GetRepository<WorkingRange>().GetByIdAsync(id);
        if (existingWorkingRange == null) throw new KeyNotFoundException();
        _uow.GetRepository<WorkingRange>().Delete(existingWorkingRange);
        await _uow.SaveChangesAsync();
    }

    public async Task<List<WorkingRangeDto>> GetAllWorkingRangesAsync()
    {
        var rooms = await _uow.GetRepository<WorkingRange>().GetAllAsync();
        return _mapper.Map<List<WorkingRangeDto>>(rooms);
    }

    public async Task<WorkingRangeDto> GetWorkingRangeById(int id)
    {
        var existingWorkingRange = await _uow.GetRepository<WorkingRange>().GetByIdAsync(id);
        if (existingWorkingRange == null) throw new KeyNotFoundException();
        
        return _mapper.Map<WorkingRangeDto>(existingWorkingRange);
    }

    public async Task<List<WorkingRangeDto>> GetHotelWorkingRangesAsync(int hotelId)
    {
        var rooms = await _repo.GetHotelWorkingRanges(hotelId);
        return _mapper.Map<List<WorkingRangeDto>>(rooms);
    }
}