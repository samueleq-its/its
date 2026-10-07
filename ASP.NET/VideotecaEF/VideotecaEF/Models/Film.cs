using System;
using System.Collections.Generic;

namespace VideotecaEF.Models;

public partial class Film
{
    public int Codice { get; set; }

    public string? Titolo { get; set; }

    public string? Supporto { get; set; }

    public string? Regista { get; set; }

    public string? Attori { get; set; }

    public string? Genere { get; set; }

    public virtual ICollection<Prestito> Prestiti { get; set; } = new List<Prestito>();
}
