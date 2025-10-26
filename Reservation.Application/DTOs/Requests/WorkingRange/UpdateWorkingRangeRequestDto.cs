namespace Reservation.Application.DTOs.Requests.WorkingRange;

public class UpdateWorkingRangeRequestDto
{
    public int Id { get; set; }
    public int HotelId { get; set; }
    public int Year { get; set; }
    public DateTime OpeningDate { get; set; }
    public DateTime ClosingDate { get; set; }
}