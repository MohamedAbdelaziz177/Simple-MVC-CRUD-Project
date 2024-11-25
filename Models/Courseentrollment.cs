using System;
using System.Collections.Generic;

namespace DemoMvc.Models;

public partial class Courseentrollment
{
    public int CousreCourseId { get; set; }

    public int StudentStudetId { get; set; }

    public int? Degree { get; set; }

    public virtual Cousre CousreCourse { get; set; } = null!;

    public virtual Student StudentStudet { get; set; } = null!;
}
