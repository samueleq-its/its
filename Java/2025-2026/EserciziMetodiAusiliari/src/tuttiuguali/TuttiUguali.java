package tuttiuguali;

import java.util.Scanner;

public class TuttiUguali {

    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        System.out.println("Inserisci il primo numero");
        int num1 = input.nextInt();
        System.out.println("Inserisci il secondo numero");
        int num2 = input.nextInt();
        System.out.println("Inserisci il terzo numero");
        int num3 = input.nextInt();

        System.out.println(ControlloUguali(num1,num2,num3) ? "Tutti uguali!" : "Almeno uno e' diverso");
    }

    private static boolean ControlloUguali(int num1, int num2, int num3){
        return num1 == num2 && num1 == num3;
    }
}
