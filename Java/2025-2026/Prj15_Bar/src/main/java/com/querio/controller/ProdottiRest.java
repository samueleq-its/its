package com.querio.controller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import com.querio.entities.ProdottoBar;
import com.querio.services.ProdottoBarService;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;


@RestController
@RequestMapping("/api/prodotti")
public class ProdottiRest {
	
	@Autowired
	private ProdottoBarService service;
	
	@GetMapping("")
	public ResponseEntity<List<ProdottoBar>> prodotti() {
		return ResponseEntity.ok(service.GetAllProdotti());
	}
	
	@GetMapping("/sezione/{sezione}")
	public ResponseEntity<List<ProdottoBar>> ProdottiBySezione(@PathVariable String sezione){
		return ResponseEntity.ok(service.GetProdottiBySezione(sezione));
	}
	
	@GetMapping("/sezioni")
	public ResponseEntity<List<String>> getSezioni() {
		return ResponseEntity.ok(service.getSezioni());
	}
	
	@PostMapping("")
	public ResponseEntity<ProdottoBar> AddProdotto(@RequestBody ProdottoBar p) {
		return ResponseEntity.ok(service.addProdotto(p));
	}
	
	@PostMapping("/tanti")
	public ResponseEntity<List<ProdottoBar>> AddProdotti(@RequestBody List<ProdottoBar> prodotti) {
//		for (ProdottoBar p : prodotti) {
//			service.addProdotto(p);
//		}
		
		prodotti
			.stream()
			.forEach(service::addProdotto);
		
		return ResponseEntity.ok(prodotti);
	}

}
