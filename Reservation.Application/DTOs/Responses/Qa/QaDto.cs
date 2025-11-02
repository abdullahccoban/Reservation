namespace Reservation.Application.DTOs.Responses.Qa;

public class QaDto
{
    public int Id { get; set; }
    public int HotelId { get; set; }
    public required string Question { get; set; }
    public DateTime QuestionDate { get; set; }
    public required string Answer { get; set; }
    public DateTime AnswerDate { get; set; }
}