namespace Reservation.Domain.Entities;

public class HotelDomain
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int DailyCapacity { get; private set; }
    
    public HotelDomain(string name, string description, int dailyCapacity, int id = 0)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException();
        if (string.IsNullOrWhiteSpace(description)) throw new ArgumentException();
        
        Name = name;
        Description = description;
        DailyCapacity = dailyCapacity;
        
        if (id != 0) Id = id;
    }

    public void Update(string? name, string? description, int? dailyCapacity)
    {
        if (name is not null)
        {
            if (string.IsNullOrWhiteSpace(name)) 
                throw new ArgumentException("Hotel name cannot be empty when provided.");
            
            Name = name;
        }
        
        if (description is not null)
        {
            if (string.IsNullOrWhiteSpace(description)) 
                throw new ArgumentException("Description cannot be empty when provided.");
            
            Description = description;
        }
        
        if (dailyCapacity.HasValue)
        {
            if (dailyCapacity.Value <= 0) 
                throw new ArgumentException("Daily capacity must be greater than zero.");
            
            DailyCapacity = dailyCapacity.Value;
        }
    }
}