package demo;

import java.util.Collection;
import java.util.HashMap;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Set;

public class ProvaMappe {
	
	public static void main(String[] args) {
		
		Map<String, String> regioni = new HashMap<String, String>();
		
		regioni.put("Piemonte", "Torino");
		regioni.put("Lombardia", "Milano");
		regioni.put("Veneto", "Venezia");
		
		// CTRL + SHIFT + L
		Set<String> keySet = regioni.keySet();
		Collection<String> values = regioni.values();
		Set<Entry<String, String>> entrySet = regioni.entrySet();
		
		for (var key : keySet) {
			System.out.println(key + " " + regioni.get(key));
		}
		
	}
}
