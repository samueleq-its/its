package references;

public abstract class Libro {

	private static int contatoreLibri = 1;  
	
	private int id;
	private String titolo;
	private int pagine;
	protected Genere genere;

	public Libro() {
		this.id = contatoreLibri++; //viene incrementato DOPO l'assegnazione
	}

	public Libro(String titolo, int pagine) {
		this(); // generazione Id
		this.titolo = titolo;
		this.pagine = pagine;
	}

	// region GETTERS E SETTERS
	public int getId() {
		return id;
	}

//	public void setId(int id) {
//		this.id = id;
//	}

	public Genere getGenere() {
		return genere;
	}

	public void setGenere(Genere genere) {
		this.genere = genere;
	}

	public String getTitolo() {
		return titolo;
	}

	public void setTitolo(String titolo) {
		this.titolo = titolo;
	}

	public int getPagine() {
		return pagine;
	}

	public void setPagine(int pagine) {
		this.pagine = pagine;
	}
	// endregion

	@Override
	public String toString() {
		StringBuilder builder = new StringBuilder();
		builder.append("Libro [id=");
		builder.append(id);
		if (genere != null) {
			builder.append(", genere=");
			builder.append(genere);			
		}
		builder.append(", titolo=");
		builder.append(titolo);
		builder.append(", pagine=");
		builder.append(pagine);
		builder.append("]");
		return builder.toString();
	}

}
