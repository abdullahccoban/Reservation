using Reservation.Application.DTOs.Requests.Hotel;
using Reservation.Application.DTOs.Requests.HotelAdmin;
using Reservation.Application.DTOs.Responses.HotelAdmin;
using Reservation.Application.DTOs.Responses.Hotels;

namespace Reservation.Application.Interfaces;

public interface IHotelAdminService
{
    Task CreateHotelAdminAsync(CreateHotelAdminRequestDto request);
    Task UpdateHotelAdminAsync(UpdateHotelAdminRequestDto request);
    Task RemoveHotelAdminAsync(int id);
    Task<List<HotelAdminDto>> GetAllHotelAdminsAsync();
    Task<HotelAdminDto> GetHotelAdminByIdAsync(int id);
    Task<List<HotelAdminDto>> GetHotelAdminsAsync(int hotelId);
    Task<List<HotelAdminDto>> GetHotelAdminsAsync(string userEmail);
}