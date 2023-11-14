namespace Apartment.Models;

public partial class Building
{
    public int Id { get; set; }

    public int ResidentialComplexId { get; set; }

    public string Name { get; set; } = null!;
    
    public virtual ResidentialComplex ResidentialComplex { get; set; } = null!;
}
