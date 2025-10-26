namespace Reservation.Domain.Entities;

public class HotelInformationDomain
{
    public int Id { get; private set; }
    public int HotelId { get; private set; }
    public string Description { get; private set; }

    public HotelInformationDomain(int hotelId, string description, int id = 0)
    {
        if (hotelId == 0) throw new ArgumentException("HotelId must be greater than zero");
        if (string.IsNullOrEmpty(description)) throw new ArgumentException("Description must be greater than zero");
        
        HotelId = hotelId;
        Description = description;
        
        if (id != 0) Id = id;
    }
    
    public void Update(string? description)
    {
        if (description is not null)
        {
            if (string.IsNullOrWhiteSpace(description)) 
                throw new ArgumentException("Description cannot be empty when provided.");
            
            Description = description;
        }
    }
}