package com.querio.controller;

import java.util.List;

import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.querio.entity.FilmInSala;
import com.querio.service.FilmInSalaService;

@RestController
@RequestMapping("/api/film-in-sala")
public class FilmInSalaRest {

	private final FilmInSalaService filmInSalaService;

	public FilmInSalaRest(FilmInSalaService fs) {
		this.filmInSalaService = fs;
	}

	@GetMapping("")
	public List<FilmInSala> getAll() {
		return filmInSalaService.getAll();
	}

	@GetMapping("/{id}")
	public FilmInSala getById(@PathVariable int id) {
		return filmInSalaService.getById(id);
	}

	@PostMapping("")
	public FilmInSala create(@RequestBody FilmInSala f) {
		return filmInSalaService.create(f);
	}

	@PutMapping("/{id}")
	public FilmInSala update(@PathVariable int id, @RequestBody FilmInSala f) {
		return filmInSalaService.update(id, f);
	}

	@DeleteMapping("/{id}")
	public void delete(@PathVariable int id) {
		filmInSalaService.delete(id);
	}
}