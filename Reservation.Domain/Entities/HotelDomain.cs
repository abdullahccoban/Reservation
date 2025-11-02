namespace Reservation.Domain.Entities;

public class HotelDomain
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int DailyCapacity { get; private set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Phone { get; set; }
    public int StarCount { get; set; }
    
    public HotelDomain(string name, string description, int dailyCapacity, string country, string city, string phone, int starCount, int id = 0)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException();
        if (string.IsNullOrWhiteSpace(description)) throw new ArgumentException();
        if (string.IsNullOrWhiteSpace(country)) throw new ArgumentException();
        if (string.IsNullOrWhiteSpace(city)) throw new ArgumentException();
        if (string.IsNullOrWhiteSpace(phone)) throw new ArgumentException();
        if (starCount <= 0 || starCount > 5) throw new ArgumentException();
        
        Name = name;
        Description = description;
        DailyCapacity = dailyCapacity;
        Country = country;
        City = city;
        Phone = phone;
        StarCount = starCount;
        
        if (id != 0) Id = id;
    }

    public void Update(string? name, string? description, int? dailyCapacity, string? country, string? city, string? phone, int? starCount)
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
        
        if (country is not null)
        {
            if (string.IsNullOrWhiteSpace(country)) 
                throw new ArgumentException("Country cannot be empty when provided.");
            
            Country = country;
        }
        
        if (city is not null)
        {
            if (string.IsNullOrWhiteSpace(city)) 
                throw new ArgumentException("City cannot be empty when provided.");
            
            City = city;
        }
        
        if (phone is not null)
        {
            if (string.IsNullOrWhiteSpace(phone)) 
                throw new ArgumentException("Phone cannot be empty when provided.");
            
            Phone = phone;
        }
        
        if (starCount.HasValue)
        {
            if (starCount.Value <= 0 || starCount.Value > 5) 
                throw new ArgumentException("Star Count must be greater than zero or lower than five.");
            
            StarCount = starCount.Value;
        }
    }
}