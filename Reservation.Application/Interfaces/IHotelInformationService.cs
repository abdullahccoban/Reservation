using Reservation.Application.DTOs.Requests.Hotel;
using Reservation.Application.DTOs.Requests.HotelInformation;
using Reservation.Application.DTOs.Responses.HotelInformation;
using Reservation.Application.DTOs.Responses.Hotels;

namespace Reservation.Application.Interfaces;

public interface IHotelInformationService
{
    Task CreateHotelInformationAsync(CreateHotelInformationRequestDto request);
    Task UpdateHotelInformationAsync(UpdateHotelInformationRequestDto request);
    Task RemoveHotelInformationAsync(int id);
    Task<List<HotelInformationDto>> GetAllHotelInformationsAsync();
    Task<HotelInformationDto> GetHotelInformationByIdAsync(int id);
    Task<List<HotelInformationDto>> GetHotelInformationsAsync(int hotelId);
}