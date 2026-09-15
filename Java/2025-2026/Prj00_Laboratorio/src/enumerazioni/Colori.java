package enumerazioni;

public enum Colori {
	BIANCO("#ff0000"), ROSSO("#00ff00"), NERO("#0000ff");
	
	private String esa;
	
	private Colori (String esa) {
		
		this.esa = esa;
	}
	
	public String getEsa() {
		return esa;
	}
	
	
	
}
