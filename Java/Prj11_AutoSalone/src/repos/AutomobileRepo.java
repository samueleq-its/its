package repos;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

import model.Automobile;

public class AutomobileRepo {

	List<Automobile> automobili = new ArrayList<>();

	public AutomobileRepo() throws FileNotFoundException {
		leggiFile();
	}

	private void leggiFile() throws FileNotFoundException {
		File f = new File("veicoli/auto.csv");

		@SuppressWarnings("resource")
		Scanner scanner = new Scanner(f);

		// butta via prima riga
		scanner.nextLine();

		while (scanner.hasNextLine()) {
			String line = scanner.nextLine();

			line = line.replaceAll("\"", "");
			String[] splitLine = line.split(",");
			String marca = splitLine[0];
			String modello = splitLine[1];
			int cilindrata = Integer.parseInt(splitLine[2]);
			double prezzo = Double.parseDouble(splitLine[3]);

			this.automobili.add(new Automobile(marca, modello, cilindrata, prezzo));

		}
	}

	public static void main(String[] args) {
		AutomobileRepo ar;
		try {
			ar = new AutomobileRepo();
			List<Automobile> list =  ar
				.automobili
				.stream()
				.filter(a -> a.getPrezzo() > 20000)
				.sorted((a,b) -> Double.compare(b.getPrezzo(), a.getPrezzo()))
				.limit(3)
				//.forEach(a -> System.out.println(a));
				.toList();
			
			list.forEach(System.out::println);
			
		} catch (FileNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

}
