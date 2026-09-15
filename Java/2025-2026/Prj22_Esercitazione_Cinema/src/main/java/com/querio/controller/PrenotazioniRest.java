package com.querio.controller;

import java.util.List;

import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.querio.dto.PrenotazioneDTO;
import com.querio.entity.FilmInSala;
import com.querio.entity.Prenotazione;
import com.querio.service.FilmInSalaService;
import com.querio.service.PrenotazioniService;
import com.querio.service.ProgrammazioneService;

@RestController
@RequestMapping("/api/prenotazioni")
@CrossOrigin
public class PrenotazioniRest {

	private final PrenotazioniService prenotazioniService;
	private final ProgrammazioneService programmazioneService;
	private final FilmInSalaService filmInSalaService;

	public PrenotazioniRest(PrenotazioniService prenotazioniService,
			FilmInSalaService filmInSalaService,
			ProgrammazioneService programmazioneService) {
		this.prenotazioniService = prenotazioniService;
		this.programmazioneService = programmazioneService;
		this.filmInSalaService = filmInSalaService;
	}

	@GetMapping("")
	public List<Prenotazione> getAll() {
		return prenotazioniService.getAll();
	}

	@GetMapping("/{id}")
	public Prenotazione getById(@PathVariable int id) {
		return prenotazioniService.getById(id);
	}

	@PostMapping("")
	public Prenotazione create(@RequestBody PrenotazioneDTO p) {
		// logica dovrebbe stare in servie non nel controller
		Prenotazione nuovaPrenotazione = new Prenotazione();
		nuovaPrenotazione.setNome(p.nome());
		nuovaPrenotazione.setPostiPrenotati(p.postiPrenotati());
		nuovaPrenotazione.setFilmInSala(filmInSalaService.getById(p.idFilmInSala()));

		Prenotazione prenotazione = prenotazioniService.create(nuovaPrenotazione);
		programmazioneService.updatePosti(prenotazione.getFilmInSala());
		return prenotazione;
	}

	@PutMapping("/{id}")
	public Prenotazione update(@PathVariable int id, @RequestBody Prenotazione p) {
		Prenotazione prenotazione = prenotazioniService.update(id, p);
		programmazioneService.updatePosti(prenotazione.getFilmInSala());
		return prenotazione;
	}

	@DeleteMapping("/{id}")
	public void delete(@PathVariable int id) {
		FilmInSala filmInSala = prenotazioniService.getById(id).getFilmInSala();
		prenotazioniService.delete(id);
		programmazioneService.updatePosti(filmInSala);
	}
}