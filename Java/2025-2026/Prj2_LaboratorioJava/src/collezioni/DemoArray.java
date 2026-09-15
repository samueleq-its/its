package collezioni;

public class DemoArray {
    public static void main(String[] args) {

        int[] voti = new int[10];

        voti[0] = 25;
        voti[2] = 26;
        voti[4] = 28;
        voti[6] = 30;

        int lunghezza = voti.length;
        int totale = 0;
        int esamiDati = 0;

        for (int i = 0; i < voti.length; i++) {

            if (voti[i] > 0){
                esamiDati++;
            }
            totale += voti[i];
        }

        System.out.println(totale);
        System.out.println((double) totale/esamiDati);
    }
}
