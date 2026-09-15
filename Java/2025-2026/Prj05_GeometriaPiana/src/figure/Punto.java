package figure;

public class Punto extends LuogoGeometrico{

    private int x,y;

    public Punto() {
        this.nome = "Punto";
        this.x = 0;
        this.y = 0;
    }

    public Punto(int x, int y) {
        this();
        this.x = x;
        this.y = y;
    }

    public int getX() {
        return x;
    }

    public void setX(int x) {
        this.x = x;
    }

    public int getY() {
        return y;
    }

    public void setY(int y) {
        this.y = y;
    }

    @Override
    public String toString() {
        String metodoEreditato = super.toString();
        return metodoEreditato + " (" + x + ", " + y + ")";
    }
}
