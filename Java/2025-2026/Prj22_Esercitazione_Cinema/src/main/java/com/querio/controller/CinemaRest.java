package com.querio.controller;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.querio.entity.Cinema;
import com.querio.service.CinemaService;

import java.util.List;

import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;



@RestController
@RequestMapping("/api/cinemas")
public class CinemaRest {

	private final CinemaService cinemaService;

	public CinemaRest(CinemaService cs) {
		this.cinemaService = cs;
	}

	@GetMapping("")
	public List<Cinema> getAll() {
		return cinemaService.getAll();
	}

	@GetMapping("/{id}")
	public Cinema getById(@PathVariable int id) {
		return cinemaService.getById(id);
	}
	
	@PostMapping("")
	public Cinema create(@RequestBody Cinema c) {
		return cinemaService.create(c);
	}
	
	@PutMapping("/{id}")
	public Cinema update(@PathVariable int id, @RequestBody Cinema c) {
		return cinemaService.update(id, c);
	}

	@DeleteMapping("/{id}")
	public void delete(@PathVariable int id) {
		cinemaService.delete(id);
	}
}
