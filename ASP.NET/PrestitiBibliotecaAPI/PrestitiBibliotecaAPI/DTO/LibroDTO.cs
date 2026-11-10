namespace PrestitiBibliotecaAPI.DTO
{
    public class LibroDTO
    {
        public int Id { get; set; }
        public string? Autore { get; set; }
        public string? Titolo { get; set; }
        public string? Editore { get; set; }
        public int? Anno { get; set; }
        public string? Classificazione { get; set; }
    }
}