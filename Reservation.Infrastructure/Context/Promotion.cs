using System;
using System.Collections.Generic;
using GenericInfra.Core;

namespace Reservation.Infrastructure.Context;

public partial class Promotion : IEntity
{
    public int Id { get; set; }

    public int HotelId { get; set; }

    public bool IsGeneral { get; set; }

    public string? User { get; set; }

    public virtual Hotel Hotel { get; set; } = null!;
}
