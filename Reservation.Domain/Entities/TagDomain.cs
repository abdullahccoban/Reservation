namespace Reservation.Domain.Entities;

public class TagDomain
{
    public int Id { get; private set; } 
    public int HotelId  { get; private set; }
    public string Tag { get; private set; }

    protected TagDomain() { }
    
    public TagDomain(int hotelId, string tag, int id = 0)
    {
        if (string.IsNullOrEmpty(tag)) throw new ArgumentNullException();
        if (hotelId <= 0) throw new ArgumentNullException();
        if (id != 0) Id = id;
        HotelId = hotelId;
        Tag = tag;
    }

    public void Update(string? tag)
    {
        if (tag is not null)
        {
            if (string.IsNullOrWhiteSpace(tag)) 
                throw new ArgumentException("Tag type name cannot be empty when provided.");
            
            Tag = tag;
        }
    }
}