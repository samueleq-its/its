package services;

import java.util.List;

import entities.Prodotto;

public interface NegozioService {

	List<Prodotto> getProdotti();
	List<Prodotto> getProdottiByCategoria(String categoria);
	List<Prodotto> getProdottiByOrigine(String origine);
	
	
}
