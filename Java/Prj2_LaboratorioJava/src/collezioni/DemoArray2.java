package collezioni;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.PrintWriter;
import java.util.Scanner;

public class DemoArray2 {
    public static void main(String[] args) throws FileNotFoundException {

        File fileVoti = new File("documenti/voti.txt");
        File fileOutput = new File("documenti/output.txt");

        Scanner input = new Scanner(fileVoti);

        PrintWriter pw = new PrintWriter(fileOutput);

        String stringona = "";
        int totale = 0;

        while (input.hasNextLine()){
            String riga = input.nextLine();
            int voto = Integer.parseInt(riga);
            totale += voto;
            stringona += riga;
            System.out.println(riga);
        }
        System.out.println("Totale " + totale);
        pw.println("Totale " + totale);
        pw.close();
    }
}
