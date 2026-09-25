public class App {
    public static void main(String[] args) {
        String currentThreadName = Thread.currentThread().getName();

        System.out.println("nome thread: " + currentThreadName);
        System.out.println("### INIZIO GARA ###");

        Thread t2 = new Thread();
        t2.setName("EclipseTop");

        Thread t3 = new Thread();
        t3.setName("PitoneMaledetto");

        RaceThread eclipse = new RaceThread("Eclipse", 1000);
        RaceThread pitone = new RaceThread("Pitone", 2000);
        Thread t1 = new Thread(() -> {
            for (int i = 0; i < 5; i++) {
                try {
                    System.out.println("t1");
                    System.out.println("ho percorso " + (i + 1) + "m");
                    Thread.sleep(1500);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            }
        });

        eclipse.start();
        pitone.start();
        t1.start();

        try {
            pitone.join();
            eclipse.join();
            t1.join();
        } catch (InterruptedException e) {
            e.printStackTrace();
        }

        System.out.println("### FINE GARA ###");

    }
}
