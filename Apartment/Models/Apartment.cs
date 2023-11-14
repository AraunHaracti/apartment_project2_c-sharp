namespace Apartment.Models;

public partial class Apartment
{
    public int Id { get; set; }

    public int BuildingId { get; set; }

    public string Name { get; set; } = null!;

    public virtual Building Building { get; set; } = null!;
}
