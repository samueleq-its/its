package repos;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;

import model.Studente;

public class StudenteRepoImp implements StudenteRepo {

	private List<Studente> studenti = new ArrayList<Studente>();

	public StudenteRepoImp() {
		caricaStudente();
	}

	private void caricaStudente() {
		
		//try with resource
		try (BufferedReader br = new BufferedReader(new FileReader(new File("documenti/studenti.csv")));){
			// br.readLine(); // scarta prima riga

			String riga;
			while ((riga = br.readLine()) != null) {
				String[] split = riga.split(",");

				if (split[0].equals("ID") || split[0].equals("")) {
					continue;
				}

				int id = Integer.parseInt(split[0]);
				String nome = split[1];
				String cognome = split[2];

				Studente s = new Studente(id, nome, cognome);
				this.addStudente(s);

			}

		} catch (FileNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}	
	}

	@Override
	public Studente addStudente(Studente s) {
		studenti.add(s);
		return s;
	}

	@Override
	public List<Studente> getStudenti() {
		return this.studenti;
	}

}
