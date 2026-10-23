using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GAM.Models;

public partial class Opera
{
    [Key]
    public int Id { get; set; }

    public string? Inventario { get; set; }

    public int? IdAutore { get; set; }

    [Column("Ambito_culturale")]
    public string? AmbitoCulturale { get; set; }

    public string? Datazione { get; set; }

    [Column("Titolo_soggetto")]
    public string? TitoloSoggetto { get; set; }

    public string? Immagine { get; set; }

    public string? Lsreferenceby { get; set; }

    [ForeignKey(nameof(IdAutore))]
    public virtual Autore? IdAutoreNavigation { get; set; }

    public virtual ICollection<Materiale> IdMateriali { get; set; } = new List<Materiale>();
}