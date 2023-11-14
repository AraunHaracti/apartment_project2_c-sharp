using System;

namespace Apartment.Models;

public partial class Problem
{
    public int Id { get; set; }

    public string Place { get; set; } = null!;

    public DateTimeOffset DateAdded { get; set; }

    public DateTimeOffset? DateCompleted { get; set; }

    public string Description { get; set; } = null!;

    public string ProblemPriority { get; set; } = null!;

    public string ProblemStatus { get; set; } = null!;
}
