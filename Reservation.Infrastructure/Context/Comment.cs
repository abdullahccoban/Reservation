using System;
using System.Collections.Generic;

namespace Reservation.Infrastructure.Context;

public partial class Comment
{
    public int Id { get; set; }

    public int HotelId { get; set; }

    public int Point { get; set; }

    public string Comment1 { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual Hotel Hotel { get; set; } = null!;
}
