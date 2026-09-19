package com.samuele.controller;

import org.springframework.web.bind.annotation.RestController;

import com.samuele.component.PlayerSession;
import com.samuele.entity.Evento;
import com.samuele.service.EventoService;

import java.io.IOException;

import java.util.Map;

import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;

@RestController
@RequestMapping("/api/test")
public class TestController {

	private final EventoService eventoService;

	private final PlayerSession session;

	public TestController(EventoService eventoService, PlayerSession userSession) {
		this.eventoService = eventoService;
		this.session = userSession;
	}

	@GetMapping("")
	public ResponseEntity<Map<Integer, Evento>> test() throws IOException {
		return ResponseEntity.ok(eventoService.findAll());
	}

	@GetMapping("session")
	public ResponseEntity<String> testSessione() {
		return ResponseEntity.ok(session.toString());
	}

}