package demo;

import java.util.List;

import model.Comune;
import model.Regione;

public class GeografiaDemo {
	
	public static void main(String[] args) {
		
		Comune c1 = new Comune("Torino");
		Comune c2 = new Comune("Coazze");
		Comune c3 = new Comune("Avigliana");
		Comune c4 = new Comune("Giaveno");
		Comune c5 = new Comune("Pinerolo");
		
		Regione r1 = new Regione("Piemonte");
		r1.addComune(c1);
		r1.addComune(c2);
		r1.addComune(c3);
		r1.addComune(c4);
		r1.addComune(c5);
		
		List<Comune> comuni = r1
			.getComuni();
		
		comuni
			.stream()
			.forEach(System.out::println);
		

		
	}
	
}
