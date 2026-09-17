package com.samuele.service;

import java.util.List;
import java.util.Optional;

import com.samuele.entity.Evento;

public interface EventoService {
	List<Evento> findAll();

	Optional<Evento> findById(Integer id);

	Evento save(Evento evento);

	Evento update(Integer id, Evento eventoDetails);

	void deleteById(Integer id);
}
