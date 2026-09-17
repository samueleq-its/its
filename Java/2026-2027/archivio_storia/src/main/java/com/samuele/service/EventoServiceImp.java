package com.samuele.service;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Optional;
import java.util.stream.Collector;
import java.util.stream.Collectors;
import java.util.stream.Stream;

import org.springframework.stereotype.Service;

import com.samuele.dto.EventoFilter;
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
		List<Evento> eventi = eventoRepo.findAll();
		eventi.sort((e1, e2) -> e1.getAnno() - e2.getAnno());
		return eventi;

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

	@Override
	public List<Evento> filtra(EventoFilter filter) {
		Stream<Evento> stream = findAll().stream();
		if (filter.anno() != null) {
			stream = stream.filter(e -> e.getAnno() == filter.anno().intValue());
		}
		if (filter.categoria() != null && !filter.categoria().isBlank()) {
			stream = stream.filter(e -> e.getCategoria().equals(filter.categoria()));
		}
		if (filter.civilta() != null && !filter.civilta().isBlank()) {
			stream = stream.filter(e -> e.getCivilta().equals(filter.civilta()));
		}
		if (filter.titolo() != null && !filter.civilta().isBlank()) {
			stream = stream.filter(e -> e.getTitolo().toLowerCase().contains(filter.titolo().toLowerCase()));
		}
		return stream.toList();
	}

	@Override
	public int[] getAnni() {
		return findAll()
				.stream()
				.mapToInt(s -> s.getAnno())
				.distinct()
				.sorted()
				.toArray();
	}

	@Override
	public List<String> getCategorie() {
		return findAll()
				.stream()
				.map(s -> s.getCategoria())
				.distinct()
				.sorted()
				.toList();
	}

	@Override
	public List<String> getCivilta() {
		return findAll()
				.stream()
				.map(s -> s.getCivilta())
				.distinct()
				.sorted()
				.toList();
	}

	@Override
	public int getTotale() {
		return findAll().size();
	}

	@Override
	public Evento getPiuAntico() {
		return findAll().getFirst();
	}

	@Override
	public Evento getPiuRecente() {
		return findAll().getLast();
	}

	@Override
	public Map<String, Integer> getTotalePerCategoria() {

		var totalePerCategorie = new HashMap<String, Integer>();

		for (Evento e : findAll()) {
			int subtotaleCategoria = totalePerCategorie.getOrDefault(e.getCategoria(), 0);
			totalePerCategorie.put(e.getCategoria(), 1 + subtotaleCategoria);
		}

		return totalePerCategorie;
	}

}
