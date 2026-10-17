using System;
using System.Collections.Generic;

namespace ScuoleItaliane.Models;

public partial class CaratteristicaScuola
{
    public int Id { get; set; }

    public string Denominazione { get; set; } = null!;

    public virtual ICollection<Scuola> Scuolas { get; set; } = new List<Scuola>();
}
