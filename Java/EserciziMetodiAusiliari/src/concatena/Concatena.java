package concatena;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Concatena {

    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        System.out.println(concantenaParole(getParole(in)));
    }

    private static List<String> getParole(Scanner in) {
        List<String> parole = new ArrayList<>();
        for (int i = 0; i < 3; i++) {
            System.out.println("Inserisci una parola");
            parole.add(in.nextLine());
        }
        return parole;
    }

    private static String concantenaParole(List<String> parole){
        StringBuilder risultato = new StringBuilder();
        for (String parola : parole){
            risultato.append("*").append(parola);
        }
        risultato.deleteCharAt(0);
        return risultato.toString();
    }
}
