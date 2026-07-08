package com.querio.service;

import java.util.List;

import org.springframework.stereotype.Service;

import com.querio.entity.Prenotazione;
import com.querio.repo.PrenotazioniRepo;

@Service
public class PrenotazioniService {

	private final PrenotazioniRepo prenotazioniRepo;

	public PrenotazioniService(PrenotazioniRepo pr) {
		this.prenotazioniRepo = pr;
	}

	public List<Prenotazione> getAll() {
		return prenotazioniRepo.findAll();
	}

	public Prenotazione getById(int id) {
		return prenotazioniRepo.findById(id).orElse(null);
	}

	public Prenotazione create(Prenotazione p) {
		return prenotazioniRepo.save(p);
	}

	public Prenotazione update(int id, Prenotazione p) {
		p.setId(id);
		return prenotazioniRepo.save(p);
	}

	public void delete(int id) {
		prenotazioniRepo.deleteById(id);
	}
}