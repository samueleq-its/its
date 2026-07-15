package stanzaPrenotazione;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

public class Stanza {

	private List<Prenotazione> elencoPrenotazioni = new ArrayList<Prenotazione>();
	
	
	public Prenotazione riserva(String nome, LocalDate inizio, LocalDate fine) throws Exception {
		Prenotazione nuovaPrenotazione = new Prenotazione(nome, inizio, fine);
		
		for (Prenotazione p : elencoPrenotazioni) {
			if (p.sovrapposizionePeriodo(nuovaPrenotazione)) {
				throw new Exception("periodo già prenotato");
			}
		}
		
		this.elencoPrenotazioni.add(nuovaPrenotazione);
		return nuovaPrenotazione;
	}
	
	public List<Prenotazione> prenotazioni(){
		return this.elencoPrenotazioni;
	}
}
