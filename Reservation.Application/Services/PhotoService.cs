using AutoMapper;
using GenericInfra.Core;
using Reservation.Application.DTOs.Requests.Photo;
using Reservation.Application.DTOs.Responses.Photo;
using Reservation.Application.Interfaces;
using Reservation.Domain.Entities;
using Reservation.Infrastructure.Context;
using Reservation.Infrastructure.Interfaces;

namespace Reservation.Application.Services;

public class PhotoService : IPhotoService
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IPhotoRepository _repo;

    public PhotoService(IUnitOfWork uow, IMapper mapper, IPhotoRepository repo)
    {
        _uow = uow;
        _mapper = mapper;
        _repo = repo;
    }
    
    public async Task CreatePhotoAsync(CreatePhotoRequestDto request)
    {
        var photo = new PhotoDomain(request.HotelId, request.PhotoPath);
        await _uow.GetRepository<Photo>().AddAsync(_mapper.Map<Photo>(photo));
        await _uow.SaveChangesAsync();
    }

    public async Task UpdatePhotoAsync(UpdatePhotoRequestDto request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        
        var existingPhoto = await _uow.GetRepository<Photo>().GetByIdAsync(request.Id);
        if (existingPhoto == null) throw new KeyNotFoundException();
        
        var domain = _mapper.Map<PhotoDomain>(existingPhoto);
        domain.Update(request.PhotoPath);

        _mapper.Map(domain, existingPhoto);
        _uow.GetRepository<Photo>().Update(existingPhoto);
        
        await _uow.SaveChangesAsync();
    }

    public async Task RemovePhotoAsync(int id)
    {
        var existingPhoto = await _uow.GetRepository<Photo>().GetByIdAsync(id);
        if (existingPhoto == null) throw new KeyNotFoundException();
        _uow.GetRepository<Photo>().Delete(existingPhoto);
        await _uow.SaveChangesAsync();
    }

    public async Task<List<PhotoDto>> GetAllPhotosAsync()
    {
        var photos = await _uow.GetRepository<Photo>().GetAllAsync();
        return _mapper.Map<List<PhotoDto>>(photos);
    }

    public async Task<PhotoDto> GetPhotoById(int id)
    {
        var existingPhoto = await _uow.GetRepository<Photo>().GetByIdAsync(id);
        if (existingPhoto == null) throw new KeyNotFoundException();
        
        return _mapper.Map<PhotoDto>(existingPhoto);
    }

    public async Task<List<PhotoDto>> GetHotelPhotosAsync(int hotelId)
    {
        var photos = await _repo.GetHotelPhotos(hotelId);
        return _mapper.Map<List<PhotoDto>>(photos);
    }
}