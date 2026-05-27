package model;

public class Automobile extends Veicolo {

	private String marca;
	private String modello;
	
	public Automobile(String nome, String marca, String modello) {
		super(nome);
		this.marca = marca;
		this.modello = modello;
	}

	public String getMarca() {
		return marca;
	}

	public String getModello() {
		return modello;
	}

	@Override
	public String toString() {
		return "Automobile [marca=" + marca + ", modello=" + modello + "]";
	}
	
	

}
