package demo;

import java.util.Scanner;

public class LibreriaDemo {

	public static void main(String[] args) {
		
		Libro[] libreria = new Libro[10];
		Scanner input = new Scanner(System.in);
		
		
		for (int i = 0; i < libreria.length; i++) {
			System.out.println("inserisci il titolo del libro");
			String titolo = input.nextLine();
			System.out.println("inserisci il prezzo del libro");
			double prezzo = input.nextDouble();
			System.out.println("inserisci il numero di pagine del libro");
			int pagine = input.nextInt();
			
			System.out.println("Libro inserito");
			input.nextLine();
			
			Libro l = new Libro((i+1), titolo, prezzo, pagine, 1);
			libreria[i] = l;
		}
		
		for (Libro l : libreria) {
			System.out.println(l.insertLibro());
		}
		
		System.out.println("Grazie per usare Eclypse");
		
		
		//System.out.println(libro1.stampaLibro());
		//System.out.println(libro1.stampaLibroHtml());
		
		
	}

}
