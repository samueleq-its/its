package repos;

import java.util.List;

import entities.Prodotto;

public interface ProdottoRepo {

	String TABLE = "prodotti_ortofrutticoli";
	String FIND_ALL = "SELECT * FROM " + TABLE;
	String FIND_BY_CAT = "SELECT * FROM " + TABLE + " WHERE categoria = ?";
	String FIND_BY_ORIGIN = "SELECT * FROM " + TABLE + "WHERE origine = ?";	
	
	List<Prodotto> getProdotti();
	List<Prodotto> getProdottiByCategoria(String categoria);
	List<Prodotto> getProdottiByOrigine(String origine);
}
