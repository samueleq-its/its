package com.samuele.controller;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.samuele.entity.Evento;
import com.samuele.service.EventoService;

import tools.jackson.core.type.TypeReference;
import tools.jackson.databind.ObjectMapper;

import java.util.List;
import java.util.Map;

import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;

@RestController
@RequestMapping("/api/eventi")
public class EventoController {

	private final EventoService eventoService;
	private final ObjectMapper objectMapper;

	public EventoController(EventoService eventoService, ObjectMapper objectMapper) {
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

}
