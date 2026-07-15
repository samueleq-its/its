package libro;

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
	
	public void cambiaAnno(Libro l) {
		this.annoDiPubblicazione = l.getAnnoDiPubblicazione();
	}

	public boolean inAnno(int a){
		return this.annoDiPubblicazione == a;
	}
	
	public boolean stessoAnno(Libro l) {
		return this.annoDiPubblicazione == l.getAnnoDiPubblicazione();
	}

	@Override
	public String toString() {
		StringBuilder builder = new StringBuilder();
		builder.append(autori);
		builder.append(", ");
		builder.append(titolo);
		builder.append(", ");
		if (annoDiPubblicazione != Integer.MAX_VALUE) {
			builder.append(annoDiPubblicazione);
			builder.append(", ");			
		}
		builder.append(codiceISBN);

		return builder.toString();
	}

	public String getAutori() {
		return autori;
	}

	public String getTitolo() {
		return titolo;
	}

	public int getAnnoDiPubblicazione() {
		return annoDiPubblicazione;
	}

	public String getCodiceISBN() {
		return codiceISBN;
	}

	

}
