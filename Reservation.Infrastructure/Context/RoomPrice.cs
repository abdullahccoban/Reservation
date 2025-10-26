using System;
using System.Collections.Generic;
using GenericInfra.Core;

namespace Reservation.Infrastructure.Context;

public partial class RoomPrice : IEntity
{
    public int Id { get; set; }

    public int RoomId { get; set; }

    public decimal Price { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public virtual Room Room { get; set; } = null!;
}
