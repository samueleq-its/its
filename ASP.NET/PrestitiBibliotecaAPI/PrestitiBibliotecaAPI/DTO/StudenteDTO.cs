using PrestitiBibliotecaAPI.Models;

namespace PrestitiBibliotecaAPI.DTO
{
    public class StudenteDTO
    {
        public int Id { get; set; }
        public string Nominativo { get; set; }
        public string Classe { get; set; }

        public StudenteDTO() { }

        public StudenteDTO(Studente s) {
            this.Id = s.Matricola;
            this.Nominativo = s.Nominativo;
            this.Classe = s.Classe;
        }
    public static StudenteDTO from(Studente s)
        {
            return new StudenteDTO {
                Id = s.Matricola,
                Nominativo = s.Nominativo,
                Classe = s.Classe
            };
        }
}

    }

