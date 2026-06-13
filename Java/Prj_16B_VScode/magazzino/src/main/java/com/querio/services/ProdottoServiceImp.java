package com.querio.services;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.querio.entities.Prodotto;
import com.querio.repos.ProdottoRepo;

@Service
public class ProdottoServiceImp implements ProdottoService {

	@Autowired
	private ProdottoRepo repo;

	// rimpiazza @autowired repo
	// viene caricato una volta sola invece di chiamare il DB
	//private Map<Integer, Prodotto> prodotti;
	

	// public ProdottoServiceImp(ProdottoRepo repo) {
	// 	this.prodotti = new HashMap<>();
	// 	repo
	// 		.findAll()
	// 		.forEach(p -> prodotti.put(p.getId(), p));
	// 	this.repo = repo;	
	// }

	@Override
	public List<Prodotto> getProdotti() {
		// return prodotti.values().stream().toList();
		return repo.findAll();
	}

	@Override
	public Prodotto getProdottoById(int id) {
		return repo.findById(id).orElse(null);
	}

	@Override
	public Prodotto addProdotto(Prodotto p) {
		return repo.save(p);
	}

	@Override
	public Prodotto updateProdotto(Prodotto p) {
		return repo.save(p);
	}

	@Override
	public void deleteProdotto(int id) {
		repo.deleteById(id);
	}

	@Override
	public List<Prodotto> getProdottiByCategoria(String categoria) {
		return repo.findByCategoria(categoria);
	}

	@Override
	public List<String> getCategorie() {
		return repo
				.findAll()
				.stream()
				.map(p -> p.getCategoria())
				.distinct()
				.sorted()
				.toList();
	}

}
