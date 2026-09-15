package com.querio.service;

import java.util.List;

import org.springframework.stereotype.Service;

import com.querio.entity.Cinema;
import com.querio.repo.CinemaRepo;

@Service
public class CinemaService {

	private final CinemaRepo cinemaRepo;

	public CinemaService(CinemaRepo cr) {
		this.cinemaRepo = cr;
	}

	public List<Cinema> getAll() {
		return cinemaRepo.findAll();
	}

	public Cinema getById(int id) {
		return cinemaRepo.findById(id).orElse(null);
	}

	public Cinema create(Cinema c) {
		return cinemaRepo.save(c);
	}

	public Cinema update(int id, Cinema c) {
		c.setId(id);
		return cinemaRepo.save(c);
	}

	public void delete(int id) {
		cinemaRepo.deleteById(id);
	}
}