
public class Carta extends Simbolo {

    @Override
    public Esito vs(Simbolo other) {
	return switch (other) {
	    case Carta _ -> Esito.PAREGGIO;
	    case Forbici _ -> Esito.VITTORIA;
	    case Sasso _ -> Esito.SCONFITTA;
	    default -> throw new IllegalStateException("Unexpected value: " + other);
	};
    }

}
