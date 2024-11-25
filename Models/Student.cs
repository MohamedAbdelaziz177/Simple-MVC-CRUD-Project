using System;
using System.Collections.Generic;

namespace DemoMvc.Models;

public partial class Student
{
    public int StudetId { get; set; }

    public string StdName { get; set; } = null!;

    public int? StdPhone { get; set; }

    public string? StdAddress { get; set; }

    public virtual ICollection<Courseentrollment> Courseentrollments { get; set; } = new List<Courseentrollment>();
}
