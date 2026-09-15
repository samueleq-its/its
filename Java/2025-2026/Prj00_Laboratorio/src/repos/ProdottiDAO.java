package repos;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

public class ProdottiDAO {

	public static void main(String[] args) {
		// file a caso
		File F = new File("\"C:\\Users\\samuele.querio\\Documents\\GitHub\\its\\Java\\Prj00_Laboratorio\\prova.txt\"");

		// non lancia eccezioni
		Scanner scanner = new Scanner(System.in);

		// richiede di gestire FileNotFoundException
		// Scanner fileScanner = new Scanner(F);

		try {
			Scanner fileScanner2 = new Scanner(F);
		} catch (FileNotFoundException e) {
			// e.printStackTrace(); // stampa l'errore in System.out come se non fosse stato
			// gestito
			System.err.println("Spiacenti si è verificato un errore");
			System.err.println(e.getMessage());
		}

		scanner.close();
	}
}
