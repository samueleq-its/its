package model;

public class Dirigente extends Dipendente {

	public Dirigente(String nome, String cognome) {
		super(nome, cognome);
		this.mansione = "Dirigente";
	}
}
