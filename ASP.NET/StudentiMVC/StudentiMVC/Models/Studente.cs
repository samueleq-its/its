using Microsoft.EntityFrameworkCore;

namespace StudentiMVC.Models
{
    public class Studente
    {
        public int Matricola {get; set;}
        public string Cognome {get; set;}
        public string Nome {get; set;}
        public string Email { get; set; }
        public string Classe { get; set; }

        public override string ToString()
        {
            return $"{{{nameof(Matricola)}={Matricola.ToString()}" +
                $", {nameof(Cognome)}={Cognome}" +
                $", {nameof(Nome)}={Nome}" +
                $", {nameof(Email)}={Email}" +
                $", {nameof(Classe)}={Classe}}}";
        }
    }
}
