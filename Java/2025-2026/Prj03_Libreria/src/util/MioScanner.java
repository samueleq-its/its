package util;

import java.util.Scanner;

public class MioScanner {

    private Scanner input = null;

    public MioScanner() {
        accendiScanner();
    }

    public String leggiStringa(String domanda){
        System.out.println(domanda);
        return this.input.nextLine();
    }

    public int leggiIntero(String domanda){
        System.out.println(domanda);
        int temp = this.input.nextInt();
        input.nextLine();
        return temp;
    }

    public double leggiDouble(String domanda){
        System.out.println(domanda);
        double temp = this.input.nextDouble();
        input.nextLine();
        return temp;
    }

    public void accendiScanner() {
        if (this.input == null)
            this.input = new Scanner(System.in);
    }

    public  void spegniScanner(){
        if (this.input != null)
            this.input.close();
    }
}
