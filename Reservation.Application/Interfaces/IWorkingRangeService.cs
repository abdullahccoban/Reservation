using Reservation.Application.DTOs.Requests.WorkingRange;
using Reservation.Application.DTOs.Responses.WorkingRange;

namespace Reservation.Application.Interfaces;

public interface IWorkingRangeService
{
    Task CreateWorkingRangeAsync(CreateWorkingRangeRequestDto request);
    Task UpdateWorkingRangeAsync(UpdateWorkingRangeRequestDto request);
    Task RemoveWorkingRangeAsync(int id);
    Task<List<WorkingRangeDto>> GetAllWorkingRangesAsync();
    Task<WorkingRangeDto> GetWorkingRangeById(int id);
    Task<List<WorkingRangeDto>> GetHotelWorkingRangesAsync(int hotelId);
}