package model;

public abstract class Dipendente {
	
	private static int contatore = 1;
	
	private int nMatricola;
	private String nome;
	private String cognome;
	protected String mansione;
	protected double pagaBase;
	
	public Dipendente(String nome, String cognome) {
		this.nMatricola = contatore++; // contatore incrementato dopo assegnazione
		this.nome = nome;
		this.cognome = cognome;
	}

	//region GETTERS & SETTERS
	public static int getContatore() {
		return contatore;
	}

	public int getnMatricola() {
		return nMatricola;
	}
	
	public String getMansione() {
		return mansione;
	}

	public void setMainsione(String mansione) {
		this.mansione = mansione;
	}

	public double getPagaBase() {
		return pagaBase;
	}

	public void setPagaBase(double pagaBase) {
		this.pagaBase = pagaBase;
	}
	//endregion

	@Override
	
	
	public String toString() {
		// getClass().getName()
		return this.mansione + " [nMatricola=" + nMatricola + ", nome=" + nome + ", cognome=" + cognome + "]";
	}
	
	
}
