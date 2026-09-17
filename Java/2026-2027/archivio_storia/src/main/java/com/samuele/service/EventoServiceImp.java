package com.samuele.service;

import java.util.List;
import java.util.Optional;

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
	public List<Evento> findAll() {
		return eventoRepo.findAll();
	}

	@Override
	public Optional<Evento> findById(Integer id) {
		return eventoRepo.findById(id);
	}

	@Override
	public Evento save(Evento evento) {
		return eventoRepo.save(evento);
	}

	@Override
	public Evento update(Integer id, Evento eventoDetails) {
		return eventoRepo.findById(id)
				.map(existing -> {
					existing.setAnno(eventoDetails.getAnno());
					existing.setTitolo(eventoDetails.getTitolo());
					existing.setLuogo(eventoDetails.getLuogo());
					existing.setCategoria(eventoDetails.getCategoria());
					existing.setDescrizione(eventoDetails.getDescrizione());
					return eventoRepo.save(existing);
				})
				.orElseThrow(() -> new RuntimeException("Evento non trovato con id: " + id));
	}

	@Override
	public void deleteById(Integer id) {
		if (!eventoRepo.existsById(id)) {
			throw new RuntimeException("Evento non trovato con id: " + id);
		}
		eventoRepo.deleteById(id);
	}

}
