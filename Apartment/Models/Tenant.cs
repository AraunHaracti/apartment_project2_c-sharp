using System;

namespace Apartment.Models;

public partial class Tenant
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public DateTimeOffset Birthday { get; set; }

    public string Email { get; set; } = null!;
}
