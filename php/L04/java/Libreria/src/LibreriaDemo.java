public class LibreriaDemo {
	public static void main(String[] args) {
		Libreria libreria = new Libreria();
		for (Libro libro : libreria.getLibri()) {
			if (libro.autore.equals("Ilaria Beltramme")) {
				System.out.println(libro);
			} 
		}
	}
}
