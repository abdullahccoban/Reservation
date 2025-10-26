using Reservation.Application.DTOs.Requests.Photo;
using Reservation.Application.DTOs.Responses.Photo;
using Reservation.Infrastructure.Context;

namespace Reservation.Application.Interfaces;

public interface IPhotoService
{
    Task CreatePhotoAsync(CreatePhotoRequestDto request);
    Task UpdatePhotoAsync(UpdatePhotoRequestDto request);
    Task RemovePhotoAsync(int id);
    Task<List<PhotoDto>> GetAllPhotosAsync();
    Task<PhotoDto> GetPhotoById(int id);
    Task<List<PhotoDto>> GetHotelPhotosAsync(int hotelId);
}