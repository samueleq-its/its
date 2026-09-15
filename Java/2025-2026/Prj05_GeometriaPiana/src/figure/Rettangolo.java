package figure;

public class Rettangolo extends LuogoGeometrico implements Contornabile{

    private Segmento base, altezza;

    public Rettangolo(Segmento base, Segmento altezza) {
        this.base = base;
        this.altezza = altezza;
    }

    public double perimetro(){
        return (base.lunghezza() + altezza.lunghezza()) * 2;
    }

    public double area() {
        return base.lunghezza() * altezza.lunghezza();
    }

    @Override
    public String toString() {
        return "Rettangolo[" +
                " Perimetro=" + perimetro() +
                ", Area=" + area() +
                ']';
    }

    @Override
    public double contorno() {
        return perimetro();
    }
}
