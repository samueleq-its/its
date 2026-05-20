package figure;

public class Segmento extends LuogoGeometrico{

    private Punto a,b;

    public Segmento(Punto a, Punto b) {
        this.nome = "Segmento";
        this.a = a;
        this.b = b;
    }

    public double lunghezza(){
        return Math.sqrt(Math.pow(a.getX() - b.getX(),2) + Math.pow(a.getY() - b.getY(),2));
    }

    @Override
    public String toString() {
        return super.toString() +
                " [a=" + a +
                ", b=" + b +
                ", Lunghezza=" + lunghezza() +
                ']';
    }


}
