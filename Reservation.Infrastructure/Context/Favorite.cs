using System;
using System.Collections.Generic;
using GenericInfra.Core;

namespace Reservation.Infrastructure.Context;

public partial class Favorite : IEntity
{
    public int Id { get; set; }

    public int HotelId { get; set; }

    public string UserId { get; set; } = null!;

    public virtual Hotel Hotel { get; set; } = null!;
}
