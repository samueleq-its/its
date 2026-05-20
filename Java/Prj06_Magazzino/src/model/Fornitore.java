package model;

public class Fornitore {

	private int idFornitore;
	private String ragioneSOciale;
	private String citta;
	private String email;

	public Fornitore() {
	}

	public Fornitore(int idFornitore, String ragioneSOciale, String citta, String email) {
		this.idFornitore = idFornitore;
		this.ragioneSOciale = ragioneSOciale;
		this.citta = citta;
		this.email = email;
	}

	public int getIdFornitore() {
		return idFornitore;
	}

	public void setIdFornitore(int idFornitore) {
		this.idFornitore = idFornitore;
	}

	public String getRagioneSOciale() {
		return ragioneSOciale;
	}

	public void setRagioneSOciale(String ragioneSOciale) {
		this.ragioneSOciale = ragioneSOciale;
	}

	public String getCitta() {
		return citta;
	}

	public void setCitta(String citta) {
		this.citta = citta;
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	@Override
	public String toString() {
		return "Fornitore [idFornitore=" + idFornitore + ", ragioneSOciale=" + ragioneSOciale + ", citta=" + citta
				+ ", email=" + email + "]";
	}

}
