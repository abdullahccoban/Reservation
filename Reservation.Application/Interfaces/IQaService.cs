using Reservation.Application.DTOs.Requests.Qa;
using Reservation.Application.DTOs.Responses.Qa;

namespace Reservation.Application.Interfaces;

public interface IQaService
{
    Task CreateQaAsync(CreateQaRequestDto request);
    Task UpdateQaAsync(UpdateQaRequestDto request);
    Task RemoveQaAsync(int id);
    Task<List<QaDto>> GetAllQasAsync();
    Task<QaDto> GetQaById(int id);
    Task<List<QaDto>> GetHotelQasAsync(int hotelId);
}