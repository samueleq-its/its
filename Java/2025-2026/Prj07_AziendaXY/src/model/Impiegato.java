package model;

public class Impiegato extends Dipendente implements Stipendiato {

	private int giorniMese;
	
	public Impiegato(String nome, String cognome) {
		super(nome, cognome);
		this.mansione = "Impiegato";
	}

	//region GETTERS & SETTERS
	public int getGiorniMese() {
		return giorniMese;
	}

	public void setGiorniMese(int giorniMese) {
		this.giorniMese = giorniMese;
	}
	//endregion

	@Override
	public double calcolaStipendio() {
		return this.getPagaBase() * this.getGiorniMese();
	}
	
	
	
	
}
