using System;
using System.Collections.Generic;
using GenericInfra.Core;

namespace Reservation.Infrastructure.Context;

public partial class Hotel : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int DailyCapacity { get; set; }
    
    
    public string? Country { get; set; } = null!;
    
    
    public string? City { get; set; } = null!;
    
    
    public string? Phone { get; set; } = null!;
    
    
    public int? StarCount { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

    public virtual ICollection<HotelAdmin> HotelAdmins { get; set; } = new List<HotelAdmin>();

    public virtual ICollection<HotelInformation> HotelInformations { get; set; } = new List<HotelInformation>();

    public virtual ICollection<Photo> Photos { get; set; } = new List<Photo>();

    public virtual ICollection<Promotion> Promotions { get; set; } = new List<Promotion>();

    public virtual ICollection<Qa> Qas { get; set; } = new List<Qa>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();

    public virtual ICollection<WorkingRange> WorkingRanges { get; set; } = new List<WorkingRange>();
}
