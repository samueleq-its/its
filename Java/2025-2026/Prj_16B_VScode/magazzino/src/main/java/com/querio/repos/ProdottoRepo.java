package com.querio.repos;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;

import com.querio.entities.Prodotto;

// @Repository non è necessario
public interface ProdottoRepo extends JpaRepository<Prodotto, Integer> {

	//derived queries
	public List<Prodotto> findByCategoria(String catergoria);
	

}
