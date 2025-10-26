namespace Reservation.Domain.Entities;

public class RoomFeatureDomain
{
    public int Id { get; private set; }
    public int RoomId { get; private set; }
    public string Feature { get; private set; }

    public RoomFeatureDomain(int roomId, string feature, int id = 0)
    {
        if (roomId <= 0) throw new ArgumentNullException();
        if (string.IsNullOrEmpty(feature)) throw new ArgumentNullException();
        RoomId = roomId;
        Feature = feature;

        if (id != 0) Id = id;
    }

    public void Update(string? feature)
    {
        if (feature is not null)
        {
            if (string.IsNullOrWhiteSpace(feature)) 
                throw new ArgumentException("Feature type name cannot be empty when provided.");
            
            Feature = feature;
        }
    }
}