package ripeti;

import java.util.Scanner;

public class Ripeti {

    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        System.out.println(stampaRipeti(getStringa(input),getNum(input)));

    }

    private static int getNum(Scanner input) {
        System.out.println("Inserisci un numero intero");
        return input.nextInt();
    }

    private static String getStringa(Scanner input) {
        System.out.println("Inserisci una stringa");
        return input.nextLine();
    }

    private static String stampaRipeti(String stringa, int num){
        StringBuilder risultato = new StringBuilder();
        if (num < 0){
            System.out.println("ERRORE: numero negativo");
        }
        for (int i = 0; i < num; i++) {
            risultato.append(stringa);
        }

        return risultato.toString();
    }
}
