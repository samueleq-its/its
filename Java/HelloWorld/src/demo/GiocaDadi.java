package demo;

public class GiocaDadi {

	public static void main(String[] args) {
		
		Dado dado1 = new Dado(6);
		Dado dado2 = new Dado(6);
		
		int lanci = 500000000;
		int vittorie = 0;
		
		long start = System.currentTimeMillis();
		for (int i = 0;i < lanci; i++) {
			int result1 = dado1.lancia();
			//System.out.println(result1);
			
			int result2 = dado2.lancia();
			//System.out.println(result2);
			
			if (result1 == result2) {
				//System.out.println("Hai vinto");
				vittorie++;
			}
		}
		long stop = System.currentTimeMillis();
		double media = (double) vittorie / lanci * 100;
		System.out.println("Hai lanciato " + lanci + " volte");
		System.out.println("Hai vinto " + vittorie+ " volte");
		System.out.println("Media: " + media);
		System.out.println("l'elaborazione è stata:" + (stop - start));
	}
}
