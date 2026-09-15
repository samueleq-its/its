package model;


public class Postazione {

	private int riga, colonna;

	/**
	 * 
	 * @param riga
	 * @param colonna
	 */
	public Postazione(int riga, int colonna) {
		this.riga = riga;
		this.colonna = colonna;
	}

	@Override
	public String toString() {
		StringBuilder builder = new StringBuilder();
		builder.append("Postazione [riga=");
		builder.append(riga);
		builder.append(", colonna=");
		builder.append(colonna);
		builder.append("]");
		return builder.toString();
	}
	
	
}
