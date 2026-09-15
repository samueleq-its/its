package com.querio.service;

import org.springframework.stereotype.Service;

import com.querio.entity.FilmInSala;

@Service
public class ProgrammazioneService {

	private final FilmInSalaService filmInSalaService;
	private final PrenotazioniService prenotazioniService;

	public ProgrammazioneService(FilmInSalaService filmInSalaService, PrenotazioniService prenotazioniService) {

		this.filmInSalaService = filmInSalaService;
		this.prenotazioniService = prenotazioniService;
	}

	public void updatePosti(FilmInSala filmInSala) {
		// get all prenotazioni di quel filmInSala
		// somma il numero posti prenotati
		// aggiorna il numero di posti rimanenti

		int postiPrenotati = prenotazioniService.getAll()
				.stream()
				.filter(p -> p.getFilmInSala().getId() == filmInSala.getId())
				.mapToInt(p -> p.getPostiPrenotati())
				.reduce(0, (acc, item) -> acc + item);

		filmInSala.setPostiRimanenti(filmInSala.getCinema().getPosti() - postiPrenotati);
		filmInSalaService.update(filmInSala.getId(), filmInSala);
	}
}
