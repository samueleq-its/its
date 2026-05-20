package figure;

public class Quadrato extends Rettangolo{

    private Segmento lato;

    public Quadrato(Segmento lato){
        super(lato,lato);
        this.lato = lato;
    }

    @Override
    public double perimetro() {
        return lato.lunghezza() * 4;
    }

    @Override
    public double area() {
        return Math.pow(lato.lunghezza(),2);
    }

    @Override
    public String toString() {
        return "Quadrato[" +
                "lato=" + lato +
                "Perimetro=" + perimetro() +
                ", Area=" + area() +
                ']';
    }
}
