package com.samuele.service;

import java.util.Map;
import java.util.Optional;
import java.util.Set;
import java.util.stream.Collectors;

import org.springframework.stereotype.Service;

import com.samuele.entity.Evento;
import com.samuele.repo.EventoRepo;

@Service
public class EventoServiceImp implements EventoService {

	private final EventoRepo eventoRepo;

	public EventoServiceImp(EventoRepo eventoRepo) {
		this.eventoRepo = eventoRepo;
	}

	@Override
	public Map<Integer, Evento> findAll() {
		return eventoRepo.findAll();
	}

	@Override
	public Optional<Evento> findByAnno(int anno) {
		return eventoRepo.findByAnno(anno);
	}

	@Override
	public Map<Integer, Evento> findAllByCategoria(String categoria) {
		return eventoRepo.findAllByCategoria(categoria);
	}

	@Override
	public Set<String> findAllCategorie() {
		return eventoRepo.findAll()
				.values()
				.stream()
				.map(Evento::getCategoria)
				.collect(Collectors.toSet());
	}

	@Override
	public Set<Integer> findAllAnni() {
		return eventoRepo.findAll().keySet();
	}

}
