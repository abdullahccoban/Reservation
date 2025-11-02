using Reservation.Application.DTOs.Responses.HotelInformation;
using Reservation.Application.DTOs.Responses.Photo;
using Reservation.Application.DTOs.Responses.Room;
using Reservation.Application.DTOs.Responses.Tag;

namespace Reservation.Application.DTOs.Responses.Hotels;

public class HotelDetailDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int StarCount { get; set; }
    public List<PhotoDto>? Photos { get; set; }
    public List<HotelInformationDto>? HotelInfos { get; set; }
    public List<TagDto>? Tags { get; set; }
    public List<RoomDto>? Rooms { get; set; }
    public double AverageScore  { get; set; }
    public int CommentCount  { get; set; }
}