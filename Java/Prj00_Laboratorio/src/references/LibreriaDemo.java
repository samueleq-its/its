package references;

import java.util.List;

public class LibreriaDemo {
	public static void main(String[] args) {

		// LibroRecord lr = new LibroRecord(1, "Tu, Robot", 321);
		Libro l = new LibroGiallo("Io, Robot", 123);
		Libro rr = new RomanzoRosa("io amo il robot", 123);
		Libro lf = new LibroFantascienza("fantasy", 5);
		Libro lfy = new LibroFantasy("mezza terra", 1000);

		List<Libro> tuttiLibri = List.of(l, rr, lf, lfy);
		List<Fantasticabile> libriFantastici = List.of((Fantasticabile) lf, (Fantasticabile) lfy);

		// System.out.println(lr);

		libriFantastici.forEach(System.out::println);

	}
}
