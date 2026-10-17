using System.ComponentModel;

namespace ScuoleItaliane.Models;

public partial class Regione
{
    public int Id { get; set; }

    [DisplayName("Nome Regione")]
    public string Denominazione { get; set; } = null!;

    public int IdRipartizione { get; set; }

    public virtual RipartizioneGeografica IdRipartizioneNavigation { get; set; } = null!;

    public virtual ICollection<Provincia> Provincie { get; set; } = new List<Provincia>();

    [DisplayName("Numero Scuole")]
    public int NumeroScuole { get
        {
            return Provincie.SelectMany(p => p.Comuni).Aggregate(0,(acc, c) => acc + c.Scuole.Count);
        } }
}
