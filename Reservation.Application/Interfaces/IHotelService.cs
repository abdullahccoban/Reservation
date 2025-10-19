using Reservation.Application.DTOs.Requests.Hotel;

namespace Reservation.Application.Interfaces;

public interface IHotelService
{
    Task CreateHotelAsync(CreateHotelRequestDto request);
    Task UpdateHotelAsync(UpdateHotelRequestDto request);
}