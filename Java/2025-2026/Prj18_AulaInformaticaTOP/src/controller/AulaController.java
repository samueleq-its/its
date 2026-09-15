package controller;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;

import model.Domanda;
import model.Postazione;
import model.Studente;

public class AulaController {

	private List<Studente> studenti;
	private List<Postazione> postazioni;
	private List<Domanda> domande;
	
	public AulaController() {
		this.studenti = new ArrayList<Studente>();
		this.postazioni = new ArrayList<Postazione>();
		this.domande = new ArrayList<Domanda>();
	}
	
	public void addStudente(Studente s) {
		this.studenti.add(s);
	}
	
	public void addPostazione(Postazione p) {
		this.postazioni.add(p);
	}
	
	public void addDomanda(Domanda d) {
		this.domande.add(d);
	}
	
	public List<Studente> getStudenti() {
		return studenti;
	}
	
	public String interroga() {
		StringBuilder sb = new StringBuilder();
		Random r = new Random();
		int casuale = r.nextInt(studenti.size());
		Studente studente = studenti.get(casuale);
		
		sb.append("Lo studente " + studente.cognome());
		sb.append("\nrisponde alla domanda di teoria: " + r.nextInt(30));
		sb.append("\nesegue l'esercizio: " + r.nextInt(30));
		
		return sb.toString();
	}
	
}
