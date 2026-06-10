package com.querio.controllers;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.RestController;

import com.querio.model.Maglia;
import com.querio.services.TShirtService;
import org.springframework.web.bind.annotation.GetMapping;


@RestController
public class AbbigliamentoREST {
	
	@Autowired
	private TShirtService service;
	
	@GetMapping("/api/magliette")
	public List<Maglia> getMagliette() {
		return service.getmagliette();
	}
	
	
}
