using System;
using System.Collections.Generic;

namespace ScuoleItaliane.Models;

public partial class Comune
{
    public string CodiceCatastale { get; set; } = null!;

    public int IdProvincia { get; set; }

    public string Denominazione { get; set; } = null!;

    public bool Capoluogo { get; set; }

    public int AltitudineCentro { get; set; }

    public int IdZonaAltimetrica { get; set; }

    public string IdZonaMontana { get; set; } = null!;

    public bool ComuneLitoraneo { get; set; }

    public double Superficie { get; set; }

    public int Popolazione2001 { get; set; }

    public int Popolazione2011 { get; set; }

    public virtual Provincia IdProvinciaNavigation { get; set; } = null!;

    public virtual ZonaAltimetrica IdZonaAltimetricaNavigation { get; set; } = null!;

    public virtual ZonaMontana IdZonaMontanaNavigation { get; set; } = null!;

    public virtual ICollection<Scuola> Scuole { get; set; } = new List<Scuola>();
}
