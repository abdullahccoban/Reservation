using System;
using System.Collections.Generic;

namespace Reservation.Infrastructure.Context;

public partial class Promotion
{
    public int Id { get; set; }

    public int HotelId { get; set; }

    public bool IsGeneral { get; set; }

    public string? User { get; set; }

    public virtual Hotel Hotel { get; set; } = null!;
}
