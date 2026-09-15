package model;

public record Studente (
		String nome,
		String cognome
		) {
	
	private static int counter = 1;
	
	public Studente {
		counter++;
	}

	public static int getCounter() {
		//TODO: da sistemare 
		return counter - 1;
	}
	
	
}
