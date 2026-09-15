package com.querio.services;

import java.util.List;

import com.querio.entities.ProdottoBar;

public interface ProdottoBarService {

	ProdottoBar getProdottoById(int id);
	List<ProdottoBar> GetAllProdotti();
	List<ProdottoBar> GetProdottiBySezione(String sezione);
	
	List<String> getSezioni();
	
	
	ProdottoBar addProdotto(ProdottoBar prodotto);
	ProdottoBar updateProdotto(ProdottoBar prodotto);
	void deleteProdotto(int id);
	
}
