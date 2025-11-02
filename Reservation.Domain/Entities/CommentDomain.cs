namespace Reservation.Domain.Entities;

public class CommentDomain
{
    public int Id { get; private set; } 
    public int HotelId  { get; private set; }
    public int Point { get; private set; }
    public string Comment { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public CommentDomain(int hotelId, int point, string comment, DateTime createdAt, int id = 0)
    {
        if (string.IsNullOrEmpty(comment)) throw new ArgumentNullException();
        if (hotelId <= 0) throw new ArgumentOutOfRangeException();
        if (point <= 0 || point > 5) throw new ArgumentOutOfRangeException();
        HotelId = hotelId;
        Point = point;
        Comment = comment;
        CreatedAt = createdAt;
        if (id != 0) Id = id;
    }
    
    public void Update(int? point, string? comment, DateTime? createdAt)
    {
        if (comment is not null)
        {
            if (string.IsNullOrWhiteSpace(comment)) 
                throw new ArgumentException("Comment cannot be empty when provided.");
            
            Comment = comment;
        }
        
        if (point.HasValue)
        {
            if (point.Value <= 0) 
                throw new ArgumentException("Point must be greater than zero.");
            
            Point = point.Value;
        }
        
        if (createdAt.HasValue)
            CreatedAt = createdAt.Value;
    }
}