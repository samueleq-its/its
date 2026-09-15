package stanzaPrenotazione;

import java.time.LocalDate;

public class Prenotazione {
	private String name;
	private LocalDate inizio;
	private LocalDate fine;
	
	public Prenotazione(String name, LocalDate inizio, LocalDate fine) {
		super();
		this.name = name;
		this.inizio = inizio;
		this.fine = fine;
	}
	
	
	public boolean sovrapposizionePeriodo(Prenotazione p) {

		return this.inizio.isBefore(p.getInizio()) && this.fine.isAfter(p.getInizio())
				|| this.inizio.isBefore(p.getFine())&& this.fine.isAfter(p.getFine());
	}
	
	public String getName() {
		return name;
	}
	public LocalDate getInizio() {
		return inizio;
	}
	public LocalDate getFine() {
		return fine;
	}
	
	
}
