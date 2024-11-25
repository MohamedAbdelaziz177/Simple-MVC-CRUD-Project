using System;
using System.Collections.Generic;

namespace DemoMvc.Models;

public partial class Reference
{
    public int RefId { get; set; }

    public string RefName { get; set; } = null!;

    public virtual ICollection<Cousre> Cousres { get; set; } = new List<Cousre>();
}
