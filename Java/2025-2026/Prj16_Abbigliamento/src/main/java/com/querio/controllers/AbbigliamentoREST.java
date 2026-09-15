package com.querio.controllers;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.RestController;

import com.querio.model.Maglia;
import com.querio.model.Prodotto;
import com.querio.services.TShirtService;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;


@RestController
public class AbbigliamentoREST {
	
	@Autowired
	private TShirtService service;
	
	@GetMapping("/api/magliette")
	public List<Maglia> getMagliette() {
		return service.getmagliette();
	}
	
	@GetMapping("/api/prodotti")
	public ResponseEntity<List<Prodotto>> getProdotti() {
		return ResponseEntity.ok(service.getProdotti());
	}
	
	@GetMapping("/api/prodotti/categoria/{cat}")
	public ResponseEntity<List<Prodotto>> getProdottiByCategoria(@PathVariable String cat) {
		return ResponseEntity.ok(service.getProdottiByCategoria(cat));
	}
}
