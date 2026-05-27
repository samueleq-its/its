package model;

public class Fattorino extends Dipendente implements Stipendiato {

	private int consegneMese;
	
	public Fattorino(String nome, String cognome) {
		super(nome, cognome);
		this.mansione = "Fattorino";
	}
	
	//region GETTERS & SETTERS
	public int getConsegneMese() {
		return consegneMese;
	}
	
	public void setConsegneMese(int consegneMese) {
		this.consegneMese = consegneMese;
	}
	//endregion

	
	
	@Override
	public double calcolaStipendio() {
		return this.getPagaBase() * this.consegneMese;
	}
}
