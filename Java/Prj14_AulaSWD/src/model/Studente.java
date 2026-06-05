package model;

public class Studente implements Comparable<Studente>{
	private int id;
	private String nome;
	private String cognome;
	
	public Studente() {}
	
	public Studente(int id, String nome, String cognome) {
		super();
		this.id = id;
		this.nome = nome;
		this.cognome = cognome;
	}

	//region GETTERS & SETTERS
	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public String getNome() {
		return nome;
	}

	public void setNome(String nome) {
		this.nome = nome;
	}

	public String getCognome() {
		return cognome;
	}

	public void setCognome(String cognome) {
		this.cognome = cognome;
	}
	//endregion 
	
	@Override
	public int compareTo(Studente altroStudente) {
		return this.cognome.compareToIgnoreCase(altroStudente.cognome);
	}
	
	@Override
	public String toString() {
		return "Studente [id=" + id + ", nome=" + nome + ", cognome=" + cognome + "]";
	}

	
	
	
	
}
