package scatole;

public class DemoArray {
	
	public static void main(String[] args) {
		
		if (args.length > 0) {
			for (String arg : args) {
				System.out.println(arg);		
			}
		}
		
		
		String[] capitali = new String[5];
		
		capitali[0] = "Parigi";
		
		int quanti = capitali.length;
		
		for (String capitale : capitali) {
			System.out.println(capitale);		
		}
		
		
		
		
	}
}
