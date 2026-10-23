using System;
using System.Collections.Generic;

namespace GAM.Models;

public partial class Autore
{
    public int Id { get; set; }

    public string? Nominativo { get; set; }

    public virtual ICollection<Opera> Opere { get; set; } = new List<Opera>();
}
