package demo;

//import java.util.Random;

public class Dado {
	int facce;
	
	public Dado(int facce) {
		this.facce = facce;
	}
	
	public int lancia() {
		// deve ritornare un intero compreso tra 1 e facce
		
		//Random rng = new Random();
		//return rng.nextInt(facce)+ 1;
		
		double casuale = Math.random();
		int result = (int) (casuale * facce) + 1;
		return result;

	}
}
