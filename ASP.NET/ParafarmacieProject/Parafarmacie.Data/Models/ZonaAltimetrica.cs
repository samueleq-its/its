using System;
using System.Collections.Generic;

namespace Parafarmacie.Data.Models;

public partial class ZonaAltimetrica
{
    public int Id { get; set; }

    public string Denominazione { get; set; } = null!;

    public virtual ICollection<Comune> Comunes { get; set; } = new List<Comune>();
}
