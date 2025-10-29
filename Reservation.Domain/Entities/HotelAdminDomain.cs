namespace Reservation.Domain.Entities;

public class HotelAdminDomain
{
    public int Id { get; private set; }
    public int HotelId { get; private set; }
    public string UserEmail { get; private set; }

    public HotelAdminDomain(int hotelId, string userEmail, int id = 0)
    {
        if (hotelId <= 0) throw new ArgumentOutOfRangeException();
        if (string.IsNullOrEmpty(userEmail)) throw new ArgumentNullException();
        if (id != 0) Id = id;
        UserEmail = userEmail;
        HotelId = hotelId;
    }
    
    public void Update(string? userEmail)
    {
        if (userEmail is not null)
        {
            if (string.IsNullOrWhiteSpace(userEmail)) 
                throw new ArgumentException("Email cannot be empty when provided.");
            
            UserEmail = userEmail;
        }
    }
}