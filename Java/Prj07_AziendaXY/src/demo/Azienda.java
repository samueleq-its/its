package demo;

import controller.AziendaController;
import model.Dipendente;
import model.Dirigente;
import model.Fattorino;
import model.Impiegato;

public class Azienda {

	public static void main(String[] args) {
		AziendaController ctrl = new AziendaController();
		
		Dipendente f1 = new Fattorino("Nicole", "Tappo");
		Dipendente i1 = new Impiegato("Filippo", "De Filippis");
		Dipendente d1 = new Dirigente("Samuele", "Querio");
		
		ctrl.addDipendente(f1);
		ctrl.addDipendente(i1);
		ctrl.addDipendente(d1);
		
		f1.setPagaBase(3);
		if (f1 instanceof Fattorino) {
			((Fattorino)f1).setConsegneMese(0);			
		}
		
		for (Dipendente d : ctrl.getDipendenti()) {
			System.out.println(d);
		}
	}
}
