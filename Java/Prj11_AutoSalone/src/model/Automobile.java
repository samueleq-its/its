package model;

public class Automobile {

	private String marca;
	private String modello;
	private int cilindrata;
	private double prezzo;
	
	public Automobile() {
		// TODO Auto-generated constructor stub
	}
	
	public Automobile(String marca, String modello, int cilindrata, double prezzo) {
		super();
		this.marca = marca;
		this.modello = modello;
		this.cilindrata = cilindrata;
		this.prezzo = prezzo;
	}

	//region GETTERS & SETTERS 
	public String getMarca() {
		return marca;
	}

	public void setMarca(String marca) {
		this.marca = marca;
	}

	public String getModello() {
		return modello;
	}

	public void setModello(String modello) {
		this.modello = modello;
	}

	public int getCilindrata() {
		return cilindrata;
	}

	public void setCilindrata(int cilindrata) {
		this.cilindrata = cilindrata;
	}

	public double getPrezzo() {
		return prezzo;
	}

	public void setPrezzo(double prezzo) {
		this.prezzo = prezzo;
	}
	//endregion

	@Override
	
	public String toString() {
		return "Automobile [marca=" + marca + ", modello=" + modello + ", cilindrata=" + cilindrata + ", prezzo="
				+ prezzo + "]";
	}
	
	
}
