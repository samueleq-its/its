package model;

public class Domanda{

	private String teoria;
	private String pratica;
	
	public Domanda(String teoria, String pratica) {
		this.teoria = teoria;
		this.pratica = pratica;
	}

	
	@Override
	public String toString() {
		StringBuilder builder = new StringBuilder();
		builder.append("Domanda [teoria=");
		builder.append(teoria);
		builder.append(", pratica=");
		builder.append(pratica);
		builder.append("]");
		return builder.toString();
	}
}
