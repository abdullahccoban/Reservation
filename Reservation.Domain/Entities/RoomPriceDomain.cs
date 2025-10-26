namespace Reservation.Domain.Entities;

public class RoomPriceDomain
{
    public int Id { get; private set; }
    public int RoomId { get; private set; }
    public decimal Price { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }

    public RoomPriceDomain(int roomId, decimal price, DateTime startDate, DateTime endDate, int id = 0)
    {
        if (roomId <= 0) throw new ArgumentNullException();
        if (price <= 0) throw new ArgumentNullException();
        if (id != 0) Id = id;
        RoomId = roomId;
        Price = price;
        StartDate = startDate;
        EndDate = endDate;
    }

    public void Update(decimal? price, DateTime? startDate, DateTime? endDate)
    {
        if (price.HasValue)
        {
            if (price.Value <= 0) 
                throw new ArgumentException("Price must be greater than zero.");
            
            Price = price.Value;
        }
        
        if (startDate.HasValue)
            StartDate = startDate.Value;
        
        if (endDate.HasValue)
            EndDate = endDate.Value;
    }
}