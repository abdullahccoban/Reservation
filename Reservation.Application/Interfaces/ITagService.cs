using Reservation.Application.DTOs.Requests.Tag;
using Reservation.Application.DTOs.Responses.Tag;

namespace Reservation.Application.Interfaces;

public interface ITagService
{
    Task CreateTagAsync(CreateTagRequestDto request);
    Task UpdateTagAsync(UpdateTagRequestDto request);
    Task RemoveTagAsync(int id);
    Task<List<TagDto>> GetAllTagsAsync();
    Task<TagDto> GetTagById(int id);
    Task<List<TagDto>> GetHotelTagsAsync(int hotelId);
}