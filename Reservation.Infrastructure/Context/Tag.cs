using System;
using System.Collections.Generic;
using GenericInfra.Core;

namespace Reservation.Infrastructure.Context;

public partial class Tag : IEntity
{
    public int Id { get; set; }

    public int HotelId { get; set; }

    public string Tag1 { get; set; } = null!;

    public virtual Hotel Hotel { get; set; } = null!;
}
