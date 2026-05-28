package com.querio.integration;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.querio.entities.Automobile;
import com.querio.services.ServizioVeicoli;

@RestController
@RequestMapping("api")
public class AutosaloneREST {

	@Autowired
	private ServizioVeicoli service;
	
	@GetMapping("automobili")
	public List<Automobile> getAutomobili() {
		return service.getAutomobili();
	}
	
	@PostMapping("automobili")
	public Automobile postAutomobili(@RequestBody Automobile a) {
		return service.addAutomobile(a);
	}
}
