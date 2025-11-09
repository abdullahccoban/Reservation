namespace Reservation.Application.DTOs.Requests.Qa;

public class CreateQaRequestDto
{
    public int HotelId { get; set; }
    public required string Question { get; set; }
    public DateTime QuestionDate { get; set; }
    public string? Answer { get; set; }
    public DateTime? AnswerDate { get; set; }
    
}