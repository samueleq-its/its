
import java.util.Scanner;

public class App {

    static String[] simboli = {"Carta", "Forbici", "Sasso"};

    // metodi ausiliari
    private static String scelta(String[] scelte) {
        int index = (int) (Math.random() * scelte.length);
        return scelte[index];
    }

    private static String valuta(String scelta1, String scelta2) {
        if (scelta1.equals(scelta2)) {
            return "Pareggio!";
        } else if ((scelta1.equals("Carta") && scelta2.equals("Sasso"))
                || (scelta1.equals("Forbici") && scelta2.equals("Carta"))
                || (scelta1.equals("Sasso") && scelta2.equals("Forbici"))) {
            return "Giocatore 1 vince!";
        } else {
            return "Giocatore 2 vince!";
        }
    }

    public static void main(String[] args) throws Exception {
        // String scelta1 = scelta(simboli);
        String scelta2 = scelta(simboli);

        String scelta1 = "";
        Scanner scanner = new Scanner(System.in);
        while (scelta1.equals("")) {
            System.out.println("Scegli tra CARTA, FORBICE o SASSO");
            String choice = scanner.nextLine().toUpperCase();
            scelta1 = switch (choice) {
                case "CARTA" -> "Carta";
                case "FORBICE" -> "Forbici";
                case "SASSO" -> "Sasso";
                default -> {
                    System.out.println("Scelta errata");
                    yield "";
                }
            };
        }
        scanner.close();

        System.out.println("Giocatore 1: " + scelta1);
        System.out.println("Giocatore 2: " + scelta2);

        String risultato = valuta(scelta1, scelta2);
        System.out.println(risultato);
    }
}
