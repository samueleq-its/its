using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrestitiVideotecaWebForm
{
    public partial class Prestiti : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtArchivio_Click(object sender, EventArgs e)
        {
            sdsPrestiti.SelectCommand = "SELECT Prestito.Id, Prestito.IdFilm, Prestito.Matricola, Prestito.DataPrestito, Prestito.DataRestituzione, " +
                "Film.Titolo, Studente.Cognome, Studente.Nome " +
                "FROM Prestito " +
                "INNER JOIN Film ON Prestito.IdFilm = Film.Codice I" +
                "NNER JOIN Studente ON Prestito.Matricola = Studente.Matricola " +
                "WHERE DataRestituzione is not null " +
                "ORDER BY Prestito.DataPrestito DESC";
            sdsPrestiti.DataBind();
        }

        protected void lbtNonRestituiti_Click(object sender, EventArgs e)
        {
            sdsPrestiti.SelectCommand = "SELECT Prestito.Id, Prestito.IdFilm, Prestito.Matricola, Prestito.DataPrestito, Prestito.DataRestituzione, Film.Titolo, Studente.Cognome, Studente.Nome FROM Prestito INNER JOIN Film ON Prestito.IdFilm = Film.Codice INNER JOIN Studente ON Prestito.Matricola = Studente.Matricola where DataRestituzione is null ORDER BY Prestito.DataPrestito DESC";
            sdsPrestiti.DataBind();
        }
    }
}