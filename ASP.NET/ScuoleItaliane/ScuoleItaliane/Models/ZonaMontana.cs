using System;
using System.Collections.Generic;

namespace ScuoleItaliane.Models;

public partial class ZonaMontana
{
    public string Id { get; set; } = null!;

    public string Denominazione { get; set; } = null!;

    public virtual ICollection<Comune> Comunes { get; set; } = new List<Comune>();
}
