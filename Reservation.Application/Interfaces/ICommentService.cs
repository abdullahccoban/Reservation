using Reservation.Application.DTOs.Requests.Comment;
using Reservation.Application.DTOs.Responses.Comment;

namespace Reservation.Application.Interfaces;

public interface ICommentService
{
    Task CreateCommentAsync(CreateCommentRequestDto request);
    Task UpdateCommentAsync(UpdateCommentRequestDto request);
    Task RemoveCommentAsync(int id);
    Task<List<CommentDto>> GetAllCommentsAsync();
    Task<CommentDto> GetCommentById(int id);
    Task<List<CommentDto>> GetHotelCommentsAsync(int hotelId);
}