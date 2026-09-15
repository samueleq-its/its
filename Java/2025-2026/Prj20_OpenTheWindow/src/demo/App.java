package demo;
import javax.swing.SwingUtilities;

public class App {
    public static void main(String[] args) throws Exception {
        //SwingUtilities.invokeLater(() -> new Demo());
        SwingUtilities.invokeLater(new Runnable() {
            public void run() {
                new Demo("Gestione DB Prodotti");
            }
        });

    }
}
