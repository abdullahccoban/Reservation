using System;
using System.Collections.Generic;
using GenericInfra.Core;

namespace Reservation.Infrastructure.Context;

public partial class WorkingRange : IEntity
{
    public int Id { get; set; }

    public int HotelId { get; set; }

    public int Year { get; set; }

    public DateTime OpeningDate { get; set; }

    public DateTime ClosingDate { get; set; }

    public virtual Hotel Hotel { get; set; } = null!;
}
