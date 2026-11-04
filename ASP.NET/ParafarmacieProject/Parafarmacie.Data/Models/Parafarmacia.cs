using System;
using System.Collections.Generic;

namespace Parafarmacie.Data.Models;

public partial class Parafarmacia
{
    public int Id { get; set; }

    public string? CodiceIdentificativoSito { get; set; }

    public string? SitoLogistico { get; set; }

    public string? Indirizzo { get; set; }

    public string? PartitaIva { get; set; }

    public string? Cap { get; set; }

    //public string? CodiceComune { get; set; }

    public int? IdComune { get; set; }

    //public string? Comune { get; set; }

    //public string? CodiceProvincia { get; set; }

    //public string? SiglaProvincia { get; set; }

    //public string? Provincia { get; set; }

    //public string? CodiceRegione { get; set; }

    //public string? Regione { get; set; }

    public string? DataInizioValidita { get; set; }

    public string? DataFineValidita { get; set; }

    public string? Latitudine { get; set; }

    public string? Longitudine { get; set; }

    public string? Localizzazione { get; set; }
}
