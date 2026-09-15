package stringhe;

public class ProvaStringhe {

	public static void main(String[] args) {

		String s1 = "ciao";
		String s2 = new String("ciao");
		
		System.out.println(s1 == s2);
		System.out.println(s1.equals(s2));
		
		s1 += " mondo";
		String s3 = "ciao mondo";
		
		System.out.println(s1);
		
		System.out.println(s1 == s3);
		
		String[] frutti = {"mela", "pera", "fragola", "banana"};
		

//		String output = "";
//		output += "<ul>\n";
//		for (var frutto : frutti) {
//			output += "\t<li>"+ frutto +"</li>\n";
//		}
//		output += "</ul>\n";
	
		StringBuilder output = new StringBuilder();
		output.append("<ul>\n");
		for (var frutto : frutti) {
			output.append("\t<li>"+ frutto +"</li>\n");
		}
		output.append("</ul>\n");
		
		
		
		System.out.println(output.toString());
		
	}

}
