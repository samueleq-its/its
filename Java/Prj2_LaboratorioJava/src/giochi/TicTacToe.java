package giochi;

/**
 * Classe tic tac toe
 */
public class TicTacToe {

    /**
     * player1
     */
    String player1;
    String player2;

    /**
     * Metodo per iniziare a giocare
     * @param parametro passa un parametro
     * @return ritorna una stringa
     */
    String gioca(String parametro){
        return "si gioca";
    }

    public static void main(String[] args) {
        TicTacToe oggetto1 = new TicTacToe();
        TicTacToe oggetto2 = new TicTacToe();
        TicTacToe oggetto3 = new TicTacToe();

        System.out.println(oggetto1.player1);
    }
}
