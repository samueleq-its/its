package Libro;

public class Libro {
	private String autori;
	private String titolo;
	private int annoDiPubblicazione;
	private String codiceISBN;

	public Libro(String autori, String titolo, String codiceISBN){
		this.autori = autori;
		this.titolo = titolo;
		this.codiceISBN = codiceISBN;
		this.annoDiPubblicazione = Integer.MAX_VALUE;
	}

	public void cambiaAnno(int a){
		this.annoDiPubblicazione = a;
	}

	public boolean inAnno(int a){
		return this.annoDiPubblicazione == a;
	}


	// to string


}
