namespace PrestitiBibliotecaAPI.DTO
{
    public class PrestitoDTO
    {
        public int Id { get; set; }
        public string TitoloLibro { get; set; }
        public string NominativoStudente { get; set; }
        public DateTime DataPrestito { get; set; }
        public DateTime? DataRestituzione { get; set; }
    }
}
