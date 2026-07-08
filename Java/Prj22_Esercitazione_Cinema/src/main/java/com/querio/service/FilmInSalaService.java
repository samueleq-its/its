package com.querio.service;

import java.util.List;

import org.springframework.stereotype.Service;

import com.querio.entity.FilmInSala;

import com.querio.repo.FilmInSalaRepo;

@Service
public class FilmInSalaService {

	private final FilmInSalaRepo filmInSalaRepo;

	public FilmInSalaService(FilmInSalaRepo fsr) {
		this.filmInSalaRepo = fsr;
	}

	public List<FilmInSala> getAll() {
		return filmInSalaRepo.findAll();
	}

	public FilmInSala getById(int id) {
		return filmInSalaRepo.findById(id).orElse(null);
	}

	public FilmInSala create(FilmInSala f) {
		return filmInSalaRepo.save(f);
	}

	public FilmInSala update(int id, FilmInSala f) {
		f.setId(id);
		return filmInSalaRepo.save(f);
	}

	public void delete(int id) {
		filmInSalaRepo.deleteById(id);
	}

}