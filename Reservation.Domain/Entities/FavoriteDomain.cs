namespace Reservation.Domain.Entities;

public class FavoriteDomain
{
    public int Id { get; private set; } 
    public int HotelId  { get; private set; }
    public string UserId { get; private set; }

    public FavoriteDomain(int hotelId, string userId, int id = 0)
    {
        if (string.IsNullOrEmpty(userId)) throw new ArgumentNullException();
        if (hotelId <= 0) throw new ArgumentOutOfRangeException();
        HotelId = hotelId;
        UserId = userId;
        if (id != 0) Id = id;
    }
}