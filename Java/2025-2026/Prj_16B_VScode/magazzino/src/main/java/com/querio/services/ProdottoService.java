package com.querio.services;

import java.util.List;

import com.querio.entities.Prodotto;

public interface ProdottoService {

	List<Prodotto> getProdotti();
	Prodotto getProdottoById(int id);
	Prodotto addProdotto(Prodotto p);
	Prodotto updateProdotto(Prodotto p);
	void deleteProdotto(int id);

	List<Prodotto> getProdottiByCategoria(String categoria);

	List<String> getCategorie();

}
