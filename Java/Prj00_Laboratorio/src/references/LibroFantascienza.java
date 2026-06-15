package references;

public class LibroFantascienza extends Libro implements Fantasticabile {

	public LibroFantascienza(String titolo, int pagine) {
		super(titolo, pagine);
		this.genere = Genere.FANTASCIENZA;
	}
}
