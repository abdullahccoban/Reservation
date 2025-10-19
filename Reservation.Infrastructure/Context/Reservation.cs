using System;
using System.Collections.Generic;

namespace Reservation.Infrastructure.Context;

public partial class Reservation
{
    public int Id { get; set; }

    public int HotelId { get; set; }

    public int RoomId { get; set; }

    public string User { get; set; } = null!;

    public int PersonCount { get; set; }

    public DateTime CheckIn { get; set; }

    public DateTime CheckOut { get; set; }

    public DateTime ReservationDate { get; set; }

    public string? SpecialRequest { get; set; }

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual Hotel Hotel { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;
}
