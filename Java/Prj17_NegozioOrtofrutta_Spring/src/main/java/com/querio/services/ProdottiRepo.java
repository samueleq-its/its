package com.querio.services;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;

import com.querio.entities.Prodotto;

public interface ProdottiRepo extends JpaRepository<Prodotto, Integer>{

	List<Prodotto> findByCategoria(String categoria);
	List<Prodotto> findByOrigine(String origine);

}
