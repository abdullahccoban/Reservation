using System;
using System.Collections.Generic;
using GenericInfra.Core;

namespace Reservation.Infrastructure.Context;

public partial class Room : IEntity
{
    public int Id { get; set; }

    public int HotelId { get; set; }

    public string RoomType { get; set; } = null!;

    public int Capacity { get; set; }

    public int Count { get; set; }

    public virtual Hotel Hotel { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual ICollection<RoomFeature> RoomFeatures { get; set; } = new List<RoomFeature>();

    public virtual ICollection<RoomPrice> RoomPrices { get; set; } = new List<RoomPrice>();
}
