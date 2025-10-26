namespace Reservation.Domain.Entities;

public class WorkingRangeDomain
{
    public int Id { get; private set; }
    public int HotelId { get; private set; }
    public int Year { get; private set; }
    public DateTime OpeningDate { get; private set; }
    public DateTime ClosingDate { get; private set; }

    public WorkingRangeDomain(int hotelId, int year, DateTime openingDate, DateTime closingDate, int id = 0)
    {
        if (hotelId <= 0) throw new ArgumentNullException();
        if (year <= 0) throw new ArgumentNullException();
        HotelId = hotelId;
        Year = year;
        OpeningDate = openingDate;
        ClosingDate = closingDate;
        if (id != 0) Id = id;
    }

    public void Update(int? year, DateTime? openingDate, DateTime? closingDate)
    {
        if (year.HasValue)
        {
            if (year.Value <= 0) 
                throw new ArgumentException("Year must be greater than zero.");
            
            year = year.Value;
        }
        
        if (openingDate.HasValue)
            OpeningDate = openingDate.Value;
        
        if (closingDate.HasValue)
            ClosingDate = closingDate.Value;
    }
}