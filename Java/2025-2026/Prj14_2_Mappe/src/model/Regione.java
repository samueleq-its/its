package model;

import java.util.ArrayList;
import java.util.List;

public class Regione {
	
	private String nome;
	private List<Comune> comuni;
	
	public Regione(String nome) {
		this.nome = nome;
		this.comuni = new ArrayList<Comune>();
	}
	
	public void addComune(Comune c) {
		comuni.add(c);
	}
	
	public List<Comune> getComuni() {
		return comuni;
	}
	
	public String getNome() {
		return nome;
	}
	
}
