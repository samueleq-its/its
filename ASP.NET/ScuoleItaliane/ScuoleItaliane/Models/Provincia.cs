using System;
using System.Collections.Generic;

namespace ScuoleItaliane.Models;

public partial class Provincia
{
    public int Id { get; set; }

    public string Denominazione { get; set; } = null!;

    public string Sigla { get; set; } = null!;

    public int? CodiceCittaMetropolitana { get; set; }

    public int IdRegione { get; set; }

    public virtual ICollection<Comune> Comuni { get; set; } = new List<Comune>();

    public virtual Regione IdRegioneNavigation { get; set; } = null!;
}
