package com.querio.repos;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;

import com.querio.entities.ProdottoBar;

public interface ProdottoBarRepo extends JpaRepository<ProdottoBar, Long> {

	// genera automaticamente l'implementazione
	// deve avere nome findBy... e argomento uguale ad una proprietà
	List<ProdottoBar> findBySezione(String sezione);
	
}
