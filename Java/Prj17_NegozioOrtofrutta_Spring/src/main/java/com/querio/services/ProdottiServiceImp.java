package com.querio.services;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.querio.entities.Prodotto;

@Service
public class ProdottiServiceImp implements ProdottiService{

	@Autowired
	private ProdottiRepo repo;
	
	@Override
	public List<Prodotto> getProdotti() {
		return repo.findAll();
	}

	@Override
	public List<Prodotto> getProdottiByCategoria(String categoria) {
		return repo.findByCategoria(categoria);
	}

	@Override
	public List<Prodotto> getProdottiByOrigine(String origine) {
		return repo.findByOrigine(origine);
	}

}
