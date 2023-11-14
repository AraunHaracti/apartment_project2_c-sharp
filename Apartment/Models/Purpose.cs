namespace Apartment.Models;

public partial class Purpose
{
    public int Id { get; set; }

    public int ProblemId { get; set; }

    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Problem Problem { get; set; } = null!;
}
