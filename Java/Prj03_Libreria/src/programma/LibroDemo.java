package programma;

import controller.Scaffale;
import model.Libro;
import util.MioScanner;

public class LibroDemo {
    public static void main(String[] args) {

        /*Libro libro1 = new Libro("Io robot", 123, 10.50);
        Libro libro2 = new Libro("Tu robot", 223, 15.40);
        Libro libro3 = new Libro("Egli robot", 323, 20.30);*/

        Scaffale fantascienza = new Scaffale();
/*        fantascienza.addLibro(libro1);
        fantascienza.addLibro(libro2);
        fantascienza.addLibro(libro3);*/

        MioScanner canon = new MioScanner();

        boolean gira = true;

        while(gira){
            aggiungiLibro(fantascienza, canon);
            String risposta = canon.leggiStringa("Vuoi insierire altri libri?");
            //canon.leggiStringa("");
            if (risposta.equalsIgnoreCase("n"))
                gira = false;
        }

        for (Libro l : fantascienza.getLibri()){
            System.out.println(l.stampaInfoLibro());
        }
    }

    private static void aggiungiLibro(Scaffale fantascienza, MioScanner canon) {
        String titolo = canon.leggiStringa("scrivi il titolo del libro");
        int pagine = canon.leggiIntero("scrivi il numero delle pagine");
        double prezzo = canon.leggiDouble("scrivi il prezzo del libro");

        Libro libro = new Libro(titolo,pagine,prezzo);
        fantascienza.addLibro(libro);
    }
}
