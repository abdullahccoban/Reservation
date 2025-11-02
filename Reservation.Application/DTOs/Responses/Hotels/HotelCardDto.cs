namespace Reservation.Application.DTOs.Responses.Hotels;

public class HotelCardDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double AverageScore  { get; set; }
    public int CommentCount  { get; set; }
    public decimal MinPrice  { get; set; }
    public string? FirstPhotoPath  { get; set; }
    public int StarCount { get; set; }
}