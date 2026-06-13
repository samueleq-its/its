package com.querio.controllers;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import com.querio.entities.Prodotto;
import com.querio.services.ProdottoService;

import jakarta.websocket.server.PathParam;

import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.PutMapping;



@RestController
@RequestMapping("/api/prodotti")
public class ProdottoREST {

	@Autowired
	private ProdottoService service;

	@GetMapping("")
	public ResponseEntity<List<Prodotto>> getProdotti() {
		return ResponseEntity.ok(service.getProdotti());
	}

	@GetMapping("{id}")
	public ResponseEntity<Prodotto> getProdottoById(@PathVariable int id) {
		return ResponseEntity.ok(service.getProdottoById(id));
	}
	

	@GetMapping("/categorie")
	public ResponseEntity<List<String>> getCategorie() {
		return ResponseEntity.ok(service.getCategorie());
	}

	@GetMapping("/categoria/{categoria}")
	public ResponseEntity<List<Prodotto>> getProdottiByCategoria(@PathVariable String categoria) {
		return ResponseEntity.ok(service.getProdottiByCategoria(categoria));
	}

	@PostMapping("/new")
	public ResponseEntity<Prodotto> addProdotto(@RequestBody Prodotto p) {
		System.out.println("ADD: " + p);
		if (p.getNome() == null || p.getCategoria() == null) {
			return ResponseEntity.badRequest().build();
		}
		return ResponseEntity.ok(service.addProdotto(p));
	}
	
	@PutMapping("/update")
	public ResponseEntity<Prodotto> updateProdotto(@RequestBody Prodotto p) {
		System.out.println("UPDATE: " + p);
		if (p.getNome() == null || p.getCategoria() == null) {
			return ResponseEntity.badRequest().build();
		}
		return ResponseEntity.ok(service.updateProdotto(p));
	}
	
	@DeleteMapping("/delete/{id}")
	public ResponseEntity<String> delete(@PathVariable int id) {
		System.out.println("DELETE id: " + id);
		service.deleteProdotto(id);
		return ResponseEntity.ok(id + " eliminato");
	}
	

}
