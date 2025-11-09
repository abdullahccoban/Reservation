using System;
using System.Collections.Generic;
using GenericInfra.Core;

namespace Reservation.Infrastructure.Context;

public partial class Qa : IEntity
{
    public int Id { get; set; }

    public int HotelId { get; set; }

    public string Question { get; set; } = null!;

    public DateTime QuestionDate { get; set; }

    public string? Answer { get; set; } = null!;

    public DateTime? AnswerDate { get; set; }

    public virtual Hotel Hotel { get; set; } = null!;
}
