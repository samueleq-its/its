package com.querio.services;

import java.util.List;

import com.querio.model.Maglia;
import com.querio.model.Prodotto;

public interface TShirtService {
	
	List<Maglia> getmagliette();
	Maglia addMaglietta(String maglietta);
	
	List<Prodotto> getProdotti();
	List<Prodotto> getProdottiByCategoria(String categoria);	
	Prodotto addProdotto(Prodotto p);
	Prodotto updateProdotto(Prodotto p);
	Prodotto getProdottoById(int id);
	void DeleteProdottoById(int id);
	

}
