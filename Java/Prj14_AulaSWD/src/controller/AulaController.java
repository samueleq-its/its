package controller;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.PrintWriter;
import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;
import java.util.Random;
import java.util.Scanner;

import model.Studente;
import repos.StudenteRepo;
import repos.StudenteRepoImp;

public class AulaController {
	
	private StudenteRepo repo = new StudenteRepoImp();
	private List<Studente> presenti = new ArrayList<Studente>();
	private List<Studente> assenti= new ArrayList<Studente>();
	
	public List<Studente> getStudenti(){
		return repo.getStudenti();
	}
	
	public List<Studente> getStudentibyCognome(){
		return repo
				.getStudenti()
				.stream()
				.sorted()
				.toList();
	}
	
	public Studente interrogaStudente() {
		Random random = new Random();
		return repo
				.getStudenti()
				.get(random.nextInt(0, repo.getStudenti().size()));
	}
	
	
	public List<Studente> getPresenti() {
		return presenti;
	}

	public void setPresenti(List<Studente> presenti) {
		this.presenti = presenti;
	}

	public List<Studente> getAssenti() {
		return assenti;
	}

	public void setAssenti(List<Studente> assenti) {
		this.assenti = assenti;
	}

	public void faiAppello() {
		Scanner scanner = new Scanner(System.in);
		for (Studente s : repo.getStudenti()) {
			System.out.println(s.getCognome() + " è presente? S/N");
			String risposta = scanner.nextLine();
			
			if (risposta.equalsIgnoreCase("S")) {
				presenti.add(s);
			} else if (risposta.equalsIgnoreCase("N")) {
				assenti.add(s);
			}
			// è se non è nessuno dei due?
		}
		scanner.close();
	}
	
	public void writeFile(String fileName, List<Studente> studenti) {
		try {
			PrintWriter writer = new PrintWriter(new File(fileName));
			
			writer.println("------------------------");
			writer.println("Appello del " + LocalDateTime.now());
			writer.println("------------------------");
			
			
			for (Studente studente : studenti) {
				writer.println(studente);
			}
			
			writer.close();
			
		} catch (FileNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
	}
	
}
