package enumerazioni;

public class TShirt {
	
	private double prezzo;
	private Colori colore;
	private Taglie taglie;
	
	public TShirt(double prezzo, Colori colore, Taglie taglie) {
		this.prezzo = prezzo;
		this.colore = colore;
		this.taglie = taglie;
	}
	
	public static void main(String[] args) {
		TShirt bianca = new TShirt(10, Colori.NERO, Taglie.XL);
		
		System.out.println(bianca);
	}
}
