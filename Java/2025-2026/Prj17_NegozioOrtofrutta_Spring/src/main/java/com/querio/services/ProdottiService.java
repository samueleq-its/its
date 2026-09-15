package com.querio.services;

import java.util.List;

import com.querio.entities.Prodotto;

public interface ProdottiService{

	List<Prodotto> getProdotti();
	List<Prodotto> getProdottiByCategoria(String categoria);
	List<Prodotto> getProdottiByOrigine(String origine);

}
