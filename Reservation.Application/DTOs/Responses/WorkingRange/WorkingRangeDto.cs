namespace Reservation.Application.DTOs.Responses.WorkingRange;

public class WorkingRangeDto
{
    public int Id { get; set; }
    public int HotelId { get; set; }
    public int Year { get; set; }
    public DateTime OpeningDate { get; set; }
    public DateTime ClosingDate { get; set; }
}