using System;
using System.Collections.Generic;

namespace DemoMvc.Models;

public partial class Instructor
{
    public int InstructorId { get; set; }

    public string InstName { get; set; } = null!;

    public string? InstPhone { get; set; }

    public string? InstAddress { get; set; }

    public virtual ICollection<Cousre> Cousres { get; set; } = new List<Cousre>();
}
