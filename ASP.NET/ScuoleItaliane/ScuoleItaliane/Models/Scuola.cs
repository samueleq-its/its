using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ScuoleItaliane.Models;

public partial class Scuola
{
    public string CodiceScuola { get; set; } = null!;

    [DisplayName("Nome Scuola")]
    public string Denominazione { get; set; } = null!;

    [DisplayName("Sede Direttiva")]
    public bool SedeDirettiva { get; set; }

    public string? Indirizzo { get; set; }

    public string? Cap { get; set; }

    public string? Email { get; set; }

    public string? Pec { get; set; }

    [DisplayName("Sito Web")]
    public string? SitoWeb { get; set; }

    [DisplayName("Istituto OmniComprensivo")]
    public string? IstitutoOmniComprensivo { get; set; }

    public string IdIstitutoRiferimento { get; set; } = null!;

    public string IdComune { get; set; } = null!;

    public int IdCaratteristicaScuola { get; set; }

    public int IdTipologiaScuola { get; set; }

    public virtual CaratteristicaScuola IdCaratteristicaScuolaNavigation { get; set; } = null!;

    [DisplayName("Comune")]
    public virtual Comune IdComuneNavigation { get; set; } = null!;

    public virtual IstitutoRiferimento IdIstitutoRiferimentoNavigation { get; set; } = null!;

    [DisplayName("Tipologia Scuola")]
    public virtual TipologiaScuola IdTipologiaScuolaNavigation { get; set; } = null!;
}
