package service;

import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.List;

import model.Studente;

// builder design pattern
public class StudentsBuilder {

	public static List<Studente> creaStudenti(String fileName){
		
		List<Studente> studenti = new ArrayList<Studente>();
		List<String> righe = EstrattoreStringhe.estrai(Paths.get(fileName));
		
		for (String riga : righe) {
			
			if (riga.startsWith("ID")) { continue; }
			
			String[] split = riga.split(",");
			
			Studente s = new Studente(split[1], split[2]);
			studenti.add(s);
		}
		
		return studenti;
	}
}
