package com.querio.integration;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.querio.entities.Libretto;
import com.querio.entities.Studente;
import com.querio.service.ISegreteriaService;

import java.util.List;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;

@RestController
@RequestMapping("api/studenti")
public class SegreteriaRest {

	private final ISegreteriaService service;

	public SegreteriaRest(ISegreteriaService segreteriaService) {
		this.service = segreteriaService;
	}

	@GetMapping("")
	public List<Studente> getStudenti() {
		return service.getStudenti();
	}

	@PostMapping("")
	public Studente addStudente(@RequestBody Studente s) {
		//la logica dovrebbe stare in service non in repo
		Studente iscritto = service.addStudente(s);

		Libretto l = new Libretto();
		l.setNumeroMatricola("random");
		l.setStudente(s);
		iscritto.setLibretto(l);

		service.addLibretto(l);
		return service.addStudente(iscritto);
	}

}
