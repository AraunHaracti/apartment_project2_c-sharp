using System;

namespace Apartment.Models;

public partial class Occupancy
{
    public int Id { get; set; }

    public int TenantId { get; set; }

    public int ApartmentId { get; set; }

    public DateTimeOffset? DateBegin { get; set; }

    public DateTimeOffset? DateEnd { get; set; }

    public virtual Apartment Apartment { get; set; } = null!;
    
    public virtual Tenant Tenant { get; set; } = null!;
}
