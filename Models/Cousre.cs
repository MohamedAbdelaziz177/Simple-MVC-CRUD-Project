using System;
using System.Collections.Generic;

namespace DemoMvc.Models;

public partial class Cousre
{
    public int CourseId { get; set; }

    public string CrsName { get; set; } = null!;

    public string? CrsCategory { get; set; }

    public decimal? Hours { get; set; }

    public int FullMark { get; set; }

    public int InstructorId { get; set; }

    public int ReferenceRefId { get; set; }

    public virtual ICollection<Courseentrollment> Courseentrollments { get; set; } = new List<Courseentrollment>();

    public virtual Instructor Instructor { get; set; } = null!;

    public virtual Reference ReferenceRef { get; set; } = null!;
}
