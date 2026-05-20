package model;

public class Libro {

    public String titolo;
    public int pagine;
    public double prezzo;

    public Libro(String titolo, int pagine, double prezzo) {
        this.titolo = titolo;
        this.pagine = pagine;
        this.prezzo = prezzo;
    }

    public String stampaInfoLibro(){
        return "Il libro " + this.titolo + " costa " + this.prezzo + " Euro";
    }
}
