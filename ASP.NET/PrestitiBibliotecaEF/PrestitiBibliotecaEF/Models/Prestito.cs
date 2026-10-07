using System.ComponentModel;

namespace PrestitiBibliotecaEF.Models;

public partial class Prestito
{
    public int Id { get; set; }

    public int IdLibro { get; set; }

    public int Matricola { get; set; }

    [DisplayName("Data Prestito")]
    public DateTime DataPrestito { get; set; }

    [DisplayName("Data Restituzione")]
    public DateTime? DataRestituzione { get; set; }

    [DisplayName("Libro")]
    public virtual Libro IdLibroNavigation { get; set; } = null!;

    [DisplayName("Studente")]
    public virtual Studente MatricolaNavigation { get; set; } = null!;
}
