package com.samuele.controller;

import org.springframework.web.bind.annotation.RestController;

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

	public TestController(EventoService eventoService) {
		this.eventoService = eventoService;
	}

	@GetMapping("")
	public ResponseEntity<Map<Integer, Evento>> getMethodName() throws IOException {
		return ResponseEntity.ok(eventoService.findAll());
	}

}