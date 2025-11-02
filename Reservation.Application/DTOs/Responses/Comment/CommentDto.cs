namespace Reservation.Application.DTOs.Responses.Comment;

public class CommentDto
{
    public int Id { get; set; }
    public int HotelId { get; set; }
    public int Point { get; set; }
    public required string Comment { get; set; }
    public DateTime CreatedAt { get; set; }
}