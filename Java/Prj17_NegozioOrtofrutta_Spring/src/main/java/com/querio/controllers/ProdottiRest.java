package com.querio.controllers;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;

import com.querio.entities.Prodotto;
import com.querio.services.ProdottiService;


@Controller
@RequestMapping("/negozio")
public class ProdottiRest {

	@Autowired
	private ProdottiService service;
	
	@GetMapping("")
	public ResponseEntity<List<Prodotto>> getProdotti(){
		return ResponseEntity.ok(service.getProdotti());
	}
	
	@GetMapping("/categoria/{categoria}")
	public ResponseEntity<List<Prodotto>> getProdottiByCategoria(@PathVariable String categoria){
		return ResponseEntity.ok(service.getProdottiByCategoria(categoria));
	}
	
	@GetMapping("/origine/{origine}")
	public ResponseEntity<List<Prodotto>> getProdottiByoOrigine(@PathVariable String origine){
		return ResponseEntity.ok(service.getProdottiByOrigine(origine));
	}
}
