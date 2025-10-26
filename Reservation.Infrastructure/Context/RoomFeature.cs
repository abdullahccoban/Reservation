using System;
using System.Collections.Generic;
using GenericInfra.Core;

namespace Reservation.Infrastructure.Context;

public partial class RoomFeature : IEntity
{
    public int Id { get; set; }

    public int RoomId { get; set; }

    public string Feature { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;
}
