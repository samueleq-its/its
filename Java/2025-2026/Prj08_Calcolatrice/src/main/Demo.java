package main;

import java.util.Scanner;

public class Demo {

	public static void main(String[] args) {

		double result;

		Scanner scanner = new Scanner(System.in);

		System.out.println("inserisci il primo numero");
		String a = scanner.nextLine();

		System.out.println("inserisci il secondo numero");
		String b = scanner.nextLine();

		System.out.println("inserisci l'operatore aritmetico");
		String c = scanner.nextLine();

		double x = Double.parseDouble(a);
		double y = Double.parseDouble(b);

		switch (c) {
		case "+":
			result = CalcolatriceStatic.addizione(x, y);
			System.out.println("il risultato dell'addizione è: " + result);
			break;
		case "-":
			result = CalcolatriceStatic.sottrazione(x, y);
			System.out.println("il risultato dell'addizione è: " + result);
			break;
		case "*":
			result = CalcolatriceStatic.moltiplicazione(x, y);
			System.out.println("il risultato dell'addizione è: " + result);
			break;
		case "/":
			result = CalcolatriceStatic.divisione(x, y);
			System.out.println("il risultato dell'addizione è: " + result);
			break;
			
		default:
			System.out.println("operazione non consentita");
		}

	}

}
