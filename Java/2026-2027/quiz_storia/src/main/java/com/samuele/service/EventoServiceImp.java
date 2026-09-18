package com.samuele.service;

import java.util.Map;

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

}
