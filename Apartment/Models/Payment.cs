using System;

namespace Apartment.Models;

public partial class Payment
{
    public int Id { get; set; }

    public int ApartmentId { get; set; }

    public double Amount { get; set; }

    public DateTimeOffset Date { get; set; }

    public string? Description { get; set; }

    public virtual Apartment Apartment { get; set; } = null!;
}
