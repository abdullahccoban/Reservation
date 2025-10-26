namespace Reservation.Domain.Entities;

public class RoomDomain
{
    public int Id { get; private set; }
    public int HotelId { get; private set; }
    public string RoomType  { get; private set; }
    public int Capacity { get; private set; }
    public int Count { get; private set; }

    public RoomDomain(int hotelId, string roomType, int capacity, int count, int id = 0)
    {
        if (hotelId <= 0) throw new ArgumentException("HotelId must be greater than zero");
        if (string.IsNullOrEmpty(roomType)) throw new ArgumentNullException();
        if (capacity <= 0) throw new ArgumentNullException("Capacity must be greater than zero");
        if (count <= 0) throw new ArgumentOutOfRangeException("Count must be greater than zero");
        
        if (id != 0) Id = id;
        HotelId = hotelId;
        RoomType = roomType;
        Capacity = capacity;
        Count = count;
    }
    
    public void Update(string? roomType, int? capacity, int? count)
    {
        if (roomType is not null)
        {
            if (string.IsNullOrWhiteSpace(roomType)) 
                throw new ArgumentException("Room type name cannot be empty when provided.");
            
            RoomType = roomType;
        }
        
        if (capacity.HasValue)
        {
            if (capacity.Value <= 0) 
                throw new ArgumentException("Capacity must be greater than zero.");
            
            Capacity = capacity.Value;
        }
        
        if (count.HasValue)
        {
            if (count.Value <= 0) 
                throw new ArgumentException("Count must be greater than zero.");
            
            Count = count.Value;
        }
    }
}