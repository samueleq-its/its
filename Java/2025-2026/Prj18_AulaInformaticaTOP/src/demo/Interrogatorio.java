package demo;

import java.util.List;

import controller.AulaController;
import model.Studente;
import service.StudentsBuilder;

public class Interrogatorio {

	
	public static void main(String[] args) {
		
		AulaController ctrl = new AulaController();
		
		List<Studente> studenti = StudentsBuilder.creaStudenti("documenti/studenti.csv");
		
		studenti.forEach(ctrl::addStudente);
		
		//ctrl.getStudenti().stream().forEach(System.out::println);
		System.out.println("n. studenti: " + Studente.getCounter());
		
		System.out.println(ctrl.interroga());
		
		
	}
}
