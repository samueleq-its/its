package com.samuele.repo;

import java.util.Map;
import java.util.Optional;

import org.springframework.stereotype.Repository;

import com.samuele.entity.Evento;

@Repository
public interface EventoRepo {

	Map<Integer, Evento> findAll();

	Optional<Evento> findByAnno(int anno);

	Map<Integer, Evento> findAllByCategoria(String categoria);
}
