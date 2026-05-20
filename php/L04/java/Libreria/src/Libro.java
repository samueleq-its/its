
public class Libro {

    public String titolo;
    public String autore;
    public int annoPubblicazione;

    public Libro(String titolo, String autore, int annoPubblicazione) {
        this.titolo = titolo;
        this.autore = autore;
        this.annoPubblicazione = annoPubblicazione;
    }

    @Override
    public String toString() {
        return "Titolo: " + this.titolo + ", Autore: " + this.autore + ", Anno di Pubblicazione: " + this.annoPubblicazione;
    }
}
