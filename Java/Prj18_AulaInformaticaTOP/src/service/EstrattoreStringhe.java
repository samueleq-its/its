package service;

import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.List;

public class EstrattoreStringhe {

	public static List<String> estrai(Path p) {
		List<String> righe = null;
		
		try {
			righe = Files.readAllLines(p, StandardCharsets.UTF_8);
		} catch (IOException e) {
			// TODO Auto-generated catch block
			System.err.println("Lettura file non riuscita");
			System.err.println(e.getMessage());
		}
		
		return righe;
	}
}
