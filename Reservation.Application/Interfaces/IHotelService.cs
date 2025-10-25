using Reservation.Application.DTOs.Requests.Hotel;
using Reservation.Application.DTOs.Responses.Hotels;

namespace Reservation.Application.Interfaces;

public interface IHotelService
{
    Task<List<HotelCardDto>> GetHotelCards();
    Task CreateHotelAsync(CreateHotelRequestDto request);
    Task UpdateHotelAsync(UpdateHotelRequestDto request);
}