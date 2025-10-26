namespace Reservation.Domain.Entities;

public class PromotionDomain
{
    public int Id { get; private set; }
    public int HotelId  { get; private set; }
    public bool IsGeneral { get; private set; }
    public string User { get; private set; }

    public PromotionDomain(int hotelId, string? user, int id = 0)
    {
        if (hotelId <= 0) throw new ArgumentNullException();
        HotelId = hotelId;

        if (!string.IsNullOrEmpty(user))
        {
            User = user;
            IsGeneral = false;
        }
        else
        {
            IsGeneral = true;
        }
        
        if (id != 0) Id = id;
    }

    public void Update(string? user)
    {
        if (user is not null)
        {
            if (string.IsNullOrWhiteSpace(user)) 
                throw new ArgumentException("User name cannot be empty when provided.");
            
            User = user;
            IsGeneral = false;
        }
        else
        {
            IsGeneral = true;
        }
    }
}