package com.querio.service;

import java.util.List;

import org.springframework.stereotype.Service;

import com.querio.entity.Film;
import com.querio.repo.FilmRepo;

@Service
public class FilmService {
	private final FilmRepo filmRepo;

	public FilmService(FilmRepo fr) {
		this.filmRepo = fr;
	}

	public List<Film> getAll() {
		return filmRepo.findAll();
	}

	public Film getById(int id) {
		return filmRepo.findById(id).orElse(null);
	}

	public Film create(Film f) {
		return filmRepo.save(f);
	}

	public Film update(int id, Film f) {
		f.setId(id);
		return filmRepo.save(f);
	}

	public void delete(int id) {
		filmRepo.deleteById(id);;
	}
}
