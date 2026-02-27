package demo;

public class Libro {
	
	// attributi
	int libro_id;
	String titolo;
	double prezzo;
	int pagine;
	int editore_id;
	
	
	
	public Libro(int libro_id, String titolo, double prezzo, int pagine, int editore_id) {
		this.libro_id = libro_id;
		this.titolo = titolo;
		this.prezzo = prezzo;
		this.pagine = pagine;
		this.editore_id = editore_id;
	}
	
	
	public String stampaLibro() {
		return titolo + " " + prezzo + "€";
	}
	
	public String stampaLibroHtml() {
		return "<tr><td>" +  titolo + "</td><td>" + prezzo + "€</td></tr>";
	}
	
	public String insertLibro() {
		return "INSERT INTO libri VALUES (" + libro_id + ",'" + titolo + "', " + prezzo + ", " + pagine + ", " + editore_id +");";
	}
}
