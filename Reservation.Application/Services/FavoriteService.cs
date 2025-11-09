using AutoMapper;
using GenericInfra.Core;
using Reservation.Application.DTOs.Requests.Favorite;
using Reservation.Application.DTOs.Responses.Favorite;
using Reservation.Application.Interfaces;
using Reservation.Domain.Entities;
using Reservation.Infrastructure.Context;
using Reservation.Infrastructure.Interfaces;

namespace Reservation.Application.Services;

public class FavoriteService : IFavoriteService
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IFavoriteRepository _repo;

    public FavoriteService(IUnitOfWork uow, IMapper mapper, IFavoriteRepository repo)
    {
        _uow = uow;
        _mapper = mapper;
        _repo = repo;
    }
    
    public async Task AddFavoriteAsync(AddFavoriteRequestDto request)
    {
        var favorite = new FavoriteDomain(request.HotelId, request.UserId);
        await _uow.GetRepository<Favorite>().AddAsync(_mapper.Map<Favorite>(favorite));
        await _uow.SaveChangesAsync();
    }

    public async Task RemoveFavoriteAsync(RemoveFavoriteRequestDto request)
    {
        var domain = new FavoriteDomain(request.HotelId, request.UserId);
        await _repo.RemoveFavorite(domain.HotelId, domain.UserId);
    }

    public async Task<List<FavoritesResponseDto>> GetFavoritesAsync(string userId)
    {
        var favorites = await _repo.GetFavorites(userId);
        return _mapper.Map<List<FavoritesResponseDto>>(favorites);
    }
}