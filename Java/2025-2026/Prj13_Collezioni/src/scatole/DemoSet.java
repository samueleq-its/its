package scatole;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.HashSet;
import java.util.LinkedList;
import java.util.List;
import java.util.TreeSet;

public class DemoSet {

	public static void main(String[] args) {
		
		String[] oldCities = {"Madrid", "Lisbona"};
		
		//restituisce una lista con lo stesso contenuto dell'array passato
		List<String> oldArrayAsList = Arrays.asList(oldCities);
		
		TreeSet<String> capitali = new TreeSet<String>(oldArrayAsList);

		capitali.add("Parigi");
		capitali.add("Roma");
		capitali.add("Berlino");
		capitali.add("Parigi");
		//capitali.addFirst("Londra"); non disponibile in un Set
		
		
		int totale = capitali.size();
		
		System.out.println("size = " + totale);
		
		for (String capitale : capitali) {
			System.out.println(capitale);
		}
	}

}
