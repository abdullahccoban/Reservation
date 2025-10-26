namespace Reservation.Domain.Entities;

public class PhotoDomain
{
    public int Id { get; private set; }
    public int HotelId { get; private set; }
    public string PhotoPath { get; private set; }
    public DateTime CreatedAt { get; protected set; }

    public PhotoDomain(int hotelId, string photoPath, DateTime? createdAt = null, int id = 0)
    {
        if (hotelId == 0) throw new ArgumentException("HotelId must be greater than zero");
        if (string.IsNullOrEmpty(photoPath)) throw new ArgumentNullException();
        if (id != 0) Id = id;
        HotelId = hotelId;
        PhotoPath = photoPath;
        
        if (createdAt.HasValue) 
            CreatedAt = createdAt.Value;
        else 
            CreatedAt = DateTime.UtcNow;
    }
    
    public void Update(string? photoPath)
    {
        if (photoPath is not null)
        {
            if (string.IsNullOrWhiteSpace(photoPath)) 
                throw new ArgumentException();
            
            PhotoPath = photoPath;
        }
    }
}