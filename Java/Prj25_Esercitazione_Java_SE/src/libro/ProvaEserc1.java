package libro;

public class ProvaEserc1 {

	public static void main (String[] args) {
		Libro l1 = new Libro("J.D. Salinger", "Il giovane Holden",
		"123456789");
		Libro l2 = new Libro("Agatha Christie", "Dieci piccoli indiani",
		"987654321");
		Libro l3 = new Libro("Antoine de Saint-Exupéry", "Il Piccolo Principe", "000000001");
		String s = l2.toString();
		boolean b = s.equals("Agatha Christie, Dieci piccoli indiani, 987654321");
		System.out.println("Test 1. Metodo toString(): "+b);
		l2.cambiaAnno(1939);
		b = l2.toString().equals("Agatha Christie, Dieci piccoli indiani, 1939, 987654321");
		System.out.println("Test 2. Metodi toString() e cambiaAnno(a):"+b);
		b = l1.inAnno(Integer.MAX_VALUE) && !l1.inAnno(2020);
		System.out.println("Test 3. Metodo inAnno(a): "+b);
		b = l1.stessoAnno(l3) && !l1.stessoAnno(l2);
		System.out.println("Test 4. Metodo stessoAnno(l): "+b);
		l2.cambiaAnno(l1);
		b = l2.toString().equals("Agatha Christie, Dieci piccoli indiani,987654321");
		System.out.println("Test 5. Metodo cambiaAnno(l): "+b);
		}

}
