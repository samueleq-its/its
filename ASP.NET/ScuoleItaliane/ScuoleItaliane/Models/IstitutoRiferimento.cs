using System;
using System.Collections.Generic;

namespace ScuoleItaliane.Models;

public partial class IstitutoRiferimento
{
    public string CodiceIstituto { get; set; } = null!;

    public string Denominazione { get; set; } = null!;

    public virtual ICollection<Scuola> Scuolas { get; set; } = new List<Scuola>();
}
