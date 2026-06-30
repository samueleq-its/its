package com.querio.service;

import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.querio.entities.Libretto;
import com.querio.entities.Studente;
import com.querio.repos.LibrettoRepo;
import com.querio.repos.StudenteRepo;

@Service
public class SegreteriaService implements ISegreteriaService {

	private final StudenteRepo studenteRepo;
	private final LibrettoRepo librettoRepo;
	private Map<Integer, Studente> mapStudenti;

	public SegreteriaService(StudenteRepo sr, LibrettoRepo lr) {
		this.studenteRepo = sr;
		this.librettoRepo = lr;
	}

	@Override
	public Studente addStudente(Studente s) {
		return studenteRepo.save(s);
	}

	@Override
	public Libretto addLibretto(Libretto l) {
		return librettoRepo.save(l);
	}


	@Override
	public List<Studente> getStudenti() {
		return studenteRepo.findAll();
	}

	@Override
	public Map<Integer, Studente> getStudentiMap() {

		this.getStudenti()
				.stream()
				.forEach(s -> this.mapStudenti.put(s.getId(), s));

		return this.mapStudenti;
	}

	@Override
	public Optional<Studente> getStudenteById(int id) {
		return studenteRepo.findById(id);
	}

	@Override
	public Optional<Studente> getStudenteByMatricola(String matricola) {
		for (Studente s : getStudenti()) {
			if (s.getLibretto().getNumeroMatricola().equals(matricola)) {
				return getStudenteById(s.getId());
			}
		}
		return null;
	}

}
