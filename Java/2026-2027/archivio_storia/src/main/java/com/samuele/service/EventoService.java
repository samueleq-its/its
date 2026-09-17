package com.samuele.service;

import java.util.List;
import java.util.Map;
import java.util.Optional;

import com.samuele.dto.EventoFilter;
import com.samuele.entity.Evento;

public interface EventoService {
	List<Evento> findAll();

	Optional<Evento> findById(Integer id);

	Evento save(Evento evento);

	Evento update(Integer id, Evento eventoDetails);

	void deleteById(Integer id);

	List<Evento> filtra(EventoFilter filter);

	int[] getAnni();

	List<String> getCategorie();

	List<String> getCivilta();

	int getTotale();

	Evento getPiuAntico();

	Evento getPiuRecente();

	Map<String, Integer> getTotalePerCategoria();
}
