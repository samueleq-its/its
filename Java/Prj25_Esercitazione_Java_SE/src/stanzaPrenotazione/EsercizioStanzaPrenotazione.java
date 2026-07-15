package stanzaPrenotazione;

import java.time.LocalDate;

public class EsercizioStanzaPrenotazione {

	public static void main(String[] args) throws Exception {
		Stanza r = new Stanza();
		
		LocalDate baseDate = LocalDate.of(2026, 1, 1);

		// p1: 105 to 120
		LocalDate p1_start = baseDate.plusDays(105); // April 16, 2026
		LocalDate p1_end   = baseDate.plusDays(120); // May 1, 2026

		// p2: 5 to 20
		LocalDate p2_start = baseDate.plusDays(5);   // January 6, 2026
		LocalDate p2_end   = baseDate.plusDays(20);  // January 21, 2026

		// p3: 20 to 22
		LocalDate p3_start = baseDate.plusDays(20);  // January 21, 2026
		LocalDate p3_end   = baseDate.plusDays(22);  // January 23, 2026

		// p4: 200 to 222
		LocalDate p4_start = baseDate.plusDays(200); // July 20, 2026
		LocalDate p4_end   = baseDate.plusDays(222); // August 11, 2026
		
		Prenotazione p1 = r.riserva("Mario Rossi", p1_start, p1_end);
		Prenotazione p2 = r.riserva("Giuseppe Verdi", p2_start, p2_end);
		Prenotazione p3 = r.riserva("Brad Pitt", p3_start, p3_end);
		Prenotazione p4 = r.riserva("Angiolina Jolie", p4_start, p4_end);
		
		for (Prenotazione p: r . prenotazioni ()){
		System.out.println(p.getName());
		}

	}

}
