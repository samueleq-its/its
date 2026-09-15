package repos;

import java.util.List;

import model.Studente;

public interface StudenteRepo {
	
	Studente addStudente(Studente s);
	List<Studente> getStudenti();
	
	
}
