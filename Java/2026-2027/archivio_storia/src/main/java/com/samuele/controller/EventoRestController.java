package com.samuele.controller;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.samuele.dto.EventoFilter;
import com.samuele.entity.Evento;
import com.samuele.service.EventoService;

import tools.jackson.core.type.TypeReference;
import tools.jackson.databind.ObjectMapper;

import java.util.List;
import java.util.Map;

import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestParam;

@RestController
@RequestMapping("/api/eventi")
public class EventoRestController {

	private final EventoService eventoService;
	private final ObjectMapper objectMapper;

	public EventoRestController(EventoService eventoService, ObjectMapper objectMapper) {
		this.eventoService = eventoService;
		this.objectMapper = objectMapper;
	}

	@PostMapping("/import")
	public String postMethodName(@RequestBody Map<String, Object> map) {
		try {
			List<Evento> eventi = objectMapper.convertValue(
					map.get("eventi"),
					new TypeReference<List<Evento>>() {
					});

			eventi.forEach(e -> {
				e.setId(0);
				eventoService.save(e);
			});

			return "eventi caricati";
		} catch (IllegalArgumentException e) {
			return "formato errato";
		}
	}

	@GetMapping
	public ResponseEntity<List<Evento>> getAllEventi() {
		return ResponseEntity.ok(eventoService.findAll());
	}

	@GetMapping("/{id}")
	public ResponseEntity<Evento> getEventoById(@PathVariable Integer id) {
		return eventoService.findById(id)
				.map(ResponseEntity::ok)
				.orElse(ResponseEntity.notFound().build());
	}

	@PostMapping
	public ResponseEntity<Evento> createEvento(@RequestBody Evento evento) {
		evento.setId(0); // Force insert instead of update
		Evento created = eventoService.save(evento);
		return ResponseEntity.status(HttpStatus.CREATED).body(created);
	}

	@PutMapping("/{id}")
	public ResponseEntity<Evento> updateEvento(@PathVariable Integer id, @RequestBody Evento eventoDetails) {
		try {
			Evento updated = eventoService.update(id, eventoDetails);
			return ResponseEntity.ok(updated);
		} catch (RuntimeException e) {
			return ResponseEntity.notFound().build();
		}
	}

	@DeleteMapping("/{id}")
	public ResponseEntity<Void> deleteEvento(@PathVariable Integer id) {
		try {
			eventoService.deleteById(id);
			return ResponseEntity.noContent().build();
		} catch (RuntimeException e) {
			return ResponseEntity.notFound().build();
		}
	}

	@GetMapping("/filtra")
	public ResponseEntity<List<Evento>> filtraEventi(EventoFilter filter) {
		List<Evento> risultati = eventoService.filtra(filter);
		return ResponseEntity.ok(risultati);
	}

	@GetMapping("/anni")
	public ResponseEntity<int[]> getAnni() {
		return ResponseEntity.ok(eventoService.getAnni());
	}

	@GetMapping("/categorie")
	public ResponseEntity<List<String>> getCategorie() {
		return ResponseEntity.ok(eventoService.getCategorie());
	}

	@GetMapping("/civilta")
	public ResponseEntity<List<String>> getCivilta() {
		return ResponseEntity.ok(eventoService.getCivilta());
	}

	@GetMapping("/totale")
	public ResponseEntity<Integer> getTotale() {
		return ResponseEntity.ok(eventoService.getTotale());
	}

	@GetMapping("/piu-antico")
	public ResponseEntity<Evento> getPiuAntico() {
		return ResponseEntity.ok(eventoService.getPiuAntico());
	}

	@GetMapping("/piu-recente")
	public ResponseEntity<Evento> getPiuRecente() {
		return ResponseEntity.ok(eventoService.getPiuRecente());
	}

	@GetMapping("/totale-per-categoria")
	public ResponseEntity<Map<String, Integer>> getTotalePerCategoria() {
		return ResponseEntity.ok(eventoService.getTotalePerCategoria());
	}

}
