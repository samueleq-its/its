package model;

public class Prodotto {

	private int idProdotto;
	private String nome;
	private double prezzoUnitario;
	private int quantitaStock;
	private Categoria categoria;
	private Fornitore fornitore;

	public Prodotto() {
	}

	public Prodotto(int idProdotto, String nome, double prezzoUnitario, int quantitaStock, Categoria categoria,
			Fornitore fornitore) {
		this.idProdotto = idProdotto;
		this.nome = nome;
		this.prezzoUnitario = prezzoUnitario;
		this.quantitaStock = quantitaStock;
		this.categoria = categoria;
		this.fornitore = fornitore;
	}

	public int getIdProdotto() {
		return idProdotto;
	}

	public void setIdProdotto(int idProdotto) {
		this.idProdotto = idProdotto;
	}

	public String getNome() {
		return nome;
	}

	public void setNome(String nome) {
		this.nome = nome;
	}

	public double getPrezzoUnitario() {
		return prezzoUnitario;
	}

	public void setPrezzoUnitario(double prezzoUnitario) {
		this.prezzoUnitario = prezzoUnitario;
	}

	public int getQuantitaStock() {
		return quantitaStock;
	}

	public void setQuantitaStock(int quantitaStock) {
		this.quantitaStock = quantitaStock;
	}

	public Categoria getCategoria() {
		return categoria;
	}

	public void setCategoria(Categoria categoria) {
		this.categoria = categoria;
	}

	public Fornitore getFornitore() {
		return fornitore;
	}

	public void setFornitore(Fornitore fornitore) {
		this.fornitore = fornitore;
	}

	@Override
	public String toString() {
		return "Prodotto [idProdotto=" + idProdotto + ", nome=" + nome + ", prezzoUnitario=" + prezzoUnitario
				+ ", quantitaStock=" + quantitaStock + ", categoria=" + categoria + ", fornitore=" + fornitore + "]";
	}

}
