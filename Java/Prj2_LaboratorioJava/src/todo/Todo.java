package todo;

public class Todo {

    private String cosaDaFare;
    private boolean completato;

    public Todo() {
    }

    public Todo(String cosaDaFare) {
        this.cosaDaFare = cosaDaFare;
        this.completato = false;
    }

    @Override
    public String toString() {
        return this.cosaDaFare + " " + this.completato;
    }
}
