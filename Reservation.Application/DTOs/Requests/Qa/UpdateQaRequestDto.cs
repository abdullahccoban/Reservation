namespace Reservation.Application.DTOs.Requests.Qa;

public class UpdateQaRequestDto
{
    public int Id { get; set; }
    public int HotelId { get; set; }
    public required string Question { get; set; }
    public DateTime QuestionDate { get; set; }
    public required string Answer { get; set; }
    public DateTime AnswerDate { get; set; }
}