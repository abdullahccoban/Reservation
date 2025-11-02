using AutoMapper;
using GenericInfra.Core;
using Reservation.Application.DTOs.Requests.Qa;
using Reservation.Application.DTOs.Responses.Qa;
using Reservation.Application.Interfaces;
using Reservation.Domain.Entities;
using Reservation.Infrastructure.Context;
using Reservation.Infrastructure.Interfaces;

namespace Reservation.Application.Services;

public class QaService : IQaService
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IQaRepository _repo;

    public QaService(IUnitOfWork uow, IMapper mapper, IQaRepository repo)
    {
        _uow = uow;
        _mapper = mapper;
        _repo = repo;
    }
    
    public async Task CreateQaAsync(CreateQaRequestDto request)
    {
        var room = new QaDomain(request.HotelId, request.Question, request.QuestionDate, request.Answer, request.AnswerDate);
        await _uow.GetRepository<Qa>().AddAsync(_mapper.Map<Qa>(room));
        await _uow.SaveChangesAsync();
    }

    public async Task UpdateQaAsync(UpdateQaRequestDto request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        
        var existingQa = await _uow.GetRepository<Qa>().GetByIdAsync(request.Id);
        if (existingQa == null) throw new KeyNotFoundException();
        
        var domain = _mapper.Map<QaDomain>(existingQa);
        domain.Update(request.Question, request.QuestionDate, request.Answer, request.AnswerDate);

        _mapper.Map(domain, existingQa);
        _uow.GetRepository<Qa>().Update(existingQa);
        
        await _uow.SaveChangesAsync();
    }

    public async Task RemoveQaAsync(int id)
    {
        var existingQa = await _uow.GetRepository<Qa>().GetByIdAsync(id);
        if (existingQa == null) throw new KeyNotFoundException();
        _uow.GetRepository<Qa>().Delete(existingQa);
        await _uow.SaveChangesAsync();
    }

    public async Task<List<QaDto>> GetAllQasAsync()
    {
        var rooms = await _uow.GetRepository<Qa>().GetAllAsync();
        return _mapper.Map<List<QaDto>>(rooms);
    }

    public async Task<QaDto> GetQaById(int id)
    {
        var existingQa = await _uow.GetRepository<Qa>().GetByIdAsync(id);
        if (existingQa == null) throw new KeyNotFoundException();
        
        return _mapper.Map<QaDto>(existingQa);
    }

    public async Task<List<QaDto>> GetHotelQasAsync(int hotelId)
    {
        var rooms = await _repo.GetHotelQas(hotelId);
        return _mapper.Map<List<QaDto>>(rooms);
    }
}