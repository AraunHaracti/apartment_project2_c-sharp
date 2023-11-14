using System;

namespace Apartment.Models;

public partial class Disbursement
{
    public int Id { get; set; }

    public int PaymentId { get; set; }

    public int OccupancyId { get; set; }

    public double Amount { get; set; }

    public DateTimeOffset Date { get; set; }

    public virtual Occupancy Occupancy { get; set; } = null!;

    public virtual Payment Payment { get; set; } = null!;
}
