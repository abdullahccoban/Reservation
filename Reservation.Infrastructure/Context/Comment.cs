using System;
using System.Collections.Generic;
using GenericInfra.Core;

namespace Reservation.Infrastructure.Context;

public partial class Comment : IEntity
{
    public int Id { get; set; }

    public int HotelId { get; set; }

    public int Point { get; set; }

    public string Comment1 { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual Hotel Hotel { get; set; } = null!;
}
