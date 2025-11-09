using Reservation.Application.DTOs.Responses.RoomFeature;
using Reservation.Application.DTOs.Responses.RoomPrice;

namespace Reservation.Application.DTOs.Responses.Room;

public class RoomDto
{
    public int Id { get; set; }
    public int HotelId  { get; set; }
    public required string RoomType { get; set; }
    public int Capacity { get; set; }
    public int Count { get; set; }
    public List<RoomPriceDto>? RoomPrices { get; set; }
    public List<RoomFeatureDto>? RoomFeatures { get; set; }
}