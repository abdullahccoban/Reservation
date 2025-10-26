using AutoMapper;
using GenericInfra.Core;
using Reservation.Application.DTOs.Requests.Promotion;
using Reservation.Application.DTOs.Responses.Promotion;
using Reservation.Application.Interfaces;
using Reservation.Domain.Entities;
using Reservation.Infrastructure.Context;
using Reservation.Infrastructure.Interfaces;

namespace Reservation.Application.Services;

public class PromotionService : IPromotionService
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IPromotionRepository _repo;

    public PromotionService(IUnitOfWork uow, IMapper mapper, IPromotionRepository repo)
    {
        _uow = uow;
        _mapper = mapper;
        _repo = repo;
    }
    
    public async Task CreatePromotionAsync(CreatePromotionRequestDto request)
    {
        var room = new PromotionDomain(request.HotelId, request.User);
        await _uow.GetRepository<Promotion>().AddAsync(_mapper.Map<Promotion>(room));
        await _uow.SaveChangesAsync();
    }

    public async Task UpdatePromotionAsync(UpdatePromotionRequestDto request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        
        var existingPromotion = await _uow.GetRepository<Promotion>().GetByIdAsync(request.Id);
        if (existingPromotion == null) throw new KeyNotFoundException();
        
        var domain = _mapper.Map<PromotionDomain>(existingPromotion);
        domain.Update(request.User);

        _mapper.Map(domain, existingPromotion);
        _uow.GetRepository<Promotion>().Update(existingPromotion);
        
        await _uow.SaveChangesAsync();
    }

    public async Task RemovePromotionAsync(int id)
    {
        var existingPromotion = await _uow.GetRepository<Promotion>().GetByIdAsync(id);
        if (existingPromotion == null) throw new KeyNotFoundException();
        _uow.GetRepository<Promotion>().Delete(existingPromotion);
        await _uow.SaveChangesAsync();
    }

    public async Task<List<PromotionDto>> GetAllPromotionsAsync()
    {
        var rooms = await _uow.GetRepository<Promotion>().GetAllAsync();
        return _mapper.Map<List<PromotionDto>>(rooms);
    }

    public async Task<PromotionDto> GetPromotionById(int id)
    {
        var existingPromotion = await _uow.GetRepository<Promotion>().GetByIdAsync(id);
        if (existingPromotion == null) throw new KeyNotFoundException();
        
        return _mapper.Map<PromotionDto>(existingPromotion);
    }

    public async Task<List<PromotionDto>> GetHotelPromotionsAsync(int hotelId)
    {
        var rooms = await _repo.GetHotelPromotions(hotelId);
        return _mapper.Map<List<PromotionDto>>(rooms);
    }
}