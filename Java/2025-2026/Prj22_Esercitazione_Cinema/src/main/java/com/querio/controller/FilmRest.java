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

import com.querio.entity.Film;
import com.querio.service.FilmService;

@RestController
@RequestMapping("/api/films")
public class FilmRest {

	private final FilmService filmService;

	public FilmRest(FilmService fs) {
		this.filmService = fs;
	}

	@GetMapping("")
	public List<Film> getAll() {
		return filmService.getAll();
	}

	@GetMapping("/{id}")
	public Film getById(@PathVariable int id) {
		return filmService.getById(id);
	}

	@PostMapping("")
	public Film create(@RequestBody Film f) {
		return filmService.create(f);
	}

	@PutMapping("/{id}")
	public Film update(@PathVariable int id, @RequestBody Film f) {
		return filmService.update(id, f);
	}

	@DeleteMapping("/{id}")
	public void delete(@PathVariable int id) {
		filmService.delete(id);
	}
}