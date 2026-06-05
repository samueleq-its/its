package demo;

import java.util.Comparator;
import java.util.List;

import controller.AulaController;
import model.Studente;

//class ComparatorePerNome implements Comparator<Studente>{
//
//	@Override
//	public int compare(Studente s1, Studente s2) {
//		return s1.getNome().compareToIgnoreCase(s2.getNome());
//	}
//}

public class ComparatoreDemo {
	public static void main(String[] args) {
		
		AulaController ctrl = new AulaController();
		
		List<Studente> studenti = ctrl.getStudenti();
		
//		Comparator<Studente> cpn = new Comparator<Studente>() {
//			@Override
//			public int compare(Studente s1, Studente s2) {
//				return s1.getNome().compareToIgnoreCase(s2.getNome());
//			}
//		};
		
		studenti
			.stream()
			.sorted((s1, s2) -> s1.getNome().compareToIgnoreCase(s2.getNome()))
			.forEach(System.out::println);
	}
}
