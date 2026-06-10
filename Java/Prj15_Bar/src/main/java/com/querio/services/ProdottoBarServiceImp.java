package com.querio.services;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.querio.entities.ProdottoBar;
import com.querio.repos.ProdottoBarRepo;

@Service
public class ProdottoBarServiceImp implements ProdottoBarService {

	@Autowired
	private ProdottoBarRepo repo;
	
	@Override
	public ProdottoBar getProdottoById(int id) {
		return repo.findById((long)id).orElse(null);
	}

	@Override
	public List<ProdottoBar> GetAllProdotti() {
		return repo.findAll();
	}

	@Override
	public List<ProdottoBar> GetProdottiBySezione(String sezione) {
		return repo.findBySezione(sezione);
	}

	@Override
	public ProdottoBar addProdotto(ProdottoBar prodotto) {
		return repo.save(prodotto);
	}

	@Override
	public ProdottoBar updateProdotto(ProdottoBar prodotto) {
		return repo.save(prodotto);
	}

	@Override
	public void deleteProdotto(int id) {
		repo.deleteById((long)id);		
	}

	@Override
	public List<String> getSezioni() {
		return this.GetAllProdotti()
			.stream()
			.map(p -> p.getSezione())
			.distinct()
			.sorted()
			.toList();
	}

}
