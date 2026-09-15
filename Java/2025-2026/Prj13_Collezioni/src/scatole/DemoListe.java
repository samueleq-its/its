package scatole;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.LinkedList;
import java.util.List;

public class DemoListe {

	public static void main(String[] args) {
		
		String[] oldCities = {"Madrid", "Lisbona"};
		
		//restituisce una lista con lo stesso contenuto dell'array passato
		List<String> oldArrayAsList = Arrays.asList(oldCities);
		
		ArrayList<String> capitali = new ArrayList<String>(oldArrayAsList);

		capitali.add("Parigi");
		capitali.add("Roma");
		capitali.add("Berlino");
		capitali.add("Parigi");
		capitali.addFirst("Londra");
		
		// Collections.sort(capitali);
		
		capitali.stream()
		.sorted()
		.forEach(c -> System.out.println(c));
		
		System.out.println("-----------------------");
		
		int totale = capitali.size();
		
		System.out.println("size = " + totale);
		
		for (String capitale : capitali) {
			System.out.println(capitale);
		}
		
	}

}
